namespace ProjektNr1_Kuźnicki_61961
{
    partial class KokpitProjektuNr1
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
            this.label1 = new System.Windows.Forms.Label();
            this.btn_laboratoriumnr1 = new System.Windows.Forms.Button();
            this.btn_indywidualnynr1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(192, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(432, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "Animacja komputerowa po linii toru wyznaczonego \r\nprzez wykres szeregu potęgowego" +
    "";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_laboratoriumnr1
            // 
            this.btn_laboratoriumnr1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_laboratoriumnr1.Location = new System.Drawing.Point(148, 225);
            this.btn_laboratoriumnr1.Name = "btn_laboratoriumnr1";
            this.btn_laboratoriumnr1.Size = new System.Drawing.Size(159, 67);
            this.btn_laboratoriumnr1.TabIndex = 1;
            this.btn_laboratoriumnr1.Text = "Laboratorium nr 1\r\n(szereg laboratoryjny)\r\n";
            this.btn_laboratoriumnr1.UseVisualStyleBackColor = true;
            this.btn_laboratoriumnr1.Click += new System.EventHandler(this.btn_laboratoriumnr1_Click);
            // 
            // btn_indywidualnynr1
            // 
            this.btn_indywidualnynr1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_indywidualnynr1.Location = new System.Drawing.Point(503, 225);
            this.btn_indywidualnynr1.Name = "btn_indywidualnynr1";
            this.btn_indywidualnynr1.Size = new System.Drawing.Size(159, 67);
            this.btn_indywidualnynr1.TabIndex = 3;
            this.btn_indywidualnynr1.Text = "Projekt nr 1\r\n(szereg indywidualny)\r\n";
            this.btn_indywidualnynr1.UseVisualStyleBackColor = true;
            this.btn_indywidualnynr1.Click += new System.EventHandler(this.btn_indywidualnynr1_Click);
            // 
            // KokpitProjektuNr1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_indywidualnynr1);
            this.Controls.Add(this.btn_laboratoriumnr1);
            this.Controls.Add(this.label1);
            this.Name = "KokpitProjektuNr1";
            this.Text = "Animacja komputerowa po linii toru";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KokpitProjektuNr1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_laboratoriumnr1;
        private System.Windows.Forms.Button btn_indywidualnynr1;
    }
}

