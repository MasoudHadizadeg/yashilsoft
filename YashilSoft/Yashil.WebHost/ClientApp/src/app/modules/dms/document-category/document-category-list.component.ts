			
		import { Component, OnInit } from '@angular/core';
		import {DocumentCategoryDetailComponent} from './document-category-detail.component';
		@Component({
		  selector: 'app-document-category-list',
		  templateUrl: './document-category-list.component.html'
		})
		export class DocumentCategoryListComponent {
		  selectedItemId: number;
		  columns: any[] = [];
		  entityName = 'documentCategory';
		  detailComponent = DocumentCategoryDetailComponent;
		  constructor() {
							this.columns.push({ 
					caption: 'عنوان',
					dataField: 'title'
					});
							this.columns.push({ 
					caption: 'کد پدر',
					dataField: 'parentTitle'
					});
							this.columns.push({ 
					caption: 'موجودیت',
					dataField: 'appEntityTitle'
					});
							this.columns.push({ 
					caption: 'کد مالک',
					dataField: 'objectId'
					});
							this.columns.push({ 
					caption: 'ترتیب نمایش',
					dataField: 'displayOrder'
					});
							this.columns.push({ 
					caption: 'فعال بودن',
					dataField: 'isActive'
					});
							this.columns.push({ 
					caption: 'سازمان ایجاد کننده سند',
					dataField: 'creatorOrganizationId'
					});
							
				}
		}
