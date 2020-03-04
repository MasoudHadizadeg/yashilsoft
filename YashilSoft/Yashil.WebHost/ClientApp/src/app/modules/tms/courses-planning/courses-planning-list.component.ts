			
		import { Component, OnInit } from '@angular/core';
		import {CoursesPlanningDetailComponent} from './courses-planning-detail.component';
				import {CoursesPlanningDetailTabBasedComponent} from './courses-planning-detail-tab-based.component';
			
		

		@Component({
		  selector: 'app-courses-planning-list',
		  templateUrl: './courses-planning-list.component.html'
		})
		export class CoursesPlanningListComponent {
		  selectedItemId: number;
		  columns: any[] = [];
		  entityName = 'coursesPlanning';
		  detailComponent =  CoursesPlanningDetailTabBasedComponent; 		  constructor() {
							this.columns.push({ 
					caption: 'کد',
					dataField: 'code'
					});
							this.columns.push({ 
					caption: 'نمایندگی',
					dataField: 'representationTitle'
					});
							this.columns.push({ 
					caption: 'دوره سازمانی',
					dataField: 'organizational'
					});
							this.columns.push({ 
					caption: 'وضعیت دوره',
					dataField: 'courceStatusTitle'
					});
							this.columns.push({ 
					caption: 'مدرس',
					dataField: 'representationPersonTitle'
					});
							this.columns.push({ 
					caption: 'قیمت دوره',
					dataField: 'price'
					});
							this.columns.push({ 
					caption: 'دوره',
					dataField: 'courseTitle'
					});
							this.columns.push({ 
					caption: 'رده سنی',
					dataField: 'ageCategoryTitle'
					});
							this.columns.push({ 
					caption: 'نوع برگزاری',
					dataField: 'implementaionTypeTitle'
					});
							this.columns.push({ 
					caption: 'نوع دوره',
					dataField: 'courceTypeTitle'
					});
							this.columns.push({ 
					caption: 'روش اجرای دوره',
					dataField: 'runTypeTitle'
					});
							this.columns.push({ 
					caption: 'تاریخ شروع',
					dataField: 'startDate'
					});
							this.columns.push({ 
					caption: 'جنسیت',
					dataField: 'customGenderTitle'
					});
							this.columns.push({ 
					caption: 'حداکثر ظرفیت',
					dataField: 'maxCapacity'
					});
							this.columns.push({ 
					caption: 'سطح دسترسی',
					dataField: 'accessLevelTitle'
					});
							
				}
		}
