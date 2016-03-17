using System.Threading.Tasks;
using AutoMapper;
using BookFast.Common;
using BookFast.Data.Models;
using Facility = BookFast.Business.Models.Facility;

namespace BookFast.Data.Commands
{
    internal class CreateFacilityCommand : ICommand<BookFastContext>
    {
        private readonly Facility facility;
        private readonly IMapper mapper;

        public CreateFacilityCommand(Facility facility, IMapper mapper)
        {
            this.facility = facility;
            this.mapper = mapper;
        }

        public Task ApplyAsync(BookFastContext model)
        {
            model.Facilities.Add(mapper.Map<Models.Facility>(facility));
            return model.SaveChangesAsync();
        }
    }
}