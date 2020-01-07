import {Component, Input, OnInit} from '@angular/core';
import {FakeModel} from '../../models/FakeModel';

@Component({
  selector: 'ysh-spa-body-section',
  templateUrl: './spa-body-section.component.html',
  styleUrls: ['./spa-body-section.component.scss']
})
export class SpaBodySectionComponent implements OnInit {

  @Input() section;
  @Input() showBlue;
  @Input() sectionCount;

  cardItems = FakeModel.cardItems;

  constructor() {
  }

  ngOnInit() {
  }

}
