import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

export class JwtTokenService {

  public static tokenGetter() {
    return localStorage.getItem('evolucional.access_token');
  }

  constructor() { }

  public guardarToken(token: string): void {
    localStorage.setItem('evolucional.access_token', token);
  }

  public removerToken(): void {
    localStorage.removeItem('evolucional.access_token');
  }

  private token(): string {
    return localStorage.getItem('evolucional.access_token');
  }

  public existeTokenNaoExpirado(): boolean {
    const token = this.token();
    if (!token) {
      return false;
    }
    
    return true;
  }
}
