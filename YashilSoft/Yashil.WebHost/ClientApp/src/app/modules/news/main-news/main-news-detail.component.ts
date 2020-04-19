		

import {Component, Input, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {createStore} from 'devextreme-aspnet-data-nojquery';


@Component({
  selector: 'app-main-news-detail',
  templateUrl: './main-news-detail.component.html'
})
export class MainNewsDetailComponent extends BaseEdit implements OnInit {
						@Input()
			newsStoreId:number;
						@Input()
			newsPropertyId:number;
					 newsStoreDataSource:any;
	 					newsPropertys: any;
  constructor(private genericDataService: GenericDataService) {
    super(genericDataService);
    this.entityName = 'mainNews';
  }

  ngOnInit() {
    super.ngOnInit();
				if(this.newsStoreId)
				this.entity.newsStoreId=this.newsStoreId;
						if(this.newsPropertyId)
				this.entity.newsPropertyId=this.newsPropertyId;
			
							this.newsStoreDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'newsStore');
									this._genericDataService.getCommonBaseDataForSelect('NewsProperty').subscribe(res => this.newsPropertys = res);
				  }      
}
