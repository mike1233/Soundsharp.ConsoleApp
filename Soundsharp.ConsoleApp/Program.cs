using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundsharp.ConsoleApp
{
    class Program
    {
        const string password = "sharpsound";
        public struct mp3Speler
        {
            private int _id;
            private string _make;
            private string _model;
            private int _mbsize;
            private double _price;
            private int _voorraad;

            public int Id
            {
                get { return _id;}

                set { _id = value;}
            }

            public string Make
            {
                get {return _make;}

                set { _make = value;}
            }

            public string Model
            {
                get {return _model; }

                set { _model = value; }
            }

            public int Mbsize
            {
                get { return _mbsize;}

                set { _mbsize = value;}
            }

            public double Price
            {
                get { return _price; }

                set { _price = value;}
            }

            public int Voorraad
            {
                get{ return _voorraad;}

                set{ _voorraad = value;}
            }

            public mp3Speler(int ID, string MAKE, string MODEL, int MBSize, double PRICE, int VOORRAAD)
            {
                this._id = ID;
                this._make = MAKE;
                this._mbsize = MBSize;
                this._model = MODEL;
                this._price = PRICE;
                this._voorraad = VOORRAAD;
            }



           /* public void PrintMP3()   deze methode is outdated.
            {
                Console.WriteLine("ID = {0}"    ,     this._id);
                Console.WriteLine("Merk = {0}"  ,     this._make);
                Console.WriteLine("Model = {0}" ,     this._model);
                Console.WriteLine("MBSize = {0} MB",     this._mbsize);
                Console.WriteLine("Prijs = ${0}" ,     this._price);
            }*/
        }

        public static List<mp3Speler> mp3spelers = new List<mp3Speler>
        {
            new mp3Speler {Id = 1, Make = "GET technologies .inc", Model = "HF 410", Mbsize = 4096, Price = 129.95, Voorraad = 500}, // product 1
            new mp3Speler {Id = 2, Make = "Far & Loud", Model = "XM 600", Mbsize = 8192, Price = 224.95, Voorraad = 500}, // product 2
            new mp3Speler {Id = 3, Make = "Innotivative", Model = "Z3", Mbsize = 512, Price = 79.95, Voorraad = 500}, // product 3
            new mp3Speler {Id = 4, Make = "Resistance S.A.", Model = "3001", Mbsize = 4096, Price = 124.95, Voorraad = 500}, // product 4
            new mp3Speler {Id = 5, Make = "CBA", Model = "NXT volume", Mbsize = 2048, Price = 159.05, Voorraad = 500},  //product 5
        };
        
        static void Main(string[] args)
        {
            
            if (args.Length == 2 && args[0] == "admin" && args[1] == password)
            {
                adminmenu(); // Laad hier het Admin menu
            }
            else
            {
                // Console.WriteLine("Geen Admin");
            }

            try // Rechter muis admin
            {
                WindowsIdentity identity = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
                {
                    Login();
                }
                else
                {
                    adminmenu();
                }
            }
            catch (Exception ex)
            {
                if (ex != null) { }
            }
            Console.WriteLine("hello");
            Login();
            ShowMenu();
        }

        public static void adminmenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            string s = "SoundSharp Admin Menu";
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.WriteLine(s);

            string s4 = "Alle mp3 spelers";
            Console.SetCursorPosition((Console.WindowWidth - s4.Length) / 2, Console.CursorTop);
            Console.WriteLine(s4);

            for (int i = 0; i < mp3spelers.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.White; Console.Write("ID:        "); Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine(mp3spelers[i].Id);
                Console.ForegroundColor = ConsoleColor.White; Console.Write("Merk:      "); Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine(mp3spelers[i].Make);
                Console.ForegroundColor = ConsoleColor.White; Console.Write("Model:     "); Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine(mp3spelers[i].Model);
                Console.ForegroundColor = ConsoleColor.White; Console.Write("MBsize:    "); Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine(mp3spelers[i].Mbsize + "MB");
                Console.ForegroundColor = ConsoleColor.White; Console.Write("Prijs:     "); Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine("$" + mp3spelers[i].Price);
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            string s2 = "Voorraad Soundsharp";
            Console.SetCursorPosition((Console.WindowWidth - s2.Length) / 2, Console.CursorTop);
            Console.WriteLine(s2);

            for (int i = 0; i < mp3spelers.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.White; Console.Write("ID:        "); Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine(mp3spelers[i].Id);
                Console.ForegroundColor = ConsoleColor.White; Console.Write("Merk:      "); Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine(mp3spelers[i].Make);
                Console.ForegroundColor = ConsoleColor.White; Console.Write("Model:     "); Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine(mp3spelers[i].Model);
                Console.ForegroundColor = ConsoleColor.White; Console.Write("Voorraad:  "); Console.WriteLine(mp3spelers[i].Voorraad);
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            string s3 = "Statistieken";
            Console.SetCursorPosition((Console.WindowWidth - s3.Length) / 2, Console.CursorTop);
            Console.WriteLine(s3);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            int totaleVoorraad = 0;
            Double totaleWaarde = 0;
            Double ppMB = 0;
            foreach (mp3Speler m in mp3spelers)
            {
                totaleVoorraad += m.Voorraad;
                Double waarde = m.Voorraad * m.Price;
                totaleWaarde += waarde;
            }
            Double gemiddeldePrijs = Math.Round(totaleWaarde / totaleVoorraad, 2);

            Console.WriteLine("Totaal aantal spelers op voorraad: {0}", totaleVoorraad);
            Console.WriteLine("");
            Console.WriteLine("Totale waarde aan MP3 Spelers: {0}", totaleWaarde);
            Console.WriteLine("");
            Console.WriteLine("Gemiddelde prijs per MP3 Speler: {0}", gemiddeldePrijs);
            Console.WriteLine("");
            Console.WriteLine("");

            // Goedkoopste per MB groen
            // Goedkoop naar duur
            // Prijzen 2 cijfers achter de komma

            foreach (mp3Speler m in mp3spelers)
            {
                ppMB = Math.Round(m.Price / m.Mbsize, 3);
                Console.WriteLine("MP3 Speler {0} kost: {1} per MB.", m.Id, ppMB);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Druk op [ 9 ] om af te sluiten of op [ 8 ] om terug te keren naar het hoofdmenu.");
            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey();
                switch (keyinfo.Key)
                {
                    case ConsoleKey.D8:
                        ShowMenu();
                        break;
                    
                    default:
                        Console.Clear();
                        adminmenu();
                        // Console.WriteLine("Kies een van de opties");
                        break;
                }

            } while (keyinfo.Key != ConsoleKey.Escape);

        }

        public static void Login()
        {
            
            // maak een gebruikersnaam
            Console.WriteLine("Voer een gebruikernaam in");
            string userName = Console.ReadLine();
            Console.WriteLine("Welkom bij SoundSharp" + " " + userName);


            // check het wachtwoord
            int poging = 1;
            do
            {
                
                switch (poging)
                {
                    case 1:
                        string input = string.Empty;

                        Console.Write("Voer het wachtwoord in: ");
                        input = Console.ReadLine();

                        if (input == password)
                        {
                            Console.WriteLine("Correct wachtwoord");
                            Console.WriteLine("U bent ingelogd");
                            ShowMenu();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect wachtwoord");
                            poging++;
                            //Console.WriteLine(poging);
                            break;
                        }

                    case 2:
                        Console.Write("Voer het wachtwoord in: ");
                        input = Console.ReadLine();

                        if (input == password)
                        {
                            Console.WriteLine("Correct wachtwoord");
                            Console.WriteLine("U bent ingelogd");
                            ShowMenu();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect wachtwoord");
                            poging++;
                            //Console.WriteLine(poging);
                            break;
                        }

                    case 3:
                        Console.WriteLine("dit is de laatste poging");
                        input = Console.ReadLine();
                        if (input == password)
                        {
                            Console.WriteLine("Correct wachtwoord");
                            Console.WriteLine("U bent ingelogd");
                            ShowMenu();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect wachtwoord, druk op een toets om het programma af te sluiten");
                            Environment.Exit(0);
                            break;
                        }

                }
            }

            while (poging < 4);
               
            

        }

        public static void ShowMenu()
        {
            int selectie;
            Console.Clear();
            do
            {
               
                Console.WriteLine("dit is het menu, druk op een nummer om verder te gaan");
                Console.WriteLine("");
                Console.WriteLine("1. Overzicht mp3 spelers");
                Console.WriteLine("2. Overzicht voorraad");
                Console.WriteLine("3. Muteer voorraad");
                Console.WriteLine("4. Statistieken");
                Console.WriteLine("5. MP3 Speler toevoegen");
                Console.WriteLine("6. -Leeg-");
                Console.WriteLine("7. -Leeg-");
                Console.WriteLine("8. Toon menu");
                Console.WriteLine("9. Menu afsluiten");

                string strReadKey = Console.ReadKey().KeyChar.ToString();
                int.TryParse(strReadKey, out selectie);


                switch (selectie)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("gekozen actie: 1. Overzicht mp3 spelers");
                        Console.WriteLine("");
                        ShowMP3();
                        RerunMenu();
                        break;
                        // overzicht mp3 spelers
                    case 2:
                        Console.Clear();
                        Console.WriteLine("gekozen actie: 2. Overzicht voorraad");
                        Console.WriteLine("");
                        ShowVoorraad();
                        RerunMenu();
                        break;
                    // overzicht voorraad

                    case 3:
                        Console.Clear();
                        Console.WriteLine("gekozen actie: 3. Muteer voorraad");
                        Console.WriteLine("");
                        MuteerVoorraad();
                        RerunMenu();
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("gekozen actie: 4. Statistieken");
                        Console.WriteLine("");
                        Statistieken();
                        RerunMenu();
                        break;

                    case 5:
                        Console.Clear();
                        Console.WriteLine("gekozen actie: 5. MP3 speler toevoegen");
                        Console.WriteLine("");
                        mp3spelertoevoegen();
                        RerunMenu();
                        break;

                    case 9:
                        Console.Clear();
                        Console.WriteLine("menu afgesloten (9)");
                        Console.WriteLine("druk op een toets om het programma af te sluiten");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("onjuiste waarde ingevoerd");
                        Console.WriteLine("");
                        break; 

                }

            }

            while (selectie != 9);
        }

        public static void ShowMP3()
        {
            
            foreach (mp3Speler M in mp3spelers)
            {
                Console.WriteLine("ID = {0}", M.Id);
                Console.WriteLine("Merk = {0}", M.Make);
                Console.WriteLine("Model = {0}", M.Model);
                Console.WriteLine("MBSize = {0} MB", M.Mbsize);
                Console.WriteLine("Prijs = ${0}", M.Price);
                Console.WriteLine("");
            }

        }

        public static void mp3spelertoevoegen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            string s = "MP3 speler toevoegen";
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.WriteLine(s);
            Console.ForegroundColor = ConsoleColor.Gray;



            int id = mp3spelers.Count + 1;

            Console.Write("Merk: ");
            string merk = Convert.ToString(Console.ReadLine());

            Console.Write("Model: ");
            string model = Convert.ToString(Console.ReadLine());

            Console.Write("MB Grootte: ");
            int mbsize = Convert.ToInt32(Console.ReadLine());

            Console.Write("Prijs: ");
            Double prijs = Convert.ToDouble(Console.ReadLine());

            Console.Write("Huidige voorraad: ");
            int voorraad = Convert.ToInt32(Console.ReadLine());

            mp3spelers.Add(new mp3Speler(id, merk, model, mbsize, prijs, voorraad));

            Console.WriteLine("Speler is succesvol toegevoegd! Druk op 8 om terug te gaan naar het hoofdmenu");
        }

        public static void ShowVoorraad()
        {
          
            foreach (mp3Speler M in mp3spelers)
            {
                Console.WriteLine("ID = {0}", M.Id);
                Console.WriteLine("Voorraad = {0}", M.Voorraad);
                Console.WriteLine("");
            }
        }

        public static void MuteerVoorraad()
        {
            Console.WriteLine("Voer het ID van een MP3 speler in om de voorraad aan te passen:");
            string readInput = Console.ReadLine();
            int ID;

            try
            {
                ID = Convert.ToInt32(readInput);
                mp3Speler tempinfo = mp3spelers[mp3spelers.FindIndex(x => x.Id == ID)];
                Console.WriteLine("De voorraad voor het gekozen ID is: {0}", tempinfo.Voorraad);
                Console.WriteLine("Mutatie -/+: ");
                int mutatie = Convert.ToInt32(Console.ReadLine());
                tempinfo.Voorraad += mutatie;
                if (tempinfo.Voorraad < 0)
                {
                    Console.WriteLine("Mutatie niet uitgevoerd: voorraad mag niet negatief worden.");
                }
                else
                {
                    mp3spelers[mp3spelers.FindIndex(x => x.Id == ID)] = tempinfo;
                }
            }
            catch (FormatException error)
            {
                Console.WriteLine("Mutatie niet uitgevoerd: Verkeerde waarde ingevoerd. (Error: {0}", error);
                MuteerVoorraad();
                return;
            }
            catch (OverflowException error2)
            {
                Console.WriteLine("Mutatie niet uitgevoerd: Te hoge mutatie ingevoerd. (Error: {0}", error2);
                MuteerVoorraad();
                return;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Dit ID bestaat niet");
                MuteerVoorraad();
                return;

            }
        }

        public static void Statistieken()
        {
            int TotaleVoorraad = 0;
            double TotaleWaarde = 0;
            double GemiddeldePrijs = 0;
            double ppMB = 0;

            foreach (var mp3Speler in mp3spelers)
            {
                TotaleVoorraad += mp3Speler.Voorraad;
                TotaleWaarde += (mp3Speler.Voorraad * mp3Speler.Price);
                GemiddeldePrijs += (mp3Speler.Price / mp3spelers.Count);
            }

            Console.WriteLine("De totale voorraad is: {0}", TotaleVoorraad);
            Console.WriteLine("De totale waarde van de voorraad is: {0} euro", TotaleWaarde);
            Console.WriteLine("De gemiddelde prijs van een mp3 speler is: {0} euro", GemiddeldePrijs);
            Console.WriteLine("");
            foreach (mp3Speler m in mp3spelers)
            {
                ppMB = Math.Round(m.Price / m.Mbsize, 3);
                Console.WriteLine("MP3 Speler {0} kost: {1} per MB.", m.Id, ppMB);
            }
        }

        public static void RerunMenu()
        {
            int keus;
            do
            {

                string ReadKey = Console.ReadKey().KeyChar.ToString();
                int.TryParse(ReadKey, out keus);

                if (keus == 8)
                {
                    Console.Clear();
                    Console.WriteLine("8 is ingedrukt, u gaat terug naar het menu");
                    ShowMenu();
                }

                else
                {

                    Console.WriteLine("  is ingedrukt, deze toets heeft geen toegewezen actie");
                }
            }

            while (keus != 8);
        }
    }
    
}
 