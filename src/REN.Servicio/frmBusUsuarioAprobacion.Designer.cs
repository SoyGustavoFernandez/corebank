namespace CLI.Servicio
{
    partial class frmBusUsuarioAprobacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBusUsuarioAprobacion));
            this.dtgColaborador = new System.Windows.Forms.DataGridView();
            this.cboCriBusCol = new System.Windows.Forms.ComboBox();
            this.txtDniNom = new System.Windows.Forms.TextBox();
            this.lblDescripcionBusqueda = new System.Windows.Forms.Label();
            this.lblCriterioBusqueda = new System.Windows.Forms.Label();
            this.btnBusqueda = new GEN.BotonesBase.btnBusqueda();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            ((System.ComponentModel.ISupportInitialize)(this.dtgColaborador)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgColaborador
            // 
            this.dtgColaborador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgColaborador.Location = new System.Drawing.Point(8, 75);
            this.dtgColaborador.Name = "dtgColaborador";
            this.dtgColaborador.Size = new System.Drawing.Size(504, 176);
            this.dtgColaborador.TabIndex = 3;
            this.dtgColaborador.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgColaborador_KeyDown);
            // 
            // cboCriBusCol
            // 
            this.cboCriBusCol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCriBusCol.FormattingEnabled = true;
            this.cboCriBusCol.Location = new System.Drawing.Point(152, 12);
            this.cboCriBusCol.Name = "cboCriBusCol";
            this.cboCriBusCol.Size = new System.Drawing.Size(276, 21);
            this.cboCriBusCol.TabIndex = 4;
            this.cboCriBusCol.SelectedIndexChanged += new System.EventHandler(this.cboCriBusCol_SelectedIndexChanged);
            // 
            // txtDniNom
            // 
            this.txtDniNom.Location = new System.Drawing.Point(152, 40);
            this.txtDniNom.Name = "txtDniNom";
            this.txtDniNom.Size = new System.Drawing.Size(276, 20);
            this.txtDniNom.TabIndex = 5;
            this.txtDniNom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDniNom_KeyPress);
            // 
            // lblDescripcionBusqueda
            // 
            this.lblDescripcionBusqueda.AutoSize = true;
            this.lblDescripcionBusqueda.Location = new System.Drawing.Point(11, 15);
            this.lblDescripcionBusqueda.Name = "lblDescripcionBusqueda";
            this.lblDescripcionBusqueda.Size = new System.Drawing.Size(108, 13);
            this.lblDescripcionBusqueda.TabIndex = 6;
            this.lblDescripcionBusqueda.Text = "Criterio de Búsqueda:";
            // 
            // lblCriterioBusqueda
            // 
            this.lblCriterioBusqueda.AutoSize = true;
            this.lblCriterioBusqueda.Location = new System.Drawing.Point(11, 43);
            this.lblCriterioBusqueda.Name = "lblCriterioBusqueda";
            this.lblCriterioBusqueda.Size = new System.Drawing.Size(29, 13);
            this.lblCriterioBusqueda.TabIndex = 7;
            this.lblCriterioBusqueda.Text = "DNI:";
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda.BackgroundImage")));
            this.btnBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda.Location = new System.Drawing.Point(452, 10);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda.TabIndex = 2;
            this.btnBusqueda.Text = "&Buscar";
            this.btnBusqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(452, 257);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(392, 257);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmBusUsuarioAprobacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 338);
            this.Controls.Add(this.lblCriterioBusqueda);
            this.Controls.Add(this.lblDescripcionBusqueda);
            this.Controls.Add(this.txtDniNom);
            this.Controls.Add(this.cboCriBusCol);
            this.Controls.Add(this.dtgColaborador);
            this.Controls.Add(this.btnBusqueda);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAceptar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBusUsuarioAprobacion";
            this.Text = "Busqueda de personal para Aprobación Excepción Biométrico";
            this.Load += new System.EventHandler(this.frmBusUsuarioAprobacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgColaborador)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnBusqueda btnBusqueda;
        private System.Windows.Forms.DataGridView dtgColaborador;
        private System.Windows.Forms.ComboBox cboCriBusCol;
        private System.Windows.Forms.TextBox txtDniNom;
        private System.Windows.Forms.Label lblDescripcionBusqueda;
        private System.Windows.Forms.Label lblCriterioBusqueda;
    }
}