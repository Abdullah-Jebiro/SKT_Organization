import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ClinicService {

  constructor(private http: HttpClient) { }

  getClinics() {
    const url = 'https://localhost:7052/api/Booking/Clinics';
    return this.http.get(url)
      .pipe(
        catchError(error => {
          console.log('Error: Could not connect to server.', error);
          return throwError(error.message);
        })
      );
  }
}