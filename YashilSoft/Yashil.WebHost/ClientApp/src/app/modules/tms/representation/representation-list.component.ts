import {Component, Input, OnInit, ViewChild} from '@angular/core';
import {RepresentationDetailTabBasedComponent} from './representation-detail-tab-based.component';
import {Selectable} from '../../../shared/base/classes/selectable';
import {BaseList} from '../../../shared/base/classes/base-list';


@Component({
    selector: 'app-representation-list',
    templateUrl: './representation-list.component.html'
})
export class RepresentationListComponent extends Selectable implements OnInit {
    @ViewChild('frmRep', {static: true}) frmRep: BaseList;
    private _educationalCenterId: number;
    @Input()
    hideEducationalCenterColumn = false;

    @Input()
    set educationalCenterId(value: number) {
        if (this._educationalCenterId !== value) {
            this._educationalCenterId = value;
            this.frmRep.customListUrl = `${this.baseListUrl}${this._educationalCenterId}`;
            this.frmRep.refreshList();
        }
    }

    get educationalCenterId(): number {
        return this._educationalCenterId;
    }

    selectedItemId: number;
    columns: any[] = [];
    entityName = 'representation';
    detailComponent = RepresentationDetailTabBasedComponent;
    customListUrl: string;
    baseListUrl = 'representation/GetByEducationalCenterIdForList?educationalCenterId=';

    constructor() {
        super();
    }

    setEducationalCenterId() {
    }

    afterInitialDetailComponent(componentInstance: any) {
        (<RepresentationDetailTabBasedComponent>componentInstance).educationalCenterId = this.educationalCenterId;
    }

    ngOnInit(): void {
        this.columns.push({
            caption: 'عنوان',
            dataField: 'title'
        });
        if (!this.hideEducationalCenterColumn) {
            this.columns.push({
                caption: 'مرکز آموشي',
                dataField: 'educationalCenterTitle'
            });
        }
        this.columns.push({
            caption: 'شهر',
            dataField: 'cityTitle'
        });
        this.columns.push({
            caption: 'نوع مدرک',
            dataField: 'licenseTypeTitle'
        });
        this.columns.push({
            caption: 'نوع مجوز تاسیس',
            dataField: 'establishedLicenseTypeTitle'
        });
    }
}
