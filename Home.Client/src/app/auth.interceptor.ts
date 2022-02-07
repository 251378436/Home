import { HttpInterceptor, HttpRequest, HttpHandler, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, throwError } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  private secureRoutes = ['https://localhost:5001'];

  constructor(private authService: AuthService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler) {
    console.log('*************** 1  *********************');
    if (!this.secureRoutes.find((x) => request.url.startsWith(x))) {
      return next.handle(request);
    }

    const token = this.authService.getAuthorizationHeaderValue();

    if (!token) {
      return next.handle(request);
    }

    request = request.clone({
      headers: request.headers.set('Authorization', 'Bearer ' + token),
    });

    return next.handle(request)
            .pipe(
                catchError(this.handleError)
            );
  }

    private handleError(error: HttpErrorResponse) {
        console.log('*************** 1 error *********************');
        if (error.status === 0) {
        // A client-side or network error occurred. Handle it accordingly.
        console.error('An error occurred:', error.error);
        } else {
        // The backend returned an unsuccessful response code.
        // The response body may contain clues as to what went wrong.
        console.error(
            `Backend returned code ${error.status}, body was: `, error.error);
        }
        // Return an observable with a user-facing error message.
        return throwError(() => new Error('Something bad happened; please try again later.'));
    }
}
