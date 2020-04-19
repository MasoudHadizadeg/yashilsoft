		

import {Component, Input, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {createStore} from 'devextreme-aspnet-data-nojquery';


@Component({
  selector: 'app-news-keyword-detail',
  templateUrl: './news-keyword-detail.component.html'
})
export class NewsKeywordDetailComponent extends BaseEdit implements OnInit {
						@Input()
			newsStoreId:number;
						@Input()
			keywordId:number;
						@Input()
			accessLevelId:number;
					 newsStoreDataSource:any;
	 	 keywordDataSource:any;
	 		accessLevels: any[] = [];
	  constructor(private genericDataService: GenericDataService) {
    super(genericDataService);
    this.entityName = 'newsKeyword';
  }

  ngOnInit() {
    super.ngOnInit();
				if(this.newsStoreId)
				this.entity.newsStoreId=this.newsStoreId;
						if(this.keywordId)
				this.entity.keywordId=this.keywordId;
						if(this.accessLevelId)
				this.entity.accessLevelId=this.accessLevelId;
			
							this.newsStoreDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'newsStore');
									this.keywordDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'keyword');
							this._genericDataService.getEntitiesByEntityNameForSelect(Entity.AccessLevel).subscribe(res => this.accessLevels = res);
		  }      
}
