import {AfterViewInit, Component, EventEmitter, OnInit, Output} from '@angular/core';
import {BaseList} from '../classes/base-list';
import { NgModule } from '@angular/core';

@Component({
    selector: 'app-base-list-form',
    templateUrl: './base-list-form.component.html',
    styleUrls: ['./base-list-form.component.css']
})
export class BaseListFormComponent extends BaseList implements AfterViewInit, OnInit {

}
