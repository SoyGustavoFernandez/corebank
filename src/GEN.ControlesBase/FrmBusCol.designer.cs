namespace GEN.ControlesBase
{
    partial class FrmBusCol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBusCol));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblCriterio = new GEN.ControlesBase.lblBase();
            this.dtgColaborador = new GEN.ControlesBase.dtgBase(this.components);
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.txtDniNom = new GEN.ControlesBase.txtBase(this.components);
            this.cboCriBusCol = new GEN.ControlesBase.cboCriBusCli(this.components);
            this.btnBusqueda1 = new GEN.BotonesBase.btnBusqueda();
            ((System.ComponentModel.ISupportInitialize)(this.dtgColaborador)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 15);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(115, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Criterio Búsqueda:";
            // 
            // lblCriterio
            // 
            this.lblCriterio.AutoSize = true;
            this.lblCriterio.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblCriterio.ForeColor = System.Drawing.Color.Navy;
            this.lblCriterio.Location = new System.Drawing.Point(12, 43);
            this.lblCriterio.Name = "lblCriterio";
            this.lblCriterio.Size = new System.Drawing.Size(34, 13);
            this.lblCriterio.TabIndex = 4;
            this.lblCriterio.Text = "DNI:";
            // 
            // dtgColaborador
            // 
            this.dtgColaborador.AllowUserToAddRows = false;
            this.dtgColaborador.AllowUserToDeleteRows = false;
            this.dtgColaborador.AllowUserToResizeColumns = false;
            this.dtgColaborador.AllowUserToResizeRows = false;
            this.dtgColaborador.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgColaborador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgColaborador.Location = new System.Drawing.Point(9, 75);
            this.dtgColaborador.MultiSelect = false;
            this.dtgColaborador.Name = "dtgColaborador";
            this.dtgColaborador.ReadOnly = true;
            this.dtgColaborador.RowHeadersVisible = false;
            this.dtgColaborador.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgColaborador.Size = new System.Drawing.Size(504, 176);
            this.dtgColaborador.TabIndex = 3;
            this.dtgColaborador.DoubleClick += new System.EventHandler(this.dtgClientes_DoubleClick);
            this.dtgColaborador.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgColaborador_KeyDown);
            this.dtgColaborador.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtgClientes_KeyPress);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(387, 257);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(453, 257);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 3;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            this.btnSalir1.Click += new System.EventHandler(this.btnSalir1_Click);
            // 
            // txtDniNom
            // 
            this.txtDniNom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDniNom.Location = new System.Drawing.Point(153, 42);
            this.txtDniNom.Name = "txtDniNom";
            this.txtDniNom.Size = new System.Drawing.Size(276, 20);
            this.txtDniNom.TabIndex = 0;
            this.txtDniNom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDniNom_KeyPress);
            // 
            // cboCriBusCol
            // 
            this.cboCriBusCol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCriBusCol.FormattingEnabled = true;
            this.cboCriBusCol.Location = new System.Drawing.Point(153, 12);
            this.cboCriBusCol.Name = "cboCriBusCol";
            this.cboCriBusCol.Size = new System.Drawing.Size(276, 21);
            this.cboCriBusCol.TabIndex = 4;
            this.cboCriBusCol.SelectedIndexChanged += new System.EventHandler(this.cboCriBusCli1_SelectedIndexChanged);
            // 
            // btnBusqueda1
            // 
            this.btnBusqueda1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda1.BackgroundImage")));
            this.btnBusqueda1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda1.Location = new System.Drawing.Point(453, 10);
            this.btnBusqueda1.Name = "btnBusqueda1";
            this.btnBusqueda1.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda1.TabIndex = 5;
            this.btnBusqueda1.Text = "&Buscar";
            this.btnBusqueda1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda1.UseVisualStyleBackColor = true;
            this.btnBusqueda1.Click += new System.EventHandler(this.btnBusqueda1_Click);
            // 
            // FrmBusCol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 335);
            this.Controls.Add(this.cboCriBusCol);
            this.Controls.Add(this.btnBusqueda1);
            this.Controls.Add(this.txtDniNom);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.dtgColaborador);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblCriterio);
            this.Controls.Add(this.lblBase1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmBusCol";
            this.Text = "Buscar Colaborador";
            this.Load += new System.EventHandler(this.FrmBusquedaCli_Load);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblCriterio, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.dtgColaborador, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.txtDniNom, 0);
            this.Controls.SetChildIndex(this.btnBusqueda1, 0);
            this.Controls.SetChildIndex(this.cboCriBusCol, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgColaborador)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private lblBase lblBase1;
        private lblBase lblCriterio;
        private dtgBase dtgColaborador;
        private BotonesBase.BtnAceptar btnAceptar;
        private BotonesBase.btnSalir btnSalir1;
        private cboCriBusCli cboCriBusCol;
        private BotonesBase.btnBusqueda btnBusqueda1;
        public txtBase txtDniNom;
    }
}