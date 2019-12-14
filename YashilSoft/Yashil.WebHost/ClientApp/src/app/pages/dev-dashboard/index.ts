import {Provider} from '@angular/core';
import {DashboardDesignerComponent} from './dashboard-designer/dashboard-designer.component';
import {DashboardViewerComponent} from './dashboard-viewer/dashboard-viewer.component';

export const COMPONENTS: Provider[] = [
    DashboardDesignerComponent,
    DashboardViewerComponent
];
