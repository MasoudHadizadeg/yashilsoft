import {NgModule} from '@angular/core';
import {COMPONENTS} from './index';
import {SharedModule} from '../../shared/shared.module';
import {ENTRYCOMPONENTS} from './entryIndex';
import {StimulsoftReportRoutingModule} from './stimulsoft-report-routing.module';

@NgModule({
  declarations: [COMPONENTS],
  entryComponents: [ENTRYCOMPONENTS],
  imports: [
    StimulsoftReportRoutingModule,
    SharedModule
  ],
  exports: [COMPONENTS],
})
export class StimulsoftReportModule {
}
