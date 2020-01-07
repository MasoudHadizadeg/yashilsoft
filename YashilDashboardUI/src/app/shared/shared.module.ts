import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {TextLimitationPipe} from './pipes/text-limitation.pipe';
import {YshTooltipDirective} from './directives/ysh-tooltip.directive';
import {EnvServiceProvider} from './services/env.service.provider';
import {YashilCoreModule} from 'yashil-core';


@NgModule({
  imports: [
    CommonModule,
    YashilCoreModule
  ],
  providers: [EnvServiceProvider],
  declarations: [TextLimitationPipe, YshTooltipDirective],
  exports: [
    TextLimitationPipe,
    YshTooltipDirective,
    YashilCoreModule
  ]
})
export class SharedModule {
}
