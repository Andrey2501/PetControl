using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Vaccination> Vaccinations { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<MedicalHistory> MedicalHistories { get; set; }
    }
}
