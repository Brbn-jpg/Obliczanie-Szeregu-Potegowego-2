namespace ProjektNr1_Kuźnicki_61961
{
    partial class LaboratoriumNr1
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
            this.components = new System.ComponentModel.Container();
            this.pb_rysownica = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txt_Xd = new System.Windows.Forms.TextBox();
            this.txt_H = new System.Windows.Forms.TextBox();
            this.txt_Xg = new System.Windows.Forms.TextBox();
            this.lbl_Xd = new System.Windows.Forms.Label();
            this.lbl_H = new System.Windows.Forms.Label();
            this.lbl_Xg = new System.Windows.Forms.Label();
            this.btn_animacja = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.edycjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gruboscLiniiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kolorLiniiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.stylLiniiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liniaKreskowadashToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liniaKreskowokropkowadashdotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liniaKreskowokropkowakropkowadashdotdotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liniaKropkowadotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liniaCiaglasolidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pb_rysownica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pb_rysownica
            // 
            this.pb_rysownica.Location = new System.Drawing.Point(25, 44);
            this.pb_rysownica.Name = "pb_rysownica";
            this.pb_rysownica.Size = new System.Drawing.Size(799, 467);
            this.pb_rysownica.TabIndex = 0;
            this.pb_rysownica.TabStop = false;
            this.pb_rysownica.Paint += new System.Windows.Forms.PaintEventHandler(this.pb_rysownica_Paint);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txt_Xd
            // 
            this.txt_Xd.Location = new System.Drawing.Point(889, 192);
            this.txt_Xd.Name = "txt_Xd";
            this.txt_Xd.Size = new System.Drawing.Size(34, 20);
            this.txt_Xd.TabIndex = 1;
            // 
            // txt_H
            // 
            this.txt_H.Location = new System.Drawing.Point(889, 303);
            this.txt_H.Name = "txt_H";
            this.txt_H.Size = new System.Drawing.Size(34, 20);
            this.txt_H.TabIndex = 2;
            // 
            // txt_Xg
            // 
            this.txt_Xg.Location = new System.Drawing.Point(889, 218);
            this.txt_Xg.Name = "txt_Xg";
            this.txt_Xg.Size = new System.Drawing.Size(34, 20);
            this.txt_Xg.TabIndex = 3;
            // 
            // lbl_Xd
            // 
            this.lbl_Xd.AutoSize = true;
            this.lbl_Xd.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbl_Xd.Location = new System.Drawing.Point(850, 189);
            this.lbl_Xd.Name = "lbl_Xd";
            this.lbl_Xd.Size = new System.Drawing.Size(33, 22);
            this.lbl_Xd.TabIndex = 4;
            this.lbl_Xd.Text = "Xd";
            // 
            // lbl_H
            // 
            this.lbl_H.AutoSize = true;
            this.lbl_H.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbl_H.Location = new System.Drawing.Point(859, 300);
            this.lbl_H.Name = "lbl_H";
            this.lbl_H.Size = new System.Drawing.Size(24, 22);
            this.lbl_H.TabIndex = 5;
            this.lbl_H.Text = "H";
            // 
            // lbl_Xg
            // 
            this.lbl_Xg.AutoSize = true;
            this.lbl_Xg.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Xg.Location = new System.Drawing.Point(850, 216);
            this.lbl_Xg.Name = "lbl_Xg";
            this.lbl_Xg.Size = new System.Drawing.Size(33, 22);
            this.lbl_Xg.TabIndex = 6;
            this.lbl_Xg.Text = "Xg";
            // 
            // btn_animacja
            // 
            this.btn_animacja.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.btn_animacja.Location = new System.Drawing.Point(847, 44);
            this.btn_animacja.Name = "btn_animacja";
            this.btn_animacja.Size = new System.Drawing.Size(158, 67);
            this.btn_animacja.TabIndex = 7;
            this.btn_animacja.Text = "Animacja";
            this.btn_animacja.UseVisualStyleBackColor = true;
            this.btn_animacja.Click += new System.EventHandler(this.btn_animacja_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(854, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 44);
            this.label1.TabIndex = 8;
            this.label1.Text = "Przedział wartości \r\nzmiennej niezależnej X:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(854, 266);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 22);
            this.label2.TabIndex = 9;
            this.label2.Text = "H (krok zmian wartości X)";
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.edycjaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1100, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // edycjaToolStripMenuItem
            // 
            this.edycjaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gruboscLiniiToolStripMenuItem,
            this.kolorLiniiToolStripMenuItem,
            this.stylLiniiToolStripMenuItem});
            this.edycjaToolStripMenuItem.Name = "edycjaToolStripMenuItem";
            this.edycjaToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.edycjaToolStripMenuItem.Text = "Obramowanie";
            // 
            // gruboscLiniiToolStripMenuItem
            // 
            this.gruboscLiniiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6});
            this.gruboscLiniiToolStripMenuItem.Name = "gruboscLiniiToolStripMenuItem";
            this.gruboscLiniiToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gruboscLiniiToolStripMenuItem.Text = "Grubosc linii";
            // 
            // kolorLiniiToolStripMenuItem
            // 
            this.kolorLiniiToolStripMenuItem.Name = "kolorLiniiToolStripMenuItem";
            this.kolorLiniiToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.kolorLiniiToolStripMenuItem.Text = "Kolor linii";
            this.kolorLiniiToolStripMenuItem.Click += new System.EventHandler(this.kolorLiniiToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem2.Text = "1";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem3.Text = "2";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem4.Text = "3";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem5.Text = "4";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem6.Text = "5";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // stylLiniiToolStripMenuItem
            // 
            this.stylLiniiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.liniaKreskowadashToolStripMenuItem,
            this.liniaKreskowokropkowadashdotToolStripMenuItem,
            this.liniaKreskowokropkowakropkowadashdotdotToolStripMenuItem,
            this.liniaKropkowadotToolStripMenuItem,
            this.liniaCiaglasolidToolStripMenuItem});
            this.stylLiniiToolStripMenuItem.Name = "stylLiniiToolStripMenuItem";
            this.stylLiniiToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.stylLiniiToolStripMenuItem.Text = "Styl linii";
            // 
            // liniaKreskowadashToolStripMenuItem
            // 
            this.liniaKreskowadashToolStripMenuItem.Name = "liniaKreskowadashToolStripMenuItem";
            this.liniaKreskowadashToolStripMenuItem.Size = new System.Drawing.Size(348, 22);
            this.liniaKreskowadashToolStripMenuItem.Text = "Linia kreskowa (dash)";
            this.liniaKreskowadashToolStripMenuItem.Click += new System.EventHandler(this.liniaKreskowadashToolStripMenuItem_Click);
            // 
            // liniaKreskowokropkowadashdotToolStripMenuItem
            // 
            this.liniaKreskowokropkowadashdotToolStripMenuItem.Name = "liniaKreskowokropkowadashdotToolStripMenuItem";
            this.liniaKreskowokropkowadashdotToolStripMenuItem.Size = new System.Drawing.Size(348, 22);
            this.liniaKreskowokropkowadashdotToolStripMenuItem.Text = "Linia kreskowo-kropkowa (dash-dot)";
            this.liniaKreskowokropkowadashdotToolStripMenuItem.Click += new System.EventHandler(this.liniaKreskowokropkowadashdotToolStripMenuItem_Click);
            // 
            // liniaKreskowokropkowakropkowadashdotdotToolStripMenuItem
            // 
            this.liniaKreskowokropkowakropkowadashdotdotToolStripMenuItem.Name = "liniaKreskowokropkowakropkowadashdotdotToolStripMenuItem";
            this.liniaKreskowokropkowakropkowadashdotdotToolStripMenuItem.Size = new System.Drawing.Size(348, 22);
            this.liniaKreskowokropkowakropkowadashdotdotToolStripMenuItem.Text = "Linia kreskowo-kropkowa-kropkowa (dash-dot-dot)";
            this.liniaKreskowokropkowakropkowadashdotdotToolStripMenuItem.Click += new System.EventHandler(this.liniaKreskowokropkowakropkowadashdotdotToolStripMenuItem_Click);
            // 
            // liniaKropkowadotToolStripMenuItem
            // 
            this.liniaKropkowadotToolStripMenuItem.Name = "liniaKropkowadotToolStripMenuItem";
            this.liniaKropkowadotToolStripMenuItem.Size = new System.Drawing.Size(348, 22);
            this.liniaKropkowadotToolStripMenuItem.Text = "Linia kropkowa (dot)";
            this.liniaKropkowadotToolStripMenuItem.Click += new System.EventHandler(this.liniaKropkowadotToolStripMenuItem_Click);
            // 
            // liniaCiaglasolidToolStripMenuItem
            // 
            this.liniaCiaglasolidToolStripMenuItem.Name = "liniaCiaglasolidToolStripMenuItem";
            this.liniaCiaglasolidToolStripMenuItem.Size = new System.Drawing.Size(348, 22);
            this.liniaCiaglasolidToolStripMenuItem.Text = "Linia ciagla (solid)";
            this.liniaCiaglasolidToolStripMenuItem.Click += new System.EventHandler(this.liniaCiaglasolidToolStripMenuItem_Click);
            // 
            // LaboratoriumNr1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 614);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_animacja);
            this.Controls.Add(this.lbl_Xg);
            this.Controls.Add(this.lbl_H);
            this.Controls.Add(this.lbl_Xd);
            this.Controls.Add(this.txt_Xg);
            this.Controls.Add(this.txt_H);
            this.Controls.Add(this.txt_Xd);
            this.Controls.Add(this.pb_rysownica);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "LaboratoriumNr1";
            this.Text = "LaboratoriumNr1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LaboratoriumNr1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pb_rysownica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_rysownica;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txt_Xd;
        private System.Windows.Forms.TextBox txt_H;
        private System.Windows.Forms.TextBox txt_Xg;
        private System.Windows.Forms.Label lbl_Xd;
        private System.Windows.Forms.Label lbl_H;
        private System.Windows.Forms.Label lbl_Xg;
        private System.Windows.Forms.Button btn_animacja;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Diagnostics.EventLog eventLog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem edycjaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gruboscLiniiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kolorLiniiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem stylLiniiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liniaKreskowadashToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liniaKreskowokropkowadashdotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liniaKreskowokropkowakropkowadashdotdotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liniaKropkowadotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liniaCiaglasolidToolStripMenuItem;
    }
}