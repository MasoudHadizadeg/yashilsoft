﻿import {EventEmitter, Output, ViewChild} from '@angular/core'
import {IBusyIndicator} from '../interfaces'
import {BusyIndicatorComponent} from '../components/busy-indicator/busy-indicator.component';
import {DxFormComponent} from 'devextreme-angular';

export class YashilComponent {

  busyMessage: string;
  busyState: boolean;

  @Output()
  onCloseRequest = new EventEmitter();

  @ViewChild(BusyIndicatorComponent) busyIndicator: IBusyIndicator;

  setBusy(newState: boolean, msg?: string) {
    this.busyState = newState;
    this.busyMessage = msg;
    if (this.busyIndicator) {
      this.busyIndicator.setBusy(newState, msg);
    }
  }
}
