using System;
using System.ComponentModel.DataAnnotations;

namespace RedisCacheSample.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
    }
}
