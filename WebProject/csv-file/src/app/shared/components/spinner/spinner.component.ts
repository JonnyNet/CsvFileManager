import { Component, Input } from '@angular/core';


@Component({
  selector: 'spinner',
  template: `<div class="spinner" *ngIf="active">
              <div class="loading-shade">
                <mat-spinner diameter="70" color="primary"></mat-spinner>
              </div>
            </div>`,
  styleUrls: ['./spinner.component.scss']
})

export class SpinnerComponent {
  @Input()
  active: boolean | null | undefined;
}
