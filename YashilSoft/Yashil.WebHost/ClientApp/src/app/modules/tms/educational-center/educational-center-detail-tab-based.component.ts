


import {Component, OnInit} from '@angular/core';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Editable} from '../../../shared/base/classes/editable';


@Component({
    selector: 'app-educational-center-detail-tab-based',
    templateUrl: './educational-center-detail-tab-based.component.html'
})
export class EducationalCenterDetailTabBasedComponent extends Editable implements OnInit {
    tabs = [
    {id: 1, title: 'مرکز آموشي', template: 'educationalCenter'},
					 {id: 2, title: 'درباره', template: 'about'},
									 {id: 3, title: 'اهداف و ماموریت', template: 'goal'},
									 {id: 4, title: 'توضیحات', template: 'description'},
									 {id: 5, title: 'توانمندی ها و سوابق', template: 'ability'},
				 ];

    constructor(private genericDataService: GenericDataService) {
        super();
        this.entityName = 'educationalCenter';
    }

    ngOnInit() {
    }
}


