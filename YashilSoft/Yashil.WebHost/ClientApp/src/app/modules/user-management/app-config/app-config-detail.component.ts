		

import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {createStore} from 'devextreme-aspnet-data-nojquery';


@Component({
  selector: 'app-app-config-detail',
  templateUrl: './app-config-detail.component.html'
})
export class AppConfigDetailComponent extends BaseEdit implements OnInit {
	  constructor(private genericDataService: GenericDataService) {
    super(genericDataService);
    this.entityName = 'appConfig';
  }

  ngOnInit() {
    super.ngOnInit();
		  }      
}
