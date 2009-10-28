using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/*
 * TODO: Messagbox -> Infobar
 */

namespace Fitness
{
    public partial class AddEntry : Form
    {
        private data.Xml xml;
        public bool successfull_saved { get; set; }
        public Messwert messwert { get; set; }

        public AddEntry()
        {
            InitializeComponent();
        }
        private void AddEntry_Load(object sender, EventArgs e)
        {
            if (messwert.MesswertDatum != null)
            {
                input_datum.Value = messwert.MesswertDatum;
                input_gewicht.Text = messwert.Gewicht.ToString();
                input_fett.Text = messwert.FettAnteil.ToString();
                input_wasser.Text = messwert.WasserAnteil.ToString();
                input_muskel.Text = messwert.MuskelAnteil.ToString();
                input_knochen.Text = messwert.KnochenMasse.ToString();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                xml = new Fitness.data.Xml();

                messwert = new Messwert();
                messwert.MesswertDatum = input_datum.Value;
                messwert.Gewicht = Convert.ToDouble(input_gewicht.Text);
                messwert.FettAnteil = Convert.ToDouble(input_fett.Text);
                messwert.WasserAnteil = Convert.ToDouble(input_wasser.Text);
                messwert.MuskelAnteil = Convert.ToDouble(input_muskel.Text);
                messwert.KnochenMasse = Convert.ToDouble(input_knochen.Text);

                if (xml.addEntry(messwert))
                {
                    successfull_saved = true;
                }
                
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "Falsches Format",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }
        private void input_leave(object sender, EventArgs e)
        {
            TextBox tb = (sender as TextBox);

            if (tb.Text.Length > 2)
                tb.Text = tb.Text.Insert(tb.Text.Length - 1, ",");
        }
    }
}
