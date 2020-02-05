import {Component, Inject, Input, OnInit, ViewChild} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {GenericDataService} from '../../../services/generic-data.service';
import {CustomDevDataSource} from '../../../classes/custom-dev-data-source';
import {DxDataGridComponent} from 'devextreme-angular/ui/data-grid';
import DevExpress from 'devextreme';
import query = DevExpress.data.query;
import array from 'devextreme/ui/file_manager/file_provider/array';

@Component({
    selector: 'app-assignable-list',
    templateUrl: 'assignable-list.component.html'
})
export class AssignableListComponent implements OnInit {
    @ViewChild('notSelectedItems', {static: false}) notSelectedItemsDataGrid: DxDataGridComponent;
    itemDataSource: any;
    @Input()
    selectedGroupItemId: number;
    @Input()
    groupEntityName: string;
    @Input()
    groupEntityLabel: string;
    @Input()
    columns: any[] = [];
    @Input()
    assignableListName: string;
    @Input()
    getAssignedMethodName: string;
    @Input()
    getNotAssignedMethodName: string;
    assignedItemDataSource: any = {};
    notAssignedItemDatasource: any = {};
    httpClient: HttpClient

    constructor(@Inject(HttpClient) httpClient: HttpClient, private genericDataService: GenericDataService) {
        this.httpClient = httpClient;
    }

    ngOnInit() {
        if (this.columns.length === 0) {
            this.columns.push({
                caption: 'عنوان',
                dataField: 'title'
            });
        }
        this.itemDataSource = this.genericDataService.createCustomDatasourceForSelect('id', this.groupEntityName);
    }

    bindLists() {
        if (!this.getAssignedMethodName) {
            this.getAssignedMethodName = `${this.assignableListName}/Get${this.assignableListName}sAssignedTo${this.groupEntityName}Async?id=${this.selectedGroupItemId}`;
        }
        if (!this.getNotAssignedMethodName) {
            this.getNotAssignedMethodName = `${this.assignableListName}/Get${this.assignableListName}sNotAssignedTo${this.groupEntityName}Async?id=${this.selectedGroupItemId}`;
        }
        this.assignedItemDataSource = new CustomDevDataSource(this.httpClient).getCustomDataSourceWithCustomListUrl(this.getAssignedMethodName);
        this.notAssignedItemDatasource = new CustomDevDataSource(this.httpClient).getCustomDataSourceWithCustomListUrl(this.getNotAssignedMethodName);
    }

    selectedGroupItemChanged(data) {
        this.selectedGroupItemId = data.value;
        this.bindLists();
    }

    calculateStatistics() {
        this.notSelectedItemsDataGrid.instance.getSelectedRowsData().then((rowData) => {
            // const commonDuration = 0;
            // let selectedItems = new array();
            // for (let i = 0; i < rowData.length; i++) {
            //     rowData[i]
            // }
        });
    }
}
