import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ScheduleService {

  constructor(private http: HttpClient) { }

  getSchedule():Observable<any>{
    const url = 'https://localhost:7052/api/Booking/Schedules';
    return this.http.get(url)
      .pipe(
        catchError(error => {
          console.log('Error: Could not connect to server.', error);
          return throwError(error.message);
        })
      );
  }


  GetPatientsForDoctor(clinicId:number):Observable<any>{
    const url = 'https://localhost:7052/api/Booking/Clinics/'+clinicId;
    return this.http.get(url)
      .pipe( 
        catchError(error => {
          console.log('Error: Could not connect to server.', error);
          return throwError(error.message);
        })
      );
  }

  getClinics(): Observable<any[]> {
    const url = 'https://localhost:7052/api/Booking/Clinics';
    return this.http.get<any[]>(url).pipe(
      catchError((error) => {
        console.log('Error: Could not connect to server.', error);
        return throwError(error.message);
      })
    );
  }

}
