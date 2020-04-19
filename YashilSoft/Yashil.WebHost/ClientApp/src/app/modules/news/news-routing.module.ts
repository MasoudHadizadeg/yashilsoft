import {RouterModule, Routes} from '@angular/router';
import {AuthGuard} from '../../shared/_guards';
import {MainNewsListComponent} from './main-news/main-news-list.component';
import {ServiceListComponent} from './service/service-list.component';
import {NgModule} from '@angular/core';
import {NewsStoreCustomListComponent} from './news-store/news-store-custom-list.component';

const routes: Routes = [
    {path: 'mainNewss', component: MainNewsListComponent, canActivate: [AuthGuard]},
    {path: 'services', component: ServiceListComponent, canActivate: [AuthGuard]},
    {path: 'newsStores', component: NewsStoreCustomListComponent, canActivate: [AuthGuard]},
    {path: 'notification', component: NewsStoreCustomListComponent, data: {newsType: 1074}, canActivate: [AuthGuard]},
    {path: 'gallery', component: NewsStoreCustomListComponent, data: {newsType: 1075}, canActivate: [AuthGuard]},
];

@NgModule({
        imports: [RouterModule.forChild(routes)],
        exports: [RouterModule],
    }
)
export class NewsRoutingModule {

}
