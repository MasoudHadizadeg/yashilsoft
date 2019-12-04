import {Pipe, PipeTransform} from '@angular/core';
import * as moment from 'jalali-moment';

@Pipe({
  name: 'persianDay'
})
export class PersianDayPipe implements PipeTransform {

  weekDayNames: string[] = ['شنبه', 'یکشنبه', 'دوشنبه',
    'سه شنبه', 'چهارشنبه',
    'پنج شنبه', 'جمعه'];
  monthNames: string[] = [
    'فروردین',
    'اردیبهشت',
    'خرداد',
    'تیر',
    'مرداد',
    'شهریور',
    'مهر',
    'آبان',
    'آذر',
    'دی',
    'بهمن',
    'اسفند'];

  transform(value: any, args?: any): any {
    const m = moment.from(value, 'fa', 'YYYY/MM/DD');
    return this.weekDayNames[m.jDay()] + '-' + m.jDate() + '-' + this.monthNames[m.jMonth()] + ' ' + m.jYear();
  }
}
