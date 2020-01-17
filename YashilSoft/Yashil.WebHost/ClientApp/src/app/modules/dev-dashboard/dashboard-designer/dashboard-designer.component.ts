import * as Globalize from 'globalize';
import {Component, ElementRef, OnDestroy, OnInit} from '@angular/core';
import {DashboardControl, ResourceManager} from 'devexpress-dashboard';
import {YashilComponent} from '../../../core/baseClasses/yashilComponent';
import {ActivatedRoute} from '@angular/router';
import {DashboardMenuItem, ToolboxExtension} from 'devexpress-dashboard/designer';
import {Location} from '@angular/common';

declare var require: (e: string) => object;

@Component({
    selector: 'app-dashboard-designer',
    templateUrl: 'dashboard-designer.component.html',
    styleUrls: ['./dashboard-designer.component.css']
})

export class DashboardDesignerComponent extends YashilComponent implements OnInit, OnDestroy {
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

    ngOnInit(): void {
        this.setBusy(true);
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
        (toolBox as ToolboxExtension).menuItems.push(dashboardMenuItem);
        // tslint:disable-next-line:prefer-const
        // const HELLOWORLD_ITEM_ICON = '<svg id="helloWorldItemIcon" viewBox="0 0 24 24"><path stroke="#42f48f" fill="#42f48f" d="M12 2 L2 22 L22 22 Z" /></svg>';
        // ResourceManager.registerIcon(HELLOWORLD_ITEM_ICON);
        const api = this.dashboardControl.findExtension('viewer-api');

        api['_options'].onItemWidgetCreated = function (s, e) {
            that.customizeWidgets(s);
        }

        api['_options'].onItemWidgetUpdated = function (s, e) {
            that.customizeWidgets(s);
        }

        this.dashboardControl.render();
        this.setBusy(false);
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
        this.dashboardControl.dispose();
    }
}
