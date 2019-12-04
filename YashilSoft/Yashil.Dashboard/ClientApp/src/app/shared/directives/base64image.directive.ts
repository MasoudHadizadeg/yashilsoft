import {Directive, ElementRef, Input} from '@angular/core';
import {Observable} from 'rxjs';
import {HttpClient} from '@angular/common/http';

@Directive({
    selector: '[appBase64image]'
})
export class Base64imageDirective {
    // This code block just creates an rxjs stream from the src
    imageData: any;
    // <img [src]="dataUrl$|async" />
    _base64ImgUrl: string;
    @Input() private src: string;

    @Input()
    set base64ImgUrl(val) {
        if (val && val !== '') {
            this._base64ImgUrl = val;
            this.getImageFromService(val);
        } else {
            this.imageData = null;
            this.el.nativeElement.src = '';
        }
    }

    get base64ImgUrl(): string {
        return this._base64ImgUrl;
    }

    constructor(private httpClient: HttpClient, private el: ElementRef) {
    }

    getImage(imageUrl: string): Observable<Blob> {
        return this.httpClient.get(imageUrl, {responseType: 'blob'});
    }

    createImageFromBlob(image: Blob) {
        const reader = new FileReader();
        reader.addEventListener('load', () => {
            this.imageData = reader.result;
            this.el.nativeElement.src = this.imageData;
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
