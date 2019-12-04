import {NgModule} from '@angular/core';
import {BusyIndicatorComponent} from './components/busy-indicator/busy-indicator.component';
import {CommonModule} from '@angular/common';
// COMPONENTS
// DIRECTIVES

@NgModule({
  exports: [BusyIndicatorComponent],
  imports: [CommonModule],
  declarations: [BusyIndicatorComponent],
  providers: [],
})
export class CoreModule {
}
