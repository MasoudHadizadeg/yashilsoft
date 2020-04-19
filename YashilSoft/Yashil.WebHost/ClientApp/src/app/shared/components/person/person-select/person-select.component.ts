import {Component, Input, OnInit} from '@angular/core';
import {Selectable} from '../../../base/classes/selectable';
import {GenericDataService} from '../../../base/services/generic-data.service';


@Component({
    selector: 'app-person-select',
    templateUrl: './person-select.component.html'
})
export class PersonSelectComponent extends Selectable implements OnInit {
    @Input()
    selectedItemId: number;
    columns: any[] = [];
    entityName = 'Person';
    personDataSource: any;

    constructor(private genericDataService: GenericDataService) {
        super();
        this.columns.push({
            caption: 'نام و نام خانوادگی',
            dataField: 'title'
        });
        this.columns.push({
            caption: 'کد ملی',
            dataField: 'nationalCode'
        });

    }

    ngOnInit(): void {
        this.personDataSource = this.genericDataService.createCustomDatasourceForSelect('id', 'person');
    }

    selectedPersonChanged(e: any) {
        if (e && e.selectedRowsData && e.selectedRowsData.length > 0) {
            this.selectedItemId = e.selectedRowsData[0].id;
            this.selectedRowChanged.emit(this.selectedItemId);
        }
    }
}
