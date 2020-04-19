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
    formNewsType: number;
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

    private baseListUrl = 'newsStore/GetByCustomFilterForList?';
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

    customButtons: any;

    constructor(private activatedRoute: ActivatedRoute) {
        super();
        this.customButtonClicked = this.customButtonClicked.bind(this);
    }

    ngOnInit(): void {
        this.activatedRoute.data.subscribe((data: { newsType: any }) => {
            this.newsType = data.newsType;
            this.formNewsType = data.newsType;
            this.bindColumns();
            this.bindCustomButtons();
            this.bindCustomDataSources();
        });
    }

    bindColumns() {
        if (!this.newsType) {
            this.columns.push({
                caption: 'نوع خبر',
                dataField: 'newsTypeTitle'
            });
        }
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
        let customListUrl = `${this.baseListUrl}`;
        if (this.listForm) {
            if (this.serviceId) {
                customListUrl += `serviceId=${this.serviceId}&`;
            }
            if (this.newsType) {
                customListUrl += `newsType=${this.newsType}&`;
            }
            if (this.language) {
                this.listForm.customListUrl += `language=${this.language}&`;
            }
        }
        let res = false;
        if (this.serviceId || this.newsType || this.language) {
            res = true;
        }
        /**
         * For Null NewsType Must Refresh List For Simple News Film News And Pictorial News List
         */
        this.listForm.customListUrl = customListUrl;
        this.listForm.refreshList();
        return res;
    }

    afterInitialDetailComponent(componentInstance: any) {
        const comp = (<NewsStoreDetailTabBasedComponent>componentInstance.instance);

        if (this.serviceId) {
            comp.serviceId = this.serviceId;
        }
        if (componentInstance.selectedItem) {
            comp.newsTypeTitle = componentInstance.selectedItem.newsTypeTitle;
        }
        if (this.formNewsType) {
            comp.newsType = this.formNewsType;
        }
        if (this.language) {
            comp.language = this.language;
        }

    }

    customButtonClicked(e: any) {
        this.formNewsType = e;
        this.listForm.addEntity();
    }
}
