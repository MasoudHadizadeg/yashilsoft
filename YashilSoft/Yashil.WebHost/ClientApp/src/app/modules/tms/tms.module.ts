import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {DpDatePickerModule} from 'ng2-jalali-date-picker';
import {COMPONENTS} from './index';
import {ErrorInterceptor, JwtInterceptor} from '../../shared/_helpers';
import {SharedModule} from '../../shared/shared.module';
import {AngularSplitModule} from 'angular-split';
import {ImageCropperModule} from 'ngx-image-cropper';
import {MessageService} from '../../shared/base/messages/message.service';
import {ENTRYCOMPONENTS} from './entryIndex';
import {TmsRoutingModule} from './tms-routing.module';

@NgModule({
    declarations: [COMPONENTS],
    entryComponents: [ENTRYCOMPONENTS],
    imports: [
        CommonModule,
        TmsRoutingModule,
        ReactiveFormsModule,
        FormsModule,
        HttpClientModule,
        DpDatePickerModule,
        SharedModule,
        AngularSplitModule.forRoot(),
        ImageCropperModule
    ],
    providers: [
        MessageService,
        {
            provide: HTTP_INTERCEPTORS,
            useClass: JwtInterceptor, multi: true
        },
        {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true}
    ],
    exports: [COMPONENTS],
})
export class TmsModule {
}
