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
            Console.WriteLine("Osztály átlagok:");
            Console.WriteLine(OsztalyAtlag(tanulok));
            //2. feladat: Programozás gyakorlatból megbukottak adatainak kiiratása.
            //3. feladat: Írjunk függvényt, amivel keressük meg az első olyan embert, akinek hármasa van angol nyelvből, majd írjuk ki az adatait.
            //4. feladat: Kérjük be a felhasználótól, melyik tanuló legjobb jegyét szeretné megtudni.
            //Írjuk ki az adott tanuló legjobb eredményét függvénnyel. Szorgalmi: Kezeljük a lehetséges felhasználói hibát is.
            //5. feladat: Egy új fájlba írjuk ki a fenti tanuló nevét és oktatási azonosítóját.
        }
        static double TanuloAtlag(Tanulo tanulo)
        {
            return tanulo.Ertekelesek.Average(v => v);
        }
        static double OsztalyAtlag(List<Tanulo> tanulok)
        {
            int tanuloCount = tanulok.Count();
            double[] tanuloAtlagok= new double[tanuloCount];

            for (int i = 0; i < tanuloCount; i++)
            {
                tanuloAtlagok[i] = tanulok[i].Ertekelesek.Average(v => v);
            }

            return tanuloAtlagok.Average();
        }
    }
}
