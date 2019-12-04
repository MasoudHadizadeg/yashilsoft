import {Pipe, PipeTransform} from '@angular/core';
import * as moment from 'jalali-moment';

@Pipe({
    name: 'intToDateTime'
})
export class IntToDateTimePipe implements PipeTransform {

    transform(value: any): any {
        if (value) {
            const s = value.toString().substring(0, 4) + '/' + value.toString().substring(4, 6) + '/' + value.toString().substring(6, 8);
            return moment(s, 'jYYYY/jMM/jD').locale('fa');
        }
        return null;
    }

}
