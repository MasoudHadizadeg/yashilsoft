		

import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {createStore} from 'devextreme-aspnet-data-nojquery';


@Component({
  selector: 'app-course-detail',
  templateUrl: './course-detail.component.html'
})
export class CourseDetailComponent extends BaseEdit implements OnInit {
		 courseCategoryDataSource:any;
	 	 educationalCenterDataSource:any;
	 					skillTypes: any;
					certificateTypes: any;
					evaluationMethods: any;
		accessLevels: any[] = [];
	  constructor(private genericDataService: GenericDataService) {
    super(genericDataService);
    this.entityName = 'course';
  }

  ngOnInit() {
    super.ngOnInit();
							this.courseCategoryDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'courseCategory');
									this.educationalCenterDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'educationalCenter');
									this._genericDataService.getCommonBaseDataForSelect('SkillType').subscribe(res => this.skillTypes = res);
									this._genericDataService.getCommonBaseDataForSelect('CertificateType').subscribe(res => this.certificateTypes = res);
									this._genericDataService.getCommonBaseDataForSelect('EvaluationMethod').subscribe(res => this.evaluationMethods = res);
							this._genericDataService.getEntitiesByEntityName(Entity.AccessLevel).subscribe(res => this.accessLevels = res);
		  }      
}
