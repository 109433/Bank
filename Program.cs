using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Program
    {
        public static bool czyscEkran = false;
        public static List<Klienci> _klienci = new List<Klienci>();
        static void Main(string[] args)
        {


            UzupelnijKlientow(_klienci);
            //    Pokazmenu();

            while (1 == 1)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Pokazmenu();

                string pobrana_wartosc = Console.ReadLine();
                KtoraOpcja(pobrana_wartosc);
            }
            // Console.ReadLine();


        }

        public static void UzupelnijKlientow(List<Klienci> klienci)
        {
            klienci.Add(new Klienci
            {
                id = 1,
                Imie_Nazwisko = "Jan Nowak",
                Nr_konta = "001",
                Saldo = 1457.23m,
                Waluta = "zł"
            }
                );

            klienci.Add(new Klienci
            {
                id = 2,
                Imie_Nazwisko = "Agnieszka Kowalska",
                Nr_konta = "002",
                Saldo = 3000.18m,
                Waluta = "zł"
            }
               );

            klienci.Add(new Klienci
            {
                id = 3,
                Imie_Nazwisko = "Robert Lewandowski",
                Nr_konta = "003",
                Saldo = 2745.03m,
                Waluta = "zł"
            }
               );

            klienci.Add(new Klienci
            {
                id = 4,
                Imie_Nazwisko = "Zofia Plucińska",
                Nr_konta = "004",
                Saldo = 7344.00m,
                Waluta = "zł"
            }
               );

            klienci.Add(new Klienci
            {
                id = 5,
                Imie_Nazwisko = "Grzegorz Braun",
                Nr_konta = "005",
                Saldo = 455.38m,
                Waluta = "zł"
            }
               );


        }

        public static void Pokazmenu()
        {
            if (czyscEkran)
            {
                Console.Clear();
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("WYBIERZ OPCJE:");
            Console.WriteLine("1 => LISTA WSZYSTKICH KLIENTÓW BANKU");
            Console.WriteLine("2 => LOGOWANIE");
            Console.WriteLine("3 => ZAKOŃCZ PROGRAM");
            Console.WriteLine("WYBIERZ 1, 2 LUB 3:");

        }
        public static void ZalogowanyKlient()
        {
            string idlog = Console.ReadLine();
            foreach (Klienci klient in _klienci)
            {

                int idlogliczba = 0;
                int.TryParse(idlog, out idlogliczba);
                if (idlogliczba == klient.id)
                {
                    klient.id = idlogliczba;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("ZALOGOWANY KLIENT");
                    Console.WriteLine("ID: " + klient.id);
                    Console.WriteLine("IMIĘ I NAZWISKO: " + klient.Imie_Nazwisko);
                    Console.WriteLine("NR KONTA: " + klient.Nr_konta);
                    Console.WriteLine("SALDO: " + klient.Saldo);
                    Console.WriteLine("WPISZ NUMER KONTA NA KTÓRY CHCESZ ZROBIĆ PRZELEW: ");
                    Poprawnoscnrkonta(klient);
                    return;
                }
            }
            czyscEkran = false;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("LOGOWANIE NIEUDANE");
        }

        public static void Poprawnoscnrkonta(Klienci zalogowany_klient)
        {
            string wprowadzonynrkonta = Console.ReadLine();



            foreach (Klienci klient in _klienci)
            {

                if (wprowadzonynrkonta == klient.Nr_konta && wprowadzonynrkonta != zalogowany_klient.Nr_konta)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("PODAJ KWOTE:");
                    string wprowadzonaKwota = Console.ReadLine();


                    decimal kwota = 0;
                    try
                    {
                        kwota = decimal.Parse(wprowadzonaKwota);
                        kwota = Math.Round(kwota, 2);
                    }
                    catch
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Nieprawidłowa kwota");
                        return;
                    }

                    //if (kwota!= Math.Round(kwota, 2))
                    //{
                    //    czyscEkran = false;
                    //    Console.Clear();
                    //    Console.ForegroundColor = ConsoleColor.Red;
                    //    Console.WriteLine("Zaokrąglamy do dwóch miejsc po przecinku");
                    //    PokazKlientow();
                    //    return;

                    //}
                    if (kwota > zalogowany_klient.Saldo)
                    {
                        czyscEkran = false;
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("NIEWYSTARCZAJĄCE ŚRODKI NA RACHUNKU");
                        return;
                    }
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("PRZELEW ZOSTAŁ WYKONANY");
                    zalogowany_klient.Saldo = zalogowany_klient.Saldo - kwota;
                    klient.Saldo = klient.Saldo + kwota;

                    PokazKlientow();


                    return;
                }

            }
            czyscEkran = false;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("NIEPRAWIDŁOWY NUMER KONTA");
            //  Poprawnoscnrkonta(zalogowany_klient);

        }
        public static void PokazKlientow()
        {
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Klienci klient in _klienci)
            {

                Console.WriteLine(klient.id + " | " + klient.Imie_Nazwisko + " | " + klient.Nr_konta + " | " + klient.Saldo + " " + klient.Waluta);


            }


        }
        public static void KtoraOpcja(string wartosc)
        {
            Console.ForegroundColor = ConsoleColor.White;
            if (wartosc == "1")
            {
                Console.Clear();
                Console.WriteLine("ID" + " | " + "IMIĘ I NAZWISKO" + " | " + "NR KONTA" + " | " + "SALDO");
                PokazKlientow();
                czyscEkran = false;
                Pokazmenu();
                string pobrana_wartosc = Console.ReadLine();
                KtoraOpcja(pobrana_wartosc);
            }
            else if (wartosc == "2")
            {
                Console.Clear();
                Console.WriteLine("ZALOGUJ SIĘ WYBIERAJĄC ID KLIENTA:");
                ZalogowanyKlient();

            }
            else if (wartosc == "3")
            {

                Environment.Exit(0);
            }
            else
            {
                czyscEkran = true;

                return;
            }

        }

    }
}

