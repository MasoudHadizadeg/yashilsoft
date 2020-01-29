import {Component} from '@angular/core';
import {UserDetailComponent} from './user-detail.component';

@Component({
    selector: 'app-user-list',
    templateUrl: './user-list.component.html'
})
export class UserListComponent {
    selectedItemId: number;
    columns: any[] = [];
    entityName = 'user';
    detailComponent = UserDetailComponent;

    constructor() {
        this.columns.push({
            caption: 'نام کاربری',
            dataField: 'userName'
        });
        this.columns.push({
            caption: 'نام',
            dataField: 'firstName'
        });
        this.columns.push({
            caption: 'نام خانوادگی',
            dataField: 'lastName'
        });
        this.columns.push({
            caption: 'کد ملی',
            dataField: 'nationalCode'
        });
        this.columns.push({
            caption: 'ایمیل',
            dataField: 'email'
        });
        this.columns.push({
            caption: 'فعال',
            dataField: 'isActive'
        });
        this.columns.push({
            caption: 'سازمان',
            dataField: 'organizationTitle'
        });
    }
}
