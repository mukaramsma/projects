using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SalesManagementSystem.BusinessLayer.Models;

namespace SalesManagementSystem.BusinessLayer.DbContext
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<SaleInfo> SalesInfo { get; private set; }
        public DbSet<Location> Locations { get; private set; }
    }
}
