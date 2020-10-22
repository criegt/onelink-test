using System.Collections.Generic;
using System.Text.Json.Serialization;
using OneLinkTest.Domain.Employees;

namespace OneLinkTest.Domain.Areas.Subareas
{
    public class Subarea
    {
        public int SubareaId { get; set; }

        public int AreaId { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public Area Area { get; set; }

        [JsonIgnore]
        public List<Employee> Employees { get; set; }
    }
}
