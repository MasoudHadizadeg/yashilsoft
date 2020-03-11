import {Component, Input, OnInit} from '@angular/core';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Editable} from '../../../shared/base/classes/editable';


@Component({
    selector: 'app-representation-detail-tab-based',
    templateUrl: './representation-detail-tab-based.component.html'
})
export class RepresentationDetailTabBasedComponent extends Editable implements OnInit {
    @Input()
    educationalCenterId: number;
    allowEditDesc: boolean;
    tabs: any[] = [];

    constructor(private genericDataService: GenericDataService) {
        super();
        this.entityName = 'representation';
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
            {id: 1, title: 'نمایندگی', template: 'representation'},
            {id: 2, title: 'درباره', template: 'about', disabled: !this.allowEditDesc},
            {id: 3, title: 'اهداف و ماموریت', template: 'goal', disabled: !this.allowEditDesc},
            {id: 4, title: 'توضیحات', template: 'description', disabled: !this.allowEditDesc},
            {id: 5, title: 'توانمندی ها و سوابق', template: 'ability', disabled: !this.allowEditDesc},
        ];

    }


}


