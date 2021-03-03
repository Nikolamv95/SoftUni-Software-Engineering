using StudentSystem.GlobalValues;

namespace StudentSystem.Data.Models
{
    public class Resource
    {
        public int RecourceId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public ResourceType ResourceType { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }        
    }
}
