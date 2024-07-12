namespace GEN.ControlesBase
{
    partial class frmSolCreProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSolCreProducto));
            this.conProducto = new GEN.ControlesBase.conProducto();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblidSolicitud = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.SuspendLayout();
            // 
            // conProducto
            // 
            this.conProducto.AutoSize = true;
            this.conProducto.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conProducto.lBloquear3Niveles = false;
            this.conProducto.lMostrarTipoCredito = true;
            this.conProducto.Location = new System.Drawing.Point(11, 41);
            this.conProducto.Name = "conProducto";
            this.conProducto.Size = new System.Drawing.Size(322, 92);
            this.conProducto.TabIndex = 2;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(54, 19);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(55, 13);
            this.lblBase1.TabIndex = 3;
            this.lblBase1.Text = "Solicitud";
            this.lblBase1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblidSolicitud
            // 
            this.lblidSolicitud.AutoSize = true;
            this.lblidSolicitud.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblidSolicitud.ForeColor = System.Drawing.Color.Navy;
            this.lblidSolicitud.Location = new System.Drawing.Point(113, 19);
            this.lblidSolicitud.Name = "lblidSolicitud";
            this.lblidSolicitud.Size = new System.Drawing.Size(13, 13);
            this.lblidSolicitud.TabIndex = 4;
            this.lblidSolicitud.Text = "-";
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(252, 146);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(312, 146);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // frmSolCreProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 236);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblidSolicitud);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.conProducto);
            this.Name = "frmSolCreProducto";
            this.Text = "Selección de Producto";
            this.Load += new System.EventHandler(this.frmSolCreProducto_Load);
            this.Controls.SetChildIndex(this.conProducto, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblidSolicitud, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private conProducto conProducto;
        private lblBase lblBase1;
        private lblBaseCustom lblidSolicitud;
        private BotonesBase.BtnAceptar btnAceptar;
        private BotonesBase.btnSalir btnSalir;
    }
}