using System;
using System.Threading.Tasks;
using BookFast.Business;
using BookFast.Business.Exceptions;
using Microsoft.AspNet.Mvc;
using BookFast.ViewModels;
using Microsoft.AspNet.Authorization;

namespace BookFast.Controllers
{
    [Authorize]
    public class FacilityController : Controller
    {
        private readonly IFacilityService service;
        private readonly IFacilityMapper mapper;

        public FacilityController(IFacilityService service, IFacilityMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var facilities = await service.ListAsync();
            return View(mapper.MapFrom(facilities));
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            try
            {
                var facility = await service.FindAsync(id.Value);
                return View(mapper.MapFrom(facility));
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
                var details = mapper.MapFrom(facilityViewModel);

                await service.CreateAsync(details);
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
                var facility = await service.FindAsync(id.Value);
                return View(mapper.MapFrom(facility));
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
                var details = mapper.MapFrom(facilityViewModel);

                try
                {
                    await service.UpdateAsync(facilityViewModel.Id, details);
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
                var facility = await service.FindAsync(id.Value);
                return View(mapper.MapFrom(facility));
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
                await service.DeleteAsync(id);
                return RedirectToAction("Index");
            }
            catch (FacilityNotFoundException)
            {
                return HttpNotFound();
            }
        }
    }
}
