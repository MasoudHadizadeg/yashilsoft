import {Component} from '@angular/core';
import { ScrollTop, ShowScrollButtonFunctionality} from './shared/helper/ScrollFunction';

@Component({
  selector: 'ysh-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor() {
    this.scrollTopButtonFunctionality();
  }

  scrollToTop() {
    ScrollTop();
  }

  scrollTopButtonFunctionality() {
    ShowScrollButtonFunctionality();
  }
}
