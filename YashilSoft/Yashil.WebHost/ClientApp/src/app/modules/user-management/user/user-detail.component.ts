import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {UserExtenderService} from '../../../shared/services/user-extender.service';


@Component({
    selector: 'app-user-detail',
    templateUrl: './user-detail.component.html',
    styleUrls: ['./user-detail.component.css']
})
export class UserDetailComponent extends BaseEdit implements OnInit {
    items: any[] = [];
    organizationDataSource: any;
    accessLevelDataSource: any;

    constructor(private genericDataService: GenericDataService, private userExtender: UserExtenderService) {
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
        if (!this.selectedEntityId) {
            this.entity.additionalInfoList = [0, 0];
            this.entity.isActive = true;
            this.userExtender.setEntity(this.entity, true);
        }
        this.organizationDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'organization');
        this.accessLevelDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'accessLevel');
        const uiItems = [
            {
                name: 'uName',
                dataField: 'userName',
                cssClass: 'dispNone'
            },
            {
                name: 'pssRe',
                dataField: 'Pass',
                cssClass: 'dispNone',
                editorOptions: {
                    mode: 'password'
                }
            },
            {
                name: 'userName',
                label: {
                    text: 'نام کاربری'
                },
                dataField: 'userName',
                editorOptions: {disabled: this.entity.id},
                validationRules: [{
                    type: 'required',
                    message: 'نام کاربری اجباری می باشد'
                }, {
                    type: 'async',
                    message: 'این نام کاربری قبلا ثبت شده است!',
                    validationCallback: this.validateUserName
                }]
            }, {
                name: 'nationalCode',
                label: {
                    text: 'کد ملی'
                },
                dataField: 'nationalCode',
                editorOptions: {disabled: this.entity.id},
                validationRules: [{
                    type: 'required',
                    message: 'کد ملی اجباری می باشد'
                }, {
                    type: 'stringLength',
                    min: 10,
                    max: 10,
                    message: 'طول کد ملی باید 10 کاراکتر باشد'
                }, {
                    type: 'custom',
                    message: 'فرمت کد ملی صحیح نیست',
                    validationCallback: this.nationalCodeValidate,
                }, {
                    type: 'async',
                    message: 'این کد ملی قبلا ثبت شده است!',
                    validationCallback: this.validateNationalCode
                }]
            },
            {
                label: {
                    text: 'نام'
                },
                dataField: 'firstName',
                validationRules: [{
                    type: 'required',
                    message: 'نام اجباری می باشد'
                }]
            },
            {
                label: {
                    text: 'نام خانوادگی'
                },
                dataField: 'lastName',
                validationRules: [{
                    type: 'required',
                    message: 'نام خانوادگی اجباری می باشد'
                }]
            },
            {
                name: 'passwordStr',
                label: {
                    text: 'کلمه عبور'
                },
                dataField: 'passwordStr',
                editorOptions: {
                    mode: 'password'
                },
                validationRules: [{
                    type: 'required',
                    message: 'کلمه عبور اجباری می باشد'
                }]
            },
            {
                name: 'rePasswordStr',
                label: {
                    text: 'تکرار کلمه عبور'
                },
                editorType: 'dxTextBox',
                editorOptions: {
                    mode: 'password'
                },
                validationRules: [{
                    type: 'required',
                    message: 'تکرار کلمه عبور اجباری می باشد'
                }, {
                    type: 'compare',
                    message: 'تکرار کلمه عبور صحیح نیست',
                    comparisonTarget: this.passwordComparison
                }]
            },
            {
                name: 'organizationId',
                label: {
                    text: 'سازمان'
                },
                dataField: 'organizationId',
                editorType: 'dxLookup',
                editorOptions: {
                    rtlEnabled: true,
                    closeOnOutsideClick: true,
                    showPopupTitle: false,
                    dataSource: this.organizationDataSource,
                    displayExpr: 'title',
                    valueExpr: 'id'
                }
            },
            {
                label: {
                    text: 'ایمیل'
                },
                dataField: 'email',
                validationRules: [{
                    type: 'email',
                    message: 'فرمت آدرس  ایمیل ورودی صحیح نیست'
                }]
            },
            {
                label: {
                    text: 'شماره موبایل'
                },
                dataField: 'mobileNumber',
                editorOptions: {
                    mask: '\\0\\900 0000000'
                },
                cssClass: 'text-align-left'
            },
            {
                label: {
                    text: 'آدرس'
                },
                dataField: 'address',
                editorType: 'dxTextArea'
            },
            {
                label: {
                    text: 'فعال'
                },
                dataField: 'isActive',
                editorType: 'dxCheckBox'
            },
        ];
        if (this.selectedEntityId) {
            const userName = uiItems.filter(x => x.name === 'userName')[0];
            userName.validationRules = null;
            userName.editorOptions['readOnly'] = true;
            const nationalCode = uiItems.filter(x => x.name === 'nationalCode')[0];
            nationalCode.validationRules = null;
            nationalCode.editorOptions['readOnly'] = true;
            uiItems.filter(x => x.name === 'passwordStr')[0].validationRules = null;
            uiItems.filter(x => x.name === 'rePasswordStr')[0].validationRules = null;
        }
        this.items = this.userExtender.extend(this.detailForm, uiItems);
    }

    validateUserName(params) {
        return this.genericDataService.getEntitiesWithAction('user', 'CheckUserName?userName=' + params.value, null).toPromise();
    }

    validateNationalCode(params) {
        return this.genericDataService.getEntitiesWithAction('user', 'CheckNationalCode?nationalCode=' + params.value, null).toPromise();

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

    parseInt(val: any) {
        return +val;
    }

    afterLoadData(res: any): any {
        if (!this.selectedEntityId) {
            this.entity.isActive = true;
        }
        this.userExtender.setEntity(this.entity);
        return super.afterLoadData(res);
    }
}
