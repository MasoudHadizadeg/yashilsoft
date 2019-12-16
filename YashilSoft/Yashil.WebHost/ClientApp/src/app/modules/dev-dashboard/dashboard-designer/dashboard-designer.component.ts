import * as Globalize from 'globalize';
import {AfterViewInit, Component, ElementRef, OnDestroy} from '@angular/core';
import {DashboardControl, ResourceManager} from 'devexpress-dashboard';
import {YashilComponent} from '../../../core/baseClasses/yashilComponent';
import {ActivatedRoute} from '@angular/router';
import {DashboardMenuItem} from 'devexpress-dashboard/designer';
import {Location} from '@angular/common';

declare var require: (e: string) => object;

@Component({
    selector: 'app-dashboard-designer',
    templateUrl: 'dashboard-designer.component.html',
    styleUrls: ['./dashboard-designer.component.css']
})

export class DashboardDesignerComponent extends YashilComponent implements AfterViewInit, OnDestroy {
    private dashboardControl!: DashboardControl;
    dashboardId: any;

    constructor(private location: Location, private route: ActivatedRoute, private element: ElementRef) {
        super();
        if (this.route.snapshot.params.id) {
            this.dashboardId = this.route.snapshot.params.id;
        }
        this.initGlobalize();
        ResourceManager.embedBundledResources();
    }

    initGlobalize() {
        Globalize.load([
            require('devextreme-cldr-data/en.json'),
            // require('devextreme-cldr-data/de.json'),
            require('devextreme-cldr-data/supplemental.json')
        ]);
        Globalize.locale('en');
    }

    ngAfterViewInit(): void {
        this.dashboardControl = new DashboardControl(this.element.nativeElement.querySelector('.dashboard-container'), {
            // Specifies a URL of the Web Dashboard's server.
            endpoint: '/api/dashboard',
            initialDashboardId: this.dashboardId,
            loadDefaultDashboard: false,
            useCardLegacyLayout: false,
            workingMode: 'Designer'
        });
        const toolBox = this.dashboardControl.findExtension('toolbox');
        this.dashboardControl.unregisterExtension('create-dashboard');
        this.dashboardControl.unregisterExtension('open-dashboard');

        const that = this;
        const dashboardMenuItem = new DashboardMenuItem('save-as_custom', 'Exit', 120, 0, function () {
            that.location.back();
        });
        toolBox.menuItems.push(dashboardMenuItem);
        // tslint:disable-next-line:prefer-const
        const HELLOWORLD_ITEM_ICON = '<svg id="helloWorldItemIcon" viewBox="0 0 24 24"><path stroke="#42f48f" fill="#42f48f" d="M12 2 L2 22 L22 22 Z" /></svg>';
        ResourceManager.registerIcon(HELLOWORLD_ITEM_ICON);


        this.dashboardControl.render();
    }

    ngOnDestroy(): void {
        this.dashboardControl.dispose();
    }
}
