namespace CRE.Presentacion
{
    partial class frmVincularPagare
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVincularPagare));
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.txtPagare = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnMiniQuitar = new GEN.BotonesBase.btnMiniQuitar();
            this.btnMiniAnular = new GEN.BotonesBase.btnMiniCancelEst();
            this.SuspendLayout();
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(89, 82);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 3;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(166, 82);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 2;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // txtPagare
            // 
            this.txtPagare.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPagare.FormatoDecimal = false;
            this.txtPagare.Location = new System.Drawing.Point(141, 39);
            this.txtPagare.MaxLength = 10;
            this.txtPagare.Name = "txtPagare";
            this.txtPagare.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPagare.nNumDecimales = 0;
            this.txtPagare.nvalor = 0D;
            this.txtPagare.Size = new System.Drawing.Size(128, 23);
            this.txtPagare.TabIndex = 4;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 42);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(119, 13);
            this.lblBase1.TabIndex = 5;
            this.lblBase1.Text = "Número de Pagaré:";
            // 
            // btnMiniQuitar
            // 
            this.btnMiniQuitar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniQuitar.BackgroundImage")));
            this.btnMiniQuitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniQuitar.Location = new System.Drawing.Point(271, 36);
            this.btnMiniQuitar.Name = "btnMiniQuitar";
            this.btnMiniQuitar.Size = new System.Drawing.Size(36, 28);
            this.btnMiniQuitar.TabIndex = 6;
            this.btnMiniQuitar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniQuitar.UseVisualStyleBackColor = true;
            this.btnMiniQuitar.Click += new System.EventHandler(this.btnMiniQuitar_Click);
            // 
            // btnMiniAnular
            // 
            this.btnMiniAnular.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniAnular.BackgroundImage")));
            this.btnMiniAnular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniAnular.Location = new System.Drawing.Point(307, 36);
            this.btnMiniAnular.Name = "btnMiniAnular";
            this.btnMiniAnular.Size = new System.Drawing.Size(36, 28);
            this.btnMiniAnular.TabIndex = 8;
            this.btnMiniAnular.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniAnular.UseVisualStyleBackColor = true;
            this.btnMiniAnular.Click += new System.EventHandler(this.btnMiniAnular_Click);
            // 
            // frmVincularPagare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 176);
            this.Controls.Add(this.btnMiniAnular);
            this.Controls.Add(this.btnMiniQuitar);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.txtPagare);
            this.Controls.Add(this.btnAceptar1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmVincularPagare";
            this.Text = "Vincular Pagaré con Crédito";
            this.Load += new System.EventHandler(this.frmBase_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            this.Controls.SetChildIndex(this.txtPagare, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.btnMiniQuitar, 0);
            this.Controls.SetChildIndex(this.btnMiniAnular, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.BtnAceptar btnAceptar1;
        private GEN.ControlesBase.txtNumRea txtPagare;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnMiniQuitar btnMiniQuitar;
        private GEN.BotonesBase.btnMiniCancelEst btnMiniAnular;
    }
}

