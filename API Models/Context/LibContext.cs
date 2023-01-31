using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Models.Models;
using API_Project.Configs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace API_Models.Context
{
    public class LibContext : IdentityDbContext<User, Role, Guid>
    {
        public LibContext(DbContextOptions<LibContext> options) : base(options)
        {

        }
        public DbSet<Book>? Books { get; set; }
        public DbSet<Author>? Authors { get; set; }
       public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UserConfiguration());
            
        }


    }
}

   

