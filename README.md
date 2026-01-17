# GenericRepository (Console App)

C# Console ilova. 4 ta model (Student, Teacher, Subject, School) uchun Generic Repository pattern asosida CRUD amallarini bajaradi. Ma'lumotlar vaqtincha `List<T>` (in-memory) da saqlanadi.

## Features
- Main menu: Student / Teacher / Subject / School / Exit
- Har bir bo‘lim uchun CRUD menu:
  - Add
  - Update
  - Delete
  - GetById
  - GetAll
  - Back
- Generic repository + interface orqali toza struktura

## Project Structure
- **Domain**
  - Entities (BaseEntity, Student, Teacher, Subject, School)
  - Contracts (IRepository)
- **Infrastructure**
  - Repositories (GenericRepository)
- **Application**
  - Services (StudentService, TeacherService, SubjectService, SchoolService)
- **Program.cs**
  - Menyular va ishlash oqimi

## Requirements
- .NET (Console Application)

## Run
1. Reponi clone qiling
2. `GenericRepository.sln` ni oching
3. Run (F5)


Tayyorlandi: AIZUEldor.

## Notes
Ma'lumotlar dastur yopilganda o‘chadi (List<T> ishlatilgan).
