namespace GEN.ControlesBase
{
    partial class frmBusUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBusUsuario));
            this.lblCriterioBusqueda = new System.Windows.Forms.Label();
            this.lblDescripcionBusqueda = new System.Windows.Forms.Label();
            this.txtDniNom = new System.Windows.Forms.TextBox();
            this.btnBusqueda = new GEN.BotonesBase.btnBusqueda();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.cboCriBusCli = new GEN.ControlesBase.cboCriBusCli(this.components);
            this.dtgUsuario = new GEN.ControlesBase.dtgBase(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgUsuario)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCriterioBusqueda
            // 
            this.lblCriterioBusqueda.AutoSize = true;
            this.lblCriterioBusqueda.Location = new System.Drawing.Point(11, 45);
            this.lblCriterioBusqueda.Name = "lblCriterioBusqueda";
            this.lblCriterioBusqueda.Size = new System.Drawing.Size(29, 13);
            this.lblCriterioBusqueda.TabIndex = 15;
            this.lblCriterioBusqueda.Text = "DNI:";
            // 
            // lblDescripcionBusqueda
            // 
            this.lblDescripcionBusqueda.AutoSize = true;
            this.lblDescripcionBusqueda.Location = new System.Drawing.Point(11, 17);
            this.lblDescripcionBusqueda.Name = "lblDescripcionBusqueda";
            this.lblDescripcionBusqueda.Size = new System.Drawing.Size(108, 13);
            this.lblDescripcionBusqueda.TabIndex = 14;
            this.lblDescripcionBusqueda.Text = "Criterio de Búsqueda:";
            // 
            // txtDniNom
            // 
            this.txtDniNom.Location = new System.Drawing.Point(152, 42);
            this.txtDniNom.Name = "txtDniNom";
            this.txtDniNom.Size = new System.Drawing.Size(276, 20);
            this.txtDniNom.TabIndex = 13;
            this.txtDniNom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDniNom_KeyPress);
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda.BackgroundImage")));
            this.btnBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda.Location = new System.Drawing.Point(452, 12);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda.TabIndex = 10;
            this.btnBusqueda.Text = "&Buscar";
            this.btnBusqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(452, 259);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(392, 259);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // cboCriBusCli
            // 
            this.cboCriBusCli.FormattingEnabled = true;
            this.cboCriBusCli.Location = new System.Drawing.Point(152, 15);
            this.cboCriBusCli.Name = "cboCriBusCli";
            this.cboCriBusCli.Size = new System.Drawing.Size(276, 21);
            this.cboCriBusCli.TabIndex = 16;
            this.cboCriBusCli.SelectedIndexChanged += new System.EventHandler(this.cboCriBusCli_SelectedIndexChanged);
            // 
            // dtgUsuario
            // 
            this.dtgUsuario.AllowUserToAddRows = false;
            this.dtgUsuario.AllowUserToDeleteRows = false;
            this.dtgUsuario.AllowUserToResizeColumns = false;
            this.dtgUsuario.AllowUserToResizeRows = false;
            this.dtgUsuario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgUsuario.Location = new System.Drawing.Point(14, 73);
            this.dtgUsuario.MultiSelect = false;
            this.dtgUsuario.Name = "dtgUsuario";
            this.dtgUsuario.ReadOnly = true;
            this.dtgUsuario.RowHeadersVisible = false;
            this.dtgUsuario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgUsuario.Size = new System.Drawing.Size(498, 176);
            this.dtgUsuario.TabIndex = 17;
            this.dtgUsuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgUsuario_KeyDown);
            // 
            // frmBusUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 340);
            this.Controls.Add(this.dtgUsuario);
            this.Controls.Add(this.cboCriBusCli);
            this.Controls.Add(this.lblCriterioBusqueda);
            this.Controls.Add(this.lblDescripcionBusqueda);
            this.Controls.Add(this.txtDniNom);
            this.Controls.Add(this.btnBusqueda);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAceptar);
            this.Name = "frmBusUsuario";
            this.Text = "Buscar Usuario";
            this.Load += new System.EventHandler(this.frmBusUsuario_Load);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnBusqueda, 0);
            this.Controls.SetChildIndex(this.txtDniNom, 0);
            this.Controls.SetChildIndex(this.lblDescripcionBusqueda, 0);
            this.Controls.SetChildIndex(this.lblCriterioBusqueda, 0);
            this.Controls.SetChildIndex(this.cboCriBusCli, 0);
            this.Controls.SetChildIndex(this.dtgUsuario, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgUsuario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCriterioBusqueda;
        private System.Windows.Forms.Label lblDescripcionBusqueda;
        private System.Windows.Forms.TextBox txtDniNom;
        private BotonesBase.btnBusqueda btnBusqueda;
        private BotonesBase.btnSalir btnSalir;
        private BotonesBase.BtnAceptar btnAceptar;
        private cboCriBusCli cboCriBusCli;
        private dtgBase dtgUsuario;
    }
}