import {AfterViewInit, Component, OnInit, ViewEncapsulation} from '@angular/core';
import {FakeModel} from '../../models/FakeModel';
import {GenericDataService} from 'yashil-core';
import {EnvService} from '../../../../shared/services/env.service';
import {ReportDataService} from '../../services/report-data.service';

@Component({
  selector: 'ysh-spa-body',
  templateUrl: './spa-body.component.html',
  styleUrls: ['./spa-body.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class SpaBodyComponent implements OnInit, AfterViewInit {


  constructor(private genericDataService: GenericDataService, private env: EnvService, private reportDataService: ReportDataService) {
  }

  ngOnInit() {
    if (!this.reportDataService.groupItems || !this.reportDataService.groups) {
      this.genericDataService.getEntitiesWithAction(`${this.env.mode}Group`, `Get${this.env.mode}GroupList`, null).subscribe((res: any) => {
        this.reportDataService.groups = res;
      });
      this.genericDataService.getEntitiesWithAction(`${this.env.mode}Store`, `Get${this.env.mode}List`, null)
        .subscribe((res: any) => {
          this.reportDataService.groupItems = res;
        });
    }
  }

  ngAfterViewInit(): void {
  }


}
