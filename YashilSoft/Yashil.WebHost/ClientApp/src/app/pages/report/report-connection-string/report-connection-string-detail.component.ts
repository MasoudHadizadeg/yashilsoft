		

import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {createStore} from 'devextreme-aspnet-data-nojquery';


@Component({
  selector: 'app-report-connection-string-detail',
  templateUrl: './report-connection-string-detail.component.html'
})
export class ReportConnectionStringDetailComponent extends BaseEdit implements OnInit {
		 reportDataSource:any;
	 	 connectionStringDataSource:any;
	   constructor(private genericDataService: GenericDataService) {
    super(genericDataService);
    this.entityName = 'reportConnectionString';
  }

  ngOnInit() {
    super.ngOnInit();
							this.reportDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'reportStore');
									this.connectionStringDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'yashilConnectionString');
				  }      
}
