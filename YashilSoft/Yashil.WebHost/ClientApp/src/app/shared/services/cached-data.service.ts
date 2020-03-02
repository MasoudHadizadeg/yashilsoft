import {Injectable} from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class CachedDataService {
    public claimData: any;

    getClaimData() {
        if (!this.claimData) {
            const token = localStorage.getItem('currentUser');
            const payloadHash = JSON.parse(token).token.toString().split('.')[1];
            const payload = JSON.parse(atob(payloadHash));
            this.claimData = payload;
        }
        return this.claimData;
    }

    setData(key: string, value: any, isJson = true) {
        if (isJson && isJson === true) {
            localStorage.setItem(key, JSON.stringify(value));
        } else {
            localStorage.setItem(key, value);
        }
    }

    getData(key: string, parseJson = true): any {
        const data = localStorage.getItem(key);
        if (parseJson === true && data) {
            return JSON.parse(data);
        } else {
            return data;
        }
    }

    clear(key: string) {
        localStorage.removeItem(key);
    }

    clearAll() {
        localStorage.clear();
    }
}
