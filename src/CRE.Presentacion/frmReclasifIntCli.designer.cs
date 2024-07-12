namespace CRE.Presentacion
{
    partial class frmReclasifIntCli
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReclasifIntCli));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.chcTieneClasif = new GEN.ControlesBase.chcBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.dtpFecClasif = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtpFecUltClasif = new GEN.ControlesBase.dtpCorto(this.components);
            this.cboCalifIni = new GEN.ControlesBase.cboCalifInt(this.components);
            this.txtObservacion = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblCalifica = new GEN.ControlesBase.lblBase();
            this.lblCalifica2 = new GEN.ControlesBase.lblBase();
            this.cboCalifFin = new GEN.ControlesBase.cboCalifInt(this.components);
            this.conBusCli = new GEN.ControlesBase.ConBusCli();
            this.txtCodInst = new GEN.ControlesBase.txtBase(this.components);
            this.txtCodAge = new GEN.ControlesBase.txtBase(this.components);
            this.txtDireccion = new GEN.ControlesBase.txtBase(this.components);
            this.txtCodCli = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtNombre = new GEN.ControlesBase.txtBase(this.components);
            this.txtNroDoc = new GEN.ControlesBase.txtBase(this.components);
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir2 = new GEN.BotonesBase.btnSalir();
            this.grbBase1.SuspendLayout();
            this.conBusCli.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.chcTieneClasif);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.dtpFecClasif);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.dtpFecUltClasif);
            this.grbBase1.Controls.Add(this.cboCalifIni);
            this.grbBase1.Controls.Add(this.txtObservacion);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.lblCalifica);
            this.grbBase1.Controls.Add(this.lblCalifica2);
            this.grbBase1.Controls.Add(this.cboCalifFin);
            this.grbBase1.Location = new System.Drawing.Point(16, 148);
            this.grbBase1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbBase1.Size = new System.Drawing.Size(748, 256);
            this.grbBase1.TabIndex = 25;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos reclasificación";
            // 
            // chcTieneClasif
            // 
            this.chcTieneClasif.AutoSize = true;
            this.chcTieneClasif.Enabled = false;
            this.chcTieneClasif.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chcTieneClasif.ForeColor = System.Drawing.Color.Navy;
            this.chcTieneClasif.Location = new System.Drawing.Point(193, 44);
            this.chcTieneClasif.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chcTieneClasif.Name = "chcTieneClasif";
            this.chcTieneClasif.Size = new System.Drawing.Size(123, 21);
            this.chcTieneClasif.TabIndex = 20;
            this.chcTieneClasif.Text = "Tiene clasif?";
            this.chcTieneClasif.UseVisualStyleBackColor = true;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(375, 22);
            this.lblBase3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(145, 17);
            this.lblBase3.TabIndex = 18;
            this.lblBase3.Text = "Fec. Reclasificación:";
            // 
            // dtpFecClasif
            // 
            this.dtpFecClasif.Enabled = false;
            this.dtpFecClasif.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecClasif.Location = new System.Drawing.Point(375, 42);
            this.dtpFecClasif.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpFecClasif.Name = "dtpFecClasif";
            this.dtpFecClasif.Size = new System.Drawing.Size(153, 22);
            this.dtpFecClasif.TabIndex = 19;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(29, 22);
            this.lblBase2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(159, 17);
            this.lblBase2.TabIndex = 16;
            this.lblBase2.Text = "Fec. Ult. Clasificación:";
            // 
            // dtpFecUltClasif
            // 
            this.dtpFecUltClasif.Enabled = false;
            this.dtpFecUltClasif.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecUltClasif.Location = new System.Drawing.Point(29, 42);
            this.dtpFecUltClasif.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpFecUltClasif.Name = "dtpFecUltClasif";
            this.dtpFecUltClasif.Size = new System.Drawing.Size(153, 22);
            this.dtpFecUltClasif.TabIndex = 17;
            // 
            // cboCalifIni
            // 
            this.cboCalifIni.DisplayMember = "cClasifInterna";
            this.cboCalifIni.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCalifIni.Enabled = false;
            this.cboCalifIni.FormattingEnabled = true;
            this.cboCalifIni.Location = new System.Drawing.Point(29, 100);
            this.cboCalifIni.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboCalifIni.Name = "cboCalifIni";
            this.cboCalifIni.Size = new System.Drawing.Size(235, 24);
            this.cboCalifIni.TabIndex = 9;
            this.cboCalifIni.ValueMember = "idClasifInterna";
            // 
            // txtObservacion
            // 
            this.txtObservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObservacion.Location = new System.Drawing.Point(29, 153);
            this.txtObservacion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(704, 86);
            this.txtObservacion.TabIndex = 15;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(29, 133);
            this.lblBase1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(79, 17);
            this.lblBase1.TabIndex = 14;
            this.lblBase1.Text = "Sustento:";
            // 
            // lblCalifica
            // 
            this.lblCalifica.AutoSize = true;
            this.lblCalifica.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblCalifica.ForeColor = System.Drawing.Color.Navy;
            this.lblCalifica.Location = new System.Drawing.Point(29, 79);
            this.lblCalifica.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCalifica.Name = "lblCalifica";
            this.lblCalifica.Size = new System.Drawing.Size(209, 17);
            this.lblCalifica.TabIndex = 11;
            this.lblCalifica.Text = "Calificación actual del cliente:";
            // 
            // lblCalifica2
            // 
            this.lblCalifica2.AutoSize = true;
            this.lblCalifica2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblCalifica2.ForeColor = System.Drawing.Color.Navy;
            this.lblCalifica2.Location = new System.Drawing.Point(375, 79);
            this.lblCalifica2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCalifica2.Name = "lblCalifica2";
            this.lblCalifica2.Size = new System.Drawing.Size(161, 17);
            this.lblCalifica2.TabIndex = 13;
            this.lblCalifica2.Text = "Cambiar calificación a:";
            // 
            // cboCalifFin
            // 
            this.cboCalifFin.DisplayMember = "cClasifInterna";
            this.cboCalifFin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCalifFin.FormattingEnabled = true;
            this.cboCalifFin.Location = new System.Drawing.Point(375, 100);
            this.cboCalifFin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboCalifFin.Name = "cboCalifFin";
            this.cboCalifFin.Size = new System.Drawing.Size(235, 24);
            this.cboCalifFin.TabIndex = 12;
            this.cboCalifFin.ValueMember = "idClasifInterna";
            // 
            // conBusCli
            // 
            this.conBusCli.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli.Controls.Add(this.txtCodInst);
            this.conBusCli.Controls.Add(this.txtCodAge);
            this.conBusCli.Controls.Add(this.txtDireccion);
            this.conBusCli.Controls.Add(this.txtCodCli);
            this.conBusCli.Controls.Add(this.txtNombre);
            this.conBusCli.Controls.Add(this.txtNroDoc);
            this.conBusCli.idCli = 0;
            this.conBusCli.Location = new System.Drawing.Point(16, 15);
            this.conBusCli.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.conBusCli.Name = "conBusCli";
            this.conBusCli.Size = new System.Drawing.Size(708, 128);
            this.conBusCli.TabIndex = 23;
            this.conBusCli.ClicBuscar += new System.EventHandler(this.conBusCli_ClicBuscar);
            // 
            // txtCodInst
            // 
            this.txtCodInst.Enabled = false;
            this.txtCodInst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodInst.Location = new System.Drawing.Point(161, 8);
            this.txtCodInst.Name = "txtCodInst";
            this.txtCodInst.Size = new System.Drawing.Size(27, 23);
            this.txtCodInst.TabIndex = 13;
            // 
            // txtCodAge
            // 
            this.txtCodAge.Enabled = false;
            this.txtCodAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodAge.Location = new System.Drawing.Point(186, 8);
            this.txtCodAge.Name = "txtCodAge";
            this.txtCodAge.Size = new System.Drawing.Size(27, 23);
            this.txtCodAge.TabIndex = 12;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(161, 79);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(357, 23);
            this.txtDireccion.TabIndex = 11;
            // 
            // txtCodCli
            // 
            this.txtCodCli.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodCli.Location = new System.Drawing.Point(211, 8);
            this.txtCodCli.MaxLength = 7;
            this.txtCodCli.Name = "txtCodCli";
            this.txtCodCli.Size = new System.Drawing.Size(130, 23);
            this.txtCodCli.TabIndex = 1;
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(161, 55);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(357, 23);
            this.txtNombre.TabIndex = 6;
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Enabled = false;
            this.txtNroDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroDoc.Location = new System.Drawing.Point(161, 31);
            this.txtNroDoc.MaxLength = 15;
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(180, 23);
            this.txtNroDoc.TabIndex = 5;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(525, 411);
            this.btnGrabar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 21;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Enabled = false;
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.Location = new System.Drawing.Point(445, 411);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 24;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(604, 411);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 22;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir2
            // 
            this.btnSalir2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir2.BackgroundImage")));
            this.btnSalir2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir2.Location = new System.Drawing.Point(684, 411);
            this.btnSalir2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSalir2.Name = "btnSalir2";
            this.btnSalir2.Size = new System.Drawing.Size(60, 50);
            this.btnSalir2.TabIndex = 26;
            this.btnSalir2.Text = "&Salir";
            this.btnSalir2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir2.UseVisualStyleBackColor = true;
            // 
            // frmReclasifIntCli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(776, 506);
            this.Controls.Add(this.btnSalir2);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.conBusCli);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnCancelar);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frmReclasifIntCli";
            this.Text = "Reclasificación interna de clientes";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.conBusCli, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnSalir2, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.conBusCli.ResumeLayout(false);
            this.conBusCli.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.cboCalifInt cboCalifIni;
        private GEN.ControlesBase.txtBase txtObservacion;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblCalifica;
        private GEN.ControlesBase.lblBase lblCalifica2;
        private GEN.ControlesBase.cboCalifInt cboCalifFin;
        private GEN.ControlesBase.ConBusCli conBusCli;
        private GEN.ControlesBase.txtBase txtCodInst;
        private GEN.ControlesBase.txtBase txtCodAge;
        private GEN.ControlesBase.txtBase txtDireccion;
        private GEN.ControlesBase.txtCBNumerosEnteros txtCodCli;
        private GEN.ControlesBase.txtBase txtNombre;
        private GEN.ControlesBase.txtBase txtNroDoc;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.dtpCorto dtpFecClasif;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.dtpCorto dtpFecUltClasif;
        private GEN.ControlesBase.chcBase chcTieneClasif;
    }
}

