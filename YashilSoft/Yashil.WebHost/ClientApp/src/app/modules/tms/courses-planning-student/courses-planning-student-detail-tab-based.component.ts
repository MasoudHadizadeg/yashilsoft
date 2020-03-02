


import {Component, OnInit} from '@angular/core';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Editable} from '../../../shared/base/classes/editable';


@Component({
    selector: 'app-courses-planning-student-detail-tab-based',
    templateUrl: './courses-planning-student-detail-tab-based.component.html'
})
export class CoursesPlanningStudentDetailTabBasedComponent extends Editable implements OnInit {
    tabs = [
    {id: 1, title: 'دانشجويان شرکت کننده در دوره ', template: 'coursesPlanningStudent'},
					 {id: 2, title: 'توضیحات', template: 'description'},
				 ];

    constructor(private genericDataService: GenericDataService) {
        super();
        this.entityName = 'coursesPlanningStudent';
    }

    ngOnInit() {
    }
}


