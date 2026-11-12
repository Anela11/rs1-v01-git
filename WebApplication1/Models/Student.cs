namespace WebApplication1.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Prezime { get; set; }
        public string Ime { get; set; }
        public string BrojIndeksa { get; set; }
        public DateOnly? DatumRodjenja { get; set; }

        //Upitnik znaci da ne moramo unositi datum rodjenja, tj da moze biti Null

        public DateTime DatumKreiranja { get; set; }
    }
}