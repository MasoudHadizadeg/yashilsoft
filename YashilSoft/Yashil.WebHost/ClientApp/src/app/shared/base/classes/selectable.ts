import {EventEmitter, Input, Output} from '@angular/core';

export class Selectable {
    @Output()
    public selectedRowChanged: EventEmitter<any> = new EventEmitter<any>();
}
