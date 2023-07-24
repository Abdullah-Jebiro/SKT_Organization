using AutoMapper;
using Data.Migrations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Model;
using Model.DbEntities;
using Model.Dtos;
using Services.BookingRepo;
using System.Net;
using Booking = Model.DbEntities.Booking;

namespace WebApi.Controllers
{
    [Route("api/Booking")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _booking;
        private readonly IMapper _mapper;

        public BookingController(IBookingRepository booking, IMapper mapper)
        {
            _booking = booking;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult> checkReservationStatus([FromQuery]string iPAddress)
        {
            var reservationStatus = await _booking.checkReservationStatus(iPAddress);      
            return Ok(reservationStatus);

        }


        [HttpPost]
        public async Task<ActionResult>Add(BookingForAddDto dto)
        {
            var booking = _mapper.Map<Booking>(dto);
            await _booking.AddBooking(booking);
            return Ok();
        }



        [HttpDelete]
        public async Task<ActionResult> DeleteBooking(string iPAddress)
        {
            await _booking.DeleteBooking(iPAddress);
            return NoContent();
        }

        [HttpGet("Clinics")]
        public async Task<ActionResult> GetClinics()
        {
               
            var Clinics = await _booking.GetClinicsForBooking();
            if (Clinics == null)
            {
                return NotFound();
            }
            return Ok(Clinics);
        }

        [HttpGet("Clinics/{clinicsId}")]
        public async Task<ActionResult> GetClinics(int clinicsId)
        {

            var Clinics = await _booking.GetPatientsForDotor(clinicsId);
            if (Clinics == null)
            {
                return NotFound();
            }
            return Ok(Clinics);
        }

        [HttpGet("Schedules")]
        public async Task<ActionResult> GetSchedules()
        {
            var Schedules = await _booking.GetSchedules();
            if (Schedules == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<List<ScheduleDto>>(Schedules));
        }
    }
}
