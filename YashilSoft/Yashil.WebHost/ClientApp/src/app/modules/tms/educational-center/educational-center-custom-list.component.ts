import {Component, OnInit} from '@angular/core';
import {CachedKey} from '../tms-enums';
import {CachedDataService} from '../../../shared/services/cached-data.service';


@Component({
    selector: 'app-educational-center-custom-list',
    templateUrl: './educational-center-custom-list.component.html'
})
export class EducationalCenterCustomListComponent implements OnInit {
    selectedItemId: number;
    columns: any[] = [];
    entityName = 'educationalCenter';
    contentHeight: number;
    selectedEducationalCenterId: number;
    representationId: number;
    educationalCenterId: number;
    tabs = [
        {id: 1, title: 'گروه', template: 'courseCategory'},
        {id: 2, title: 'نمایندگی ها', template: 'representation'},
        {id: 3, title: 'دوره', template: 'course'}
    ];

    constructor(private cachedDataService: CachedDataService) {
        this.contentHeight = window.innerHeight - 110;
    }

    selectedRepresentationChange(selectedRepresentation: any) {
    }

    selectedEducationalCenterChange(selectedEducationalCenter: any) {
        this.selectedEducationalCenterId = selectedEducationalCenter.id;
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
