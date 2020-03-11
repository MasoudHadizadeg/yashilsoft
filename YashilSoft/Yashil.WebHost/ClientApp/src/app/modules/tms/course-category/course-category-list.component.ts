import {Component, Input, OnInit, ViewChild} from '@angular/core';
import {CourseCategoryDetailTabBasedComponent} from './course-category-detail-tab-based.component';
import {BaseList} from '../../../shared/base/classes/base-list';
import {Selectable} from '../../../shared/base/classes/selectable';


@Component({
    selector: 'app-course-category-list',
    templateUrl: './course-category-list.component.html'
})
export class CourseCategoryListComponent extends Selectable implements OnInit {
    @ViewChild('frmCategory', {static: true}) frmRep: BaseList;
    private _educationalCenterId: number;
    @Input()
    hideEducationalCenterColumn = false;
    @Input()
    set educationalCenterId(value: number) {
        if (this._educationalCenterId !== value) {
            this._educationalCenterId = value;
            this.frmRep.customListUrl = `${this.baseListUrl}${this._educationalCenterId}`;
            this.frmRep.refreshList();
        }
    }

    get educationalCenterId(): number {
        return this._educationalCenterId;
    }

    customListUrl: string;
    baseListUrl = 'courseCategory/GetByEducationalCenterIdForList?educationalCenterId=';

    selectedItemId: number;
    columns: any[] = [];
    entityName = 'courseCategory';
    detailComponent = CourseCategoryDetailTabBasedComponent;

    constructor() {
        super();
    }

    afterInitialDetailComponent(componentInstance: any) {
        (<CourseCategoryDetailTabBasedComponent>componentInstance).educationalCenterId = this.educationalCenterId;
    }

    ngOnInit(): void {
        this.columns.push({
            caption: 'عنوان',
            dataField: 'title'
        });
        if (!this.hideEducationalCenterColumn) {
            this.columns.push({
                caption: 'مرکز آموزشی',
                dataField: 'educationalCenterTitle'
            });
        }
    }
}
