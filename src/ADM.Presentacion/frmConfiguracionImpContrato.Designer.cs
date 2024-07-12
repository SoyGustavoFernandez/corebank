namespace ADM.Presentacion
{
    partial class frmConfiguracionImpContrato
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfiguracionImpContrato));
            this.dtgVariables = new GEN.ControlesBase.dtgBase(this.components);
            this.grbVariables = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtValor = new GEN.ControlesBase.txtBase(this.components);
            this.txtLabel = new GEN.ControlesBase.txtBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grbFirma = new GEN.ControlesBase.grbBase(this.components);
            this.btnCargarFile1 = new GEN.BotonesBase.btnCargarFile();
            this.btnGenerar1 = new GEN.BotonesBase.btnGenerar();
            ((System.ComponentModel.ISupportInitialize)(this.dtgVariables)).BeginInit();
            this.grbVariables.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grbFirma.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgVariables
            // 
            this.dtgVariables.AllowUserToAddRows = false;
            this.dtgVariables.AllowUserToDeleteRows = false;
            this.dtgVariables.AllowUserToResizeColumns = false;
            this.dtgVariables.AllowUserToResizeRows = false;
            this.dtgVariables.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgVariables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgVariables.Location = new System.Drawing.Point(12, 6);
            this.dtgVariables.MultiSelect = false;
            this.dtgVariables.Name = "dtgVariables";
            this.dtgVariables.ReadOnly = true;
            this.dtgVariables.RowHeadersVisible = false;
            this.dtgVariables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgVariables.Size = new System.Drawing.Size(306, 146);
            this.dtgVariables.TabIndex = 0;
            this.dtgVariables.SelectionChanged += new System.EventHandler(this.dtgVariables_SelectionChanged);
            // 
            // grbVariables
            // 
            this.grbVariables.Controls.Add(this.lblBase1);
            this.grbVariables.Controls.Add(this.txtValor);
            this.grbVariables.Controls.Add(this.txtLabel);
            this.grbVariables.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbVariables.Location = new System.Drawing.Point(324, 6);
            this.grbVariables.Name = "grbVariables";
            this.grbVariables.Size = new System.Drawing.Size(294, 90);
            this.grbVariables.TabIndex = 3;
            this.grbVariables.TabStop = false;
            this.grbVariables.Text = "Acciones:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 49);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(123, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Valor de la Variable:";
            // 
            // txtValor
            // 
            this.txtValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValor.Location = new System.Drawing.Point(135, 46);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(59, 20);
            this.txtValor.TabIndex = 1;
            // 
            // txtLabel
            // 
            this.txtLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLabel.Location = new System.Drawing.Point(7, 20);
            this.txtLabel.Name = "txtLabel";
            this.txtLabel.Size = new System.Drawing.Size(187, 20);
            this.txtLabel.TabIndex = 0;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(550, 102);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 4;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(484, 102);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 5;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(418, 102);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 6;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pictureBox1.Location = new System.Drawing.Point(6, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(280, 70);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // grbFirma
            // 
            this.grbFirma.Controls.Add(this.pictureBox1);
            this.grbFirma.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbFirma.Location = new System.Drawing.Point(324, 2);
            this.grbFirma.Name = "grbFirma";
            this.grbFirma.Size = new System.Drawing.Size(294, 90);
            this.grbFirma.TabIndex = 7;
            this.grbFirma.TabStop = false;
            this.grbFirma.Text = "Firma del Representante";
            // 
            // btnCargarFile1
            // 
            this.btnCargarFile1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCargarFile1.BackgroundImage")));
            this.btnCargarFile1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCargarFile1.Location = new System.Drawing.Point(418, 102);
            this.btnCargarFile1.Name = "btnCargarFile1";
            this.btnCargarFile1.Size = new System.Drawing.Size(60, 50);
            this.btnCargarFile1.TabIndex = 12;
            this.btnCargarFile1.Text = "Abrir";
            this.btnCargarFile1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCargarFile1.UseVisualStyleBackColor = true;
            this.btnCargarFile1.Click += new System.EventHandler(this.btnCargarFile1_Click);
            // 
            // btnGenerar1
            // 
            this.btnGenerar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGenerar1.BackgroundImage")));
            this.btnGenerar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGenerar1.Location = new System.Drawing.Point(355, 102);
            this.btnGenerar1.Name = "btnGenerar1";
            this.btnGenerar1.Size = new System.Drawing.Size(60, 50);
            this.btnGenerar1.TabIndex = 16;
            this.btnGenerar1.Text = "Gene&rar";
            this.btnGenerar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGenerar1.UseVisualStyleBackColor = true;
            this.btnGenerar1.Click += new System.EventHandler(this.btnGenerar1_Click);
            // 
            // frmConfiguracionImpContrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 183);
            this.Controls.Add(this.btnGenerar1);
            this.Controls.Add(this.btnCargarFile1);
            this.Controls.Add(this.grbFirma);
            this.Controls.Add(this.dtgVariables);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.grbVariables);
            this.Name = "frmConfiguracionImpContrato";
            this.Text = "Configuración de Impresión de Contratos";
            this.Load += new System.EventHandler(this.frmConfiguracionImpContrato_Load);
            this.Controls.SetChildIndex(this.grbVariables, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.dtgVariables, 0);
            this.Controls.SetChildIndex(this.grbFirma, 0);
            this.Controls.SetChildIndex(this.btnCargarFile1, 0);
            this.Controls.SetChildIndex(this.btnGenerar1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgVariables)).EndInit();
            this.grbVariables.ResumeLayout(false);
            this.grbVariables.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grbFirma.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgVariables;
        private GEN.ControlesBase.grbBase grbVariables;
        private GEN.ControlesBase.txtBase txtValor;
        private GEN.ControlesBase.txtBase txtLabel;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private GEN.ControlesBase.grbBase grbFirma;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnCargarFile btnCargarFile1;
        private GEN.BotonesBase.btnGenerar btnGenerar1;
    }
}