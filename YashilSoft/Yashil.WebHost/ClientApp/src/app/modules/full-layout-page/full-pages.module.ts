import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FullPagesRoutingModule} from './full-pages-routing.module';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {DpDatePickerModule} from 'ng2-jalali-date-picker';
import {COMPONENTS} from './index';
import {SharedModule} from '../../shared/shared.module';
import {AngularSplitModule} from 'angular-split';
import {ImageCropperModule} from 'ngx-image-cropper';
import {ENTRYCOMPONENTS} from './entryIndex';

@NgModule({
    declarations: [COMPONENTS],
    entryComponents: [ENTRYCOMPONENTS],
    imports: [
        CommonModule,
        FullPagesRoutingModule,
        ReactiveFormsModule,
        DpDatePickerModule,
        SharedModule,
        AngularSplitModule.forRoot(),
        ImageCropperModule
    ],
    providers: [],
    exports: [COMPONENTS],
})
export class FullPagesModule {
}
