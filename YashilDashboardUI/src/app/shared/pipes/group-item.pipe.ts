import {Pipe, PipeTransform} from '@angular/core';

@Pipe({
  name: 'groupItem'
})
export class GroupItemPipe implements PipeTransform {

  transform(value: any, id: any): any {
    if (value) {
      return value.filter(x => x.reportGroups.contains(id));
    }
  }
}
