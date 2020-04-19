import {Component, Input, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {CachedKey} from '../tms-enums';
import {CachedDataService} from '../../../shared/services/cached-data.service';


@Component({
    selector: 'app-representation-person-detail',
    templateUrl: './representation-person-detail.component.html'
})
export class RepresentationPersonDetailComponent extends BaseEdit implements OnInit {
    educationalCenterId: number;
    @Input()
    representationId: number;
    @Input()
    personId: number;
    @Input()
    postId: number;
    @Input()
    accessLevelId: number;
    representationDataSource: any;
    personDataSource: any;
    postDataSource: any;
    accessLevels: any[] = [];

    constructor(private genericDataService: GenericDataService, private cachedDataService: CachedDataService) {
        super(genericDataService);
        this.entityName = 'representationPerson';
    }

    ngOnInit() {
        super.ngOnInit();
        const data = this.cachedDataService.getData(CachedKey.AdditionalUserProp);
        if (data) {
            if (data.educationalCenterId) {
                this.educationalCenterId = data.educationalCenterId;
            }
            if (data.representationId) {
                this.representationId = data.representationId;
            }
        }
        if (this.representationId) {
            this.entity.representationId = this.representationId;
        }
        if (this.personId) {
            this.entity.personId = this.personId;
        }
        if (this.postId) {
            this.entity.postId = this.postId;
        }
        if (this.accessLevelId) {
            this.entity.accessLevelId = this.accessLevelId;
        }

        this.representationDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'representation');
        this.personDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'person');
        this.postDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'post');
        this._genericDataService.getEntitiesByEntityNameForSelect(Entity.AccessLevel).subscribe(res => this.accessLevels = res);
    }

    selectedPersonChanged(selectedPersonId: any) {
        this.entity.personId = selectedPersonId;
    }
}
