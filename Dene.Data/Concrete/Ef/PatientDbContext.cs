﻿using Dene.Entity.Concrete.Models;
using Microsoft.EntityFrameworkCore;


namespace Dene.Data.Concrete.Ef
{
    public class PatientDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-R4ITLSH; Initial Catalog=DenemeDbContext; Integrated Security=True; TrustServerCertificate=True");
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MailVerify> MailVerifys { get; set; }
    }
}
