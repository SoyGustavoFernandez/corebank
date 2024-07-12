namespace CLI.Presentacion
{
    partial class frmRptSolActCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptSolActCliente));
            this.dtpFecIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.cboZona = new GEN.ControlesBase.cboZona(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.rbtSolicitados = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtTodos = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtRechazados = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtAprobados = new GEN.ControlesBase.rbtBase(this.components);
            this.cboAgencia = new GEN.ControlesBase.cboAgencia(this.components);
            this.dtpFecFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.grbBase2.SuspendLayout();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecIni.Location = new System.Drawing.Point(99, 74);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(183, 20);
            this.dtpFecIni.TabIndex = 84;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(13, 79);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(80, 13);
            this.lblBase6.TabIndex = 85;
            this.lblBase6.Text = "Fecha Inicio:";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.cboZona);
            this.grbBase2.Controls.Add(this.lblBase2);
            this.grbBase2.Controls.Add(this.grbBase1);
            this.grbBase2.Controls.Add(this.cboAgencia);
            this.grbBase2.Controls.Add(this.dtpFecFin);
            this.grbBase2.Controls.Add(this.lblBase1);
            this.grbBase2.Controls.Add(this.dtpFecIni);
            this.grbBase2.Controls.Add(this.lblBase6);
            this.grbBase2.Controls.Add(this.lblBase3);
            this.grbBase2.Location = new System.Drawing.Point(6, 6);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(421, 131);
            this.grbBase2.TabIndex = 86;
            this.grbBase2.TabStop = false;
            // 
            // cboZona
            // 
            this.cboZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZona.FormattingEnabled = true;
            this.cboZona.Location = new System.Drawing.Point(99, 21);
            this.cboZona.Name = "cboZona";
            this.cboZona.Size = new System.Drawing.Size(183, 21);
            this.cboZona.TabIndex = 96;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(13, 24);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(51, 13);
            this.lblBase2.TabIndex = 95;
            this.lblBase2.Text = "Region:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.rbtSolicitados);
            this.grbBase1.Controls.Add(this.rbtTodos);
            this.grbBase1.Controls.Add(this.rbtRechazados);
            this.grbBase1.Controls.Add(this.rbtAprobados);
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(288, 19);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(127, 106);
            this.grbBase1.TabIndex = 92;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Estados";
            // 
            // rbtSolicitados
            // 
            this.rbtSolicitados.AutoSize = true;
            this.rbtSolicitados.ForeColor = System.Drawing.Color.Navy;
            this.rbtSolicitados.Location = new System.Drawing.Point(17, 81);
            this.rbtSolicitados.Name = "rbtSolicitados";
            this.rbtSolicitados.Size = new System.Drawing.Size(76, 17);
            this.rbtSolicitados.TabIndex = 92;
            this.rbtSolicitados.Text = "Solicitados";
            this.rbtSolicitados.UseVisualStyleBackColor = true;
            // 
            // rbtTodos
            // 
            this.rbtTodos.AutoSize = true;
            this.rbtTodos.Checked = true;
            this.rbtTodos.ForeColor = System.Drawing.Color.Navy;
            this.rbtTodos.Location = new System.Drawing.Point(17, 19);
            this.rbtTodos.Name = "rbtTodos";
            this.rbtTodos.Size = new System.Drawing.Size(55, 17);
            this.rbtTodos.TabIndex = 89;
            this.rbtTodos.TabStop = true;
            this.rbtTodos.Text = "Todos";
            this.rbtTodos.UseVisualStyleBackColor = true;
            // 
            // rbtRechazados
            // 
            this.rbtRechazados.AutoSize = true;
            this.rbtRechazados.ForeColor = System.Drawing.Color.Navy;
            this.rbtRechazados.Location = new System.Drawing.Point(17, 58);
            this.rbtRechazados.Name = "rbtRechazados";
            this.rbtRechazados.Size = new System.Drawing.Size(85, 17);
            this.rbtRechazados.TabIndex = 91;
            this.rbtRechazados.Text = "Rechazados";
            this.rbtRechazados.UseVisualStyleBackColor = true;
            // 
            // rbtAprobados
            // 
            this.rbtAprobados.AutoSize = true;
            this.rbtAprobados.ForeColor = System.Drawing.Color.Navy;
            this.rbtAprobados.Location = new System.Drawing.Point(17, 38);
            this.rbtAprobados.Name = "rbtAprobados";
            this.rbtAprobados.Size = new System.Drawing.Size(76, 17);
            this.rbtAprobados.TabIndex = 90;
            this.rbtAprobados.Text = "Aprobados";
            this.rbtAprobados.UseVisualStyleBackColor = true;
            // 
            // cboAgencia
            // 
            this.cboAgencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia.FormattingEnabled = true;
            this.cboAgencia.Location = new System.Drawing.Point(99, 47);
            this.cboAgencia.Name = "cboAgencia";
            this.cboAgencia.Size = new System.Drawing.Size(183, 21);
            this.cboAgencia.TabIndex = 94;
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecFin.Location = new System.Drawing.Point(99, 100);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(183, 20);
            this.dtpFecFin.TabIndex = 90;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(13, 105);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(65, 13);
            this.lblBase1.TabIndex = 91;
            this.lblBase1.Text = "Fecha Fin:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(13, 50);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(57, 13);
            this.lblBase3.TabIndex = 75;
            this.lblBase3.Text = "Agencia:";
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(367, 143);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 88;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(301, 143);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 87;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // frmRptSolActCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 218);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.grbBase2);
            this.Name = "frmRptSolActCliente";
            this.Text = "Reporte de Solicitudes de Actualización de Datos de Cliente";
            this.Load += new System.EventHandler(this.frmRptSolActCliente_Load);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public GEN.ControlesBase.dtpCorto dtpFecIni;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.ControlesBase.lblBase lblBase3;
        public GEN.ControlesBase.dtpCorto dtpFecFin;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboAgencia cboAgencia;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.rbtBase rbtTodos;
        private GEN.ControlesBase.rbtBase rbtRechazados;
        private GEN.ControlesBase.rbtBase rbtAprobados;
        private GEN.ControlesBase.rbtBase rbtSolicitados;
        private GEN.ControlesBase.cboZona cboZona;
        private GEN.ControlesBase.lblBase lblBase2;
    }
}