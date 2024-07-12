namespace GEN.ControlesBase
{
    partial class ConActividadCIIUSimp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConActividadCIIUSimp));
            this.btnMiniBusqueda = new GEN.BotonesBase.btnMiniBusqueda(this.components);
            this.ttpMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.cboCIIU = new GEN.ControlesBase.cboActividadEco(this.components);
            this.cboActividadEco = new GEN.ControlesBase.cboActividadEco(this.components);
            this.cboActividadInterna1 = new GEN.ControlesBase.cboActividadInterna(this.components);
            this.cboGrupoCiiu = new GEN.ControlesBase.cboActividadEco(this.components);
            this.SuspendLayout();
            // 
            // btnMiniBusqueda
            // 
            this.btnMiniBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMiniBusqueda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniBusqueda.BackgroundImage")));
            this.btnMiniBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMiniBusqueda.Location = new System.Drawing.Point(513, 0);
            this.btnMiniBusqueda.Name = "btnMiniBusqueda";
            this.btnMiniBusqueda.Size = new System.Drawing.Size(23, 23);
            this.btnMiniBusqueda.TabIndex = 69;
            this.btnMiniBusqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniBusqueda.UseVisualStyleBackColor = true;
            this.btnMiniBusqueda.Click += new System.EventHandler(this.btnMiniBusqueda_Click);
            // 
            // cboCIIU
            // 
            this.cboCIIU.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCIIU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCIIU.DropDownWidth = 510;
            this.cboCIIU.Enabled = false;
            this.cboCIIU.FormattingEnabled = true;
            this.cboCIIU.Location = new System.Drawing.Point(1, 73);
            this.cboCIIU.Name = "cboCIIU";
            this.cboCIIU.Size = new System.Drawing.Size(535, 21);
            this.cboCIIU.TabIndex = 73;
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
            this.cboActividadEco.Location = new System.Drawing.Point(1, 25);
            this.cboActividadEco.Name = "cboActividadEco";
            this.cboActividadEco.Size = new System.Drawing.Size(535, 21);
            this.cboActividadEco.TabIndex = 72;
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
            this.cboActividadInterna1.Location = new System.Drawing.Point(1, 1);
            this.cboActividadInterna1.Name = "cboActividadInterna1";
            this.cboActividadInterna1.Size = new System.Drawing.Size(510, 21);
            this.cboActividadInterna1.TabIndex = 68;
            this.cboActividadInterna1.SelectedIndexChanged += new System.EventHandler(this.cboActividadInterna1_SelectedIndexChanged);
            // 
            // cboGrupoCiiu
            // 
            this.cboGrupoCiiu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboGrupoCiiu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrupoCiiu.DropDownWidth = 510;
            this.cboGrupoCiiu.Enabled = false;
            this.cboGrupoCiiu.FormattingEnabled = true;
            this.cboGrupoCiiu.Location = new System.Drawing.Point(1, 49);
            this.cboGrupoCiiu.Name = "cboGrupoCiiu";
            this.cboGrupoCiiu.Size = new System.Drawing.Size(535, 21);
            this.cboGrupoCiiu.TabIndex = 71;
            this.cboGrupoCiiu.Visible = false;
            this.cboGrupoCiiu.SelectedIndexChanged += new System.EventHandler(this.cboGrupoCiiu_SelectedIndexChanged);
            // 
            // ConActividadCIIUSimp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.btnMiniBusqueda);
            this.Controls.Add(this.cboCIIU);
            this.Controls.Add(this.cboActividadEco);
            this.Controls.Add(this.cboActividadInterna1);
            this.Controls.Add(this.cboGrupoCiiu);
            this.Name = "ConActividadCIIUSimp";
            this.Size = new System.Drawing.Size(539, 97);
            this.Load += new System.EventHandler(this.conActividadCIIU_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private BotonesBase.btnMiniBusqueda btnMiniBusqueda;
        public cboActividadEco cboCIIU;
        public cboActividadEco cboActividadEco;
        public cboActividadInterna cboActividadInterna1;
        public cboActividadEco cboGrupoCiiu;
        private System.Windows.Forms.ToolTip ttpMensaje;
    }
}
