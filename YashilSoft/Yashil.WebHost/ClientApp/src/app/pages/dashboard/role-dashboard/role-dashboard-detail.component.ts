		

import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {createStore} from 'devextreme-aspnet-data-nojquery';


@Component({
  selector: 'app-role-dashboard-detail',
  templateUrl: './role-dashboard-detail.component.html'
})
export class RoleDashboardDetailComponent extends BaseEdit implements OnInit {
		 roleDataSource:any;
	 	 dashboardDataSource:any;
	   constructor(private genericDataService: GenericDataService) {
    super(genericDataService);
    this.entityName = 'roleDashboard';
  }

  ngOnInit() {
    super.ngOnInit();
							this.roleDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'role');
									this.dashboardDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'dashboardStore');
				  }      
}
