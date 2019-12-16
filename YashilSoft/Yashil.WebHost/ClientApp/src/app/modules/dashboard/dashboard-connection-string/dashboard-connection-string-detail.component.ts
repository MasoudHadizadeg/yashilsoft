import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';


@Component({
    selector: 'app-dashboard-connection-string-detail',
    templateUrl: './dashboard-connection-string-detail.component.html'
})
export class DashboardConnectionStringDetailComponent extends BaseEdit implements OnInit {
    dashboardDataSource: any;
    connectionStringDataSource: any;

    constructor(private genericDataService: GenericDataService) {
        super(genericDataService);
        this.entityName = 'dashboardConnectionString';
    }

    ngOnInit() {
        super.ngOnInit();
        this.dashboardDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'dashboardStore');
        this.connectionStringDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'yashilConnectionString');
    }
}
