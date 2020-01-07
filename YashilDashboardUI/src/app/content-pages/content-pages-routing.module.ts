import {RouterModule, Routes} from '@angular/router';
import {LoginPageComponent} from './login/login-page.component';
import {NgModule} from '@angular/core';

const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: 'login',
        component: LoginPageComponent,
        data: {
          title: 'Login Page'
        }
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ContentPagesRoutingModule {
}
