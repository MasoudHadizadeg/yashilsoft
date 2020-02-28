import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {createStore} from 'devextreme-aspnet-data-nojquery';


@Component({
    selector: 'app-document-category-detail',
    templateUrl: './document-category-detail.component.html'
})
export class DocumentCategoryDetailComponent extends BaseEdit implements OnInit {
    parentDataSource: any;
    appEntityDataSource: any;

    constructor(private genericDataService: GenericDataService) {
        super(genericDataService);
        this.entityName = 'documentCategory';
    }

    ngOnInit() {
        super.ngOnInit();
        this.parentDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'documentCategory');
        this.appEntityDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'appEntity');
        this.entity.appEntityId = this.additionalData.appEntityId;
        this.entity.objectId = this.additionalData.objectId;
        this.entity.parentId = this.additionalData.parentId;
    }
}
