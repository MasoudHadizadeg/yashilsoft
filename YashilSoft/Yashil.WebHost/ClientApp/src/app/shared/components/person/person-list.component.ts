import {Component} from '@angular/core';
import {PersonDetailComponent} from './person-detail.component';


@Component({
    selector: 'app-person-list',
    templateUrl: './person-list.component.html'
})
export class PersonListComponent {
    selectedItemId: number;
    columns: any[] = [];
    entityName = 'person';
    detailComponent = PersonDetailComponent;

    constructor() {
        this.columns.push({
            caption: 'نام',
            dataField: 'name'
        });
        this.columns.push({
            caption: 'نام خانوادگی',
            dataField: 'lastName'
        });
        this.columns.push({
            caption: 'نام پدر',
            dataField: 'fatherName'
        });
        this.columns.push({
            caption: 'جنسیت',
            dataField: 'genderTitle'
        });
        this.columns.push({
            caption: 'تاریخ تولد',
            dataField: 'birthDate',
            cellTemplate: 'intDate'
        });
        this.columns.push({
            caption: 'شماره تلفن',
            dataField: 'phoneNumber'
        });
        this.columns.push({
            caption: 'مدرک تحصیلی',
            dataField: 'educationGradeTitle'
        });
        this.columns.push({
            caption: 'رایانامه (Email)',
            dataField: 'email'
        });
        this.columns.push({
            caption: 'کد ملی',
            dataField: 'nationalCode'
        });

    }
}
