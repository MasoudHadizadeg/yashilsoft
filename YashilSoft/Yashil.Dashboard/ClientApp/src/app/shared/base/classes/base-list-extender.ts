import {EventEmitter, Input, Output, Type} from '@angular/core';
import {FormEditType} from './edit-type';

export class BaseListExtender {
  @Input()
  offsetHeight: number;
  @Input()
  showFilterButton = true;
  @Input()
  title: string;
  @Input()
  showListHeader = true;
  @Input()
  allowGrouping: boolean;
  @Input()
  lazyLoading: boolean;
  @Input()
  allowColumnResizing: boolean;
  @Input()
  wordWrapEnabled: boolean;
  @Input()
  filters: any[] = [];
  @Input()
  virtualPaging = false;
  @Input()
  columnHidingEnabled: boolean;
  @Input()
  parentIdExpr: 'parentId';
  @Input()
  isForSelectReadOnly = false;
  @Input()
  detailComponent: Type<any>;
  @Input()
  additionalData = {};
  @Input()
  allowFilter: boolean;
  @Input()
  allowLoadData = true;
  @Input()
  isForTree = false;
  @Input()
  gridHeight: number;
  @Input()
  editType: FormEditType = FormEditType.CustomModal;
  @Input()
  allowEdit: boolean;
  @Input()
  columns: any[] = [];
  @Output()
  selectedRowChanged: EventEmitter<any> = new EventEmitter<any>();
}
