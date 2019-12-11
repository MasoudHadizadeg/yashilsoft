import {Component, OnInit, ViewEncapsulation} from '@angular/core';
import {GenericDataService} from '../../../../shared/base/services/generic-data.service';
import {DynamicScriptLoaderService} from '../../../../shared/services/dynamic-script-loader.service';
import {YashilComponent} from '../../../../core/baseClasses/yashilComponent';
import {Location} from '@angular/common';
import {HttpParams} from '@angular/common/http';
import {ActivatedRoute} from '@angular/router';

declare var Stimulsoft: any;

@Component({
    selector: 'app-report-viewer',
    templateUrl: './report-designer.component.html',
    styleUrls: ['./report-designer.component.css'],
    encapsulation: ViewEncapsulation.None
})

export class ReportDesignerComponent extends YashilComponent implements OnInit {
    reportId: any;

    constructor(private route: ActivatedRoute, private genericDataService: GenericDataService, private location: Location,
                private dynamicScriptLoaderService: DynamicScriptLoaderService) {
        super();
        if (this.route.snapshot.params.id) {
            this.reportId = this.route.snapshot.params.id;
        }
    }

    ngOnInit() {
        this.setBusy(true);
        this.dynamicScriptLoaderService.load(['report', 'viewer', 'designer'], ['viewer_whiteblue', 'designer_whiteblue']).then(data => {
            Stimulsoft.Base.Localization.StiLocalization.setLocalizationFile('assets/stimulsoft/localization/fa.xml');
            Stimulsoft.Base.Localization.StiLocalization
            this.designReport();
        }).catch(error => console.log(error));
    }

    designReport() {
        const that = this;
        StiOptions.WebServer.url = 'api/reportStore/handler';
        StiOptions.Dictionary.showOnlyAliasForDatabase = true;
        const report = new Stimulsoft.Report.StiReport();
        const options = new Stimulsoft.Designer.StiDesignerOptions();
        Stimulsoft.Base.StiLicense.Key = '6vJhGtLLLz2GNviWmUTrhSqnOItdDwjBylQzQcAOiHl2AD0gPVknKsaW0un+3PuM6TTcPMUAWEURKXNso0e5OFPaZYasFtsxNoDemsFOXbvf7SIcnyAkFX/4u37NTfx7g+0IqLXw6QIPolr1PvCSZz8Z5wjBNakeCVozGGOiuCOQDy60XNqfbgrOjxgQ5y/u54K4g7R/xuWmpdx5OMAbUbcy3WbhPCbJJYTI5Hg8C/gsbHSnC2EeOCuyA9ImrNyjsUHkLEh9y4WoRw7lRIc1x+dli8jSJxt9C+NYVUIqK7MEeCmmVyFEGN8mNnqZp4vTe98kxAr4dWSmhcQahHGuFBhKQLlVOdlJ/OT+WPX1zS2UmnkTrxun+FWpCC5bLDlwhlslxtyaN9pV3sRLO6KXM88ZkefRrH21DdR+4j79HA7VLTAsebI79t9nMgmXJ5hB1JKcJMUAgWpxT7C7JUGcWCPIG10NuCd9XQ7H4ykQ4Ve6J2LuNo9SbvP6jPwdfQJB6fJBnKg4mtNuLMlQ4pnXDc+wJmqgw25NfHpFmrZYACZOtLEJoPtMWxxwDzZEYYfT';
        options.appearance.scrollbarsMode = false;
        options.appearance.rightToLeft = true;
        options.appearance.showSaveDialog = false;
        options.appearance.fullScreenMode = true;
        options.toolbar.showFileMenu = false;
        options.toolbar.showFileMenuAbout = false;
        options.toolbar.viewMode = Stimulsoft.Viewer.StiWebViewMode.WholeReport;
        Stimulsoft.Base.StiFontCollection.addOpentypeFontFile('assets/fonts/iransans/fonts/iransansweb.ttf', 'IRANSansWeb');
        const designer = new Stimulsoft.Designer.StiDesigner(options, 'StiDesigner', false);
        const param = new HttpParams().set('id', this.reportId);
        this.genericDataService.getEntitiesWithAction('reportStore', 'GetReportDesigner', param).subscribe((data: any) => {
            this.setBusy(false);
            report.load(JSON.parse(data));
            designer.report = report;
            designer.renderHtml('viewerContent');
        });
        designer.onSaveReport = function (e) {
            const jsonStr = e.report.saveToJsonString();
            that.genericDataService.postEntityByUrl(`api/reportStore/SaveReportDesign`, {
                reportId: 1,
                reportFile: jsonStr
            }).subscribe(() => {
                alert('گزارش با موفقیت ذخیره شد');
            });

        }
    }
}
