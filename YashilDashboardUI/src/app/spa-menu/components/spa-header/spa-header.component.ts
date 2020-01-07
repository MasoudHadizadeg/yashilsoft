import {Component, OnInit} from '@angular/core';
import {AuthenticationService, User, YashilComponent} from 'yashil-core';

@Component({
  selector: 'ysh-spa-header',
  templateUrl: './spa-header.component.html',
  styleUrls: ['./spa-header.component.scss']
})
export class SpaHeaderComponent extends YashilComponent {

  constructor(private authenticationService: AuthenticationService) {
    super();
  }

  signOut() {
    this.authenticationService.logout();
  }

}
