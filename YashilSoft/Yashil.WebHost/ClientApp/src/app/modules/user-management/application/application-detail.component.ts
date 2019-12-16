		

import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {createStore} from 'devextreme-aspnet-data-nojquery';


@Component({
  selector: 'app-application-detail',
  templateUrl: './application-detail.component.html'
})
export class ApplicationDetailComponent extends BaseEdit implements OnInit {
	  constructor(private genericDataService: GenericDataService) {
    super(genericDataService);
    this.entityName = 'application';
  }

  ngOnInit() {
    super.ngOnInit();
		  }      
}
