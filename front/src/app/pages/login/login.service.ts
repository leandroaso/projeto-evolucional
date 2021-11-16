import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: HttpClient) { }

  public gerarToken(usuario): Observable<string> {
    return this.http
      .post<any>(`${environment.API_URL}auth/token`, usuario)
      .pipe(
        map((res) => {
          return res.token;
        })
      );
  }
}
