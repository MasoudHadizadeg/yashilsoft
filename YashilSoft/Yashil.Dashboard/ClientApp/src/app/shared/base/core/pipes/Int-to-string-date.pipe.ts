import {Pipe, PipeTransform} from '@angular/core';
import * as moment from 'jalali-moment';

@Pipe({
    name: 'intToStringDate'
})
export class IntToStringDatePipe implements PipeTransform {

    transform(value: any): any {
        if (value) {
            return  value.toString().substring(0, 4) + '/' + value.toString().substring(4, 6) + '/' + value.toString().substring(6, 8);
        }
        return null;
    }

}
