import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {DomSanitizer} from '@angular/platform-browser';
import ArrayStore from 'devextreme/data/array_store';


@Component({
    selector: 'app-dashboard-store-detail',
    templateUrl: './dashboard-store-detail.component.html'
})
export class DashboardStoreDetailComponent extends BaseEdit implements OnInit {
    accessLevelDataSource: any;
    connectionStrings: any;
    imgBase64: any;

    constructor(private genericDataService: GenericDataService, private sanitizer: DomSanitizer) {
        super(genericDataService);
        this.entityName = 'dashboardStore';
        this.connectionStrings = new ArrayStore();
    }

    ngOnInit() {
        super.ngOnInit();
        this.accessLevelDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'accessLevel');
        this._genericDataService.getEntitiesByEntityNameForSelect(Entity.YashilConnectionString).subscribe(res =>
            this.connectionStrings = new ArrayStore({
                data: res['data'],
                key: 'id'
            })
        );
    }

    afterLoadData(res: any): any {
        if (res.picture) {
            this.imgBase64 = this.sanitizer.bypassSecurityTrustResourceUrl(atob(res.picture));
        }
    }

    showImage(files) {
        const that = this;
        if (files && files[0]) {
            const reader = new FileReader();
            reader.onload = function (e) {
                that.imgBase64 = that.sanitizer.bypassSecurityTrustResourceUrl(e.target['result']);
                that.entity.picture = atob(that.imgBase64);
            }
            reader.readAsDataURL(files[0]);
        }
    }
}
