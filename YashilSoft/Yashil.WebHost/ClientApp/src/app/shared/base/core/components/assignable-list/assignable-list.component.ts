import {Component, Inject, Input, OnInit} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {GenericDataService} from '../../../services/generic-data.service';
import {CustomDevDataSource} from '../../../classes/custom-dev-data-source';

@Component({
    selector: 'app-assignable-list',
    templateUrl: 'assignable-list.component.html'
})
export class AssignableListComponent implements OnInit {
    itemDataSource: any;
    @Input()
    selectedItemId: number;
    @Input()
    itemEntityName: string;
    @Input()
    itemEntityLabel: string;
    @Input()
    columns: any[] = [];
    @Input()
    assignableListName: string;
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
        this.selectedItemId = 2016;
        this.itemDataSource = this.genericDataService.createCustomDatasourceForSelect('id', this.itemEntityName);
        this.assignedItemDataSource = new CustomDevDataSource(this.httpClient).getCustomDataSourceAssignedList(this.assignableListName, [], this.selectedItemId);
        this.notAssignedItemDatasource = new CustomDevDataSource(this.httpClient).getCustomDataSourceNotAssignedList(this.assignableListName, [], this.selectedItemId);
    }
}
