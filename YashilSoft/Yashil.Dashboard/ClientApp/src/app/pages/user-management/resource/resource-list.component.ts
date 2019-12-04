			
		import { Component, OnInit } from '@angular/core';
		import {ResourceDetailComponent} from './resource-detail.component';
		@Component({
		  selector: 'app-resource-list',
		  templateUrl: './resource-list.component.html'
		})
		export class ResourceListComponent {
		  selectedItemId: number;
		  columns: any[] = [];
		  entityName = 'resource';
		  detailComponent = ResourceDetailComponent;
		  constructor() {
							this.columns.push({ 
					caption: 'آدرس منبع',
					dataField: 'title'
					});
							this.columns.push({ 
					caption: 'توضیحات',
					dataField: 'description'
					});
							this.columns.push({ 
					caption: 'نوع',
					dataField: 'type'
					});
							
				}
		}
