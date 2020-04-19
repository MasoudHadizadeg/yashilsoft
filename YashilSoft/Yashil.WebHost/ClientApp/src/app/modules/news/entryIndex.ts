import {MainNewsDetailComponent} from './main-news/main-news-detail.component';

import {ServiceDetailComponent} from './service/service-detail.component';

import {NewsStoreDetailTabBasedComponent} from './news-store/news-store-detail-tab-based.component';

import {NewsStoreDetailComponent} from './news-store/news-store-detail.component';

import {Provider} from '@angular/core';

export const ENTRYCOMPONENTS: Provider[] = [
    MainNewsDetailComponent,
    ServiceDetailComponent,
    NewsStoreDetailTabBasedComponent,
    NewsStoreDetailComponent,
];