import {Component, OnInit} from '@angular/core';
import {UserRoleDetailComponent} from './user-role-detail.component';

@Component({
    selector: 'app-user-role-list',
    templateUrl: './user-role-list.component.html'
})
export class UserRoleListComponent {
    selectedItemId: number;
    columns: any[] = [];
    entityName = 'userRole';
    detailComponent = UserRoleDetailComponent;

    constructor() {
        this.columns.push({
            caption: 'کاربر',
            dataField: 'userTitle'
        });
        this.columns.push({
            caption: 'نقش',
            dataField: 'roleTitle'
        });

    }
}
