		

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
			roles: any[] = [];
			dashboards: any[] = [];
	  constructor(private genericDataService: GenericDataService) {
    super(genericDataService);
    this.entityName = 'roleDashboard';
  }

  ngOnInit() {
    super.ngOnInit();
					this._genericDataService.getEntitiesByEntityName(Entity.Role).subscribe(res => this.roles = res);
					this._genericDataService.getEntitiesByEntityName(Entity.Dashboard).subscribe(res => this.dashboards = res);
		  }      
}
