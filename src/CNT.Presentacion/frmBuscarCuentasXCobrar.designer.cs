namespace CNT.Presentacion
{
    partial class frmBuscarCuentasXCobrar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarCuentasXCobrar));
            this.dtgCuentasCobrar = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCuentasCobrar)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgCuentasCobrar
            // 
            this.dtgCuentasCobrar.AllowUserToAddRows = false;
            this.dtgCuentasCobrar.AllowUserToDeleteRows = false;
            this.dtgCuentasCobrar.AllowUserToResizeColumns = false;
            this.dtgCuentasCobrar.AllowUserToResizeRows = false;
            this.dtgCuentasCobrar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCuentasCobrar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCuentasCobrar.Location = new System.Drawing.Point(5, 6);
            this.dtgCuentasCobrar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtgCuentasCobrar.MultiSelect = false;
            this.dtgCuentasCobrar.Name = "dtgCuentasCobrar";
            this.dtgCuentasCobrar.ReadOnly = true;
            this.dtgCuentasCobrar.RowHeadersVisible = false;
            this.dtgCuentasCobrar.RowTemplate.Height = 24;
            this.dtgCuentasCobrar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCuentasCobrar.Size = new System.Drawing.Size(590, 202);
            this.dtgCuentasCobrar.TabIndex = 0;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(540, 212);
            this.btnSalir1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 1;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(476, 212);
            this.btnAceptar1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 2;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // frmBuscarCuentasXCobrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 293);
            this.Controls.Add(this.btnAceptar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.dtgCuentasCobrar);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmBuscarCuentasXCobrar";
            this.Text = "Lista de cuentas por cobrar";
            this.Controls.SetChildIndex(this.dtgCuentasCobrar, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCuentasCobrar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgCuentasCobrar;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.BtnAceptar btnAceptar1;
    }
}