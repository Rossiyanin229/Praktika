using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;

namespace PhoneBook
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // ВНИМАНИЕ: Двойной слеш перед SQLEXPRESS02 обязателен!
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS02;Database=PhoneBookDb;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
