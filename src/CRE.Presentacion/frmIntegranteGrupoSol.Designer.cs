namespace CRE.Presentacion
{
    partial class frmIntegranteGrupoSol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIntegranteGrupoSol));
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.cboCargo = new GEN.ControlesBase.CboGrupoSolidarioCargo(this.components);
            this.dtFechaIntegracion = new GEN.ControlesBase.dtLargoBase(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.conBusCli = new GEN.ControlesBase.ConBusCli();
            this.txtCodInst = new GEN.ControlesBase.txtBase(this.components);
            this.txtCodAge = new GEN.ControlesBase.txtBase(this.components);
            this.object_1768eed0_1f87_4488_a0f5_f658c17e4672 = new GEN.ControlesBase.txtBase(this.components);
            this.txtCodCli = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtNombre = new GEN.ControlesBase.txtBase(this.components);
            this.txtNroDoc = new GEN.ControlesBase.txtBase(this.components);
            this.cboCiclo = new GEN.ControlesBase.CboGrupoSolidarioCiclo(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.chcDomicilio = new GEN.ControlesBase.chcBase(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.grbBase3.SuspendLayout();
            this.conBusCli.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.cboCargo);
            this.grbBase3.Controls.Add(this.dtFechaIntegracion);
            this.grbBase3.Controls.Add(this.lblBase9);
            this.grbBase3.Controls.Add(this.lblBase8);
            this.grbBase3.Controls.Add(this.conBusCli);
            this.grbBase3.Location = new System.Drawing.Point(12, 21);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(540, 172);
            this.grbBase3.TabIndex = 95;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Información Integrante";
            // 
            // cboCargo
            // 
            this.cboCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCargo.FormattingEnabled = true;
            this.cboCargo.Location = new System.Drawing.Point(167, 97);
            this.cboCargo.Name = "cboCargo";
            this.cboCargo.Size = new System.Drawing.Size(121, 21);
            this.cboCargo.TabIndex = 0;
            this.cboCargo.SelectedIndexChanged += new System.EventHandler(this.cboCargo_SelectedIndexChanged);
            // 
            // dtFechaIntegracion
            // 
            this.dtFechaIntegracion.CustomFormat = "dd/MMM/yyyy";
            this.dtFechaIntegracion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaIntegracion.Location = new System.Drawing.Point(167, 120);
            this.dtFechaIntegracion.Name = "dtFechaIntegracion";
            this.dtFechaIntegracion.Size = new System.Drawing.Size(100, 20);
            this.dtFechaIntegracion.TabIndex = 2;
            this.dtFechaIntegracion.Value = new System.DateTime(2012, 5, 31, 17, 25, 32, 0);
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(40, 124);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(125, 13);
            this.lblBase9.TabIndex = 96;
            this.lblBase9.Text = "Fecha de integración";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(48, 101);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(117, 13);
            this.lblBase8.TabIndex = 94;
            this.lblBase8.Text = "Cargo en  el Grupo";
            // 
            // conBusCli
            // 
            this.conBusCli.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli.Controls.Add(this.txtCodInst);
            this.conBusCli.Controls.Add(this.txtCodAge);
            this.conBusCli.Controls.Add(this.object_1768eed0_1f87_4488_a0f5_f658c17e4672);
            this.conBusCli.Controls.Add(this.txtCodCli);
            this.conBusCli.Controls.Add(this.txtNombre);
            this.conBusCli.Controls.Add(this.txtNroDoc);
            this.conBusCli.idCli = 0;
            this.conBusCli.Location = new System.Drawing.Point(6, 19);
            this.conBusCli.Name = "conBusCli";
            this.conBusCli.Size = new System.Drawing.Size(531, 77);
            this.conBusCli.TabIndex = 4;
            this.conBusCli.TabStop = false;
            this.conBusCli.ClicBuscar += new System.EventHandler(this.conBusCli_ClicBuscar);
            // 
            // txtCodInst
            // 
            this.txtCodInst.Enabled = false;
            this.txtCodInst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodInst.Location = new System.Drawing.Point(161, 8);
            this.txtCodInst.Name = "txtCodInst";
            this.txtCodInst.Size = new System.Drawing.Size(27, 20);
            this.txtCodInst.TabIndex = 13;
            // 
            // txtCodAge
            // 
            this.txtCodAge.Enabled = false;
            this.txtCodAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodAge.Location = new System.Drawing.Point(186, 8);
            this.txtCodAge.Name = "txtCodAge";
            this.txtCodAge.Size = new System.Drawing.Size(27, 20);
            this.txtCodAge.TabIndex = 12;
            // 
            // object_1768eed0_1f87_4488_a0f5_f658c17e4672
            // 
            this.object_1768eed0_1f87_4488_a0f5_f658c17e4672.Enabled = false;
            this.object_1768eed0_1f87_4488_a0f5_f658c17e4672.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.object_1768eed0_1f87_4488_a0f5_f658c17e4672.Location = new System.Drawing.Point(161, 79);
            this.object_1768eed0_1f87_4488_a0f5_f658c17e4672.Name = "object_1768eed0_1f87_4488_a0f5_f658c17e4672";
            this.object_1768eed0_1f87_4488_a0f5_f658c17e4672.Size = new System.Drawing.Size(357, 20);
            this.object_1768eed0_1f87_4488_a0f5_f658c17e4672.TabIndex = 11;
            // 
            // txtCodCli
            // 
            this.txtCodCli.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodCli.Location = new System.Drawing.Point(211, 8);
            this.txtCodCli.MaxLength = 7;
            this.txtCodCli.Name = "txtCodCli";
            this.txtCodCli.Size = new System.Drawing.Size(130, 20);
            this.txtCodCli.TabIndex = 1;
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(161, 55);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(357, 20);
            this.txtNombre.TabIndex = 6;
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Enabled = false;
            this.txtNroDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroDoc.Location = new System.Drawing.Point(161, 31);
            this.txtNroDoc.MaxLength = 15;
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(180, 20);
            this.txtNroDoc.TabIndex = 5;
            // 
            // cboCiclo
            // 
            this.cboCiclo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCiclo.FormattingEnabled = true;
            this.cboCiclo.Location = new System.Drawing.Point(181, 199);
            this.cboCiclo.Name = "cboCiclo";
            this.cboCiclo.Size = new System.Drawing.Size(121, 21);
            this.cboCiclo.TabIndex = 1;
            this.cboCiclo.Visible = false;
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(144, 203);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(35, 13);
            this.lblBase10.TabIndex = 98;
            this.lblBase10.Text = "Ciclo";
            this.lblBase10.Visible = false;
            // 
            // chcDomicilio
            // 
            this.chcDomicilio.AutoSize = true;
            this.chcDomicilio.Location = new System.Drawing.Point(179, 166);
            this.chcDomicilio.Name = "chcDomicilio";
            this.chcDomicilio.Size = new System.Drawing.Size(115, 17);
            this.chcDomicilio.TabIndex = 3;
            this.chcDomicilio.Text = "Domicilio del grupo";
            this.chcDomicilio.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(492, 199);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(426, 199);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(360, 199);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmIntegranteGrupoSol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 285);
            this.Controls.Add(this.cboCiclo);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblBase10);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.chcDomicilio);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grbBase3);
            this.Name = "frmIntegranteGrupoSol";
            this.ShowInTaskbar = false;
            this.Text = "Integrante del Grupo Solidario";
            this.Shown += new System.EventHandler(this.frmIntegranteGrupoSol_Shown);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.chcDomicilio, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.lblBase10, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.cboCiclo, 0);
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.conBusCli.ResumeLayout(false);
            this.conBusCli.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.dtLargoBase dtFechaIntegracion;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.ConBusCli conBusCli;
        private GEN.ControlesBase.txtBase txtCodInst;
        private GEN.ControlesBase.txtBase txtCodAge;
        private GEN.ControlesBase.txtBase object_1768eed0_1f87_4488_a0f5_f658c17e4672;
        private GEN.ControlesBase.txtCBNumerosEnteros txtCodCli;
        private GEN.ControlesBase.txtBase txtNombre;
        private GEN.ControlesBase.txtBase txtNroDoc;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.ControlesBase.chcBase chcDomicilio;
        private GEN.ControlesBase.CboGrupoSolidarioCiclo cboCiclo;
        private GEN.ControlesBase.CboGrupoSolidarioCargo cboCargo;
    }
}