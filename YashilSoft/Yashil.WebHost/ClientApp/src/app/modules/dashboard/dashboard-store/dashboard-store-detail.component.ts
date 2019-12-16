import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';


@Component({
    selector: 'app-dashboard-store-detail',
    templateUrl: './dashboard-store-detail.component.html'
})
export class DashboardStoreDetailComponent extends BaseEdit implements OnInit {
    accessLevelDataSource: any;
    connectionStrings: any[] = [];
    constructor(private genericDataService: GenericDataService) {
        super(genericDataService);
        this.entityName = 'dashboardStore';
    }

    ngOnInit() {
        super.ngOnInit();
        this.accessLevelDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'accessLevel');
        this._genericDataService.getEntitiesByEntityNameForSelect(Entity.YashilConnectionString).subscribe(res => this.connectionStrings = res);
    }
}