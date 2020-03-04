import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders, HttpParams} from '@angular/common/http';
import {Observable, of} from 'rxjs';
import {catchError, map, tap} from 'rxjs/operators';
import {MessageService} from '../messages/message.service';
import CustomStore from 'devextreme/data/custom_store';
import {createStore} from 'devextreme-aspnet-data-nojquery';
import {CachedDataService} from '../../services/cached-data.service';

const httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
};

@Injectable({
    providedIn: 'root'
})
export class GenericDataService {
    private readonly baseUrl: string;

    constructor(
        private cachedDataService: CachedDataService,
        private httpClient: HttpClient,
        private messageService: MessageService) {
        this.baseUrl = '/api';
    }

    public getEntitiesWithAction(entityName: string, actionName: string, params: HttpParams): Observable<any[]> {
        // const params: HttpParams = new HttpParams();
        if (!params) {
            params = new HttpParams();
        }

        return this.httpClient.get<any[]>(`${this.baseUrl}/${entityName}/${actionName}`, {params})
            .pipe(
                tap(res => this.log('fetched res')),
                catchError(this.handleError('getEntities', []))
            );
    }

    public createCustomDatasource(key: string, entityName: string): any {
        const currentUser = this.cachedDataService.getData('currentUser');
        return createStore({
            key, loadUrl: `${this.baseUrl}/${entityName}`, onBeforeSend(method, ajaxOptions) {
                ajaxOptions.headers = {
                    Authorization: `Bearer ${currentUser.token}`
                };
            }
        });
    }

    public getCommonBaseDataForSelect(commonBaseTypeKey: string) {
        const data = this.cachedDataService.getData(commonBaseTypeKey, true);
        if (data) {
            return new Observable(subscriber => {
                subscriber.next(data)
            });
        }
        const param = new HttpParams().set('keyName', commonBaseTypeKey);
        return this.getCustomEntities('commonBaseData', 'GetByKeyName', param).pipe(tap(res => {
                if (res) {
                    this.cachedDataService.setData(commonBaseTypeKey, res);
                } else {
                    this.cachedDataService.clear(commonBaseTypeKey);
                }
            }
        ));
    }

    getCustomEntities(entityName, actionName: string, params: HttpParams): Observable<any[]> {
        return this.httpClient.get<any[]>(`${this.baseUrl}/${entityName}/${actionName}`, {params: params})
            .pipe(
                tap(res => this.log('fetched res')),
                catchError(this.handleError('getEntities', []))
            );
    }

    public createCustomDatasourceForSelect(key: string, entityName: string): any {
        return this.createCustomDatasourceWithAction(key, entityName, 'getForSelect');
    }

    public createCustomDatasourceWithAction(key: string, entityName: string, actionName: string): any {
        const currentUser = this.cachedDataService.getData('currentUser');

        return createStore({
            key, loadUrl: `${this.baseUrl}/${entityName}/${actionName}`, onBeforeSend(method, ajaxOptions) {
                ajaxOptions.headers = {
                    Authorization: `Bearer ${currentUser.token}`
                };
            }
        });
    }

    public createCustomDataSourceByFilter(key: string, entityName: string, actionName: string, filterMap: Map<string, string>)
        : CustomStore {
        const currentUser = this.cachedDataService.getData('currentUser');
        return createStore({
            key,
            loadUrl: `${this.baseUrl}/${entityName}/${actionName}`,
            updateUrl: `${this.baseUrl}/${entityName}/${actionName}`,
            onBeforeSend(method, ajaxOptions) {
                filterMap.forEach((value: string, filterKey: string) => {
                    ajaxOptions.data[filterKey] = value;
                });

                ajaxOptions.headers = {
                    Authorization: `Bearer ${currentUser.token}`
                };
            }
        });
    }

    public getEntitiesByEntityName(entityName: string): Observable<any[]> {
        return this.httpClient.get<any[]>(`${this.baseUrl}/${entityName}`)
            .pipe(tap(res => this.log('fetched res')), catchError(this.handleError('getEntities', [])));
    }

    public getEntitiesByEntityNameForSelect(entityName: string): Observable<any[]> {
        return this.httpClient.get<any[]>(`${this.baseUrl}/${entityName}/getForSelect`)
            .pipe(
                tap(res => this.log('fetched res')),
                catchError(this.handleError('getEntities', []))
            );
    }

    /** GET res from the server */

    getCustomEntitiesByUrl(url: string): Observable<any[]> {
        const params: HttpParams = new HttpParams();
        return this.httpClient.get<any[]>(url, {params})
            .pipe(
                tap(res => this.log('fetched res')),
                catchError(this.handleError('getEntities', []))
            );
    }

    /** GET res from the server */
    getEntities(entityName: string): Observable<any[]> {
        return this.httpClient.get<any[]>(`${this.baseUrl}/${this.baseUrl}/${entityName}`)
            .pipe(
                tap(res => this.log('fetched res')),
                catchError(this.handleError('getEntities', []))
            );
    }

    /** GET entity by id. Return `undefined` when id not found */
    getEntityNo404<Data>(entityName, id: number): Observable<any> {
        const url = `${this.baseUrl}/${entityName}/?id=${id}`;
        return this.httpClient.get<any[]>(url)
            .pipe(
                map(res => res[0]), // returns a {0|1} element array
                tap(h => {
                    const outcome = h ? `fetched` : `did not find`;
                    this.log(`${outcome} entity id=${id}`);
                }),
                catchError(this.handleError<any>(`getEntity id=${id}`))
            );
    }

    /** GET entity by id. Will 404 if id not found */
    getEntity(entityName, id: number, customLoadMethodName: string = null): Observable<any> {
        const url = customLoadMethodName ? `${this.baseUrl}/${entityName}/${customLoadMethodName}/${id}` : `${this.baseUrl}/${entityName}/${id}`;
        return this.httpClient.get<any>(url).pipe(
            tap(_ => this.log(`fetched entity id=${id}`)),
            catchError(this.handleError<any>(`getEntity id=${id}`))
        );
    }

    /* GET res whose name contains search term */
    searchEntities(entityName, term: string): Observable<any[]> {
        if (!term.trim()) {
            // if not search term, return empty entity array.
            return of([]);
        }
        return this.httpClient.get<any[]>(`${this.baseUrl}/${entityName}/?name=${term}`).pipe(
            tap(_ => this.log(`found res matching "${term}"`)),
            catchError(this.handleError<any[]>('searchEntities', []))
        );
    }

    //////// Save methods //////////
    postEntityByUrl(url: string, entity: any): Observable<any> {
        return this.httpClient.post<any>(url, entity, httpOptions)
            .pipe(
                tap((a: any) => this.log(`postEntityByUrl entity w/ id=${entity.id}`)),
                catchError(this.handleError<any>('postEntityByUrl')));
    }

    /** POST: add a new entity to the server */
    addEntity(entityName, entity: any): Observable<any> {
        return this.httpClient.post<any>(`${this.baseUrl}/${entityName}`, entity, httpOptions);
        /*
            .pipe(
                tap((a: any) => this.log(`added entity w/ id=${entity.id}`)),
                catchError(this.handleError<any>('addEntity')));
         */
    }

    /** DELETE: delete the entity from the server */
    deleteEntity(entityName, entity: any | number): Observable<any> {
        const id = typeof entity === 'number' ? entity : entity.id;
        const url = `${this.baseUrl}/${entityName}/${id}`;

        return this.httpClient.delete<any>(url, httpOptions).pipe(
            tap(_ => this.log(`deleted entity id=${id}`)),
            catchError(this.handleError<any>('deleteEntity'))
        );
    }

    /** PUT: update the entity on the server */
    updateEntity(entityName, entity: any): Observable<any> {
        return this.httpClient.put(`${this.baseUrl}/${entityName}`, entity, httpOptions).pipe(
            tap(_ => this.log(`updated entity id=${entity.id}`)),
            catchError(this.handleError<any>('updateEntity'))
        );
    }

    /**
     * Handle Http operation that failed.
     * Let the app continue.
     * @param operation - name of the operation that failed
     * @param result - optional value to return as the observable result
     */
    private handleError<T>(operation = 'operation', result?: T) {
        return (error: any): Observable<T> => {

            // TODO: send the error to remote logging infrastructure
            console.error(error); // log to console instead

            // TODO: better job of transforming error for user consumption
            this.log(`${operation} failed: ${error.message}`);

            // Let the app keep running by returning an empty result.
            return of(result as T);
        };
    }

    /** Log a EntityService message with the MessageService */
    private log(message: string) {
        this.messageService.add(`EntityService: ${message}`);
    }
}
