import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class ErrorInterceptorService {

  constructor(
    private AuthService: AuthService,
    private router: Router,
  ) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(catchError(err => {
      if (err.status === 401) {
        if (!request.url.includes('login')) {
          location.reload();
        }
      } else if (err.status === 404) {
        this.router.navigate(['not-found']);
      }
      const error = err.error.message || err.statusText;
      return throwError(error);
    }));
  }
}
