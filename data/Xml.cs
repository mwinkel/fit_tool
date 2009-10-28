using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.IO;
using System.Windows.Forms;

/*
 * Refactor:    Nur noch XML lesen / schreiben
 *              Alles andere raus hier ?!
 */

namespace Fitness.data {
    class Xml {
        public string xml_path { get; set; }
        private Properties.Settings settings;

        public Xml() {
            settings = Properties.Settings.Default;
            settings.Reload();

            this.xml_path = settings.xml_path;

            try {
                if(!(new FileInfo(xml_path).Exists)) {
                    createXmlFile();
                    MessageBox.Show("Xml File '" + xml_path + "' wurde angelegt.");
                }
            }
            catch(Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }
        private void createXmlFile() {
            Messwerte messwertListe = new Messwerte();

            saveMesswerte(messwertListe);
        }
        public bool addEntry(Messwert m) {
            XmlSerializer serializer = new XmlSerializer(typeof(Messwerte));
            FileStream fs = new FileStream(xml_path, FileMode.Open);
            Messwerte mListe = (Messwerte)serializer.Deserialize(fs);
            fs.Close();

            if(mListe.Contains(m)){
                DialogResult overwrite = MessageBox.Show("Für das Datum " + m.MesswertDatum + " ist schon ein Datensatz vorhanden.\n\nSoll der vorhandene Datensatz überschrieben werden?", 
                                "Datensatz schon vorhanden.",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Information);

                if (overwrite == DialogResult.Yes)
                {
                    mListe.removeMesswert(m.MesswertDatum.ToShortDateString());
                    mListe.MesswertListe.Add(m);
                    saveMesswerte(mListe);
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                mListe.MesswertListe.Add(m);
                saveMesswerte(mListe);
                return true;
            }
        }

        public void saveMesswerte(Messwerte mListe)
        {
            XmlTextWriter writer = new XmlTextWriter(xml_path, Encoding.UTF8);
            XmlSerializer serializer = new XmlSerializer(typeof(Messwerte));
            serializer.Serialize(writer, mListe);
            writer.Close();
        }
        public List<Messwert> getMesswerte() {
            XmlTextReader reader = new XmlTextReader(xml_path);
            XmlSerializer serializer = new XmlSerializer(typeof(Messwerte));
            Messwerte mListe = (Messwerte)serializer.Deserialize(reader);
            reader.Close();

            return mListe.MesswertListe;
        }
        public Messwert getMesswertDetails(string datum) {

            foreach (Messwert tmp in getMesswerte())
            {
                if (tmp.MesswertDatum.ToShortDateString().Equals(datum))
                {
                    return tmp;
                }
            }

            return null;
        }
    }
}
