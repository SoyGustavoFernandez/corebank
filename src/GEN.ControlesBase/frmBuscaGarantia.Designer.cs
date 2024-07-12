namespace GEN.ControlesBase
{
    partial class frmBuscaGarantia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscaGarantia));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cboCriBusGar = new GEN.ControlesBase.cboCriBusGar(this.components);
            this.dtgGarantias = new GEN.ControlesBase.dtgBase(this.components);
            this.txtValBusqueda = new GEN.ControlesBase.txtBase(this.components);
            this.lblCriterio = new GEN.ControlesBase.lblBase();
            this.lblValBusuqeda = new GEN.ControlesBase.lblBase();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.btnBusqueda = new GEN.BotonesBase.btnBusqueda();
            this.idCliGarantia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cGarantia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idGarantia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMonGravado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nPorcentaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMonGarantia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMonSaldoGrav = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGarantias)).BeginInit();
            this.SuspendLayout();
            // 
            // cboCriBusGar
            // 
            this.cboCriBusGar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCriBusGar.FormattingEnabled = true;
            this.cboCriBusGar.Location = new System.Drawing.Point(162, 20);
            this.cboCriBusGar.Name = "cboCriBusGar";
            this.cboCriBusGar.Size = new System.Drawing.Size(252, 21);
            this.cboCriBusGar.TabIndex = 2;
            this.cboCriBusGar.SelectedIndexChanged += new System.EventHandler(this.cboCriBusGar_SelectedIndexChanged);
            // 
            // dtgGarantias
            // 
            this.dtgGarantias.AllowUserToAddRows = false;
            this.dtgGarantias.AllowUserToDeleteRows = false;
            this.dtgGarantias.AllowUserToResizeColumns = false;
            this.dtgGarantias.AllowUserToResizeRows = false;
            this.dtgGarantias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgGarantias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgGarantias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCliGarantia,
            this.cGarantia,
            this.cNombre,
            this.idGarantia,
            this.idCli,
            this.nMonGravado,
            this.nPorcentaje,
            this.nMonGarantia,
            this.nMonSaldoGrav});
            this.dtgGarantias.Location = new System.Drawing.Point(12, 92);
            this.dtgGarantias.MultiSelect = false;
            this.dtgGarantias.Name = "dtgGarantias";
            this.dtgGarantias.ReadOnly = true;
            this.dtgGarantias.RowHeadersVisible = false;
            this.dtgGarantias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgGarantias.Size = new System.Drawing.Size(524, 169);
            this.dtgGarantias.TabIndex = 3;
            // 
            // txtValBusqueda
            // 
            this.txtValBusqueda.Location = new System.Drawing.Point(162, 46);
            this.txtValBusqueda.Name = "txtValBusqueda";
            this.txtValBusqueda.Size = new System.Drawing.Size(252, 20);
            this.txtValBusqueda.TabIndex = 0;
            this.txtValBusqueda.TextChanged += new System.EventHandler(this.txtValBusqueda_TextChanged);
            this.txtValBusqueda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValBusqueda_KeyPress);
            // 
            // lblCriterio
            // 
            this.lblCriterio.AutoSize = true;
            this.lblCriterio.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblCriterio.ForeColor = System.Drawing.Color.Navy;
            this.lblCriterio.Location = new System.Drawing.Point(12, 23);
            this.lblCriterio.Name = "lblCriterio";
            this.lblCriterio.Size = new System.Drawing.Size(65, 13);
            this.lblCriterio.TabIndex = 5;
            this.lblCriterio.Text = "CRITERIO";
            // 
            // lblValBusuqeda
            // 
            this.lblValBusuqeda.AutoSize = true;
            this.lblValBusuqeda.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblValBusuqeda.ForeColor = System.Drawing.Color.Navy;
            this.lblValBusuqeda.Location = new System.Drawing.Point(12, 49);
            this.lblValBusuqeda.Name = "lblValBusuqeda";
            this.lblValBusuqeda.Size = new System.Drawing.Size(144, 13);
            this.lblValBusuqeda.TabIndex = 6;
            this.lblValBusuqeda.Text = "APELLIDOS Y NOMBRES";
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Location = new System.Drawing.Point(476, 267);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(410, 267);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda.BackgroundImage")));
            this.btnBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda.Location = new System.Drawing.Point(476, 20);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda.TabIndex = 9;
            this.btnBusqueda.Text = "&Buscar";
            this.btnBusqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // idCliGarantia
            // 
            this.idCliGarantia.DataPropertyName = "idCliGarantia";
            this.idCliGarantia.FillWeight = 60.9137F;
            this.idCliGarantia.HeaderText = "Id";
            this.idCliGarantia.Name = "idCliGarantia";
            this.idCliGarantia.ReadOnly = true;
            this.idCliGarantia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cGarantia
            // 
            this.cGarantia.DataPropertyName = "cGarantia";
            this.cGarantia.FillWeight = 114.0989F;
            this.cGarantia.HeaderText = "Desc";
            this.cGarantia.Name = "cGarantia";
            this.cGarantia.ReadOnly = true;
            this.cGarantia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // cNombre
            // 
            this.cNombre.DataPropertyName = "cNombre";
            this.cNombre.FillWeight = 124.9874F;
            this.cNombre.HeaderText = "Nombres";
            this.cNombre.Name = "cNombre";
            this.cNombre.ReadOnly = true;
            this.cNombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // idGarantia
            // 
            this.idGarantia.DataPropertyName = "idGarantia";
            this.idGarantia.HeaderText = "idGarantia";
            this.idGarantia.Name = "idGarantia";
            this.idGarantia.ReadOnly = true;
            this.idGarantia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.idGarantia.Visible = false;
            // 
            // idCli
            // 
            this.idCli.DataPropertyName = "idCli";
            this.idCli.HeaderText = "idCli";
            this.idCli.Name = "idCli";
            this.idCli.ReadOnly = true;
            this.idCli.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.idCli.Visible = false;
            // 
            // nMonGravado
            // 
            this.nMonGravado.DataPropertyName = "nMonGravado";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.nMonGravado.DefaultCellStyle = dataGridViewCellStyle1;
            this.nMonGravado.HeaderText = "Gravado";
            this.nMonGravado.Name = "nMonGravado";
            this.nMonGravado.ReadOnly = true;
            this.nMonGravado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // nPorcentaje
            // 
            this.nPorcentaje.DataPropertyName = "nPorcentaje";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.nPorcentaje.DefaultCellStyle = dataGridViewCellStyle2;
            this.nPorcentaje.HeaderText = "Porc(%)";
            this.nPorcentaje.Name = "nPorcentaje";
            this.nPorcentaje.ReadOnly = true;
            this.nPorcentaje.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // nMonGarantia
            // 
            this.nMonGarantia.DataPropertyName = "nMonGarantia";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.nMonGarantia.DefaultCellStyle = dataGridViewCellStyle3;
            this.nMonGarantia.HeaderText = "Garantía";
            this.nMonGarantia.Name = "nMonGarantia";
            this.nMonGarantia.ReadOnly = true;
            this.nMonGarantia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // nMonSaldoGrav
            // 
            this.nMonSaldoGrav.DataPropertyName = "nMonSaldoGrav";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.nMonSaldoGrav.DefaultCellStyle = dataGridViewCellStyle4;
            this.nMonSaldoGrav.HeaderText = "Saldo";
            this.nMonSaldoGrav.Name = "nMonSaldoGrav";
            this.nMonSaldoGrav.ReadOnly = true;
            this.nMonSaldoGrav.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // frmBuscaGarantia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(551, 344);
            this.Controls.Add(this.btnBusqueda);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblValBusuqeda);
            this.Controls.Add(this.lblCriterio);
            this.Controls.Add(this.txtValBusqueda);
            this.Controls.Add(this.dtgGarantias);
            this.Controls.Add(this.cboCriBusGar);
            this.Name = "frmBuscaGarantia";
            this.Text = "Buscar Garantías";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.cboCriBusGar, 0);
            this.Controls.SetChildIndex(this.dtgGarantias, 0);
            this.Controls.SetChildIndex(this.txtValBusqueda, 0);
            this.Controls.SetChildIndex(this.lblCriterio, 0);
            this.Controls.SetChildIndex(this.lblValBusuqeda, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnBusqueda, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgGarantias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private cboCriBusGar cboCriBusGar;
        private dtgBase dtgGarantias;
        private txtBase txtValBusqueda;
        private lblBase lblCriterio;
        private lblBase lblValBusuqeda;
        private BotonesBase.btnSalir btnSalir;
        private BotonesBase.BtnAceptar btnAceptar;
        private BotonesBase.btnBusqueda btnBusqueda;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCliGarantia;
        private System.Windows.Forms.DataGridViewTextBoxColumn cGarantia;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn idGarantia;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCli;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMonGravado;
        private System.Windows.Forms.DataGridViewTextBoxColumn nPorcentaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMonGarantia;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMonSaldoGrav;
    }
}

