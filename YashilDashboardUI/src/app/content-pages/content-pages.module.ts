import {ContentPagesRoutingModule} from './content-pages-routing.module';
import {NgModule} from '@angular/core';
import {LoginPageComponent} from './login/login-page.component';
import {SharedModule} from '../shared/shared.module';
import {FormsModule} from '@angular/forms';

@NgModule({
  imports: [
    ContentPagesRoutingModule,
    SharedModule,
    FormsModule
  ],
  declarations: [
    LoginPageComponent
  ]
})
export class ContentPagesModule {
}
