			
		import { Component, OnInit } from '@angular/core';
		import {YashilDataProviderDetailComponent} from './yashil-data-provider-detail.component';
		@Component({
		  selector: 'app-yashil-data-provider-list',
		  templateUrl: './yashil-data-provider-list.component.html'
		})
		export class YashilDataProviderListComponent {
		  selectedItemId: number;
		  columns: any[] = [];
		  entityName = 'yashilDataProvider';
		  detailComponent = YashilDataProviderDetailComponent;
		  constructor() {
							this.columns.push({ 
					caption: 'عنوان',
					dataField: 'title'
					});
							this.columns.push({ 
					caption: 'نوع پایه',
					dataField: 'baseType'
					});
							this.columns.push({ 
					caption: 'فعال بودن',
					dataField: 'isActive'
					});
							
				}
		}
