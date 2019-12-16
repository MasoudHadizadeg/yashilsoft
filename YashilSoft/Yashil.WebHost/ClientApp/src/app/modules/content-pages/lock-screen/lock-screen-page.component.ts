import {Component, ViewChild} from '@angular/core';
import {NgForm} from '@angular/forms';
import {DxFormComponent} from 'devextreme-angular';

@Component({
    selector: 'app-lock-screen-page',
    templateUrl: './lock-screen-page.component.html',
    styleUrls: ['./lock-screen-page.component.scss']
})

export class LockScreenPageComponent {
    @ViewChild('f', { static: false }) lockScreenForm: NgForm;

    onSubmit() {
        this.lockScreenForm.reset();
    }
}
