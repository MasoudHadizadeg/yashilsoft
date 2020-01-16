import {AfterViewInit, Component, Input, OnInit} from '@angular/core';
import {FakeModel} from '../../models/FakeModel';
import {ActivatedRoute} from '@angular/router';
import {ScrollAfterRouteChange} from '../../../shared/helper/ScrollFunction';

@Component({
  selector: 'ysh-spa-body-section',
  templateUrl: './spa-body-section.component.html',
  styleUrls: ['./spa-body-section.component.scss']
})
export class SpaBodySectionComponent implements OnInit, AfterViewInit {

  @Input() section;
  @Input() showBlue;
  @Input() sectionCount;
  currentMenu;
  @Input()
  cardItems: any[] = []; // = FakeModel.cardItems;

  constructor(private router: ActivatedRoute) {
    this.router.fragment.subscribe((fragment: string) => {
      this.currentMenu = fragment;
    });
  }

  ngOnInit() {
  }

  ngAfterViewInit(): void {
    ScrollAfterRouteChange(this.currentMenu);
  }

}
