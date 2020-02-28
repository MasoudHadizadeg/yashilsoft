import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {BaseEdit} from '../../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../../shared/base/services/generic-data.service';
import {DomSanitizer} from '@angular/platform-browser';
import {PDFSource} from 'pdfjs-dist';
import {Router} from '@angular/router';

@Component({
    selector: 'app-pdf-uploader',
    templateUrl: './simple-pdf-uploader.component.html'
})
export class SimplePdfUploaderComponent extends BaseEdit implements OnInit {
    localPdfFileSource: any;
    showLargImage: boolean;
    @Input()
    doc: any = {};
    @Input()
    docCategoryId: number;
    @Output()
    addDocEvent = new EventEmitter<any>();

    currentUser: any;
    authorizationHeader: any;
    uploadUri: string;
    pdfSource: PDFSource;

    constructor(private genericDataService: GenericDataService, private router: Router) {
        super(genericDataService);
        this.entityName = 'reportStore';
        this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
        this.authorizationHeader = {
            Authorization: `Bearer ${this.currentUser.token}`
        };
    }

    showPdf(files) {
        const that = this;
        if (files && files[0]) {
            const reader = new FileReader();
            reader.onload = function (e: any) {
                that.pdfSource = e.target.result;
            }
            reader.readAsArrayBuffer(files[0]);
        }
    }

    // (int? docCategoryId, int appEntityId, int docTypeId, int? docId, int objectId)
    ngOnInit() {
        super.ngOnInit();
        this.showLargImage = false;
        this.uploadUri = 'api/AppDocument/UploadFile';
        if (this.docCategoryId) {
            this.updateQueryStringParameter('docCategoryId', this.docCategoryId);
        }
        if (this.doc.id) {
            this.updateQueryStringParameter('docId', this.doc.id);
        }
        this.updateQueryStringParameter('appEntityId', this.doc.docType.appEntityId);
        this.updateQueryStringParameter('docTypeId', this.doc.docType.id);
        this.updateQueryStringParameter('objectId', this.doc.objectId);
        if (this.doc && this.doc.id) {
            this.pdfSource = {
                url: `${window.location.origin}/api/appDocument/GetFile?appDocumentId=${this.doc.id}`,
                withCredentials: true,
                httpHeaders: this.authorizationHeader
            };
        }
    }

    updateQueryStringParameter(key, value) {
        const re = new RegExp('([?&])' + key + '=.*?(&|$)', 'i');
        const separator = this.uploadUri.indexOf('?') !== -1 ? '&' : '?';
        if (this.uploadUri.match(re)) {
            return this.uploadUri.replace(re, '$1' + key + '=' + value + '$2');
        } else {
            this.uploadUri = this.uploadUri + separator + key + '=' + value;
        }
    }

    uploadStarted(param: any) {
        console.log(param);
    }
}
