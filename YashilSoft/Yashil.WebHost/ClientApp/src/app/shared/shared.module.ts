import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {RouterModule} from '@angular/router';
import {TranslateModule} from '@ngx-translate/core';
// COMPONENTS
import {FooterComponent} from './footer/footer.component';
import {NavbarComponent} from './navbar/navbar.component';
import {SidebarComponent} from './sidebar/sidebar.component';
// DIRECTIVES
import {ToggleFullscreenDirective} from './directives/toggle-fullscreen.directive';
import {SidebarDirective} from './directives/sidebar.directive';
import {SidebarLinkDirective} from './directives/sidebarlink.directive';
import {SidebarListDirective} from './directives/sidebarlist.directive';
import {SidebarAnchorToggleDirective} from './directives/sidebaranchortoggle.directive';
import {SidebarToggleDirective} from './directives/sidebartoggle.directive';
import {BaseListFormComponent} from './base/base-list-form/base-list-form.component';
import {BaseEditFormComponent} from './base/base-edit-form/base-edit-form.component';
import {DpDatePickerModule} from 'ng2-jalali-date-picker';
import {FormsModule} from '@angular/forms';
import {DxDataGridModule} from 'devextreme-angular/ui/data-grid'
import {DxButtonModule} from 'devextreme-angular/ui/button'
import {DxCheckBoxModule} from 'devextreme-angular/ui/check-box'
import {DxFileUploaderModule} from 'devextreme-angular/ui/file-uploader'
import {DxFormModule} from 'devextreme-angular/ui/form'
import {DxLookupModule} from 'devextreme-angular/ui/lookup'
import {DxColorBoxModule} from 'devextreme-angular/ui/color-box'
import {DxNumberBoxModule} from 'devextreme-angular/ui/number-box'
import {DxPopupModule} from 'devextreme-angular/ui/popup'
import {DxResponsiveBoxModule} from 'devextreme-angular/ui/responsive-box'
import {DxScrollViewModule} from 'devextreme-angular/ui/scroll-view'
import {DxSelectBoxModule} from 'devextreme-angular/ui/select-box'
import {DxTagBoxModule} from 'devextreme-angular/ui/tag-box';
import {DxTreeListModule} from 'devextreme-angular/ui/tree-list';
import {DxTextAreaModule} from 'devextreme-angular/ui/text-area';
import {DxTabPanelModule} from 'devextreme-angular/ui/tab-panel';
import {DxTileViewModule} from 'devextreme-angular/ui/tile-view';
import {DxListModule} from 'devextreme-angular/ui/list'
import {DxValidatorModule} from 'devextreme-angular/ui/validator'
import {DxValidationSummaryModule} from 'devextreme-angular/ui/validation-summary';

import {MessagesComponent} from './base/messages/messages.component';
import {SecuredImageComponent} from './base/core/components/secured-image/secured-image.component';
import {Base64imageDirective} from './directives/base64image.directive';
import {DetailComponentDirective} from './base/base-list-form/detail-component.directive';
import {IntToDateTimePipe} from './base/core/pipes/int-to-date-time.pipe';
import {IntToStringDatePipe} from './base/core/pipes/Int-to-string-date.pipe';
import {JalaliPipe} from './base/core/pipes/jalali.pipe ';
import {IntToStringTimePipe} from './base/core/pipes/int-to-string-time.pipe';
import {PersianDayPipe} from './base/core/pipes/persian-day.pipe';
import {FullLayoutComponent} from '../layouts/full/full-layout.component';
import {FullLayoutSplitComponent} from '../layouts/fullsplit/full-layout-split.component';
import {AngularSplitModule} from 'angular-split';
import {MessageService} from './base/messages/message.service';
import {HTTP_INTERCEPTORS} from '@angular/common/http';
import {ErrorInterceptor, JwtInterceptor} from './_helpers';
import {DynamicScriptLoaderService} from './services/dynamic-script-loader.service';
import {CoreModule} from '../core/core.module';

@NgModule({
    exports: [
        CoreModule,
        FullLayoutComponent,
        FullLayoutSplitComponent,
        IntToDateTimePipe,
        IntToStringDatePipe,
        IntToStringTimePipe,
        PersianDayPipe,
        JalaliPipe,
        CommonModule,
        FooterComponent,
        NavbarComponent,
        SidebarComponent,
        ToggleFullscreenDirective,
        SidebarDirective,
        TranslateModule,
        BaseListFormComponent,
        BaseEditFormComponent,
        SecuredImageComponent,
        DxLookupModule,
        DxColorBoxModule,
        DxScrollViewModule,
        DxDataGridModule,
        DxCheckBoxModule,
        DxSelectBoxModule,
        DxNumberBoxModule,
        DxFormModule,
        DxButtonModule,
        DxPopupModule,
        DxTagBoxModule,
        DxResponsiveBoxModule,
        DxFileUploaderModule,
        DxTreeListModule,
        DxTextAreaModule,
        DxTabPanelModule,
        DxTileViewModule,
        DxValidatorModule,
        DxValidationSummaryModule,
        Base64imageDirective,
        DetailComponentDirective,
        DxListModule
    ],
    imports: [
        FormsModule,
        RouterModule,
        CommonModule,
        DxTileViewModule,
        TranslateModule,
        DxLookupModule,
        DxScrollViewModule,
        DxDataGridModule,
        DxColorBoxModule,
        DxCheckBoxModule,
        DxSelectBoxModule,
        DxNumberBoxModule,
        DxFormModule,
        DxButtonModule,
        DxPopupModule,
        DxResponsiveBoxModule,
        DpDatePickerModule,
        DxFileUploaderModule,
        DxTreeListModule,
        DxTagBoxModule,
        DxTextAreaModule,
        DxTabPanelModule,
        DxListModule,
        DxValidatorModule,
        DxValidationSummaryModule,
        AngularSplitModule,
        CoreModule
    ],
    declarations: [
        FooterComponent,
        NavbarComponent,
        SidebarComponent,
        ToggleFullscreenDirective,
        SidebarDirective,
        SidebarLinkDirective,
        SidebarListDirective,
        SidebarAnchorToggleDirective,
        SidebarToggleDirective,
        Base64imageDirective,
        BaseListFormComponent,
        BaseEditFormComponent,
        MessagesComponent,
        SecuredImageComponent,
        Base64imageDirective,
        DetailComponentDirective,
        IntToDateTimePipe,
        IntToStringDatePipe,
        JalaliPipe,
        IntToStringTimePipe,
        PersianDayPipe,
        FullLayoutComponent,
        FullLayoutSplitComponent
    ],
    providers: [
        DynamicScriptLoaderService,
        MessageService,
        {
            provide: HTTP_INTERCEPTORS,
            useClass: JwtInterceptor, multi: true
        },
        {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true}
    ],
})
export class SharedModule {
}
