import {Selectable} from '../../../shared/base/classes/selectable';
import {BaseList} from '../../../shared/base/classes/base-list';
import {Component, Input, OnInit, ViewChild} from '@angular/core';
import {PersonBankAccountDetailComponent} from './person-bank-account-detail.component';


@Component({
    selector: 'app-person-bank-account-list',
    templateUrl: './person-bank-account-list.component.html'
})
export class PersonBankAccountListComponent extends Selectable implements OnInit {
    @Input()
    representationId: number;
    @ViewChild('listForm', {static: true}) listForm: BaseList;
    loadAfterSetFilter: boolean;
    selectedItemId: number;
    columns: any[] = [];
    entityName = 'personBankAccount';
    detailComponent = PersonBankAccountDetailComponent;
    _personId: number;
    @Input()
    set personId(val) {
        if (val !== this._personId) {
            this._personId = val;
        }
    }

    get personId(): number {
        return this._personId;
    }

    _bankType: number;
    @Input()
    set bankType(val) {
        if (val !== this._bankType) {
            this._bankType = val;
        }
    }

    get bankType(): number {
        return this._bankType;
    }

    _accessLevelId: number;
    @Input()
    set accessLevelId(val) {
        if (val !== this._accessLevelId) {
            this._accessLevelId = val;
        }
    }

    get accessLevelId(): number {
        return this._accessLevelId;
    }

    private baseListUrl = 'personBankAccount/GetByCustomFilterForList?';

    constructor() {
        super();
        this.columns.push({
            caption: 'شخص',
            dataField: 'personTitle'
        });
        this.columns.push({
            caption: 'کد ملی',
            dataField: 'nationalCode'
        });
        this.columns.push({
            caption: 'بانک',
            dataField: 'bankTypeTitle'
        });
        this.columns.push({
            caption: 'شعبه',
            dataField: 'branchName'
        });
        this.columns.push({
            caption: 'شماره کارت',
            dataField: 'cardNumber'
        });
        this.columns.push({
            caption: 'شماره حساب',
            dataField: 'accountNumber'
        });
        this.columns.push({
            caption: 'شماره شبا',
            dataField: 'shabaNumber'
        });

    }

    ngOnInit(): void {
        if (this.bindCustomDataSources()) {
            this.loadAfterSetFilter = true;
        }
    }

    private bindCustomDataSources() {
        let customListUrl = `${this.baseListUrl}`;
        if (this.listForm) {
            if (this.personId) {
                customListUrl += `personId=${this.personId}&`;
            }
            if (this.bankType) {
                customListUrl += `bankType=${this.bankType}&`;
            }
            if (this.accessLevelId) {
                customListUrl += `accessLevelId=${this.accessLevelId}&`;
            }
            if (this.representationId) {
                customListUrl += `representationId=${this.representationId}&`;
            }
        }
        let res = false;
        if (this.personId || this.bankType || this.accessLevelId) {
            this.listForm.customListUrl = customListUrl;
            this.listForm.refreshList();
            res = true;
        }
        return res;
    }

    afterInitialDetailComponent(componentInstance: any) {
        const comp = (<PersonBankAccountDetailComponent>componentInstance.instance);

        if (this.personId) {
            comp.personId = this.personId;
        }

        if (this.bankType) {
            comp.bankType = this.bankType;
        }

        if (this.accessLevelId) {
            comp.accessLevelId = this.accessLevelId;
        }

    }
}
