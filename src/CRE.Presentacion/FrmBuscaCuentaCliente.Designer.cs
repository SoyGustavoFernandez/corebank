namespace CRE.Presentacion
{
    partial class FrmBuscaCuentaCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBuscaCuentaCliente));
            this.dtgDatosCreSol = new GEN.ControlesBase.dtgBase(this.components);
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.conBusCli = new GEN.ControlesBase.ConBusCli();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatosCreSol)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgDatosCreSol
            // 
            this.dtgDatosCreSol.AllowUserToAddRows = false;
            this.dtgDatosCreSol.AllowUserToDeleteRows = false;
            this.dtgDatosCreSol.AllowUserToResizeColumns = false;
            this.dtgDatosCreSol.AllowUserToResizeRows = false;
            this.dtgDatosCreSol.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDatosCreSol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDatosCreSol.Location = new System.Drawing.Point(12, 106);
            this.dtgDatosCreSol.MultiSelect = false;
            this.dtgDatosCreSol.Name = "dtgDatosCreSol";
            this.dtgDatosCreSol.ReadOnly = true;
            this.dtgDatosCreSol.RowHeadersVisible = false;
            this.dtgDatosCreSol.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDatosCreSol.Size = new System.Drawing.Size(316, 150);
            this.dtgDatosCreSol.TabIndex = 2;
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(202, 267);
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
            this.btnSalir1.Location = new System.Drawing.Point(268, 267);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 4;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // conBusCli
            // 
            this.conBusCli.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli.idCli = 0;
            this.conBusCli.Location = new System.Drawing.Point(12, 12);
            this.conBusCli.Name = "conBusCli";
            this.conBusCli.Size = new System.Drawing.Size(316, 59);
            this.conBusCli.TabIndex = 5;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 83);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(49, 13);
            this.lblBase1.TabIndex = 6;
            this.lblBase1.Text = "Datos :";
            // 
            // FrmBuscaCuentaCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 342);
            this.Controls.Add(this.conBusCli);
            this.Controls.Add(this.dtgDatosCreSol);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.btnAceptar1);
            this.Name = "FrmBuscaCuentaCliente";
            this.Text = "Busca Cuenta del Cliente";
            this.Load += new System.EventHandler(this.FrmBuscaCuentaCliente_Load);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.dtgDatosCreSol, 0);
            this.Controls.SetChildIndex(this.conBusCli, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatosCreSol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.BtnAceptar btnAceptar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.lblBase lblBase1;
        public GEN.ControlesBase.dtgBase dtgDatosCreSol;
        public GEN.ControlesBase.ConBusCli conBusCli;



    }
}