import {Component, OnInit} from '@angular/core';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Editable} from '../../../shared/base/classes/editable';
import {CourseExtraPropsComponent} from './course-extra-props';


@Component({
    selector: 'app-custom-course-detail',
    templateUrl: './custom-course.component.html'
})
export class CustomCourseComponent extends Editable implements OnInit {
    tabs: any[] = [];
    extraDetailComponent = CourseExtraPropsComponent;

    constructor(private genericDataService: GenericDataService) {
        super();
        this.entityName = 'course';
    }

    ngOnInit() {
    }
}


