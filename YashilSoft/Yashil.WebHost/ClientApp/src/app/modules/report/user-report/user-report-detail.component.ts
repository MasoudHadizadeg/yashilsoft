		

import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {createStore} from 'devextreme-aspnet-data-nojquery';


@Component({
  selector: 'app-user-report-detail',
  templateUrl: './user-report-detail.component.html'
})
export class UserReportDetailComponent extends BaseEdit implements OnInit {
		 userDataSource:any;
	 	 reportDataSource:any;
	   constructor(private genericDataService: GenericDataService) {
    super(genericDataService);
    this.entityName = 'userReport';
  }

  ngOnInit() {
    super.ngOnInit();
							this.userDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'user');
									this.reportDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'reportStore');
				  }      
}
