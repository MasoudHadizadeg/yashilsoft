import {Component, OnDestroy, OnInit} from '@angular/core';
import {Subscription} from 'rxjs';
import {NavigationEnd, Router} from '@angular/router';
import {filter} from 'rxjs/operators';
import {loadMessages, locale} from 'devextreme/localization';
import {Message} from '../devextreme/localization/messages/message';
import {CachedDataService} from './shared/services/cached-data.service';
import {GenericDataService} from './shared/base/services/generic-data.service';
import {CachedKey} from './modules/tms/tms-enums';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html'
})
export class AppComponent implements OnInit, OnDestroy {

    subscription: Subscription;

    constructor(private router: Router) {
        loadMessages(Message.messages)
        locale('en');
    }

    ngOnInit() {
        this.subscription = this.router.events
            .pipe(filter(event => event instanceof NavigationEnd))
            .subscribe(() => window.scrollTo(0, 0));
    }

    ngOnDestroy() {
        if (this.subscription) {
            this.subscription.unsubscribe();
        }
    }
}
