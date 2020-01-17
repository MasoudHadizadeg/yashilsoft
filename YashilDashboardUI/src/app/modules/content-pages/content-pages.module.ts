import {ContentPagesRoutingModule} from './content-pages-routing.module';
import {NgModule} from '@angular/core';
import {LoginPageComponent} from './login/login-page.component';
import {FormsModule} from '@angular/forms';
import {SharedModule} from '../../shared/shared.module';

@NgModule({
  imports: [
    ContentPagesRoutingModule,
    FormsModule,
    SharedModule.forRoot()
  ],
  declarations: [
    LoginPageComponent
  ]
})
export class ContentPagesModule {
}
