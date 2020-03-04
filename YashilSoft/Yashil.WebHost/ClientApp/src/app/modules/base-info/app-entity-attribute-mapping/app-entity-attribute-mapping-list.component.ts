			
		import { Component, OnInit } from '@angular/core';
		import {AppEntityAttributeMappingDetailComponent} from './app-entity-attribute-mapping-detail.component';
			
		

		@Component({
		  selector: 'app-app-entity-attribute-mapping-list',
		  templateUrl: './app-entity-attribute-mapping-list.component.html'
		})
		export class AppEntityAttributeMappingListComponent {
		  selectedItemId: number;
		  columns: any[] = [];
		  entityName = 'appEntityAttributeMapping';
		  detailComponent = AppEntityAttributeMappingDetailComponent; 		  constructor() {
							this.columns.push({ 
					caption: 'کد',
					dataField: 'code'
					});
							this.columns.push({ 
					caption: 'موجودیت',
					dataField: 'appEntityTitle'
					});
							this.columns.push({ 
					caption: 'ویژگی',
					dataField: 'appEntityAttributeTitle'
					});
							this.columns.push({ 
					caption: 'اجباری بودن',
					dataField: 'isRequired'
					});
							this.columns.push({ 
					caption: 'نوع کنترل',
					dataField: 'attributeControlTypeTitle'
					});
							this.columns.push({ 
					caption: 'ترتیب نمایش',
					dataField: 'displayOrder'
					});
							this.columns.push({ 
					caption: 'حداقل مقدار',
					dataField: 'validationMinLength'
					});
							this.columns.push({ 
					caption: 'حداکثر مقدار',
					dataField: 'validationMaxLength'
					});
							this.columns.push({ 
					caption: 'سطح دسترسی',
					dataField: 'accessLevelTitle'
					});
							
				}
		}
