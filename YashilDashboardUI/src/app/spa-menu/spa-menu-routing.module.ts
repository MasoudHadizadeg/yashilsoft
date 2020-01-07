import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {SpaIndexComponent} from './pages/spa-index/spa-index.component';
import {AuthGuard} from 'yashil-core';


const routes: Routes = [
  {path: '', component: SpaIndexComponent, canActivate: [AuthGuard]},

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SpaMenuRoutingModule {
}
