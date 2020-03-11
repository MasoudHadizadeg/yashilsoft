		

import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {createStore} from 'devextreme-aspnet-data-nojquery';


@Component({
  selector: 'app-representation-person-detail',
  templateUrl: './representation-person-detail.component.html'
})
export class RepresentationPersonDetailComponent extends BaseEdit implements OnInit {
		 representationDataSource:any;
	 	 personDataSource:any;
	 	 postDataSource:any;
	 					cooperationTypes: any;
		accessLevels: any[] = [];
	  constructor(private genericDataService: GenericDataService) {
    super(genericDataService);
    this.entityName = 'representationPerson';
  }

  ngOnInit() {
    super.ngOnInit();
							this.representationDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'representation');
									this.personDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'person');
									this.postDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'post');
									this._genericDataService.getCommonBaseDataForSelect('CooperationType').subscribe(res => this.cooperationTypes = res);
							this._genericDataService.getEntitiesByEntityNameForSelect(Entity.AccessLevel).subscribe(res => this.accessLevels = res);
		  }      
}
