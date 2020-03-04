			
		import { Component, OnInit } from '@angular/core';
		import {CourseCategoryDetailComponent} from './course-category-detail.component';
				import {CourseCategoryDetailTabBasedComponent} from './course-category-detail-tab-based.component';
			
		

		@Component({
		  selector: 'app-course-category-list',
		  templateUrl: './course-category-list.component.html'
		})
		export class CourseCategoryListComponent {
		  selectedItemId: number;
		  columns: any[] = [];
		  entityName = 'courseCategory';
		  detailComponent =  CourseCategoryDetailTabBasedComponent; 		  constructor() {
							this.columns.push({ 
					caption: 'ParentId',
					dataField: 'parentTitle'
					});
							this.columns.push({ 
					caption: 'کد',
					dataField: 'code'
					});
							this.columns.push({ 
					caption: 'عنوان',
					dataField: 'title'
					});
							this.columns.push({ 
					caption: 'مرکز آموزشی',
					dataField: 'educationalCenterTitle'
					});
							this.columns.push({ 
					caption: 'سطح دسترسی',
					dataField: 'accessLevelTitle'
					});
							
				}
		}
