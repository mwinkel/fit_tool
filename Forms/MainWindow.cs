using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using ZedGraph;


namespace Fitness
{
    public partial class MainWindow : Form
    {
        private string arrowDown = " ▼";
        private string arrowUp = " ▲";
        private data.Xml xml;
        private Messwerte mw;
        private AddEntry a;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            resizeContent();

            xml = new data.Xml();
            mw = new Messwerte();

            refreshListView();
        }

        private void resizeContent()
        {
            int columnWidth = (listView1.ClientSize.Width / 6) - 5;
            int scrollBalken = 17;

            foreach (ColumnHeader ch in listView1.Columns)
            {
                if (ch.Index == 5)
                    ch.Width = listView1.ClientSize.Width - (5 * columnWidth) - scrollBalken;
                else
                    ch.Width = columnWidth;
            }
        }
        public void refreshListView()
        {
            listView1.Items.Clear();

            foreach (Messwert m in mw.getMesswerte())
            {
                listView1.Items.Add(new ListViewItem(m.getContent()));
            }

            CreateGraph(zedGraphControl1, mw.getLastFiveMesswerte());
            zedGraphControl1.Refresh();
        }

        private void zedGraphConfig(ZedGraphControl zgc)
        {
            GraphPane myPane = zgc.GraphPane;

            myPane.Title.Text = "Fitness Graph";
            myPane.XAxis.Title.Text = "Datum";
            myPane.YAxis.Title.Text = "";
        }
        private void CreateGraph(ZedGraphControl zgc, List<Messwert> werte)
        {
            zgc.GraphPane.CurveList.Clear();
            GraphPane myPane = zgc.GraphPane;

            PointPairList gewicht = new PointPairList();
            PointPairList fett = new PointPairList();
            PointPairList wasser = new PointPairList();
            PointPairList muskel = new PointPairList();
            PointPairList knochen = new PointPairList();

            int count = 1;
            string[] labels = new string[werte.Count];

            foreach (Messwert m in werte)
            {
                labels[count - 1] = m.MesswertDatum.ToShortDateString();
                gewicht.Add(count, m.Gewicht);
                fett.Add(count, m.FettAnteil);
                wasser.Add(count, m.WasserAnteil);
                muskel.Add(count, m.MuskelAnteil);
                knochen.Add(count++, m.KnochenMasse);
            }

            myPane.XAxis.Scale.TextLabels = labels;
            myPane.XAxis.Type = AxisType.Text;

            LineItem myCurve = myPane.AddCurve("Gewicht",
                  gewicht, Color.Red, SymbolType.Default);
            LineItem myCurve2 = myPane.AddCurve("Fettanteil",
                  fett, Color.Black, SymbolType.Default);
            LineItem myCurve3 = myPane.AddCurve("Wasseranteil",
                  wasser, Color.Blue, SymbolType.Default);
            LineItem myCurve4 = myPane.AddCurve("Muskelanteil",
                  muskel, Color.Orange, SymbolType.Default);
            LineItem myCurve5 = myPane.AddCurve("Knochenmasse",
                  knochen, Color.Silver, SymbolType.Default);

            zgc.AxisChange();
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void datenSichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Backup Datei|*.xml";
            saveFileDialog1.Title = "Datensätze sichern";
            saveFileDialog1.DefaultExt = ".xml";
            DialogResult result = saveFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                if (saveFileDialog1.FileName != "")
                {
                    if (!xml.xml_path.Equals(saveFileDialog1.FileName))
                        try
                        {
                            File.Copy(Application.StartupPath + "\\" + xml.xml_path, saveFileDialog1.FileName);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    else
                        infobar_show("Dateien identisch", 0);
                }
            }
            else { /* nichts :P */ }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                rechtsKlickMenu.Show(MousePosition.X, MousePosition.Y);
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            List<String> list = new List<String>(getSelectedListViewItems());
            StringBuilder sb = new StringBuilder();

            if (list.Capacity < 1)
            {
                infobar_show("Fehler.\n\nDatensatz markiert?", 0);
            }
            else
            {
                foreach (string s in list)
                    sb.Append(s + ", ");
                sb.Remove(sb.Length - 2, 2);

                DialogResult result = MessageBox.Show("Folgende Einträge entfernen?\n\n" +
                                sb.ToString() +
                                "\n", "Löschen", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    if (mw.removeMesswerte(list))
                        infobar_show("Einträge gelöscht.", 0);
                    else
                        infobar_show("Fehlgeschlagen.\n\nEs konnten keine / nicht alle Einträge gelöscht werden.", 0);

                    refreshListView();
                }
                else
                {
                    infobar_show("Keine Datensätze gelöscht. Vom Benutzer abgebrochen.", 0);
                }
            }
        }

        public void infobar_show(string text, int imageIndex)
        {
            infoBar.Text = text;
            infoBar.SmallImageList = imageListInfoBar;
            infoBar.ImageIndex = 0;
            infoBar.Show(true);
            Timer t = new Timer();
            t.Interval = 5000;
            t.Enabled = true;
            t.Tick += new EventHandler(infobar_hide);
        }

        void infobar_hide(object sender, EventArgs e)
        {
            infoBar.Hide(true);
        }
        private List<String> getSelectedListViewItems()
        {
            List<String> list = new List<String>();

            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Selected)
                    list.Add(item.Text);
            }

            return list;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            List<String> list = new List<String>(getSelectedListViewItems());

            if (list.Capacity != 1)
            {
                infobar_show("Fehler.\n\nBitte genau einen Datensatz auswählen!", 0);
            }
            else
            {
                Messwert m = xml.getMesswertDetails(list[0]);

                if (m != null)
                {
                    fillTextboxes(m);
                }
                else
                    infobar_show("Fehler beim finden des Datensatzes.", 0);
            }
        }

        private void fillTextboxes(Messwert m)
        {
            a = new AddEntry();
            a.messwert = m;
            //a.InputDatum = m.MesswertDatum;
            //a.InputGewicht = m.Gewicht;
            //a.InputFett = m.FettAnteil;
            //a.InputWasser = m.WasserAnteil;
            //a.InputMuskel = m.MuskelAnteil;
            //a.InputKnochen = m.KnochenMasse;

            a.Show();
            a.FormClosed += new FormClosedEventHandler(a_FormClosed);
        }

        int sortColumn = -1;

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (this.sortColumn == e.Column)
            {
                if (listView1.Sorting == SortOrder.Ascending)
                    this.listView1.Sorting = SortOrder.Descending;
                else
                    this.listView1.Sorting = SortOrder.Ascending;
            }
            else
            {
                this.sortColumn = e.Column;
                this.listView1.Sorting = SortOrder.Ascending;
            }

            switch (e.Column)
            {
                case 0:
                    this.listView1.ListViewItemSorter = new DateSorter(this.listView1.Sorting);
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    this.listView1.ListViewItemSorter = new DoubleSorter(this.listView1.Sorting, e.Column);
                    break;
            }

            /*
             *  TODO:   looks dirty :P
             */

            if (listView1.Sorting == SortOrder.Ascending)
                listView1.Columns[e.Column].Text = listView1.Columns[e.Column].Text.Replace(arrowDown, "") + arrowUp;
            else if (listView1.Sorting == SortOrder.Descending)
                listView1.Columns[e.Column].Text = listView1.Columns[e.Column].Text.Replace(arrowUp, "") + arrowDown;
            else
                listView1.Columns[e.Column].Text += arrowDown;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.StartPosition = FormStartPosition.CenterParent;
            a.Show();
        }
        private void btn_addEntry_Click(object sender, EventArgs e)
        {
            a = new AddEntry();
            a.StartPosition = FormStartPosition.CenterParent;
            a.Show();

            a.FormClosed += new FormClosedEventHandler(a_FormClosed);
        }

        void a_FormClosed(object sender, FormClosedEventArgs e)
        {
            if ((sender as AddEntry).successfull_saved)
            {
                mw.addMesswert((sender as AddEntry).messwert);
                infobar_show("Gespeichert.", 0);
            }
            else
                infobar_show("Nicht gespeichert.", 0);

            updateContent();
        }

        private void updateContent()
        {
            refreshListView();
            CreateGraph(zedGraphControl1, mw.getLastFiveMesswerte());
            zedGraphControl1.Refresh();
        }

        private void createToolTip(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBox2, "Refresh diagram with selected data");
            toolTip1.SetToolTip(pictureBox1, "Add entry");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            a = new AddEntry();
            a.StartPosition = FormStartPosition.CenterParent;
            a.Show();

            a.FormClosed += new FormClosedEventHandler(a_FormClosed);
        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            resizeContent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {

                List<string> selectedDates = new List<string>();

                foreach (ListViewItem item in listView1.Items)
                {
                    if (item.Selected)
                    {
                        selectedDates.Add(item.Text);
                    }
                }

                CreateGraph(zedGraphControl1, mw.getMesswerte(selectedDates));
                zedGraphControl1.Refresh();
            }
            else
            {
                CreateGraph(zedGraphControl1, mw.getLastFiveMesswerte());
            }
        }

        private void infoBar_MouseDown(object sender, MouseEventArgs e)
        {
            infoBar.Hide(true);
        }

        private void infoBar_MouseLeave(object sender, EventArgs e)
        {
            infoBar.BackColor = Color.FromArgb(192, 255, 192);
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            mw.save();
        }
    }
}
