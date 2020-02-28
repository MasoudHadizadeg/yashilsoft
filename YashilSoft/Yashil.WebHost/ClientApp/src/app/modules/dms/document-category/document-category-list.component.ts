import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {DocumentCategoryDetailComponent} from './document-category-detail.component';

@Component({
    selector: 'app-document-category-list',
    templateUrl: './document-category-list.component.html'
})
export class DocumentCategoryListComponent implements OnInit {
    @Output()
    public selectedRowChanged: EventEmitter<any> = new EventEmitter<any>();
    @Input()
    appEntityId: number;
    @Input()
    objectId: number;
    selectedItemId: number;
    columns: any[] = [];
    entityName = 'documentCategory';
    detailComponent = DocumentCategoryDetailComponent;
    customListUrl: string;
    baseListUrl = 'documentCategory/GetEntitiesCustom?';
    additionalData: any;

    constructor() {
        this.columns.push({
            caption: 'عنوان',
            dataField: 'title'
        });
    }

    ngOnInit(): void {
        this.customListUrl = `${this.baseListUrl}appEntityId=${this.appEntityId}&objectId=${this.objectId}`;
        this.additionalData = {appEntityId: this.appEntityId, objectId: this.objectId, parentId: null};
    }

    selectedItemChanged(item: any) {
        this.selectedItemId = item.id;
        this.selectedRowChanged.emit(item);
        this.additionalData.parentId = item.id;
    }
}

