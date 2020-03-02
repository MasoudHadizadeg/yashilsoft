		

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
	 	 customCategoryDataSource:any;
	 	 countryDivisionTypeDataSource:any;
	   constructor(private genericDataService: GenericDataService) {
    super(genericDataService);
    this.entityName = 'city';
  }

  ngOnInit() {
    super.ngOnInit();
							this.parentDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'city');
									this.customCategoryDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'commonBaseData');
									this.countryDivisionTypeDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'commonBaseData');
				  }      
}
