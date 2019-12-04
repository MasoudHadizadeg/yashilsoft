		

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
		 parentDataSource:any;
	 	 resourceDataSource:any;
	   constructor(private genericDataService: GenericDataService) {
    super(genericDataService);
    this.entityName = 'menu';
  }

  ngOnInit() {
    super.ngOnInit();
							this.parentDataSource = this._genericDataService.createCustomDatasource('id', 'menu');
									this.resourceDataSource = this._genericDataService.createCustomDatasource('id', 'resource');
				  }      
}
