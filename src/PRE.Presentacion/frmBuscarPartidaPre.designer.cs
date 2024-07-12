namespace PRE.Presentacion
{
    partial class frmBuscarPartidaPre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarPartidaPre));
            this.dtgPartidasPresupuestales = new GEN.ControlesBase.dtgBase(this.components);
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPartidasPresupuestales)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgPartidasPresupuestales
            // 
            this.dtgPartidasPresupuestales.AllowUserToAddRows = false;
            this.dtgPartidasPresupuestales.AllowUserToDeleteRows = false;
            this.dtgPartidasPresupuestales.AllowUserToResizeColumns = false;
            this.dtgPartidasPresupuestales.AllowUserToResizeRows = false;
            this.dtgPartidasPresupuestales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgPartidasPresupuestales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPartidasPresupuestales.Location = new System.Drawing.Point(12, 12);
            this.dtgPartidasPresupuestales.MultiSelect = false;
            this.dtgPartidasPresupuestales.Name = "dtgPartidasPresupuestales";
            this.dtgPartidasPresupuestales.ReadOnly = true;
            this.dtgPartidasPresupuestales.RowHeadersVisible = false;
            this.dtgPartidasPresupuestales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPartidasPresupuestales.Size = new System.Drawing.Size(344, 298);
            this.dtgPartidasPresupuestales.TabIndex = 0;
            this.dtgPartidasPresupuestales.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPartidasPresupuestales_CellEnter);
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackColor = System.Drawing.SystemColors.Control;
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(230, 316);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 1;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = false;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(296, 316);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 2;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = false;
            // 
            // frmBuscarPartidaPre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 399);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnAceptar1);
            this.Controls.Add(this.dtgPartidasPresupuestales);
            this.Name = "frmBuscarPartidaPre";
            this.Text = "Buscar partida presupuestal";
            this.Load += new System.EventHandler(this.frmBuscarPartidaPre_Load);
            this.Controls.SetChildIndex(this.dtgPartidasPresupuestales, 0);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPartidasPresupuestales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgPartidasPresupuestales;
        private GEN.BotonesBase.BtnAceptar btnAceptar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
    }
}