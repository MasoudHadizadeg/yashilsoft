import {MainNewsDetailComponent} from './main-news/main-news-detail.component';
import {MainNewsListComponent} from './main-news/main-news-list.component';

import {ServiceDetailComponent} from './service/service-detail.component';
import {ServiceListComponent} from './service/service-list.component';

import {NewsStoreDetailTabBasedComponent} from './news-store/news-store-detail-tab-based.component';

import {NewsStoreDetailComponent} from './news-store/news-store-detail.component';
import {NewsStoreListComponent} from './news-store/news-store-list.component';

import {Provider} from '@angular/core';
import {NewsStoreCustomListComponent} from './news-store/news-store-custom-list.component';
import {NewsKeywordListComponent} from './news-keyword/news-keyword-list.component';

export const COMPONENTS: Provider[] = [

    MainNewsListComponent,

    MainNewsDetailComponent,
    ServiceListComponent,

    ServiceDetailComponent,

    NewsStoreDetailTabBasedComponent,
    NewsStoreListComponent,
    NewsKeywordListComponent,
    NewsStoreDetailComponent,
    NewsStoreCustomListComponent,
];
