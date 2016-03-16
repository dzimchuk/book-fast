using System;
using System.Threading.Tasks;
using AutoMapper;
using BookFast.Business;
using Microsoft.AspNet.Mvc;
using BookFast.ViewModels;
using Microsoft.AspNet.Authorization;

namespace BookFast.Controllers
{
    [Authorize]
    public class FacilityController : Controller
    {
        private readonly IFacilityService service;
        private readonly IMapper mapper;

        public FacilityController(IFacilityService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await service.ListByOwnerAsync(User.Identity.Name));
        }
        
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var facilityViewModel = mapper.Map<FacilityViewModel>(await service.FindAsync(id.Value));
            if (facilityViewModel == null)
            {
                return HttpNotFound();
            }

            return View(facilityViewModel);
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
                await service.CreateAsync(mapper.Map<Business.Models.Facility>(facilityViewModel));
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

            var facilityViewModel = mapper.Map<FacilityViewModel>(await service.FindAsync(id.Value));
            if (facilityViewModel == null)
            {
                return HttpNotFound();
            }

            return View(facilityViewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FacilityViewModel facilityViewModel)
        {
            if (ModelState.IsValid)
            {
                await service.UpdateAsync(mapper.Map<Business.Models.Facility>(facilityViewModel));
                return RedirectToAction("Index");
            }

            return View(facilityViewModel);
        }

        // GET: Facility/Delete/5
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var facilityViewModel = mapper.Map<FacilityViewModel>(await service.FindAsync(id.Value));
            if (facilityViewModel == null)
            {
                return HttpNotFound();
            }

            return View(facilityViewModel);
        }

        // POST: Facility/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
