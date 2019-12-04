import {Injectable} from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot} from '@angular/router';
import {AuthenticationService} from '../../_services';
import {GenericDataService} from '../base/services/generic-data.service';
import * as moment from 'moment';

@Injectable({providedIn: 'root'})
export class AuthGuard implements CanActivate {
  _isLoggedIn: boolean;
  get isLoggedIn(): boolean {
    return this._isLoggedIn;
  }

  set isLoggedIn(val: boolean) {
    this._isLoggedIn = val;
  }

  constructor(private authService: AuthenticationService, private router: Router, private  genericDataService: GenericDataService) {
    this.authService.isLoggedIn.subscribe(
      x =>
        this.isLoggedIn = x
    );
  }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): boolean {
    if (moment().isBefore(this.getExpiration())) {
      return true;
    }
    this.router.navigate(['pages/login']);
    return false;
  }

  getExpiration() {
    const expiration = localStorage.getItem('expires_at');
    const expiresAt = JSON.parse(expiration);
    // let sourceEpoch = +expiresAt;
    //
    // if (sourceEpoch <= 9999999999) {
    //   sourceEpoch *= 1000;
    // }
    // const date = new Date(sourceEpoch);
    const d = new Date(0); // The 0 there is the key, which sets the date to the epoch
    d.setUTCSeconds(expiresAt);
    return d;
  }
}


