import {Component, Input, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {IsEqual, NewsType} from '../news-enums';


@Component({
    selector: 'app-news-store-detail',
    templateUrl: './news-store-detail.component.html'
})
export class NewsStoreDetailComponent extends BaseEdit implements OnInit {
    @Input()
    serviceId: number;
    @Input()
    newsType: number;
    @Input()
    language: number;
    @Input()
    accessLevelId: number;
    serviceDataSource: any;
    newsTypes: any;
    languages: any;
    accessLevels: any[] = [];
    selectedNewsTypeTittle: string;
    isNews: boolean;

    constructor(private genericDataService: GenericDataService) {
        super(genericDataService);
        this.entityName = 'newsStore';
        this.selectedNewsTypeChanged = this.selectedNewsTypeChanged.bind(this);
    }

    ngOnInit() {
        super.ngOnInit();
        if (IsEqual(this.newsType, NewsType.Notification) || IsEqual(this.newsType, NewsType.Gallery)) {
            this.isNews = false;
        } else {
            this.isNews = true;
        }
        if (!this.selectedEntityId) {
            this.entity.language = 1073;
        }
        if (this.serviceId) {
            this.entity.serviceId = this.serviceId;
        }
        if (this.newsType) {
            this.entity.newsType = this.newsType;
        }
        if (this.language) {
            this.entity.language = this.language;
        }
        if (this.accessLevelId) {
            this.entity.accessLevelId = this.accessLevelId;
        }

        this.serviceDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'service');
        this._genericDataService.getCommonBaseDataForSelect('NewsType').subscribe(res => this.newsTypes = res);
        this._genericDataService.getCommonBaseDataForSelect('Language').subscribe(res => this.languages = res);
        this._genericDataService.getEntitiesByEntityNameForSelect(Entity.AccessLevel).subscribe(res => this.accessLevels = res);
    }

    selectedNewsTypeChanged(e) {
        if (e && e.selectedItem) {
            this.selectedNewsTypeTittle = e.selectedItem.title;
        }
    }
}
