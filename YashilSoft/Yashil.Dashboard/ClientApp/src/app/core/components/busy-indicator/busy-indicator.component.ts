import {Component} from '@angular/core';
import {IBusyIndicator} from '../../interfaces';

@Component({
  selector: 'app-busy-indicator',
  templateUrl: './busy-indicator.component.html',
  styleUrls: ['./busy-indicator.component.css']
})
export class BusyIndicatorComponent implements IBusyIndicator {

  public isBusy = false;

  setBusy(newState: boolean, msg?: string) {
    this.isBusy = newState;
  }
}
