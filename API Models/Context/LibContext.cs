using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace API_Models.Context
{
    public class LibContext : IdentityDbContext<User>
    {
        public LibContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Book>? Books { get; set; }
        public DbSet<Author>? Authors { get; set; }



    }
}

   

