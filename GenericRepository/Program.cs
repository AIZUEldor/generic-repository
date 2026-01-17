using System;
using GenericRepository.Aplication.Services;
using GenericRepository.Domain.Entities;
using GenericRepository.Infrastructure.Repositories;

namespace GenericRepository
{
    internal class Program
    {
        static void Main()
        {
            
            var studentRepo = new GenericRepository<Student>();
            var teacherRepo = new GenericRepository<Teacher>();
            var subjectRepo = new GenericRepository<Subject>();
            var schoolRepo = new GenericRepository<School>();

           
            var studentService = new StudentService(studentRepo);
            var teacherService = new TeacherService(teacherRepo);
            var subjectService = new SubjectService(subjectRepo);
            var schoolService = new SchoolService(schoolRepo);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("====================================");
                Console.WriteLine("   GENERIC REPOSITORY (MAIN MENU)   ");
                Console.WriteLine("====================================");
                Console.WriteLine("1) Student");
                Console.WriteLine("2) Teacher");
                Console.WriteLine("3) Subject");
                Console.WriteLine("4) School");
                Console.WriteLine("5) Exit");
                Console.Write("Tanlang: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CrudMenu("STUDENT", studentService.Add, studentService.Update, studentService.Delete, studentService.GetById, studentService.GetAll);
                        break;
                    case "2":
                        CrudMenu("TEACHER", teacherService.Add, teacherService.Update, teacherService.Delete, teacherService.GetById, teacherService.GetAll);
                        break;
                    case "3":
                        CrudMenu("SUBJECT", subjectService.Add, subjectService.Update, subjectService.Delete, subjectService.GetById, subjectService.GetAll);
                        break;
                    case "4":
                        CrudMenu("SCHOOL", schoolService.Add, schoolService.Update, schoolService.Delete, schoolService.GetById, schoolService.GetAll);
                        break;
                    case "5":
                        return;
                    default:
                        Pause(" Noto‘g‘ri tanlov!");
                        break;
                }
            }
        }

        static void CrudMenu(string title,
            Action add, Action update, Action delete,
            Action getById, Action getAll)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("====================================");
                Console.WriteLine($"         {title} - CRUD MENU        ");
                Console.WriteLine("====================================");
                Console.WriteLine("1) Add");
                Console.WriteLine("2) Update");
                Console.WriteLine("3) Delete");
                Console.WriteLine("4) GetById");
                Console.WriteLine("5) GetAll");
                Console.WriteLine("6) Back");
                Console.Write("Tanlang: ");

                string? choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1": add(); break;
                    case "2": update(); break;
                    case "3": delete(); break;
                    case "4": getById(); break;
                    case "5": getAll(); break;
                    case "6": return;
                    default: Console.WriteLine(" Noto‘g‘ri tanlov!"); break;
                }

                Pause();
            }
        }

        static void Pause(string msg = "")
        {
            if (!string.IsNullOrWhiteSpace(msg))
                Console.WriteLine(msg);

            Console.WriteLine("\nDavom etish uchun Enter...");
            Console.ReadLine();
        }
    }
}
