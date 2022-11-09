using Microsoft.EntityFrameworkCore;

internal class PhoneBookContext : DbContext
{
    public DbSet<ContactClass> Contacts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\test;Database=PhoneBook;Trusted_Connection=True");
    }
}

