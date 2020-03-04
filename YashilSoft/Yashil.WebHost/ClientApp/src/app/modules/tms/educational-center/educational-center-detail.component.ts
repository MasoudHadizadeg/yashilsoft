		

import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {createStore} from 'devextreme-aspnet-data-nojquery';


@Component({
  selector: 'app-educational-center-detail',
  templateUrl: './educational-center-detail.component.html'
})
export class EducationalCenterDetailComponent extends BaseEdit implements OnInit {
			accessLevels: any[] = [];
	  constructor(private genericDataService: GenericDataService) {
    super(genericDataService);
    this.entityName = 'educationalCenter';
  }

  ngOnInit() {
    super.ngOnInit();
					this._genericDataService.getEntitiesByEntityName(Entity.AccessLevel).subscribe(res => this.accessLevels = res);
		  }      
}
