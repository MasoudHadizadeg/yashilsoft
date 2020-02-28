import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {BaseEdit} from '../../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../../shared/base/services/generic-data.service';
import {DomSanitizer} from '@angular/platform-browser';


@Component({
    selector: 'app-simple-image-uploader',
    templateUrl: './simple-image-uploader.component.html'
})
export class SimpleImageUploaderComponent extends BaseEdit implements OnInit {
    imgBase64: any;
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

    constructor(private genericDataService: GenericDataService, private sanitizer: DomSanitizer) {
        super(genericDataService);
        this.entityName = 'reportStore';
        this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
        this.authorizationHeader = {
            Authorization: `Bearer ${this.currentUser.token}`
        };
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
    }

    afterLoadData(res: any): any {
        if (res.picture) {
            this.imgBase64 = this.sanitizer.bypassSecurityTrustResourceUrl(atob(res.picture));
        }
    }

    showImage(files) {
        const that = this;
        if (files && files[0]) {
            const reader = new FileReader();
            reader.onload = function (e) {
                that.imgBase64 = that.sanitizer.bypassSecurityTrustResourceUrl(e.target['result']);
                that.entity.picture = btoa(e.target['result']);
            }
            reader.readAsDataURL(files[0]);
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

    addFile() {
        this.addDocEvent.next(this.doc.docType);
    }
}
