import {Component, OnInit} from '@angular/core';
import {DocTypeDetailComponent} from './doc-type-detail.component';

@Component({
    selector: 'app-doc-type-list',
    templateUrl: './doc-type-list.component.html'
})
export class DocTypeListComponent {
    selectedItemId: number;
    columns: any[] = [];
    entityName = 'docType';
    detailComponent = DocTypeDetailComponent;

    constructor() {
        this.columns.push({
            caption: 'عنوان',
            dataField: 'title'
        });
        this.columns.push({
            caption: 'موجودیت',
            dataField: 'appEntityTitle',
            groupIndex: 1
        });
        this.columns.push({
            caption: 'ترتیب نمایش',
            dataField: 'displayOrder'
        });
        this.columns.push({
            caption: 'حداکثر اندازه',
            dataField: 'maxSize'
        });
        this.columns.push({
            caption: 'حداکثر تعداد',
            dataField: 'maxCount'
        });
        this.columns.push({
            caption: 'فرمت سند',
            dataField: 'docFormatTitle'
        });
        this.columns.push({
            caption: 'آیا فایل تصویر است؟',
            dataField: 'isImage'
        });
        this.columns.push({
            caption: 'آیا عنوان اجبرای است؟',
            dataField: 'isTitleRequired'
        });
        this.columns.push({
            caption: 'آیا نیاز به دسته بندی سند وجود دارد؟',
            dataField: 'isCetegorized'
        });

    }
}
