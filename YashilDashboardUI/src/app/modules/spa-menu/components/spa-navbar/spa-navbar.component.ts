import {AfterViewInit, Component, Input, OnInit} from '@angular/core';
import {FakeModel} from '../../models/FakeModel';
import {ActivatedRoute} from '@angular/router';
import {interval} from 'rxjs';
import {SliderFunction} from '../../../../shared/helper/SliderFunction';

@Component({
  selector: 'ysh-spa-navbar',
  templateUrl: './spa-navbar.component.html',
  styleUrls: ['./spa-navbar.component.scss']
})

export class SpaNavbarComponent implements OnInit, AfterViewInit {
  @Input()
  navBarItems: any[] = [];
  sliderContent = FakeModel.sliderContent;
  mobileMenuToggle: boolean;
  currentSliderId;
  currentSlider = {bigTitle: '', smallTitle: '', imageUrl: ''};
  animationState;
  animationTime = 6;

  constructor() {
  }

  ngOnInit() {
    this.mobileMenuToggle = false;
    this.animationState = false;
    this.initialSlider();
    window.onclick = () => {
      this.mobileMenuToggle = false;
    };
  }

  ngAfterViewInit(): void {

  }

  initialSlider() {
    this.currentSliderId = 0;
    this.setSliderContent();
    this.sliderInterval();
  }

  changeSlider(value) {
    this.currentSliderId = SliderFunction(this.sliderContent, value, this.currentSliderId);
    // this.animationState = !this.animationState;
    this.setSliderContent();
  }

  setSliderContent() {
    this.currentSlider.bigTitle = this.sliderContent[this.currentSliderId].bigTitle;
    this.currentSlider.smallTitle = this.sliderContent[this.currentSliderId].smallTitle;
    this.currentSlider.imageUrl = this.sliderContent[this.currentSliderId].imageUrl;
  }

  sliderInterval() {
    const timer = interval(1000);
    const subscriber = timer.subscribe(t => {
      this.animationState = false;
      if (t % this.animationTime === 0) {
        this.changeSlider('next');
      }
    });
  }

  toggleMenu(event) {
    event.stopPropagation();
    this.mobileMenuToggle = !this.mobileMenuToggle;
  }
}
