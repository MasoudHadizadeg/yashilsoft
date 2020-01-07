import {Pipe, PipeTransform} from '@angular/core';

@Pipe({
  name: 'textLimitation'
})
export class TextLimitationPipe implements PipeTransform {

  transform(value: any, args: any): any {
    const defaultLength = 100;
    if (typeof value === 'string') {
      return this.limitation(value, args ? args : defaultLength);
    } else {
      return this.limitation(value.toString(), args ? args : defaultLength);
    }
  }

  limitation(value: string, limitNumber) {
    if (value.length > limitNumber) {
      return value.substring(0, limitNumber) + '...';
    }
    return value;
  }


}
