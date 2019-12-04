import {Routes, RouterModule} from '@angular/router';

// Route for content layout with sidebar, navbar and footer
export const Full_SPLIT_ROUTES: Routes = [
    {
        path: '',
        loadChildren: './pages/full-layout-split-pages/full-split-pages.module#FullSplitPagesModule'
    }
];
