		

import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {createStore} from 'devextreme-aspnet-data-nojquery';


@Component({
  selector: 'app-user-role-detail',
  templateUrl: './user-role-detail.component.html'
})
export class UserRoleDetailComponent extends BaseEdit implements OnInit {
		 userDataSource:any;
	 	 roleDataSource:any;
	   constructor(private genericDataService: GenericDataService) {
    super(genericDataService);
    this.entityName = 'userRole';
  }

  ngOnInit() {
    super.ngOnInit();
							this.userDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'user');
									this.roleDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'role');
				  }      
}
