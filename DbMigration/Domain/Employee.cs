using System;
using System.Collections.Generic;
using DotNetCore.Domain;

namespace Domain
{
    public class Employee : Entity<long>
    {
        public Employee(long id, string name, int age, string phone, string email)
        {
            Id = id;
            Name = name;
            Age = age;
            Phone = phone;
            Email = email;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public virtual List<Department> Departments { get; set; }
    }
}
