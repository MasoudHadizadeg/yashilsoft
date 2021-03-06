import {Component, OnInit} from '@angular/core';
import {AuthenticationService, GenericDataService, User, YashilComponent} from 'yashil-core';

@Component({
  selector: 'ysh-spa-header',
  templateUrl: './spa-header.component.html',
  styleUrls: ['./spa-header.component.scss']
})
export class SpaHeaderComponent extends YashilComponent implements OnInit {
  userFullName: string;
  user: any = {};

  constructor(private genericDataService: GenericDataService, private authenticationService: AuthenticationService) {
    super();
  }

  signOut() {
    this.authenticationService.logout();
  }

  ngOnInit(): void {
    this.genericDataService.getEntitiesWithAction(`User`, `GetCurrentUserInfo`, null).subscribe((res: any) => {
      this.user = res;
    });
    this.userFullName = this.authenticationService.getPayloadByPropName('family_name');
  }

}
