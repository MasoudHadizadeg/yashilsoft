		

import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {createStore} from 'devextreme-aspnet-data-nojquery';


@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html'
})
export class UserDetailComponent extends BaseEdit implements OnInit {
		 organizationDataSource:any;
	 	 accessLevelDataSource:any;
	   constructor(private genericDataService: GenericDataService) {
    super(genericDataService);
    this.entityName = 'user';
  }

  ngOnInit() {
    super.ngOnInit();
							this.organizationDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'organization');
									this.accessLevelDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'accessLevel');
				  }      
}
