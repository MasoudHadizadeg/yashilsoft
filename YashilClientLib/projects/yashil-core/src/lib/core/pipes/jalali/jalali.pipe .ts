import {Pipe, PipeTransform} from '@angular/core';
import moment from 'jalali-moment';

@Pipe({
  name: 'jalali'
})
export class JalaliPipe implements PipeTransform {
  transform(value: any, args?: any): any {
    // 2010-10-09 00:00:00.000
    // 2019-08-01T00:00:00
    try {
      const momentDate = moment(value);
      return momentDate.locale('fa').format('YYYY/MM/DD');
    } catch (e) {
      return value;
    }
  }
}
