import {Component, Inject, Input, OnInit} from '@angular/core';
import {YashilComponent} from '../../../core/baseClasses/yashilComponent';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {CustomDevDataSource} from '../../../shared/base/classes/custom-dev-data-source';
import {HttpClient} from '@angular/common/http';

@Component({
    selector: 'app-assignable-list',
    templateUrl: 'assignable-list.component.html'
})
export class AssignableListComponent extends YashilComponent implements OnInit {
    itemDataSource: any;
    @Input()
    itemEntityTitle: string;
    @Input()
    itemEntityLabel: string;
    @Input()
    columns: any[] = [];
    @Input()
    assignableListTitle: string;
    assignedItemDataSource: any = {};
    notAssignedItemDatasource: any = {};
    httpClient: HttpClient

    constructor(@Inject(HttpClient) httpClient: HttpClient, private genericDataService: GenericDataService) {
        super();
        this.httpClient = httpClient;
    }

    ngOnInit() {
        this.itemDataSource = this.genericDataService.createCustomDatasourceForSelect('id', this.itemEntityTitle);
        this.assignedItemDataSource = new CustomDevDataSource(this.httpClient).getCustomDataSource(this.itemEntityTitle, [], '');
        this.notAssignedItemDatasource = new CustomDevDataSource(this.httpClient).getCustomDataSource(this.itemEntityTitle, [], '');
    }
}
