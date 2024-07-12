namespace GEN.ControlesBase
{
    partial class FrmBusCli
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBusCli));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblCriterio = new GEN.ControlesBase.lblBase();
            this.dtgClientes = new GEN.ControlesBase.dtgBase(this.components);
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.txtDniNom = new GEN.ControlesBase.txtBase(this.components);
            this.cboCriBusCli = new GEN.ControlesBase.cboCriBusCli(this.components);
            this.btnBusCliente = new GEN.BotonesBase.btnBusCliente();
            ((System.ComponentModel.ISupportInitialize)(this.dtgClientes)).BeginInit();
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
            // dtgClientes
            // 
            this.dtgClientes.AllowUserToAddRows = false;
            this.dtgClientes.AllowUserToDeleteRows = false;
            this.dtgClientes.AllowUserToResizeColumns = false;
            this.dtgClientes.AllowUserToResizeRows = false;
            this.dtgClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgClientes.Location = new System.Drawing.Point(9, 75);
            this.dtgClientes.MultiSelect = false;
            this.dtgClientes.Name = "dtgClientes";
            this.dtgClientes.ReadOnly = true;
            this.dtgClientes.RowHeadersVisible = false;
            this.dtgClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgClientes.Size = new System.Drawing.Size(624, 176);
            this.dtgClientes.TabIndex = 3;
            this.dtgClientes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgClientes_KeyDown);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(505, 257);
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
            this.btnSalir1.Location = new System.Drawing.Point(571, 257);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 3;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // txtDniNom
            // 
            this.txtDniNom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDniNom.Location = new System.Drawing.Point(153, 40);
            this.txtDniNom.Name = "txtDniNom";
            this.txtDniNom.Size = new System.Drawing.Size(276, 20);
            this.txtDniNom.TabIndex = 0;
            this.txtDniNom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDniNom_KeyPress);
            // 
            // cboCriBusCli
            // 
            this.cboCriBusCli.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCriBusCli.FormattingEnabled = true;
            this.cboCriBusCli.Location = new System.Drawing.Point(153, 12);
            this.cboCriBusCli.Name = "cboCriBusCli";
            this.cboCriBusCli.Size = new System.Drawing.Size(276, 21);
            this.cboCriBusCli.TabIndex = 4;
            this.cboCriBusCli.SelectedIndexChanged += new System.EventHandler(this.cboCriBusCli1_SelectedIndexChanged);
            // 
            // btnBusCliente
            // 
            this.btnBusCliente.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusCliente.BackgroundImage")));
            this.btnBusCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusCliente.Location = new System.Drawing.Point(453, 10);
            this.btnBusCliente.Name = "btnBusCliente";
            this.btnBusCliente.Size = new System.Drawing.Size(60, 50);
            this.btnBusCliente.TabIndex = 1;
            this.btnBusCliente.Text = "Cliente";
            this.btnBusCliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusCliente.UseVisualStyleBackColor = true;
            this.btnBusCliente.Click += new System.EventHandler(this.btnBusCliente_Click);
            // 
            // FrmBusCli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 335);
            this.Controls.Add(this.btnBusCliente);
            this.Controls.Add(this.cboCriBusCli);
            this.Controls.Add(this.txtDniNom);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.dtgClientes);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblCriterio);
            this.Controls.Add(this.lblBase1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FrmBusCli";
            this.Text = "Buscar Clientes";
            this.Load += new System.EventHandler(this.FrmBusquedaCli_Load);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblCriterio, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.dtgClientes, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.txtDniNom, 0);
            this.Controls.SetChildIndex(this.cboCriBusCli, 0);
            this.Controls.SetChildIndex(this.btnBusCliente, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private lblBase lblBase1;
        private lblBase lblCriterio;
        private dtgBase dtgClientes;
        private BotonesBase.BtnAceptar btnAceptar;
        private BotonesBase.btnSalir btnSalir1;
        private txtBase txtDniNom;
        private cboCriBusCli cboCriBusCli;
        private BotonesBase.btnBusCliente btnBusCliente;
    }
}