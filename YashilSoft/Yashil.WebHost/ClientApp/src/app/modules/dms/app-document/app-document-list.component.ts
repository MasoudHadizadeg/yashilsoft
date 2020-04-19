import {Component, Input, OnInit} from '@angular/core';
import {AppDocumentDetailComponent} from './app-document-detail.component';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';

@Component({
    selector: 'app-app-document-list',
    templateUrl: './app-document-list.component.html'
})
export class AppDocumentListComponent implements OnInit {
    contentHeight: number;
    selectedItemId: number;
    columns: any[] = [];
    entityName = 'appDocument';
    detailComponent = AppDocumentDetailComponent;
    appEntityDataSource: any;
    selectedAppEntity: any = {};
    selectedAppEntityId: number;
    tabs: any;

    constructor(private genericDataService: GenericDataService) {
        this.contentHeight = window.innerHeight - 110;
        this.selectedAppEntityIdChanged = this.selectedAppEntityIdChanged.bind(this);
    }

    ngOnInit(): void {
        this.appEntityDataSource = this.genericDataService.createCustomDatasourceForSelect('id', 'appEntity');
        this.tabs = [
            {id: 1, title: 'دسته بندی اسناد', template: 'documentCategory'},
            {id: 2, title: 'نوع سند', template: 'docType'},
        ];
    }

    selectedAppEntityIdChanged(item: any) {
        this.selectedAppEntity = item.selectedItem;
    }
}
