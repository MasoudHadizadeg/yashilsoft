import {Component, OnInit} from '@angular/core';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Editable} from '../../../shared/base/classes/editable';


@Component({
    selector: 'app-course-detail-tab-based',
    templateUrl: './course-detail-tab-based.component.html'
})
export class CourseDetailTabBasedComponent extends Editable implements OnInit {

    allowEditDesc: boolean;
    tabs: any[] = [];
    educationalCenterId: number;
    courseCategoryId: number;

    constructor(private genericDataService: GenericDataService) {
        super();
        this.entityName = 'course';
    }

    ngOnInit() {
        if (this.selectedEntityId && this.selectedEntityId !== 0) {
            this.allowEditDesc = true;
        } else {
            this.allowEditDesc = false;
        }
        this.bindTabs();
    }

    rowInserted(insertedRowId: any) {
        this.selectedEntityId = insertedRowId;
        this.allowEditDesc = true;
        this.bindTabs();
    }

    bindTabs() {

        this.tabs = [
            {id: 1, title: 'دوره', template: 'course'},
            {id: 2, title: 'معرفی دوره', template: 'description', disabled: !this.allowEditDesc},
            {id: 3, title: 'سرفصل دوره', template: 'topic', disabled: !this.allowEditDesc},
            {id: 4, title: 'پیش نیاز', template: 'prerequisite', disabled: !this.allowEditDesc},
            {id: 5, title: 'اهداف دوره', template: 'target', disabled: !this.allowEditDesc},
            {id: 6, title: 'الزامات دوره', template: 'requirements', disabled: !this.allowEditDesc},
            {id: 7, title: 'مهارت در انتهای دوره', template: 'skill', disabled: !this.allowEditDesc},
            {id: 8, title: 'مخاطب دوره', template: 'audience', disabled: !this.allowEditDesc},
        ];

    }


}


