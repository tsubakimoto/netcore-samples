using System.ComponentModel.DataAnnotations;

namespace CacheRepositorySample.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string Name { get; set; }
    }
}
