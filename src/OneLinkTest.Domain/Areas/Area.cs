using OneLinkTest.Domain.Areas.Subareas;

namespace OneLinkTest.Domain.Areas
{
    public class Area
    {
        public int AreaId { get; set; }

        public string Name { get; set; }

        public SubareasCollection Subareas { get; set; } = new SubareasCollection();
    }
}
