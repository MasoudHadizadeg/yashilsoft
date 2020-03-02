		

import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {createStore} from 'devextreme-aspnet-data-nojquery';


@Component({
  selector: 'app-representation-detail',
  templateUrl: './representation-detail.component.html'
})
export class RepresentationDetailComponent extends BaseEdit implements OnInit {
		 educationalCenterDataSource:any;
	 	 cityDataSource:any;
	 					licenseTypes: any;
					ownershipTypes: any;
	 accessLevelDataSource:any;
	   constructor(private genericDataService: GenericDataService) {
    super(genericDataService);
    this.entityName = 'representation';
  }

  ngOnInit() {
    super.ngOnInit();
							this.educationalCenterDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'educationalCenter');
									this.cityDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'city');
									this._genericDataService.getCommonBaseDataForSelect('LicenseType').subscribe(res => this.licenseTypes = res);
									this._genericDataService.getCommonBaseDataForSelect('OwnershipType').subscribe(res => this.ownershipTypes = res);
									this.accessLevelDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'accessLevel');
				  }      
}
