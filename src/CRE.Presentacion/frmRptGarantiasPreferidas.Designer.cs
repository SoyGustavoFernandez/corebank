namespace CRE.Presentacion
{
    partial class frmRptGarantiasPreferidas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptGarantiasPreferidas));
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.cboClaseGarantia = new GEN.ControlesBase.cboClaseGarantia(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.rptPreferidas = new System.Windows.Forms.RadioButton();
            this.rptContradepositos = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.cboZona2 = new GEN.ControlesBase.cboZona(this.components);
            this.cboAgencias1 = new GEN.ControlesBase.cboAgencias(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.dtpFechaHasta = new GEN.ControlesBase.dtpCorto(this.components);
            this.SuspendLayout();
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(202, 143);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 8;
            this.btnImprimir1.Text = "&Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(268, 143);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 9;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // cboClaseGarantia
            // 
            this.cboClaseGarantia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClaseGarantia.DropDownWidth = 180;
            this.cboClaseGarantia.FormattingEnabled = true;
            this.cboClaseGarantia.Location = new System.Drawing.Point(116, 79);
            this.cboClaseGarantia.Name = "cboClaseGarantia";
            this.cboClaseGarantia.Size = new System.Drawing.Size(212, 21);
            this.cboClaseGarantia.TabIndex = 23;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(3, 82);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(115, 13);
            this.lblBase1.TabIndex = 22;
            this.lblBase1.Text = "Clase de Garantía:";
            // 
            // rptPreferidas
            // 
            this.rptPreferidas.AutoSize = true;
            this.rptPreferidas.Checked = true;
            this.rptPreferidas.Location = new System.Drawing.Point(33, 56);
            this.rptPreferidas.Name = "rptPreferidas";
            this.rptPreferidas.Size = new System.Drawing.Size(122, 17);
            this.rptPreferidas.TabIndex = 24;
            this.rptPreferidas.TabStop = true;
            this.rptPreferidas.Text = "Garantías Preferidas";
            this.rptPreferidas.UseVisualStyleBackColor = true;
            // 
            // rptContradepositos
            // 
            this.rptContradepositos.AutoSize = true;
            this.rptContradepositos.Location = new System.Drawing.Point(185, 56);
            this.rptContradepositos.Name = "rptContradepositos";
            this.rptContradepositos.Size = new System.Drawing.Size(101, 17);
            this.rptContradepositos.TabIndex = 25;
            this.rptContradepositos.Text = "Contradepósitos";
            this.rptContradepositos.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(299, 9);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(56, 17);
            this.checkBox1.TabIndex = 37;
            this.checkBox1.Text = "Todos";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(11, 33);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(61, 13);
            this.lblBase7.TabIndex = 36;
            this.lblBase7.Text = "Agencia :";
            // 
            // cboZona2
            // 
            this.cboZona2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZona2.FormattingEnabled = true;
            this.cboZona2.Location = new System.Drawing.Point(72, 6);
            this.cboZona2.Name = "cboZona2";
            this.cboZona2.Size = new System.Drawing.Size(220, 21);
            this.cboZona2.TabIndex = 33;
            this.cboZona2.SelectedIndexChanged += new System.EventHandler(this.cboZona2_SelectedIndexChanged);
            // 
            // cboAgencias1
            // 
            this.cboAgencias1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencias1.FormattingEnabled = true;
            this.cboAgencias1.Location = new System.Drawing.Point(72, 29);
            this.cboAgencias1.Name = "cboAgencias1";
            this.cboAgencias1.Size = new System.Drawing.Size(220, 21);
            this.cboAgencias1.TabIndex = 34;
            this.cboAgencias1.SelectedIndexChanged += new System.EventHandler(this.cboAgencias1_SelectedIndexChanged);
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(17, 9);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(55, 13);
            this.lblBase8.TabIndex = 38;
            this.lblBase8.Text = "Región :";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(69, 115);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(49, 13);
            this.lblBase3.TabIndex = 40;
            this.lblBase3.Text = "Fecha :";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.CustomFormat = "";
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(116, 115);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(135, 20);
            this.dtpFechaHasta.TabIndex = 39;
            // 
            // frmRptGarantiasPreferidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 235);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.dtpFechaHasta);
            this.Controls.Add(this.lblBase8);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.cboZona2);
            this.Controls.Add(this.cboAgencias1);
            this.Controls.Add(this.rptContradepositos);
            this.Controls.Add(this.rptPreferidas);
            this.Controls.Add(this.cboClaseGarantia);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnImprimir1);
            this.Name = "frmRptGarantiasPreferidas";
            this.Text = "Reporte Garantías Preferidas/Contradepósitos";
            this.Load += new System.EventHandler(this.frmRptGarantiasPreferidas_Load);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.cboClaseGarantia, 0);
            this.Controls.SetChildIndex(this.rptPreferidas, 0);
            this.Controls.SetChildIndex(this.rptContradepositos, 0);
            this.Controls.SetChildIndex(this.cboAgencias1, 0);
            this.Controls.SetChildIndex(this.cboZona2, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            this.Controls.SetChildIndex(this.checkBox1, 0);
            this.Controls.SetChildIndex(this.lblBase8, 0);
            this.Controls.SetChildIndex(this.dtpFechaHasta, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.cboClaseGarantia cboClaseGarantia;
        private GEN.ControlesBase.lblBase lblBase1;
        private System.Windows.Forms.RadioButton rptPreferidas;
        private System.Windows.Forms.RadioButton rptContradepositos;
        private System.Windows.Forms.CheckBox checkBox1;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.cboZona cboZona2;
        private GEN.ControlesBase.cboAgencias cboAgencias1;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.dtpCorto dtpFechaHasta;
    }
}