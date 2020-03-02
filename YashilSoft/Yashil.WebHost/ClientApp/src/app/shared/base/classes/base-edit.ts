import * as moment from 'jalali-moment';
import {Input, OnInit, Output, ViewChild} from '@angular/core';
import {GenericDataService} from '../services/generic-data.service';
import {DxFormComponent} from 'devextreme-angular/ui/form';
import notify from 'devextreme/ui/notify';
import {catchError} from 'rxjs/operators';
import {BaseEditFormComponent} from '../base-edit-form/base-edit-form.component';
import {Editable} from './editable';

export class BaseEdit extends Editable implements OnInit {
    // tslint:disable-next-line:variable-name
    _genericDataService: GenericDataService;
    closeAfterSave = true;
    // tslint:disable-next-line:variable-name
    _entityParentId: number;
    keyExpr: string;
    displayExpr: string;
    parentIdExpr: string;

    @Input()
    public set entityParentId(value: number) {
        this._entityParentId = value;
        this.entity.parentId = this._entityParentId;
    }

    public get entityParentId() {
        return this._entityParentId;
    }

    buttonOptions: any = {
        text: 'Register',
        type: 'success',
        useSubmitBehavior: true
    };
    public datePickerConfig = {
        format: 'jYYYY/jMM/jDD',
        dir: 'rtl',
        locale: moment.locale('fa')
    };

    private dataFilters: any = [];

    @Input()
    public set filters(val: any[]) {
        this.dataFilters = val;
        if (this.isNew) {
            this.applyFilter();
        }
    }

    public get filters(): any[] {
        return this.dataFilters;
    }

    entity: any = {};

    @ViewChild(DxFormComponent, {static: true}) detailForm: DxFormComponent
    @ViewChild(BaseEditFormComponent, {static: true}) baseEditFormComponent: BaseEditFormComponent

    public onCloseFormClick(e) {
        this.closeFormClick.next(true);
    }

    constructor(genericDataService: GenericDataService) {
        super();
        this._genericDataService = genericDataService;
    }

    public convertDateToInt(p: moment.Moment) {
        if (p) {
            return +p.locale('fa').format('YYYYMMDD');
        }
        return null;
    }

    public convertDateToString(p: moment.Moment) {
        if (p) {
            return p.locale('fa').format('YYYY/MM/DD');
        }
        return null;
    }

    public setParentId(parentId: number) {
    }

    doBeforeSubmit(e) {
    }

    public formSubmit(e) {
        this.baseEditFormComponent.allowSave = false;
        let errorMsg = 'بروز خطا در ذخیره سازی';
        this.doBeforeSubmit(e);
        if (this.detailForm && this.detailForm.instance) {
            try {
                const result = this.detailForm.instance.validate();
                if (result && !result.isValid) {
                    e.preventDefault();
                    return;
                }
            } catch (e) {
            } finally {
                this.baseEditFormComponent.allowSave = true;
            }
        }
        if (this.entity.id) {
            this._genericDataService.updateEntity(this.entityName, this.entity).pipe(catchError(err => {
                if (err && err.error !== '' && (typeof err.error) === 'string') {
                    errorMsg = err.error;
                }
                notify({
                    message: errorMsg,
                    position: {
                        my: 'center top',
                        at: 'center top'
                    }
                }, 'error', 3000);
                this.baseEditFormComponent.allowSave = true;
                return '';
            })).subscribe(
                msg => {
                    notify({
                        message: 'تغییرات  با موفقیت ذخیره شد',
                        position: {
                            my: 'center top',
                            at: 'center top'
                        }
                    }, 'success', 3000);
                    this.afterSave();
                    this.closeForm();
                });
        } else {
            this._genericDataService.addEntity(this.entityName, this.entity).pipe(catchError(err => {
                if (err && err.error !== '') {
                    errorMsg = err.error;
                }
                notify({
                    message: errorMsg,
                    position: {
                        my: 'center top',
                        at: 'center top'
                    }
                }, 'error', 3000);
                return '';
            })).subscribe(
                msg => {
                    notify({
                        message: 'ذخیره سازی با موفقیت انجام شد',
                        position: {
                            my: 'center top',
                            at: 'center top'
                        }
                    }, 'success', 3000);
                    // this.baseEditFormComponent.allowSave = true;
                    this.afterSave();
                    this.closeForm();
                }
            );
        }
    }

    afterSave() {
    }

    private closeForm() {
        this.selectedEntityId = null;
        if (this.closeAfterSave) {
            this.closeFormClick.emit(true);
        }
    }

    ngOnInit(): void {
        this.loadEntityData()
    }

    public afterLoadData(res: any): any {
    }

    public loadEntityData() {
        if (this.selectedEntityId && !this.isNew) {
            this._genericDataService.getEntity(this.entityName, this.selectedEntityId).subscribe(
                res => {
                    this.entity = res;
                    this.afterLoadData(res);
                }
            );
        } else {
            if (this.entityParentId) {
                this.entity[this.parentIdExpr] = this.entityParentId;
            }
            this.applyFilter();
        }
    }

    applyFilter() {
        let i = 0;
        for (const item of this.filters) {
            this.entity[item[0]] = item[1];
            i++;
        }
        // for (let i = 0; i < this.filters.length; i++) {
        //     const item = this.filters[i];
        //     this.entity[item[0]] = item[1];
        // }
    }
}
