import {Component, OnInit, ViewEncapsulation} from '@angular/core';
import {GenericDataService} from '../../../../shared/base/services/generic-data.service';
import {DynamicScriptLoaderService} from '../../../../shared/services/dynamic-script-loader.service';
import {ActivatedRoute} from '@angular/router';
import {Location} from '@angular/common';
import {HttpParams} from '@angular/common/http';
import {YashilComponent} from '../../../../core/baseClasses/yashilComponent';

declare var Stimulsoft: any;

@Component({
    selector: 'app-report-viewer',
    templateUrl: './report-viewer.component.html',
    encapsulation: ViewEncapsulation.None
})

export class ReportViewerComponent extends YashilComponent implements OnInit {
    reportId: any;

    constructor(private location: Location, private route: ActivatedRoute, private genericDataService: GenericDataService, private dynamicScriptLoaderService: DynamicScriptLoaderService) {
        super();
        if (this.route.snapshot.params.id) {
            this.reportId = this.route.snapshot.params.id;
        }
    }

    ngOnInit() {
        this.setBusy(true);
        this.dynamicScriptLoaderService.load(['report', 'viewer', 'designer'], ['viewer_whiteblue', 'designer_whiteblue']).then(data => {
            Stimulsoft.Base.Localization.StiLocalization.setLocalizationFile('assets/stimulsoft/localization/fa.xml');
            this.showReport();
        }).catch(error => console.log(error));
    }

    showReport() {
        const that = this;
        const report = new Stimulsoft.Report.StiReport();
        const options = new Stimulsoft.Viewer.StiViewerOptions();
        options.toolbar.showParametersButton = true;
        options.appearance.scrollbarsMode = true;
        options.toolbar.showDesignButton = true;
        options.toolbar.printDestination = Stimulsoft.Viewer.StiPrintDestination.Direct;
        options.appearance.htmlRenderMode = Stimulsoft.Report.Export.StiHtmlExportMode.Div;

        // const viewer = new Stimulsoft.Viewer.StiViewer(options, 'StiViewer', false);
        const viewer = new Stimulsoft.Viewer.StiViewer(options, 'StiViewer', false);

        const param = new HttpParams().set('id', this.reportId);
        this.genericDataService.getEntitiesWithAction('reportStore', 'GetReportViewer', param).subscribe((data: any) => {
            this.setBusy(false);
            report.load(JSON.parse(data));
            viewer.report = report;
            viewer.renderHtml('viewerContent');
        });
    }
}
