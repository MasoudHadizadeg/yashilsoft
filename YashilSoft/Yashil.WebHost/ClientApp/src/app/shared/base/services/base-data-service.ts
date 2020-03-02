import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders, HttpParams} from '@angular/common/http';
import {Observable, of} from 'rxjs';
import {catchError, map, tap} from 'rxjs/operators';
import {MessageService} from '../messages/message.service';

import CustomStore from 'devextreme/data/custom_store';
import {createStore} from 'devextreme-aspnet-data-nojquery';

const httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
};

@Injectable({
    providedIn: 'root'
})
export class GenericDataService {
    private baseUrl: string;
}
