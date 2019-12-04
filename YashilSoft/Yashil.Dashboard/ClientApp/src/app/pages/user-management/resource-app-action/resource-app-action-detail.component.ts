		

import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {createStore} from 'devextreme-aspnet-data-nojquery';


@Component({
  selector: 'app-resource-app-action-detail',
  templateUrl: './resource-app-action-detail.component.html'
})
export class ResourceAppActionDetailComponent extends BaseEdit implements OnInit {
		 appActionDataSource:any;
	 	 resourceDataSource:any;
	   constructor(private genericDataService: GenericDataService) {
    super(genericDataService);
    this.entityName = 'resourceAppAction';
  }

  ngOnInit() {
    super.ngOnInit();
							this.appActionDataSource = this._genericDataService.createCustomDatasource('id', 'appAction');
									this.resourceDataSource = this._genericDataService.createCustomDatasource('id', 'resource');
				  }      
}
