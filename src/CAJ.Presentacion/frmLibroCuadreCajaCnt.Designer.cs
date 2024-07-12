namespace CAJ.Presentacion
{
    partial class frmLibroCuadreCajaCnt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLibroCuadreCajaCnt));
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.txtCodUsu = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtNomUsu = new GEN.ControlesBase.txtCBLetra(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.grbBase6 = new GEN.ControlesBase.grbBase(this.components);
            this.chcConsolidad = new GEN.ControlesBase.chcBase(this.components);
            this.cboAgencias1 = new GEN.ControlesBase.cboAgencias(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.dtpFechaFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFechaIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase22 = new GEN.ControlesBase.lblBase();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.grbBase3.SuspendLayout();
            this.grbBase6.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.txtCodUsu);
            this.grbBase3.Controls.Add(this.lblBase2);
            this.grbBase3.Controls.Add(this.txtNomUsu);
            this.grbBase3.Controls.Add(this.lblBase1);
            this.grbBase3.Location = new System.Drawing.Point(5, 3);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(462, 37);
            this.grbBase3.TabIndex = 109;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Datos Usuario";
            // 
            // txtCodUsu
            // 
            this.txtCodUsu.Location = new System.Drawing.Point(66, 14);
            this.txtCodUsu.Name = "txtCodUsu";
            this.txtCodUsu.ReadOnly = true;
            this.txtCodUsu.Size = new System.Drawing.Size(50, 20);
            this.txtCodUsu.TabIndex = 70;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(13, 17);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(52, 13);
            this.lblBase2.TabIndex = 69;
            this.lblBase2.Text = "Código:";
            // 
            // txtNomUsu
            // 
            this.txtNomUsu.Location = new System.Drawing.Point(180, 14);
            this.txtNomUsu.Name = "txtNomUsu";
            this.txtNomUsu.ReadOnly = true;
            this.txtNomUsu.Size = new System.Drawing.Size(271, 20);
            this.txtNomUsu.TabIndex = 72;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(120, 16);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(57, 13);
            this.lblBase1.TabIndex = 71;
            this.lblBase1.Text = "Nombre:";
            // 
            // grbBase6
            // 
            this.grbBase6.Controls.Add(this.btnSalir1);
            this.grbBase6.Controls.Add(this.chcConsolidad);
            this.grbBase6.Controls.Add(this.cboAgencias1);
            this.grbBase6.Controls.Add(this.lblBase4);
            this.grbBase6.Controls.Add(this.btnImprimir);
            this.grbBase6.Controls.Add(this.dtpFechaFin);
            this.grbBase6.Controls.Add(this.lblBase3);
            this.grbBase6.Controls.Add(this.label1);
            this.grbBase6.Controls.Add(this.dtpFechaIni);
            this.grbBase6.Controls.Add(this.lblBase22);
            this.grbBase6.Location = new System.Drawing.Point(4, 36);
            this.grbBase6.Name = "grbBase6";
            this.grbBase6.Size = new System.Drawing.Size(463, 125);
            this.grbBase6.TabIndex = 110;
            this.grbBase6.TabStop = false;
            // 
            // chcConsolidad
            // 
            this.chcConsolidad.AutoSize = true;
            this.chcConsolidad.ForeColor = System.Drawing.Color.Navy;
            this.chcConsolidad.Location = new System.Drawing.Point(164, 16);
            this.chcConsolidad.Name = "chcConsolidad";
            this.chcConsolidad.Size = new System.Drawing.Size(102, 17);
            this.chcConsolidad.TabIndex = 112;
            this.chcConsolidad.Text = "Ver consolidado";
            this.chcConsolidad.UseVisualStyleBackColor = true;
            this.chcConsolidad.CheckedChanged += new System.EventHandler(this.chcConsolidad_CheckedChanged);
            // 
            // cboAgencias1
            // 
            this.cboAgencias1.FormattingEnabled = true;
            this.cboAgencias1.Location = new System.Drawing.Point(248, 41);
            this.cboAgencias1.Name = "cboAgencias1";
            this.cboAgencias1.Size = new System.Drawing.Size(204, 21);
            this.cboAgencias1.TabIndex = 111;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(161, 47);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(61, 13);
            this.lblBase4.TabIndex = 110;
            this.lblBase4.Text = "Agencia :";
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(330, 67);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 109;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(248, 94);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(80, 20);
            this.dtpFechaFin.TabIndex = 107;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(161, 98);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(73, 13);
            this.lblBase3.TabIndex = 108;
            this.lblBase3.Text = "Fecha final:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SeaGreen;
            this.label1.Location = new System.Drawing.Point(14, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 37);
            this.label1.TabIndex = 106;
            this.label1.Text = "CUADRE LIBRO CAJA CONTABLE";
            // 
            // dtpFechaIni
            // 
            this.dtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaIni.Location = new System.Drawing.Point(248, 68);
            this.dtpFechaIni.Name = "dtpFechaIni";
            this.dtpFechaIni.Size = new System.Drawing.Size(80, 20);
            this.dtpFechaIni.TabIndex = 104;
            // 
            // lblBase22
            // 
            this.lblBase22.AutoSize = true;
            this.lblBase22.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase22.ForeColor = System.Drawing.Color.Navy;
            this.lblBase22.Location = new System.Drawing.Point(161, 72);
            this.lblBase22.Name = "lblBase22";
            this.lblBase22.Size = new System.Drawing.Size(81, 13);
            this.lblBase22.TabIndex = 105;
            this.lblBase22.Text = "Fecha inicial:";
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(392, 67);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 113;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // frmLibroCuadreCajaCnt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 186);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.grbBase6);
            this.Name = "frmLibroCuadreCajaCnt";
            this.Text = "Cuadre libro caja contable";
            this.Load += new System.EventHandler(this.frmLibroCuadreCajaCnt_Load);
            this.Controls.SetChildIndex(this.grbBase6, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.grbBase6.ResumeLayout(false);
            this.grbBase6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.txtBase txtCodUsu;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtCBLetra txtNomUsu;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.grbBase grbBase6;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        public GEN.ControlesBase.dtpCorto dtpFechaFin;
        private GEN.ControlesBase.lblBase lblBase3;
        private System.Windows.Forms.Label label1;
        public GEN.ControlesBase.dtpCorto dtpFechaIni;
        private GEN.ControlesBase.lblBase lblBase22;
        private GEN.ControlesBase.cboAgencias cboAgencias1;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.chcBase chcConsolidad;
        private GEN.BotonesBase.btnSalir btnSalir1;
    }
}