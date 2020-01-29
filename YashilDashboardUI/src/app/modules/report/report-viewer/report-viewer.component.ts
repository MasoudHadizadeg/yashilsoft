import {Component, OnInit, ViewEncapsulation} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {Location} from '@angular/common';
import {HttpParams} from '@angular/common/http';
import {GenericDataService, YashilComponent} from 'yashil-core';

declare var Stimulsoft: any;

@Component({
  selector: 'ysh-report-viewer',
  templateUrl: './report-viewer.component.html',
  encapsulation: ViewEncapsulation.None
})

export class ReportViewerComponent extends YashilComponent implements OnInit {
  reportId: any;

  // tslint:disable-next-line:max-line-length
  constructor(private location: Location, private route: ActivatedRoute, private genericDataService: GenericDataService) {
    super();
    if (this.route.snapshot.params.id) {
      this.reportId = this.route.snapshot.params.id;
    }
  }

  ngOnInit() {
    this.setBusy(true);
    Stimulsoft.Base.Localization.StiLocalization.setLocalizationFile('assets/stimulsoft/localization/fa.xml');
    this.showReport();
  }

  showReport() {
    const that = this;
    const report = new Stimulsoft.Report.StiReport();
    const options = new Stimulsoft.Viewer.StiViewerOptions();
    StiOptions.WebServer.url = this.genericDataService.baseUrl + '/reportStore/handler';

    options.toolbar.showAboutButton = false;
    options.toolbar.showOpenButton = false;
    options.appearance.showTooltipsHelp = false;
    Stimulsoft.Base.StiFontCollection.addOpentypeFontFile('assets/fonts/Iransans/fonts/iransansweb.ttf', 'IRANSansWeb');
    // tslint:disable-next-line:max-line-length
    Stimulsoft.Base.StiLicense.Key = '6vJhGtLLLz2GNviWmUTrhSqnOItdDwjBylQzQcAOiHl2AD0gPVknKsaW0un+3PuM6TTcPMUAWEURKXNso0e5OFPaZYasFtsxNoDemsFOXbvf7SIcnyAkFX/4u37NTfx7g+0IqLXw6QIPolr1PvCSZz8Z5wjBNakeCVozGGOiuCOQDy60XNqfbgrOjxgQ5y/u54K4g7R/xuWmpdx5OMAbUbcy3WbhPCbJJYTI5Hg8C/gsbHSnC2EeOCuyA9ImrNyjsUHkLEh9y4WoRw7lRIc1x+dli8jSJxt9C+NYVUIqK7MEeCmmVyFEGN8mNnqZp4vTe98kxAr4dWSmhcQahHGuFBhKQLlVOdlJ/OT+WPX1zS2UmnkTrxun+FWpCC5bLDlwhlslxtyaN9pV3sRLO6KXM88ZkefRrH21DdR+4j79HA7VLTAsebI79t9nMgmXJ5hB1JKcJMUAgWpxT7C7JUGcWCPIG10NuCd9XQ7H4ykQ4Ve6J2LuNo9SbvP6jPwdfQJB6fJBnKg4mtNuLMlQ4pnXDc+wJmqgw25NfHpFmrZYACZOtLEJoPtMWxxwDzZEYYfT';
    const viewer = new Stimulsoft.Viewer.StiViewer(options, 'StiViewer', false);

    const param = new HttpParams().set('id', this.reportId);
    this.genericDataService.getEntitiesWithAction('reportStore', 'GetReportDesigner', param).subscribe((data: any) => {
      this.setBusy(false);
      report.load(JSON.parse(data));
      viewer.report = report;
      viewer.renderHtml('viewerContent');

      const userButton = viewer.jsObject.SmallButton('userButton', 'بازگشت', 'emptyImage');
      userButton.image.src = 'assets/img/tour/close.png';
      // tslint:disable-next-line:only-arrow-functions
      userButton.action = function() {
        that.location.back();
      };
      const toolbarTable = viewer.jsObject.controls.toolbar.firstChild.firstChild;
      const buttonsTable = toolbarTable.rows[0].firstChild.firstChild;
      const userButtonCell = buttonsTable.rows[0].insertCell(0);
      userButtonCell.className = 'stiJsViewerClearAllStyles';
      userButtonCell.appendChild(userButton);
    });
  }
}
