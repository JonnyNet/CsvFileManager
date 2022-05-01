import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CsvRoutingModule } from './csv-routing.module';
import { ListUploadedFilesComponent } from './pages/list-uploaded-files/list-uploaded-files.component';
import { ItemListPerFileComponent } from './pages/item-list-per-file/item-list-per-file.component';
import { SharedModule } from '../shared';
import { FileUploadDialogComponent } from './components/file-upload-dialog/file-upload-dialog.component';


@NgModule({
  declarations: [
    ListUploadedFilesComponent,
    ItemListPerFileComponent,
    FileUploadDialogComponent
  ],
  imports: [
    CommonModule,
    CsvRoutingModule,
    SharedModule,
  ]
})
export class CsvModule { }
