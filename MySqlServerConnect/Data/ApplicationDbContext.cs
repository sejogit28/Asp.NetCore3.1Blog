using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MySqlServerConnect.Models;

namespace MySqlServerConnect.Data
{
    public class ApplicationDbContext : IdentityDbContext<BlogAppUser>
    {
        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        
                public DbSet<BlogAppUser> BlogAppUsers { get; set;} //In order to change the name of this table ON THE BACK END you must change the name of the file(Users model)

                public DbSet<Tags> Tags { get; set;}

                public DbSet<Comments> Comments { get; set; }

                public DbSet<SubComments> SubComments { get; set; }

                public DbSet<Posts> Posts { get; set; }
                
                    
                public DbSet<PostsTags> PostsTags { get; set; }


                protected override void OnModelCreating(ModelBuilder modelBuilder)
                 {

                       base.OnModelCreating(modelBuilder);
                         //modelBuilder.Seed();

                    modelBuilder.Entity<PostsTags>()
                    .HasKey(o => new { o.PostsPostId, o.TagsTagId });

            
                 }

    }

}

        
   