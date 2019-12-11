import {Component, OnInit, ViewEncapsulation} from '@angular/core';
import {GenericDataService} from '../../../../shared/base/services/generic-data.service';
import {DynamicScriptLoaderService} from '../../../../shared/services/dynamic-script-loader.service';

declare var Stimulsoft: any;

@Component({
    selector: 'app-report-viewer',
    template: `
        <div style="text-align: left; direction: ltr" id="viewerContent"></div>`,
    encapsulation: ViewEncapsulation.None
})

export class ReportViewerComponent implements OnInit {
    constructor(private genericDataService: GenericDataService, private dynamicScriptLoaderService: DynamicScriptLoaderService) {
    }

    ngOnInit() {
        this.dynamicScriptLoaderService.load(['report', 'viewer', 'designer'], ['viewer_whiteblue', 'designer_whiteblue']).then(data => {
            Stimulsoft.Base.Localization.StiLocalization.setLocalizationFile('assets/stimulsoft/localization/fa.xml');
            this.showReport();
        }).catch(error => console.log(error));
    }

    showReport() {
        const report = new Stimulsoft.Report.StiReport();
        const options = new Stimulsoft.Viewer.StiViewerOptions();
        const viewer = new Stimulsoft.Viewer.StiViewer(options, 'StiViewer', false);
        this.genericDataService.getEntitiesWithAction('report', 'GetReportViewer', null).subscribe((data: any) => {
            report.load(JSON.parse(data));
            viewer.report = report;
            viewer.renderHtml('viewerContent');
        });
    }
}
