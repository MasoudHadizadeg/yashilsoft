		

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
	 representationPersonDataSource:any;
	 	 courseDataSource:any;
	 					ageCategorys: any;
					implementaionTypes: any;
					courceTypes: any;
					runTypes: any;
					customGenders: any;
		accessLevels: any[] = [];
	  constructor(private genericDataService: GenericDataService) {
    super(genericDataService);
    this.entityName = 'coursesPlanning';
  }

  ngOnInit() {
    super.ngOnInit();
							this.representationDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'representation');
									this._genericDataService.getCommonBaseDataForSelect('CourceStatus').subscribe(res => this.courceStatuss = res);
									this.representationPersonDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'representationPerson');
									this.courseDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'course');
									this._genericDataService.getCommonBaseDataForSelect('AgeCategory').subscribe(res => this.ageCategorys = res);
									this._genericDataService.getCommonBaseDataForSelect('ImplementaionType').subscribe(res => this.implementaionTypes = res);
									this._genericDataService.getCommonBaseDataForSelect('CourceType').subscribe(res => this.courceTypes = res);
									this._genericDataService.getCommonBaseDataForSelect('RunType').subscribe(res => this.runTypes = res);
									this._genericDataService.getCommonBaseDataForSelect('CustomGender').subscribe(res => this.customGenders = res);
							this._genericDataService.getEntitiesByEntityNameForSelect(Entity.AccessLevel).subscribe(res => this.accessLevels = res);
		  }      
}
