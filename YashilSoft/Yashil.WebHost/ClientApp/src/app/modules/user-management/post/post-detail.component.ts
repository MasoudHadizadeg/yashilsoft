		

import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {createStore} from 'devextreme-aspnet-data-nojquery';


@Component({
  selector: 'app-post-detail',
  templateUrl: './post-detail.component.html'
})
export class PostDetailComponent extends BaseEdit implements OnInit {
		 parentDataSource:any;
	 		accessLevels: any[] = [];
	  constructor(private genericDataService: GenericDataService) {
    super(genericDataService);
    this.entityName = 'post';
  }

  ngOnInit() {
    super.ngOnInit();
							this.parentDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'post');
							this._genericDataService.getEntitiesByEntityName(Entity.AccessLevel).subscribe(res => this.accessLevels = res);
		  }      
}
