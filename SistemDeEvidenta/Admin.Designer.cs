
namespace SistemDeEvidenta
{
    partial class Admin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TBDescriere = new System.Windows.Forms.TextBox();
            this.TBDenumire = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BBack = new System.Windows.Forms.Button();
            this.BAdd = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.LV = new System.Windows.Forms.ListView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel1.Controls.Add(this.LV);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(978, 594);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkCyan;
            this.panel2.Controls.Add(this.BAdd);
            this.panel2.Controls.Add(this.TBDescriere);
            this.panel2.Controls.Add(this.TBDenumire);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.BBack);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(426, 594);
            this.panel2.TabIndex = 1;
            // 
            // TBDescriere
            // 
            this.TBDescriere.BackColor = System.Drawing.Color.SkyBlue;
            this.TBDescriere.Location = new System.Drawing.Point(190, 304);
            this.TBDescriere.Margin = new System.Windows.Forms.Padding(0);
            this.TBDescriere.Multiline = true;
            this.TBDescriere.Name = "TBDescriere";
            this.TBDescriere.Size = new System.Drawing.Size(188, 64);
            this.TBDescriere.TabIndex = 6;
            // 
            // TBDenumire
            // 
            this.TBDenumire.BackColor = System.Drawing.Color.LightSkyBlue;
            this.TBDenumire.Location = new System.Drawing.Point(190, 208);
            this.TBDenumire.Margin = new System.Windows.Forms.Padding(0);
            this.TBDenumire.Multiline = true;
            this.TBDenumire.Name = "TBDenumire";
            this.TBDenumire.Size = new System.Drawing.Size(188, 64);
            this.TBDenumire.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 294);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 73);
            this.label3.TabIndex = 4;
            this.label3.Text = "Descriere";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 208);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 73);
            this.label2.TabIndex = 3;
            this.label2.Text = "Denumire";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(120, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 73);
            this.label1.TabIndex = 2;
            this.label1.Text = "Adaugare Taxe";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BBack
            // 
            this.BBack.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.BBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BBack.BackgroundImage")));
            this.BBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BBack.Location = new System.Drawing.Point(0, 0);
            this.BBack.Margin = new System.Windows.Forms.Padding(0);
            this.BBack.Name = "BBack";
            this.BBack.Size = new System.Drawing.Size(46, 46);
            this.BBack.TabIndex = 1;
            this.BBack.UseVisualStyleBackColor = false;
            this.BBack.Click += new System.EventHandler(this.BBack_Click);
            // 
            // BAdd
            // 
            this.BAdd.BackColor = System.Drawing.Color.LightSkyBlue;
            this.BAdd.Location = new System.Drawing.Point(38, 421);
            this.BAdd.Margin = new System.Windows.Forms.Padding(0);
            this.BAdd.Name = "BAdd";
            this.BAdd.Size = new System.Drawing.Size(340, 55);
            this.BAdd.TabIndex = 7;
            this.BAdd.Text = "Adaugare";
            this.BAdd.UseVisualStyleBackColor = false;
            this.BAdd.Click += new System.EventHandler(this.BAdd_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(632, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 73);
            this.label4.TabIndex = 8;
            this.label4.Text = "Taxe";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LV
            // 
            this.LV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LV.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LV.BackgroundImage")));
            this.LV.BackgroundImageTiled = true;
            this.LV.GridLines = true;
            this.LV.HideSelection = false;
            this.LV.Location = new System.Drawing.Point(459, 85);
            this.LV.Name = "LV";
            this.LV.Size = new System.Drawing.Size(489, 203);
            this.LV.TabIndex = 9;
            this.LV.UseCompatibleStateImageBehavior = false;
            // 
            // Admin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(978, 594);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Nirmala UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1000, 700);
            this.MinimumSize = new System.Drawing.Size(900, 620);
            this.Name = "Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Admin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Admin_FormClosing);
            this.Load += new System.EventHandler(this.Admin_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BBack;
        private System.Windows.Forms.TextBox TBDescriere;
        private System.Windows.Forms.TextBox TBDenumire;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BAdd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView LV;
    }
}