import DataSource from 'devextreme/data/data_source';
import {HttpClient, HttpParams} from '@angular/common/http';
import {Inject, Input} from '@angular/core';

export class CustomDevDataSource {
    @Input()
    allowDeleteInForm = true;
    private httpClient: HttpClient;
    rowKey = 'id';
    // This Property Used For Set Tree List RowKeys
    selectedRowKeys: any[] = [];

    constructor(@Inject(HttpClient) httpClient: HttpClient) {
        this.httpClient = httpClient;
    }

    getCustomDataSource(entityName, pageFilters: any[], customListUrl: string) {
        return new DataSource(
            {
                key: 'id',
                load: (loadOptions) => {
                    let params: HttpParams = new HttpParams();
                    [
                        'skip',
                        'take',
                        'requireTotalCount',
                        'requireGroupCount',
                        'sort',
                        // 'filter',
                        'totalSummary',
                        'group',
                        'groupSummary'
                    ].forEach(function (i) {
                            if (i in loadOptions && (loadOptions[i] && loadOptions[i] !== '')) {
                                params = params.set(i, JSON.stringify(loadOptions[i]));
                            }
                        }
                    );
                    let rf = [];
                    const filterParamKey = 'filter';
                    if (loadOptions[filterParamKey] && loadOptions[filterParamKey] !== '') {
                        const filters = loadOptions[filterParamKey];
                        if (filters[1] === 'and') {
                            rf = filters;
                        } else {
                            rf.push(filters);
                        }
                    }
                    params = params.set('filter', JSON.stringify(rf));
                    let cp: any[];
                    cp = [];
                    for (let k = 0; k < pageFilters.length; k++) {
                        cp.push(pageFilters[k]);
                    }
                    params = params.set('customParams', JSON.stringify(cp));
                    let listUrl = entityName;
                    if (customListUrl != null) {
                        listUrl = customListUrl;
                    }
                    return this.httpClient.get(`/api/${listUrl}`, {params: params})
                        .toPromise()
                        .then(result => {
                            this.afterLoadData(result);
                            return {
                                data: result['data'],
                                totalCount: result['totalCount'],
                                summary: result['summary'],
                                groupCount: result['groupCount']
                            };
                        });
                },
                update: (key: any | string | number, values: any) => {
                    const changedProps = Object.keys(values);
                    for (let i = 0; i < changedProps.length; i++) {
                        changedProps[i] = changedProps[i].charAt(0).toUpperCase() + changedProps[i].slice(1);
                    }
                    const data = {EditModel: values, ChangedProps: changedProps};
                    values['id'] = key.id;
                    return this.httpClient.put<any>('/api/' + entityName + '/PutEntityCustom', data, {})
                        .toPromise().then();
                }
            }
        );
    }

    // :TODO  This Method Must Be Private and Other Class Cannot change it,but Other Class Maybe Need for  it
    afterLoadData(result) {
    }

}
