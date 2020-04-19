import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';


@Component({
    selector: 'app-post-detail',
    templateUrl: './post-detail.component.html'
})
export class PostDetailComponent extends BaseEdit implements OnInit {
    jobDataSource: any;
    parentDataSource: any;
    accessLevels: any[] = [];

    constructor(private genericDataService: GenericDataService) {
        super(genericDataService);
        this.entityName = 'post';
    }

    ngOnInit() {
        super.ngOnInit();
        this.jobDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'job');
        this.parentDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'post');
        this._genericDataService.getEntitiesByEntityNameForSelect(Entity.AccessLevel).subscribe(res => this.accessLevels = res);
    }
}
