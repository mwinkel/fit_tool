namespace Fitness
{
    partial class AddEntry
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEntry));
            this.label1 = new System.Windows.Forms.Label();
            this.input_wasser = new System.Windows.Forms.TextBox();
            this.input_muskel = new System.Windows.Forms.TextBox();
            this.input_fett = new System.Windows.Forms.TextBox();
            this.input_knochen = new System.Windows.Forms.TextBox();
            this.input_gewicht = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.input_datum = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Fettanteil in %";
            // 
            // input_wasser
            // 
            this.input_wasser.Location = new System.Drawing.Point(139, 121);
            this.input_wasser.Name = "input_wasser";
            this.input_wasser.Size = new System.Drawing.Size(77, 20);
            this.input_wasser.TabIndex = 16;
            this.input_wasser.Leave += new System.EventHandler(this.input_leave);
            // 
            // input_muskel
            // 
            this.input_muskel.Location = new System.Drawing.Point(139, 147);
            this.input_muskel.Name = "input_muskel";
            this.input_muskel.Size = new System.Drawing.Size(77, 20);
            this.input_muskel.TabIndex = 17;
            this.input_muskel.Leave += new System.EventHandler(this.input_leave);
            // 
            // input_fett
            // 
            this.input_fett.Location = new System.Drawing.Point(139, 95);
            this.input_fett.Name = "input_fett";
            this.input_fett.Size = new System.Drawing.Size(77, 20);
            this.input_fett.TabIndex = 15;
            this.input_fett.Leave += new System.EventHandler(this.input_leave);
            // 
            // input_knochen
            // 
            this.input_knochen.Location = new System.Drawing.Point(139, 173);
            this.input_knochen.Name = "input_knochen";
            this.input_knochen.Size = new System.Drawing.Size(77, 20);
            this.input_knochen.TabIndex = 18;
            this.input_knochen.Leave += new System.EventHandler(this.input_leave);
            // 
            // input_gewicht
            // 
            this.input_gewicht.Location = new System.Drawing.Point(139, 69);
            this.input_gewicht.Name = "input_gewicht";
            this.input_gewicht.Size = new System.Drawing.Size(77, 20);
            this.input_gewicht.TabIndex = 14;
            this.input_gewicht.Leave += new System.EventHandler(this.input_leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Wasseranteil in %";
            // 
            // input_datum
            // 
            this.input_datum.Location = new System.Drawing.Point(139, 41);
            this.input_datum.Name = "input_datum";
            this.input_datum.Size = new System.Drawing.Size(200, 20);
            this.input_datum.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Muskelanteil in %";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Gewicht in kg";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Knochenmasse in kg";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(264, 171);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Speichern";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Datum des Datensatzes";
            // 
            // AddEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 209);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.input_wasser);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.input_muskel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.input_fett);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.input_knochen);
            this.Controls.Add(this.input_datum);
            this.Controls.Add(this.input_gewicht);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddEntry";
            this.Text = "AddEntry";
            this.Load += new System.EventHandler(this.AddEntry_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox input_wasser;
        private System.Windows.Forms.TextBox input_muskel;
        private System.Windows.Forms.TextBox input_fett;
        private System.Windows.Forms.TextBox input_knochen;
        private System.Windows.Forms.TextBox input_gewicht;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker input_datum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
    }
}