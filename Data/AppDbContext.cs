using atickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//For many-to-many reletionships we need to add some indications or instructions to the translator 
//model creating!!!
namespace atickets.Data
{
    public class AppDbContext:DbContext
    {
        // to pass configuration information to the DbContext us DbContextOptions instance
        // pass the options parameter to the base class by using the base keyword 
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        // overidde the onmodelcreating method

        // trouble understanding this 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //For many-to-many reletionships we need to add some indications or instructions to the translator 

            modelBuilder.Entity<Actor_Movie>().HasKey(am => new  { am.ActorId,am.MovieId });

            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(am => am.Actor_Movies).HasForeignKey(m => m.MovieId);

            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Actor).WithMany(am => am.Actor_Movies).HasForeignKey(m => m.ActorId);



            base.OnModelCreating(modelBuilder);
        }

        //define the table names for each model

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor_Movie> Actor_Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producers { get; set; }

        
        
    }
}
