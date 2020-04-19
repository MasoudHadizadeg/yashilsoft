import {Selectable} from '../../../shared/base/classes/selectable';
import {BaseList} from '../../../shared/base/classes/base-list';
import {Component, Input, OnInit, ViewChild} from '@angular/core';
import {MainNewsDetailComponent} from './main-news-detail.component';


@Component({
    selector: 'app-main-news-list',
    templateUrl: './main-news-list.component.html'
})
export class MainNewsListComponent extends Selectable implements OnInit {
    @ViewChild('listForm', {static: true}) listForm: BaseList;
    loadAfterSetFilter: boolean;
    selectedItemId: number;
    columns: any[] = [];
    entityName = 'mainNews';
    detailComponent = MainNewsDetailComponent;
    _newsStoreId: number;
    @Input()
    set newsStoreId(val) {
        if (val !== this._newsStoreId) {
            this._newsStoreId = val;
            this.bindCustomDataSources();
        }
    }

    private baseListUrlByNewsStoreId = 'mainNews/GetByNewsStoreIdForList?newsStoreId=';
    _newsPropertyId: number;
    @Input()
    set newsPropertyId(val) {
        if (val !== this._newsPropertyId) {
            this._newsPropertyId = val;
            this.bindCustomDataSources();
        }
    }

    private baseListUrlByNewsPropertyId = 'mainNews/GetByNewsPropertyIdForList?newsPropertyId=';

    constructor() {
        super();
        this.columns.push({
            caption: 'خبر',
            dataField: 'newsStoreTitle'
        });
        this.columns.push({
            caption: 'ویژگی خبر',
            dataField: 'newsPropertyTitle'
        });
        this.columns.push({
            caption: 'خبر عادی',
            dataField: 'simplenews'
        });
        this.columns.push({
            caption: 'نمایش در اسلایدر صفحه اصلی',
            dataField: 'showInMainPageSlider'
        });
        this.columns.push({
            caption: 'خبر داغ',
            dataField: 'isHotNews'
        });
        this.columns.push({
            caption: 'خبر منتخب',
            dataField: 'selectedNews'
        });
        this.columns.push({
            caption: 'خبر اصلی سرویس خبری',
            dataField: 'serviceMainNews'
        });
        this.columns.push({
            caption: 'نمایش در قسمت چند رسانه ای',
            dataField: 'showAsMultimedia'
        });
        this.columns.push({
            caption: 'خبر مهم',
            dataField: 'showAsImportantNews'
        });
        this.columns.push({
            caption: 'انتخاب سردبیر',
            dataField: 'editorSelected'
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
        if (this.newsStoreId) {
            this.listForm.customListUrl = `${this.baseListUrlByNewsStoreId}${this.newsStoreId}`;
        } else if (this.newsPropertyId) {
            this.listForm.customListUrl = `${this.baseListUrlByNewsPropertyId}${this.newsPropertyId}`;
        }
        let res = false;
        if (this.newsStoreId || this.newsPropertyId) {
            res = true;
            this.listForm.refreshList();
        }
        return res;
    }

    afterInitialDetailComponent(componentInstance: any) {
        const comp = (<MainNewsDetailComponent>componentInstance);

        if (this.newsStoreId) {
            comp.newsStoreId = this.newsStoreId;
        }

        if (this.newsPropertyId) {
            comp.newsPropertyId = this.newsPropertyId;
        }

    }
}
