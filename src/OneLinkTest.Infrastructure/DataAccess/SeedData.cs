using Microsoft.EntityFrameworkCore;
using OneLinkTest.Domain.Areas;
using OneLinkTest.Domain.Areas.Subareas;
using OneLinkTest.Domain.Employees;

namespace OneLinkTest.Infrastructure.DataAccess
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder builder)
        {
            var area1 = new Area { AreaId = 1, Name = "Comercialización" };
            var subarea1 = new Subarea { SubareaId = 1, AreaId = 1, Name = "Investigación de mercado" };
            var subarea2 = new Subarea { SubareaId = 2, AreaId = 1, Name = "Publicidad" };
            var subarea3 = new Subarea { SubareaId = 3, AreaId = 1, Name = "Promoción" };
            var subarea4 = new Subarea { SubareaId = 4, AreaId = 1, Name = "Ventas" };
            var subarea5 = new Subarea { SubareaId = 5, AreaId = 1, Name = "Distribución" };

            var area2 = new Area { AreaId = 2, Name = "Administración" };
            var subarea6 = new Subarea { SubareaId = 6, AreaId = 2, Name = "Finanzas" };
            var subarea7 = new Subarea { SubareaId = 7, AreaId = 2, Name = "Control" };

            var area3 = new Area { AreaId = 3, Name = "Administración del Personal" };
            var subarea8 = new Subarea { SubareaId = 8, AreaId = 3, Name = "Selección y distribución" };
            var subarea9 = new Subarea { SubareaId = 9, AreaId = 3, Name = "Relaciones Industriales" };
            var subarea10 = new Subarea { SubareaId = 10, AreaId = 3, Name = "Servicios Sociales" };

            var employee = new Employee
            {
                EmployeeId = 1,
                Document = 1040049214,
                DocumentType = DocumentType.CitizenshipCard,
                FirstName = "Cristian",
                LastName = "García",
                SubareaId = 7
            };

            builder.Entity<Area>()
                .HasData(area1, area2, area3);

            builder.Entity<Subarea>()
                .HasData(subarea1, subarea2, subarea3, subarea4, subarea5,
                    subarea6, subarea7, subarea8, subarea9, subarea10);

            builder.Entity<Employee>()
                .HasData(employee);
        }
    }
}
