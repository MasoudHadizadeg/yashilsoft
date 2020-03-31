import {Component, Input, OnInit} from '@angular/core';
import {YashilComponent} from '../../../core/baseClasses/yashilComponent';


@Component({
    selector: 'app-course-select',
    templateUrl: './course-select.component.html'
})
export class CourseSelectComponent extends YashilComponent implements OnInit {
    @Input()
    educationalCenterId: number;
    showCourse = false;
    btnSelectCourseOptions: any;

    constructor() {
        super();
        this.selectCourseClicked = this.selectCourseClicked.bind(this);
    }


    selectCourseClicked(e) {
        this.showCourse = true;
    }

    ngOnInit(): void {
        this.btnSelectCourseOptions = {
            icon: 'plus',
            type: 'default',
            onClick: () => {
                this.showCourse = true;
            }
        }
    }
}
