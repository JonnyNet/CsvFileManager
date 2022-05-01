import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { CsvFilesStoreService } from './csv/services/csv-files-store.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  loading$!: Observable<boolean>;

  constructor(private readonly csvFileService: CsvFilesStoreService) {
    this.loading$ = this.csvFileService.loading$;
  }
}
