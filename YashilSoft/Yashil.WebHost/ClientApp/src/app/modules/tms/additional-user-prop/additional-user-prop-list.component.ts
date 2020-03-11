			
		import { Component, OnInit } from '@angular/core';
		import {AdditionalUserPropDetailComponent} from './additional-user-prop-detail.component';
			
		

		@Component({
		  selector: 'app-additional-user-prop-list',
		  templateUrl: './additional-user-prop-list.component.html'
		})
		export class AdditionalUserPropListComponent {
		  selectedItemId: number;
		  columns: any[] = [];
		  entityName = 'additionalUserProp';
		  detailComponent = AdditionalUserPropDetailComponent; 		  constructor() {
							this.columns.push({ 
					caption: 'کاربر',
					dataField: 'userTitle'
					});
							this.columns.push({ 
					caption: 'مرکز آموزشی',
					dataField: 'educationalCenterId'
					});
							this.columns.push({ 
					caption: 'نمایندگی',
					dataField: 'representationTitle'
					});
							
				}
		}
