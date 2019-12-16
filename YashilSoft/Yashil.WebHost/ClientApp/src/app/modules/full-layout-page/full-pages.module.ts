import {NgModule} from '@angular/core';
import {FullPagesRoutingModule} from './full-pages-routing.module';
import {COMPONENTS} from './index';
import {ENTRYCOMPONENTS} from './entryIndex';
import {SharedModule} from '../../shared/shared.module';

@NgModule({
    declarations: [COMPONENTS],
    entryComponents: [ENTRYCOMPONENTS],
    imports: [
        FullPagesRoutingModule,
        SharedModule
    ],
    providers: [],
    exports: [COMPONENTS],
})
export class FullPagesModule {
}
