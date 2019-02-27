using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EF.Postgres.Entities
{
    public class Student
    {
        [Key]
        public int ID { get; set; }
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }
        public DateTime DoB { get; set; }
        public bool Sex { get; set; }
        public string Address { get; set; }

        public Student()
        {
            Name = "xxx";
            DoB = DateTime.Now;
            Sex = true;
        }
    }
}
