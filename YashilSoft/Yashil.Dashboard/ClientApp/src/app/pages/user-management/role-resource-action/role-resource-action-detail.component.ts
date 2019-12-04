		

import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {createStore} from 'devextreme-aspnet-data-nojquery';


@Component({
  selector: 'app-role-resource-action-detail',
  templateUrl: './role-resource-action-detail.component.html'
})
export class RoleResourceActionDetailComponent extends BaseEdit implements OnInit {
		 resourceActionDataSource:any;
	 		roles: any[] = [];
	  constructor(private genericDataService: GenericDataService) {
    super(genericDataService);
    this.entityName = 'roleResourceAction';
  }

  ngOnInit() {
    super.ngOnInit();
							this.resourceActionDataSource = this._genericDataService.createCustomDatasource('id', 'resourceAppAction');
							this._genericDataService.getEntitiesByEntityName(Entity.Role).subscribe(res => this.roles = res);
		  }      
}
