import { AfterViewInit, Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute } from '@angular/router';
import { Observable, Subscription } from 'rxjs';
import { CsvFilesStoreService } from '../../services/csv-files-store.service';

@Component({
  selector: 'app-item-list-per-file',
  templateUrl: './item-list-per-file.component.html',
  styleUrls: ['./item-list-per-file.component.scss']
})
export class ItemListPerFileComponent implements OnInit, AfterViewInit, OnDestroy {

  displayedColumns: string[] = [];
  dataSource = new MatTableDataSource<any>();
  resultsLength = 0;
  id!: string;
  fileName$!: Observable<string | undefined>;
  itemsHeader$!: Observable<string[]>;

  subscription = new Array<Subscription>();

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private readonly csvFileService: CsvFilesStoreService) {
    this.fileName$ = this.csvFileService.fileName$;
    this.subscription.push(this.csvFileService.items$.subscribe((listItem) => {
      const firstItem = listItem.data[0] || [];
      this.displayedColumns = Object.keys(firstItem);
      this.dataSource = new MatTableDataSource<any>(listItem.data);
      this.resultsLength = listItem.total;
    }));
  }

  ngOnInit(): void {
    this.csvFileService.getFileElemets();
  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
    this.subscription.push(this.paginator.page.subscribe((page) => {
      this.csvFileService.getFileElemets(page.pageIndex + 1, page.pageSize);
    }));
  }

  ngOnDestroy(): void {
    this.csvFileService.cleanFileData();
    this.subscription.forEach(x => x.unsubscribe());
  }
}
