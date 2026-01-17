using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Domain.Entities
{
    public class School : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public override string ToString()
          => $"School [Id={Id}, Name={Name}, Address={Address}]";
    }
}
