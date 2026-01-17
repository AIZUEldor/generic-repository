using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Domain.Entities
{
    public  class Teacher : BaseEntity
    {
        public string FullName { get; set; } = "";
        public string Specialty { get; set; } = "";
        public int ExperienceYear { get; set; }
        public override string ToString()
          => $"Teacher [Id={Id}, FullName={FullName}, Specialty={Specialty}, ExperienceYears={ExperienceYear}]";
    }
}
