namespace Wypozyczalnia_Test
{
    public class Samochod
    {


        public Samochod(int id, string marka, string segment, string paliwo, decimal cena, bool dostepnosc)
        {
            Id = id;
            Marka = marka;
            Segment = segment;
            Paliwo = paliwo;
            CenaZaDobe = cena;
            Dostepnosc = dostepnosc;

        }
        public int Id { get; set; }
        public string Marka { get; set; }
        public string Segment { get; set; }
        public string Paliwo { get; set; }
        public decimal CenaZaDobe { get; set; }
        public bool Dostepnosc { get; set; }
    }

}
