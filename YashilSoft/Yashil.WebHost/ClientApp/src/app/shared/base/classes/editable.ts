import {EventEmitter, Input, Output} from '@angular/core';

export class Editable {
    dataEntityName: string;

    @Input()
    public set entityName(value: string) {
        this.dataEntityName = value;
    }

    public get entityName(): string {
        return this.dataEntityName;
    }

    public dataSelectedEntityId: number;

    showCloseButton: boolean;

    @Input()
    public set additionalData(value: any) {
        this._additionalData = value;
    }

    @Input()
    isNew: boolean;

    @Input()
    public set selectedEntityId(value: number) {
        this.dataSelectedEntityId = value;
    }

    public get selectedEntityId(): number {
        return this.dataSelectedEntityId;
    }

    @Output()
    closeFormClick = new EventEmitter<boolean>();
    _additionalData: any;

    public get additionalData(): any {
        return this._additionalData;
    }
}
