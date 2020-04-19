import {Component, Inject, Input, OnInit, ViewChild} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {GenericDataService} from '../../../services/generic-data.service';
import {CustomDevDataSource} from '../../../classes/custom-dev-data-source';
import {DxDataGridComponent} from 'devextreme-angular/ui/data-grid';
import notify from 'devextreme/ui/notify';
import {custom} from 'devextreme/ui/dialog';

@Component({
    selector: 'app-assignable-list',
    templateUrl: 'assignable-list.component.html'
})
export class AssignableListComponent implements OnInit {
    @Input()
    allowEditAssignedItems = false;
    gridHeight = 400;
    @ViewChild('notSelectedItemsGrid', {static: false}) notSelectedItemsDataGrid: DxDataGridComponent;
    @ViewChild('selectedItemsGrid', {static: false}) selectedItemsDataGrid: DxDataGridComponent;
    itemDataSource: any;
    @Input()
    selectedGroupItemId: number;
    selectedGroupItemTitle: string;
    /**
     * @param groupEntityName  The Name Of Entity For Group By.
     */
    @Input()
    groupEntityName: string;
    /**
     * @param assignableListName The Name Of Entity For Grouping.
     */
    @Input()
    assignableListName: string;
    /**
     * @param assignableListLabel  Label For Assignable Entity.
     */
    @Input()
    assignableListLabel: string;
    /**
     * @param groupEntityLabel  Label For Group Entity.
     */
    @Input()
    groupEntityLabel: string;
    @Input()
    columns: any[] = [];
    @Input()
    assignedColumns: any[] = [];
    @Input()
    getAssignedMethodName: string;
    @Input()
    getNotAssignedMethodName: string;
    assignedItemDataSource: any = {};
    notAssignedItemDataSource: any = {};
    httpClient: HttpClient

    constructor(@Inject(HttpClient) httpClient: HttpClient, private genericDataService: GenericDataService) {
        this.httpClient = httpClient;
    }

    ngOnInit() {
        const defaultColumn = {
            caption: 'عنوان',
            dataField: 'title'
        };
        if (this.columns.length === 0) {
            this.columns.push(defaultColumn);
        }
        if (this.assignedColumns.length === 0) {
            this.columns.push(defaultColumn);
        }
        this.gridHeight = window.innerHeight - 180;
        this.itemDataSource = this.genericDataService.createCustomDatasourceForSelect('id', this.groupEntityName);
        if (this.selectedGroupItemId){
            this.bindLists();
        }
    }

    /**
     * Generate Select List Url And Get Custom Dasaources For Selected And Not Selected Items
     */
    bindLists() {
        const getAssignedMethod = `${this.assignableListName}/Get${this.assignableListName}sAssignedTo${this.groupEntityName}Async?id=${this.selectedGroupItemId}`;
        const getNotAssignedMethod = `${this.assignableListName}/Get${this.assignableListName}sNotAssignedTo${this.groupEntityName}Async?id=${this.selectedGroupItemId}`;
        this.assignedItemDataSource = new CustomDevDataSource(this.httpClient).getCustomDataSource(this.assignableListName, [], getAssignedMethod);
        // getCustomDataSourceWithCustomListUrl(getAssignedMethod);
        this.notAssignedItemDataSource = new CustomDevDataSource(this.httpClient).getCustomDataSourceWithCustomListUrl(getNotAssignedMethod);
    }

    /**
     * Raise When Selected Group Changed
     * @param data
     */
    selectedGroupItemChanged(data) {
        this.selectedGroupItemId = data.value;
        this.selectedGroupItemTitle = data.text;
        this.bindLists();
    }

    /**
     * Assign Items To Selected Group
     */
    assignItemsToGroup() {
        const selectedRowKeys = this.notSelectedItemsDataGrid.instance.getSelectedRowKeys();
        this.assignItems(selectedRowKeys, true);
    }

    /**
     * Not Assign Items To Selected Group
     */
    removeAssignItemsFromGroup() {
        const selectedRowKeys = this.selectedItemsDataGrid.instance.getSelectedRowKeys();
        this.assignItems(selectedRowKeys, false);
    }

    /**
     * Assign Or Not Assign Items To Selected Group
     * @param selectedRowKeys Selected Items For Assign Or Not Assign
     * @param assign True For Assign And False For Not Assign
     */
    assignItems(selectedRowKeys: any, assign) {
        if (selectedRowKeys && selectedRowKeys.length > 0) {
            this.confirmBeforeAction(assign ? 'تخصیص آیتم های انتخاب شده' : 'لغو تخصیص آیتم های انتخاب شده', 'تایید').show().then((dialogResult) => {
                if (dialogResult.res === 'ok') {
                    this.genericDataService.postEntityByUrl(`api/${this.assignableListName}/AssignSelectedItemsTo${this.groupEntityName}`, {
                        selectedItems: selectedRowKeys,
                        groupId: this.selectedGroupItemId,
                        assign: assign
                    }).subscribe(() => {
                        this.bindLists();
                    });
                }
            });
        } else {
            notify({
                message: ` هیچ ${this.assignableListLabel}ی انتخاب نشده است! `,
                position: {
                    my: 'center top',
                    at: 'center top'
                }
            }, 'warning', 3000);
        }
    }

    confirmBeforeAction(title: string, confirmText: string) {
        return custom({
            title: title,
            messageHtml: `آیا مطمئن به ${title} می باشید؟ `,
            buttons: [{
                text: confirmText,
                onClick: (e) => {
                    return {res: 'ok'}
                }
            }, {
                text: 'انصراف',
                onClick: (e) => {
                    return {res: 'cancel'}
                }
            }]
        });
    }
}
