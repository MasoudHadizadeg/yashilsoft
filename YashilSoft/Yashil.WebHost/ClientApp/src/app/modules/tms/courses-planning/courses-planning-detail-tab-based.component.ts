


import {Component, OnInit} from '@angular/core';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Editable} from '../../../shared/base/classes/editable';


@Component({
    selector: 'app-courses-planning-detail-tab-based',
    templateUrl: './courses-planning-detail-tab-based.component.html'
})
export class CoursesPlanningDetailTabBasedComponent extends Editable implements OnInit {
    tabs = [
    {id: 1, title: 'برنامه ريزي دوره', template: 'coursesPlanning'},
					 {id: 2, title: 'توضیحات', template: 'description'},
				 ];

    constructor(private genericDataService: GenericDataService) {
        super();
        this.entityName = 'coursesPlanning';
    }

    ngOnInit() {
    }
}


