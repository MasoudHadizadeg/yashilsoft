import {ReportViewerComponent} from './stimulsoft/report-viewer/report-viewer.component';
import {ReportDesignerComponent} from './stimulsoft/report-designer/report-designer.component';
import {Provider} from '@angular/core';

export const COMPONENTS: Provider[] = [
    ReportDesignerComponent,
    ReportViewerComponent
];
