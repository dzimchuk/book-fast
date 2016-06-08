using BookFast.Contracts;
using BookFast.Contracts.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BookFast.Controllers
{
    [Authorize(Policy = "Facility.Write")]
    public class FileAccessController : Controller
    {
        private readonly IFileAccessProxy proxy;

        public FileAccessController(IFileAccessProxy proxy)
        {
            this.proxy = proxy;
        }
        
        [HttpGet("/api/facilities/{id}/image-token")]
        public async Task<IActionResult> GetFacilityImageUploadToken(Guid id, [FromQuery]string originalFileName)
        {
            try
            {
                if (string.IsNullOrEmpty(originalFileName))
                    throw new ArgumentNullException(nameof(originalFileName));

                var token = await proxy.IssueFacilityImageUploadTokenAsync(id, originalFileName);
                return Ok(token);
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
            catch (FacilityNotFoundException)
            {
                return NotFound();
            }
        }
        
        [HttpGet("/api/accommodations/{id}/image-token")]
        public async Task<IActionResult> GetAccommodationImageUploadToken(Guid id, [FromQuery]string originalFileName)
        {
            try
            {
                if (string.IsNullOrEmpty(originalFileName))
                    throw new ArgumentNullException(nameof(originalFileName));

                var token = await proxy.IssueAccommodationImageUploadTokenAsync(id, originalFileName);
                return Ok(token);
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
            catch (AccommodationNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
