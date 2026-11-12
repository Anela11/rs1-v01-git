using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController(StudentStorage studentStorage) : Controller
    {
        //eh sad, obzirom da je ovo kontroler, i da je ovo ispod dole akcija, ono sto bi trebali imati ovdje ispod je [HttpGet], a iznad StudentController klase bi trebali navesti da je to Api Controller, i navodimo da je ruta Naziv kontrolera

        [HttpGet]
        public List<StudentResponse> GetAll()
        {
            List<Student> students = studentStorage.GetAll();
            return students.Select(Mapiraj).ToList();
            //To List pisemo jer Select funkcija nam vraca IEnumerable tip podatka (podaci nad kojima se ne mogu izvrsavati daljnje operacije, niti se mogu mijenjati, dok sa listama to mozemo).
            //Stoga je potrebno uraditi eksplicitnu konverziju u ToList()
            //Medjutim, posto mi trenutno
        }

        private static StudentResponse Mapiraj(Student s)
        {
            return new StudentResponse()
            {
                Id = s.Id,
                ImePrezime = $"{s.Ime} {s.Prezime}",
                BrojIndeksa = s.BrojIndeksa,
                DatumRodjenja = s.DatumRodjenja,
            };
        }
    }
}