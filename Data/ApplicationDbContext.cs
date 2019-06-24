using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using market.Models;

namespace market
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
     {
         public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
         {
             
         }

         protected override void OnModelCreating(ModelBuilder builder){

              base.OnModelCreating(builder);
              builder.Entity<IdentityRole>().HasData(
                  new { Id = "1" , Name = "Admin" ,NormalizedName= "Admin" },
                  new { Id = "2" , Name = "Customer" ,NormalizedName= "Customer" },
                  new { Id = "3" , Name = "Moderator" ,NormalizedName= "Moderator" }

              );


         }
             public DbSet<ProductModel> products {get; set;}

    }

}