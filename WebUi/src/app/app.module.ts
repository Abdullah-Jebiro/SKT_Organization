import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot([
      {
        path: 'Home',
        loadChildren: () => import('./booking/booking.module').then((b) => b.BookingModule),
      },
      {
        path: '',
        loadChildren: () => import('./clinic/clinic.module').then((b) => b.ClinicModule),
      },

      { path: '', redirectTo: 'clinic', pathMatch: 'full' },
      { path: '**', redirectTo: 'clinic', pathMatch: 'full' },
    ]),
  ],
  providers: [],

  bootstrap: [AppComponent]
})
export class AppModule { }
