using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Domain.Entities
{
    public class Student : BaseEntity
    {
        public string FullName { get; set; } = "";
        public int Age { get; set; }
        public string Group { get; set; } = "";

        public override string ToString()
          => $"Student [Id={Id}, FullName={FullName}, Age={Age}, Group={Group}]";
        
    }
}
