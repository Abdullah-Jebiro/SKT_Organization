
using Model.DbEntities;
using Model.Dtos;
using System.Net;

namespace Services.BookingRepo
{
    public interface IBookingRepository
    {
        Task AddBooking(Booking booking);
        Task DeleteBooking(string iPAddress);
        Task DeleteBooking(int bookingId);
        Task<List<Clinic>> GetClinicsForBooking();
        Task<List<Booking>> GetPatients();
        Task<ReservationStatus> checkReservationStatus(string iPAddress);

        Task<List<Clinic>> GetClinics();
        Task AddClinics(Clinic clinic);
        Task DeleteClinics(int clinicId);
        Task UpdateClinics(Clinic clinic);
        Task<Clinic?> GetClinic();
        Task<List<Booking>> GetPatientsForDotor(int clinicId);
        Task<List<Booking>> GetBookingForMonitoring(int? clinicId);

    }
}