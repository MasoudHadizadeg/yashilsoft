import {Directive, ViewContainerRef} from '@angular/core';

@Directive({
  selector: '[appDetailComponentHost]',
})
export class DetailComponentDirective {
  constructor(public viewContainerRef: ViewContainerRef) { }
}

