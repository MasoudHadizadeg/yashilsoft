import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';


@Component({
    selector: 'app-application-detail',
    templateUrl: './application-detail.component.html'
})
export class ApplicationDetailComponent extends BaseEdit implements OnInit {
    parents: any[] = [];

    constructor(private genericDataService: GenericDataService) {
        super(genericDataService);
        this.entityName = 'application';
    }

    ngOnInit() {
        super.ngOnInit();
        this._genericDataService.getEntitiesByEntityName(Entity.Application).subscribe(res => this.parents = res);
    }
}
