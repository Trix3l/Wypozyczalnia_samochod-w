using System;
using System.Collections.Generic;
using System.Linq;

namespace Wypozyczalnia_Test
{
    public class WypozyczenieSerwis
    {
        public WypozyczenieSerwis()
        {
            UtworzKlientow();
            UtworzSamochody();
        }
        private void UtworzKlientow()
        {
            Klienci = new List<Klient>();
            Klienci.Add(new Klient(1, "Szymon Nowak", new DateTime(2020, 4, 21)));
            Klienci.Add(new Klient(2, "Agata Szewczyk", new DateTime(2000, 1, 8)));
            Klienci.Add(new Klient(3, "Janusz Somsiad", new DateTime(1982, 2, 2)));
            Klienci.Add(new Klient(4, "Mariusz Adamczyk", new DateTime(2018, 12, 1)));
            Klienci.Add(new Klient(5, "Małgorzata Boryczko", new DateTime(2021, 9, 1)));
        }
        public List<Klient> Klienci { get; set; }
        public Klient Wypozyczajacy { get; set; }
        public Klient ZnajdzKlienta(int id)
        {
            var klient = Klienci.FirstOrDefault(k => k.Id == id);
            if (klient != null)
            {
                Wypozyczajacy = klient;
                return klient;
            }
            else
                return null;
        }

        private void UtworzSamochody()
        {
            Samochody = new List<Samochod>();
            Samochody.Add(new Samochod(1, "Škoda Citigo", "mini", "benzyna", 70, true));
            Samochody.Add(new Samochod(2, "Toyota Aygo", "mini", "benzyna", 90, true));
            Samochody.Add(new Samochod(3, "Fiat 500", "mini", "elektryczny", 110, true));
            Samochody.Add(new Samochod(4, "Ford Focus", "kompakt", "diesel", 160, true));
            Samochody.Add(new Samochod(5, "Kia Ceed", "kompakt", "benzyna", 150, true));
            Samochody.Add(new Samochod(6, "Volkswagen Golf", "kompakt", "benzyna", 160, true));
            Samochody.Add(new Samochod(7, "Hundai Kona Elecric", "kompakt", "elektryczny", 180, true));
            Samochody.Add(new Samochod(8, "Audi A6 Allroad", "premium", "diesel", 290, true));
            Samochody.Add(new Samochod(9, "Mercedes E270 AMG", "premium", "benzyna", 320, true));
            Samochody.Add(new Samochod(10, "Tesla Model S", "premium", "elektryczny", 350, true));


        }
        public List<Samochod> Samochody { get; set; }

    }
}
