import {Component} from '@angular/core';
import {CoursePlanningStudentDetailComponent} from './course-planning-student-detail.component';


@Component({
    selector: 'app-course-planning-student-list',
    templateUrl: './course-planning-student-list.component.html'
})
export class CoursePlanningStudentListComponent {
    selectedItemId: number;
    columns: any[] = [];
    entityName = 'coursePlanningStudent';
    detailComponent = CoursePlanningStudentDetailComponent;

    constructor() {
        this.columns.push({
            caption: 'دوره',
            dataField: 'coursePlanningTitle'
        });
        this.columns.push({
            caption: 'دانشجو',
            dataField: 'personTitle'
        });
        this.columns.push({
            caption: 'نمره',
            dataField: 'score'
        });

    }
}
