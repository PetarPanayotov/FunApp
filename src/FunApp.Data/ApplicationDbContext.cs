using System;
using System.Collections.Generic;
using System.Text;
using FunApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FunApp.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<FunAppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Joke> Jokes{ get; set; }
    }
}
