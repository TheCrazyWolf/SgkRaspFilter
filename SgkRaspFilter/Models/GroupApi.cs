namespace SgkRaspFilter.Models
{

    internal class GroupApi
    {
        public List<_groups> MyArray { get; set; }

        public GroupApi()
        {
            MyArray = new List<_groups>();
        }
    }
    
    public class _groups
    {
        public int id { get; set; }
        public string name { get; set; }
        public int currator { get; set; }
    }
}
