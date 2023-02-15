using System;
using CourseOnline.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseOnline.Infraestructure.Persistence.Context
{
    public class CoursesOnlineConext : DbContext
    {
        public CoursesOnlineConext(DbContextOptions options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseInstructor>().HasKey(ci => new { ci.InstructorId, ci.CourseId });
        }

        DbSet<Course> Courses { get; set; }

        DbSet<Comment> Comments { get; set; }

        DbSet<CourseInstructor> CourseInstructors { get; set; }


        DbSet<Instructor> Instructors { get; set; }

        DbSet<Price> Prices { get; set; }


    }
}

