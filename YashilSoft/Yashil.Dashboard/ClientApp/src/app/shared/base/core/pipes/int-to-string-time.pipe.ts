import {Pipe, PipeTransform} from '@angular/core';

@Pipe({
    name: 'intToStringTime'
})
export class IntToStringTimePipe implements PipeTransform {

    transform(value: any): any {
        if (value) {
            return value.toString().substring(0, 2) + ':' + value.toString().substring(2);
        }
        return null;
    }

}
