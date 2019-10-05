using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPICoreMiniProject.Models
{
    public class AddressBookContext : DbContext
    {
        public AddressBookContext(DbContextOptions<AddressBookContext> options)
            : base(options)
        { }

        public DbSet<AddressModel> Addresses { get; set; }
        public DbSet<PersonModel> People { get; set; }
    }
}
