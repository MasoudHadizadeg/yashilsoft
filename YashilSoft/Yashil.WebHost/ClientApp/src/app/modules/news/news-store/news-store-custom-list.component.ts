import {Component, Input, OnInit, ViewChild} from '@angular/core';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {CachedDataService} from '../../../shared/services/cached-data.service';
import {NewsStoreListComponent} from './news-store-list.component';


@Component({
    selector: 'app-news-store-custom-list',
    templateUrl: './news-store-custom-list.component.html'
})
export class NewsStoreCustomListComponent implements OnInit {
    @ViewChild('listForm', {static: true}) listForm: NewsStoreListComponent;
    contentHeight: number;
    selectedServiceId: number;
    @Input()
    newsType: number;

    constructor(private genericDataService: GenericDataService, private cachedDataService: CachedDataService) {
        this.contentHeight = window.innerHeight - 110;
        this.selectedServiceChanged = this.selectedServiceChanged.bind(this);
    }

    ngOnInit(): void {
    }

    selectedServiceChanged(item: any) {
        this.selectedServiceId = item.id;
        this.listForm.serviceId = this.selectedServiceId;
        this.listForm.bindCustomDataSources();
    }
}
