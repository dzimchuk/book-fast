using System;
using System.Threading.Tasks;
using BookFast.Contracts;
using BookFast.Contracts.Exceptions;
using BookFast.ViewModels;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace BookFast.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {
        private readonly IBookingService bookingService;
        private readonly IBookingMapper mapper;
        private readonly IAccommodationService accommodationService;

        public BookingController(IBookingService bookingService, IBookingMapper mapper, IAccommodationService accommodationService)
        {
            this.bookingService = bookingService;
            this.mapper = mapper;
            this.accommodationService = accommodationService;
        }

        public async Task<IActionResult> Index()
        {
            var bookings = await bookingService.ListPendingAsync();
            return View(mapper.MapFrom(bookings));
        }

        public async Task<IActionResult> Create(Guid id)
        {
            try
            {
                var accommodation = await accommodationService.FindAsync(id);

                ViewBag.AccommodationId = accommodation.Id;
                ViewBag.AccommodationName = accommodation.Details.Name;
                return View();
            }
            catch (AccommodationNotFoundException)
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBookingViewModel booking)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var details = mapper.MapFrom(booking);
                    await bookingService.BookAsync(booking.AccommodationId, details);
                    return RedirectToAction("Index");
                }

                var accommodation = await accommodationService.FindAsync(booking.AccommodationId);
                ViewBag.AccommodationId = accommodation.Id;
                ViewBag.AccommodationName = accommodation.Details.Name;
                return View(booking);
            }
            catch (AccommodationNotFoundException)
            {
                return HttpNotFound();
            }
        }

        public async Task<IActionResult> Cancel(Guid id)
        {
            try
            {
                var booking = await bookingService.FindAsync(id);
                return View(mapper.MapFrom(booking));
            }
            catch (BookingNotFoundException)
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Cancel")]
        public async Task<IActionResult> CancelConfirmed(Guid id)
        {
            try
            {
                await bookingService.CancelAsync(id);
                return RedirectToAction("Index");
            }
            catch (BookingNotFoundException)
            {
                return HttpNotFound();
            }
            catch (UserMismatchException)
            {
                return HttpBadRequest();
            }
        }
    }
}