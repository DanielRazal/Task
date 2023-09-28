import { Injectable } from '@angular/core';
import Swal from 'sweetalert2';

@Injectable({
  providedIn: 'root'
})
export class AlertService {

  constructor() { }

  showEmailInput(): Promise<any> {
    return Swal.fire({
      title: 'Send Email',
      text: 'Please enter your email:',
      input: 'email',
      showCancelButton: true,
      confirmButtonText: 'Send',
      cancelButtonText: 'Cancel',
      inputValidator: (value: any) => {
        if (!value) {
          return 'The Email field is required.';
        }
        return null;
      }
    });
  }

  success(title: string, content: string, footer: string): Promise<any> {
    return Swal.fire({
      icon: 'success',
      title: title,
      text: content,
      footer: footer
    });
  }

}
