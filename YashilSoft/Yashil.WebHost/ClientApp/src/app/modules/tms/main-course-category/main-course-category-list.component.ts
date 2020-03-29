			
		import { Component, OnInit } from '@angular/core';
		import {MainCourseCategoryDetailComponent} from './main-course-category-detail.component';
			
		

		@Component({
		  selector: 'app-main-course-category-list',
		  templateUrl: './main-course-category-list.component.html'
		})
		export class MainCourseCategoryListComponent {
		  selectedItemId: number;
		  columns: any[] = [];
		  entityName = 'mainCourseCategory';
		  detailComponent = MainCourseCategoryDetailComponent; 		  constructor() {
							this.columns.push({ 
					caption: 'عنوان',
					dataField: 'title'
					});
							
				}
		}
