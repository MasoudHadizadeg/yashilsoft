import {EventEmitter, Output} from '@angular/core';
import {ActivatedRoute} from '@angular/router';

export class Selectable {
    @Output()
    public selectedRowChanged: EventEmitter<any> = new EventEmitter<any>();
}
