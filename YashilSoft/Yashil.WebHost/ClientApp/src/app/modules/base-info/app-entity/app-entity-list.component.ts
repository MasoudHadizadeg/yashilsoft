			
		import { Component, OnInit } from '@angular/core';
		import {AppEntityDetailComponent} from './app-entity-detail.component';
		@Component({
		  selector: 'app-app-entity-list',
		  templateUrl: './app-entity-list.component.html'
		})
		export class AppEntityListComponent {
		  selectedItemId: number;
		  columns: any[] = [];
		  entityName = 'appEntity';
		  detailComponent = AppEntityDetailComponent;
		  constructor() {
							this.columns.push({ 
					caption: 'عنوان انگلیسی جدول',
					dataField: 'title'
					});
							this.columns.push({ 
					caption: 'کد سیستمی جدول',
					dataField: 'objectId'
					});
							this.columns.push({ 
					caption: 'عنوان ستون نمایشی',
					dataField: 'titlePropertyName'
					});
							this.columns.push({ 
					caption: 'با تعداد رکوردهای بزرگتر از 1000',
					dataField: 'isLarge'
					});
							this.columns.push({ 
					caption: 'فیلد json ویژگی ها',
					dataField: 'props'
					});
							this.columns.push({ 
					caption: 'عنوان فارسی جدول',
					dataField: 'persianTitle'
					});
							this.columns.push({ 
					caption: 'عنوان انگلیسی جدول',
					dataField: 'englishTitle'
					});
							this.columns.push({ 
					caption: 'رکورهای جدول به تفکیک برنامه می باشد',
					dataField: 'applicationBased'
					});
							
				}
		}
