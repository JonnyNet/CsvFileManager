import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { URLS } from './constans/urls';
import { ItemListPerFileComponent } from './pages/item-list-per-file/item-list-per-file.component';
import { ListUploadedFilesComponent } from './pages/list-uploaded-files/list-uploaded-files.component';

const routes: Routes = [
  {
    path: URLS.LIST_FILE.PATH,
    component: ListUploadedFilesComponent,
  },
  {
    path: URLS.LIST_ITEM.PATH,
    component: ItemListPerFileComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CsvRoutingModule { }
