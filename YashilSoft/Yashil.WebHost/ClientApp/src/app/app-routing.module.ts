import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {Full_ROUTES} from './shared/routes/full-layout.routes';
import {CONTENT_ROUTES} from './shared/routes/content-layout.routes';
import {AuthGuard} from './shared/_guards';
import {FullLayoutComponent} from './layouts/full/full-layout.component';
import {HomeComponent} from './pages/full-layout-page/home/home.component';

const appRoutes: Routes = [
    {path: 'pages', data: {title: 'content Views'}, children: CONTENT_ROUTES},
    {path: '', data: {title: 'full Views split'}, children: Full_ROUTES, canActivate: [AuthGuard]},
];

@NgModule({
    imports: [RouterModule.forRoot(appRoutes)],
    exports: [RouterModule]
})

export class AppRoutingModule {

}
