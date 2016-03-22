﻿using System.Threading.Tasks;
using AutoMapper;
using BookFast.Contracts.Framework;
using BookFast.Data.Models;
using Accommodation = BookFast.Contracts.Models.Accommodation;

namespace BookFast.Data.Commands
{
    internal class CreateAccommodationCommand : ICommand<BookFastContext>
    {
        private readonly Accommodation accommodation;
        private readonly IMapper mapper;

        public CreateAccommodationCommand(Accommodation accommodation, IMapper mapper)
        {
            this.accommodation = accommodation;
            this.mapper = mapper;
        }

        public Task ApplyAsync(BookFastContext model)
        {
            model.Accommodations.Add(mapper.Map<Models.Accommodation>(accommodation));
            return model.SaveChangesAsync();
        }
    }
}