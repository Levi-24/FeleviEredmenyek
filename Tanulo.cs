﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeleviEredmenyek
{
    class Tanulo
    {
        //Tanuló neve Oktatási azonosító  Hálózatok I.Hálózatok I.gyakorlat Programozás Programozás gyakorlat Angol nyelv Magyar nyelv és irodalom  Matematika Történelem
        public string Nev { get; set; }
        public double Azonosito { get; set; }
        public List<int> Ertekelesek { get; set; }
        public double Atlag => Ertekelesek.Average();

        public Tanulo(string line)
        {
            string sep = "\t";
            var pieces = line.Split(sep.ToCharArray());
            this.Nev = pieces[0];
            this.Azonosito = double.Parse(pieces[1]);
            Ertekelesek = new();
            for (int i = 2; i < pieces.Length ; i++)
            {
                this.Ertekelesek.Add(int.Parse(pieces[i]));
            }
        }

        public override string ToString()
        {
            string returns = $"{this.Nev}, {this.Azonosito}, ";
            foreach (var jegy in Ertekelesek) returns += jegy + ", ";
            return returns;
        }
    }
}
