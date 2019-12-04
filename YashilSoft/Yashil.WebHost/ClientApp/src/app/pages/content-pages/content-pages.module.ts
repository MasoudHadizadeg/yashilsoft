import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormsModule} from '@angular/forms';
import {ContentPagesRoutingModule} from './content-pages-routing.module';
import {ComingSoonPageComponent} from './coming-soon/coming-soon-page.component';
import {ErrorPageComponent} from './error/error-page.component';
import {ForgotPasswordPageComponent} from './forgot-password/forgot-password-page.component';
import {LockScreenPageComponent} from './lock-screen/lock-screen-page.component';
import {LoginPageComponent} from './login/login-page.component';
import {MaintenancePageComponent} from './maintenance/maintenance-page.component';
import {RegisterPageComponent} from './register/register-page.component';
import {ReportDesignerComponent} from './stimulsoft/report-designer/report-designer.component';
import {ReportViewerComponent} from './stimulsoft/report-viewer/report-viewer.component';
import {CoreModule} from '../../core/core.module';


@NgModule({
  imports: [
    CommonModule,
    ContentPagesRoutingModule,
    FormsModule,
    CoreModule
  ],
  declarations: [
    ComingSoonPageComponent,
    ErrorPageComponent,
    ForgotPasswordPageComponent,
    LockScreenPageComponent,
    LoginPageComponent,
    MaintenancePageComponent,
    RegisterPageComponent,
    ReportDesignerComponent,
    ReportViewerComponent
  ]
})
export class ContentPagesModule {
}
