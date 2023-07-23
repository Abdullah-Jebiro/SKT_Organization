import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { catchError, throwError } from 'rxjs';
import { ClinicService } from '../services/clinic.service';
import { IClinic } from '../Model/IClinic';
import { async } from '@angular/core/testing';
import { BookingService } from '../services/Booking.service';
import { IReservationStatus } from '../Model/IReservationStatus';

@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.css'],
})
export class BookingComponent implements OnInit {
  bookingForm!: FormGroup;
  ipAddress!: string;
  clinics!: IClinic[];
  constructor(
    private clinicService: ClinicService,
    private bookingService: BookingService,
    private fb: FormBuilder,
    private http: HttpClient
  ) { }

  ngOnInit() {
    this.bookingForm = this.fb.group({
      fullName: ['', [Validators.required, Validators.maxLength(100)]],
      phoneNumber: [
        '',
        [
          Validators.required,
          Validators.minLength(2),
          Validators.maxLength(100),
        ],
      ],
      dateOfBirth: ['', Validators.required],
      gender: ['', Validators.required],
      clinicId: ['', Validators.required],
      ipAddress: ['202.001.584.9', Validators.required]
    });
    this.getClinics()
    this.getIPAddress();


    this.bookingService.reservationStatus('').subscribe(
      (response: IReservationStatus) => {
        if (response.stopping) {
          this.appendAlert(response.status + '\n' + response.stoppingTo, 'warning');
        }
      },
      (error) => {
        const errorMessage = error;
        console.log(errorMessage, 'danger');
      });
  }



  onSubmit() {
    this.bookingForm.patchValue({ ipAddress: this.ipAddress })
    this.bookingService.submitBooking(this.bookingForm.value).subscribe(
      (response: any) => {
        console.log('Booking successful.', 'success');
      },
      (error) => {
        const errorMessage = error;
        console.log(errorMessage, 'danger');
      }
    );
  }

  getClinics() {
    this.clinicService.getClinics().subscribe((data: any) => {
      this.clinics = data;
    });
  }

  getIPAddress() {
    this.ipAddress = '202.001.584.9'
  }

  appendAlert = (message: string, type: string) => {
    const alertPlaceholder = document.getElementById('div-message')!;
    const wrapper = document.createElement('div');
    wrapper.innerHTML = [
      `<div class="alert alert-${type} alert-dismissible" role="alert">`,
      `   <div>${message}</div>`,
      '   <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>',
      '</div>',
    ].join('');
    alertPlaceholder.append(wrapper);
  };

}
