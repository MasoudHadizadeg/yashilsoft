import {Selectable} from '../../../shared/base/classes/selectable';
import {BaseList} from '../../../shared/base/classes/base-list';
import {Component, Input, OnInit, ViewChild} from '@angular/core';
import {NewsStoreDetailTabBasedComponent} from './news-store-detail-tab-based.component';
import {ActivatedRoute} from '@angular/router';
import {NewsType} from '../news-enums';


@Component({
    selector: 'app-news-store-list',
    templateUrl: './news-store-list.component.html'
})
export class NewsStoreListComponent extends Selectable implements OnInit {
    @ViewChild('listForm', {static: true}) listForm: BaseList;
    @Input()
    loadAfterSetFilter: boolean;
    selectedItemId: number;
    columns: any[] = [];
    entityName = 'newsStore';
    detailComponent = NewsStoreDetailTabBasedComponent;
    _serviceId: number;
    @Input()
    set serviceId(val) {
        if (val !== this._serviceId) {
            this._serviceId = val;
        }
    }

    get serviceId(): number {
        return this._serviceId;
    }

    private baseListUrl = 'newsStore/GetByCustomFilter?';
    private baseListUrlByServiceId = 'newsStore/GetByServiceIdForList?serviceId=';
    _newsType: number;
    @Input()
    set newsType(val) {
        if (val !== this._newsType) {
            this._newsType = val;
        }
    }

    get newsType(): number {
        return this._newsType;
    }

    private baseListUrlByNewsType = 'newsStore/GetByNewsTypeForList?newsType=';
    _language: number;
    @Input()
    set language(val) {
        if (val !== this._language) {
            this._language = val;
        }
    }

    get language(): number {
        return this._language;
    }

    private baseListUrlByLanguage = 'newsStore/GetByLanguageForList?language=';
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

    private baseListUrlByAccessLevelId = 'newsStore/GetByAccessLevelIdForList?accessLevelId=';

    customButtons: any;

    constructor(private activatedRoute: ActivatedRoute) {
        super();
        this.customButtonClicked = this.customButtonClicked.bind(this);
        this.columns.push({
            caption: 'نوع خبر',
            dataField: 'newsTypeTitle'
        });
        this.columns.push({
            caption: 'سرویس خبر',
            dataField: 'serviceTitle',
        });
        this.columns.push({
            caption: 'تیتر',
            dataField: 'title',
            width: '50%'
        });
        this.columns.push({
            caption: 'تاریخ درج',
            dataField: 'dateInsert',
            cellTemplate: 'intDate'
        });
        this.columns.push({
            caption: 'تایید شده',
            dataField: 'confirmed'
        });

    }

    ngOnInit(): void {
        this.activatedRoute.data.subscribe((data: { newsType: any }) => {
            this.newsType = data.newsType;
        });
        // if (this.bindCustomDataSources()) {
        //     this.loadAfterSetFilter = true;
        // }
        this.bindCustomButtons();
    }

    bindCustomButtons() {
        if (this.newsType === 1074) {
            this.customButtons = [{
                icon: 'file',
                text: 'تعریف اطلاعیه',
                type: 'default',
                key: NewsType.Notification,
            }];
        } else if (this.newsType === NewsType.Gallery) {
            this.customButtons = [{
                icon: 'image',
                text: 'تعریف گالری تصاویر',
                type: 'default',
                key: NewsType.Gallery,
            }];
        } else {
            this.customButtons = [{
                icon: 'comment',
                text: 'تعریف خبر عادی',
                type: 'default',
                key: NewsType.Simple,
            }, {
                icon: 'image',
                text: 'تعریف خبر تصویری',
                type: 'success',
                key: NewsType.Pictorial
            }, {
                icon: 'video',
                text: 'تعریف خبر فیلم',
                type: 'danger',
                key: NewsType.Movie
            }];
        }
    }

    public bindCustomDataSources() {
        if (this.listForm) {
            let customListUrl = `${this.baseListUrl}`;
            if (this.serviceId) {
                customListUrl += `serviceId=${this.serviceId}&`;
            }
            if (this.newsType) {
                customListUrl += `newsType=${this.newsType}&`;
            }
            if (this.language) {
                this.listForm.customListUrl += `language=${this.language}&`;
            }
            this.listForm.customListUrl = customListUrl;
            this.listForm.refreshList();
        }
        let res = false;
        if (this.serviceId || this.newsType || this.language || this.accessLevelId) {
            res = true;
        }
        return res;
    }

    afterInitialDetailComponent(componentInstance: any) {
        const comp = (<NewsStoreDetailTabBasedComponent>componentInstance);

        if (this.serviceId) {
            comp.serviceId = this.serviceId;
        }

        if (this.newsType) {
            comp.newsType = this.newsType;
        }

        if (this.language) {
            comp.language = this.language;
        }

        if (this.accessLevelId) {
            comp.accessLevelId = this.accessLevelId;
        }

    }

    customButtonClicked(e: any) {
        this.newsType = e;
        this.listForm.addEntity();
    }
}
