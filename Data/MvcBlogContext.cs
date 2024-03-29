using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using dotnet_mvc.Models;

namespace dotnet_mvc.Data
{
    public class MvcBlogContext : IdentityDbContext<IdentityUser>
    {
        public MvcBlogContext(DbContextOptions<MvcBlogContext> options)
            : base(options)
        {
        }

        public DbSet<dotnet_mvc.Models.Post> Post { get; set; } = default!;
        public DbSet<dotnet_mvc.Models.Tag> Tag { get; set; } = default!;
    }
}
