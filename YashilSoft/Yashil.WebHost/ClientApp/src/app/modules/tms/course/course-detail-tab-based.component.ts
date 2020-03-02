


import {Component, OnInit} from '@angular/core';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Editable} from '../../../shared/base/classes/editable';


@Component({
    selector: 'app-course-detail-tab-based',
    templateUrl: './course-detail-tab-based.component.html'
})
export class CourseDetailTabBasedComponent extends Editable implements OnInit {
    tabs = [
    {id: 1, title: 'دوره', template: 'course'},
					 {id: 2, title: 'معرفی دوره', template: 'description'},
									 {id: 3, title: 'سرفصل دوره', template: 'topic'},
									 {id: 4, title: 'پیش نیاز', template: 'prerequisite'},
									 {id: 5, title: 'اهداف دوره', template: 'target'},
									 {id: 6, title: 'الزامات دوره', template: 'requirements'},
									 {id: 7, title: 'مهارت در انتهای دوره', template: 'skill'},
									 {id: 8, title: 'مخاطب دوره', template: 'audience'},
				 ];

    constructor(private genericDataService: GenericDataService) {
        super();
        this.entityName = 'course';
    }

    ngOnInit() {
    }
}


