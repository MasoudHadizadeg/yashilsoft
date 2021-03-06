import {
    AfterViewInit,
    ComponentFactoryResolver,
    ContentChild,
    EventEmitter,
    Inject,
    Input,
    OnInit,
    Output,
    TemplateRef,
    Type,
    ViewChild
} from '@angular/core';
import {GenericDataService} from '../services/generic-data.service';
import {custom} from 'devextreme/ui/dialog';
import {DetailComponentDirective} from '../base-list-form/detail-component.directive';
import {DxPopupComponent} from 'devextreme-angular/ui/popup';
import {DxDataGridComponent} from 'devextreme-angular/ui/data-grid';
import {BaseEditFormComponent} from '../base-edit-form/base-edit-form.component';
import {BaseEdit} from './base-edit';
import {FormEditType} from './edit-type';
import {DialogService} from '../../../_services/dialog.service';
import {Router} from '@angular/router';
import {CustomDevDataSource} from './custom-dev-data-source';
import {HttpClient} from '@angular/common/http';
import {CachedDataService} from '../../services/cached-data.service';

export class BaseList extends CustomDevDataSource implements OnInit, AfterViewInit {
    /*
    * this use for custom Mode when u need bind data to custom component without dataSource
    * */
    @Input()
    customButtons: any[];
    @Input()
    allowAdd = true;
    selectedItemId: number;
    allowEditSelectedRow: boolean;
    allowDeleteSelectedRow: boolean;

    @Input()
    showFilterButton = true;
    @Input()
    showListHeader = true;
    @Input()
    title: string;
    @Input()
    allowInsertInForm = true;
    @Input()
    showAddButton = true;
    @Input()
    allowEditInForm = true;
    @Input()
    allowPaging = true;
    @Input()
    lazyLoading = true;
    @Input()
    allowColumnResizing: boolean;
    @Input()
    wordWrapEnabled: boolean;
    @Input()
    loadAfterSetFilter = false;
    @Input()
    allowGrouping = false;
    _rootValue: any;
    @Input()
    virtualPaging = false;
    @Input()
    columnHidingEnabled: boolean;

    @Input()
    set rootValue(val) {
        this._rootValue = val;
    }

    get rootValue() {
        return this._rootValue;
    }

    @Output()
    customButtonClicked: EventEmitter<any> = new EventEmitter<any>();
    @Input()
    offsetHeight: number;
    parentIdExpr: 'parentId';
    @Input()
    isForSelectReadOnly = false;
    @ViewChild(DetailComponentDirective, {static: false}) detailComponentContainer: DetailComponentDirective;
    @Input()
    detailComponent: Type<any>;
    loadData: boolean;
    @Input()
    additionalData = {};
    @Output()
    afterInitialDetailComponent: EventEmitter<any> = new EventEmitter<any>();
    @Output()
    beforeAddClicked: EventEmitter<boolean> = new EventEmitter<boolean>();
    @Output()
    public selectedRowChanged: EventEmitter<any> = new EventEmitter<any>();
    @Output()
    recordInitialized: EventEmitter<any> = new EventEmitter<any>();
    @Input()
    allowFilter = false;
    private deleteConfirm: any;
    @Input()
    allowLoadData = true;
    @Input()
    dataStructureIsPlain = false;
    entities: any = {};
    _gridDataSource: any = {};
    set gridDataSource(val) {
        if (val !== this._gridDataSource) {
            this._gridDataSource = val;
        }
    }

    get gridDataSource() {
        return this._gridDataSource;
    }

    _genericDataService: GenericDataService;
    dataEntityName: string;
    remoteOperations: any = {};

    @Input()
    public set entityName(value: string) {
        this.dataEntityName = value;
    }

    public get entityName(): string {
        return this.dataEntityName;
    }

    @Input()
    customListUrl: string;
    customFilters: any[] = [];
    @Input()
    isForTree: boolean;
// The Root Value In Tree Mode
    closeActionEmitter = new EventEmitter<boolean>();
    @ViewChild(DxPopupComponent, {static: true}) popupComponent: DxPopupComponent;
    @ViewChild(DxDataGridComponent, {static: false}) listGrid: DxDataGridComponent;
    @ViewChild(BaseEditFormComponent, {static: false}) baseEdit: BaseEditFormComponent;
    @ContentChild(TemplateRef, {static: false})
    template: TemplateRef<BaseEdit>;
    // tslint:disable-next-line:variable-name
    private _showEditForm: boolean;
    @Input()
    gridHeight: number;
    @Input()
    editType: FormEditType = FormEditType.CustomModal;

    // @Input()
    // public set filters(val: any[]) {
    //     if (val) {
    //         this.customFilters = val;
    //         this.bindDataSource();
    //     }
    // }

    public get filters(): any[] {
        return this.customFilters;
    }

    @Input()
    public set showEditForm(val: boolean) {
        this._showEditForm = val;
        // this.listGrid.instance.refresh();
    }

    public get showEditForm(): boolean {
        return this._showEditForm;
    }

    @Input()
    columns: any[] = [];
    isNew = false;
    selectedRowId: number;
    _componentFactoryResolver: ComponentFactoryResolver

    public get isCustomEditForm() {
        return this.editType === FormEditType.CustomModal;
    }

    constructor(private componentFactoryResolver: ComponentFactoryResolver,
                private dialogService: DialogService, genericDataService: GenericDataService,
                private cachedDataService: CachedDataService, @Inject(HttpClient) httpClient: HttpClient,
                public router: Router) {
        super(httpClient);
        this._genericDataService = genericDataService;
        this.bindDataSource = this.bindDataSource.bind(this);
        this.allowEditRecord = this.allowEditRecord.bind(this);
        this.allowDeleteRecord = this.allowDeleteRecord.bind(this);
        this.selectedCustomButtonChanged = this.selectedCustomButtonChanged.bind(this);
        this._componentFactoryResolver = componentFactoryResolver;
    }

    ngAfterViewInit(): void {
        this.setRemoteOperations();
        if (this.lazyLoading) {
            this.remoteOperations = {paging: true, sorting: true, filtering: false};
        }
        this.closeActionEmitter.subscribe(res => {
            this.showEditForm = false;
        });
    }

    ngOnInit(): void {
        this.declareDeleteConfirm();
        this.setListTitle();
        if (this.isCustomEditForm && !this.isForSelectReadOnly) {
            const editColumn = { // Pushes the "Contacts" band column into the "columns" array
                caption: '',
                width: '80px',
                cellTemplate: 'cellTemplate',
                allowEditing: false,
                formItem: {
                    visible: false
                }
            };
            if (this.isForTree) {
                this.columns.push(editColumn);
            } else {
                this.columns.unshift(editColumn);
            }
        }
        let heightD = 150;
        if (this.offsetHeight) {
            heightD = this.offsetHeight;
        }
        if (this.allowGrouping && this.allowGrouping === true && heightD < 170) {
            heightD = 170;
        }
        if (!this.gridHeight) {
            this.gridHeight = window.innerHeight - heightD;
        }
        /*
      * If Is For Tree bind To Data Source After Root Value Set
      * */
        if (!this.loadAfterSetFilter) {
            this.bindDataSource();
        }
    }

    selectedCustomButtonChanged(e: any) {
        this.customButtonClicked.emit(e);
    }

    toggleFilter() {
        this.allowFilter = !this.allowFilter;
        //  this.remoteOperations = {paging: true, sorting: true, filtering: this.allowFilter, groupPaging: true};
        this.setRemoteOperations();
    }

    setRemoteOperations() {
        if (this.lazyLoading) {
            this.remoteOperations.paging = true;
        } else {
            this.remoteOperations.paging = false;
        }
        this.remoteOperations.sorting = true;
        this.remoteOperations.filtering = this.allowFilter;
        if (this.allowGrouping) {
            this.remoteOperations.groupPaging = true;
        } else {
            this.remoteOperations.groupPaging = false;
        }
    }

    loadPlainData() {
        if (this.customListUrl) {
            this._genericDataService.getCustomEntitiesByUrl(`/api/${this.customListUrl}`).subscribe((res: any) => {
                this.gridDataSource = res;
            });
        } else {
            this._genericDataService.getEntities(this.entityName).subscribe((res: any) => {
                this.gridDataSource = res;
            });
        }
    }

    public refreshList() {
        this.bindDataSource();
    }

    public afterSave(): void {
        this.bindDataSource();
    }

    public applyDynamicFilters(dataTableFilters) {
        return dataTableFilters;
    }

    public bindDataSource() {
        if (!this.allowLoadData) {
            return;
        }
        const pageFilters = this.customFilters;
        if (this.dataStructureIsPlain) {
            this.loadPlainData();
        } else {
            this.gridDataSource = this.getCustomDataSource(this.entityName, pageFilters, this.customListUrl);
        }
    }

    private declareDeleteConfirm() {
        return custom({
            title: 'حذف',
            messageHtml: 'آیا از حذف آیتم انتخاب شده مطمئن هستید؟',
            buttons: [{
                text: 'تایید',
                onClick: (e) => {
                    return {res: 'ok'}
                }
            },
                {
                    text: 'انصراف',
                    onClick: (e) => {
                        return {res: 'cancel'}
                    }
                }
            ]
        });
    }

    delete(id) {
        this.declareDeleteConfirm().show().then((dialogResult) => {
            if (dialogResult.res === 'ok') {
                this._genericDataService.deleteEntity(this.entityName, id).subscribe((res: any) => {
                    this.bindDataSource();
                });
            }
        });
        // prompt('آیا مایل به حذف رکورد انتخاب شده می یاشید؟');
    }

    public hidePopop() {
        this.showEditForm = false;
        this.dialogService.dialogOpend.emit(false);
    }

    onSelectionChanged(e) {
        if (e && e.selectedRowsData && e.selectedRowsData.length > 0) {
            this.setSelectedRow(e.selectedRowsData[0][this.rowKey], e.selectedRowsData[0]);
            this.selectedRowChanged.emit(e.selectedRowsData[0]);
        }
    }

    dialogClosed() {
        this.dialogService.dialogOpend.emit(true);
        this.afterSave();
    }

    addEntity() {
        // t his.loadData = !this.loadData;
        if (!this.isCustomEditForm) {
            this.listGrid.instance.addRow();
            return;
        }
        this.beforeAddClicked.emit(true);
        this.isNew = true;
        this.selectedItemId = null;
        this.showEditForm = true;
        this.dialogService.dialogOpend.emit(false);
        this.setDialogContent(true, null, null);
    }

    setDialogContent(isNew: boolean, selectedEntityId, selectedItem: any) {
        const componentFactory = this.componentFactoryResolver.resolveComponentFactory(this.detailComponent);
        const viewContainerRef = this.detailComponentContainer.viewContainerRef;
        viewContainerRef.clear();
        const componentRef = viewContainerRef.createComponent(componentFactory);
        const editComponent = (<BaseEdit>componentRef.instance);
        editComponent.selectedEntityId = selectedEntityId;
        editComponent.isNew = isNew;
        editComponent.closeFormClick = this.closeActionEmitter;
        editComponent.additionalData = this.additionalData;
        editComponent.showCloseButton = true;
        this.afterSetDialogContent(componentRef.instance, selectedItem);
    }

    editEntity(id) {
        this.loadData = !this.loadData;
        if (!this.isCustomEditForm) {
            const selectedRowIndex = this.listGrid.instance.getRowIndexByKey(this.listGrid.instance.getSelectedRowKeys()[0]);
            this.listGrid.instance.editRow(selectedRowIndex);
            return;
        }
        let selectedItem = null;
        if (this.listGrid) {
            if (this.listGrid.instance.getSelectedRowsData().length === 0) {
                const keys = [id];
                this.listGrid.instance.selectRows(keys, true);
            }
            const selectedRow = this.listGrid.instance.getSelectedRowsData();
            if (selectedRow) {
                selectedItem = selectedRow[0];
            }
        }
        this.selectedRowId = id;
        this.isNew = false;
        this.selectedItemId = this.selectedRowId;
        this.showEditForm = true;
        this.dialogService.dialogOpend.emit(false);
        this.setDialogContent(false, this.selectedItemId, selectedItem);
    }

    protected setSelectedRow(selectedRowId, selectedRow) {
        this.selectedItemId = selectedRowId;
        this.allowEditSelectedRow = this.allowEditRecord(selectedRow);
        this.allowDeleteSelectedRow = this.allowDeleteRecord(selectedRow);
    }

    afterLoadData(result) {
        // if (result && result['data'].length > 0) {
        //     const firstRowId = result['data'][0][this.rowKey];
        //     this.selectedRowKeys = [firstRowId];
        //     this.setSelectedRow(firstRowId, result['data'][0]);
        // }
    }

    allowEditRecord(data: any) {
        if (data.hasOwnProperty('allowEdit')) {
            if (data.allowEdit === true) {
                return true
            }
            return false;
        }
        return true;
    }

    allowDeleteRecord(data: any) {
        if (!this.allowDeleteInForm) {
            return false;
        }
        if (data.hasOwnProperty('allowDelete')) {
            if (data.allowDelete === true) {
                return true
            }
            return false;
        }
        return true;
    }

    private afterSetDialogContent(instance: any, selectedItem: any) {
        this.afterInitialDetailComponent.emit({instance: instance, selectedItem: selectedItem});
    }

    private setListTitle() {
        if (!this.title) {
            const moduleKy = this.router.url.split('/')[1];
            const menuItems = this.cachedDataService.getData('menuItems');
            const rootMenu = menuItems.filter(x => x.title === moduleKy);
            if (rootMenu && rootMenu.length === 1) {
                const menu = rootMenu[0].submenu.filter(x => x.path === this.router.url);
                if (menu.length === 1) {
                    this.title = menu[0].title;
                }
            }
        }
    }
}
