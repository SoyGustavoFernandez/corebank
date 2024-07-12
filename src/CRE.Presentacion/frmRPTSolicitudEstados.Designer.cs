namespace CRE.Presentacion
{
    partial class frmRPTSolicitudEstados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRPTSolicitudEstados));
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtpDesde = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpHasta = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboEstablecimiento = new System.Windows.Forms.ComboBox();
            this.cboAgencia = new System.Windows.Forms.ComboBox();
            this.cboEstadoSolicitud = new System.Windows.Forms.ComboBox();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.cboZona = new System.Windows.Forms.ComboBox();
            this.btnProcesar1 = new GEN.BotonesBase.btnProcesar();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(324, 106);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 39;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(16, 130);
            this.lblBase5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(65, 13);
            this.lblBase5.TabIndex = 37;
            this.lblBase5.Text = "Fecha Fin:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(16, 89);
            this.lblBase4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(80, 13);
            this.lblBase4.TabIndex = 36;
            this.lblBase4.Text = "Fecha Inicio:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(13, 9);
            this.lblBase2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(57, 13);
            this.lblBase2.TabIndex = 34;
            this.lblBase2.Text = "Agencia:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(13, 49);
            this.lblBase1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(51, 13);
            this.lblBase1.TabIndex = 33;
            this.lblBase1.Text = "Región:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(16, 106);
            this.dtpDesde.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(176, 20);
            this.dtpDesde.TabIndex = 32;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(16, 147);
            this.dtpHasta.Margin = new System.Windows.Forms.Padding(4);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(176, 20);
            this.dtpHasta.TabIndex = 31;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(205, 9);
            this.lblBase3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(101, 13);
            this.lblBase3.TabIndex = 41;
            this.lblBase3.Text = "Establecimiento:";
            // 
            // cboEstablecimiento
            // 
            this.cboEstablecimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstablecimiento.FormattingEnabled = true;
            this.cboEstablecimiento.Location = new System.Drawing.Point(208, 25);
            this.cboEstablecimiento.Name = "cboEstablecimiento";
            this.cboEstablecimiento.Size = new System.Drawing.Size(176, 21);
            this.cboEstablecimiento.TabIndex = 42;
            // 
            // cboAgencia
            // 
            this.cboAgencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia.FormattingEnabled = true;
            this.cboAgencia.Location = new System.Drawing.Point(16, 25);
            this.cboAgencia.Name = "cboAgencia";
            this.cboAgencia.Size = new System.Drawing.Size(176, 21);
            this.cboAgencia.TabIndex = 43;
            this.cboAgencia.SelectedIndexChanged += new System.EventHandler(this.cboAgencia_SelectedIndexChanged);
            // 
            // cboEstadoSolicitud
            // 
            this.cboEstadoSolicitud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoSolicitud.FormattingEnabled = true;
            this.cboEstadoSolicitud.Location = new System.Drawing.Point(208, 65);
            this.cboEstadoSolicitud.Name = "cboEstadoSolicitud";
            this.cboEstadoSolicitud.Size = new System.Drawing.Size(176, 21);
            this.cboEstadoSolicitud.TabIndex = 45;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(205, 49);
            this.lblBase6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(120, 13);
            this.lblBase6.TabIndex = 44;
            this.lblBase6.Text = "Estado de Solicitud:";
            // 
            // cboZona
            // 
            this.cboZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZona.FormattingEnabled = true;
            this.cboZona.Location = new System.Drawing.Point(16, 65);
            this.cboZona.Name = "cboZona";
            this.cboZona.Size = new System.Drawing.Size(176, 21);
            this.cboZona.TabIndex = 46;
            this.cboZona.SelectedIndexChanged += new System.EventHandler(this.cboZona_SelectedIndexChanged);
            // 
            // btnProcesar1
            // 
            this.btnProcesar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar1.BackgroundImage")));
            this.btnProcesar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar1.Location = new System.Drawing.Point(257, 106);
            this.btnProcesar1.Name = "btnProcesar1";
            this.btnProcesar1.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar1.TabIndex = 47;
            this.btnProcesar1.Text = "&Procesar";
            this.btnProcesar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar1.UseVisualStyleBackColor = true;
            this.btnProcesar1.Click += new System.EventHandler(this.btnProcesar1_Click);
            // 
            // frmRPTSolicitudEstados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 204);
            this.Controls.Add(this.btnProcesar1);
            this.Controls.Add(this.cboZona);
            this.Controls.Add(this.cboEstadoSolicitud);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.cboAgencia);
            this.Controls.Add(this.cboEstablecimiento);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.dtpHasta);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmRPTSolicitudEstados";
            this.Text = "Reporte de Solicitudes de Crédito";
            this.Load += new System.EventHandler(this.frmRPTSeguimientoSeguroMultiriesgo_Load);
            this.Controls.SetChildIndex(this.dtpHasta, 0);
            this.Controls.SetChildIndex(this.dtpDesde, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.cboEstablecimiento, 0);
            this.Controls.SetChildIndex(this.cboAgencia, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.cboEstadoSolicitud, 0);
            this.Controls.SetChildIndex(this.cboZona, 0);
            this.Controls.SetChildIndex(this.btnProcesar1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.dtpCorto dtpDesde;
        private GEN.ControlesBase.dtpCorto dtpHasta;
        private GEN.ControlesBase.lblBase lblBase3;
        private System.Windows.Forms.ComboBox cboEstablecimiento;
        private System.Windows.Forms.ComboBox cboAgencia;
        private System.Windows.Forms.ComboBox cboEstadoSolicitud;
        private GEN.ControlesBase.lblBase lblBase6;
        private System.Windows.Forms.ComboBox cboZona;
        private GEN.BotonesBase.btnProcesar btnProcesar1;
    }
}