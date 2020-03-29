


import {Component, OnInit} from '@angular/core';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Editable} from '../../../shared/base/classes/editable';


@Component({
    selector: 'app-courses-planning-student-detail-tab-based',
    templateUrl: './courses-planning-student-detail-tab-based.component.html'
})
export class CoursesPlanningStudentDetailTabBasedComponent extends Editable implements OnInit {

    allowEditDesc: boolean;
    tabs: any[] = [];
    constructor(private genericDataService: GenericDataService) {
        super();
        this.entityName = 'coursePlanningStudent';
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
    bindTabs(){

    this.tabs = [
    {id: 1, title: 'دانشجويان شرکت کننده در دوره ', template: 'coursePlanningStudent'},
					 {id: 2, title: 'توضیحات', template: 'description', disabled: !this.allowEditDesc},
				 ];

}


}


