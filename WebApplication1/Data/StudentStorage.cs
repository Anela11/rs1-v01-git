using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class StudentStorage
    {
        private readonly List<Student> _students = [];

        private int _sljedeciId = 1;

        public StudentStorage()
        {
            Dodaj(new Student()
            {
                Ime = "Anela",
                Prezime = "Hafizovic",
                BrojIndeksa = "IB220000",
                DatumRodjenja = new DateOnly(1998, 3, 15)
            });

            Dodaj(new Student()
            {
                Ime = "Amar",
                Prezime = "Eminovic",
                BrojIndeksa = "IB220007",
                DatumRodjenja = new DateOnly(1997, 5, 20)
            });
        }

        public Student Dodaj(Student student)
        {
            student.Id = _sljedeciId++;
            student.DatumKreiranja = DateTime.UtcNow;
            _students.Add(student);

            return student;
        }

        public List<Student> GetAll()
        {
            return _students;
        }
    }
}