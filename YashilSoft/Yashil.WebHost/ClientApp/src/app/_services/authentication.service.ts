import {EventEmitter, Injectable, Output} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {map} from 'rxjs/operators';
import {Router} from '@angular/router';
import {CachedDataService} from '../shared/services/cached-data.service';

@Injectable({providedIn: 'root'})
export class AuthenticationService {
  @Output() isLoggedIn: EventEmitter<boolean> = new EventEmitter();
  public loggedInLastState = false;

  constructor(private http: HttpClient, private router: Router, private cachedDataService: CachedDataService) {
  }

  login(username: string, password: string) {
    return this.http.post<any>(`/api/authentication/authenticate`, {username, password})
      .pipe(map(user => {
        // login successful if there's a jwt token in the response
        if (user && user.token) {
          // store user details and jwt token in local storage to keep user logged in between page refreshes
          localStorage.setItem('currentUser', JSON.stringify(user));
          const token = localStorage.getItem('currentUser');
          const payloadHash = JSON.parse(token).token.toString().split('.')[1];
          const payload = JSON.parse(atob(payloadHash));
          this.cachedDataService.claimData = payload;
          const exp = payload.exp;
          const expiresAt = exp; // moment().add(exp, 'second');
          localStorage.setItem('expires_at', JSON.stringify(expiresAt.valueOf()));
          this.isLoggedIn.emit(true);
          this.loggedInLastState = true;
          // this.loggedIn = true;
        } else {
          this.isLoggedIn.emit(false);
          this.loggedInLastState = false;
        }

        return user;
      }));
  }


  logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('currentUser');
    localStorage.removeItem('expires_at');
    this.isLoggedIn.emit(false);
    this.router.navigate(['pages/login']);
  }
}
