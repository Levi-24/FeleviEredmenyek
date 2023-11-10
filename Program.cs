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

            foreach (var item in definiciok)
            {
                Console.Write($"{item},");
            }
            foreach (var item in tanulok)
            {
                Console.WriteLine(item);
            }
            //1. feladat
            //Írjunk függvényt, ami kiszámítja a jegyek átlagát tanulónként.Írjunk függvényt, ami kiszámítja az osztályátlagot, illetve a tantárgyankénti átlagot is.
            //2. feladat: Programozás gyakorlatból megbukottak adatainak kiiratása.
            //3. feladat: Írjunk függvényt, amivel keressük meg az első olyan embert, akinek hármasa van angol nyelvből, majd írjuk ki az adatait.
            //4. feladat: Kérjük be a felhasználótól, melyik tanuló legjobb jegyét szeretné megtudni.
            //Írjuk ki az adott tanuló legjobb eredményét függvénnyel. Szorgalmi: Kezeljük a lehetséges felhasználói hibát is.
            //5. feladat: Egy új fájlba írjuk ki a fenti tanuló nevét és oktatási azonosítóját.
        }
    }
}
