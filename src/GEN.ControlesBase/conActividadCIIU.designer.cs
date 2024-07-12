namespace GEN.ControlesBase
{
    partial class conActividadCIIU
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(conActividadCIIU));
            this.ttpMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.cboCIIU = new GEN.ControlesBase.cboActividadEco(this.components);
            this.cboActividadEco = new GEN.ControlesBase.cboActividadEco(this.components);
            this.cboActividadInterna1 = new GEN.ControlesBase.cboActividadInterna(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboGrupoCiiu = new GEN.ControlesBase.cboActividadEco(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.btnMiniBusqueda = new GEN.BotonesBase.btnMiniBusqueda(this.components);
            this.SuspendLayout();
            // 
            // cboCIIU
            // 
            this.cboCIIU.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCIIU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCIIU.DropDownWidth = 510;
            this.cboCIIU.Enabled = false;
            this.cboCIIU.FormattingEnabled = true;
            this.cboCIIU.Location = new System.Drawing.Point(95, 73);
            this.cboCIIU.Name = "cboCIIU";
            this.cboCIIU.Size = new System.Drawing.Size(395, 21);
            this.cboCIIU.TabIndex = 65;
            this.cboCIIU.Visible = false;
            // 
            // cboActividadEco
            // 
            this.cboActividadEco.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboActividadEco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboActividadEco.DropDownWidth = 400;
            this.cboActividadEco.Enabled = false;
            this.cboActividadEco.FormattingEnabled = true;
            this.cboActividadEco.Location = new System.Drawing.Point(95, 25);
            this.cboActividadEco.Name = "cboActividadEco";
            this.cboActividadEco.Size = new System.Drawing.Size(395, 21);
            this.cboActividadEco.TabIndex = 64;
            this.cboActividadEco.Visible = false;
            this.cboActividadEco.SelectedIndexChanged += new System.EventHandler(this.cboActividadEco_SelectedIndexChanged);
            // 
            // cboActividadInterna1
            // 
            this.cboActividadInterna1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboActividadInterna1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboActividadInterna1.DropDownWidth = 400;
            this.cboActividadInterna1.FormattingEnabled = true;
            this.cboActividadInterna1.Location = new System.Drawing.Point(95, 1);
            this.cboActividadInterna1.Name = "cboActividadInterna1";
            this.cboActividadInterna1.Size = new System.Drawing.Size(345, 21);
            this.cboActividadInterna1.TabIndex = 0;
            this.cboActividadInterna1.SelectedIndexChanged += new System.EventHandler(this.cboActividadInterna1_SelectedIndexChanged);
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(50, 52);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(42, 13);
            this.lblBase6.TabIndex = 67;
            this.lblBase6.Text = "Grupo";
            this.lblBase6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblBase6.Visible = false;
            this.lblBase6.MouseHover += new System.EventHandler(this.lblBase6_MouseHover);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(17, 4);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(75, 13);
            this.lblBase2.TabIndex = 7;
            this.lblBase2.Text = "Act. Interna";
            this.lblBase2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(58, 76);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(34, 13);
            this.lblBase3.TabIndex = 67;
            this.lblBase3.Text = "CIIU";
            this.lblBase3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblBase3.Visible = false;
            this.lblBase3.MouseHover += new System.EventHandler(this.lblBase3_MouseHover);
            // 
            // cboGrupoCiiu
            // 
            this.cboGrupoCiiu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboGrupoCiiu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrupoCiiu.DropDownWidth = 510;
            this.cboGrupoCiiu.Enabled = false;
            this.cboGrupoCiiu.FormattingEnabled = true;
            this.cboGrupoCiiu.Location = new System.Drawing.Point(95, 49);
            this.cboGrupoCiiu.Name = "cboGrupoCiiu";
            this.cboGrupoCiiu.Size = new System.Drawing.Size(395, 21);
            this.cboGrupoCiiu.TabIndex = 8;
            this.cboGrupoCiiu.Visible = false;
            this.cboGrupoCiiu.SelectedIndexChanged += new System.EventHandler(this.cboGrupoCiiu_SelectedIndexChanged);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(-2, 28);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(94, 13);
            this.lblBase5.TabIndex = 66;
            this.lblBase5.Text = "Act. Económica";
            this.lblBase5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblBase5.Visible = false;
            this.lblBase5.MouseHover += new System.EventHandler(this.lblBase5_MouseHover);
            // 
            // btnMiniBusqueda
            // 
            this.btnMiniBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMiniBusqueda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniBusqueda.BackgroundImage")));
            this.btnMiniBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMiniBusqueda.Location = new System.Drawing.Point(447, 0);
            this.btnMiniBusqueda.Name = "btnMiniBusqueda";
            this.btnMiniBusqueda.Size = new System.Drawing.Size(32, 25);
            this.btnMiniBusqueda.TabIndex = 1;
            this.btnMiniBusqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniBusqueda.UseVisualStyleBackColor = true;
            this.btnMiniBusqueda.Click += new System.EventHandler(this.btnMiniBusqueda_Click);
            // 
            // conActividadCIIU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.btnMiniBusqueda);
            this.Controls.Add(this.cboCIIU);
            this.Controls.Add(this.cboActividadEco);
            this.Controls.Add(this.cboActividadInterna1);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.cboGrupoCiiu);
            this.Controls.Add(this.lblBase5);
            this.Name = "conActividadCIIU";
            this.Size = new System.Drawing.Size(493, 97);
            this.Load += new System.EventHandler(this.conActividadCIIU_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public cboActividadEco cboCIIU;
        public cboActividadEco cboActividadEco;
        public lblBase lblBase6;
        public lblBase lblBase3;
        public lblBase lblBase5;
        public cboActividadEco cboGrupoCiiu;
        public lblBase lblBase2;
        public cboActividadInterna cboActividadInterna1;
        private System.Windows.Forms.ToolTip ttpMensaje;
        private BotonesBase.btnMiniBusqueda btnMiniBusqueda;

    }
}
