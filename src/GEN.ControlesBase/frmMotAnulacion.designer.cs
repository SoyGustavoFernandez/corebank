namespace GEN.ControlesBase
{
    partial class frmMotAnulacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMotAnulacion));
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtMotAnul = new GEN.ControlesBase.txtBase(this.components);
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(281, 116);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 2;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            this.btnSalir1.Click += new System.EventHandler(this.btnSalir1_Click);
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(215, 116);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 3;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(9, 9);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(170, 13);
            this.lblBase1.TabIndex = 4;
            this.lblBase1.Text = "Detalle Motivo de Anulación:";
            // 
            // txtMotAnul
            // 
            this.txtMotAnul.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMotAnul.Location = new System.Drawing.Point(12, 27);
            this.txtMotAnul.MaxLength = 200;
            this.txtMotAnul.Multiline = true;
            this.txtMotAnul.Name = "txtMotAnul";
            this.txtMotAnul.Size = new System.Drawing.Size(329, 83);
            this.txtMotAnul.TabIndex = 12;
            // 
            // frmMotAnulacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 198);
            this.Controls.Add(this.txtMotAnul);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.btnAceptar1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmMotAnulacion";
            this.Text = "Motivo de Anulación";
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.txtMotAnul, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BotonesBase.btnSalir btnSalir1;
        private BotonesBase.BtnAceptar btnAceptar1;
        private lblBase lblBase1;
        private txtBase txtMotAnul;
    }
}