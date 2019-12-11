import {Component, ViewChild} from '@angular/core';
import {NgForm} from '@angular/forms';
import {DxFormComponent} from 'devextreme-angular';

@Component({
    selector: 'app-register-page',
    templateUrl: './register-page.component.html',
    styleUrls: ['./register-page.component.scss']
})

export class RegisterPageComponent {
    @ViewChild('f' ) registerForm: NgForm;

    //  On submit click, reset field value
    onSubmit() {
        this.registerForm.reset();
    }
}
