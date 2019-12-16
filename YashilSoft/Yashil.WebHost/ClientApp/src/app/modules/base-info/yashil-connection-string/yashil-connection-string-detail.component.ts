import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';


@Component({
    selector: 'app-yashil-connection-string-detail',
    templateUrl: './yashil-connection-string-detail.component.html'
})
export class YashilConnectionStringDetailComponent extends BaseEdit implements OnInit {
    dataProviderDataSource: any;

    constructor(private genericDataService: GenericDataService) {
        super(genericDataService);
        this.entityName = 'yashilConnectionString';
    }

    ngOnInit() {
        super.ngOnInit();
        this.dataProviderDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'yashilDataProvider');
    }
}
