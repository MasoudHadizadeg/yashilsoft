import {Component, EventEmitter, Input, OnInit, Output, ViewChild} from '@angular/core';
import {DocumentCategoryDetailComponent} from './document-category-detail.component';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {BaseList} from '../../../shared/base/classes/base-list';

@Component({
    selector: 'app-document-category-list',
    templateUrl: './document-category-list.component.html'
})
export class DocumentCategoryListComponent implements OnInit {
    @ViewChild('documentCategoryForm', {static: true}) documentCategoryForm: BaseList;
    @Output()
    public selectedRowChanged: EventEmitter<any> = new EventEmitter<any>();
    @Input()
    appEntityName: string;
    @Input()
    objectId: number;
    selectedItemId: number;
    columns: any[] = [];
    entityName = 'documentCategory';
    detailComponent = DocumentCategoryDetailComponent;
    customListUrl: string;
    baseListUrl = 'documentCategory/GetEntitiesCustom?';
    additionalData: any;
    appEntityDataSource: any;
    selectedAppEntityId: number;
    contentHeight: number;
    @Input()
    showSelectedAppEntity = true;

    constructor(private genericDataService: GenericDataService) {
        this.columns.push({
            caption: 'موجودیت',
            dataField: 'appEntityTitle'
        });
        this.columns.push({
            caption: 'عنوان',
            dataField: 'title'
        });
    }

    ngOnInit(): void {
        if (this.appEntityName) {
            this.bindDataSources()
        }
        this.additionalData = {appEntityName: this.appEntityName, objectId: this.objectId, parentId: null};
        this.appEntityDataSource = this.genericDataService.createCustomDatasourceForSelect('id', 'appEntity');
    }

    selectedItemChanged(item: any) {
        this.selectedItemId = item.id;
        this.selectedRowChanged.emit(item);
        this.additionalData.parentId = item.id;
    }

    selectedAppEntityIdChanged(item: any) {
        this.appEntityName = item.Title;
        this.bindDataSources();
    }

    private bindDataSources() {
        if (this.appEntityName) {
            this.customListUrl = `${this.baseListUrl}appEntityName=${this.appEntityName}&objectId=${this.objectId}`;
            this.documentCategoryForm.refreshList();
        }
    }
}

