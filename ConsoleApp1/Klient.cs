using System;

namespace Wypozyczalnia_Test
{
    public class Klient
    {
        public Klient(int id, string imieNazwisko, DateTime data)
        {
            Id = id;
            ImieNazwisko = imieNazwisko;
            DataWydaniaPrawa = data;
        }

        public int Id { get; set; }
        public string ImieNazwisko { get; set; }
        public DateTime DataWydaniaPrawa { get; set; }
        public int Doswiadczenie
        {
            get
            {
                DateTime teraz = DateTime.Now;
                return teraz.Year - DataWydaniaPrawa.Year;
            }
        }

        public bool CzyMozeWypozyczycPremium
        {
            get
            {
                return Doswiadczenie >= 4;
            }
        }
    }
}
