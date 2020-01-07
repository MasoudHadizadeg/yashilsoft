import {Injectable} from '@angular/core';
import {FormContainer} from '../models/FormContainer';
import {EMPTY, Observable} from 'rxjs';
import {HttpClient, HttpErrorResponse, HttpHeaders} from '@angular/common/http';
import {catchError, map} from 'rxjs/operators';
import {ServiceTools} from '../models/ServiceTools';

@Injectable({
  providedIn: 'root'
})
export class ApiClientService {

  constructor(private http: HttpClient) {
  }


  getHeaders(config?: ApiConfig) {
    let headers = new HttpHeaders();
    if (!config || !config.noAuth) {
      if (this.getCurrentAuthToken()) {
        headers = headers.set('Authorization', this.getCurrentAuthToken());
      }
    }
    return headers;
  }

  getCurrentAuthToken() {
    return null;
    // todo get token from local storage or observable
  }

  post<T>(api: string, data: any, component: FormContainer, config?: ApiConfig): Observable<T> {
    if (component) {
      component.isWorking = true;
      component.fieldErrors = {};
    }
    return this.http.post<T>(ServiceTools.api(api), data, {headers: this.getHeaders()})
      .pipe(
        map(res => this.processResponse(res, component)),
        catchError(err => this.processError(err, component))
      );
  }

  put<T>(api: string, data: any, component: FormContainer, config?: ApiConfig): Observable<T> {
    if (component) {
      component.isWorking = true;
      component.fieldErrors = {};
    }
    return this.http.put<T>(ServiceTools.api(api), data, {headers: this.getHeaders()})
      .pipe(
        map(res => this.processResponse(res, component)),
        catchError(err => this.processError(err, component))
      );
  }

  get<T>(api: string, component: FormContainer, config?: ApiConfig): Observable<T> {
    if (component) {
      component.isWorking = true;
      component.fieldErrors = {};
    }
    return this.http.get<T>(ServiceTools.api(api), {headers: this.getHeaders()})
      .pipe(
        map(res => this.processResponse(res, component)),
        catchError(err => this.processError(err, component))
      );
  }

  delete<T>(api: string, component: FormContainer, config?: ApiConfig): Observable<T> {
    if (component) {
      component.isWorking = true;
      component.fieldErrors = {};
    }
    return this.http.post<T>(ServiceTools.api(api), {headers: this.getHeaders()})
      .pipe(
        map(res => this.processResponse(res, component)),
        catchError(err => this.processError(err, component))
      );
  }

  processResponse<T>(res: T, component: FormContainer) {
    if (component) {
      component.isWorking = false;
    }
    return res;
  }

  processError(err: HttpErrorResponse, component: FormContainer) {
    if (component) {
      component.isWorking = true;
    }

    if (component && component.handleError && component.handleError(err)) {
      return EMPTY;
    }

    // todo should fill fields error
    return EMPTY;
  }


}

export interface ApiConfig {
  noAuth?: boolean;
  allowAnonymous?: boolean;
}
