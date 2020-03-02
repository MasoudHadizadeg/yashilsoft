


import {Component, OnInit} from '@angular/core';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Editable} from '../../../shared/base/classes/editable';


@Component({
    selector: 'app-representation-detail-tab-based',
    templateUrl: './representation-detail-tab-based.component.html'
})
export class RepresentationDetailTabBasedComponent extends Editable implements OnInit {
    tabs = [
    {id: 1, title: 'نمایندگی', template: 'representation'},
					 {id: 2, title: 'درباره', template: 'about'},
									 {id: 3, title: 'اهداف و ماموریت', template: 'goal'},
									 {id: 4, title: 'توضیحات', template: 'description'},
									 {id: 5, title: 'توانمندی ها و سوابق', template: 'ability'},
				 ];

    constructor(private genericDataService: GenericDataService) {
        super();
        this.entityName = 'representation';
    }

    ngOnInit() {
    }
}


