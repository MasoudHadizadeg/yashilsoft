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
    private _representationId: number;
    @Input()
    isForSelectReadOnly = false;
    @Input()
    hideEducationalCenterColumn = false;
    selectedEntity: any = null;

    @Input()
    set representationId(value: number) {
        if (value && this._representationId !== value) {
            this._representationId = value;
            this.bindTree();
        }
    }

    get representationId(): number {
        return this._representationId;
    }


    @Input()
    set educationalCenterId(value: number) {
        if (value && this._educationalCenterId !== value) {
            this._educationalCenterId = value;
            this.bindTree();
        }
    }

    get educationalCenterId(): number {
        return this._educationalCenterId;
    }

    loadAfterSetFilter: boolean;
    customListUrl: string;
    baseListUrl = 'courseCategory/GetMainCourseCategoriesByEducationalCenterId';

    selectedItemId: number;
    columns: any[] = [];
    entityName = 'courseCategory';
    detailComponent = CourseCategoryDetailTabBasedComponent;

    constructor() {
        super();
    }

    bindTree() {
        if (this._educationalCenterId) {
            this.frmRep.customListUrl = `${this.baseListUrl}?educationalCenterId=${this._educationalCenterId}`;
        } else if (this.representationId) {
            this.frmRep.customListUrl = `courseCategory/GetRepresentationCourseCategories?representationId=${this.representationId}`;
        } else {
            this.frmRep.customListUrl = `${this.baseListUrl}`;
        }
        this.frmRep.dataStructureIsPlain = true;
        this.frmRep.isForTree = true;
        this.frmRep.rootValue = null;
        this.frmRep.refreshList();
    }

    afterInitialDetailComponent(componentInstance: any) {
        const comp = (<CourseCategoryDetailTabBasedComponent>componentInstance.instance);
        comp.educationalCenterId = this.educationalCenterId;
        if (this.selectedEntity) {
            comp.educationalCenterMainCourseCategoryId = this.selectedEntity.educationalCenterMainCourseCategoryId;
            comp.parentId = this.selectedEntity.isMainCourseCategory === true ? null : this.selectedEntity.id;
        }
    }

    ngOnInit(): void {
        this.columns.push({
            caption: 'عنوان',
            dataField: 'title'
        });
        if (!this.hideEducationalCenterColumn) {
            this.columns.push({
                caption: 'مرکز آموزشی',
                dataField: 'educationalCenterTitle',
            });
        }
    }

    onRowSelect(item: any) {
        this.selectedEntity = item;
        this.selectedRowChanged.emit(item);
    }
}
