import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {CachedKey} from '../tms-enums';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {CachedDataService} from '../../../shared/services/cached-data.service';


@Component({
    selector: 'app-representation-filter',
    templateUrl: './representation-filter.component.html'
})
export class RepresentationFilterComponent implements OnInit {
    selectedData: any = {};
    @Output()
    selectedRepresentationChanged: EventEmitter<any> = new EventEmitter<any>();
    representationId: number;
    representationDataSource: any;
    selectedCourseCategory: any;
    additionalUserProp: any;
    contentHeight: number;
    @Input()
    postId: number;
    selectedItemId: number;
    columns: any[] = [];
    entityName = 'representationPerson';
    educationalCenterDataSource: any;
    private _educationalCenterId: number;
    @Input()
    set educationalCenterId(value: number) {
        if (this._educationalCenterId !== value) {
            this._educationalCenterId = value;
        }
    }

    get educationalCenterId(): number {
        return this._educationalCenterId;
    }

    constructor(private genericDataService: GenericDataService, private cachedDataService: CachedDataService) {
        this.contentHeight = window.innerHeight - 110;
    }

    ngOnInit(): void {
        this.additionalUserProp = this.cachedDataService.getData(CachedKey.AdditionalUserProp);
        if (this.additionalUserProp && this.additionalUserProp.educationalCenterId) {
            this.educationalCenterId = this.additionalUserProp.educationalCenterId;
        }
        this.educationalCenterDataSource = this.genericDataService.createCustomDatasourceForSelect('id', 'educationalCenter');
    }

    private selectedEducationalCenterChanged(e: any) {
        if (e && e.selectedItem) {
            this.selectedData.educationalCenter = e.selectedItem;
            this.representationId = null;
            this.bindDataSources(e.selectedItem.id);
        }
    }

    private bindDataSources(educationalCenterId) {
        if (educationalCenterId) {
            this.representationDataSource =
                this.genericDataService.createCustomDatasourceWithAction('id', 'representation', `GetByEducationalCenter?educationalCenterId=${educationalCenterId}`);
        } else {
            this.representationDataSource = null;
        }
    }

    onSelectedRepresentationChanged(e: any) {
        if (e && e.selectedItem) {
            this.selectedData.representation = e.selectedItem;
        }
    }

    applyFilter() {
        this.selectedRepresentationChanged.emit(this.selectedData);
    }
}
