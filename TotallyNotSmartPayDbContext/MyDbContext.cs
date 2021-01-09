using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TotallyNotSmartPayModels;

namespace TotallyNotSmartPayDbContext
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            :base(options)
        {

        }

        public MyDbContext()
        {

        }

        public DbSet<StoreInformation> StoreInformation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS01;Database=TotallyNotSmartPayDB;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
