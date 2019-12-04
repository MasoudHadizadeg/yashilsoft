import {FullLayoutComponent} from '../../layouts/full/full-layout.component';
import {RouterModule, Routes} from '@angular/router';
import {HomeComponent} from './home/home.component';
import {NgModule} from '@angular/core';
import {AuthGuard} from '../../shared/_guards';

const routes: Routes = [
  {
    path: '',
    component: FullLayoutComponent,
    children: [
      {path: '', component: HomeComponent, canActivate: [AuthGuard]},
      {path: 'um', loadChildren: '../user-management/user-management.module#UserManagementModule'}
    ]
  }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
  }
)
export class FullPagesRoutingModule {

}
