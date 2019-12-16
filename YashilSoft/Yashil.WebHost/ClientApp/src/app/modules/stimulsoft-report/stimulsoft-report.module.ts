import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {COMPONENTS} from './index';
import {SharedModule} from '../../shared/shared.module';
import {ENTRYCOMPONENTS} from './entryIndex';
import {StimulsoftReportRoutingModule} from './stimulsoft-report-routing.module';

@NgModule({
    declarations: [COMPONENTS],
    entryComponents: [ENTRYCOMPONENTS],
    imports: [
        CommonModule,
        StimulsoftReportRoutingModule,
        SharedModule
    ],
    exports: [COMPONENTS],
})
export class StimulsoftReportModule {
}
