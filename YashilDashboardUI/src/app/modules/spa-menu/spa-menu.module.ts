import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {SpaMenuRoutingModule} from './spa-menu-routing.module';
import {SpaHeaderComponent} from './components/spa-header/spa-header.component';
import {SpaBodyComponent} from './components/spa-body/spa-body.component';
import {SpaIndexComponent} from './pages/spa-index/spa-index.component';
import {SpaNavbarComponent} from './components/spa-navbar/spa-navbar.component';
import {SpaBodySectionComponent} from './components/spa-body-section/spa-body-section.component';
import {SpaCardTileComponent} from './components/spa-card-tile/spa-card-tile.component';
import {SharedModule} from '../../shared/shared.module';

@NgModule({
  declarations: [
    SpaHeaderComponent,
    SpaBodyComponent,
    SpaIndexComponent,
    SpaNavbarComponent,
    SpaBodySectionComponent,
    SpaCardTileComponent
  ],
  imports: [
    CommonModule,
    SpaMenuRoutingModule,
    SharedModule
  ],
  exports: []
})
export class SpaMenuModule {
}
