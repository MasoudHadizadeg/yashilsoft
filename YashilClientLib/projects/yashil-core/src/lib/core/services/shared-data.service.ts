import {Injectable} from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SharedDataService {
  data = {};

  get(key) {
    return this.data[key];
  }

  getAndClear(key) {
    const value = this.data[key];
    this.data[key] = null;
    return value;
  }

  set(key, value) {
    this.data[key] = value;
  }
}
