import {Routes, RouterModule} from '@angular/router';

// Route for content layout with sidebar, navbar and footer
export const Full_SPLIT_ROUTES: Routes = [
    {
        path: '',
        loadChildren: () => import('./pages/full-layout-split-pages/full-split-pages.module').then(m => m.FullSplitPagesModule)
    }
];
