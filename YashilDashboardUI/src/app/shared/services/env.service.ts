import {Injectable} from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EnvService {
  public apiUrl = '';

  // Whether or not to enable debug mode
  public enableDebug = true;

  constructor() {
  }
}
