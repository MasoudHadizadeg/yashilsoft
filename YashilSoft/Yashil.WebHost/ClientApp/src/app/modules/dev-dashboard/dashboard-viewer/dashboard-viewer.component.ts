import * as Globalize from 'globalize';
import {YashilComponent} from '../../../core/baseClasses/yashilComponent';
import {AfterViewInit, Component, ElementRef, OnDestroy} from '@angular/core';
import {DashboardControl, ResourceManager} from 'devexpress-dashboard';
import {Location} from '@angular/common';
import {ActivatedRoute} from '@angular/router';

declare var require: (e: string) => object

@Component({
    selector: 'app-dashboard-viewer',
    templateUrl: './dashboard-viewer.component.html',
    styleUrls: ['./dashboard-viewer.component.css']
})

export class DashboardViewerComponent extends YashilComponent implements AfterViewInit, OnDestroy {
    private dashboardControl!: DashboardControl;
    dashboardId: any;

    constructor(private element: ElementRef, private route: ActivatedRoute) {
        super();
        this.initGlobalize();
        if (this.route.snapshot.params.id) {
            this.dashboardId = this.route.snapshot.params.id;
        }
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
            workingMode: 'ViewerOnly',
            initialDashboardId: this.dashboardId,
            loadDefaultDashboard: false,
            useCardLegacyLayout: false
        });
        const that = this;
        const api = this.dashboardControl.findExtension('viewer-api');

        api['_options'].onItemWidgetCreated = function (s, e) {
            that.customizeWidgets(s);
        }

        api['_options'].onItemWidgetUpdated = function (s, e) {
            that.customizeWidgets(s);
        }
        this.dashboardControl.render();
    }

    customizeWidgets(args) {
        const widget = args.getWidget();
        widget.option('rtlEnabled', true);
        if (widget.NAME === 'dxDataGrid') {
            for (let i = 0; i < widget.columnCount(); i++) {
                widget.columnOption(i, 'alignment', 'right');
            }
        }
        if (args.ItemName === 'chartDashboardItem') {
            const chart = args.GetWidget();
            chart.option({
                tooltip: {
                    enabled: false
                },
                onArgumentAxisClick: function (info) {
                    info.component.getAllSeries()[0].getPointsByArg(info.argument)[0].showTooltip()
                }
            });
        }
        if (args.ItemName === 'pieDashboardItem1') {
            const pie = args.GetWidget()[0];
            pie.option({
                legend: {
                    visible: true,
                    border: {
                        visible: true
                    }
                }
            });
        }
    }

    ngOnDestroy(): void {
        if (this.dashboardControl) {
            this.dashboardControl.dispose();
        }
    }
}
