using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using GenericRepository.Domain.Contracts;
using GenericRepository.Domain.Entities;

namespace GenericRepository.Aplication.Services
{
    public class StudentService
    {
        private readonly IRepository<Student> _repo;

        public StudentService(IRepository<Student> repo)
        {
            _repo = repo;
        }

        public void Add()
        {
            var s = new Student
            {
                FullName = ReadString("Full Name: "),
                Age = ReadInt("Age: "),
                Group = ReadString("Group: ")

            };

            var created = _repo.Add(s);
            Console.WriteLine("Created student: " + created);
        }

        public void Update()
        {
            int id = ReadInt("Student Id to update: ");
            var old = _repo.GetById(id);
            if (old == null)
            {
                Console.WriteLine("Student not found");
                return;
            }
            var s = new Student
            {
                Id = id,
                FullName = ReadString($"Full Name: ({old.FullName} ): ", allowEmpty: true) is string fn && fn != "" ? fn : old.FullName,
                Age = ReadInt($"Age: ({old.Age}) : ", allowEmpty: true, old.Age),
                Group = ReadString($"Group: ({old.Group}): ", allowEmpty: true) is string gr && gr != "" ? gr : old.Group
            };

            Console.WriteLine(_repo.Update(s) ? "Yangilandi" : "Yangilashda xatolik !!!");

        }

        public void Delete()
        {
            int id = ReadInt("Delete uchun Id : ");
            Console.WriteLine(_repo.Delete(id) ? "O'chirildi :) " : "Topilmadi afsus :(");
        }

        public void GetById()
        {
            int id = ReadInt("Id : ");
            var item = _repo.GetById(id);
            Console.WriteLine(item == null ? "Topilmadi !!!" : item.ToString());
        }

        public void GetAll()
        {
            var list = _repo.GetAll();
            if (list.Count == 0)
            {
                Console.WriteLine("Xozircha malumot yo'q ");
                return;
            }
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        private static string ReadString(string label, bool allowEmpty = true)
        {
            while (true)
            {
                Console.Write(label);
                string ? s = Console.ReadLine();
                if(allowEmpty) return s ?? "";
                if(!string.IsNullOrWhiteSpace(s)) return s.Trim();

                Console.WriteLine("Bo'sh bo'lishi mumkin emasss !!!!");
            }
        }

        private static int ReadInt(string label, bool allowEmpty = false, int defaultValue = 0)
        {
            while(true)
            {
                Console.Write(label);
                string? s = Console.ReadLine();
                if (allowEmpty && string.IsNullOrWhiteSpace(s))
                    return defaultValue;

                if (int.TryParse(s, out int n)) return n;
                Console.WriteLine("Iltimos butun son kiriting !!!");
            }
        }
    }
}
