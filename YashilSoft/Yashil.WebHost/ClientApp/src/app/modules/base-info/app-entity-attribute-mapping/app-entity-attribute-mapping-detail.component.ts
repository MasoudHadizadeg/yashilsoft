import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {createStore} from 'devextreme-aspnet-data-nojquery';


@Component({
    selector: 'app-app-entity-attribute-mapping-detail',
    templateUrl: './app-entity-attribute-mapping-detail.component.html'
})
export class AppEntityAttributeMappingDetailComponent extends BaseEdit implements OnInit {
    appEntityDataSource: any;
    appEntityAttributeDataSource: any;
    attributeControlTypes: any;
    accessLevels: any[] = [];

    constructor(private genericDataService: GenericDataService) {
        super(genericDataService);
        this.entityName = 'appEntityAttributeMapping';
    }

    ngOnInit() {
        super.ngOnInit();
        this.appEntityDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'appEntity');
        this.appEntityAttributeDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'appEntityAttribute');
        this._genericDataService.getCommonBaseDataForSelect('AttributeControlType').subscribe(res => this.attributeControlTypes = res);
        this._genericDataService.getEntitiesByEntityName(Entity.AccessLevel).subscribe(res => this.accessLevels = res);
    }
}
