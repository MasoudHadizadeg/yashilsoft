import {RouterModule, Routes} from '@angular/router';
import {AuthGuard} from '../../shared/_guards';
import {DocFormatListComponent} from './doc-format/doc-format-list.component';
import {DocumentCategoryListComponent} from './document-category/document-category-list.component';
import {AppDocumentListComponent} from './app-document/app-document-list.component';
import {DocTypeListComponent} from './doc-type/doc-type-list.component';
import {FullLayoutSplitComponent} from '../../layouts/fullsplit/full-layout-split.component';
import {NgModule} from '@angular/core';

const routes: Routes = [
    {path: 'docFormats', component: DocFormatListComponent, canActivate: [AuthGuard]},
    {path: 'documentCategorys', component: DocumentCategoryListComponent, canActivate: [AuthGuard]},
    {path: 'appDocuments', component: AppDocumentListComponent, canActivate: [AuthGuard]},
    {path: 'docTypes', component: DocTypeListComponent, canActivate: [AuthGuard]}
];

@NgModule({
        imports: [RouterModule.forChild(routes)],
        exports: [RouterModule],
    }
)
export class DmsRoutingModule {

}
