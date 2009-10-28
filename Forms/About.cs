using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fitness
{
    public partial class About : Form
    {
        private bool expanded = false;
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(Size.Width, 165);
            this.MaximumSize = new Size(Size.Width, 165);
            text_version.Text = Properties.Settings.Default.version;
            
        }

        private void btn_expand_Click(object sender, EventArgs e)
        {
            if (!expanded)
            {
                expanded = true;
                richTextBox1.Text = changeLog();
                this.MaximumSize = new Size(Size.Width, 450);
                this.MinimumSize = new Size(Size.Width, 450);
                btn_expand.Text = "Minimize";
            }
            else
            {
                expanded = false;
                this.MaximumSize = new Size(Size.Width, 165);
                this.MinimumSize = new Size(Size.Width, 165);
                btn_expand.Text = "Changelog";
            }
        }

        /*
         *  TODO: extern abspeichern den mist
         */
        private string changeLog()
        {
            return "0.4:" + Environment.NewLine + "\t- tabview -> new Inputform (add entry)" + Environment.NewLine +
                   "0.3:" + Environment.NewLine + "\t- edit, remove entry";
        }
    }
}
