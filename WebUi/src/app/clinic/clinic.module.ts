import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ScheduleComponent } from './schedule/schedule.component';
import { RouterModule } from '@angular/router';
import { ScheduleService } from './services/schedule.service';
import { HttpClientModule } from '@angular/common/http';



@NgModule({
  declarations: [
    ScheduleComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    RouterModule.forChild([
      {
        path: '', component:ScheduleComponent ,
        
      },
     
    ])
  ],
  providers: [
    ScheduleService,
  ]
})
export class ClinicModule { }
