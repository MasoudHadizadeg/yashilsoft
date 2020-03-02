		

import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {createStore} from 'devextreme-aspnet-data-nojquery';


@Component({
  selector: 'app-common-base-data-detail',
  templateUrl: './common-base-data-detail.component.html'
})
export class CommonBaseDataDetailComponent extends BaseEdit implements OnInit {
		 parentDataSource:any;
	 	 commonBaseTypeDataSource:any;
	 	 accessLevelDataSource:any;
	   constructor(private genericDataService: GenericDataService) {
    super(genericDataService);
    this.entityName = 'commonBaseData';
  }

  ngOnInit() {
    super.ngOnInit();
							this.parentDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'commonBaseData');
									this.commonBaseTypeDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'commonBaseType');
									this.accessLevelDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'accessLevel');
				  }      
}
