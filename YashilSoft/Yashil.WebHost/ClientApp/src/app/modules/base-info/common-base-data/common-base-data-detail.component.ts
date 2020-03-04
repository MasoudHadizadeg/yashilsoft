		

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
						parents: any;
	 commonBaseTypeDataSource:any;
	 		accessLevels: any[] = [];
	  constructor(private genericDataService: GenericDataService) {
    super(genericDataService);
    this.entityName = 'commonBaseData';
  }

  ngOnInit() {
    super.ngOnInit();
							this._genericDataService.getCommonBaseDataForSelect('Parent').subscribe(res => this.parents = res);
									this.commonBaseTypeDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'commonBaseType');
							this._genericDataService.getEntitiesByEntityName(Entity.AccessLevel).subscribe(res => this.accessLevels = res);
		  }      
}
