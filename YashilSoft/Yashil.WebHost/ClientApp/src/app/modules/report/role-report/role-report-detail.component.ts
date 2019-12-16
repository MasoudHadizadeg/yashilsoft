		

import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {createStore} from 'devextreme-aspnet-data-nojquery';


@Component({
  selector: 'app-role-report-detail',
  templateUrl: './role-report-detail.component.html'
})
export class RoleReportDetailComponent extends BaseEdit implements OnInit {
		 roleDataSource:any;
	 	 reportDataSource:any;
	   constructor(private genericDataService: GenericDataService) {
    super(genericDataService);
    this.entityName = 'roleReport';
  }

  ngOnInit() {
    super.ngOnInit();
							this.roleDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'role');
									this.reportDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'reportStore');
				  }      
}
