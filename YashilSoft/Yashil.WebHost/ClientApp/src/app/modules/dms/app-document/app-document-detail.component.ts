		

import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {createStore} from 'devextreme-aspnet-data-nojquery';


@Component({
  selector: 'app-app-document-detail',
  templateUrl: './app-document-detail.component.html'
})
export class AppDocumentDetailComponent extends BaseEdit implements OnInit {
		 docTypeDataSource:any;
	 	 documentCategoryDataSource:any;
	   constructor(private genericDataService: GenericDataService) {
    super(genericDataService);
    this.entityName = 'appDocument';
  }

  ngOnInit() {
    super.ngOnInit();
							this.docTypeDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'docType');
									this.documentCategoryDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'documentCategory');
				  }      
}
