			
		import { Component, OnInit } from '@angular/core';
		import {UserDetailComponent} from './user-detail.component';
		@Component({
		  selector: 'app-user-list',
		  templateUrl: './user-list.component.html'
		})
		export class UserListComponent {
		  selectedItemId: number;
		  columns: any[] = [];
		  entityName = 'user';
		  detailComponent = UserDetailComponent;
		  constructor() {
							this.columns.push({ 
					caption: 'نام کاربری',
					dataField: 'userName'
					});
							this.columns.push({ 
					caption: 'نام',
					dataField: 'firstName'
					});
							this.columns.push({ 
					caption: 'نام خانوادگی',
					dataField: 'lastName'
					});
							this.columns.push({ 
					caption: 'کد ملی',
					dataField: 'nationalCode'
					});
							this.columns.push({ 
					caption: 'ایمیل',
					dataField: 'email'
					});
							this.columns.push({ 
					caption: 'کلمه عبور',
					dataField: 'password'
					});
							this.columns.push({ 
					caption: 'فعال',
					dataField: 'isActive'
					});
							this.columns.push({ 
					caption: 'شماره موبایل',
					dataField: 'mobileNumber'
					});
							this.columns.push({ 
					caption: 'سازمان',
					dataField: 'organizationTitle'
					});
							this.columns.push({ 
					caption: 'زمان ایجاد',
					dataField: 'createTime'
					});
							this.columns.push({ 
					caption: 'تاریخ ایجاد',
					dataField: 'createDate'
					});
							this.columns.push({ 
					caption: 'PasswordSalt',
					dataField: 'passwordSalt'
					});
							this.columns.push({ 
					caption: 'آدرس',
					dataField: 'address'
					});
							this.columns.push({ 
					caption: 'سطح دسترسی',
					dataField: 'accessLevelTitle'
					});
							
				}
		}
