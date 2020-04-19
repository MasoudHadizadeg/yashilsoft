import {Component, Input, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {FileFormat} from '../enums';


@Component({
    selector: 'app-doc-type-detail',
    templateUrl: './doc-type-detail.component.html'
})
export class DocTypeDetailComponent extends BaseEdit implements OnInit {
    @Input()
    appEntityId;
    appEntityDataSource: any;
    docFormatDataSource: any;
    documentCategories: any;
    firstLoad = false;

    get fileFormat() {
        return FileFormat;
    }

    constructor(private genericDataService: GenericDataService) {
        super(genericDataService);
        this.entityName = 'docType';
        this.selectedDocTypeChange = this.selectedDocTypeChange.bind(this);
        this.selectedAppEntityChanged = this.selectedAppEntityChanged.bind(this);
    }

    ngOnInit() {
        super.ngOnInit();
        if (this.selectedEntityId) {
            this.firstLoad = true;
        }
        if (this.appEntityId) {
            this.bindDataSources(this.appEntityId);
        }
        this.appEntityDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'appEntity');
        this.docFormatDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'docFormat');
    }

    loadEntityData() {
        if (!this.entity.id) {
            this.entity.maxCount = 1;
            this.entity.maxSize = 1024;
        }
        super.loadEntityData();
    }

    selectedDocTypeChange(e: any) {
        if (e.value === FileFormat.Picture) {
            this.entity.isImage = true;
        } else {
            this.entity.isImage = false;
        }
    }

    selectedAppEntityChanged(e) {
        if (e && e.selectedItem) {
            if (!this.firstLoad) {
                this.entity.documentCategoryId = null;
            }
            this.bindDataSources(e.selectedItem.id);
            this.firstLoad = false;
        }
    }

    private bindDataSources(id: any) {
        this._genericDataService.getEntitiesByEntityName(`documentCategory/GetEntitiesByAppEntityId?appEntityId=${id}`)
            .subscribe(res =>
                this.documentCategories = res
            );
    }
}
