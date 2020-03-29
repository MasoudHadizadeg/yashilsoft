		

import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {createStore} from 'devextreme-aspnet-data-nojquery';


@Component({
  selector: 'app-courses-planning-student-detail',
  templateUrl: './courses-planning-student-detail.component.html'
})
export class CoursesPlanningStudentDetailComponent extends BaseEdit implements OnInit {
		 coursePlanningDataSource:any;
	 	 personDataSource:any;
	 		accessLevels: any[] = [];
	  constructor(private genericDataService: GenericDataService) {
    super(genericDataService);
    this.entityName = 'coursePlanningStudent';
  }

  ngOnInit() {
    super.ngOnInit();
							this.coursePlanningDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'coursePlanning');
									this.personDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'person');
							this._genericDataService.getEntitiesByEntityNameForSelect(Entity.AccessLevel).subscribe(res => this.accessLevels = res);
		  }      
}
