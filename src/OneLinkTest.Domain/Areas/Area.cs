using OneLinkTest.Domain.Areas.Subareas;

namespace OneLinkTest.Domain.Areas
{
    public class Area
    {
        public Area(int areaId, string name)
        {
            AreaId = areaId;
            Name = name;
        }

        public int AreaId { get; }

        public string Name { get; }

        public SubareasCollection Subareas { get; } = new SubareasCollection();
    }
}
