import {Component, OnInit} from '@angular/core';
import {FormGroup} from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';
import {User} from '../../../_models';
import {AuthenticationService} from '../../../_services';
import {first} from 'rxjs/operators';
import {YashilComponent} from '../../../core/baseClasses/yashilComponent';
import {CachedKey} from '../../tms/tms-enums';
import {UserExtenderService} from '../../../shared/services/user-extender.service';
import {CachedDataService} from '../../../shared/services/cached-data.service';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';

@Component({
    selector: 'app-login-page',
    templateUrl: './login-page.component.html',
    styleUrls: ['./login-page.component.css']
})

export class LoginPageComponent extends YashilComponent implements OnInit {
    loginForm: FormGroup;
    loading = false;
    submitted = false;
    returnUrl: string;
    error = '';
    userLogin: User;

    constructor(
        private userExtenderService: UserExtenderService,
        private cachedDataService: CachedDataService,
        private genericDataService: GenericDataService,
        private route: ActivatedRoute,
        private router: Router,
        private authenticationService: AuthenticationService) {
        super();
        this.userLogin = new User();
    }

    ngOnInit() {
        // reset login status
        this.authenticationService.logout();

        // get return url from route parameters or default to '/'
        this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    }

    // convenience getter for easy access to form field

    onSubmit() {
        this.setBusy(true);
        this.submitted = true;

        // stop here if form is invalid
        // if (this.loginForm.invalid) {
        //   return;
        // }

        this.loading = true;
        this.authenticationService.login(this.userLogin.username, this.userLogin.password)
            .pipe(first())
            .subscribe(
                data => {
                    this.setBusy(false);
                    this.setUserAdditionalInfo();
                },
                error => {
                    this.error = error;
                    this.loading = false;
                    this.setBusy(false);
                }
            );
    }

    // On Forgot password link click
    onForgotPassword() {
        this.router.navigate(['forgotpassword'], {relativeTo: this.route.parent});
    }

    // On registration link click
    onRegister() {
        this.router.navigate(['register'], {relativeTo: this.route.parent});
    }

    private setUserAdditionalInfo() {
        this.genericDataService.getCustomEntitiesByUrl(`api/AdditionalUserProp/GetCurrentUserAdditionalProp`).subscribe((res: any) => {
            this.cachedDataService.setData(CachedKey.AdditionalUserProp, res);
            this.router.navigate([this.returnUrl]);
        });
    }
}
