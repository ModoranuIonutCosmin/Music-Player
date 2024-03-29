import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor, HttpResponse, HttpErrorResponse
} from '@angular/common/http';
import { Observable } from 'rxjs';
import {AuthenticationService} from "../authentication/authentication.service";
import {tap} from "rxjs/operators";
import {Router} from "@angular/router";

@Injectable()
export class UnauthorizedInterceptor implements HttpInterceptor {

  constructor(public auth: AuthenticationService,
              private router: Router) {}
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    return next.handle(request)
      .pipe(tap((event: HttpEvent<any>) => {
      if (event instanceof HttpResponse) {
        // do stuff with response if you want
      }
    }, (err: any) => {
      if (err instanceof HttpErrorResponse) {
        if (err.status === 401) {
          // redirect to the login route
          // or show a modal
          console.log('unauthorized');
          this.auth.logout()
          this.router.navigate(['auth/login'])
        }
      }
    }));
  }
}
