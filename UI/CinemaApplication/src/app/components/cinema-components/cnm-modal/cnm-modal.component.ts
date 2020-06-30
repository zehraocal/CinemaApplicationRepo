import { Component, OnInit, Output,EventEmitter, ViewChild, TemplateRef, Input, ContentChild } from '@angular/core';
import { NgbModal, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-cnm-modal',
  templateUrl: './cnm-modal.component.html'
})
export class CnmModalComponent implements OnInit {

  @Output() onConfirm = new EventEmitter();

  @ContentChild('saveTemplate', { static: false }) saveTemplate: TemplateRef<any>;
  @ContentChild('header', { static: false }) header: TemplateRef<any>;
  @ViewChild('classic', { static: false }) modalClassicRef: TemplateRef<any>;
  @ViewChild('dialog', { static: false }) modalDialogRef: TemplateRef<any>;
  
  constructor(private modalService: NgbModal) { }

  ngOnInit(): void {
   
  }

  confirm() {
    this.onConfirm.emit();
  }

  openDialog( ) {
    this.modalService.open(this.modalDialogRef);
  }
 



 
  
}
