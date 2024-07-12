namespace GEN.ControlesBase
{
    partial class ConBusPersona
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConBusPersona));
            this.btnBuscarCliente = new GEN.BotonesBase.btnBusCliente();
            this.lblNoEscliente = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.txtDocumentoID = new GEN.ControlesBase.txtCBNroDocumentos(this.components);
            this.txtCodigoInstitucion = new GEN.ControlesBase.txtBase(this.components);
            this.txtCodigoAgencia = new GEN.ControlesBase.txtBase(this.components);
            this.txtDireccion = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtCodigoCliente = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtNombreCompleto = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.SuspendLayout();
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarCliente.BackgroundImage")));
            this.btnBuscarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBuscarCliente.Location = new System.Drawing.Point(459, 3);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(60, 50);
            this.btnBuscarCliente.TabIndex = 15;
            this.btnBuscarCliente.Text = "Cliente";
            this.btnBuscarCliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // lblNoEscliente
            // 
            this.lblNoEscliente.AutoSize = true;
            this.lblNoEscliente.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoEscliente.ForeColor = System.Drawing.Color.Red;
            this.lblNoEscliente.Location = new System.Drawing.Point(349, 37);
            this.lblNoEscliente.Name = "lblNoEscliente";
            this.lblNoEscliente.Size = new System.Drawing.Size(92, 13);
            this.lblNoEscliente.TabIndex = 26;
            this.lblNoEscliente.Text = "No es Cliente";
            this.lblNoEscliente.Visible = false;
            // 
            // txtDocumentoID
            // 
            this.txtDocumentoID.Location = new System.Drawing.Point(162, 10);
            this.txtDocumentoID.Name = "txtDocumentoID";
            this.txtDocumentoID.Size = new System.Drawing.Size(180, 20);
            this.txtDocumentoID.TabIndex = 25;
            this.txtDocumentoID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDocumentoID_KeyPress);
            // 
            // txtCodigoInstitucion
            // 
            this.txtCodigoInstitucion.Enabled = false;
            this.txtCodigoInstitucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoInstitucion.Location = new System.Drawing.Point(162, 33);
            this.txtCodigoInstitucion.Name = "txtCodigoInstitucion";
            this.txtCodigoInstitucion.Size = new System.Drawing.Size(27, 20);
            this.txtCodigoInstitucion.TabIndex = 24;
            // 
            // txtCodigoAgencia
            // 
            this.txtCodigoAgencia.Enabled = false;
            this.txtCodigoAgencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoAgencia.Location = new System.Drawing.Point(187, 33);
            this.txtCodigoAgencia.Name = "txtCodigoAgencia";
            this.txtCodigoAgencia.Size = new System.Drawing.Size(27, 20);
            this.txtCodigoAgencia.TabIndex = 23;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(162, 81);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(357, 20);
            this.txtDireccion.TabIndex = 22;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(14, 85);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(65, 13);
            this.lblBase4.TabIndex = 21;
            this.lblBase4.Text = "Dirección:";
            // 
            // txtCodigoCliente
            // 
            this.txtCodigoCliente.Enabled = false;
            this.txtCodigoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoCliente.Location = new System.Drawing.Point(212, 33);
            this.txtCodigoCliente.MaxLength = 7;
            this.txtCodigoCliente.Name = "txtCodigoCliente";
            this.txtCodigoCliente.Size = new System.Drawing.Size(130, 20);
            this.txtCodigoCliente.TabIndex = 14;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(14, 37);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(114, 13);
            this.lblBase3.TabIndex = 20;
            this.lblBase3.Text = "Código de Cliente:";
            // 
            // txtNombreCompleto
            // 
            this.txtNombreCompleto.Enabled = false;
            this.txtNombreCompleto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreCompleto.Location = new System.Drawing.Point(162, 57);
            this.txtNombreCompleto.Name = "txtNombreCompleto";
            this.txtNombreCompleto.Size = new System.Drawing.Size(357, 20);
            this.txtNombreCompleto.TabIndex = 19;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(14, 60);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(117, 13);
            this.lblBase2.TabIndex = 17;
            this.lblBase2.Text = "Nombre y Apellido:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(14, 14);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(123, 13);
            this.lblBase1.TabIndex = 16;
            this.lblBase1.Text = "Nro. de Documento:";
            // 
            // ConBusPersona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblNoEscliente);
            this.Controls.Add(this.txtDocumentoID);
            this.Controls.Add(this.txtCodigoInstitucion);
            this.Controls.Add(this.txtCodigoAgencia);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.txtCodigoCliente);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.btnBuscarCliente);
            this.Controls.Add(this.txtNombreCompleto);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Name = "ConBusPersona";
            this.Size = new System.Drawing.Size(532, 105);
            this.Load += new System.EventHandler(this.ConBusPersona_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public txtBase txtCodigoInstitucion;
        public txtBase txtCodigoAgencia;
        public txtBase txtDireccion;
        public lblBase lblBase4;
        public txtCBNumerosEnteros txtCodigoCliente;
        private lblBase lblBase3;
        public BotonesBase.btnBusCliente btnBuscarCliente;
        public txtBase txtNombreCompleto;
        public lblBase lblBase2;
        public lblBase lblBase1;
        private lblBaseCustom lblNoEscliente;
        public txtCBNroDocumentos txtDocumentoID;
    }
}
