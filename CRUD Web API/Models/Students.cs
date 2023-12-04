using System.ComponentModel.DataAnnotations;

namespace CRUD_Web_API.Models
{
    public class Students
    {
        [Key]
        public int Id { get; set; }

        public string std_name { get; set; }

        public string Department { get; set;}
    }
}
