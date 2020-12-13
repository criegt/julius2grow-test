import { Injectable } from '@angular/core';
import { CanActivate, CanLoad, ActivatedRouteSnapshot, RouterStateSnapshot, Router, Route, UrlSegment, UrlTree } from '@angular/router';

import { Observable } from 'rxjs';
import { AuthService } from 'src/app/services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private authService: AuthService,
              private router: Router) { }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    return this.checkSignedIn(state.url);
  }

  checkSignedIn(url: string): boolean {
    if (this.authService.isSignedIn()) {
      return true;
    }

    this.router.navigate(['/users/sign-in']);
    return false;
  }
}
