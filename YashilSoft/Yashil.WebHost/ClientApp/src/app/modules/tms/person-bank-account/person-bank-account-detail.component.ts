import {Component, Input, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';


@Component({
    selector: 'app-person-bank-account-detail',
    templateUrl: './person-bank-account-detail.component.html'
})
export class PersonBankAccountDetailComponent extends BaseEdit implements OnInit {
    @Input()
    personId: number;
    @Input()
    bankType: number;
    @Input()
    accessLevelId: number;
    personDataSource: any;
    bankTypes: any;
    accessLevels: any[] = [];

    constructor(private genericDataService: GenericDataService) {
        super(genericDataService);
        this.entityName = 'personBankAccount';
    }

    ngOnInit() {
        super.ngOnInit();
        if (this.personId) {
            this.entity.personId = this.personId;
        }
        if (this.bankType) {
            this.entity.bankType = this.bankType;
        }
        if (this.accessLevelId) {
            this.entity.accessLevelId = this.accessLevelId;
        }

        this.personDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'person');
        this._genericDataService.getCommonBaseDataForSelect('BankType').subscribe(res => this.bankTypes = res);
        this._genericDataService.getEntitiesByEntityNameForSelect(Entity.AccessLevel).subscribe(res => this.accessLevels = res);
    }

    selectedPersonChanged(selectedPersonId: any) {
        this.entity.personId = selectedPersonId;
    }
}
