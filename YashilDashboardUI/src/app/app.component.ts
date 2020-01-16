import {Component} from '@angular/core';
import {ScrollTop, ShowScrollButtonFunctionality} from './shared/helper/ScrollFunction';
import {AuthenticationService, GenericDataService} from 'yashil-core';
import {EnvService} from './shared/services/env.service';

@Component({
  selector: 'ysh-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor(private genericDataService: GenericDataService, private env: EnvService) {
    this.scrollTopButtonFunctionality();
    this.genericDataService.baseUrl = this.env.apiUrl + '/api';
  }

  scrollToTop() {
    ScrollTop();
  }

  scrollTopButtonFunctionality() {
    ShowScrollButtonFunctionality();
  }
}
