using Data;
using Microsoft.EntityFrameworkCore;
using Model.DbEntities;
using Model.Dtos;
using System.ComponentModel;

namespace Services.BookingRepo
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;

        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }



        private static DayOfWeek GetDayForBooking()
        {
            if (DateTime.UtcNow.Hour >= 8)
            {
                return DateTime.UtcNow.AddDays(1).DayOfWeek;

            }
            else
            {
                return DateTime.UtcNow.DayOfWeek;
            }
        }


        public async Task AddBooking(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
        }
        public async Task<ReservationStatus> checkReservationStatus(string iPAddress)
        {
            int countBookings = await _context.Bookings.CountAsync(b => b.IPAddress == iPAddress && b.Date == DateTime.UtcNow.Date);
            var reservationStatus = new ReservationStatus();

            if (countBookings >= 3)
            {
                reservationStatus.Status = "قم بالحجز 3 مرات اليوم  \n يمكن الحجز مرة اخرة بعد";
                reservationStatus.stoppingTo = DateTime.UtcNow.Date.AddDays(1).AddHours(8).ToString("yyyy/MM/dd hh:mm");
                reservationStatus.stopping = true;
            }
            else
            {
                var temp = await _context.Bookings
                    .OrderByDescending(b=>b.Date)
                    .FirstOrDefaultAsync(b => b.IPAddress == iPAddress
                    && b.Date.AddMinutes(5) >DateTime.UtcNow);

                if (temp != null)
                {
                    reservationStatus.Status = "يمكن الحجز مرة اخرة في";
                    reservationStatus.stoppingTo = temp.Date.AddMinutes(5).ToString("yyyy/MM/dd hh:mm");
                    reservationStatus.stopping = true;
                }
                else
                {
                    reservationStatus.Status = "يمكن الحجز";
                }
            }

            return reservationStatus;
        }

        public async Task<List<Clinic>> GetClinicsForBooking()
        {
            return await _context.Permanence
                 .Where(p => p.DayOfWeek == GetDayForBooking()
                  && p.carryingCapacity > p.Clinic.Bookings.Count)
                 .Select(p=>p.Clinic)
                 .ToListAsync();
        }

      

        public async Task<List<Booking>> GetPatients()
        {
            return await _context.Bookings.ToListAsync();
        }

        public async Task DeleteBooking(string iPAddress)
        {
            var booking = await _context.Bookings
                .OrderByDescending(b => b.Date)
                .FirstOrDefaultAsync(p => p.IPAddress == iPAddress);

            if (booking != null)
            {
                _context.Bookings.Remove(booking);
            }

        }

        public Task DeleteBooking(int bookingId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Clinic>> GetClinics()
        {
           return await _context.Clinics.ToListAsync();
        }

        public async Task AddClinics(Clinic clinic)
        {
            _context.Clinics.Add(clinic);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClinics(int clinicId)
        {
            var clinic = await _context.Clinics
                .SingleOrDefaultAsync(c=>c.ClinicId==clinicId);
            if (clinic != null)
            {
                _context.Clinics.Remove(clinic);
                await _context.SaveChangesAsync();
            }
          
        }

        public async Task UpdateClinics(Clinic clinic)
        {       
            if (clinic != null)
            {
                _context.Clinics.Update(clinic);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Clinic?> GetClinic(int clinicId)
        {
            return await _context.Clinics
            .SingleOrDefaultAsync(c => c.ClinicId == clinicId);

        }

        public async Task<List<Booking>> GetPatientsForDotor(int clinicId)
        {
            return await _context.Bookings
           .Where(c => c.ClinicId == clinicId
            && c.Date.AddDays(1).DayOfWeek > DateTime.UtcNow.DayOfWeek)
           .ToListAsync();
        }

        public Task<List<Booking>> GetBookingForMonitoring(int? clinicId , DateTime? date)
        {
            throw new NotImplementedException();
        }

        public Task<Clinic?> GetClinic()
        {
            throw new NotImplementedException();
        }

        public Task<List<Booking>> GetBookingForMonitoring(int? clinicId)
        {
            throw new NotImplementedException();
        }
    }
}