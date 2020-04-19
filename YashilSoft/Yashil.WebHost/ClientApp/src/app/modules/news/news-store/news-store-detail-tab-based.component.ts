import {Component, OnInit} from '@angular/core';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Editable} from '../../../shared/base/classes/editable';
import {IsEqual, NewsType} from '../news-enums';

@Component({
    selector: 'app-news-store-detail-tab-based',
    templateUrl: './news-store-detail-tab-based.component.html'
})
export class NewsStoreDetailTabBasedComponent extends Editable implements OnInit {
    serviceId: number;
    newsType: number;
    language: number;
    accessLevelId: number;

    allowEditDesc: boolean;
    tabs: any[] = [];
    newsTypeTitle: string;

    constructor(private genericDataService: GenericDataService) {
        super();
        this.entityName = 'newsStore';
    }

    ngOnInit() {
        if (this.selectedEntityId && this.selectedEntityId !== 0) {
            this.allowEditDesc = true;
        } else {
            this.allowEditDesc = false;
        }
        if (this.newsType) {
            this.genericDataService.getCommonBaseDataForSelect('NewsType').subscribe((res: any) => {
                const newsType = res.filter(x => x.id === this.newsType);
                if (newsType && newsType.length !== 0) {
                    this.newsTypeTitle = newsType[0].title;
                }
                this.bindTabs();
            });
        } else {
            this.bindTabs();
        }
    }

    rowInserted(insertedRowId: any) {
        this.selectedEntityId = insertedRowId;
        this.allowEditDesc = true;
        this.bindTabs();
    }

    bindTabs() {
        // NewsType[this.newsType] === NewsType[NewsType.Movie]
        this.tabs = [
            {id: 1, title: this.newsTypeTitle, template: 'newsStore'},
            {id: 2, title: `متن ${this.newsTypeTitle} `, template: 'body', disabled: !this.allowEditDesc},
            {id: 3, title: `تصویر اصلی ${this.newsTypeTitle} `, template: 'mainNewsImage', disabled: !this.allowEditDesc},
            {
                id: 4,
                title: 'لیست تصاویر',
                template: 'newsPictures',
                disabled: !this.allowEditDesc,
                visible: IsEqual(this.newsType, NewsType.Gallery) || IsEqual(this.newsType, NewsType.Pictorial)
            },
            {id: 5, title: 'فیلم', template: 'newsFilm', disabled: !this.allowEditDesc, visible: IsEqual(this.newsType, NewsType.Movie)},
        ];
    }
}


