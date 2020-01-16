import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {NotFoundComponent} from './shared/components/not-found/not-found.component';
import {ContentLayoutComponent} from './layouts/content/content-layout.component';
import {AuthGuard, GenericDataService, JwtInterceptor} from 'yashil-core';
import {SharedModule} from './shared/shared.module';

@NgModule({
  declarations: [
    AppComponent,
    NotFoundComponent,
    ContentLayoutComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    SharedModule.forRoot()
  ],
  providers: [
    AuthGuard,
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
