import {Component, OnInit} from '@angular/core';
import {AppDocumentDetailComponent} from './app-document-detail.component';

@Component({
    selector: 'app-app-document-list',
    templateUrl: './app-document-list.component.html'
})
export class AppDocumentListComponent {
    selectedItemId: number;
    columns: any[] = [];
    entityName = 'appDocument';
    detailComponent = AppDocumentDetailComponent;

    constructor() {
        this.columns.push({
            caption: 'نوع سند',
            dataField: 'docTypeTitle'
        });
        this.columns.push({
            caption: 'عنوان',
            dataField: 'title'
        });
        this.columns.push({
            caption: 'نام واقعی سند',
            dataField: 'orginalName'
        });
        this.columns.push({
            caption: 'گروه سند',
            dataField: 'documentCategoryTitle'
        });
        this.columns.push({
            caption: 'کد مالک سند',
            dataField: 'objectId'
        });
        this.columns.push({
            caption: 'سند',
            dataField: 'documentFile'
        });
        this.columns.push({
            caption: 'توضیح کوتاه',
            dataField: 'shortDescription'
        });
        this.columns.push({
            caption: 'ترتیب نمایش',
            dataField: 'displayOrder'
        });

    }
}
