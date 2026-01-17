using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Domain.Entities
{
    public class Subject : BaseEntity
    {
        public string Name { get; set; }
        public int Credits { get; set; }
        public override string ToString()
          => $"Subject [Id={Id}, Name={Name}, Credits={Credits}]";
    }
}
