import {AfterViewInit, Component, EventEmitter, Input, OnInit, Output} from '@angular/core';

@Component({
  selector: 'app-base-edit-form',
  templateUrl: './base-edit-form.component.html'
})
export class BaseEditFormComponent implements OnInit {
  @Input()
  allowSave = true;
  @Input()
  showCloseButton = true;
  @Output() closeFormClick = new EventEmitter<boolean>();
  @Output() submitEvent = new EventEmitter<string>();
  formHeight: number;

  onFormSubmit(e) {
    this.submitEvent.next(e);
  }

  onCloseForm(e): void {
    this.closeFormClick.next(true);
  }

  ngOnInit(): void {
    this.formHeight = window.innerHeight - 150;
  }
}
