import {Directive, ElementRef, HostListener, Inject, Input, Renderer2} from '@angular/core';
import {DOCUMENT} from '@angular/common';

@Directive({
  selector: '[yshYshTooltip]'
})
export class YshTooltipDirective {


  @Input() text;
  @Input() textLimitation;

  child;

  constructor(private el: ElementRef,
              private renderer: Renderer2,
              @Inject(DOCUMENT) private document) {
  }


  @HostListener('mouseenter') onMouseEnter() {
    this.showPopUP();
  }

  @HostListener('mouseleave') onMouseLeave() {
    this.renderer.removeChild(this.el.nativeElement, this.child);
  }


  showPopUP() {
    this.child = document.createElement('div');
    this.child.style.position = 'absolute';
    this.child.style.top = '-100px';
    this.child.style.left = '0';
    this.child.style.minWidth = '100px';
    this.child.style.minHeight = '50px';
    this.child.style.backgroundColor = 'orangered';
    this.child.style.zIndex = '99999999999';
    this.child.innerText = this.text;
    this.child.style.padding = '10px';
    this.child.style.borderRadius = '5px';
    this.child.style.fontSize = '12px';
    this.child.style.color = '#ffffff';
    this.child.style.whitespace = 'none';

    if (this.text.length > this.textLimitation) {
      this.renderer.appendChild(this.el.nativeElement, this.child);
    }
  }

}
