		

import {Component, Input, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {createStore} from 'devextreme-aspnet-data-nojquery';


@Component({
  selector: 'app-representation-established-license-type-detail',
  templateUrl: './representation-established-license-type-detail.component.html'
})
export class RepresentationEstablishedLicenseTypeDetailComponent extends BaseEdit implements OnInit {
						@Input()
			representationId:number;
						@Input()
			establishedLicenseType:number;
						@Input()
			accessLevelId:number;
					 representationDataSource:any;
	 					establishedLicenseTypes: any;
		accessLevels: any[] = [];
	  constructor(private genericDataService: GenericDataService) {
    super(genericDataService);
    this.entityName = 'representationEstablishedLicenseType';
  }

  ngOnInit() {
    super.ngOnInit();
				if(this.representationId)
				this.entity.representationId=this.representationId;
						if(this.establishedLicenseType)
				this.entity.establishedLicenseType=this.establishedLicenseType;
						if(this.accessLevelId)
				this.entity.accessLevelId=this.accessLevelId;
			
							this.representationDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'representation');
									this._genericDataService.getCommonBaseDataForSelect('EstablishedLicenseType').subscribe(res => this.establishedLicenseTypes = res);
							this._genericDataService.getEntitiesByEntityNameForSelect(Entity.AccessLevel).subscribe(res => this.accessLevels = res);
		  }      
}
