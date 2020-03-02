import {DocFormatDetailComponent} from './doc-format/doc-format-detail.component';
import {DocFormatListComponent} from './doc-format/doc-format-list.component';
import {DocumentCategoryDetailComponent} from './document-category/document-category-detail.component';
import {DocumentCategoryListComponent} from './document-category/document-category-list.component';
import {AppDocumentDetailComponent} from './app-document/app-document-detail.component';
import {AppDocumentListComponent} from './app-document/app-document-list.component';
import {DocTypeDetailComponent} from './doc-type/doc-type-detail.component';
import {DocTypeListComponent} from './doc-type/doc-type-list.component';
import {Provider} from '@angular/core';
import {EntityDocumentUploadComponent} from './entity-document/entity-document-upload.component';
import {SimpleImageUploaderComponent} from './uploader-components/simple-image-uploader/simple-image-uploader.component';
import {SimplePdfUploaderComponent} from './uploader-components/simple-pdf-uploader/simple-pdf-uploader.component';

export const COMPONENTS: Provider[] = [

    DocFormatListComponent,
    DocFormatDetailComponent,
    DocumentCategoryListComponent,
    DocumentCategoryDetailComponent,
    AppDocumentListComponent,
    AppDocumentDetailComponent,
    DocTypeListComponent,
    DocTypeDetailComponent,
    EntityDocumentUploadComponent,
    SimpleImageUploaderComponent,
    SimplePdfUploaderComponent
];
