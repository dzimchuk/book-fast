﻿using System.Threading.Tasks;
using BookFast.Contracts.Framework;
using BookFast.Data.Models;
using Accommodation = BookFast.Contracts.Models.Accommodation;

namespace BookFast.Data.Commands
{
    internal class CreateAccommodationCommand : ICommand<BookFastContext>
    {
        private readonly Accommodation accommodation;
        private readonly IAccommodationMapper mapper;

        public CreateAccommodationCommand(Accommodation accommodation, IAccommodationMapper mapper)
        {
            this.accommodation = accommodation;
            this.mapper = mapper;
        }

        public Task ApplyAsync(BookFastContext model)
        {
            model.Accommodations.Add(mapper.MapFrom(accommodation));
            return model.SaveChangesAsync();
        }
    }
}