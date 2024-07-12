namespace GEN.Servicio
{
    partial class frmRegistroCodigoVerificacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistroCodigoVerificacion));
            this.txtCodigoValidacion = new GEN.ControlesBase.txtNumerico(this.components);
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblNumeroTelefono = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.btnSolExcepcion = new GEN.BotonesBase.btnBlanco();
            this.SuspendLayout();
            // 
            // txtCodigoValidacion
            // 
            this.txtCodigoValidacion.Format = "n2";
            this.txtCodigoValidacion.Location = new System.Drawing.Point(181, 51);
            this.txtCodigoValidacion.MaxLength = 6;
            this.txtCodigoValidacion.Name = "txtCodigoValidacion";
            this.txtCodigoValidacion.Size = new System.Drawing.Size(120, 20);
            this.txtCodigoValidacion.TabIndex = 2;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(142, 98);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(202, 98);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(44, 55);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(131, 13);
            this.lblBase1.TabIndex = 5;
            this.lblBase1.Text = "Código de Validación:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(44, 33);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(127, 13);
            this.lblBase2.TabIndex = 6;
            this.lblBase2.Text = "Número de Teléfono:";
            // 
            // lblNumeroTelefono
            // 
            this.lblNumeroTelefono.AutoSize = true;
            this.lblNumeroTelefono.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroTelefono.ForeColor = System.Drawing.Color.Navy;
            this.lblNumeroTelefono.Location = new System.Drawing.Point(181, 33);
            this.lblNumeroTelefono.Name = "lblNumeroTelefono";
            this.lblNumeroTelefono.Size = new System.Drawing.Size(119, 13);
            this.lblNumeroTelefono.TabIndex = 7;
            this.lblNumeroTelefono.Text = "Número Teléfono";
            // 
            // btnSolExcepcion
            // 
            this.btnSolExcepcion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSolExcepcion.Location = new System.Drawing.Point(82, 98);
            this.btnSolExcepcion.Name = "btnSolExcepcion";
            this.btnSolExcepcion.Size = new System.Drawing.Size(60, 50);
            this.btnSolExcepcion.TabIndex = 21;
            this.btnSolExcepcion.Text = "Sol. Excep.";
            this.btnSolExcepcion.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSolExcepcion.UseVisualStyleBackColor = true;
            this.btnSolExcepcion.Click += new System.EventHandler(this.btnSolExcepcion_Click);
            // 
            // frmRegistroCodigoVerificacion
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 186);
            this.Controls.Add(this.btnSolExcepcion);
            this.Controls.Add(this.lblNumeroTelefono);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtCodigoValidacion);
            this.Name = "frmRegistroCodigoVerificacion";
            this.Text = "Registro de Código de Validación";
            this.Load += new System.EventHandler(this.frmRegistroCodigoVerificacion_Load);
            this.Controls.SetChildIndex(this.txtCodigoValidacion, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblNumeroTelefono, 0);
            this.Controls.SetChildIndex(this.btnSolExcepcion, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlesBase.txtNumerico txtCodigoValidacion;
        private BotonesBase.BtnAceptar btnAceptar;
        private BotonesBase.btnSalir btnSalir;
        private ControlesBase.lblBase lblBase1;
        private ControlesBase.lblBase lblBase2;
        private ControlesBase.lblBaseCustom lblNumeroTelefono;
        private BotonesBase.btnBlanco btnSolExcepcion;
    }
}