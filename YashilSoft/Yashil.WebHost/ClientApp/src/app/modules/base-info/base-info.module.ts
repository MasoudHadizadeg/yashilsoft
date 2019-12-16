import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {DpDatePickerModule} from 'ng2-jalali-date-picker';
import {COMPONENTS} from './index';
import {SharedModule} from '../../shared/shared.module';
import {AngularSplitModule} from 'angular-split';
import {ImageCropperModule} from 'ngx-image-cropper';
import {ENTRYCOMPONENTS} from './entryIndex';
import {BaseInfoRoutingModule} from './base-info-routing.module';

@NgModule({
    declarations: [COMPONENTS],
    entryComponents: [ENTRYCOMPONENTS],
    imports: [
        BaseInfoRoutingModule,
        DpDatePickerModule,
        SharedModule,
        AngularSplitModule.forRoot()
    ],
    providers: [],
    exports: [COMPONENTS],
})
export class BaseInfoModule {
}
