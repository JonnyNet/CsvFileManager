import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CreateCsvFile } from '../models/create-csv-file';

@Injectable({
  providedIn: 'root'
})
export class CsvFileService {

  private urlApi = environment.urlApi;
  private csvFileModule = environment.csvFileModule;

  constructor(private readonly http: HttpClient) { }

  uploadCsvFile(csvFile: CreateCsvFile) {
    return this.http.post(`${this.urlApi}${this.csvFileModule}`, csvFile)
  }

  getAllCsvFile(page: number, pageSize: number) {
    return this.http.get(`${this.urlApi}${this.csvFileModule}`, {
      params: {
        page,
        pageSize,
      },
    }).pipe(
      map((x: any) => {
        let data = x.data;
        data = data.map((item: any) => {
          return {
            ...item,
            createdAt: new Date(item.createdAt),
          };
        });
        return {
          ...x,
          data
        };
      }),
    );
  }

  getFileElemets(id: number, page: number, pageSize: number) {
    return this.http.get(`${this.urlApi}${this.csvFileModule}/${id}/items`, {
      params: {
        page,
        pageSize,
      },
    });
  }
}
