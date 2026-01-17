using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericRepository.Domain.Contracts;
using GenericRepository.Domain.Entities;

namespace GenericRepository.Aplication.Services
{
    public class SubjectService
    {
        private readonly IRepository<Subject> _repo;

        public SubjectService(IRepository<Subject> repo)
        {
            _repo = repo;
        }

        public void Add()
        {
            var s = new Subject
            {
                Name = ReadString("Name: "),
                Credits = ReadInt("Credits: ")
            };

            var created = _repo.Add(s);
            Console.WriteLine(" Qo‘shildi: " + created);
        }

        public void Update()
        {
            int id = ReadInt("Update uchun Id: ");
            var old = _repo.GetById(id);
            if (old == null)
            {
                Console.WriteLine(" Topilmadi!");
                return;
            }

            var s = new Subject
            {
                Id = id,
                Name = ReadString($"Name ({old.Name}): ", true) is string nm && nm != "" ? nm : old.Name,
                Credits = ReadInt($"Credits ({old.Credits}): ", true, old.Credits)
            };

            Console.WriteLine(_repo.Update(s) ? " Yangilandi!" : " Yangilashda xato!");
        }

        public void Delete()
        {
            int id = ReadInt("Delete uchun Id: ");
            Console.WriteLine(_repo.Delete(id) ? " O‘chirildi!" : " Topilmadi!");
        }

        public void GetById()
        {
            int id = ReadInt("Id: ");
            var item = _repo.GetById(id);
            Console.WriteLine(item == null ? "Topilmadi!" : item.ToString());
        }

        public void GetAll()
        {
            var list = _repo.GetAll();
            if (list.Count == 0)
            {
                Console.WriteLine(" Hozircha ma’lumot yo‘q.");
                return;
            }

            foreach (var item in list)
                Console.WriteLine(item);
        }

        private static string ReadString(string label, bool allowEmpty = false)
        {
            while (true)
            {
                Console.Write(label);
                string? s = Console.ReadLine();
                if (allowEmpty) return s ?? "";
                if (!string.IsNullOrWhiteSpace(s)) return s.Trim();
                Console.WriteLine(" Bo‘sh bo‘lishi mumkin emas!");
            }
        }

        private static int ReadInt(string label, bool allowEmpty = false, int defaultValue = 0)
        {
            while (true)
            {
                Console.Write(label);
                string? s = Console.ReadLine();
                if (allowEmpty && string.IsNullOrWhiteSpace(s)) return defaultValue;
                if (int.TryParse(s, out int n)) return n;
                Console.WriteLine(" Son kiriting!");
            }
        }
    }
}
