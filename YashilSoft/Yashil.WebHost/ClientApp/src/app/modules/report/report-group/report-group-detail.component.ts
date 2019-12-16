import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {createStore} from 'devextreme-aspnet-data-nojquery';


@Component({
    selector: 'app-report-group-detail',
    templateUrl: './report-group-detail.component.html'
})
export class ReportGroupDetailComponent extends BaseEdit implements OnInit {
    constructor(private genericDataService: GenericDataService) {
        super(genericDataService);
        this.entityName = 'reportGroup';
    }

    ngOnInit() {
        super.ngOnInit();
    }
}