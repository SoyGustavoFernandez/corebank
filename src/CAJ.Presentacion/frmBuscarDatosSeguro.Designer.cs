namespace CAJ.Presentacion
{
    partial class frmBuscarDatosSeguro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarDatosSeguro));
            this.conBusCuentaCli = new GEN.ControlesBase.ConBusCuentaCli();
            this.dtgCreditoSeguro = new GEN.ControlesBase.dtgBase(this.components);
            this.grbCreditoSeguroPendiente = new GEN.ControlesBase.grbBase(this.components);
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCreditoSeguro)).BeginInit();
            this.grbCreditoSeguroPendiente.SuspendLayout();
            this.SuspendLayout();
            // 
            // conBusCuentaCli
            // 
            this.conBusCuentaCli.BackColor = System.Drawing.Color.Transparent;
            this.conBusCuentaCli.Location = new System.Drawing.Point(15, 12);
            this.conBusCuentaCli.Name = "conBusCuentaCli";
            this.conBusCuentaCli.Size = new System.Drawing.Size(565, 100);
            this.conBusCuentaCli.TabIndex = 4;
            this.conBusCuentaCli.MyKey += new System.Windows.Forms.KeyPressEventHandler(this.conBusCuentaCli_MyKey);
            this.conBusCuentaCli.MyClic += new System.EventHandler(this.conBusCuentaCli_MyClic);
            // 
            // dtgCreditoSeguro
            // 
            this.dtgCreditoSeguro.AllowUserToAddRows = false;
            this.dtgCreditoSeguro.AllowUserToDeleteRows = false;
            this.dtgCreditoSeguro.AllowUserToResizeColumns = false;
            this.dtgCreditoSeguro.AllowUserToResizeRows = false;
            this.dtgCreditoSeguro.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCreditoSeguro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCreditoSeguro.Location = new System.Drawing.Point(10, 14);
            this.dtgCreditoSeguro.MultiSelect = false;
            this.dtgCreditoSeguro.Name = "dtgCreditoSeguro";
            this.dtgCreditoSeguro.ReadOnly = true;
            this.dtgCreditoSeguro.RowHeadersVisible = false;
            this.dtgCreditoSeguro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCreditoSeguro.Size = new System.Drawing.Size(580, 119);
            this.dtgCreditoSeguro.TabIndex = 5;
            // 
            // grbCreditoSeguroPendiente
            // 
            this.grbCreditoSeguroPendiente.Controls.Add(this.dtgCreditoSeguro);
            this.grbCreditoSeguroPendiente.Location = new System.Drawing.Point(2, 114);
            this.grbCreditoSeguroPendiente.Name = "grbCreditoSeguroPendiente";
            this.grbCreditoSeguroPendiente.Size = new System.Drawing.Size(600, 143);
            this.grbCreditoSeguroPendiente.TabIndex = 6;
            this.grbCreditoSeguroPendiente.TabStop = false;
            this.grbCreditoSeguroPendiente.Text = "Lista de Seguros pendientes de cobrar";
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(412, 252);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(472, 252);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(532, 253);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmBuscarDatosSeguro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 335);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.grbCreditoSeguroPendiente);
            this.Controls.Add(this.conBusCuentaCli);
            this.Name = "frmBuscarDatosSeguro";
            this.Text = "Búsqueda de Seguros de Créditos";
            this.Load += new System.EventHandler(this.frmBuscarDatosSeguro_Load);
            this.Controls.SetChildIndex(this.conBusCuentaCli, 0);
            this.Controls.SetChildIndex(this.grbCreditoSeguroPendiente, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCreditoSeguro)).EndInit();
            this.grbCreditoSeguroPendiente.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private GEN.ControlesBase.ConBusCuentaCli conBusCuentaCli;
        private GEN.ControlesBase.dtgBase dtgCreditoSeguro;
        private GEN.ControlesBase.grbBase grbCreditoSeguroPendiente;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir;
    }
}