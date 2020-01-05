import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';


@Component({
    styleUrls: ['./yashil-connection-string-detail.component.css'],
    selector: 'app-yashil-connection-string-detail',
    templateUrl: './yashil-connection-string-detail.component.html'
})
export class YashilConnectionStringDetailComponent extends BaseEdit implements OnInit {
    dataProviderDataSource: any;

    constructor(private genericDataService: GenericDataService) {
        super(genericDataService);
        this.entityName = 'yashilConnectionString';
        this.setconnectionString = this.setconnectionString.bind(this);
    }

    ngOnInit() {
        super.ngOnInit();
        this.dataProviderDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'yashilDataProvider');
    }

    setconnectionString(e) {
        this.entity.connectionString = e.selectedItem.description;
    }

    getClassName() {
        return 'textLeft';
    }
}
