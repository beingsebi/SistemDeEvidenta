
namespace SistemDeEvidenta
{
    partial class Rapoarte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rapoarte));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BBack = new System.Windows.Forms.Button();
            this.BElevi = new System.Windows.Forms.Button();
            this.BProf = new System.Windows.Forms.Button();
            this.BTaxe = new System.Windows.Forms.Button();
            this.LV = new System.Windows.Forms.ListView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel1.Controls.Add(this.BTaxe);
            this.panel1.Controls.Add(this.BProf);
            this.panel1.Controls.Add(this.BElevi);
            this.panel1.Controls.Add(this.BBack);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 624);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.LV);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(200, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(778, 624);
            this.panel2.TabIndex = 1;
            // 
            // BBack
            // 
            this.BBack.BackColor = System.Drawing.Color.LightSkyBlue;
            this.BBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BBack.BackgroundImage")));
            this.BBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BBack.Location = new System.Drawing.Point(3, 3);
            this.BBack.Margin = new System.Windows.Forms.Padding(0);
            this.BBack.Name = "BBack";
            this.BBack.Size = new System.Drawing.Size(46, 48);
            this.BBack.TabIndex = 0;
            this.BBack.UseVisualStyleBackColor = false;
            this.BBack.Click += new System.EventHandler(this.BBack_Click);
            // 
            // BElevi
            // 
            this.BElevi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BElevi.BackColor = System.Drawing.Color.Khaki;
            this.BElevi.Font = new System.Drawing.Font("Nirmala UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BElevi.Location = new System.Drawing.Point(29, 128);
            this.BElevi.Margin = new System.Windows.Forms.Padding(0);
            this.BElevi.Name = "BElevi";
            this.BElevi.Size = new System.Drawing.Size(140, 50);
            this.BElevi.TabIndex = 1;
            this.BElevi.Text = "Elevi";
            this.BElevi.UseVisualStyleBackColor = false;
            this.BElevi.Click += new System.EventHandler(this.BElevi_Click);
            // 
            // BProf
            // 
            this.BProf.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BProf.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BProf.Font = new System.Drawing.Font("Nirmala UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BProf.Location = new System.Drawing.Point(29, 226);
            this.BProf.Margin = new System.Windows.Forms.Padding(0);
            this.BProf.Name = "BProf";
            this.BProf.Size = new System.Drawing.Size(140, 50);
            this.BProf.TabIndex = 2;
            this.BProf.Text = "Profesori";
            this.BProf.UseVisualStyleBackColor = false;
            this.BProf.Click += new System.EventHandler(this.BProf_Click);
            // 
            // BTaxe
            // 
            this.BTaxe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BTaxe.BackColor = System.Drawing.Color.LimeGreen;
            this.BTaxe.Font = new System.Drawing.Font("Nirmala UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTaxe.Location = new System.Drawing.Point(29, 327);
            this.BTaxe.Margin = new System.Windows.Forms.Padding(0);
            this.BTaxe.Name = "BTaxe";
            this.BTaxe.Size = new System.Drawing.Size(140, 50);
            this.BTaxe.TabIndex = 3;
            this.BTaxe.Text = "Taxe";
            this.BTaxe.UseVisualStyleBackColor = false;
            this.BTaxe.Click += new System.EventHandler(this.BTaxe_Click);
            // 
            // LV
            // 
            this.LV.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LV.BackgroundImage")));
            this.LV.BackgroundImageTiled = true;
            this.LV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LV.GridLines = true;
            this.LV.HideSelection = false;
            this.LV.Location = new System.Drawing.Point(0, 0);
            this.LV.Name = "LV";
            this.LV.Size = new System.Drawing.Size(778, 624);
            this.LV.TabIndex = 0;
            this.LV.UseCompatibleStateImageBehavior = false;
            // 
            // Rapoarte
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(978, 624);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Nirmala UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1000, 732);
            this.MinimumSize = new System.Drawing.Size(900, 648);
            this.Name = "Rapoarte";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Rapoarte";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Rapoarte_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BBack;
        private System.Windows.Forms.Button BTaxe;
        private System.Windows.Forms.Button BProf;
        private System.Windows.Forms.Button BElevi;
        private System.Windows.Forms.ListView LV;
    }
}