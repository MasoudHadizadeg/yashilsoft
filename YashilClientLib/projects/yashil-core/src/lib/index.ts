import {Provider} from '@angular/core';
import {BusyIndicatorComponent} from './core/components/busy-indicator/busy-indicator.component';
import {SecuredImageComponent} from './core/components/secured-image/secured-image.component';
import {IntToDateTimePipe} from './core/pipes/jalali/int-to-date-time.pipe';
import {IntToStringDatePipe} from './core/pipes/jalali/Int-to-string-date.pipe';
import {IntToStringTimePipe} from './core/pipes/jalali/int-to-string-time.pipe';
import {JalaliPipe} from './core/pipes/jalali/jalali.pipe ';
import {PersianDayPipe} from './core/pipes/jalali/persian-day.pipe';

export const COMPONENTS: Provider[] = [
  BusyIndicatorComponent,
  SecuredImageComponent,
  IntToDateTimePipe,
  IntToStringDatePipe,
  IntToStringTimePipe,
  JalaliPipe,
  PersianDayPipe
];
