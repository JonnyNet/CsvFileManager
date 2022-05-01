import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatIconModule } from '@angular/material/icon';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HeaderComponent } from './components/header/header.component';
import { AlertComponent } from './components/alert/alert.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatCardModule } from '@angular/material/card';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorIntl, MatPaginatorModule } from '@angular/material/paginator';
import { getDutchPaginatorIntl } from './providers/dutch-paginator-intl';
import { MatDialogModule } from '@angular/material/dialog';
import { ngfModule } from 'angular-file';
import { MatRippleModule } from '@angular/material/core';
import { SpinnerComponent } from './components/spinner/spinner.component';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';


const modules = [
  CommonModule,
  HttpClientModule,
  MatButtonModule,
  MatInputModule,
  MatAutocompleteModule,
  MatIconModule,
  FormsModule,
  ReactiveFormsModule,
  FlexLayoutModule,
  MatCardModule,
  MatTableModule,
  MatPaginatorModule,
  MatDialogModule,
  ngfModule,
  MatRippleModule,
  MatProgressSpinnerModule,
];

const components = [
  HeaderComponent,
  AlertComponent,
  SpinnerComponent,
];

@NgModule({
  declarations: [...components],
  imports: [
    ...modules,
  ],
  exports: [
    ...modules,
    ...components,
  ],
  providers: [{ provide: MatPaginatorIntl, useValue: getDutchPaginatorIntl() }]
})
export class SharedModule { }
