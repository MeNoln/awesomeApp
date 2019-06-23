using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EF
{
    public class PostgreDbContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql("host=localhost;port=5432;database=appdb;username=app;password=app");
            optionsBuilder.UseNpgsql("host=postgres_image;port=5432;database=notedb;username=user;password=user");
        }
    }
}
