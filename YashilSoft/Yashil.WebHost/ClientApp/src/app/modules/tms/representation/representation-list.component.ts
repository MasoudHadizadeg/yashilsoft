import {Component, Input, OnInit, ViewChild} from '@angular/core';
import {RepresentationDetailTabBasedComponent} from './representation-detail-tab-based.component';
import {Selectable} from '../../../shared/base/classes/selectable';
import {BaseList} from '../../../shared/base/classes/base-list';
import {CachedKey} from '../tms-enums';
import {CachedDataService} from '../../../shared/services/cached-data.service';


@Component({
    selector: 'app-representation-list',
    templateUrl: './representation-list.component.html'
})
export class RepresentationListComponent extends Selectable implements OnInit {
    @ViewChild('frmRep', {static: true}) frmRep: BaseList;
    private _educationalCenterId: number;
    @Input()
    hideEducationalCenterColumn = false;
    representationId: number;
    @Input()
    set educationalCenterId(value: number) {
        if (this._educationalCenterId !== value) {
            this.loadAfterSetFilter = true;
            this._educationalCenterId = value;
            this.frmRep.customListUrl = `${this.baseListUrl}${this._educationalCenterId}`;
            this.frmRep.refreshList();
        }
    }

    get educationalCenterId(): number {
        return this._educationalCenterId;
    }

    loadAfterSetFilter: boolean;
    selectedItemId: number;
    columns: any[] = [];
    entityName = 'representation';
    detailComponent = RepresentationDetailTabBasedComponent;
    customListUrl: string;
    baseListUrl = 'representation/GetByEducationalCenterIdForList?educationalCenterId=';

    constructor(private cachedDataService: CachedDataService) {
        super();
    }

    setEducationalCenterId() {
    }

    afterInitialDetailComponent(componentInstance: any) {
        (<RepresentationDetailTabBasedComponent>componentInstance.instance).educationalCenterId = this.educationalCenterId;
    }

    ngOnInit(): void {
        const data = this.cachedDataService.getData(CachedKey.AdditionalUserProp);
        if (data) {
            if (data.educationalCenterId) {
                this.educationalCenterId = data.educationalCenterId;
            }
            if (data.representationId) {
                this.representationId = data.representationId;
            }
        }
        if (this.educationalCenterId) {
            this.loadAfterSetFilter = true;
        }
        this.columns.push({
            caption: 'عنوان',
            dataField: 'title',
            width: '50%'
        });
        if (!this.hideEducationalCenterColumn) {
            this.columns.push({
                caption: 'مرکز آموشي',
                dataField: 'educationalCenterTitle',
                groupIndex: 1
            });
        }
        this.columns.push({
            caption: 'شهر',
            dataField: 'cityTitle'
        });
    }
}
