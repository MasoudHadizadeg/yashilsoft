import {Component} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {DomSanitizer} from '@angular/platform-browser';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html'
})
export class HomeComponent {
    url = '';
    id = 3030;
    data: any;
    plainData: any;

    constructor(private httpClient: HttpClient, private sanitized: DomSanitizer) {
    }

    setUrl() {
        this.id++;
        this.url = 'api/person/getPersonPicture?id=' + this.id;

        this.httpClient.get(this.url).subscribe(x => {
            // this.plainData = this.sanitized.bypassSecurityTrustHtml('data:image/jpg;base64, ' + x.toString());
        });
    }
}
