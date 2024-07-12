namespace CLI.Presentacion
{
    partial class frmFirmas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFirmas));
            this.lstClientes = new GEN.ControlesBase.lstBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnCargarFile1 = new GEN.BotonesBase.btnCargarFile();
            this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ptbFirma = new System.Windows.Forms.PictureBox();
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnProcesar1 = new GEN.BotonesBase.btnProcesar();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.btnQuitar1 = new GEN.BotonesBase.btnQuitar();
            ((System.ComponentModel.ISupportInitialize)(this.ptbFirma)).BeginInit();
            this.SuspendLayout();
            // 
            // lstClientes
            // 
            this.lstClientes.FormattingEnabled = true;
            this.lstClientes.Location = new System.Drawing.Point(39, 29);
            this.lstClientes.Name = "lstClientes";
            this.lstClientes.Size = new System.Drawing.Size(213, 342);
            this.lstClientes.TabIndex = 2;
            this.lstClientes.SelectedIndexChanged += new System.EventHandler(this.lstClientes_SelectedIndexChanged);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(586, 321);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 3;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(454, 321);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 6;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnCargarFile1
            // 
            this.btnCargarFile1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCargarFile1.BackgroundImage")));
            this.btnCargarFile1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCargarFile1.Location = new System.Drawing.Point(258, 29);
            this.btnCargarFile1.Name = "btnCargarFile1";
            this.btnCargarFile1.Size = new System.Drawing.Size(60, 50);
            this.btnCargarFile1.TabIndex = 7;
            this.btnCargarFile1.Text = "Buscar";
            this.btnCargarFile1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCargarFile1.UseVisualStyleBackColor = true;
            this.btnCargarFile1.Click += new System.EventHandler(this.btnCargarFile1_Click);
            // 
            // cmsMenu
            // 
            this.cmsMenu.Name = "cmsMenu";
            this.cmsMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // ptbFirma
            // 
            this.ptbFirma.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ptbFirma.Location = new System.Drawing.Point(347, 145);
            this.ptbFirma.Name = "ptbFirma";
            this.ptbFirma.Size = new System.Drawing.Size(233, 98);
            this.ptbFirma.TabIndex = 9;
            this.ptbFirma.TabStop = false;
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Enabled = false;
            this.btnEditar1.Location = new System.Drawing.Point(281, 321);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 10;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(39, 10);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(159, 13);
            this.lblBase1.TabIndex = 11;
            this.lblBase1.Text = "Listado de Firmas a cargar";
            // 
            // btnProcesar1
            // 
            this.btnProcesar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar1.BackgroundImage")));
            this.btnProcesar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar1.Enabled = false;
            this.btnProcesar1.Location = new System.Drawing.Point(520, 321);
            this.btnProcesar1.Name = "btnProcesar1";
            this.btnProcesar1.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar1.TabIndex = 12;
            this.btnProcesar1.Text = "&Procesar";
            this.btnProcesar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar1.UseVisualStyleBackColor = true;
            this.btnProcesar1.Click += new System.EventHandler(this.btnProcesar1_Click);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(324, 47);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(335, 13);
            this.lblBase2.TabIndex = 11;
            this.lblBase2.Text = "Se filtraran solo imágenes con extensión: \".jpg\" y \".jpeg\"";
            // 
            // btnQuitar1
            // 
            this.btnQuitar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitar1.BackgroundImage")));
            this.btnQuitar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitar1.Enabled = false;
            this.btnQuitar1.Location = new System.Drawing.Point(348, 321);
            this.btnQuitar1.Name = "btnQuitar1";
            this.btnQuitar1.Size = new System.Drawing.Size(60, 50);
            this.btnQuitar1.TabIndex = 13;
            this.btnQuitar1.Text = "&Quitar";
            this.btnQuitar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitar1.UseVisualStyleBackColor = true;
            this.btnQuitar1.Click += new System.EventHandler(this.btnQuitar1_Click);
            // 
            // frmFirmas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 404);
            this.Controls.Add(this.btnQuitar1);
            this.Controls.Add(this.btnProcesar1);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.ptbFirma);
            this.Controls.Add(this.btnCargarFile1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.lstClientes);
            this.Name = "frmFirmas";
            this.Text = "Mantenimiento de Firmas";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.lstClientes, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnCargarFile1, 0);
            this.Controls.SetChildIndex(this.ptbFirma, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.btnProcesar1, 0);
            this.Controls.SetChildIndex(this.btnQuitar1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ptbFirma)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lstBase lstClientes;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnCargarFile btnCargarFile1;
        private System.Windows.Forms.ContextMenuStrip cmsMenu;
        private System.Windows.Forms.PictureBox ptbFirma;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnProcesar btnProcesar1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.BotonesBase.btnQuitar btnQuitar1;
    }
}

