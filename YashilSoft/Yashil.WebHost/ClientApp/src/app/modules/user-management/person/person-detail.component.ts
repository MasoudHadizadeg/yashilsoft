		

import {Component, Input, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {createStore} from 'devextreme-aspnet-data-nojquery';


@Component({
  selector: 'app-person-detail',
  templateUrl: './person-detail.component.html'
})
export class PersonDetailComponent extends BaseEdit implements OnInit {
						@Input()
			gender:number;
						@Input()
			educationGrade:number;
						@Input()
			accessLevelId:number;
									genders: any;
					educationGrades: any;
		accessLevels: any[] = [];
	  constructor(private genericDataService: GenericDataService) {
    super(genericDataService);
    this.entityName = 'person';
  }

  ngOnInit() {
    super.ngOnInit();
				if(this.gender)
				this.entity.gender=this.gender;
						if(this.educationGrade)
				this.entity.educationGrade=this.educationGrade;
						if(this.accessLevelId)
				this.entity.accessLevelId=this.accessLevelId;
			
							this._genericDataService.getCommonBaseDataForSelect('Gender').subscribe(res => this.genders = res);
									this._genericDataService.getCommonBaseDataForSelect('EducationGrade').subscribe(res => this.educationGrades = res);
							this._genericDataService.getEntitiesByEntityNameForSelect(Entity.AccessLevel).subscribe(res => this.accessLevels = res);
		  }      
}
