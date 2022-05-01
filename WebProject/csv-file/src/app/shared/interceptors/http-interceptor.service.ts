import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, throwError } from 'rxjs';
import { catchError, filter } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class HttpInterceptorService implements HttpInterceptor {

  constructor(private router: Router) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      filter((event: any) => event instanceof HttpResponse),
      catchError((err: HttpErrorResponse) => {
        console.log(err);
        
        if (err.status !== 400) {
          this.router.navigate(['/errors/error500']);
        }
        return throwError(() => err);
      })
    );
  }
}

