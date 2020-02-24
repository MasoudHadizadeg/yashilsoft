import {Injectable} from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ReportDataService {
  groups: any[];
  groupItems: any[];

  constructor() {
  }

  clear() {
    this.groups = null;
    this.groupItems = null;
  }
}
