using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Fitness
{
    public class Messwerte
    {
        public List<Messwert> MesswertListe;
        private static data.Xml xml = new Fitness.data.Xml();

        public void addMesswert(Messwert mw)
        {
            this.MesswertListe.Add(mw);
        }
        public void Sort()
        {
            this.MesswertListe.Sort();
        }
        public bool Contains(Messwert m)
        {
            foreach (Messwert messwert in MesswertListe)
            {
                if (messwert.MesswertDatum.ToShortDateString().Equals(m.MesswertDatum.ToShortDateString()))
                    return true;
            }

            return false;
        }
        public List<Messwert> getMesswerte(List<string> dates)
        {
            List<Messwert> selected = new List<Messwert>();

            foreach (Messwert m in MesswertListe)
            {
                foreach (string s in dates)
                {
                    if (m.MesswertDatum.ToShortDateString().Equals(s))
                        selected.Add(m);
                }
            }

            return selected;
        }
        public List<Messwert> getMesswerte()
        {
            if (MesswertListe == null)
                MesswertListe = xml.getMesswerte();

            return MesswertListe;
        }
        public List<Messwert> getLastFiveMesswerte()
        {
            int length = MesswertListe.Count;

            return (length < 5) ?
                this.MesswertListe.GetRange(this.MesswertListe.Count - length, length) :
                this.MesswertListe.GetRange(this.MesswertListe.Count - 5, 5);
        }
        public Boolean removeMesswert(String datum)
        {
            Messwert tmp = new Messwert();
            tmp.MesswertDatum = Convert.ToDateTime(datum);

            foreach (Messwert m in MesswertListe)
            {
                if (m.MesswertDatum.ToShortDateString().Equals(datum))
                {
                    MesswertListe.Remove(m);
                    return true;
                }
            }

            return false;
        }
        public bool removeMesswerte(List<string> list)
        {
            bool success = true;

            foreach (string s in list)
            {
                if (removeMesswert(s) == false)
                    success = false;
            }

            save();
            return success;
        }
        public int Anzahl()
        {
            return this.MesswertListe.Count;
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < this.MesswertListe.Count; i++)
                yield return this.MesswertListe[i];
        }
        public void save()
        {
            MesswertListe.Sort();
            xml.saveMesswerte(this);
        }
    }
}
