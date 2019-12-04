import {BehaviorSubject, Observable} from 'rxjs';
import {Component, Input} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import 'rxjs-compat/add/operator/switchMap';
import 'rxjs-compat/add/operator/map';

@Component({
    selector: 'app-secured-image',
    template: `
        <img [src]="imageData"/>
    `
})
export class SecuredImageComponent {
    // This code block just creates an rxjs stream from the src
    imageData: any;
    // <img [src]="dataUrl$|async" />
    _base64ImgUrl: string;
    @Input() private src: string;

    @Input()
    set base64ImgUrl(val) {
        this._base64ImgUrl = val;
        this.getImageFromService(val);
    }

    get base64ImgUrl(): string {
        return this._base64ImgUrl;
    }

    private src$ = new BehaviorSubject(this.src);
    // dataUrl$ = this.src$.switchMap(url => this.loadImage(url))
    // this makes sure that we can handle source changes
    // or even when the component gets destroyed
    // this stream will contain the actual url that our img tag will load

    // So basically turn src into src$
    // ngOnChanges(): void {
    //     this.src$.next(this.src);
    // }
    // everytime the src changes, the previous call would be canceled and the
    // new resource would be loaded

    // we need HttpClient to load the image
    constructor(private httpClient: HttpClient) {
    }

    // private loadImage(url: string): Observable<any> {
    //     return this.httpClient
    //     // load the image as a blob
    //         .get(url, {responseType: 'blob'})
    //         // create an object url of that blob that we can use in the src attribute
    //         .map(e => URL.createObjectURL(e))
    // }

    getImage(imageUrl: string): Observable<Blob> {
        return this.httpClient.get(imageUrl, {responseType: 'blob'});
    }

    createImageFromBlob(image: Blob) {
        const reader = new FileReader();
        reader.addEventListener('load', () => {
            this.imageData = reader.result;
        }, false);

        if (image) {
            reader.readAsDataURL(image);
        }
    }

    getImageFromService(url) {
        this.getImage(url).subscribe(data => {
            this.createImageFromBlob(data);
        }, error => {
            console.log(error);
        });
    }
}
