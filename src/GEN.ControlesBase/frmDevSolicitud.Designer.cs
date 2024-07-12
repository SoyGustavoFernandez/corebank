namespace GEN.ControlesBase
{
    partial class frmDevSolicitud
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDevSolicitud));
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.cboMotivoDevolucion = new System.Windows.Forms.ComboBox();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.SuspendLayout();
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(510, 166);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 9;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(449, 166);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 8;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // txtComentario
            // 
            this.txtComentario.Location = new System.Drawing.Point(12, 60);
            this.txtComentario.MaxLength = 1000;
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(558, 100);
            this.txtComentario.TabIndex = 7;
            // 
            // cboMotivoDevolucion
            // 
            this.cboMotivoDevolucion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMotivoDevolucion.FormattingEnabled = true;
            this.cboMotivoDevolucion.Location = new System.Drawing.Point(12, 30);
            this.cboMotivoDevolucion.Name = "cboMotivoDevolucion";
            this.cboMotivoDevolucion.Size = new System.Drawing.Size(558, 21);
            this.cboMotivoDevolucion.TabIndex = 5;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(13, 10);
            this.lblBase5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(140, 13);
            this.lblBase5.TabIndex = 10;
            this.lblBase5.Text = "Motivos de Devolución:";
            // 
            // frmDevSolicitud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnAceptar1);
            this.Controls.Add(this.txtComentario);
            this.Controls.Add(this.cboMotivoDevolucion);
            this.MaximumSize = new System.Drawing.Size(600, 300);
            this.MinimumSize = new System.Drawing.Size(600, 300);
            this.Name = "frmDevSolicitud";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Motivos de Devolución";
            this.Load += new System.EventHandler(this.frmDevSolicitud_Load);
            this.Controls.SetChildIndex(this.cboMotivoDevolucion, 0);
            this.Controls.SetChildIndex(this.txtComentario, 0);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BotonesBase.btnCancelar btnCancelar1;
        private BotonesBase.BtnAceptar btnAceptar1;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.ComboBox cboMotivoDevolucion;
        private lblBase lblBase5;
    }
}