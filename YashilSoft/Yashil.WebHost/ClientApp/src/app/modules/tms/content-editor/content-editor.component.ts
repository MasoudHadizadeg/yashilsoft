import {Component, Input, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';


@Component({
    selector: 'app-content-editor',
    templateUrl: './content-editor.component.html'
})
export class ContentEditorComponent extends BaseEdit implements OnInit {

    @Input()
    propertyName: string;
    @Input()
    propertyLabel: string;
    accessLevelDataSource: any;

    get firstCharacterUpper() {
        return this.propertyName.charAt(0).toUpperCase() + this.propertyName.slice(1);
    }

    constructor(private genericDataService: GenericDataService) {
        super(genericDataService);
        this.showCloseButton = false;
    }

    ngOnInit() {
        this.customLoadMethodName = `Get${this.firstCharacterUpper}`;
        super.ngOnInit();
        this.entity.propertyName = this.propertyName;
    }
}
