using System;
using System.Linq;
using System.Threading.Tasks;
using Demo_Project_4REST_API_Course.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Demo_Project_4REST_API_Course
{
    public static class SeedData
    {
        public static async Task InitializeDatabaseAsync(IServiceProvider services)
        {
            await AddTestData(services.GetRequiredService<ControlNotasDbContext>());
        }

        public static async Task AddTestData(ControlNotasDbContext dbContext)
        {
            if (dbContext.Courses.Any() || dbContext.Cycles.Any())
            {
                return; //Already has data
            }

            dbContext.Cycles.Add(new CycleEntity()
            {
                Id = 1,
                Codigo = "2022-01",
                Promedio = 18.5
            });
            dbContext.Cycles.Add(new CycleEntity()
            {
                Id = 2,
                Codigo = "2022-02",
                Promedio = 18.5
            });

            dbContext.Courses.Add(new CourseEntity()
            {
                Id = 1,
                Codigo = "SI123",
                Creditos = 4,
                Nombre = "Programación 1",
                Promedio = 16.5,
                IdCiclo = 1
            });

            dbContext.Courses.Add(new CourseEntity()
            {
                Id = 2,
                Codigo = "SI124",
                Creditos = 5,
                Nombre = "Programación 2",
                Promedio = 16.5,
                IdCiclo = 1
            });

            dbContext.Courses.Add(new CourseEntity()
            {
                Id = 3,
                Codigo = "SI126",
                Creditos = 4,
                Nombre = "Programación Web",
                Promedio = 16.5,
                IdCiclo = 2
            });

            dbContext.Courses.Add(new CourseEntity()
            {
                Id = 4,
                Codigo = "SI452",
                Creditos = 5,
                Nombre = "Redes",
                Promedio = 16.5,
                IdCiclo = 1
            });

            dbContext.Courses.Add(new CourseEntity()
            {
                Id = 5,
                Codigo = "SI453",
                Creditos = 5,
                Nombre = "Redes II",
                Promedio = 16.5,
                IdCiclo = 2
            });

            dbContext.Courses.Add(new CourseEntity()
            {
                Id = 6,
                Codigo = "SI483",
                Creditos = 5,
                Nombre = "Gerencia TI",
                Promedio = 16.5,
                IdCiclo = 2
            });

            await dbContext.SaveChangesAsync();
        }
    }
}
