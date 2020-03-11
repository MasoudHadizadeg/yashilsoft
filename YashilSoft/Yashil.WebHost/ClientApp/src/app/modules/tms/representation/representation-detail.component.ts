import {Component, Input, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';


@Component({
    selector: 'app-representation-detail',
    templateUrl: './representation-detail.component.html'
})
export class RepresentationDetailComponent extends BaseEdit implements OnInit {
    @Input()
    educationalCenterId: number;
    educationalCenterDataSource: any;
    cityDataSource: any;
    licenseTypes: any;
    ownershipTypes: any;
    establishedLicenseTypes: any;
    accessLevels: any[] = [];

    constructor(private genericDataService: GenericDataService) {
        super(genericDataService);
        this.entityName = 'representation';
        this.allowSetEducationalCenter = this.allowSetEducationalCenter.bind(this);
    }

    ngOnInit() {
        super.ngOnInit();
        if (!this.selectedEntityId && this.educationalCenterId) {
            this.entity.educationalCenterId = this.educationalCenterId;
        }
        this.educationalCenterDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'educationalCenter');
        this.cityDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'city');
        this._genericDataService.getCommonBaseDataForSelect('LicenseType').subscribe(res => this.licenseTypes = res);
        this._genericDataService.getCommonBaseDataForSelect('OwnershipType').subscribe(res => this.ownershipTypes = res);
        this._genericDataService.getCommonBaseDataForSelect('EstablishedLicenseType').subscribe(res => this.establishedLicenseTypes = res);
        this._genericDataService.getEntitiesByEntityNameForSelect(Entity.AccessLevel).subscribe(res => this.accessLevels = res);
    }

    allowSetEducationalCenter() {
        return this.educationalCenterId != null && this.educationalCenterId !== undefined;
    }
}
