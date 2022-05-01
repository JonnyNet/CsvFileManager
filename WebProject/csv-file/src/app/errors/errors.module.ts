import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ErrorsRoutingModule } from './errors-routing.module';
import { Error500Component } from './500/error-500.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [Error500Component],
  imports: [
    CommonModule,
    ErrorsRoutingModule,
    SharedModule,
  ]
})
export class ErrorsModule { }
