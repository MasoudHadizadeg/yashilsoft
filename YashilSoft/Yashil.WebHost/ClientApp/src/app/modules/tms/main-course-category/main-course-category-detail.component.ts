		

import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {createStore} from 'devextreme-aspnet-data-nojquery';


@Component({
  selector: 'app-main-course-category-detail',
  templateUrl: './main-course-category-detail.component.html'
})
export class MainCourseCategoryDetailComponent extends BaseEdit implements OnInit {
			accessLevels: any[] = [];
	  constructor(private genericDataService: GenericDataService) {
    super(genericDataService);
    this.entityName = 'mainCourseCategory';
  }

  ngOnInit() {
    super.ngOnInit();
					this._genericDataService.getEntitiesByEntityNameForSelect(Entity.AccessLevel).subscribe(res => this.accessLevels = res);
		  }      
}
