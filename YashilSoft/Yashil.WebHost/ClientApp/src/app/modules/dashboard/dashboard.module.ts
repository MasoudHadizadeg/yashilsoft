import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {DpDatePickerModule} from 'ng2-jalali-date-picker';
import {COMPONENTS} from './index';
import {SharedModule} from '../../shared/shared.module';
import {AngularSplitModule} from 'angular-split';
import {ImageCropperModule} from 'ngx-image-cropper';
import {ENTRYCOMPONENTS} from './entryIndex';
import {DashboardRoutingModule} from './dashboard-routing.module';

@NgModule({
    declarations: [COMPONENTS],
    entryComponents: [ENTRYCOMPONENTS],
    imports: [
        DashboardRoutingModule,
        DpDatePickerModule,
        SharedModule,
        AngularSplitModule.forRoot(),
        ImageCropperModule
    ],
    providers: [
    ],
    exports: [COMPONENTS],
})
export class DashboardModule {
}
