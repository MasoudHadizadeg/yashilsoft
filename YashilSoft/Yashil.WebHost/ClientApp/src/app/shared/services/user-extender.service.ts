import {Injectable} from '@angular/core';
import {GenericDataService} from '../base/services/generic-data.service';
import {DxFormComponent} from 'devextreme-angular/ui/form';

@Injectable({
    providedIn: 'root'
})
export class UserExtenderService {
    representationDataSource: any;
    educationalCenterDataSource: any;
    _detailForm: DxFormComponent;
    _entity: any = {};
    /**
     * set true only on edit form
     */
    firstLoad = false;

    constructor(private genericDataService: GenericDataService) {
        this.selectedEducationalCenterChanged = this.selectedEducationalCenterChanged.bind(this);
    }

    /**
     * Call This Method Only On Edit Form
     * @param entity
     */
    setEntity(entity, isNew = false) {
        this._entity = entity;
        if (!isNew) {
            if (this._entity.additionalInfoList && this._entity.additionalInfoList[1]) {
                this.firstLoad = true;
            }
            this.bindDataSources(entity.additionalInfoList[0]);
        }
    }

    extend(detailForm: DxFormComponent, userEditFormItems: any[]) {
        this._detailForm = detailForm;
        this.educationalCenterDataSource = this.genericDataService.createCustomDatasourceForSelect('id', 'educationalCenter');
        userEditFormItems.splice(6, 0, {
            name: 'representationId',
            label: {
                text: 'نمایندگی'
            },
            dataField: 'additionalInfoList[1]',
            editorType: 'dxLookup',
            showClearButton: true,
            editorOptions: {
                rtlEnabled: true,
                closeOnOutsideClick: true,
                showPopupTitle: false,
                displayExpr: 'title',
                valueExpr: 'id'
            }
        });
        userEditFormItems.splice(6, 0,
            {
                name: 'educationalCenterId',
                label: {
                    text: 'مرکز آموزشی'
                },
                dataField: 'additionalInfoList[0]',
                editorType: 'dxLookup',
                editorOptions: {
                    rtlEnabled: true,
                    closeOnOutsideClick: true,
                    showPopupTitle: false,
                    dataSource: this.educationalCenterDataSource,
                    onSelectionChanged: this.selectedEducationalCenterChanged,
                    displayExpr: 'title',
                    valueExpr: 'id'
                }
            });
        userEditFormItems = userEditFormItems.filter(x => x.name !== 'organizationId');
        return userEditFormItems;
    }

    private selectedEducationalCenterChanged(e: any) {
        if (e && e.selectedItem) {
            this._detailForm.instance.getEditor('representationId').option('disabled', false);
            if (!this.firstLoad && this._entity) {
                this._detailForm.instance.getEditor('representationId').reset();
                this.bindDataSources(e.selectedItem.id);
            }
            this.firstLoad = false;
        }
    }

    private bindDataSources(educationalCenterId) {
        if (educationalCenterId) {
            this.representationDataSource =
                this.genericDataService.createCustomDatasourceWithAction('id', 'representation', `GetByEducationalCenter?educationalCenterId=${educationalCenterId}`);
        } else {
            this.representationDataSource = null;
        }
        this._detailForm.instance.getEditor('representationId').option('dataSource', this.representationDataSource);
    }
}
