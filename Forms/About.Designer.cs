namespace Fitness
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_expand = new System.Windows.Forms.Button();
            this.text_version = new System.Windows.Forms.Label();
            this.lbl_version = new System.Windows.Forms.Label();
            this.text_author = new System.Windows.Forms.Label();
            this.lbl_author = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Controls.Add(this.btn_expand);
            this.groupBox1.Controls.Add(this.text_version);
            this.groupBox1.Controls.Add(this.lbl_version);
            this.groupBox1.Controls.Add(this.text_author);
            this.groupBox1.Controls.Add(this.lbl_author);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(310, 256);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "";
            this.groupBox1.Text = "Information";
            // 
            // btn_expand
            // 
            this.btn_expand.Location = new System.Drawing.Point(229, 75);
            this.btn_expand.Name = "btn_expand";
            this.btn_expand.Size = new System.Drawing.Size(75, 23);
            this.btn_expand.TabIndex = 4;
            this.btn_expand.Text = "Changelog";
            this.btn_expand.UseVisualStyleBackColor = true;
            this.btn_expand.Click += new System.EventHandler(this.btn_expand_Click);
            // 
            // text_version
            // 
            this.text_version.AutoSize = true;
            this.text_version.Location = new System.Drawing.Point(167, 43);
            this.text_version.Name = "text_version";
            this.text_version.Size = new System.Drawing.Size(0, 13);
            this.text_version.TabIndex = 3;
            // 
            // lbl_version
            // 
            this.lbl_version.AutoSize = true;
            this.lbl_version.Location = new System.Drawing.Point(75, 43);
            this.lbl_version.Name = "lbl_version";
            this.lbl_version.Size = new System.Drawing.Size(45, 13);
            this.lbl_version.TabIndex = 2;
            this.lbl_version.Text = "Version:";
            // 
            // text_author
            // 
            this.text_author.AutoSize = true;
            this.text_author.Location = new System.Drawing.Point(167, 16);
            this.text_author.Name = "text_author";
            this.text_author.Size = new System.Drawing.Size(75, 13);
            this.text_author.TabIndex = 1;
            this.text_author.Text = "Marcel Winkel";
            // 
            // lbl_author
            // 
            this.lbl_author.AutoSize = true;
            this.lbl_author.Location = new System.Drawing.Point(75, 16);
            this.lbl_author.Name = "lbl_author";
            this.lbl_author.Size = new System.Drawing.Size(41, 13);
            this.lbl_author.TabIndex = 0;
            this.lbl_author.Text = "Author:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(6, 116);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(298, 134);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 280);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "About";
            this.Text = "About";
            this.Load += new System.EventHandler(this.About_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label text_author;
        private System.Windows.Forms.Label lbl_author;
        private System.Windows.Forms.Label text_version;
        private System.Windows.Forms.Label lbl_version;
        private System.Windows.Forms.Button btn_expand;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}