import {Component, OnInit, ViewEncapsulation} from '@angular/core';
import {GenericDataService} from '../../../../shared/base/services/generic-data.service';
import {DynamicScriptLoaderService} from '../../../../shared/services/dynamic-script-loader.service';
import {YashilComponent} from '../../../../core/baseClasses/yashilComponent';
import {Location} from '@angular/common';
import {HttpParams} from '@angular/common/http';
import {ActivatedRoute} from '@angular/router';

declare var Stimulsoft: any;

@Component({
    selector: 'app-report-designer',
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
            this.designReport();
        }).catch(error => console.log(error));
    }

    designReport() {
        const that = this;
        StiOptions.WebServer.url = 'api/reportStore/handler';

        const report = new Stimulsoft.Report.StiReport();

        const options = new Stimulsoft.Designer.StiDesignerOptions();
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
                reportId: +that.reportId,
                reportFile: jsonStr
            }).subscribe(() => {
                alert('گزارش با موفقیت ذخیره شد');
            });

        }
    }
}
