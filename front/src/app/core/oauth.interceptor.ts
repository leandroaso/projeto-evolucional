import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Observable } from 'rxjs';

export class OAuthInterceptor implements HttpInterceptor {
  constructor() { }

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    const token = localStorage.getItem('evolucional.access_token');
    let authReq = req;
    const url = req.url;
    const ehLogin = url.includes('/auth/token');

    if (!ehLogin) {
      if(token) {
        authReq = req.clone({ setHeaders: {
          Authorization: 'Bearer ' + token
        } });
      }
    }

    return next.handle(authReq);
  }
}
