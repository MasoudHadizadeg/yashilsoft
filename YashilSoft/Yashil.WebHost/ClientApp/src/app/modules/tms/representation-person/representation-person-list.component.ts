import {Component, Input, OnInit, ViewChild} from '@angular/core';
import {RepresentationPersonDetailComponent} from './representation-person-detail.component';
import {CachedKey} from '../tms-enums';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {CachedDataService} from '../../../shared/services/cached-data.service';
import {BaseList} from '../../../shared/base/classes/base-list';


@Component({
    selector: 'app-representation-person-list',
    templateUrl: './representation-person-list.component.html'
})
export class RepresentationPersonListComponent implements OnInit {
    @ViewChild('frmRP', {static: true}) frmRP: BaseList;
    additionalUserProp: any;
    contentHeight: number;
    @Input()
    postId: number;
    selectedItemId: number;
    columns: any[] = [];
    entityName = 'representationPerson';
    detailComponent = RepresentationPersonDetailComponent;
    educationalCenterDataSource: any;
    private _educationalCenterId: number;
    baseListUrl = 'representationPerson/GetByRepresentationIdForList?representationId=';
    private representationId: number | any;

    @Input()
    set educationalCenterId(value: number) {
        if (this._educationalCenterId !== value) {
            this._educationalCenterId = value;
        }
    }

    get educationalCenterId(): number {
        return this._educationalCenterId;
    }

    constructor(private genericDataService: GenericDataService, private cachedDataService: CachedDataService) {
        this.contentHeight = window.innerHeight - 110;
    }

    ngOnInit(): void {
        this.additionalUserProp = this.cachedDataService.getData(CachedKey.AdditionalUserProp);
        if (this.additionalUserProp) {
            if (this.additionalUserProp.educationalCenterId) {
                this.educationalCenterId = this.additionalUserProp.educationalCenterId;
            }
            if (this.additionalUserProp.representationId) {
                this.representationId = this.additionalUserProp.representationId;
                this.bindList(this.representationId);
            }
        }
        this.bindColumns();
    }

    bindColumns() {
        if (!this.representationId) {
            this.columns.push({
                caption: 'نمایندگی',
                dataField: 'representationTitle'
            });
        }
        this.columns.push({
            caption: 'نام و نام خانوادگی',
            dataField: 'personTitle',
            width: '40%'
        });
        this.columns.push({
            caption: 'سمت',
            dataField: 'postTitle'
        });
        this.columns.push({
            caption: 'نوع همکاری',
            dataField: 'cooperationTypeTitle'
        });
        this.columns.push({
            caption: 'تاریخ جذب',
            dataField: 'fromDate',
            cellTemplate: 'intDate'
        });
        this.columns.push({
            caption: 'تاریخ رهایی',
            dataField: 'toDate',
            cellTemplate: 'intDate'
        });

    }

    onSelectedRepresentationChanged(item: any) {
        this.representationId = item.representation.id;
        this.bindList(this.representationId);
    }

    bindList(representationId) {
        this.frmRP.customListUrl = `${this.baseListUrl}${representationId}`;
        this.frmRP.refreshList();
    }

    afterInitialDetailComponent(componentInstance: any) {
        const comp = (<RepresentationPersonDetailComponent>componentInstance);
        if (this.representationId) {
            comp.representationId = this.representationId;
        }
    }
}
