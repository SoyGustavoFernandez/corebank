namespace CLI.Presentacion
{
    partial class frmRegistroBaseNegativaSoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistroBaseNegativaSoc));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.grbBaseNeg = new GEN.ControlesBase.grbBase(this.components);
            this.txtSustento = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.cboAgencias1 = new GEN.ControlesBase.cboAgencias(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.dtpFechaReg = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtMotivo = new GEN.ControlesBase.txtBase(this.components);
            this.chcBaja = new GEN.ControlesBase.chcBase(this.components);
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.conBusSocio1 = new GEN.ControlesBase.conBusSocio();
            this.grbBaseNeg.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(14, 78);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(49, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Motivo:";
            // 
            // grbBaseNeg
            // 
            this.grbBaseNeg.Controls.Add(this.txtSustento);
            this.grbBaseNeg.Controls.Add(this.lblBase4);
            this.grbBaseNeg.Controls.Add(this.cboAgencias1);
            this.grbBaseNeg.Controls.Add(this.lblBase3);
            this.grbBaseNeg.Controls.Add(this.dtpFechaReg);
            this.grbBaseNeg.Controls.Add(this.lblBase2);
            this.grbBaseNeg.Controls.Add(this.txtMotivo);
            this.grbBaseNeg.Controls.Add(this.lblBase1);
            this.grbBaseNeg.Controls.Add(this.chcBaja);
            this.grbBaseNeg.Location = new System.Drawing.Point(12, 112);
            this.grbBaseNeg.Name = "grbBaseNeg";
            this.grbBaseNeg.Size = new System.Drawing.Size(524, 197);
            this.grbBaseNeg.TabIndex = 1;
            this.grbBaseNeg.TabStop = false;
            // 
            // txtSustento
            // 
            this.txtSustento.Location = new System.Drawing.Point(115, 142);
            this.txtSustento.Multiline = true;
            this.txtSustento.Name = "txtSustento";
            this.txtSustento.Size = new System.Drawing.Size(406, 47);
            this.txtSustento.TabIndex = 4;
            this.txtSustento.TextChanged += new System.EventHandler(this.txtSustento_TextChanged);
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(14, 146);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(62, 13);
            this.lblBase4.TabIndex = 12;
            this.lblBase4.Text = "Sustento:";
            // 
            // cboAgencias1
            // 
            this.cboAgencias1.Enabled = false;
            this.cboAgencias1.FormattingEnabled = true;
            this.cboAgencias1.Location = new System.Drawing.Point(115, 19);
            this.cboAgencias1.Name = "cboAgencias1";
            this.cboAgencias1.Size = new System.Drawing.Size(139, 21);
            this.cboAgencias1.TabIndex = 0;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(14, 19);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(57, 13);
            this.lblBase3.TabIndex = 6;
            this.lblBase3.Text = "Agencia:";
            // 
            // dtpFechaReg
            // 
            this.dtpFechaReg.Enabled = false;
            this.dtpFechaReg.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaReg.Location = new System.Drawing.Point(115, 46);
            this.dtpFechaReg.Name = "dtpFechaReg";
            this.dtpFechaReg.Size = new System.Drawing.Size(139, 20);
            this.dtpFechaReg.TabIndex = 1;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(14, 48);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(96, 13);
            this.lblBase2.TabIndex = 4;
            this.lblBase2.Text = "Fecha Registro:";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(115, 73);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(406, 47);
            this.txtMotivo.TabIndex = 2;
            this.txtMotivo.TextChanged += new System.EventHandler(this.txtMotivo_TextChanged);
            // 
            // chcBaja
            // 
            this.chcBaja.AutoSize = true;
            this.chcBaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chcBaja.ForeColor = System.Drawing.Color.Red;
            this.chcBaja.Location = new System.Drawing.Point(17, 123);
            this.chcBaja.Name = "chcBaja";
            this.chcBaja.Size = new System.Drawing.Size(153, 17);
            this.chcBaja.TabIndex = 3;
            this.chcBaja.Text = "Quitar de la Base Negativa";
            this.chcBaja.UseVisualStyleBackColor = true;
            this.chcBaja.CheckedChanged += new System.EventHandler(this.chcBaja_CheckedChanged);
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Location = new System.Drawing.Point(236, 315);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 2;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Enabled = false;
            this.btnGrabar1.Location = new System.Drawing.Point(356, 315);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 4;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(296, 315);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 3;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(476, 315);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 6;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Enabled = false;
            this.btnCancelar1.Location = new System.Drawing.Point(416, 315);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 5;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // conBusSocio1
            // 
            this.conBusSocio1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusSocio1.idCli = 0;
            this.conBusSocio1.Location = new System.Drawing.Point(15, 8);
            this.conBusSocio1.Name = "conBusSocio1";
            this.conBusSocio1.Size = new System.Drawing.Size(520, 108);
            this.conBusSocio1.TabIndex = 0;
            this.conBusSocio1.ClicBuscar += new System.EventHandler(this.conBusSocio1_ClicBuscar);
            // 
            // frmRegistroBaseNegativaSoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 390);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.conBusSocio1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.grbBaseNeg);
            this.Name = "frmRegistroBaseNegativaSoc";
            this.Text = "Registro de Base Negativa de los Socios";
            this.Load += new System.EventHandler(this.frmRegistroBaseNegativaSoc_Load);
            this.Controls.SetChildIndex(this.grbBaseNeg, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.conBusSocio1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.grbBaseNeg.ResumeLayout(false);
            this.grbBaseNeg.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.grbBase grbBaseNeg;
        private GEN.ControlesBase.chcBase chcBaja;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.dtpCorto dtpFechaReg;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtMotivo;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.cboAgencias cboAgencias1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtBase txtSustento;
        private GEN.ControlesBase.conBusSocio conBusSocio1;
    }
}