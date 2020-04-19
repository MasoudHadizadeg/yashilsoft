import {Component, OnInit} from '@angular/core';
import {EducationalCenterDetailTabBasedComponent} from './educational-center-detail-tab-based.component';
import {CachedKey} from '../tms-enums';
import {CachedDataService} from '../../../shared/services/cached-data.service';


@Component({
    selector: 'app-educational-center-list',
    templateUrl: './educational-center-list.component.html'
})
export class EducationalCenterListComponent implements OnInit {
    selectedItemId: number;
    columns: any[] = [];
    entityName = 'educationalCenter';
    detailComponent = EducationalCenterDetailTabBasedComponent;
    representationId: number;
    educationalCenterId: number;

    constructor(private cachedDataService: CachedDataService) {
        this.columns.push({
            caption: 'عنوان',
            dataField: 'title',
            width: '70%'

        });

        this.columns.push({
            caption: 'نوع مجوز تاسیس',
            dataField: 'establishedLicenseTypeTitle'
        });

    }

    ngOnInit(): void {
        const data = this.cachedDataService.getData(CachedKey.AdditionalUserProp);
        if (data) {
            if (data.educationalCenterId) {
                this.educationalCenterId = data.educationalCenterId;
            }
            if (data.representationId) {
                this.representationId = data.representationId;
            }
        }
    }
}
