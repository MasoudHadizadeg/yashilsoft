		

import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {createStore} from 'devextreme-aspnet-data-nojquery';


@Component({
  selector: 'app-report-group-report-detail',
  templateUrl: './report-group-report-detail.component.html'
})
export class ReportGroupReportDetailComponent extends BaseEdit implements OnInit {
		 reportStoreDataSource:any;
	 	 reportGroupDataSource:any;
	   constructor(private genericDataService: GenericDataService) {
    super(genericDataService);
    this.entityName = 'reportGroupReport';
  }

  ngOnInit() {
    super.ngOnInit();
							this.reportStoreDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'reportStore');
									this.reportGroupDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'reportGroup');
				  }      
}
