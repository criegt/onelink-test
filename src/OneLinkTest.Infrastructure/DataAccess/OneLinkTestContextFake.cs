using System.Collections.Generic;
using System.Collections.ObjectModel;
using OneLinkTest.Domain.Areas;
using OneLinkTest.Domain.Areas.Subareas;
using OneLinkTest.Domain.Employees;

namespace OneLinkTest.Infrastructure.DataAccess
{
    public class OneLinkTestContextFake
    {
        public OneLinkTestContextFake()
        {
            var area = new Area
            {
                AreaId = 1,
                Name = "Comercialización",
                Subareas = new SubareasCollection
                {
                    new Subarea
                    {
                        SubareaId = 1,
                        AreaId = 1,
                        Name = "Investigación de mercado"
                    },
                    new Subarea
                    {
                        SubareaId = 2,
                        AreaId = 1,
                        Name = "Publicidad"
                    },
                    new Subarea
                    {
                        SubareaId = 3,
                        AreaId = 1,
                        Name = "Promoción"
                    },
                }
            };

            Areas.Add(area);

            var employee = new Employee
            {
                EmployeeId = 1,
                Document = 1040049214,
                DocumentType = DocumentType.CitizenshipCard,
                FirstName = "Cristian",
                LastName = "García",
                SubareaId = 1,
            };

            Employees.Add(employee);
        }

        public ICollection<Employee> Employees { get; } = new Collection<Employee>();

        public ICollection<Area> Areas { get; } = new Collection<Area>();

        public ICollection<Subarea> Subareas { get; } = new Collection<Subarea>();
    }
}
