import { Injectable } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { observable, Observable, Subscription } from 'rxjs';
import { subscribeOn } from 'rxjs/operators';
import { ConfirmDialogComponent } from '../modals/confirm-dialog/confirm-dialog.component';

@Injectable({
  providedIn: 'root'
})
export class ConfirmService {
  BsModalRef: BsModalRef

  constructor(private modalService: BsModalService) { }

  confirm(title = 'Confirmation', 
    message = 'Are you sure ypu want to do this?',
    btnOkText = 'Ok', 
    btnCancelText = 'Cancel'): Observable<boolean>{
      const config = {
        initialState: {
          title,
          message,
          btnOkText,
          btnCancelText
        }
      }
      this.BsModalRef = this.modalService.show(ConfirmDialogComponent, config);
      return new Observable<boolean>(this.getResult());
  }

  private getResult(){
    return (observer) => {
      const subscription = this.BsModalRef.onHidden.subscribe(() => {
        observer.next(this.BsModalRef.content.result);
        observer.complete();
      })
      return {
        unsubscribe(){
          subscription.unsubscribe();
        }
      }
    }
    
  }
}
