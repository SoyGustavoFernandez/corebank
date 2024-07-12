namespace GEN.ControlesBase
{
    partial class frmBusSolAhoPen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBusSolAhoPen));
            this.dtgSolAhoPend = new GEN.ControlesBase.dtgBase(this.components);
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolAhoPend)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgSolAhoPend
            // 
            this.dtgSolAhoPend.AllowUserToAddRows = false;
            this.dtgSolAhoPend.AllowUserToDeleteRows = false;
            this.dtgSolAhoPend.AllowUserToResizeColumns = false;
            this.dtgSolAhoPend.AllowUserToResizeRows = false;
            this.dtgSolAhoPend.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgSolAhoPend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSolAhoPend.Location = new System.Drawing.Point(8, 12);
            this.dtgSolAhoPend.MultiSelect = false;
            this.dtgSolAhoPend.Name = "dtgSolAhoPend";
            this.dtgSolAhoPend.ReadOnly = true;
            this.dtgSolAhoPend.RowHeadersVisible = false;
            this.dtgSolAhoPend.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSolAhoPend.Size = new System.Drawing.Size(583, 216);
            this.dtgSolAhoPend.TabIndex = 2;
            this.dtgSolAhoPend.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgSolAhoPend_CellDoubleClick);
            this.dtgSolAhoPend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgSolAhoPend_KeyDown);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(461, 234);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(527, 234);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // frmBusSolAhoPen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 312);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dtgSolAhoPend);
            this.Name = "frmBusSolAhoPen";
            this.Text = "Solicitudes de Apertura de Cuentas de Ahorro";
            this.Load += new System.EventHandler(this.frmBusSolAhoPen_Load);
            this.Controls.SetChildIndex(this.dtgSolAhoPend, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolAhoPend)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private dtgBase dtgSolAhoPend;
        private BotonesBase.BtnAceptar btnAceptar;
        private BotonesBase.btnSalir btnSalir;
    }
}