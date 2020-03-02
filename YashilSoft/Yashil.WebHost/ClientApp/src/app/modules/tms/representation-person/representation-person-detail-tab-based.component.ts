


import {Component, OnInit} from '@angular/core';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Editable} from '../../../shared/base/classes/editable';


@Component({
    selector: 'app-representation-person-detail-tab-based',
    templateUrl: './representation-person-detail-tab-based.component.html'
})
export class RepresentationPersonDetailTabBasedComponent extends Editable implements OnInit {
    tabs = [
    {id: 1, title: 'پرسنل نمايندگي', template: 'representationPerson'},
					 {id: 2, title: 'توضیحات', template: 'description'},
				 ];

    constructor(private genericDataService: GenericDataService) {
        super();
        this.entityName = 'representationPerson';
    }

    ngOnInit() {
    }
}


