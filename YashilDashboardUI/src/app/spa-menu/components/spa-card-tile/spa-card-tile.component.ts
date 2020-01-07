import {Component, Input, OnInit, ViewEncapsulation} from '@angular/core';

@Component({
  selector: 'ysh-spa-card-tile',
  templateUrl: './spa-card-tile.component.html',
  styleUrls: ['./spa-card-tile.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class SpaCardTileComponent implements OnInit {


  @Input() cartItem;

  constructor() {
  }

  ngOnInit() {
  }

}
