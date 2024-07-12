namespace DEP.Presentacion
{
    partial class frmSolAprobReimpresion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSolAprobReimpresion));
            this.dtgSolAprobados = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolAprobados)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgSolAprobados
            // 
            this.dtgSolAprobados.AllowUserToAddRows = false;
            this.dtgSolAprobados.AllowUserToDeleteRows = false;
            this.dtgSolAprobados.AllowUserToResizeColumns = false;
            this.dtgSolAprobados.AllowUserToResizeRows = false;
            this.dtgSolAprobados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgSolAprobados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSolAprobados.Location = new System.Drawing.Point(7, 10);
            this.dtgSolAprobados.MultiSelect = false;
            this.dtgSolAprobados.Name = "dtgSolAprobados";
            this.dtgSolAprobados.ReadOnly = true;
            this.dtgSolAprobados.RowHeadersVisible = false;
            this.dtgSolAprobados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSolAprobados.Size = new System.Drawing.Size(781, 178);
            this.dtgSolAprobados.TabIndex = 2;
            this.dtgSolAprobados.DoubleClick += new System.EventHandler(this.dtgSolAprobados_DoubleClick);
            this.dtgSolAprobados.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgSolAprobados_KeyDown);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(728, 193);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 112;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Enabled = false;
            this.btnAceptar.Location = new System.Drawing.Point(662, 193);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 111;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmSolAprobReimpresion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 269);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dtgSolAprobados);
            this.Name = "frmSolAprobReimpresion";
            this.Text = "Solicitudes Aprobadas para Reimpresión de Documentos";
            this.Load += new System.EventHandler(this.frmSolAprobTitular_Load);
            this.Controls.SetChildIndex(this.dtgSolAprobados, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolAprobados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgSolAprobados;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
    }
}