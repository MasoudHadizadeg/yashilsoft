import {Component, Input, OnInit, ViewChild} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {createStore} from 'devextreme-aspnet-data-nojquery';
import ArrayStore from 'devextreme/data/array_store';
import {HttpParams} from '@angular/common/http';
import {NgForm} from '@angular/forms';

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
    docTypeDataSource: any;
    documentCategoryDataSource: any;
    docTypes: any[];
    docs: any[];
    value: any[] = [];

    constructor(private genericDataService: GenericDataService) {
        super(genericDataService);
        this.entityName = 'appDocument';
    }

    ngOnInit() {
        super.ngOnInit();
        const param = new HttpParams().set('entityId', this.appEntityId.toString()).set('ObjectId', this.objectId.toString());
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

    updateClick() {

    }
}
