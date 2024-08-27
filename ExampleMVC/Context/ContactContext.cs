using ExampleMVC.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExampleMVC.Context
{
    public class ContactContext : DbContext
    {
        public ContactContext(
            DbContextOptions<ContactContext> options
        ) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
    }
}