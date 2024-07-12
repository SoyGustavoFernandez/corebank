namespace SPL.Presentacion
{
    partial class frmActualizarDatos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmActualizarDatos));
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnProcesar1 = new GEN.BotonesBase.btnProcesar();
            this.conFechaAñoMes1 = new GEN.ControlesBase.ConFechaAñoMes();
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(143, 57);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 13;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnProcesar1
            // 
            this.btnProcesar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar1.BackgroundImage")));
            this.btnProcesar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar1.Location = new System.Drawing.Point(77, 57);
            this.btnProcesar1.Name = "btnProcesar1";
            this.btnProcesar1.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar1.TabIndex = 8;
            this.btnProcesar1.Text = "&Procesar";
            this.btnProcesar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar1.UseVisualStyleBackColor = true;
            this.btnProcesar1.Click += new System.EventHandler(this.btnProcesar1_Click);
            // 
            // conFechaAñoMes1
            // 
            this.conFechaAñoMes1.anio = 1;
            this.conFechaAñoMes1.cMes = "ENERO";
            this.conFechaAñoMes1.idMes = 1;
            this.conFechaAñoMes1.Location = new System.Drawing.Point(63, 12);
            this.conFechaAñoMes1.Name = "conFechaAñoMes1";
            this.conFechaAñoMes1.Size = new System.Drawing.Size(164, 39);
            this.conFechaAñoMes1.TabIndex = 14;
            // 
            // frmActualizarDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 145);
            this.Controls.Add(this.conFechaAñoMes1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnProcesar1);
            this.Name = "frmActualizarDatos";
            this.Text = "Actualizar Datos Del Registro de Clientes";
            this.Controls.SetChildIndex(this.btnProcesar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.conFechaAñoMes1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnProcesar btnProcesar1;
        private GEN.ControlesBase.ConFechaAñoMes conFechaAñoMes1;
    }
}