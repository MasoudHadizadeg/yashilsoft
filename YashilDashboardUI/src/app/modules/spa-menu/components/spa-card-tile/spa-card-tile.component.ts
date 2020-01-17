import {Component, Input, OnInit, ViewEncapsulation} from '@angular/core';
import {EnvService} from '../../../../shared/services/env.service';
import {DomSanitizer} from '@angular/platform-browser';

@Component({
  selector: 'ysh-spa-card-tile',
  templateUrl: './spa-card-tile.component.html',
  styleUrls: ['./spa-card-tile.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class SpaCardTileComponent implements OnInit {


  @Input()
  cartItem: any = {};

  constructor(private env: EnvService, private sanitizer: DomSanitizer) {
  }

  ngOnInit() {

  }
}
