import {Routes} from '@angular/router';

// Route for content layout without sidebar, navbar and footer for pages like Login, Registration etc...
export const CONTENT_ROUTES: Routes = [
    {
        path: '',
        loadChildren: () => import('../../pages/content-pages/content-pages.module').then(m => m.ContentPagesModule)
    },
    {
        path: 'rpt',
        loadChildren: () => import('../../pages/stimulsoft-report/stimulsoft-report.module').then(m => m.StimulsoftReportModule)
    }
    ,
    {
        path: 'dash',
        loadChildren: () => import('../../pages/dev-dashboard/dev-dashboard.module').then(m => m.DevDashboardModule)
    }
];
