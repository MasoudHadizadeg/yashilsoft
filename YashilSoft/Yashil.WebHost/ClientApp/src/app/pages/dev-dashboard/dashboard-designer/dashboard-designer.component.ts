import * as Globalize from 'globalize';
import {AfterViewInit, Component, ElementRef, OnDestroy} from '@angular/core';
import {DashboardControl, ResourceManager} from 'devexpress-dashboard';
import {YashilComponent} from '../../../core/baseClasses/yashilComponent';
import {ActivatedRoute} from '@angular/router';

declare var require: (e: string) => object;

@Component({
    selector: 'app-dashboard-designer',
    templateUrl: 'dashboard-designer.component.html',
    styleUrls: ['./dashboard-designer.component.css']
})

export class DashboardDesignerComponent extends YashilComponent implements AfterViewInit, OnDestroy {
    private dashboardControl!: DashboardControl;
    dashboardId: any;

    constructor(private route: ActivatedRoute, private element: ElementRef) {
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
        let toolbox = this.dashboardControl.findExtension('toolbox');
        // toolbox.removeMenuItem("open-dashboard");

        this.dashboardControl.render();
    }

    ngOnDestroy(): void {
        this.dashboardControl.dispose();
    }
}
