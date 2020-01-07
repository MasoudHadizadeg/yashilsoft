import {AfterViewInit, Component, OnInit} from '@angular/core';
import {FakeModel} from '../../models/FakeModel';
import {Router} from '@angular/router';
import {ScrollAfterRouteChange} from '../../../shared/helper/ScrollFunction';
import {interval} from 'rxjs';
import {SliderFunction} from '../../../shared/helper/SliderFunction';

@Component({
  selector: 'ysh-spa-navbar',
  templateUrl: './spa-navbar.component.html',
  styleUrls: ['./spa-navbar.component.scss']
})

export class SpaNavbarComponent implements OnInit, AfterViewInit {

  navBarItems = FakeModel.menu;
  sliderContent = FakeModel.sliderContent;
  mobileMenuToggle: boolean;
  currentMenu;
  currentSliderId;
  currentSlider = {bigTitle: '', smallTitle: '', imageUrl: ''};
  animationState;
  animationTime = 6;

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

  constructor(private router: Router) {
    this.currentMenu = this.router.getCurrentNavigation();
  }


  toggleMenu(event) {
    event.stopPropagation();
    this.mobileMenuToggle = !this.mobileMenuToggle;
  }

  ngOnInit() {
    this.mobileMenuToggle = false;

    this.animationState = false;

    this.currentSliderId = 0;

    this.setSliderContent();
    this.sliderInterval();

    window.onclick = () => {
      this.mobileMenuToggle = false;
    };
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

  ngAfterViewInit(): void {
    ScrollAfterRouteChange(this.currentMenu);
  }
}
