using System.ComponentModel.DataAnnotations;

namespace AspWebCoreAPICrud.model
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string subject { get; set; }

        public string dept { get; set; }
    }
}
