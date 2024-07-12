namespace GEN.ControlesBase
{
    partial class frmAnulaSolAprobacionOpinion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAnulaSolAprobacionOpinion));
            this.lblDetalle = new GEN.ControlesBase.lblBase();
            this.grbDetalle = new GEN.ControlesBase.grbBase(this.components);
            this.txtOpinionAprobador = new GEN.ControlesBase.txtBase(this.components);
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.grbDetalle.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDetalle
            // 
            this.lblDetalle.AutoSize = true;
            this.lblDetalle.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblDetalle.ForeColor = System.Drawing.Color.Navy;
            this.lblDetalle.Location = new System.Drawing.Point(6, 75);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(52, 13);
            this.lblDetalle.TabIndex = 2;
            this.lblDetalle.Text = "Detalle:";
            // 
            // grbDetalle
            // 
            this.grbDetalle.Controls.Add(this.lblDetalle);
            this.grbDetalle.Controls.Add(this.txtOpinionAprobador);
            this.grbDetalle.Location = new System.Drawing.Point(3, 3);
            this.grbDetalle.Name = "grbDetalle";
            this.grbDetalle.Size = new System.Drawing.Size(420, 149);
            this.grbDetalle.TabIndex = 3;
            this.grbDetalle.TabStop = false;
            this.grbDetalle.Text = "Detalle Anulación Solicitud";
            // 
            // txtOpinionAprobador
            // 
            this.txtOpinionAprobador.Location = new System.Drawing.Point(65, 19);
            this.txtOpinionAprobador.MaxLength = 500;
            this.txtOpinionAprobador.Multiline = true;
            this.txtOpinionAprobador.Name = "txtOpinionAprobador";
            this.txtOpinionAprobador.Size = new System.Drawing.Size(349, 124);
            this.txtOpinionAprobador.TabIndex = 4;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(297, 158);
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
            this.btnSalir.Location = new System.Drawing.Point(363, 158);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmAnulaSolAprobacionOpinion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 236);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.grbDetalle);
            this.Name = "frmAnulaSolAprobacionOpinion";
            this.Text = "Detalle de Anulación de Solicitud de Aprobacion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAnulaSolAprobacionOpinion_FormClosing);
            this.Controls.SetChildIndex(this.grbDetalle, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.grbDetalle.ResumeLayout(false);
            this.grbDetalle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private lblBase lblDetalle;
        private grbBase grbDetalle;
        private txtBase txtOpinionAprobador;
        private BotonesBase.BtnAceptar btnAceptar;
        private BotonesBase.btnSalir btnSalir;
    }
}