		

import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {createStore} from 'devextreme-aspnet-data-nojquery';


@Component({
  selector: 'app-app-entity-attribute-value-detail',
  templateUrl: './app-entity-attribute-value-detail.component.html'
})
export class AppEntityAttributeValueDetailComponent extends BaseEdit implements OnInit {
		 appEntityAttributeMappingDataSource:any;
	 		accessLevels: any[] = [];
	  constructor(private genericDataService: GenericDataService) {
    super(genericDataService);
    this.entityName = 'appEntityAttributeValue';
  }

  ngOnInit() {
    super.ngOnInit();
							this.appEntityAttributeMappingDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'appEntityAttributeMapping');
							this._genericDataService.getEntitiesByEntityName(Entity.AccessLevel).subscribe(res => this.accessLevels = res);
		  }      
}
