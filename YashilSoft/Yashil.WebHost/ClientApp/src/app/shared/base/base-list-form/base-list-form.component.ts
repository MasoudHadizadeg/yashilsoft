import {AfterViewInit, Component, OnInit} from '@angular/core';
import {BaseList} from '../classes/base-list';

@Component({
    selector: 'app-base-list-form',
    templateUrl: './base-list-form.component.html',
    styleUrls: ['./base-list-form.component.css']
})
export class BaseListFormComponent extends BaseList implements AfterViewInit, OnInit {
}
