import {AfterViewInit, Component, ElementRef, OnInit, Renderer2, ViewChild} from '@angular/core';
import {customAnimations} from '../animations/custom-animations';
import {ConfigService} from '../services/config.service';
import {ActivatedRoute, Router} from '@angular/router';
import {TranslateService} from '@ngx-translate/core';
import {GenericDataService} from '../base/services/generic-data.service';
import {RouteInfo} from './sidebar.metadata';
import {DxFormComponent} from 'devextreme-angular';

@Component({
    selector: 'app-sidebar',
    templateUrl: './sidebar.component.html',
    animations: customAnimations
})
export class SidebarComponent implements OnInit, AfterViewInit {

    @ViewChild('toggleIcon', { static: true }) toggleIcon: ElementRef;
    public menuItems: RouteInfo[];
    depth: number;
    activeTitle: string;
    activeTitles: string[] = [];
    expanded: boolean;
    navCollapsedOpen = false;
    logoUrl = 'assets/img/logo.png';
    public config: any = {};


    constructor(
        private elementRef: ElementRef,
        private renderer: Renderer2,
        private router: Router,
        private route: ActivatedRoute,
        public translate: TranslateService,
        private configService: ConfigService,
        private  genericDataService: GenericDataService
    ) {
        this.genericDataService.getEntitiesWithAction('Menu', 'UserMenu', null).subscribe(res => {
            this.menuItems = res;
        });
        if (this.depth === undefined) {
            this.depth = 0;
            this.expanded = true;
        }
    }


    ngOnInit() {
        this.config = this.configService.templateConf;
        // let ent = {};
        // this.menuItems = ROUTES;


        if (this.config.layout.sidebar.backgroundColor === 'white') {
            this.logoUrl = 'assets/img/logo-dark.png';
        } else {
            this.logoUrl = 'assets/img/logo.png';
        }


    }

    ngAfterViewInit() {

        setTimeout(() => {
            if (this.config.layout.sidebar.collapsed !== undefined) {
                if (this.config.layout.sidebar.collapsed === true) {
                    this.expanded = false;
                    this.renderer.addClass(this.toggleIcon.nativeElement, 'ft-toggle-left');
                    this.renderer.removeClass(this.toggleIcon.nativeElement, 'ft-toggle-right');
                    this.navCollapsedOpen = true;
                } else if (this.config.layout.sidebar.collapsed === false) {
                    this.expanded = true;
                    this.renderer.removeClass(this.toggleIcon.nativeElement, 'ft-toggle-left');
                    this.renderer.addClass(this.toggleIcon.nativeElement, 'ft-toggle-right');
                    this.navCollapsedOpen = false;
                }
            }
        }, 0);


    }

    toggleSlideInOut() {
        this.expanded = !this.expanded;
    }

    handleToggle(titles) {
        this.activeTitles = titles;
    }

    // NGX Wizard - skip url change
    ngxWizardFunction(path: string) {
        if (path.indexOf('forms/ngx') !== -1) {
            this.router.navigate(['forms/ngx/wizard'], {skipLocationChange: false});
        }
    }
}
