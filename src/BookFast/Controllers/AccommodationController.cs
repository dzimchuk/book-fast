using System;
using System.Threading.Tasks;
using BookFast.Business;
using BookFast.Contracts;
using BookFast.Contracts.Exceptions;
using BookFast.ViewModels;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace BookFast.Controllers
{
    [Authorize(Policy = "FacilityProviderOnly")]
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

        public async Task<IActionResult> Edit(Guid? id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AccommodationViewModel accommodationViewModel)
        {
            if (ModelState.IsValid)
            {
                var details = mapper.MapFrom(accommodationViewModel);
                try
                {
                    await service.UpdateAsync(accommodationViewModel.Id, details);
                    return RedirectToAction("details", "facility", new { id = accommodationViewModel.FacilityId });
                }
                catch (AccommodationNotFoundException)
                {
                    return HttpNotFound();
                }
                catch (FacilityNotFoundException)
                {
                    return HttpNotFound();
                }
            }

            return View(accommodationViewModel);
        }

        public IActionResult Create(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ViewBag.FacilityId = id.Value;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Guid? id, AccommodationViewModel accommodationViewModel)
        {
            if (ModelState.IsValid)
            {
                var details = mapper.MapFrom(accommodationViewModel);
                try
                {
                    await service.CreateAsync(accommodationViewModel.FacilityId, details);
                    return RedirectToAction("details", "facility", new { id = accommodationViewModel.FacilityId });
                }
                catch (FacilityNotFoundException)
                {
                    return HttpNotFound();
                }
            }

            ViewBag.FacilityId = accommodationViewModel.FacilityId;
            return View(accommodationViewModel);
        }

        public async Task<IActionResult> Delete(Guid? id)
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

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, [FromForm]Guid facilityId)
        {
            try
            {
                await service.DeleteAsync(id);
                return RedirectToAction("details", "facility", new { id = facilityId });
            }
            catch (AccommodationNotFoundException)
            {
                return HttpNotFound();
            }
        }
    }
}