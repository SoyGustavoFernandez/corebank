namespace CLI.Presentacion
{
    partial class frmReporteCuentasCli
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteCuentasCli));
            this.conBusCli1 = new GEN.ControlesBase.ConBusCli();
            this.txtCodInst = new GEN.ControlesBase.txtBase(this.components);
            this.txtCodAge = new GEN.ControlesBase.txtBase(this.components);
            this.txtDireccion = new GEN.ControlesBase.txtBase(this.components);
            this.txtCodCli = new GEN.ControlesBase.txtBase(this.components);
            this.txtNombre = new GEN.ControlesBase.txtBase(this.components);
            this.txtNroDoc = new GEN.ControlesBase.txtBase(this.components);
            this.btnImprSocio = new GEN.BotonesBase.btnImprimir();
            this.CHKVerCuentasAhorro = new System.Windows.Forms.CheckBox();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboEstadoCuentaCli1 = new GEN.ControlesBase.cboEstadoCuentaCli(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.conBusCli1.SuspendLayout();
            this.SuspendLayout();
            // 
            // conBusCli1
            // 
            this.conBusCli1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli1.Controls.Add(this.txtCodInst);
            this.conBusCli1.Controls.Add(this.txtCodAge);
            this.conBusCli1.Controls.Add(this.txtDireccion);
            this.conBusCli1.Controls.Add(this.txtCodCli);
            this.conBusCli1.Controls.Add(this.txtNombre);
            this.conBusCli1.Controls.Add(this.txtNroDoc);
            this.conBusCli1.idCli = 0;
            this.conBusCli1.Location = new System.Drawing.Point(12, 12);
            this.conBusCli1.Name = "conBusCli1";
            this.conBusCli1.Size = new System.Drawing.Size(532, 105);
            this.conBusCli1.TabIndex = 3;
            this.conBusCli1.ClicBuscar += new System.EventHandler(this.conBusCli1_ClicBuscar);
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
            // txtDireccion
            // 
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(161, 79);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(357, 20);
            this.txtDireccion.TabIndex = 11;
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
            // btnImprSocio
            // 
            this.btnImprSocio.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprSocio.BackgroundImage")));
            this.btnImprSocio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprSocio.Enabled = false;
            this.btnImprSocio.Location = new System.Drawing.Point(257, 138);
            this.btnImprSocio.Name = "btnImprSocio";
            this.btnImprSocio.Size = new System.Drawing.Size(60, 50);
            this.btnImprSocio.TabIndex = 16;
            this.btnImprSocio.Text = "Cuentas";
            this.btnImprSocio.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprSocio.UseVisualStyleBackColor = true;
            this.btnImprSocio.Click += new System.EventHandler(this.btnImprSocio_Click);
            // 
            // CHKVerCuentasAhorro
            // 
            this.CHKVerCuentasAhorro.AutoSize = true;
            this.CHKVerCuentasAhorro.Location = new System.Drawing.Point(12, 133);
            this.CHKVerCuentasAhorro.Name = "CHKVerCuentasAhorro";
            this.CHKVerCuentasAhorro.Size = new System.Drawing.Size(133, 17);
            this.CHKVerCuentasAhorro.TabIndex = 17;
            this.CHKVerCuentasAhorro.Text = "Ver Cuentas de Ahorro";
            this.CHKVerCuentasAhorro.UseVisualStyleBackColor = true;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 167);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(45, 13);
            this.lblBase1.TabIndex = 18;
            this.lblBase1.Text = "Estado";
            // 
            // cboEstadoCuentaCli1
            // 
            this.cboEstadoCuentaCli1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoCuentaCli1.FormattingEnabled = true;
            this.cboEstadoCuentaCli1.Location = new System.Drawing.Point(63, 164);
            this.cboEstadoCuentaCli1.Name = "cboEstadoCuentaCli1";
            this.cboEstadoCuentaCli1.Size = new System.Drawing.Size(139, 21);
            this.cboEstadoCuentaCli1.TabIndex = 19;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(340, 138);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 20;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // frmReporteCuentasCli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 228);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.cboEstadoCuentaCli1);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.CHKVerCuentasAhorro);
            this.Controls.Add(this.btnImprSocio);
            this.Controls.Add(this.conBusCli1);
            this.Name = "frmReporteCuentasCli";
            this.Text = "Reporte de Cuentas de Cliente";
            this.Load += new System.EventHandler(this.frmReporteCuentasCli_Load);
            this.Controls.SetChildIndex(this.conBusCli1, 0);
            this.Controls.SetChildIndex(this.btnImprSocio, 0);
            this.Controls.SetChildIndex(this.CHKVerCuentasAhorro, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.cboEstadoCuentaCli1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.conBusCli1.ResumeLayout(false);
            this.conBusCli1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.ConBusCli conBusCli1;
        private GEN.ControlesBase.txtBase txtCodInst;
        private GEN.ControlesBase.txtBase txtCodAge;
        private GEN.ControlesBase.txtBase txtDireccion;
        private GEN.ControlesBase.txtBase txtCodCli;
        private GEN.ControlesBase.txtBase txtNombre;
        private GEN.ControlesBase.txtBase txtNroDoc;
        private GEN.BotonesBase.btnImprimir btnImprSocio;
        private System.Windows.Forms.CheckBox CHKVerCuentasAhorro;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboEstadoCuentaCli cboEstadoCuentaCli1;
        private GEN.BotonesBase.btnSalir btnSalir1;
    }
}