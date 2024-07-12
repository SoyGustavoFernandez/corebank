namespace DEP.Presentacion
{
    partial class frmSolReimpresion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSolReimpresion));
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.txtCodCertificado = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtNroFolio = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.cboTipoCuenta = new GEN.ControlesBase.cboTipoCuenta(this.components);
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.dtpCorto1 = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtProducto = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.conBusCtaAho = new GEN.ControlesBase.conBusCtaAho();
            this.txtNombre = new GEN.ControlesBase.txtBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgFormatos = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase22 = new GEN.ControlesBase.lblBase();
            this.cboMotivos = new GEN.ControlesBase.cboMotivos(this.components);
            this.txtMotReimpresion = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnEnviar = new GEN.BotonesBase.btnEnviar();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase2.SuspendLayout();
            this.conBusCtaAho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFormatos)).BeginInit();
            this.grbBase3.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.lblBase7);
            this.grbBase2.Controls.Add(this.txtCodCertificado);
            this.grbBase2.Controls.Add(this.txtNroFolio);
            this.grbBase2.Controls.Add(this.lblBase9);
            this.grbBase2.Controls.Add(this.cboTipoCuenta);
            this.grbBase2.Controls.Add(this.cboMoneda);
            this.grbBase2.Controls.Add(this.dtpCorto1);
            this.grbBase2.Controls.Add(this.lblBase5);
            this.grbBase2.Controls.Add(this.lblBase3);
            this.grbBase2.Controls.Add(this.txtProducto);
            this.grbBase2.Controls.Add(this.lblBase2);
            this.grbBase2.Controls.Add(this.lblBase1);
            this.grbBase2.Location = new System.Drawing.Point(15, 131);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(664, 108);
            this.grbBase2.TabIndex = 11;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Datos de Cuenta:";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(317, 82);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(167, 13);
            this.lblBase7.TabIndex = 157;
            this.lblBase7.Text = "Nro de Folio del Certificado:";
            // 
            // txtCodCertificado
            // 
            this.txtCodCertificado.Enabled = false;
            this.txtCodCertificado.Location = new System.Drawing.Point(132, 76);
            this.txtCodCertificado.Name = "txtCodCertificado";
            this.txtCodCertificado.Size = new System.Drawing.Size(105, 20);
            this.txtCodCertificado.TabIndex = 160;
            // 
            // txtNroFolio
            // 
            this.txtNroFolio.Enabled = false;
            this.txtNroFolio.Location = new System.Drawing.Point(487, 80);
            this.txtNroFolio.Name = "txtNroFolio";
            this.txtNroFolio.Size = new System.Drawing.Size(105, 20);
            this.txtNroFolio.TabIndex = 158;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(3, 79);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(126, 13);
            this.lblBase9.TabIndex = 159;
            this.lblBase9.Text = "Cód. del Certificado:";
            // 
            // cboTipoCuenta
            // 
            this.cboTipoCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoCuenta.Enabled = false;
            this.cboTipoCuenta.FormattingEnabled = true;
            this.cboTipoCuenta.Location = new System.Drawing.Point(132, 49);
            this.cboTipoCuenta.Name = "cboTipoCuenta";
            this.cboTipoCuenta.Size = new System.Drawing.Size(232, 21);
            this.cboTipoCuenta.TabIndex = 21;
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(487, 25);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(169, 21);
            this.cboMoneda.TabIndex = 11;
            // 
            // dtpCorto1
            // 
            this.dtpCorto1.Enabled = false;
            this.dtpCorto1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCorto1.Location = new System.Drawing.Point(486, 54);
            this.dtpCorto1.Name = "dtpCorto1";
            this.dtpCorto1.Size = new System.Drawing.Size(106, 20);
            this.dtpCorto1.TabIndex = 19;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(383, 57);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(99, 13);
            this.lblBase5.TabIndex = 18;
            this.lblBase5.Text = "Fecha Apertura:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(428, 28);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(56, 13);
            this.lblBase3.TabIndex = 14;
            this.lblBase3.Text = "Moneda:";
            // 
            // txtProducto
            // 
            this.txtProducto.BackColor = System.Drawing.SystemColors.Control;
            this.txtProducto.Enabled = false;
            this.txtProducto.Location = new System.Drawing.Point(95, 21);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(272, 20);
            this.txtProducto.TabIndex = 11;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(23, 52);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(99, 13);
            this.lblBase2.TabIndex = 1;
            this.lblBase2.Text = "Tipo de Cuenta:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(30, 24);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(62, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Producto:";
            // 
            // conBusCtaAho
            // 
            this.conBusCtaAho.Controls.Add(this.txtNombre);
            this.conBusCtaAho.Controls.Add(this.grbBase1);
            this.conBusCtaAho.Location = new System.Drawing.Point(12, 12);
            this.conBusCtaAho.Name = "conBusCtaAho";
            this.conBusCtaAho.Size = new System.Drawing.Size(563, 114);
            this.conBusCtaAho.TabIndex = 10;
            this.conBusCtaAho.ClicBusCta += new System.EventHandler(this.conBusCtaAho_ClicBusCta);
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(158, 82);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(395, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // grbBase1
            // 
            this.grbBase1.Location = new System.Drawing.Point(3, -1);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(556, 112);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos del Cliente";
            // 
            // dtgFormatos
            // 
            this.dtgFormatos.AllowUserToAddRows = false;
            this.dtgFormatos.AllowUserToDeleteRows = false;
            this.dtgFormatos.AllowUserToResizeColumns = false;
            this.dtgFormatos.AllowUserToResizeRows = false;
            this.dtgFormatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgFormatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgFormatos.Location = new System.Drawing.Point(26, 248);
            this.dtgFormatos.MultiSelect = false;
            this.dtgFormatos.Name = "dtgFormatos";
            this.dtgFormatos.ReadOnly = true;
            this.dtgFormatos.RowHeadersVisible = false;
            this.dtgFormatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgFormatos.Size = new System.Drawing.Size(625, 123);
            this.dtgFormatos.TabIndex = 12;
            // 
            // lblBase22
            // 
            this.lblBase22.AutoSize = true;
            this.lblBase22.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase22.ForeColor = System.Drawing.Color.Navy;
            this.lblBase22.Location = new System.Drawing.Point(15, 23);
            this.lblBase22.Name = "lblBase22";
            this.lblBase22.Size = new System.Drawing.Size(124, 13);
            this.lblBase22.TabIndex = 152;
            this.lblBase22.Text = "Motivo Reimpresion:";
            // 
            // cboMotivos
            // 
            this.cboMotivos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMotivos.Enabled = false;
            this.cboMotivos.FormattingEnabled = true;
            this.cboMotivos.Location = new System.Drawing.Point(142, 20);
            this.cboMotivos.Name = "cboMotivos";
            this.cboMotivos.Size = new System.Drawing.Size(304, 21);
            this.cboMotivos.TabIndex = 149;
            // 
            // txtMotReimpresion
            // 
            this.txtMotReimpresion.Enabled = false;
            this.txtMotReimpresion.Location = new System.Drawing.Point(141, 45);
            this.txtMotReimpresion.Multiline = true;
            this.txtMotReimpresion.Name = "txtMotReimpresion";
            this.txtMotReimpresion.Size = new System.Drawing.Size(504, 48);
            this.txtMotReimpresion.TabIndex = 150;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(15, 45);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(78, 13);
            this.lblBase4.TabIndex = 151;
            this.lblBase4.Text = "Descripción:";
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(608, 487);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 155;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(542, 487);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 154;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEnviar.BackgroundImage")));
            this.btnEnviar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEnviar.Enabled = false;
            this.btnEnviar.Location = new System.Drawing.Point(482, 487);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(60, 50);
            this.btnEnviar.TabIndex = 153;
            this.btnEnviar.Text = "&Enviar";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.txtMotReimpresion);
            this.grbBase3.Controls.Add(this.lblBase4);
            this.grbBase3.Controls.Add(this.cboMotivos);
            this.grbBase3.Controls.Add(this.lblBase22);
            this.grbBase3.Location = new System.Drawing.Point(9, 378);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(659, 100);
            this.grbBase3.TabIndex = 156;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Datos de la Solicitud de Reimpresión";
            // 
            // frmSolReimpresion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 565);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.dtgFormatos);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.conBusCtaAho);
            this.Controls.Add(this.grbBase3);
            this.Name = "frmSolReimpresion";
            this.Text = "Solicitud de Reimpresión de Formatos";
            this.Load += new System.EventHandler(this.frmSolReimpresion_Load);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.conBusCtaAho, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.dtgFormatos, 0);
            this.Controls.SetChildIndex(this.btnEnviar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.conBusCtaAho.ResumeLayout(false);
            this.conBusCtaAho.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFormatos)).EndInit();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.cboTipoCuenta cboTipoCuenta;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.dtpCorto dtpCorto1;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtBase txtProducto;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.conBusCtaAho conBusCtaAho;
        private GEN.ControlesBase.txtBase txtNombre;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.dtgBase dtgFormatos;
        private GEN.ControlesBase.lblBase lblBase22;
        private GEN.ControlesBase.cboMotivos cboMotivos;
        private GEN.ControlesBase.txtBase txtMotReimpresion;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnEnviar btnEnviar;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.txtCBNumerosEnteros txtCodCertificado;
        private GEN.ControlesBase.txtCBNumerosEnteros txtNroFolio;
        private GEN.ControlesBase.lblBase lblBase9;
    }
}