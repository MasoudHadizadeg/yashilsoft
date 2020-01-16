import {ModuleWithProviders, NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {TextLimitationPipe} from './pipes/text-limitation.pipe';
import {YshTooltipDirective} from './directives/ysh-tooltip.directive';
import {EnvServiceProvider} from './services/env.service.provider';
import {YashilCoreModule} from 'yashil-core';
import {BypassSecurityTrustResourceUrlPipe} from './pipes/bypass-security-trust-resource-url.pipe';
import {GroupItemPipe} from './pipes/group-item.pipe';


@NgModule({
  imports: [
    CommonModule,
    YashilCoreModule
  ],
  providers: [EnvServiceProvider],
  declarations: [TextLimitationPipe, BypassSecurityTrustResourceUrlPipe, YshTooltipDirective, GroupItemPipe],
  exports: [
    TextLimitationPipe,
    BypassSecurityTrustResourceUrlPipe,
    YshTooltipDirective,
    YashilCoreModule,
    GroupItemPipe
  ]
})
export class SharedModule {
  static forRoot(): ModuleWithProviders {
    return {
      ngModule: SharedModule
    };
  }
}

