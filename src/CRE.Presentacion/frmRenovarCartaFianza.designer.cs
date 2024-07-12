namespace CRE.Presentacion
{
    partial class frmRenovarCartaFianza
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRenovarCartaFianza));
            this.conBusCli1 = new GEN.ControlesBase.ConBusCli();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboMoneda1 = new GEN.ControlesBase.cboMoneda(this.components);
            this.txtTasaAprobada = new GEN.ControlesBase.txtBase(this.components);
            this.txtPlazoAprobado = new GEN.ControlesBase.txtBase(this.components);
            this.txtFechaInicioAprobado = new GEN.ControlesBase.txtBase(this.components);
            this.txtMontoAprobado = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPlazoRenovacion = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtTasaRenovacion = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.cboMoneda2 = new GEN.ControlesBase.cboMoneda(this.components);
            this.txtFechaInicioRenovacion = new GEN.ControlesBase.txtBase(this.components);
            this.txtMontoRenovacion = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtCartaFianza = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // conBusCli1
            // 
            this.conBusCli1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli1.idCli = 0;
            this.conBusCli1.Location = new System.Drawing.Point(23, 12);
            this.conBusCli1.Name = "conBusCli1";
            this.conBusCli1.Size = new System.Drawing.Size(532, 105);
            this.conBusCli1.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblBase5);
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
            this.groupBox2.Location = new System.Drawing.Point(12, 123);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(543, 101);
            this.groupBox2.TabIndex = 47;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos de la carta fianza";
            // 
            // cboMoneda1
            // 
            this.cboMoneda1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda1.Enabled = false;
            this.cboMoneda1.FormattingEnabled = true;
            this.cboMoneda1.Location = new System.Drawing.Point(382, 18);
            this.cboMoneda1.Name = "cboMoneda1";
            this.cboMoneda1.Size = new System.Drawing.Size(140, 21);
            this.cboMoneda1.TabIndex = 25;
            // 
            // txtTasaAprobada
            // 
            this.txtTasaAprobada.Enabled = false;
            this.txtTasaAprobada.Location = new System.Drawing.Point(394, 45);
            this.txtTasaAprobada.Name = "txtTasaAprobada";
            this.txtTasaAprobada.ReadOnly = true;
            this.txtTasaAprobada.Size = new System.Drawing.Size(128, 20);
            this.txtTasaAprobada.TabIndex = 24;
            // 
            // txtPlazoAprobado
            // 
            this.txtPlazoAprobado.Enabled = false;
            this.txtPlazoAprobado.Location = new System.Drawing.Point(408, 71);
            this.txtPlazoAprobado.Name = "txtPlazoAprobado";
            this.txtPlazoAprobado.ReadOnly = true;
            this.txtPlazoAprobado.Size = new System.Drawing.Size(114, 20);
            this.txtPlazoAprobado.TabIndex = 23;
            // 
            // txtFechaInicioAprobado
            // 
            this.txtFechaInicioAprobado.Enabled = false;
            this.txtFechaInicioAprobado.Location = new System.Drawing.Point(123, 71);
            this.txtFechaInicioAprobado.Name = "txtFechaInicioAprobado";
            this.txtFechaInicioAprobado.ReadOnly = true;
            this.txtFechaInicioAprobado.Size = new System.Drawing.Size(175, 20);
            this.txtFechaInicioAprobado.TabIndex = 22;
            // 
            // txtMontoAprobado
            // 
            this.txtMontoAprobado.Enabled = false;
            this.txtMontoAprobado.Location = new System.Drawing.Point(125, 45);
            this.txtMontoAprobado.Name = "txtMontoAprobado";
            this.txtMontoAprobado.ReadOnly = true;
            this.txtMontoAprobado.Size = new System.Drawing.Size(173, 20);
            this.txtMontoAprobado.TabIndex = 21;
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(323, 48);
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
            this.lblBase10.Location = new System.Drawing.Point(323, 74);
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
            this.lblBase9.Location = new System.Drawing.Point(14, 76);
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
            this.lblBase8.Location = new System.Drawing.Point(14, 48);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(105, 13);
            this.lblBase8.TabIndex = 17;
            this.lblBase8.Text = "Monto Aprobado:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPlazoRenovacion);
            this.groupBox1.Controls.Add(this.txtTasaRenovacion);
            this.groupBox1.Controls.Add(this.cboMoneda2);
            this.groupBox1.Controls.Add(this.txtFechaInicioRenovacion);
            this.groupBox1.Controls.Add(this.txtMontoRenovacion);
            this.groupBox1.Controls.Add(this.lblBase1);
            this.groupBox1.Controls.Add(this.lblBase2);
            this.groupBox1.Controls.Add(this.lblBase3);
            this.groupBox1.Controls.Add(this.lblBase4);
            this.groupBox1.Location = new System.Drawing.Point(12, 230);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(543, 85);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de la carta fianza si renueva";
            // 
            // txtPlazoRenovacion
            // 
            this.txtPlazoRenovacion.Enabled = false;
            this.txtPlazoRenovacion.Location = new System.Drawing.Point(362, 47);
            this.txtPlazoRenovacion.Name = "txtPlazoRenovacion";
            this.txtPlazoRenovacion.Size = new System.Drawing.Size(160, 20);
            this.txtPlazoRenovacion.TabIndex = 27;
            // 
            // txtTasaRenovacion
            // 
            this.txtTasaRenovacion.Enabled = false;
            this.txtTasaRenovacion.Location = new System.Drawing.Point(424, 21);
            this.txtTasaRenovacion.Name = "txtTasaRenovacion";
            this.txtTasaRenovacion.Size = new System.Drawing.Size(100, 20);
            this.txtTasaRenovacion.TabIndex = 26;
            // 
            // cboMoneda2
            // 
            this.cboMoneda2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda2.Enabled = false;
            this.cboMoneda2.FormattingEnabled = true;
            this.cboMoneda2.Location = new System.Drawing.Point(123, 21);
            this.cboMoneda2.Name = "cboMoneda2";
            this.cboMoneda2.Size = new System.Drawing.Size(125, 21);
            this.cboMoneda2.TabIndex = 25;
            // 
            // txtFechaInicioRenovacion
            // 
            this.txtFechaInicioRenovacion.Enabled = false;
            this.txtFechaInicioRenovacion.Location = new System.Drawing.Point(123, 48);
            this.txtFechaInicioRenovacion.Name = "txtFechaInicioRenovacion";
            this.txtFechaInicioRenovacion.ReadOnly = true;
            this.txtFechaInicioRenovacion.Size = new System.Drawing.Size(175, 20);
            this.txtFechaInicioRenovacion.TabIndex = 22;
            // 
            // txtMontoRenovacion
            // 
            this.txtMontoRenovacion.Enabled = false;
            this.txtMontoRenovacion.Location = new System.Drawing.Point(254, 22);
            this.txtMontoRenovacion.Name = "txtMontoRenovacion";
            this.txtMontoRenovacion.ReadOnly = true;
            this.txtMontoRenovacion.Size = new System.Drawing.Size(119, 20);
            this.txtMontoRenovacion.TabIndex = 21;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(379, 25);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(39, 13);
            this.lblBase1.TabIndex = 20;
            this.lblBase1.Text = "Tasa:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(314, 51);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(42, 13);
            this.lblBase2.TabIndex = 19;
            this.lblBase2.Text = "Plazo:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(14, 53);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(78, 13);
            this.lblBase3.TabIndex = 18;
            this.lblBase3.Text = "Fecha inicio:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(14, 25);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(105, 13);
            this.lblBase4.TabIndex = 17;
            this.lblBase4.Text = "Monto Aprobado:";
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(495, 321);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 49;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(429, 321);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 50;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(363, 321);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 51;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(323, 21);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(56, 13);
            this.lblBase5.TabIndex = 35;
            this.lblBase5.Text = "Moneda:";
            // 
            // txtCartaFianza
            // 
            this.txtCartaFianza.Enabled = false;
            this.txtCartaFianza.Location = new System.Drawing.Point(123, 19);
            this.txtCartaFianza.Name = "txtCartaFianza";
            this.txtCartaFianza.ReadOnly = true;
            this.txtCartaFianza.Size = new System.Drawing.Size(175, 20);
            this.txtCartaFianza.TabIndex = 34;
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(9, 22);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(108, 13);
            this.lblBase12.TabIndex = 33;
            this.lblBase12.Text = "Nro Carta Fianza:";
            // 
            // frmRenovarCartaFianza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 402);
            this.Controls.Add(this.btnAceptar1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.conBusCli1);
            this.Name = "frmRenovarCartaFianza";
            this.Text = "Renovar Carta Fianza";
            this.Load += new System.EventHandler(this.frmRenovarCartaFianza_Load);
            this.Controls.SetChildIndex(this.conBusCli1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.ConBusCli conBusCli1;
        private System.Windows.Forms.GroupBox groupBox2;
        private GEN.ControlesBase.cboMoneda cboMoneda1;
        private GEN.ControlesBase.txtBase txtTasaAprobada;
        private GEN.ControlesBase.txtBase txtPlazoAprobado;
        private GEN.ControlesBase.txtBase txtFechaInicioAprobado;
        private GEN.ControlesBase.txtBase txtMontoAprobado;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.lblBase lblBase8;
        private System.Windows.Forms.GroupBox groupBox1;
        private GEN.ControlesBase.cboMoneda cboMoneda2;
        private GEN.ControlesBase.txtBase txtFechaInicioRenovacion;
        private GEN.ControlesBase.txtBase txtMontoRenovacion;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.BtnAceptar btnAceptar1;
        private GEN.ControlesBase.txtCBNumerosEnteros txtTasaRenovacion;
        private GEN.ControlesBase.txtCBNumerosEnteros txtPlazoRenovacion;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.txtBase txtCartaFianza;
        private GEN.ControlesBase.lblBase lblBase12;

    }
}