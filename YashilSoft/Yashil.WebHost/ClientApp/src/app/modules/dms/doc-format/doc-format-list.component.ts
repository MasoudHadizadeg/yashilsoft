import {Component, OnInit} from '@angular/core';
import {DocFormatDetailComponent} from './doc-format-detail.component';

@Component({
    selector: 'app-doc-format-list',
    templateUrl: './doc-format-list.component.html'
})
export class DocFormatListComponent {
    selectedItemId: number;
    columns: any[] = [];
    entityName = 'docFormat';
    detailComponent = DocFormatDetailComponent;

    constructor() {
        this.columns.push({
            caption: 'عنوان',
            dataField: 'title'
        });
        this.columns.push({
            caption: 'فرمت های قابل قبول',
            dataField: 'extensions'
        });

    }
}
