		

import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {createStore} from 'devextreme-aspnet-data-nojquery';


@Component({
  selector: 'app-menu-detail',
  templateUrl: './menu-detail.component.html'
})
export class MenuDetailComponent extends BaseEdit implements OnInit {
		 idDataSource:any;
	 	 parentDataSource:any;
	 	 resourceDataSource:any;
	   constructor(private genericDataService: GenericDataService) {
    super(genericDataService);
    this.entityName = 'menu';
  }

  ngOnInit() {
    super.ngOnInit();
							this.idDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'menu');
									this.parentDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'menu');
									this.resourceDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'resource');
				  }      
}
