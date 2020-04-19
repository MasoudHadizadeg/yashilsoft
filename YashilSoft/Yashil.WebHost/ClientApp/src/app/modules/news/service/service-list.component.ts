import {Selectable} from '../../../shared/base/classes/selectable';
import {BaseList} from '../../../shared/base/classes/base-list';
import {Component, Input, OnInit, ViewChild} from '@angular/core';
import {ServiceDetailComponent} from './service-detail.component';


@Component({
    selector: 'app-service-list',
    templateUrl: './service-list.component.html'
})
export class ServiceListComponent extends Selectable implements OnInit {
    @ViewChild('listForm', {static: true}) listForm: BaseList;
    loadAfterSetFilter: boolean;
    selectedItemId: number;
    columns: any[] = [];
    entityName = 'service';
    detailComponent = ServiceDetailComponent;
    _parentId: number;
    @Input()
    set parentId(val) {
        if (val !== this._parentId) {
            this._parentId = val;
        }
    }

    get parentId(): number {
        return this._parentId;
    }

    _appEntityId: number;
    @Input()
    set appEntityId(val) {
        if (val !== this._appEntityId) {
            this._appEntityId = val;
        }
    }

    get appEntityId(): number {
        return this._appEntityId;
    }

    _accessLevelId: number;
    @Input()
    set accessLevelId(val) {
        if (val !== this._accessLevelId) {
            this._accessLevelId = val;
        }
    }

    get accessLevelId(): number {
        return this._accessLevelId;
    }

    private baseListUrl = 'service/GetByCustomFilterForList';

    constructor() {
        super();
        this.columns.push({
            caption: 'عنوان',
            dataField: 'title',
            width: '40%'
        });
        this.columns.push({
            caption: 'عنوان انگلیسی',
            dataField: 'englishTitle'
        });
        this.columns.push({
            caption: 'سرویس های اصلی',
            dataField: 'isMain'
        });
        this.columns.push({
            caption: 'نمایش سرویس در صفحه اصلی',
            dataField: 'showInMainPage'
        });
        this.columns.push({
            caption: 'ترتیب نمایش',
            dataField: 'displayOrder'
        });
    }

    ngOnInit(): void {
        if (this.bindCustomDataSources()) {
            this.loadAfterSetFilter = true;
        }
    }

    private bindCustomDataSources() {
        let customListUrl = `${this.baseListUrl}`;
        if (this.listForm) {
            if (this.parentId) {
                customListUrl += `parentId=${this.parentId}&`;
            }
            if (this.appEntityId) {
                customListUrl += `appEntityId=${this.appEntityId}&`;
            }
            if (this.accessLevelId) {
                customListUrl += `accessLevelId=${this.accessLevelId}&`;
            }
        }
        let res = false;
        if (this.parentId || this.appEntityId || this.accessLevelId) {
            this.listForm.customListUrl = customListUrl;
            this.listForm.refreshList();
            res = true;
        }
        return res;
    }

    afterInitialDetailComponent(componentInstance: any) {
        const comp = (<ServiceDetailComponent>componentInstance.instance);
        if (this.selectedItemId) {
            this.parentId = this.selectedItemId;
        }
        if (this.parentId) {
            comp.parentId = this.parentId;
        }
        if (this.appEntityId) {
            comp.appEntityId = this.appEntityId;
        }
    }

    selectedServiceChanged(item: any) {
        this.selectedItemId = item.id;
        this.selectedRowChanged.emit(item);
    }
}
