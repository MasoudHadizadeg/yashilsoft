import {Type} from '@angular/core';

export interface IDialogService {
  error(message: string, title?: string);

  showMessage(message: string, type: string);

  showModal(component: Type<any> | string, data: any, destroyOnClose: boolean, options: any);
}

export interface IBusyIndicator {
  setBusy(newState: boolean, msg?: string);
}
