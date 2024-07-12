namespace GEN.ControlesBase
{
    partial class ConBusPersonaConServicios
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConBusPersonaConServicios));
            this.btnBusqueda = new GEN.BotonesBase.btnBusqueda();
            this.btnMiniCancelar = new GEN.BotonesBase.btnMiniCancelar();
            this.chcNoCliente = new GEN.ControlesBase.chcBase(this.components);
            this.txtCelular = new GEN.ControlesBase.txtBase(this.components);
            this.txtDireccion = new GEN.ControlesBase.txtBase(this.components);
            this.txtNombre = new GEN.ControlesBase.txtBase(this.components);
            this.txtNumeroDocumento = new GEN.ControlesBase.txtBase(this.components);
            this.cboTipoDocumento = new GEN.ControlesBase.cboTipoDocumento(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.SuspendLayout();
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda.BackgroundImage")));
            this.btnBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda.Location = new System.Drawing.Point(433, 2);
            this.btnBusqueda.Margin = new System.Windows.Forms.Padding(2);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda.TabIndex = 1;
            this.btnBusqueda.Text = "&Buscar";
            this.btnBusqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // btnMiniCancelar
            // 
            this.btnMiniCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniCancelar.BackgroundImage")));
            this.btnMiniCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniCancelar.Location = new System.Drawing.Point(401, 1);
            this.btnMiniCancelar.Name = "btnMiniCancelar";
            this.btnMiniCancelar.Size = new System.Drawing.Size(24, 22);
            this.btnMiniCancelar.TabIndex = 23;
            this.btnMiniCancelar.TabStop = false;
            this.btnMiniCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniCancelar.UseVisualStyleBackColor = true;
            this.btnMiniCancelar.Click += new System.EventHandler(this.btnMiniCancelar_Click);
            // 
            // chcNoCliente
            // 
            this.chcNoCliente.AutoSize = true;
            this.chcNoCliente.Location = new System.Drawing.Point(435, 77);
            this.chcNoCliente.Margin = new System.Windows.Forms.Padding(2);
            this.chcNoCliente.Name = "chcNoCliente";
            this.chcNoCliente.Size = new System.Drawing.Size(94, 17);
            this.chcNoCliente.TabIndex = 22;
            this.chcNoCliente.Text = "No es cliente?";
            this.chcNoCliente.UseVisualStyleBackColor = true;
            // 
            // txtCelular
            // 
            this.txtCelular.Location = new System.Drawing.Point(143, 74);
            this.txtCelular.Margin = new System.Windows.Forms.Padding(2);
            this.txtCelular.MaxLength = 9;
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(282, 20);
            this.txtCelular.TabIndex = 5;
            this.txtCelular.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCelular_KeyPress);
            // 
            // txtDireccion
            // 
            this.txtDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDireccion.Location = new System.Drawing.Point(143, 50);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(282, 20);
            this.txtDireccion.TabIndex = 4;
            // 
            // txtNombre
            // 
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Location = new System.Drawing.Point(143, 26);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(282, 20);
            this.txtNombre.TabIndex = 3;
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Location = new System.Drawing.Point(286, 2);
            this.txtNumeroDocumento.Margin = new System.Windows.Forms.Padding(2);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Size = new System.Drawing.Size(113, 20);
            this.txtNumeroDocumento.TabIndex = 0;
            this.txtNumeroDocumento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumeroDocumento_KeyDown);
            this.txtNumeroDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroDocumento_KeyPress);
            // 
            // cboTipoDocumento
            // 
            this.cboTipoDocumento.FormattingEnabled = true;
            this.cboTipoDocumento.Location = new System.Drawing.Point(143, 2);
            this.cboTipoDocumento.Margin = new System.Windows.Forms.Padding(2);
            this.cboTipoDocumento.Name = "cboTipoDocumento";
            this.cboTipoDocumento.Size = new System.Drawing.Size(139, 21);
            this.cboTipoDocumento.TabIndex = 2;
            this.cboTipoDocumento.SelectedIndexChanged += new System.EventHandler(this.cboTipoDocumento_SelectedIndexChanged);
            this.cboTipoDocumento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboTipoDocumento_KeyDown);
            this.cboTipoDocumento.Leave += new System.EventHandler(this.cboTipoDocumento_Leave);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(3, 77);
            this.lblBase5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(53, 13);
            this.lblBase5.TabIndex = 15;
            this.lblBase5.Text = "Celular:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(3, 53);
            this.lblBase4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(65, 13);
            this.lblBase4.TabIndex = 14;
            this.lblBase4.Text = "Dirección:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(3, 29);
            this.lblBase3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(133, 13);
            this.lblBase3.TabIndex = 13;
            this.lblBase3.Text = "Nombre/Razón social:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(3, 6);
            this.lblBase1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(77, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Documento:";
            // 
            // ConBusPersonaConServicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnMiniCancelar);
            this.Controls.Add(this.chcNoCliente);
            this.Controls.Add(this.btnBusqueda);
            this.Controls.Add(this.txtCelular);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtNumeroDocumento);
            this.Controls.Add(this.cboTipoDocumento);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ConBusPersonaConServicios";
            this.Size = new System.Drawing.Size(531, 100);
            this.Load += new System.EventHandler(this.ConBusPersonaConServicios_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private lblBase lblBase1;
        private lblBase lblBase5;
        private lblBase lblBase4;
        private lblBase lblBase3;
        private cboTipoDocumento cboTipoDocumento;
        private txtBase txtNumeroDocumento;
        private txtBase txtNombre;
        private txtBase txtDireccion;
        private txtBase txtCelular;
        private BotonesBase.btnBusqueda btnBusqueda;
        private chcBase chcNoCliente;
        private BotonesBase.btnMiniCancelar btnMiniCancelar;
    }
}
