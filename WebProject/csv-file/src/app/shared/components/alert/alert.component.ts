import { Component, OnInit } from '@angular/core';
import { ErrorService } from '../../services/error.service';

@Component({
  selector: 'app-alert',
  templateUrl: './alert.component.html',
  styleUrls: ['./alert.component.scss']
})
export class AlertComponent implements OnInit {

  isShow = false;
  type = 'info'
  title = '';
  message = '';

  constructor(private readonly error: ErrorService) { }

  ngOnInit(): void {
    this.error.stateAlert().subscribe((state: any) => {
      this.isShow = true;
      this.type = state.type;
      this.title = state.title;
      this.message = state.message;
    });
  }
}
