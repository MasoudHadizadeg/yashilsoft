import {Selectable} from '../../../shared/base/classes/selectable';
import {BaseList} from '../../../shared/base/classes/base-list';
import {Component, Input, OnInit, ViewChild} from '@angular/core';
import {NewsKeywordDetailComponent} from './news-keyword-detail.component';


@Component({
    selector: 'app-news-keyword-list',
    templateUrl: './news-keyword-list.component.html'
})
export class NewsKeywordListComponent extends Selectable implements OnInit {
    @ViewChild('listForm', {static: true}) listForm: BaseList;
    loadAfterSetFilter: boolean;
    selectedItemId: number;
    columns: any[] = [];
    entityName = 'newsKeyword';
    detailComponent = NewsKeywordDetailComponent;
    _newsStoreId: number;
    @Input()
    set newsStoreId(val) {
        if (val !== this._newsStoreId) {
            this._newsStoreId = val;
        }
    }

    get newsStoreId(): number {
        return this._newsStoreId;
    }

    _keywordId: number;
    @Input()
    set keywordId(val) {
        if (val !== this._keywordId) {
            this._keywordId = val;
        }
    }

    get keywordId(): number {
        return this._keywordId;
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

    private baseListUrl = 'newsKeyword/GetByCustomFilterForList';

    constructor() {
        super();
        this.columns.push({
            caption: 'عنوان',
            dataField: 'title'
        });
        this.columns.push({
            caption: 'خبر',
            dataField: 'newsStoreTitle'
        });
        this.columns.push({
            caption: 'کلمه کلیدی',
            dataField: 'keywordTitle'
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
            if (this.newsStoreId) {
                customListUrl += `newsStoreId=${this.newsStoreId}&`;
            }
            if (this.keywordId) {
                customListUrl += `keywordId=${this.keywordId}&`;
            }
            if (this.accessLevelId) {
                customListUrl += `accessLevelId=${this.accessLevelId}&`;
            }
        }
        let res = false;
        if (this.newsStoreId || this.keywordId || this.accessLevelId) {
            this.listForm.customListUrl = customListUrl;
            this.listForm.refreshList();
            res = true;
        }
        return res;
    }

    afterInitialDetailComponent(componentInstance: any) {
        const comp = (<NewsKeywordDetailComponent>componentInstance.instance);

        if (this.newsStoreId) {
            comp.newsStoreId = this.newsStoreId;
        }

        if (this.keywordId) {
            comp.keywordId = this.keywordId;
        }

        if (this.accessLevelId) {
            comp.accessLevelId = this.accessLevelId;
        }

    }
}
