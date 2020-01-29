import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';


@Component({
    selector: 'app-user-detail',
    templateUrl: './user-detail.component.html'
})
export class UserDetailComponent extends BaseEdit implements OnInit {
    organizationDataSource: any;
    accessLevelDataSource: any;

    constructor(private genericDataService: GenericDataService) {
        super(genericDataService);
        this.entityName = 'user';
        this.validateUserName = this.validateUserName.bind(this);
        this.validateNationalCode = this.validateNationalCode.bind(this);
    }

    passwordComparison = () => {
        return this.entity.passwordStr;
    };

    ngOnInit() {
        super.ngOnInit();
        this.organizationDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'organization');
        this.accessLevelDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'accessLevel');
    }

    validateUserName(params) {
        this.genericDataService.getEntitiesWithAction('user', 'CheckUserName?userName=' + params.value, null)
            .subscribe(response => {
                params.rule.isValid = !response;
                params.validator.validate();
            });
        return false;
    }

    validateNationalCode(params) {
        this.genericDataService.getEntitiesWithAction('user', 'CheckNationalCode?nationalCode=' + params.value, null)
            .subscribe(response => {
                params.rule.isValid = response;
                params.validator.validate();
            });
        return false;
    }
}
