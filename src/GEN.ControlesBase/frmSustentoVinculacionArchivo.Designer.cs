namespace GEN.ControlesBase
{
    partial class frmSustentoVinculacionArchivo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSustentoVinculacionArchivo));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.cboMotivoVinculacionArchivo = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtDescripcionVinculacionArchivo = new GEN.ControlesBase.txtBase(this.components);
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(15, 26);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(49, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Motivo:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(317, 108);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(383, 108);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cboMotivoVinculacionArchivo
            // 
            this.cboMotivoVinculacionArchivo.FormattingEnabled = true;
            this.cboMotivoVinculacionArchivo.Location = new System.Drawing.Point(173, 22);
            this.cboMotivoVinculacionArchivo.Name = "cboMotivoVinculacionArchivo";
            this.cboMotivoVinculacionArchivo.Size = new System.Drawing.Size(270, 21);
            this.cboMotivoVinculacionArchivo.TabIndex = 5;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(15, 67);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(79, 13);
            this.lblBase2.TabIndex = 6;
            this.lblBase2.Text = "Comentario:";
            // 
            // txtDescripcionVinculacionArchivo
            // 
            this.txtDescripcionVinculacionArchivo.Location = new System.Drawing.Point(173, 45);
            this.txtDescripcionVinculacionArchivo.Multiline = true;
            this.txtDescripcionVinculacionArchivo.Name = "txtDescripcionVinculacionArchivo";
            this.txtDescripcionVinculacionArchivo.Size = new System.Drawing.Size(270, 57);
            this.txtDescripcionVinculacionArchivo.TabIndex = 7;
            // 
            // frmSustentoVinculacionArchivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 191);
            this.Controls.Add(this.txtDescripcionVinculacionArchivo);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.cboMotivoVinculacionArchivo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblBase1);
            this.Name = "frmSustentoVinculacionArchivo";
            this.Text = "Registro de Sustento de Vinculación de Pagaré";
            this.Load += new System.EventHandler(this.frmSustentoVinculacionArchivo_Load);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.cboMotivoVinculacionArchivo, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.txtDescripcionVinculacionArchivo, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private lblBase lblBase1;
        private BotonesBase.BtnAceptar btnAceptar;
        private BotonesBase.btnCancelar btnCancelar;
        private cboBase cboMotivoVinculacionArchivo;
        private lblBase lblBase2;
        private txtBase txtDescripcionVinculacionArchivo;
    }
}