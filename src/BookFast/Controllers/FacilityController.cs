using System;
using System.Threading.Tasks;
using BookFast.Business;
using BookFast.Contracts;
using BookFast.Contracts.Exceptions;
using Microsoft.AspNet.Mvc;
using BookFast.ViewModels;
using Microsoft.AspNet.Authorization;

namespace BookFast.Controllers
{
    [Authorize(Policy = "FacilityProviderOnly")]
    public class FacilityController : Controller
    {
        private readonly IFacilityService facilityService;
        private readonly IFacilityMapper facilityMapper;

        private readonly IAccommodationService accommodationService;
        private readonly IAccommodationMapper accommodationMapper;

        public FacilityController(IFacilityService facilityService, IFacilityMapper facilityMapper, 
            IAccommodationService accommodationService, IAccommodationMapper accommodationMapper)
        {
            this.facilityService = facilityService;
            this.facilityMapper = facilityMapper;
            this.accommodationService = accommodationService;
            this.accommodationMapper = accommodationMapper;
        }

        public async Task<IActionResult> Index()
        {
            var facilities = await facilityService.ListAsync();
            return View(facilityMapper.MapFrom(facilities));
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            try
            {
                var facility = await facilityService.FindAsync(id.Value);
                var accommodations = await accommodationService.ListAsync(facility.Id);
                return View(new FacilityDetailsViewModel
                            {
                                Facility = facilityMapper.MapFrom(facility),
                                Accommodations = accommodationMapper.MapFrom(accommodations)
                            });
            }
            catch (FacilityNotFoundException)
            {
                return HttpNotFound();
            }
        }
        
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FacilityViewModel facilityViewModel)
        {
            if (ModelState.IsValid)
            {
                var details = facilityMapper.MapFrom(facilityViewModel);

                await facilityService.CreateAsync(details);
                return RedirectToAction("Index");
            }
            return View(facilityViewModel);
        }
        
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            try
            {
                var facility = await facilityService.FindAsync(id.Value);
                return View(facilityMapper.MapFrom(facility));
            }
            catch (FacilityNotFoundException)
            {
                return HttpNotFound();
            }
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FacilityViewModel facilityViewModel)
        {
            if (ModelState.IsValid)
            {
                var details = facilityMapper.MapFrom(facilityViewModel);

                try
                {
                    await facilityService.UpdateAsync(facilityViewModel.Id, details);
                    return RedirectToAction("Index");
                }
                catch (FacilityNotFoundException)
                {
                    return HttpNotFound();
                }
            }

            return View(facilityViewModel);
        }
        
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            try
            {
                var facility = await facilityService.FindAsync(id.Value);
                return View(facilityMapper.MapFrom(facility));
            }
            catch (FacilityNotFoundException)
            {
                return HttpNotFound();
            }
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                await facilityService.DeleteAsync(id);
                return RedirectToAction("Index");
            }
            catch (FacilityNotFoundException)
            {
                return HttpNotFound();
            }
        }
    }
}
