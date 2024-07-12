namespace GEN.ControlesBase
{
    partial class frmDetalleTasaNegSimp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetalleTasaNegSimp));
            this.conRastreoTasaNegociable = new conRastreoTasaNegociable();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblSolicitud = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblSolTasaNegociable = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.SuspendLayout();
            // 
            // conRastreoTasaNegociable
            // 
            this.conRastreoTasaNegociable.idSolicitud = 0;
            this.conRastreoTasaNegociable.idTasaNegociada = 0;
            this.conRastreoTasaNegociable.idUsuario = 0;
            this.conRastreoTasaNegociable.Location = new System.Drawing.Point(-1, 30);
            this.conRastreoTasaNegociable.lstRastreoTasaNegociable = ((System.Collections.Generic.List<EntityLayer.clsRastreoTasaNegociable>)(resources.GetObject("conRastreoTasaNegociable.lstRastreoTasaNegociable")));
            this.conRastreoTasaNegociable.Name = "conRastreoTasaNegociable";
            this.conRastreoTasaNegociable.Size = new System.Drawing.Size(737, 175);
            this.conRastreoTasaNegociable.TabIndex = 2;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 9);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(124, 13);
            this.lblBase1.TabIndex = 3;
            this.lblBase1.Text = "Solicitud de Credito:";
            // 
            // lblSolicitud
            // 
            this.lblSolicitud.AutoSize = true;
            this.lblSolicitud.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSolicitud.ForeColor = System.Drawing.Color.Navy;
            this.lblSolicitud.Location = new System.Drawing.Point(131, 9);
            this.lblSolicitud.Name = "lblSolicitud";
            this.lblSolicitud.Size = new System.Drawing.Size(13, 13);
            this.lblSolicitud.TabIndex = 4;
            this.lblSolicitud.Text = "-";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(265, 9);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(156, 13);
            this.lblBase2.TabIndex = 5;
            this.lblBase2.Text = "Solicitud Tasa Negociable:";
            // 
            // lblSolTasaNegociable
            // 
            this.lblSolTasaNegociable.AutoSize = true;
            this.lblSolTasaNegociable.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSolTasaNegociable.ForeColor = System.Drawing.Color.Navy;
            this.lblSolTasaNegociable.Location = new System.Drawing.Point(427, 9);
            this.lblSolTasaNegociable.Name = "lblSolTasaNegociable";
            this.lblSolTasaNegociable.Size = new System.Drawing.Size(13, 13);
            this.lblSolTasaNegociable.TabIndex = 6;
            this.lblSolTasaNegociable.Text = "-";
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(674, 209);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 7;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // frmDetalleTasaNegociable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 284);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.lblSolTasaNegociable);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblSolicitud);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.conRastreoTasaNegociable);
            this.Name = "frmDetalleTasaNegociable";
            this.Text = "Detalle de Solicitud de Tasa Negociable";
            this.Load += new System.EventHandler(this.frmDetalleTasaNegociable_Load);
            this.Controls.SetChildIndex(this.conRastreoTasaNegociable, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblSolicitud, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblSolTasaNegociable, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.conRastreoTasaNegociable conRastreoTasaNegociable;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBaseCustom lblSolicitud;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBaseCustom lblSolTasaNegociable;
        private GEN.BotonesBase.btnSalir btnSalir1;
    }
}