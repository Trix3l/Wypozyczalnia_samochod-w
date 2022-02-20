using System;
using System.Collections.Generic;

namespace Wypozyczalnia_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WypozyczenieSerwis serwis = new WypozyczenieSerwis();
            while (true)
            {
                string wybor = PokazMenu();
                if (wybor == "1")
                {
                    PokaListeKlientow(serwis.Klienci);
                }
                if (wybor == "2")
                {
                    PokaListeSamochodow(serwis.Samochody);
                }
                if (wybor == "3")
                {
                //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                // Wyciągnięcie koniecznych daych od klienta

                    
                    //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    //Wybór klienta
                    PokaListeKlientow(serwis.Klienci);
                    Console.Write("Podaj numer Klienta: ");
                    int numerKlienta = int.Parse(Console.ReadLine());
                    Klient klient = serwis.ZnajdzKlienta(numerKlienta);
                    if (klient == null)
                    {
                        Console.WriteLine("NIEPRAWIDŁOWY NUMER KLIENTA");
                        return;
                    }
                    //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    else
                    {
                        string segment = "null";
                        string paliwo = "null";
                        int Wsegment;
                        int Wpaliwo;
                        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        // Wybór segmentu wraz z wyliczeniem czy klient może wyporzyczyć premium
                        if (klient.Doswiadczenie >= 4)
                        {
                            Console.WriteLine("1.   mini ");
                            Console.WriteLine("2.   kompakt ");
                            Console.WriteLine("3.   premium ");
                            Console.WriteLine("PODAJ SEGMENT SAMOCHODU:");
                            Wsegment = int.Parse(Console.ReadLine());
                            Console.Clear();


                        }
                        else
                        {
                            Console.WriteLine("1.   mini ");
                            Console.WriteLine("2.   kompakt ");
                            Console.WriteLine("PODAJ SEGMENT SAMOCHODU:");
                            Wsegment = int.Parse(Console.ReadLine());
                            Console.Clear();
                        }
                        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        if (Wsegment == 1)
                        { segment = "mini"; }
                        if (Wsegment == 2)
                        { segment = "kompakt"; }
                        if (Wsegment == 3)
                        { segment = "premium"; }
                        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        // Wybór Paliwa
                        Console.WriteLine("1.   benzyna ");
                        Console.WriteLine("2.   elektryczny ");
                        Console.WriteLine("3.   diesel ");
                        Console.WriteLine("PODAJ PREFEROWANY RODZAJ PALIWA:");
                        Wpaliwo = int.Parse(Console.ReadLine());
                        Console.Clear();
                        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

                        if (Wpaliwo == 1)
                        { paliwo = "benzyna"; }
                        if (Wpaliwo == 2)
                        { paliwo = "elektryczny"; }
                        if (Wpaliwo == 3)
                        { paliwo = "diesel"; }

                        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        // Ilość dni wynajmu
                        Console.WriteLine("PODAJ ILOŚĆ DNI WYNAJMU POJAZDU:"); 
                        int IloscDni = int.Parse(Console.ReadLine()); //dodawanie dni wynajmu do nowej daty
                        DateTime es = DateTime.Now.AddDays(IloscDni);
                        
                        Console.Clear();
                        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

                        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        // Wyszukanie itema z kolekcji samochody (która spełnia konkretne argumenty) do zmiennej wynik
                        Samochod wynik = serwis.Samochody.Find(x => x.Segment == segment && x.Paliwo == paliwo && x.Dostepnosc == true);
                        //-------------------------------------
                        List<Samochod>.Remove(new Samochod(wynik.Id, wynik.Marka, wynik.Segment, wynik.Paliwo, wynik.CenaZaDobe, wynik.Dostepnosc));
                        List<Samochod>.Add(new Samochod(wynik.Id, wynik.Marka, wynik.Segment, wynik.Paliwo, wynik.CenaZaDobe, false));
                        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        // Wyliczanie ceny łącznej
                        decimal LacznaCena;
                        {
                            if (IloscDni < 7)
                                LacznaCena = wynik.CenaZaDobe * IloscDni;
                            else if (IloscDni >= 7 && IloscDni < 30)
                                LacznaCena = (wynik.CenaZaDobe * IloscDni) - wynik.CenaZaDobe;
                            else
                                LacznaCena = (wynik.CenaZaDobe * IloscDni) - 3 * wynik.CenaZaDobe;
                        }
                        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>


                        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        // "Faktura"
                        Console.WriteLine($"UMOWA WYNAJMU POJAZDU");
                        Console.WriteLine($"DATA ZAWARCIA: {DateTime.Now.Year}.{DateTime.Now.Month}.{DateTime.Now.Day}");
                        Console.WriteLine($"-------------------------------------------");
                        Console.WriteLine($"WYNAJMUJĄCY: {klient.ImieNazwisko}");
                        Console.WriteLine($"RODZAJ POJAZDU: {wynik.Marka}");
                        Console.WriteLine($"RODZAJ PALIWA: {wynik.Paliwo}");
                        Console.WriteLine($"SEGMENT: {wynik.Segment}");
                        Console.WriteLine($"-------------------------------------------");
                        Console.WriteLine($"DATA ZWROTU POJAZDU: {es.Year}.{es.Month}.{es.Day}");
                        Console.WriteLine($"OPŁATA: {LacznaCena}");
                        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    }
                }
                else
                {
                    return;
                }

            }


        }

        static void PokaListeKlientow(List<Klient> klienci)
        {
            foreach (var klient in klienci)
            {
                Console.WriteLine($"{klient.Id} {klient.ImieNazwisko} {klient.DataWydaniaPrawa.ToShortDateString()} ");
            }
        }
        static void PokaListeSamochodow(List<Samochod> samochody)
        {
            foreach (var samochod in samochody)
            {
                Console.WriteLine($"{samochod.Id} {samochod.Marka} {samochod.Segment} {samochod.Paliwo} {samochod.CenaZaDobe} {samochod.Dostepnosc}");
            }
        }


        static string PokazMenu()
        {
            Console.WriteLine("WYBIERZ OPCJE");
            Console.WriteLine("1 => LISTA KLIENTÓW");
            Console.WriteLine("2 => LISTA SAMOCHODÓW");
            Console.WriteLine("3 => WYPOŻYCZ SAMOCHÓD");
            Console.WriteLine("4 => ZAKOŃCZ");
            Console.WriteLine("ZAKOŃCZ");
            Console.Write("PROSZE WPISAĆ 1 LUB 2 LUB 3 LUB 4: ");
            return Console.ReadLine();

        }
    }

}