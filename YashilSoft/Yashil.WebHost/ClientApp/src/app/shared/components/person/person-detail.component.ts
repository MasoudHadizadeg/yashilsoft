import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';


@Component({
    selector: 'app-person-detail',
    templateUrl: './person-detail.component.html'
})
export class PersonDetailComponent extends BaseEdit implements OnInit {
    genders: any;
    educationGrades: any;
    accessLevels: any[] = [];

    constructor(private genericDataService: GenericDataService) {
        super(genericDataService);
        this.entityName = 'person';
        this.validateNationalCode = this.validateNationalCode.bind(this);
    }

    ngOnInit() {
        super.ngOnInit();
        this._genericDataService.getCommonBaseDataForSelect('Gender').subscribe(res => this.genders = res);
        this._genericDataService.getCommonBaseDataForSelect('EducationGrade').subscribe(res => this.educationGrades = res);
        this._genericDataService.getEntitiesByEntityNameForSelect(Entity.AccessLevel).subscribe(res => this.accessLevels = res);
    }

    nationalCodeValidate(param) {
        const nationalCode = param.value;
        if (nationalCode.length === 10) {
            if (nationalCode === '1111111111' ||
                nationalCode === '2222222222' ||
                nationalCode === '3333333333' ||
                nationalCode === '4444444444' ||
                nationalCode === '5555555555' ||
                nationalCode === '6666666666' ||
                nationalCode === '7777777777' ||
                nationalCode === '8888888888' ||
                nationalCode === '9999999999') {
                return false;
            } else {

                const num0 = (+nationalCode.charAt(0)) * 10;
                const num2 = (+nationalCode.charAt(1)) * 9;
                const num3 = (+nationalCode.charAt(2)) * 8;
                const num4 = (+nationalCode.charAt(3)) * 7;
                const num5 = (+nationalCode.charAt(4)) * 6;
                const num6 = (+nationalCode.charAt(5)) * 5;
                const num7 = (+nationalCode.charAt(6)) * 4;
                const num8 = (+nationalCode.charAt(7)) * 3;
                const num9 = (+nationalCode.charAt(8)) * 2;
                const a = (+nationalCode.charAt(9));

                const b = num0 + num2 + num3 + num4 + num5 + num6 + num7 + num8 + num9;
                const c = b % 11;

                return c < 2 && a === c || c >= 2 && 11 - c === a;
            }
        }
    }

    validateNationalCode(params) {
        const actionName = this.selectedEntityId ? 'CheckNationalCode?nationalCode=' + params.value + '&personId=' + this.selectedEntityId : 'CheckNationalCode?nationalCode=' + params.value;
        return this.genericDataService.getEntitiesWithAction('person', actionName, null).toPromise();
    }
}
