import {Routes} from '@angular/router';

// Route for content layout without sidebar, navbar and footer for pages like Login, Registration etc...
export const CONTENT_ROUTES: Routes = [
    {
        path: '',
        loadChildren: () => import('../../modules/content-pages/content-pages.module').then(m => m.ContentPagesModule)
    },
    {
        path: 'rpt',
        loadChildren: () => import('../../modules/stimulsoft-report/stimulsoft-report.module').then(m => m.StimulsoftReportModule)
    },
    {
        path: 'dash',
        loadChildren: () => import('../../modules/dev-dashboard/dev-dashboard.module').then(m => m.DevDashboardModule)
    },
    {
        path: 'tms',
        loadChildren: () => import('../../modules/tms/tms.module').then(m => m.TmsModule)
    },
    {
        path: 'news',
        loadChildren: () => import('../../modules/news/news.module').then(m => m.NewsModule)
    }
];
