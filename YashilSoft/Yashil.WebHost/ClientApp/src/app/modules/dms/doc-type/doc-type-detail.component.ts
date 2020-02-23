import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {createStore} from 'devextreme-aspnet-data-nojquery';


@Component({
    selector: 'app-doc-type-detail',
    templateUrl: './doc-type-detail.component.html'
})
export class DocTypeDetailComponent extends BaseEdit implements OnInit {
    appEntityDataSource: any;
    docFormatDataSource: any;

    constructor(private genericDataService: GenericDataService) {
        super(genericDataService);
        this.entityName = 'docType';
    }

    ngOnInit() {
        super.ngOnInit();
        this.appEntityDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'appEntity');
        this.docFormatDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'docFormat');
    }

    loadEntityData() {
        if (!this.entity.id) {
            this.entity.maxCount = 1;
            this.entity.maxSize = 1024;
        }
        super.loadEntityData();
    }

}
