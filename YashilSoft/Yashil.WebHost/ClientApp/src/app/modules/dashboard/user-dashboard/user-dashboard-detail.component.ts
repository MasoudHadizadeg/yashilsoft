		

import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {createStore} from 'devextreme-aspnet-data-nojquery';


@Component({
  selector: 'app-user-dashboard-detail',
  templateUrl: './user-dashboard-detail.component.html'
})
export class UserDashboardDetailComponent extends BaseEdit implements OnInit {
		 userDataSource:any;
	 	 dashboardDataSource:any;
	   constructor(private genericDataService: GenericDataService) {
    super(genericDataService);
    this.entityName = 'userDashboard';
  }

  ngOnInit() {
    super.ngOnInit();
							this.userDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'user');
									this.dashboardDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'dashboardStore');
				  }      
}
