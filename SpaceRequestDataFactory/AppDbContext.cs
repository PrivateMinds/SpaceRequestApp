using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceRequestDataFactory
{
   public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {

        }

        public DbSet<SpaceRequestDataModel.SpaceRequest> SpaceRequest { get; set; }
        public DbSet<SpaceRequestDataModel.viewuserid> viewuserid { get; set; }



    }
}
