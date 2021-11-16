import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })

export class InicioService {

  constructor(private http: HttpClient) { }

  public botao1(): Observable<any> {
    return this.http.get<any>(environment.API_URL + 'evolucional/carga-dados');
  }

  public botao2(): Observable<any> {
    return this.http.get(environment.API_URL + 'evolucional/relatorio', { responseType: 'blob' });
  }

  public getRequestOptions(): any {
    return { responseType: 'blob' };
  }
}
