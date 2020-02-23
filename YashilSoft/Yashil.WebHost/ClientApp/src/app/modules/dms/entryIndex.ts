import {DocFormatDetailComponent} from './doc-format/doc-format-detail.component';
import {DocumentCategoryDetailComponent} from './document-category/document-category-detail.component';
import {AppDocumentDetailComponent} from './app-document/app-document-detail.component';
import {DocTypeDetailComponent} from './doc-type/doc-type-detail.component';
import {Provider} from '@angular/core';
import {EntityDocumentUploadComponent} from './entity-document/entity-document-upload.component';
import {SimpleImageUploaderComponent} from './simple-image-uploader/simple-image-uploader.component';

export const ENTRYCOMPONENTS: Provider[] = [
    DocFormatDetailComponent,
    DocumentCategoryDetailComponent,
    AppDocumentDetailComponent,
    DocTypeDetailComponent,
    EntityDocumentUploadComponent,
    SimpleImageUploaderComponent
];
