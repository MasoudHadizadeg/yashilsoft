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
        this.validateLogin = this.validateLogin.bind(this);
    }

    passwordComparison = () => {
        return this.entity.passwordStr;
    };
    ngOnInit() {
        super.ngOnInit();
        this.organizationDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'organization');
        this.accessLevelDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'accessLevel');
    }
    validateLogin(params) {
        this.genericDataService.getEntitiesWithAction('user', 'CheckUserName?userName=' + params.value, null)
            .subscribe(response => {
                params.rule.isValid = !response;
                params.validator.validate();
            });
        return false;
    }
}
