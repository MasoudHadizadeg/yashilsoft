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
}
