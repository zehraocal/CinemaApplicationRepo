import { Component, OnInit, ViewChild } from '@angular/core';
import { HttpService } from 'app/services/http.service';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { Session } from 'app/entities/session';
import { SessionAddVM } from 'app/entities/session-add-vm';
import { SessionUpdateVM } from 'app/entities/session-update-vm';
import { CnmModalComponent } from '../cinema-components/cnm-modal/cnm-modal.component';
import { CnmConfirmDialogComponent } from '../cinema-components/cnm-confirm-dialog/cnm-confirm-dialog.component';
import { SessionGetVM } from 'app/entities/session-get-vm';

@Component({
  selector: 'app-session',
  templateUrl: './session.component.html',
})
export class SessionComponent implements OnInit {

  Sessions: Session[];
  sorgulandi= false;
  record: any = {};
  criteria: any = {};
  updateId:number;
  deleteId:number;
  cols:any[];
  
  @ViewChild(CnmConfirmDialogComponent, { static: false }) dialogComponentRef: CnmConfirmDialogComponent;
  @ViewChild('UpdateViewComponent', { static: false }) UpdateViewComponentRef: CnmModalComponent;
  @ViewChild('addViewComponent', { static: false }) AddViewComponentRef: CnmModalComponent;

  constructor(private httpService: HttpService, private modalService: NgbModal) { }

  ngOnInit(): void {
    this.cols = [
      { field: 'startTime', header: 'Başlama Zamanı' },
      { field: 'endTime', header: 'Bitiş Zamanı' }

    ];
  }

  getSession(){
    debugger
    let sessionParam: SessionGetVM = new SessionGetVM();
    sessionParam.StartTime = this.criteria.time;

    this.httpService.post<SessionGetVM , any>("Session", sessionParam, "GetSession").subscribe(data => {
      this.Sessions = data;
      this.sorgulandi = true;
    });
  }

  addSession(){
    debugger
   let session: SessionAddVM=new SessionAddVM();
   session.EndTime=this.record.addEndTime;
   session.StartTime=this.record.addStartTime;

   this.httpService.post<SessionAddVM, any>("Session",session,"AddSession").subscribe(data => {
    if (data)
      this.getSession();
    this.modalService.dismissAll();
  });
  }

  openAddDialog() {
    this.AddViewComponentRef.openDialog();
  }
 
  updateSession(){
    let updateSession: SessionUpdateVM=new SessionUpdateVM();
    updateSession.id=this.updateId;
    updateSession.StartTime=this.record.StartTime;
    updateSession.EndTime=this.record.EndTime;

    this.httpService.put<SessionUpdateVM, any>("Session", updateSession, "UpdateSession").subscribe(updatedata => {
      this.updateSession = updatedata;
      this.getSession();
      this.modalService.dismissAll();
    })
  }

  openUpdateDialog( selectedSession, id: number) {
    debugger
    this.updateId = id;
    this.record.StartTime = selectedSession.StartTime;
    this.record.EndTime = selectedSession.EndTime;
    
    this.UpdateViewComponentRef.openDialog();
  }

  deleteSession() {
    this.httpService.delete<any>("Session", this.deleteId, "DeleteSession").subscribe(data => {
      this.getSession();
      this.modalService.dismissAll();
    })
  }

  openDeleteDialog(id: number) {
    this.deleteId = id;
    this.dialogComponentRef.openDeleteDialog('sm');
  }

  
  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }
  cleanSelectedSession() {
    this.criteria.time = "";
  }


}
