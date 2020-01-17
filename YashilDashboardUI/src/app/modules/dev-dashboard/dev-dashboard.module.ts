import {NgModule} from '@angular/core';
import {COMPONENTS} from './index';
import {SharedModule} from '../../shared/shared.module';
import {ENTRYCOMPONENTS} from './entryIndex';
import {DevDashboardRoutingModule} from './dev-dashboard-routing.module';

@NgModule({
    declarations: [COMPONENTS],
    entryComponents: [ENTRYCOMPONENTS],
    imports: [
        DevDashboardRoutingModule,
        SharedModule
    ],
    exports: [COMPONENTS],
})
export class DevDashboardModule {
}
