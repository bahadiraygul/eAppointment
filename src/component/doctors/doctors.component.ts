import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { HttpService } from '../../app/service/http.service';
import { DoctorModel } from '../../app/models/doctor.model';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { departments } from '../../app/constants';
import { FormsModule, NgForm } from '@angular/forms';
import { FormValidateDirective } from 'form-validate-angular';
import { SwalService } from '../../app/service/swal.service';


@Component({
  selector: 'app-doctors',
  imports: [CommonModule, RouterLink, FormsModule, FormValidateDirective],
  templateUrl: './doctors.component.html',
  styleUrl: './doctors.component.css'
})
export class DoctorsComponent implements OnInit { 

@ViewChild('addModalCloseBtn') addModalCloseBtn: ElementRef<HTMLButtonElement> | undefined;

  doctors :  DoctorModel[] = [];
  departments = departments;

 createModel : DoctorModel = new DoctorModel();

  constructor( private http: HttpService,
    private swal : SwalService
  ) { }




  ngOnInit(): void {
    this.getAll();
    this.swal.callSwal("Title","text", () => {
      alert("Delete is successfull");});
  }
 
  getAll(){
    this.http.post<DoctorModel[]>('Doctors/GetAll', {}, res =>{
      this.doctors = res.data;
    });
  }

  add(form: NgForm){
    if(form.valid){
      this.http.post<string>('Doctors/Create', this.createModel, res => {
       this.swal.callToast(res.data, 'success');
       this.getAll();
       this.addModalCloseBtn?.nativeElement.click(); 
        this.createModel = new DoctorModel(); 
      }, err => {
        console.error('Error occurred while adding doctor:', err);
      });
    } else {
      console.warn('Form is invalid');
    }
  }
}
