		

import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {createStore} from 'devextreme-aspnet-data-nojquery';


@Component({
  selector: 'app-organization-detail',
  templateUrl: './organization-detail.component.html'
})
export class OrganizationDetailComponent extends BaseEdit implements OnInit {
		 parentDataSource:any;
	   constructor(private genericDataService: GenericDataService) {
    super(genericDataService);
    this.entityName = 'organization';
  }

  ngOnInit() {
    super.ngOnInit();
							this.parentDataSource = this._genericDataService.createCustomDatasource('id', 'organization');
				  }      
}
