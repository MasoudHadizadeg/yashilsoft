import {Component, Input, OnInit, ViewChild} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {DxTreeViewComponent} from 'devextreme-angular';


@Component({
    selector: 'app-representation-course-category-detail',
    templateUrl: './representation-course-category-detail.component.html'
})
export class RepresentationCourseCategoryDetailComponent extends BaseEdit implements OnInit {
    @ViewChild(DxTreeViewComponent, {static: false}) treeView;
    @Input()
    representationId: number;
    @Input()
    courseCategoryId: number;
    @Input()
    accessLevelId: number;
    representationDataSource: any;
    courseCategoryDataSource: any;
    accessLevels: any[] = [];

    constructor(private genericDataService: GenericDataService) {
        super(genericDataService);
        this.entityName = 'representationCourseCategory';
    }

    ngOnInit() {
        super.ngOnInit();
        if (this.representationId) {
            this.entity.representationId = this.representationId;
        }
        if (this.courseCategoryId) {
            this.entity.courseCategoryId = this.courseCategoryId;
        }
        if (this.accessLevelId) {
            this.entity.accessLevelId = this.accessLevelId;
        }

        this.representationDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'representation');
        this._genericDataService.getEntitiesByEntityNameForSelect(Entity.AccessLevel).subscribe(res => this.accessLevels = res);
        this.bindDataSources();
    }

    syncTreeViewSelection(e) {
        const component = (e && e.component) || (this.treeView && this.treeView.instance);

        if (!component) {
            return;
        }
    }

    treeView_itemSelectionChanged(e) {
        if (!e.itemData.isMainCourseCategory) {
            this.courseCategoryId = e.itemData.id;
            this.entity.courseCategoryId = this.courseCategoryId;
        }
    }

    private bindDataSources() {
        this.courseCategoryDataSource =
            this._genericDataService.getCustomEntitiesByUrl(`api/courseCategory/GetMainCourseCategoryByRepresentationId?representationId=${this.entity.representationId}`).subscribe((res: any) => {
                this.courseCategoryDataSource = res;
            });
    }
}
