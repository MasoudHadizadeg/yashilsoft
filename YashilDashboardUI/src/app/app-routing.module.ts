import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {NotFoundComponent} from './shared/components/not-found/not-found.component';
import {CONTENT_ROUTES} from './shared/routes/content-layout.routes';

const routes: Routes = [
  {
    path: '',
    loadChildren: () => import(`./spa-menu/spa-menu.module`).then(m => m.SpaMenuModule)
  },
  {
    path: '404',
    component: NotFoundComponent
  },
  {path: 'pages', data: {title: ''}, children: CONTENT_ROUTES},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
