import {Component} from '@angular/core';


@Component({
    selector: 'app-educational-center-custom-list',
    templateUrl: './educational-center-custom-list.component.html'
})
export class EducationalCenterCustomListComponent {
    selectedItemId: number;
    columns: any[] = [];
    entityName = 'educationalCenter';
    contentHeight: number;
    selectedEducationalCenterId: number;
    tabs = [
        {id: 2, title: 'نمایندگی ها', template: 'representation'},
        {id: 1, title: 'دسته بندي ', template: 'courseCategory'}
    ];

    constructor() {
        this.contentHeight = window.innerHeight - 110;
    }

    selectedRepresentationChange(selectedRepresentation: any) {
    }

    selectedEducationalCenterChange(selectedEducationalCenter: any) {
        this.selectedEducationalCenterId = selectedEducationalCenter.id;
    }
}
