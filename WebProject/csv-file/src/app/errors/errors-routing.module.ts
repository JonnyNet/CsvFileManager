import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { Error500Component } from './500/error-500.component';

const routes: Routes = [
  {
    path: 'error500',
    component: Error500Component,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ErrorsRoutingModule { }
