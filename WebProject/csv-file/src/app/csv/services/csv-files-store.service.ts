import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { delay, map } from 'rxjs';
import { Store } from 'src/app/shared';
import { URLS } from '../constans/urls';
import { CreateCsvFile } from '../models/create-csv-file';
import { CsvFilesStore } from '../models/csv-files-store';
import { CsvFileService } from './csv-file.service';

@Injectable({
  providedIn: 'root'
})
export class CsvFilesStoreService extends Store<CsvFilesStore>{

  readonly loading$ = this.state$.pipe(map(x => x.loading), delay(0));
  readonly files$ = this.state$.pipe(map(x => x.fileCollection));
  readonly items$ = this.state$.pipe(map(x => x.items));
  readonly fileName$ = this.state$.pipe(map(x => x.fileCollection.data.find(file => file.id === x.items.id)?.name));

  constructor(
    private readonly service: CsvFileService,
    private readonly router: Router) {
    super({
      loading: false,
      fileCollection: {
        data: [],
        page: 0,
        pageSize: 0,
        total: 0,
        totalPages: 0,
      },
      items: {
        id: 0,
        data: [],
        total: 0,
      },
    });
  }

  uploadCsvFile(csvFile: CreateCsvFile) {
    this.setLoadingState(true);
    this.service.uploadCsvFile(csvFile).subscribe((result: any) => {
      this.addCsvfile(result, csvFile.name, false);
    });
  }

  getAllCsvFile(page = 1, pageSize = 10) {
    this.setLoadingState(true);
    this.service.getAllCsvFile(page, pageSize).subscribe((result: any) => {
      this.setState({
        ...this.state,
        fileCollection: result,
        loading: false,
      });
    });
  }

  navigateToDataItem(id: number) {
    const items = this.state.items;
    this.setState({
      ...this.state,
      items: {
        ...items,
        id,
      },
    });
    this.router.navigate([URLS.LIST_ITEM.FULLPATH]);
  }

  getFileElemets(page = 1, pageSize = 10) {
    const id = this.state.items.id;
    if (id !== 0) {
      this.setLoadingState(true);
      this.service.getFileElemets(id, page, pageSize).subscribe((res: any) => {
        const items = this.state.items;
        items.data = res.data;
        items.total = res.total;
        this.setState({
          ...this.state,
          items,
          loading: false,
        });
      });
    } else {
      this.router.navigate([URLS.LIST_FILE.FULLPATH]);
    }
  }

  cleanFileData() {
    this.setState({
      ...this.state,
      items: {
        id: 0,
        data: [],
        total: 0,
      },
    });
  }


  getCurrentPage() {
    return this.state.fileCollection.page
  }

  getTotalPage() {
    return this.state.fileCollection.total
  }

  getSavedState() {
    const fileCollection = this.state.fileCollection;
    this.getAllCsvFile(fileCollection.page, fileCollection.pageSize);
  }

  private addCsvfile(id: number, name: string, loading: boolean) {
    const fileCollection = this.state.fileCollection;
    fileCollection.data.push({
      id,
      name,
      createdAt: new Date(),
    });
    this.setState({
      ...this.state,
      fileCollection,
      loading,
    });
  }

  private setLoadingState(state: boolean): void {
    this.setState({
      ...this.state,
      loading: state,
    });
  }
}