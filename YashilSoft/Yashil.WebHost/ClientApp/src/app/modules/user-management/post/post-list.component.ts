			
		import { Component, OnInit } from '@angular/core';
		import {PostDetailComponent} from './post-detail.component';
			
		

		@Component({
		  selector: 'app-post-list',
		  templateUrl: './post-list.component.html'
		})
		export class PostListComponent {
		  selectedItemId: number;
		  columns: any[] = [];
		  entityName = 'post';
		  detailComponent = PostDetailComponent; 		  constructor() {
							this.columns.push({ 
					caption: 'کد',
					dataField: 'code'
					});
							this.columns.push({ 
					caption: 'عنوان',
					dataField: 'title'
					});
							this.columns.push({ 
					caption: 'ParentId',
					dataField: 'parentTitle'
					});
							this.columns.push({ 
					caption: 'پست مجازی',
					dataField: 'isVirtual'
					});
							this.columns.push({ 
					caption: 'سطح دسترسی',
					dataField: 'accessLevelTitle'
					});
							
				}
		}
