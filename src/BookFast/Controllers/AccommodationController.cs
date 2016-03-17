using System;
using System.Threading.Tasks;
using BookFast.Business;
using BookFast.Business.Exceptions;
using Microsoft.AspNet.Mvc;

namespace BookFast.Controllers
{
    public class AccommodationController : Controller
    {
        private readonly IAccommodationService service;
        private readonly IAccommodationMapper mapper;

        public AccommodationController(IAccommodationService service, IAccommodationMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            try
            {
                var accommodation = await service.FindAsync(id.Value);
                return View(mapper.MapFrom(accommodation));
            }
            catch (AccommodationNotFoundException)
            {
                return HttpNotFound();
            }
        }
    }
}