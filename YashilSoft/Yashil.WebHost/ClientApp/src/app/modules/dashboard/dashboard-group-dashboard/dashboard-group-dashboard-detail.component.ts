import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {createStore} from 'devextreme-aspnet-data-nojquery';


@Component({
    selector: 'app-dashboard-group-dashboard-detail',
    templateUrl: './dashboard-group-dashboard-detail.component.html'
})
export class DashboardGroupDashboardDetailComponent extends BaseEdit implements OnInit {
    dashboardStoreDataSource: any;
    dashboardGroupDataSource: any;

    constructor(private genericDataService: GenericDataService) {
        super(genericDataService);
        this.entityName = 'dashboardGroupDashboard';
    }

    ngOnInit() {
        super.ngOnInit();
        this.dashboardStoreDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'dashboardStore');
        this.dashboardGroupDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'dashboardGroup');
    }
}
