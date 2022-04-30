import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CsvRoutingModule } from './csv-routing.module';
import { ListUploadedFilesComponent } from './pages/list-uploaded-files/list-uploaded-files.component';
import { ItemListPerFileComponent } from './pages/item-list-per-file/item-list-per-file.component';


@NgModule({
  declarations: [
    ListUploadedFilesComponent,
    ItemListPerFileComponent
  ],
  imports: [
    CommonModule,
    CsvRoutingModule
  ]
})
export class CsvModule { }
