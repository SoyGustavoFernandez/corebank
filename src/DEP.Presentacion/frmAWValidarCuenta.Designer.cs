namespace DEP.Presentacion
{
    partial class frmAWValidarCuenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAWValidarCuenta));
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnValidarImpresion = new System.Windows.Forms.Button();
            this.btnValidarDatos = new System.Windows.Forms.Button();
            this.btnValidarCliente = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chcDocumentosRegularizados = new GEN.ControlesBase.chcBase(this.components);
            this.chcDatosActualizados = new GEN.ControlesBase.chcBase(this.components);
            this.chcIdentidadValidada = new GEN.ControlesBase.chcBase(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(377, 126);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 69;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(310, 126);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 68;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnValidarImpresion
            // 
            this.btnValidarImpresion.Location = new System.Drawing.Point(234, 63);
            this.btnValidarImpresion.Name = "btnValidarImpresion";
            this.btnValidarImpresion.Size = new System.Drawing.Size(163, 25);
            this.btnValidarImpresion.TabIndex = 67;
            this.btnValidarImpresion.Text = "Imprimir Documentos";
            this.btnValidarImpresion.UseVisualStyleBackColor = true;
            this.btnValidarImpresion.Click += new System.EventHandler(this.btnValidarImpresion_Click);
            // 
            // btnValidarDatos
            // 
            this.btnValidarDatos.Location = new System.Drawing.Point(234, 39);
            this.btnValidarDatos.Name = "btnValidarDatos";
            this.btnValidarDatos.Size = new System.Drawing.Size(163, 25);
            this.btnValidarDatos.TabIndex = 66;
            this.btnValidarDatos.Text = "Actualizar Cliente";
            this.btnValidarDatos.UseVisualStyleBackColor = true;
            this.btnValidarDatos.Click += new System.EventHandler(this.btnValidarDatos_Click);
            // 
            // btnValidarCliente
            // 
            this.btnValidarCliente.Location = new System.Drawing.Point(234, 15);
            this.btnValidarCliente.Name = "btnValidarCliente";
            this.btnValidarCliente.Size = new System.Drawing.Size(163, 25);
            this.btnValidarCliente.TabIndex = 65;
            this.btnValidarCliente.Text = "Validar con RENIEC...";
            this.btnValidarCliente.UseVisualStyleBackColor = true;
            this.btnValidarCliente.Click += new System.EventHandler(this.btnValidarCliente_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Controls.Add(this.chcDocumentosRegularizados);
            this.panel1.Controls.Add(this.chcDatosActualizados);
            this.panel1.Controls.Add(this.chcIdentidadValidada);
            this.panel1.Controls.Add(this.btnValidarCliente);
            this.panel1.Controls.Add(this.btnValidarImpresion);
            this.panel1.Controls.Add(this.btnValidarDatos);
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(423, 108);
            this.panel1.TabIndex = 73;
            // 
            // chcDocumentosRegularizados
            // 
            this.chcDocumentosRegularizados.AutoSize = true;
            this.chcDocumentosRegularizados.Location = new System.Drawing.Point(21, 68);
            this.chcDocumentosRegularizados.Name = "chcDocumentosRegularizados";
            this.chcDocumentosRegularizados.Size = new System.Drawing.Size(207, 17);
            this.chcDocumentosRegularizados.TabIndex = 75;
            this.chcDocumentosRegularizados.Text = "Regularizar documentos contractuales";
            this.chcDocumentosRegularizados.UseVisualStyleBackColor = true;
            // 
            // chcDatosActualizados
            // 
            this.chcDatosActualizados.AutoSize = true;
            this.chcDatosActualizados.Location = new System.Drawing.Point(21, 44);
            this.chcDatosActualizados.Name = "chcDatosActualizados";
            this.chcDatosActualizados.Size = new System.Drawing.Size(206, 17);
            this.chcDatosActualizados.TabIndex = 74;
            this.chcDatosActualizados.Text = "Actualizar datos necesarios del cliente";
            this.chcDatosActualizados.UseVisualStyleBackColor = true;
            // 
            // chcIdentidadValidada
            // 
            this.chcIdentidadValidada.AutoSize = true;
            this.chcIdentidadValidada.Location = new System.Drawing.Point(21, 20);
            this.chcIdentidadValidada.Name = "chcIdentidadValidada";
            this.chcIdentidadValidada.Size = new System.Drawing.Size(155, 17);
            this.chcIdentidadValidada.TabIndex = 73;
            this.chcIdentidadValidada.Text = "Validar identidad del cliente";
            this.chcIdentidadValidada.UseVisualStyleBackColor = true;
            // 
            // frmAWValidarCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 206);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Name = "frmAWValidarCuenta";
            this.Text = "Validar Cuenta Aperturada en Línea";
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private System.Windows.Forms.Button btnValidarImpresion;
        private System.Windows.Forms.Button btnValidarDatos;
        private System.Windows.Forms.Button btnValidarCliente;
        private System.Windows.Forms.Panel panel1;
        private GEN.ControlesBase.chcBase chcDocumentosRegularizados;
        private GEN.ControlesBase.chcBase chcDatosActualizados;
        private GEN.ControlesBase.chcBase chcIdentidadValidada;
    }
}