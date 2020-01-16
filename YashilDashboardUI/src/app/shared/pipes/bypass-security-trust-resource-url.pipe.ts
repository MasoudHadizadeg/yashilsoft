import {Pipe, PipeTransform} from '@angular/core';
import {DomSanitizer} from '@angular/platform-browser';

@Pipe({
  name: 'fixBase64Image'
})
export class BypassSecurityTrustResourceUrlPipe implements PipeTransform {

  constructor(private sanitizer: DomSanitizer) {
  }

  transform(value: any): any {
    // this.sanitizer.bypassSecurityTrustResourceUrl(atob(this.entity.picture))
    return this.sanitizer.bypassSecurityTrustResourceUrl(atob(value));
  }
}
