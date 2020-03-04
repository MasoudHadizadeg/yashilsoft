		

import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {createStore} from 'devextreme-aspnet-data-nojquery';


@Component({
  selector: 'app-city-detail',
  templateUrl: './city-detail.component.html'
})
export class CityDetailComponent extends BaseEdit implements OnInit {
		 parentDataSource:any;
	 					customCategorys: any;
					countryDivisionTypes: any;
  constructor(private genericDataService: GenericDataService) {
    super(genericDataService);
    this.entityName = 'city';
  }

  ngOnInit() {
    super.ngOnInit();
							this.parentDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'city');
									this._genericDataService.getCommonBaseDataForSelect('CustomCategory').subscribe(res => this.customCategorys = res);
									this._genericDataService.getCommonBaseDataForSelect('CountryDivisionType').subscribe(res => this.countryDivisionTypes = res);
				  }      
}
