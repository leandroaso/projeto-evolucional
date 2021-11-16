import { Injectable } from '@angular/core';
import { CanActivate, CanActivateChild } from '@angular/router';
import { JwtTokenService } from './jwt-token.service';

@Injectable({
  providedIn: 'root'
})
export class TokenGuard implements CanActivate, CanActivateChild {
  constructor(private JwtTokenService: JwtTokenService) { }

  canActivate(): boolean {
    if (this.JwtTokenService.existeTokenNaoExpirado()) {
      return true;
    }

    return false;
  }

  canActivateChild(): boolean {
    return this.canActivate();
  }
}
