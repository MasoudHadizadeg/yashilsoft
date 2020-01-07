import {NgModule} from '@angular/core';
import {COMPONENTS} from './index';
import {CommonModule} from '@angular/common';

@NgModule({
  declarations: [COMPONENTS],
  imports: [CommonModule],
  exports: [COMPONENTS]
})
export class YashilCoreModule {
}
