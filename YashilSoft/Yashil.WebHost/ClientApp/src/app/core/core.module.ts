import {NgModule} from '@angular/core';
import {BusyIndicatorComponent} from './components/busy-indicator/busy-indicator.component';
import {CommonModule} from '@angular/common';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {RouterModule} from '@angular/router';
// COMPONENTS
// DIRECTIVES

@NgModule({
    exports: [
        BusyIndicatorComponent,
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule
    ],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule
    ],
    declarations: [BusyIndicatorComponent],
    providers: [],
})
export class CoreModule {
}
