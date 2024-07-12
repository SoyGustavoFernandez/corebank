namespace CRE.Presentacion
{
    partial class frmBuscarInfRiegos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarInfRiegos));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtgInformeRiesgo = new GEN.ControlesBase.dtgBase(this.components);
            this.dtpFechaIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFechafin = new GEN.ControlesBase.dtpCorto(this.components);
            this.btnBusqueda1 = new GEN.BotonesBase.btnBusqueda();
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.lblCodigo = new GEN.ControlesBase.lblBase();
            this.lblNombre = new GEN.ControlesBase.lblBase();
            this.txtNombre = new GEN.ControlesBase.txtBase(this.components);
            this.btnBusqueda2 = new GEN.BotonesBase.btnBusqueda();
            this.txtCodigo = new GEN.ControlesBase.txtNumRea(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgInformeRiesgo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 17);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(98, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Fecha de Inicio:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(12, 44);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(75, 13);
            this.lblBase2.TabIndex = 2;
            this.lblBase2.Text = "Fecha Final:";
            // 
            // dtgInformeRiesgo
            // 
            this.dtgInformeRiesgo.AllowUserToAddRows = false;
            this.dtgInformeRiesgo.AllowUserToDeleteRows = false;
            this.dtgInformeRiesgo.AllowUserToResizeColumns = false;
            this.dtgInformeRiesgo.AllowUserToResizeRows = false;
            this.dtgInformeRiesgo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgInformeRiesgo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgInformeRiesgo.Location = new System.Drawing.Point(15, 75);
            this.dtgInformeRiesgo.MultiSelect = false;
            this.dtgInformeRiesgo.Name = "dtgInformeRiesgo";
            this.dtgInformeRiesgo.ReadOnly = true;
            this.dtgInformeRiesgo.RowHeadersVisible = false;
            this.dtgInformeRiesgo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgInformeRiesgo.Size = new System.Drawing.Size(1191, 448);
            this.dtgInformeRiesgo.TabIndex = 10;
            this.dtgInformeRiesgo.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgInformeRiesgo_CellContentDoubleClick);
            // 
            // dtpFechaIni
            // 
            this.dtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaIni.Location = new System.Drawing.Point(116, 14);
            this.dtpFechaIni.Name = "dtpFechaIni";
            this.dtpFechaIni.Size = new System.Drawing.Size(111, 20);
            this.dtpFechaIni.TabIndex = 1;
            // 
            // dtpFechafin
            // 
            this.dtpFechafin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechafin.Location = new System.Drawing.Point(116, 42);
            this.dtpFechafin.Name = "dtpFechafin";
            this.dtpFechafin.Size = new System.Drawing.Size(111, 20);
            this.dtpFechafin.TabIndex = 3;
            // 
            // btnBusqueda1
            // 
            this.btnBusqueda1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda1.BackgroundImage")));
            this.btnBusqueda1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda1.Location = new System.Drawing.Point(233, 14);
            this.btnBusqueda1.Name = "btnBusqueda1";
            this.btnBusqueda1.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda1.TabIndex = 4;
            this.btnBusqueda1.Text = "&Buscar";
            this.btnBusqueda1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda1.UseVisualStyleBackColor = true;
            this.btnBusqueda1.Click += new System.EventHandler(this.btnBusqueda1_Click);
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(1080, 529);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 11;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(1146, 529);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 12;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblCodigo.ForeColor = System.Drawing.Color.Navy;
            this.lblCodigo.Location = new System.Drawing.Point(725, 16);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(93, 13);
            this.lblCodigo.TabIndex = 5;
            this.lblCodigo.Text = "Código cliente:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblNombre.ForeColor = System.Drawing.Color.Navy;
            this.lblNombre.Location = new System.Drawing.Point(761, 46);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(57, 13);
            this.lblNombre.TabIndex = 7;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(824, 41);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(316, 20);
            this.txtNombre.TabIndex = 8;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // btnBusqueda2
            // 
            this.btnBusqueda2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda2.BackgroundImage")));
            this.btnBusqueda2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda2.Location = new System.Drawing.Point(1146, 14);
            this.btnBusqueda2.Name = "btnBusqueda2";
            this.btnBusqueda2.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda2.TabIndex = 9;
            this.btnBusqueda2.Text = "&Buscar";
            this.btnBusqueda2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda2.UseVisualStyleBackColor = true;
            this.btnBusqueda2.Click += new System.EventHandler(this.btnBusqueda2_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.FormatoDecimal = false;
            this.txtCodigo.Location = new System.Drawing.Point(825, 12);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCodigo.nNumDecimales = 4;
            this.txtCodigo.nvalor = 0D;
            this.txtCodigo.Size = new System.Drawing.Size(95, 20);
            this.txtCodigo.TabIndex = 6;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // frmBuscarInfRiegos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 614);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.btnBusqueda2);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnAceptar1);
            this.Controls.Add(this.btnBusqueda1);
            this.Controls.Add(this.dtpFechafin);
            this.Controls.Add(this.dtpFechaIni);
            this.Controls.Add(this.dtgInformeRiesgo);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Name = "frmBuscarInfRiegos";
            this.Text = "Buscar Informe de Riesgos";
            this.Load += new System.EventHandler(this.frmBuscarInfRiegos_Load);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.dtgInformeRiesgo, 0);
            this.Controls.SetChildIndex(this.dtpFechaIni, 0);
            this.Controls.SetChildIndex(this.dtpFechafin, 0);
            this.Controls.SetChildIndex(this.btnBusqueda1, 0);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.lblCodigo, 0);
            this.Controls.SetChildIndex(this.lblNombre, 0);
            this.Controls.SetChildIndex(this.txtNombre, 0);
            this.Controls.SetChildIndex(this.btnBusqueda2, 0);
            this.Controls.SetChildIndex(this.txtCodigo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgInformeRiesgo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.dtgBase dtgInformeRiesgo;
        private GEN.ControlesBase.dtpCorto dtpFechaIni;
        private GEN.ControlesBase.dtpCorto dtpFechafin;
        private GEN.BotonesBase.btnBusqueda btnBusqueda1;
        private GEN.BotonesBase.BtnAceptar btnAceptar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.lblBase lblCodigo;
        private GEN.ControlesBase.lblBase lblNombre;
        private GEN.ControlesBase.txtBase txtNombre;
        private GEN.BotonesBase.btnBusqueda btnBusqueda2;
        private GEN.ControlesBase.txtNumRea txtCodigo;

    }
}