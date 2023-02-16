using System;
using CourseOnline.Domain.Entities;
using CourseOnline.Infraestructure.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CourseOnline.API.Extensions
{
    public static class HostBuilderExtensions
    {
        public static WebApplication SeedData(this WebApplication host)
        {
            using ( var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var userManager = services.GetRequiredService<UserManager<User>>();
                    var courseOnlineContext = services.GetRequiredService<CoursesOnlineConext>();
                    if (!courseOnlineContext.Database.IsInMemory())
                    {
                        courseOnlineContext.Database.Migrate();
                    }

                    if (!courseOnlineContext.Courses.Any())
                    {
                        //var uno = "";
                        SeedDataTables(courseOnlineContext);
                    }

                    if (!userManager.Users.Any())
                    {
                        var user = new User { NameComplete = "Brian Ramirez Salazar", UserName = "bramirez", Email = "brian.ramirez@dev.com" };
                        userManager.CreateAsync(user, "Passwords123$").Wait();
                    }
                    
                }
                catch (Exception ex)
                {
                    var logging = services.GetRequiredService<ILogger<Program>>();
                    logging.LogError(ex, "Error in the migration");
                }
            }
            return host;
        }

        private static void SeedDataTables(CoursesOnlineConext courseOnlineContext)
        {
            //data for course
            List<Course> courses = new List<Course>
            {
                new Course { Title = "Curso de C#",
                             Description = "Primer Curso basico de c#",
                             PublishDate = new DateTime(),
                }
            };

            courseOnlineContext.Courses.AddRange(courses);
            courseOnlineContext.SaveChangesAsync().Wait();


            // data for instructor
            List<Instructor> instructors = new List<Instructor>
            {
                new Instructor { Name = "bramirez",
                                 LastName = "dev",
                                 Grade = "Profesional"
                }
            };

            courseOnlineContext.Instructors.AddRange(instructors);
            courseOnlineContext.SaveChangesAsync().Wait();

            //data for CourseInstructor
            List<CourseInstructor> coursesInstructor = new List<CourseInstructor>
            {
                new CourseInstructor { Course = courses[0],
                                       Instructor = instructors[0],
                                        
                }
            };

            courseOnlineContext.CourseInstructors.AddRange(coursesInstructor);
            courseOnlineContext.SaveChangesAsync().Wait();


            //data for price
            List<Price> prices = new List<Price>
            {
                new Price { Course = courses[0],
                            CurrentPrice = 120,
                            Promotion = 0

                }
            };

            courseOnlineContext.Prices.AddRange(prices);
            courseOnlineContext.SaveChangesAsync().Wait();

            //insert user



        }
    }
}

