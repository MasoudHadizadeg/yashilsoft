


import {Component, OnInit} from '@angular/core';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Editable} from '../../../shared/base/classes/editable';


@Component({
    selector: 'app-courses-planning-detail-tab-based',
    templateUrl: './courses-planning-detail-tab-based.component.html'
})
export class CoursesPlanningDetailTabBasedComponent extends Editable implements OnInit {

    allowEditDesc: boolean;
    tabs: any[] = [];
    constructor(private genericDataService: GenericDataService) {
        super();
        this.entityName = 'coursePlanning';
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
    bindTabs(){

    this.tabs = [
    {id: 1, title: 'برنامه ريزي دوره', template: 'coursePlanning'},
					 {id: 2, title: 'توضیحات', template: 'description', disabled: !this.allowEditDesc},
				 ];

}


}


