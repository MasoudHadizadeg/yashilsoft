		

import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {createStore} from 'devextreme-aspnet-data-nojquery';


@Component({
  selector: 'app-course-category-detail',
  templateUrl: './course-category-detail.component.html'
})
export class CourseCategoryDetailComponent extends BaseEdit implements OnInit {
		 parentDataSource:any;
	 	 educationalCenterDataSource:any;
	 		accessLevels: any[] = [];
	  constructor(private genericDataService: GenericDataService) {
    super(genericDataService);
    this.entityName = 'courseCategory';
  }

  ngOnInit() {
    super.ngOnInit();
							this.parentDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'courseCategory');
									this.educationalCenterDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'educationalCenter');
							this._genericDataService.getEntitiesByEntityName(Entity.AccessLevel).subscribe(res => this.accessLevels = res);
		  }      
}
