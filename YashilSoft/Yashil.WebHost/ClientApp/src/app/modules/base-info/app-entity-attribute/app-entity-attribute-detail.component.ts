		

import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {createStore} from 'devextreme-aspnet-data-nojquery';


@Component({
  selector: 'app-app-entity-attribute-detail',
  templateUrl: './app-entity-attribute-detail.component.html'
})
export class AppEntityAttributeDetailComponent extends BaseEdit implements OnInit {
			accessLevels: any[] = [];
	  constructor(private genericDataService: GenericDataService) {
    super(genericDataService);
    this.entityName = 'appEntityAttribute';
  }

  ngOnInit() {
    super.ngOnInit();
					this._genericDataService.getEntitiesByEntityName(Entity.AccessLevel).subscribe(res => this.accessLevels = res);
		  }      
}
