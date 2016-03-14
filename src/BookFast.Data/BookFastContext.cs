using BookFast.Business.Models;
using Microsoft.Data.Entity;

namespace BookFast.Data
{
    internal class BookFastContext : DbContext
    {
        public DbSet<Facility> Facilities { get; set; }
    }
}