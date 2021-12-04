using System;
using DotNetCore.Domain;

namespace Domain
{
    public class Department : Entity<long>
    {
        public Department(long id, string name, string address)
        {
            Id = id;
            Name = Name;
            Address = address;
        }
        public string Name { get; set; }

        public string Address { get; set; }

        public long ManagerId { get; set; }

        public Employee Manager { get; set; }

    }
}
