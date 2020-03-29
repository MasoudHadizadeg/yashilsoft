import {Component, Input, OnInit, ViewChild} from '@angular/core';
import {CourseCategoryDetailTabBasedComponent} from './course-category-detail-tab-based.component';
import {BaseList} from '../../../shared/base/classes/base-list';
import {Selectable} from '../../../shared/base/classes/selectable';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {CachedKey} from '../tms-enums';
import {CachedDataService} from '../../../shared/services/cached-data.service';


@Component({
    selector: 'app-course-category-custom-list',
    templateUrl: './course-category-custom-list.component.html'
})
export class CourseCategoryCustomListComponent extends Selectable implements OnInit {
    @ViewChild('frmCategory', {static: true}) frmRep: BaseList;
    private _educationalCenterId: number;
    contentHeight: number;
    selectedEntity: any = null;
    educationalCenterDataSource: any;

    @Input()
    set educationalCenterId(value: number) {
        if (this._educationalCenterId !== value) {
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

    constructor(private genericDataService: GenericDataService, private cachedDataService: CachedDataService) {
        super();
        this.contentHeight = window.innerHeight - 110;
    }

    bindTree() {
        if (this._educationalCenterId) {
            this.frmRep.customListUrl = `${this.baseListUrl}?educationalCenterId=${this._educationalCenterId}`;
        } else {
            this.frmRep.customListUrl = `${this.baseListUrl}`;
        }
        this.frmRep.dataStructureIsPlain = true;
        this.frmRep.isForTree = true;
        this.frmRep.rootValue = null;
        this.frmRep.refreshList();
    }

    afterInitialDetailComponent(componentInstance: any) {
        const comp = (<CourseCategoryDetailTabBasedComponent>componentInstance);
        comp.educationalCenterId = this.educationalCenterId;
        if (this.selectedEntity) {
            comp.educationalCenterMainCourseCategoryId = this.selectedEntity.educationalCenterMainCourseCategoryId;
            comp.parentId = this.selectedEntity.isMainCourseCategory === true ? null : this.selectedEntity.id;
        }
    }

    ngOnInit(): void {
        const data = this.cachedDataService.getData(CachedKey.AdditionalUserProp);
        if (data && data.educationalCenterId) {
            this.educationalCenterId = data.educationalCenterId;
        }
        this.educationalCenterDataSource = this.genericDataService.createCustomDatasourceForSelect('id', 'educationalCenter');
        this.columns.push({
            caption: 'عنوان',
            dataField: 'title'
        });
    }

    onRowSelect(item: any) {
        this.selectedEntity = item;
    }
}
