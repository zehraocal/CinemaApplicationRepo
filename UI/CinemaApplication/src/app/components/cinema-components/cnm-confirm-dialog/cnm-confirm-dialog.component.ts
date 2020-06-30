import { Component, OnInit, Output, EventEmitter, ViewChild, TemplateRef, Input } from '@angular/core';
import { NgbModal, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-cnm-confirm-dialog',
  templateUrl: './cnm-confirm-dialog.component.html'
})
export class CnmConfirmDialogComponent implements OnInit {

  @Output() onConfirm = new EventEmitter();

  @ViewChild('modal_mini', { static: false }) modalMiniRef: TemplateRef<any>;

  closeResult: string;

  constructor(private modalService: NgbModal) { }

  ngOnInit(): void {
  }

  confirm() {
    this.onConfirm.emit();
  }

  openDeleteDialog(modalDimension) {
    let options = <NgbModalOptions>{ size: modalDimension };
    this.modalService.open(this.modalMiniRef, options);
  }
}
