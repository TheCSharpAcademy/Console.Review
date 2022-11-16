using Microsoft.EntityFrameworkCore;
using PhoneBookApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp.Data
{
    public class PhoneBookAppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=PhoneBookAppDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<Contact> Contacts { get; set; }
    }

    
}
