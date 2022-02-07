import { HttpInterceptor, HttpRequest, HttpHandler, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, finalize, tap, throwError } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable()
export class LoggingInterceptor implements HttpInterceptor {

  constructor(private authService: AuthService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler) {
    console.log('*************** 2 *********************');

    return next.handle(request)
      .pipe(
        tap({
          // Succeeds when there is a response; ignore other events
          next: (event) => {
            console.log('*************** 3 next *********************');
          },
          // Operation failed; error is an HttpErrorResponse
          error: (error) => {
            console.log('*************** 3 error *********************');
          }
        }),
        // Log when response observable either completes or errors
        finalize(() => {
          console.log('*************** 4 *********************');
        })
      );
  }
}
