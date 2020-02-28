import {Component, Input, OnInit, ViewChild} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {HttpParams} from '@angular/common/http';
import {NgForm} from '@angular/forms';
import {FileFormat} from '../enums';

@Component({
    selector: 'app-entity-document-upload',
    templateUrl: './entity-document-upload.component.html'
})
export class EntityDocumentUploadComponent extends BaseEdit implements OnInit {
    @ViewChild('form', {static: true}) form: NgForm;
    @Input()
    appEntityId: number;
    @Input()
    objectId: number;
    docCategoryId: number;
    docTypes: any[];
    docs: any[];
    value: any[] = [];

    get fileFormat() {
        return FileFormat;
    }

    constructor(private genericDataService: GenericDataService) {
        super(genericDataService);
        this.entityName = 'appDocument';
    }

    ngOnInit() {
        super.ngOnInit();
        this.getEntityObjectDocs();
    }

    updateClick() {

    }

    addDoc(docType: any) {
        this.docs.push({
            docTypeId: docType.id,
            appEntityId: this.appEntityId,
            objectId: this.objectId,
            docTypeTitle: docType.title,
            docType: docType
        })
    }

    selectedDocumentCategoryChanged(item: any) {
        this.docCategoryId = item.id;
        this.getEntityObjectDocs();
    }

    private getEntityObjectDocs() {
        if (!this.docCategoryId) {
            this.docCategoryId = 0;
        }
        const param = new HttpParams().set('entityId', this.appEntityId.toString()).set('objectId', this.objectId.toString()).set('docCategoryId', this.docCategoryId.toString());
        this.genericDataService.getEntitiesWithAction('appDocument', 'GetObjectDocuments', param).subscribe((data: any) => {
            for (const docType of data.docTypes) {
                const docs = data.docs.filter(x => x.docTypeId === docType.id);
                if (docs.length === 0) {
                    data.docs.push({
                        docTypeId: docType.id,
                        appEntityId: this.appEntityId,
                        objectId: this.objectId,
                        docTypeTitle: docType.title,
                        docType: docType
                    });
                } else {
                    for (const doc of docs) {
                        doc.docType = docType;
                    }
                }
            }
            this.docTypes = data.docTypes;
            this.docs = data.docs;
        });
    }
}
