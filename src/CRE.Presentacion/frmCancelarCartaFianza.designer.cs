namespace CRE.Presentacion
{
    partial class frmCancelarCartaFianza
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCancelarCartaFianza));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtEstado = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtCartaFianza = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.cboMoneda1 = new GEN.ControlesBase.cboMoneda(this.components);
            this.txtTasaAprobada = new GEN.ControlesBase.txtBase(this.components);
            this.txtPlazoAprobado = new GEN.ControlesBase.txtBase(this.components);
            this.txtFechaInicioAprobado = new GEN.ControlesBase.txtBase(this.components);
            this.txtMontoAprobado = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.conBusCuentaCli1 = new GEN.ControlesBase.ConBusCuentaCli();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.gboDatosCancelacion = new System.Windows.Forms.GroupBox();
            this.cboMotivoCancelacion1 = new GEN.ControlesBase.cboMotivoCancelacion(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtMotivoSustento = new GEN.ControlesBase.txtBase(this.components);
            this.txtDocumentoReferencia = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.groupBox2.SuspendLayout();
            this.conBusCuentaCli1.SuspendLayout();
            this.gboDatosCancelacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtEstado);
            this.groupBox2.Controls.Add(this.lblBase2);
            this.groupBox2.Controls.Add(this.lblBase1);
            this.groupBox2.Controls.Add(this.txtCartaFianza);
            this.groupBox2.Controls.Add(this.lblBase12);
            this.groupBox2.Controls.Add(this.cboMoneda1);
            this.groupBox2.Controls.Add(this.txtTasaAprobada);
            this.groupBox2.Controls.Add(this.txtPlazoAprobado);
            this.groupBox2.Controls.Add(this.txtFechaInicioAprobado);
            this.groupBox2.Controls.Add(this.txtMontoAprobado);
            this.groupBox2.Controls.Add(this.lblBase11);
            this.groupBox2.Controls.Add(this.lblBase10);
            this.groupBox2.Controls.Add(this.lblBase9);
            this.groupBox2.Controls.Add(this.lblBase8);
            this.groupBox2.Location = new System.Drawing.Point(12, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(557, 127);
            this.groupBox2.TabIndex = 49;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos de la carta fianza";
            // 
            // txtEstado
            // 
            this.txtEstado.Enabled = false;
            this.txtEstado.Location = new System.Drawing.Point(123, 96);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(175, 20);
            this.txtEstado.TabIndex = 34;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(9, 99);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(50, 13);
            this.lblBase2.TabIndex = 33;
            this.lblBase2.Text = "Estado:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(323, 19);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(56, 13);
            this.lblBase1.TabIndex = 32;
            this.lblBase1.Text = "Moneda:";
            // 
            // txtCartaFianza
            // 
            this.txtCartaFianza.Enabled = false;
            this.txtCartaFianza.Location = new System.Drawing.Point(123, 17);
            this.txtCartaFianza.Name = "txtCartaFianza";
            this.txtCartaFianza.ReadOnly = true;
            this.txtCartaFianza.Size = new System.Drawing.Size(175, 20);
            this.txtCartaFianza.TabIndex = 31;
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(9, 20);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(108, 13);
            this.lblBase12.TabIndex = 30;
            this.lblBase12.Text = "Nro Carta Fianza:";
            // 
            // cboMoneda1
            // 
            this.cboMoneda1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda1.Enabled = false;
            this.cboMoneda1.FormattingEnabled = true;
            this.cboMoneda1.Location = new System.Drawing.Point(399, 16);
            this.cboMoneda1.Name = "cboMoneda1";
            this.cboMoneda1.Size = new System.Drawing.Size(140, 21);
            this.cboMoneda1.TabIndex = 25;
            // 
            // txtTasaAprobada
            // 
            this.txtTasaAprobada.Enabled = false;
            this.txtTasaAprobada.Location = new System.Drawing.Point(416, 44);
            this.txtTasaAprobada.Name = "txtTasaAprobada";
            this.txtTasaAprobada.ReadOnly = true;
            this.txtTasaAprobada.Size = new System.Drawing.Size(123, 20);
            this.txtTasaAprobada.TabIndex = 24;
            // 
            // txtPlazoAprobado
            // 
            this.txtPlazoAprobado.Enabled = false;
            this.txtPlazoAprobado.Location = new System.Drawing.Point(416, 70);
            this.txtPlazoAprobado.Name = "txtPlazoAprobado";
            this.txtPlazoAprobado.ReadOnly = true;
            this.txtPlazoAprobado.Size = new System.Drawing.Size(123, 20);
            this.txtPlazoAprobado.TabIndex = 23;
            // 
            // txtFechaInicioAprobado
            // 
            this.txtFechaInicioAprobado.Enabled = false;
            this.txtFechaInicioAprobado.Location = new System.Drawing.Point(123, 70);
            this.txtFechaInicioAprobado.Name = "txtFechaInicioAprobado";
            this.txtFechaInicioAprobado.ReadOnly = true;
            this.txtFechaInicioAprobado.Size = new System.Drawing.Size(175, 20);
            this.txtFechaInicioAprobado.TabIndex = 22;
            // 
            // txtMontoAprobado
            // 
            this.txtMontoAprobado.Enabled = false;
            this.txtMontoAprobado.Location = new System.Drawing.Point(123, 44);
            this.txtMontoAprobado.Name = "txtMontoAprobado";
            this.txtMontoAprobado.ReadOnly = true;
            this.txtMontoAprobado.Size = new System.Drawing.Size(175, 20);
            this.txtMontoAprobado.TabIndex = 21;
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(323, 47);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(65, 13);
            this.lblBase11.TabIndex = 20;
            this.lblBase11.Text = "Tasa (%):";
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(323, 73);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(79, 13);
            this.lblBase10.TabIndex = 19;
            this.lblBase10.Text = "Plazo (días):";
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(9, 75);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(78, 13);
            this.lblBase9.TabIndex = 18;
            this.lblBase9.Text = "Fecha inicio:";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(9, 47);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(46, 13);
            this.lblBase8.TabIndex = 17;
            this.lblBase8.Text = "Monto:";
            // 
            // conBusCuentaCli1
            // 
            this.conBusCuentaCli1.BackColor = System.Drawing.Color.Transparent;
            this.conBusCuentaCli1.Controls.Add(this.grbBase1);
            this.conBusCuentaCli1.Controls.Add(this.grbBase2);
            this.conBusCuentaCli1.Location = new System.Drawing.Point(12, 12);
            this.conBusCuentaCli1.Name = "conBusCuentaCli1";
            this.conBusCuentaCli1.Size = new System.Drawing.Size(557, 100);
            this.conBusCuentaCli1.TabIndex = 48;
            // 
            // grbBase1
            // 
            this.grbBase1.Location = new System.Drawing.Point(3, -2);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(554, 99);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos del Cliente";
            // 
            // grbBase2
            // 
            this.grbBase2.Location = new System.Drawing.Point(3, -2);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(554, 99);
            this.grbBase2.TabIndex = 0;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Datos del Cliente";
            // 
            // gboDatosCancelacion
            // 
            this.gboDatosCancelacion.Controls.Add(this.cboMotivoCancelacion1);
            this.gboDatosCancelacion.Controls.Add(this.lblBase5);
            this.gboDatosCancelacion.Controls.Add(this.txtMotivoSustento);
            this.gboDatosCancelacion.Controls.Add(this.txtDocumentoReferencia);
            this.gboDatosCancelacion.Controls.Add(this.lblBase4);
            this.gboDatosCancelacion.Controls.Add(this.lblBase3);
            this.gboDatosCancelacion.Location = new System.Drawing.Point(15, 252);
            this.gboDatosCancelacion.Name = "gboDatosCancelacion";
            this.gboDatosCancelacion.Size = new System.Drawing.Size(554, 181);
            this.gboDatosCancelacion.TabIndex = 50;
            this.gboDatosCancelacion.TabStop = false;
            this.gboDatosCancelacion.Text = "Datos de la cancelación";
            // 
            // cboMotivoCancelacion1
            // 
            this.cboMotivoCancelacion1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMotivoCancelacion1.FormattingEnabled = true;
            this.cboMotivoCancelacion1.Location = new System.Drawing.Point(152, 18);
            this.cboMotivoCancelacion1.Name = "cboMotivoCancelacion1";
            this.cboMotivoCancelacion1.Size = new System.Drawing.Size(384, 21);
            this.cboMotivoCancelacion1.TabIndex = 5;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(10, 21);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(122, 13);
            this.lblBase5.TabIndex = 4;
            this.lblBase5.Text = "Motivo Cancelación:";
            // 
            // txtMotivoSustento
            // 
            this.txtMotivoSustento.Location = new System.Drawing.Point(152, 71);
            this.txtMotivoSustento.Multiline = true;
            this.txtMotivoSustento.Name = "txtMotivoSustento";
            this.txtMotivoSustento.Size = new System.Drawing.Size(384, 99);
            this.txtMotivoSustento.TabIndex = 3;
            // 
            // txtDocumentoReferencia
            // 
            this.txtDocumentoReferencia.Location = new System.Drawing.Point(152, 45);
            this.txtDocumentoReferencia.Name = "txtDocumentoReferencia";
            this.txtDocumentoReferencia.Size = new System.Drawing.Size(384, 20);
            this.txtDocumentoReferencia.TabIndex = 2;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(10, 74);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(62, 13);
            this.lblBase4.TabIndex = 1;
            this.lblBase4.Text = "Sustento:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(10, 48);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(139, 13);
            this.lblBase3.TabIndex = 0;
            this.lblBase3.Text = "Documento referencia:";
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(377, 439);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 51;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(443, 439);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 52;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(509, 439);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 53;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // frmCancelarCartaFianza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 523);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.gboDatosCancelacion);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.conBusCuentaCli1);
            this.Name = "frmCancelarCartaFianza";
            this.Text = "Cancelar Carta Fianza";
            this.Load += new System.EventHandler(this.frmCancelarCartaFianza_Load);
            this.Controls.SetChildIndex(this.conBusCuentaCli1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.gboDatosCancelacion, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.conBusCuentaCli1.ResumeLayout(false);
            this.gboDatosCancelacion.ResumeLayout(false);
            this.gboDatosCancelacion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtCartaFianza;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.cboMoneda cboMoneda1;
        private GEN.ControlesBase.txtBase txtTasaAprobada;
        private GEN.ControlesBase.txtBase txtPlazoAprobado;
        private GEN.ControlesBase.txtBase txtFechaInicioAprobado;
        private GEN.ControlesBase.txtBase txtMontoAprobado;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.ConBusCuentaCli conBusCuentaCli1;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.txtBase txtEstado;
        private GEN.ControlesBase.lblBase lblBase2;
        private System.Windows.Forms.GroupBox gboDatosCancelacion;
        private GEN.ControlesBase.txtBase txtMotivoSustento;
        private GEN.ControlesBase.txtBase txtDocumentoReferencia;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.cboMotivoCancelacion cboMotivoCancelacion1;
        private GEN.ControlesBase.lblBase lblBase5;
    }
}