namespace SPL.Presentacion
{
    partial class frmListaOfaq
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaOfaq));
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnCargarSdn = new GEN.BotonesBase.btnCargarFile();
            this.btnAddOfaq = new GEN.BotonesBase.btnCargarFile();
            this.txtSdnOfaq = new GEN.ControlesBase.txtBase(this.components);
            this.txtAddOfaq = new GEN.ControlesBase.txtBase(this.components);
            this.btnProcesar1 = new GEN.BotonesBase.btnProcesar();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(257, 163);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 2;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(125, 163);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 5;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            // 
            // btnCargarSdn
            // 
            this.btnCargarSdn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCargarSdn.BackgroundImage")));
            this.btnCargarSdn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCargarSdn.Location = new System.Drawing.Point(325, 17);
            this.btnCargarSdn.Name = "btnCargarSdn";
            this.btnCargarSdn.Size = new System.Drawing.Size(60, 50);
            this.btnCargarSdn.TabIndex = 6;
            this.btnCargarSdn.Text = "sdn Ofaq";
            this.btnCargarSdn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCargarSdn.UseVisualStyleBackColor = true;
            this.btnCargarSdn.Click += new System.EventHandler(this.btnCargarSdn_Click);
            // 
            // btnAddOfaq
            // 
            this.btnAddOfaq.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddOfaq.BackgroundImage")));
            this.btnAddOfaq.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddOfaq.Location = new System.Drawing.Point(325, 74);
            this.btnAddOfaq.Name = "btnAddOfaq";
            this.btnAddOfaq.Size = new System.Drawing.Size(60, 50);
            this.btnAddOfaq.TabIndex = 6;
            this.btnAddOfaq.Text = "add Ofaq";
            this.btnAddOfaq.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddOfaq.UseVisualStyleBackColor = true;
            this.btnAddOfaq.Click += new System.EventHandler(this.btnAddOfaq_Click);
            // 
            // txtSdnOfaq
            // 
            this.txtSdnOfaq.Enabled = false;
            this.txtSdnOfaq.Location = new System.Drawing.Point(6, 30);
            this.txtSdnOfaq.Name = "txtSdnOfaq";
            this.txtSdnOfaq.Size = new System.Drawing.Size(299, 20);
            this.txtSdnOfaq.TabIndex = 7;
            // 
            // txtAddOfaq
            // 
            this.txtAddOfaq.Enabled = false;
            this.txtAddOfaq.Location = new System.Drawing.Point(6, 91);
            this.txtAddOfaq.Name = "txtAddOfaq";
            this.txtAddOfaq.Size = new System.Drawing.Size(299, 20);
            this.txtAddOfaq.TabIndex = 7;
            // 
            // btnProcesar1
            // 
            this.btnProcesar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar1.BackgroundImage")));
            this.btnProcesar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar1.Location = new System.Drawing.Point(191, 163);
            this.btnProcesar1.Name = "btnProcesar1";
            this.btnProcesar1.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar1.TabIndex = 8;
            this.btnProcesar1.Text = "&Procesar";
            this.btnProcesar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar1.UseVisualStyleBackColor = true;
            this.btnProcesar1.Click += new System.EventHandler(this.btnProcesar1_Click);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.txtSdnOfaq);
            this.grbBase1.Controls.Add(this.btnCargarSdn);
            this.grbBase1.Controls.Add(this.txtAddOfaq);
            this.grbBase1.Controls.Add(this.btnAddOfaq);
            this.grbBase1.Location = new System.Drawing.Point(12, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(397, 133);
            this.grbBase1.TabIndex = 9;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Carga de archivos de la lista OFAQ";
            // 
            // frmListaOfaq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 254);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnProcesar1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmListaOfaq";
            this.Text = "Administrar Lista OFAQ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnProcesar1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnCargarFile btnCargarSdn;
        private GEN.BotonesBase.btnCargarFile btnAddOfaq;
        private GEN.ControlesBase.txtBase txtSdnOfaq;
        private GEN.ControlesBase.txtBase txtAddOfaq;
        private GEN.BotonesBase.btnProcesar btnProcesar1;
        private GEN.ControlesBase.grbBase grbBase1;
    }
}

