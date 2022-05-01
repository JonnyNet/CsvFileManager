import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';

interface AlertState {
  type: string;
  title: string;
  message: string;
}

@Injectable({
  providedIn: 'root'
})
export class ErrorService {

  private alert = new Subject<AlertState>();

  constructor() { }

  chageStateAlert(data: AlertState): void {
    setTimeout(() => { this.alert.next(data); }, 0);
  }

  stateAlert(): Observable<AlertState> {
    return this.alert.asObservable();
  }
}
