import * as Globalize from 'globalize';
import {AfterViewInit, Component, ElementRef, OnDestroy} from '@angular/core';
import {DashboardControl, ResourceManager} from 'devexpress-dashboard';
import {ActivatedRoute} from '@angular/router';
import {GenericDataService, YashilComponent} from 'yashil-core';
import {EnvService} from '../../../shared/services/env.service';

declare var require: (e: string) => object;

@Component({
  selector: 'ysh-dashboard-viewer',
  templateUrl: './dashboard-viewer.component.html',
  styleUrls: ['./dashboard-viewer.component.css']
})

export class DashboardViewerComponent extends YashilComponent implements AfterViewInit, OnDestroy {
  private dashboardControl!: DashboardControl;
  dashboardId: any;

  constructor(private element: ElementRef, private route: ActivatedRoute, private env: EnvService) {
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
      endpoint: this.env.apiUrl + '/api/dashboard',
      workingMode: 'ViewerOnly',
      initialDashboardId: this.dashboardId,
      loadDefaultDashboard: false,
      useCardLegacyLayout: false
    });
    const that = this;
    const api = this.dashboardControl.findExtension('viewer-api');

    api['_options'].onItemWidgetCreated = (s, e) => {
      that.customizeWidgets(s);
    };

    api['_options'].onItemWidgetUpdated = (s, e) => {
      that.customizeWidgets(s);
    };
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
    if (widget.NAME === 'dxVectorMap') {
      widget.option('controlBar', {
        borderColor: '#5d5d5d',
        color: '#ffffff',
        enabled: true,
        horizontalAlignment: 'left',
        margin: 20,
        opacity: 0.3,
        verticalAlignment: 'top'
      });
      widget.option('focusStateEnabled', true);
      widget.option('zoom', 10);
    }
    if (widget.NAME === 'dxChart') {
      widget.option({
        tooltip: {
          enabled: false
        },
        onArgumentAxisClick: info => {
          info.component.getAllSeries()[0].getPointsByArg(info.argument)[0].showTooltip();
        }
      });
    }
    if (widget.NAME === 'dxPieChart') {
      widget.option({
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
