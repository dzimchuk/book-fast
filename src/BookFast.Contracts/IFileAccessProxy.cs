using System;
using System.Threading.Tasks;
using BookFast.Contracts.Files;

namespace BookFast.Contracts
{
    public interface IFileAccessProxy
    {
        Task<FileAccessToken> IssueAccommodationImageUploadTokenAsync(Guid accommodationId, string originalFileName);
        Task<FileAccessToken> IssueFacilityImageUploadTokenAsync(Guid facilityId, string originalFileName);
    }
}