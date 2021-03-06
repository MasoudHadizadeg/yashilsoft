import {Component, OnInit} from '@angular/core';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Editable} from '../../../shared/base/classes/editable';


@Component({
    selector: 'app-educational-center-detail-tab-based',
    templateUrl: './educational-center-detail-tab-based.component.html'
})
export class EducationalCenterDetailTabBasedComponent extends Editable implements OnInit {

    allowEditDesc: boolean;
    tabs: any[] = [];

    constructor(private genericDataService: GenericDataService) {
        super();
        this.entityName = 'educationalCenter';
    }

    ngOnInit() {
        if (this.selectedEntityId && this.selectedEntityId !== 0) {
            this.allowEditDesc = true;
        } else {
            this.allowEditDesc = false;
        }
        this.bindTabs();
    }

    rowInserted(insertedRowId: any) {
        this.selectedEntityId = insertedRowId;
        this.allowEditDesc = true;
        this.bindTabs();
    }

    bindTabs() {

        this.tabs = [
            {id: 1, title: 'مرکز آموشي', template: 'educationalCenter'},
            {id: 2, title: 'دپارتمان های آموزشی', template: 'department', disabled: !this.allowEditDesc},
            {id: 3, title: 'گروه آموزشی', template: 'courseCategory', disabled: !this.allowEditDesc},
            {id: 4, title: 'نمایندگی', template: 'representation', disabled: !this.allowEditDesc},
            {id: 5, title: 'درباره مرکز', template: 'about', disabled: !this.allowEditDesc},
            {id: 6, title: 'اهداف و ماموریت', template: 'goal', disabled: !this.allowEditDesc},
            {id: 8, title: 'توانمندی ها و سوابق', template: 'ability', disabled: !this.allowEditDesc},
            {id: 7, title: 'توضیحات', template: 'description', disabled: !this.allowEditDesc}
        ];
    }
}


