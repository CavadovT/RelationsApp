using System.Collections.Generic;

namespace RelationsApp.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Student> Students { get; set; }
    }
}
