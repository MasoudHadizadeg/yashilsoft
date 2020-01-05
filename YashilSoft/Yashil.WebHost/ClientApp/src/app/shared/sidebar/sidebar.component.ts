import {AfterViewInit, Component, ElementRef, OnInit, Renderer2, ViewChild} from '@angular/core';
import {customAnimations} from '../animations/custom-animations';
import {ConfigService} from '../services/config.service';
import {ActivatedRoute, RouteConfigLoadEnd, RouteConfigLoadStart, Router, RouterEvent} from '@angular/router';
import {TranslateService} from '@ngx-translate/core';
import {GenericDataService} from '../base/services/generic-data.service';
import {RouteInfo} from './sidebar.metadata';
import {YashilComponent} from '../../core/baseClasses/yashilComponent';

@Component({
    selector: 'app-sidebar',
    templateUrl: './sidebar.component.html',
    animations: customAnimations
})
export class SidebarComponent extends YashilComponent implements OnInit, AfterViewInit {
    @ViewChild('toggleIcon', {static: true}) toggleIcon: ElementRef;
    public menuItems: RouteInfo[];
    depth: number;
    activeTitle: string;
    activeTitles: string[] = [];
    expanded: boolean;
    navCollapsedOpen = false;
    logoUrl = 'assets/img/logo.png';
    public config: any = {};
    public isShowingRouteLoadIndicator: boolean;

    constructor(
        private elementRef: ElementRef,
        private renderer: Renderer2,
        private router: Router,
        private route: ActivatedRoute,
        public translate: TranslateService,
        private configService: ConfigService,
        private  genericDataService: GenericDataService
    ) {
        super();
        this.genericDataService.getEntitiesWithAction('Menu', 'UserMenu', null).subscribe(res => {
            this.menuItems = res;
        });
        if (this.depth === undefined) {
            this.depth = 0;
            this.expanded = true;
        }
        this.isShowingRouteLoadIndicator = false;

        // As the router loads modules asynchronously (via loadChildren), we're going to
        // keep track of how many asynchronous requests are currently active. If there is
        // at least one pending load request, we'll show the indicator.
        let asyncLoadCount = 0;
        router.events.subscribe(
            (event: RouterEvent): void => {

                if (event instanceof RouteConfigLoadStart) {

                    this.setBusy(true)
                    asyncLoadCount++;

                } else if (event instanceof RouteConfigLoadEnd) {

                    asyncLoadCount--;
                    this.setBusy(false);
                }

                // If there is at least one pending asynchronous config load request,
                // then let's show the loading indicator.
                // --
                // CAUTION: I'm using CSS to include a small delay such that this loading
                // indicator won't be seen by people with sufficiently fast connections.
                this.isShowingRouteLoadIndicator = !!asyncLoadCount;

            }
        );
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
