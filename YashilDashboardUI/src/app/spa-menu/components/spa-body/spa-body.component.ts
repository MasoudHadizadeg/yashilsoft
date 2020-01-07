import {AfterViewInit, Component, OnInit, ViewEncapsulation} from '@angular/core';
import {FakeModel} from '../../models/FakeModel';

@Component({
  selector: 'ysh-spa-body',
  templateUrl: './spa-body.component.html',
  styleUrls: ['./spa-body.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class SpaBodyComponent implements OnInit, AfterViewInit {


  sectionItems = FakeModel.section;

  constructor() {
  }

  ngOnInit() {
  }

  ngAfterViewInit(): void {
  }


}
