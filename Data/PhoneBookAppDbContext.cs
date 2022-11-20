using Microsoft.EntityFrameworkCore;
using PhoneBookApp.Models;

namespace PhoneBookApp.Data;

public class PhoneBookAppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=PhoneBookAppDb;Trusted_Connection=True;MultipleActiveResultSets=true");
    }

    public DbSet<Contact> Contacts { get; set; }
}


