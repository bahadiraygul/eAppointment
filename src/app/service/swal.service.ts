import { Injectable } from '@angular/core';
import { Title } from '@angular/platform-browser';
import Swal from 'sweetalert2';

@Injectable({
  providedIn: 'root'
})
export class SwalService {

  constructor() { }

  callToast(title:string , icon: SweetAlertIcon = 'success'){
    Swal.fire( {
      title: title,
      timer: 3000,
      icon: icon,
      showCancelButton: false,
      showCloseButton: false,
      showConfirmButton: false,
      position:"bottom-right",
      toast: true,
    });
}

  callSwal(title:string, text : string , callBack: () => void) {
    Swal.fire( {
      title: title,
      text: 'Are you sure?',
      icon: 'question',
      showConfirmButton: true,
      confirmButtonText: 'Delete',
      cancelButtonText: "Cancel",
      showCancelButton: true,

    }).then((result) => {
      if (result.isConfirmed) {
        callBack();
      }
    });
}
}


export type SweetAlertIcon = 'success' | 'error' | 'warning' | 'info' | 'question'