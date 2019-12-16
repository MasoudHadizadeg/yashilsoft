import {Routes, RouterModule} from '@angular/router';

// Route for content layout with sidebar, navbar and footer
export const Full_ROUTES: Routes = [
    {
        path: '',
        loadChildren: () => import('../../modules/full-layout-page/full-pages.module').then(m => m.FullPagesModule)
    }
];
