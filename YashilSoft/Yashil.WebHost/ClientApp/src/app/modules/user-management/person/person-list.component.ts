					import {Selectable} from '../../../shared/base/classes/selectable';
		import {BaseList} from '../../../shared/base/classes/base-list';
		import {Component, Input, OnInit, ViewChild} from '@angular/core';
		import {PersonDetailComponent} from './person-detail.component';
			
		

		@Component({
		  selector: 'app-person-list',
		  templateUrl: './person-list.component.html'
		})
		export class PersonListComponent extends Selectable  implements OnInit {
		  @ViewChild('listForm', {static: true}) listForm: BaseList;
		  loadAfterSetFilter:boolean;
		  selectedItemId: number;
		  columns: any[] = [];
		  entityName = 'person';
		  detailComponent =PersonDetailComponent;
		 			_gender:number;
			@Input()
			set gender(val){
				if(val!==this._gender){
					this._gender=val;
				}
			}
			get gender(): number {
					return this._gender;
				}
						_educationGrade:number;
			@Input()
			set educationGrade(val){
				if(val!==this._educationGrade){
					this._educationGrade=val;
				}
			}
			get educationGrade(): number {
					return this._educationGrade;
				}
						_accessLevelId:number;
			@Input()
			set accessLevelId(val){
				if(val!==this._accessLevelId){
					this._accessLevelId=val;
				}
			}
			get accessLevelId(): number {
					return this._accessLevelId;
				}
					  private baseListUrl = 'person/GetByCustomFilterForList?';
		  constructor() {
			super();
							this.columns.push({ 
					caption: 'نام',
					dataField: 'name'
					});
							this.columns.push({ 
					caption: 'نام خانوادگی',
					dataField: 'lastName'
					});
							this.columns.push({ 
					caption: 'نام پدر',
					dataField: 'fatherName'
					});
							this.columns.push({ 
					caption: 'جنسیت',
					dataField: 'genderTitle'
					});
							this.columns.push({ 
					caption: 'تاریخ تولد',
					dataField: 'birthDate'
					});
							this.columns.push({ 
					caption: 'شماره تلفن',
					dataField: 'phoneNumber'
					});
							this.columns.push({ 
					caption: 'مدرک تحصیلی',
					dataField: 'educationGradeTitle'
					});
							this.columns.push({ 
					caption: 'رایانامه (Email)',
					dataField: 'email'
					});
							this.columns.push({ 
					caption: 'کد ملی',
					dataField: 'nationalCode'
					});
							
				}
			ngOnInit(): void {
					if(this.bindCustomDataSources()){
						this.loadAfterSetFilter=true;
					}
				}

	private bindCustomDataSources() {
				let customListUrl = `${this.baseListUrl}`;
		if (this.listForm) {
							if(this.gender){
					customListUrl += `gender=${this.gender}&`;
				}
							if(this.educationGrade){
					customListUrl += `educationGrade=${this.educationGrade}&`;
				}
							if(this.accessLevelId){
					customListUrl += `accessLevelId=${this.accessLevelId}&`;
				}
					}
		let res=false;
		if(this.gender || this.educationGrade || this.accessLevelId){
			this.listForm.customListUrl = customListUrl;
            this.listForm.refreshList();
			res=true;
		}
		return res;
    }
    afterInitialDetailComponent(componentInstance: any) {
        const comp = (<PersonDetailComponent>componentInstance.instance);
				
			if(this.gender){
				comp.gender = this.gender;
			}
				
			if(this.educationGrade){
				comp.educationGrade = this.educationGrade;
			}
				
			if(this.accessLevelId){
				comp.accessLevelId = this.accessLevelId;
			}
		        
    }
}
