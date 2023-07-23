using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.DbEntities;
using Model.Dtos;
using Services.BookingRepo;
using System.Net;

namespace WebApi.Controllers
{
    [Route("api/Clinics")]
    [ApiController]
    public class ClinicsController : ControllerBase
    {
        private readonly IBookingRepository _booking;
        private readonly IMapper _mapper;

        public ClinicsController(IBookingRepository booking, IMapper mapper)
        {
            _booking = booking;
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<ActionResult> GetClinics()
        {
            var Clinics = await _booking.GetClinicsForBooking();
            if (Clinics == null)
            {
                return NotFound();
            }
            return Ok(Clinics);
        }

      
    }
}
