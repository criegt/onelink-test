using System.Collections.Generic;
using OneLinkTest.Domain.Employees;

namespace OneLinkTest.Domain.Areas.Subareas
{
    public class Subarea
    {
        public Subarea(int subareaId, int areaId, string name)
        {
            SubareaId = subareaId;
            AreaId = areaId;
            Name = name;
        }

        public int SubareaId { get; }

        public int AreaId { get; }

        public string Name { get; }

        public Area? Area { get; set; }

        public List<Employee>? Employees { get; set; }
    }
}
