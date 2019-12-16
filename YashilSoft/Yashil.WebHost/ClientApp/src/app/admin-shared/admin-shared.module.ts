import {CoreModule} from '../core/core.module';
import {NgModule} from '@angular/core';
import {AssignableListComponent} from './components/assignable-list/assignable-list.component';
import {CommonModule} from '@angular/common';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import {SharedModule} from '../shared/shared.module';


@NgModule({
    exports: [],
    imports: [
        CoreModule,
        CommonModule,
        ReactiveFormsModule,
        FormsModule,
        HttpClientModule,
        SharedModule
    ],
    declarations: [AssignableListComponent],
    providers: [],
})
export class AdminSharedModule {
}
