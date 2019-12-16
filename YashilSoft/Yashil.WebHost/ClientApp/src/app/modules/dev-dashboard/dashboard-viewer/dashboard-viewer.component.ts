import * as Globalize from 'globalize';
import {YashilComponent} from '../../../core/baseClasses/yashilComponent';
import {AfterViewInit, Component, ElementRef, OnDestroy} from '@angular/core';
import {DashboardControl, ResourceManager} from 'devexpress-dashboard';

declare var require: (e: string) => object

@Component({
    selector: 'app-dashboard-viewer',
    templateUrl: './dashboard-viewer.component.html',
    styleUrls: ['./dashboard-viewer.component.css']
})

export class DashboardViewerComponent extends YashilComponent implements AfterViewInit, OnDestroy {
    private dashboardControl!: DashboardControl;

    constructor(private element: ElementRef) {
        super();
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
            endpoint: 'https://localhost:44368/api/dashboard',
            workingMode: 'ViewerOnly',
            initialDashboardId: '1',
            loadDefaultDashboard: false,
            useCardLegacyLayout: false
        });

        this.dashboardControl.render();
    }

    ngOnDestroy(): void {
        if (this.dashboardControl) {
            this.dashboardControl.dispose();
        }
    }
}
