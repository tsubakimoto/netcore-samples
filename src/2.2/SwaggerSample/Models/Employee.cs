using System.ComponentModel.DataAnnotations;

namespace SwaggerSample.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string Name { get; set; }
    }
}
