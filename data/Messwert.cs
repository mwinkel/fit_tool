using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fitness {
    public class Messwert : IComparable {
        public DateTime MesswertDatum { get; set; }
        public double Gewicht { get; set; }
        public double FettAnteil { get; set; }
        public double WasserAnteil { get; set; }
        public double MuskelAnteil { get; set; }
        public double KnochenMasse { get; set; }
     
        public Messwert() {
            this.MesswertDatum = DateTime.Now;
            this.Gewicht = 0;
            this.FettAnteil = 0;
            this.WasserAnteil = 0;
            this.MuskelAnteil = 0;
            this.KnochenMasse = 0;
        }
        public string[] getContent() {
            string[] s = new string[6]{ 
                MesswertDatum.ToShortDateString(), 
                Gewicht.ToString() + " kg",
                FettAnteil.ToString() + " %", 
                WasserAnteil.ToString() + " %",
                MuskelAnteil.ToString() + " %",
                KnochenMasse.ToString() + " kg"};

            return s;
        }
        public string getString() {
            string data = "";
            foreach(string s in getContent()) {
                data += s + " ";
            }
            return data;
        }
        public int CompareTo(object obj) {
            Messwert my = (obj as Messwert);

            if(my != null)
                return this.MesswertDatum.CompareTo(my.MesswertDatum);

            return 1;
        }
    }
}
