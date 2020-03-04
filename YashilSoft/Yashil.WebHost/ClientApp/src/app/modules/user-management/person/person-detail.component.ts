		

import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {createStore} from 'devextreme-aspnet-data-nojquery';


@Component({
  selector: 'app-person-detail',
  templateUrl: './person-detail.component.html'
})
export class PersonDetailComponent extends BaseEdit implements OnInit {
						genders: any;
					educationGrades: any;
		accessLevels: any[] = [];
	  constructor(private genericDataService: GenericDataService) {
    super(genericDataService);
    this.entityName = 'person';
  }

  ngOnInit() {
    super.ngOnInit();
							this._genericDataService.getCommonBaseDataForSelect('Gender').subscribe(res => this.genders = res);
									this._genericDataService.getCommonBaseDataForSelect('EducationGrade').subscribe(res => this.educationGrades = res);
							this._genericDataService.getEntitiesByEntityName(Entity.AccessLevel).subscribe(res => this.accessLevels = res);
		  }      
}
