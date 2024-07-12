namespace GEN.ControlesBase
{
    partial class conActividad
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cboCIIU = new GEN.ControlesBase.cboActividadEco(this.components);
            this.cboActividadEco = new GEN.ControlesBase.cboActividadEco(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboGrupoCiiu = new GEN.ControlesBase.cboActividadEco(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.SuspendLayout();
            // 
            // cboCIIU
            // 
            this.cboCIIU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCIIU.DropDownWidth = 510;
            this.cboCIIU.FormattingEnabled = true;
            this.cboCIIU.Location = new System.Drawing.Point(102, 53);
            this.cboCIIU.Name = "cboCIIU";
            this.cboCIIU.Size = new System.Drawing.Size(280, 21);
            this.cboCIIU.TabIndex = 70;
            // 
            // cboActividadEco
            // 
            this.cboActividadEco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboActividadEco.DropDownWidth = 400;
            this.cboActividadEco.FormattingEnabled = true;
            this.cboActividadEco.Location = new System.Drawing.Point(102, 5);
            this.cboActividadEco.Name = "cboActividadEco";
            this.cboActividadEco.Size = new System.Drawing.Size(280, 21);
            this.cboActividadEco.TabIndex = 69;
            this.cboActividadEco.SelectedIndexChanged += new System.EventHandler(this.cboActividadEco_SelectedIndexChanged);
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(3, 32);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(47, 13);
            this.lblBase6.TabIndex = 72;
            this.lblBase6.Text = "Grupo:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(4, 56);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(39, 13);
            this.lblBase3.TabIndex = 73;
            this.lblBase3.Text = "CIIU:";
            // 
            // cboGrupoCiiu
            // 
            this.cboGrupoCiiu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrupoCiiu.DropDownWidth = 510;
            this.cboGrupoCiiu.FormattingEnabled = true;
            this.cboGrupoCiiu.Location = new System.Drawing.Point(102, 29);
            this.cboGrupoCiiu.Name = "cboGrupoCiiu";
            this.cboGrupoCiiu.Size = new System.Drawing.Size(280, 21);
            this.cboGrupoCiiu.TabIndex = 68;
            this.cboGrupoCiiu.SelectedIndexChanged += new System.EventHandler(this.cboGrupoCiiu_SelectedIndexChanged);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(4, 8);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(99, 13);
            this.lblBase5.TabIndex = 71;
            this.lblBase5.Text = "Act. Económica:";
            // 
            // conActividad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cboCIIU);
            this.Controls.Add(this.cboActividadEco);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.cboGrupoCiiu);
            this.Controls.Add(this.lblBase5);
            this.Name = "conActividad";
            this.Size = new System.Drawing.Size(389, 78);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public cboActividadEco cboCIIU;
        public cboActividadEco cboActividadEco;
        public lblBase lblBase6;
        public lblBase lblBase3;
        public cboActividadEco cboGrupoCiiu;
        public lblBase lblBase5;
    }
}
