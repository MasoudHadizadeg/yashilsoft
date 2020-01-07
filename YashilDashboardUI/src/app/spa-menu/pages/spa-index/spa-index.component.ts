import {Component, OnInit} from '@angular/core';
import {YashilComponent} from 'yashil-core';

@Component({
  selector: 'ysh-spa-index',
  templateUrl: './spa-index.component.html',
  styleUrls: ['./spa-index.component.scss']
})
export class SpaIndexComponent extends YashilComponent {
  constructor() {
    super();
    this.setBusy(true);
  }
}
