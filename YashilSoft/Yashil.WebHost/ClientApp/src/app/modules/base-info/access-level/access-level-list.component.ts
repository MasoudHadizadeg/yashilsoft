			
		import { Component, OnInit } from '@angular/core';
		import {AccessLevelDetailComponent} from './access-level-detail.component';
			
		

		@Component({
		  selector: 'app-access-level-list',
		  templateUrl: './access-level-list.component.html'
		})
		export class AccessLevelListComponent {
		  selectedItemId: number;
		  columns: any[] = [];
		  entityName = 'accessLevel';
		  detailComponent = AccessLevelDetailComponent; 		  constructor() {
							this.columns.push({ 
					caption: 'عنوان',
					dataField: 'title'
					});
							this.columns.push({ 
					caption: 'مقدار سطح دسترسی',
					dataField: 'levelValue'
					});
							
				}
		}
