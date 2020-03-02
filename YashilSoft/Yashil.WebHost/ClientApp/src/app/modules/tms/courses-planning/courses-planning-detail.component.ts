		

import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {createStore} from 'devextreme-aspnet-data-nojquery';


@Component({
  selector: 'app-courses-planning-detail',
  templateUrl: './courses-planning-detail.component.html'
})
export class CoursesPlanningDetailComponent extends BaseEdit implements OnInit {
		 representationDataSource:any;
	 					courceStatuss: any;
	 courseDataSource:any;
	 					implementaionTypes: any;
					courceTypes: any;
					customGenders: any;
	 accessLevelDataSource:any;
	   constructor(private genericDataService: GenericDataService) {
    super(genericDataService);
    this.entityName = 'coursesPlanning';
  }

  ngOnInit() {
    super.ngOnInit();
							this.representationDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'representation');
									this._genericDataService.getCommonBaseDataForSelect('CourceStatus').subscribe(res => this.courceStatuss = res);
									this.courseDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'course');
									this._genericDataService.getCommonBaseDataForSelect('ImplementaionType').subscribe(res => this.implementaionTypes = res);
									this._genericDataService.getCommonBaseDataForSelect('CourceType').subscribe(res => this.courceTypes = res);
									this._genericDataService.getCommonBaseDataForSelect('CustomGender').subscribe(res => this.customGenders = res);
									this.accessLevelDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'accessLevel');
				  }      
}
