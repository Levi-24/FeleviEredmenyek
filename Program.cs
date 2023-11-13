using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FeleviEredmenyek
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Tanulo> tanulok = new List<Tanulo>();
            using StreamReader sr = new StreamReader(path: @"..\..\..\src\data.txt", Encoding.UTF8);
            List<string> definiciok = new List<string>();

            string sep = "\t";
            var nevek = sr.ReadLine().Split(sep.ToCharArray());
            foreach (var item in nevek)
            {
                definiciok.Add(item);
            }

            while (!sr.EndOfStream)
            {
                _ = sr.ReadLine();
                tanulok.Add(new Tanulo(sr.ReadLine()));
            };

            //1. feladat
            //Írjunk függvényt, ami kiszámítja a jegyek átlagát tanulónként.Írjunk függvényt, ami kiszámítja az osztályátlagot, illetve a tantárgyankénti átlagot is.
            Console.WriteLine("1.Feladat: Tanulók átlagjai:");
            foreach (var tanulo in tanulok)
            {
                Console.WriteLine(TanuloAtlag(tanulo));
            }

            Console.WriteLine();
            Console.WriteLine("Osztály átlag:");
            Console.WriteLine(OsztalyAtlag(tanulok));

            Console.WriteLine();
            Console.WriteLine("Tantárgyak átlagai:");
            double[] f1 = new double[tanulok[0].Ertekelesek.Count];
            f1 = TantargyAtlag(tanulok);
            foreach (var item in f1)
            {
                Console.WriteLine(item);
            }

            //2. feladat: Programozás gyakorlatból megbukottak adatainak kiiratása.
            Console.WriteLine();
            Console.WriteLine("2.Fealdat:");
            foreach (var tanulo in tanulok)
            {
                if (tanulo.Ertekelesek[3] < 2)
                {
                    Console.WriteLine(tanulo);
                }
            }

            //3. feladat: Írjunk függvényt, amivel keressük meg az első olyan embert, akinek hármasa van angol nyelvből, majd írjuk ki az adatait.
            Console.WriteLine();
            Console.WriteLine("3.Feladat:");
            Console.WriteLine(HarmadikFeladat(tanulok));

            //4. feladat: Kérjük be a felhasználótól, melyik tanuló legjobb jegyét szeretné megtudni.
            //Írjuk ki az adott tanuló legjobb eredményét függvénnyel. Szorgalmi: Kezeljük a lehetséges felhasználói hibát is.
            Console.WriteLine();
            Console.WriteLine("4.Feladat:");
            Console.Write("Melyik tanuló legjobb jegyét szeretné megtudni? :");
            string name = Console.ReadLine();
            Console.WriteLine(NegyedikFeladat(tanulok, name));

            //5. feladat: Egy új fájlba írjuk ki a fenti tanuló nevét és oktatási azonosítóját.
            using StreamWriter writer = new StreamWriter(path: @"..\..\..\src\lekert_tanulo.txt", false);
            writer.Write(tanulok.Find(t => t.Nev == name).Nev + "; " + tanulok.Find(t => t.Nev == name).Azonosito);
        }
        static double TanuloAtlag(Tanulo tanulo)
        {
            return Math.Round(tanulo.Ertekelesek.Average(v => v), 2);
        }
        static double OsztalyAtlag(List<Tanulo> tanulok)
        {
            int tanuloCount = tanulok.Count();
            double[] tanuloAtlagok= new double[tanuloCount];

            for (int i = 0; i < tanuloCount; i++)
            {
                tanuloAtlagok[i] = tanulok[i].Ertekelesek.Average(v => v);
            }

            return Math.Round(tanuloAtlagok.Average(), 2);
        }
        static double[] TantargyAtlag(List<Tanulo> tanulok)
        {
            int iterator = tanulok[0].Ertekelesek.Count();

            double[] tanAtlagok = new double[iterator];

            foreach (var tanulo in tanulok)
            {
                for (int i = 0; i < iterator; i++)
                {
                    tanAtlagok[i] += tanulo.Ertekelesek[i];
                }
            }

            for (int i = 0; i < iterator; i++)
            {
                tanAtlagok[i] = Math.Round(tanAtlagok[i] / tanulok.Count, 2);
            }

            return tanAtlagok;
        }
        static Tanulo HarmadikFeladat(List<Tanulo> tanulok)
        {
            return tanulok.First(t => t.Ertekelesek[4] == 3);
        }
        static int NegyedikFeladat(List<Tanulo> tanulok, string name)
        {
            Tanulo ans = tanulok.Find(t => t.Nev == name);
            return ans.Ertekelesek.Max();
        }
    }
}
