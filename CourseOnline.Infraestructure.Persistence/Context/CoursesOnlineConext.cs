using System;
using System.Reflection;
using CourseOnline.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CourseOnline.Infraestructure.Persistence.Context
{
    public class CoursesOnlineConext : IdentityDbContext<User>
    {
        public CoursesOnlineConext(DbContextOptions options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //put the same value for properties de type decimal
            var entities = modelBuilder.Model.GetEntityTypes()
                                             .SelectMany(e => e.GetProperties())
                                             .Where(e => e.ClrType == typeof(decimal) || e.ClrType == typeof(decimal?));

            foreach (var propety in entities)
            {
                propety.SetColumnType("decimal(18,4)");
            }

            // line for create migration
            base.OnModelCreating(modelBuilder);
            // line for take configurations for each table
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        virtual public DbSet<Course> Courses { get; set; }

        virtual public DbSet<Comment> Comments { get; set; }

        virtual public DbSet<CourseInstructor> CourseInstructors { get; set; }


        virtual public DbSet<Instructor> Instructors { get; set; }

        virtual public DbSet<Price> Prices { get; set; }


    }
}

