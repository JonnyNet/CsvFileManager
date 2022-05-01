import { AfterViewInit, Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { merge, Observable, startWith, Subscription, timeout } from 'rxjs';
import { FileUploadDialogComponent } from '../../components/file-upload-dialog/file-upload-dialog.component';
import { CsvFileDTO } from '../../models/csv-file-dto';
import { CsvFilesStoreService } from '../../services/csv-files-store.service';

@Component({
  selector: 'app-list-uploaded-files',
  templateUrl: './list-uploaded-files.component.html',
  styleUrls: ['./list-uploaded-files.component.scss']
})
export class ListUploadedFilesComponent implements OnInit, AfterViewInit, OnDestroy {

  displayedColumns: string[] = ['id', 'name', 'createdAt', 'view'];
  dataSource = new MatTableDataSource<CsvFileDTO>();
  resultsLength = 0;
  subscription = new Array<Subscription>();

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private readonly dialog: MatDialog,
    private readonly csvFileService: CsvFilesStoreService) {
  }

  ngOnInit(): void {
    const currentPage = this.csvFileService.getCurrentPage();
    if (currentPage === 0) {
      this.csvFileService.getAllCsvFile();
    }
  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
    this.subscription.push(this.paginator.page.subscribe((page) => {
      this.csvFileService.getAllCsvFile(page.pageIndex + 1, page.pageSize);
    }));

    this.subscription.push(this.csvFileService.files$.subscribe(fileCollection => {
      this.dataSource = new MatTableDataSource(fileCollection.data);
      setTimeout(() => {
        this.resultsLength = fileCollection.total;
      });
      
    }));

    setTimeout(() => {
      this.paginator.pageIndex = this.csvFileService.getCurrentPage() - 1;
    });
  }

  loadFile() {
    const dialogRef = this.dialog.open(FileUploadDialogComponent, {
      width: '40%'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (!!result) {
        this.csvFileService.uploadCsvFile(result);
      }
    });
  }

  goToDataItem(id: number) {
    this.csvFileService.navigateToDataItem(id);
  }

  ngOnDestroy(): void {
    this.subscription.forEach(x => x.unsubscribe());
  }
}
