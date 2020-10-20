namespace OneLinkTest.Domain.Areas.Subareas
{
    public class Subarea
    {
        public Subarea(int subareaId, string name)
        {
            SubareaId = subareaId;
            Name = name;
        }

        public int SubareaId { get; }

        public string Name { get; }
    }
}
