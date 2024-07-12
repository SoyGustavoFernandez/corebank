namespace GEN.ControlesBase
{
    partial class frmBuscarCreditoCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarCreditoCliente));
            this.conBusCli = new GEN.ControlesBase.ConBusCli();
            this.dtgDatosCreditoCliente = new GEN.ControlesBase.dtgBase(this.components);
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatosCreditoCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // conBusCli
            // 
            this.conBusCli.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli.idCli = 0;
            this.conBusCli.Location = new System.Drawing.Point(12, 12);
            this.conBusCli.Name = "conBusCli";
            this.conBusCli.Size = new System.Drawing.Size(580, 105);
            this.conBusCli.TabIndex = 2;
            this.conBusCli.ClicBuscar += new System.EventHandler(this.conBusCli_ClicBuscar);
            // 
            // dtgDatosCreditoCliente
            // 
            this.dtgDatosCreditoCliente.AllowUserToAddRows = false;
            this.dtgDatosCreditoCliente.AllowUserToDeleteRows = false;
            this.dtgDatosCreditoCliente.AllowUserToResizeColumns = false;
            this.dtgDatosCreditoCliente.AllowUserToResizeRows = false;
            this.dtgDatosCreditoCliente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dtgDatosCreditoCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDatosCreditoCliente.Location = new System.Drawing.Point(12, 123);
            this.dtgDatosCreditoCliente.MultiSelect = false;
            this.dtgDatosCreditoCliente.Name = "dtgDatosCreditoCliente";
            this.dtgDatosCreditoCliente.ReadOnly = true;
            this.dtgDatosCreditoCliente.RowHeadersVisible = false;
            this.dtgDatosCreditoCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDatosCreditoCliente.Size = new System.Drawing.Size(660, 207);
            this.dtgDatosCreditoCliente.TabIndex = 3;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(552, 336);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(612, 336);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmBuscarCreditoCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 411);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dtgDatosCreditoCliente);
            this.Controls.Add(this.conBusCli);
            this.Name = "frmBuscarCreditoCliente";
            this.Text = "Buscar  Créditos de Cliente";
            this.Controls.SetChildIndex(this.conBusCli, 0);
            this.Controls.SetChildIndex(this.dtgDatosCreditoCliente, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatosCreditoCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ConBusCli conBusCli;
        private dtgBase dtgDatosCreditoCliente;
        private BotonesBase.BtnAceptar btnAceptar;
        private BotonesBase.btnCancelar btnCancelar;
    }
}