namespace CLI.Presentacion
{
    partial class frmRegistroNumerosTelf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistroNumerosTelf));
            this.dtgRegTelefonos = new GEN.ControlesBase.dtgBase(this.components);
            this.btnAgregar1 = new GEN.BotonesBase.btnAgregar();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtNumerico1 = new GEN.ControlesBase.txtNumerico(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboTipoTelefono1 = new GEN.ControlesBase.cboTipoTelefono(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtDNI = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.txtCodCli = new GEN.ControlesBase.txtBase(this.components);
            this.txtNombre = new GEN.ControlesBase.txtBase(this.components);
            this.btnEliminar1 = new GEN.BotonesBase.btnEliminar();
            this.btnMarcar = new System.Windows.Forms.Button();
            this.txtNumerico2 = new GEN.ControlesBase.txtNumerico(this.components);
            this.cboCodCiudad = new GEN.ControlesBase.cboBase(this.components);
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRegTelefonos)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgRegTelefonos
            // 
            this.dtgRegTelefonos.AllowUserToAddRows = false;
            this.dtgRegTelefonos.AllowUserToDeleteRows = false;
            this.dtgRegTelefonos.AllowUserToResizeColumns = false;
            this.dtgRegTelefonos.AllowUserToResizeRows = false;
            this.dtgRegTelefonos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgRegTelefonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgRegTelefonos.Location = new System.Drawing.Point(27, 199);
            this.dtgRegTelefonos.MultiSelect = false;
            this.dtgRegTelefonos.Name = "dtgRegTelefonos";
            this.dtgRegTelefonos.ReadOnly = true;
            this.dtgRegTelefonos.RowHeadersVisible = false;
            this.dtgRegTelefonos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgRegTelefonos.Size = new System.Drawing.Size(355, 220);
            this.dtgRegTelefonos.TabIndex = 2;
            this.dtgRegTelefonos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgRegTelefonos_CellClick);
            this.dtgRegTelefonos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgRegTelefonos_CellContentClick_1);
            // 
            // btnAgregar1
            // 
            this.btnAgregar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar1.BackgroundImage")));
            this.btnAgregar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar1.Location = new System.Drawing.Point(388, 199);
            this.btnAgregar1.Name = "btnAgregar1";
            this.btnAgregar1.Size = new System.Drawing.Size(60, 50);
            this.btnAgregar1.TabIndex = 3;
            this.btnAgregar1.Text = "&Agregar";
            this.btnAgregar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregar1.UseVisualStyleBackColor = true;
            this.btnAgregar1.Click += new System.EventHandler(this.btnAgregar1_Click);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 164);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(188, 13);
            this.lblBase1.TabIndex = 5;
            this.lblBase1.Text = "Ingrese el número de contacto:";
            // 
            // txtNumerico1
            // 
            this.txtNumerico1.Format = "n2";
            this.txtNumerico1.Location = new System.Drawing.Point(259, 168);
            this.txtNumerico1.MaxLength = 9;
            this.txtNumerico1.Name = "txtNumerico1";
            this.txtNumerico1.Size = new System.Drawing.Size(100, 20);
            this.txtNumerico1.TabIndex = 6;
            this.txtNumerico1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumerico1_KeyPress);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(95, 143);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(104, 13);
            this.lblBase2.TabIndex = 8;
            this.lblBase2.Text = "Tipo de teléfono:";
            // 
            // cboTipoTelefono1
            // 
            this.cboTipoTelefono1.DisplayMember = "cTipoTelefono";
            this.cboTipoTelefono1.FormattingEnabled = true;
            this.cboTipoTelefono1.Location = new System.Drawing.Point(206, 140);
            this.cboTipoTelefono1.Name = "cboTipoTelefono1";
            this.cboTipoTelefono1.Size = new System.Drawing.Size(121, 21);
            this.cboTipoTelefono1.TabIndex = 9;
            this.cboTipoTelefono1.ValueMember = "idTipoTelefono";
            this.cboTipoTelefono1.SelectedIndexChanged += new System.EventHandler(this.cboTipoTelefono1_SelectedIndexChanged);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(12, 23);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(244, 13);
            this.lblBase3.TabIndex = 10;
            this.lblBase3.Text = "Registro de Teléfonos de contacto para : ";
            // 
            // txtDNI
            // 
            this.txtDNI.Enabled = false;
            this.txtDNI.Location = new System.Drawing.Point(207, 68);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(254, 20);
            this.txtDNI.TabIndex = 11;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(83, 46);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(118, 13);
            this.lblBase4.TabIndex = 12;
            this.lblBase4.Text = "Código de Cliente :";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(24, 68);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(177, 13);
            this.lblBase5.TabIndex = 13;
            this.lblBase5.Text = "Documento de identificación :";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(57, 91);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(144, 13);
            this.lblBase6.TabIndex = 14;
            this.lblBase6.Text = "Nombre o razón social :";
            // 
            // txtCodCli
            // 
            this.txtCodCli.Enabled = false;
            this.txtCodCli.Location = new System.Drawing.Point(207, 46);
            this.txtCodCli.Name = "txtCodCli";
            this.txtCodCli.Size = new System.Drawing.Size(254, 20);
            this.txtCodCli.TabIndex = 15;
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(206, 91);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(254, 20);
            this.txtNombre.TabIndex = 16;
            // 
            // btnEliminar1
            // 
            this.btnEliminar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar1.BackgroundImage")));
            this.btnEliminar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEliminar1.Location = new System.Drawing.Point(388, 255);
            this.btnEliminar1.Name = "btnEliminar1";
            this.btnEliminar1.Size = new System.Drawing.Size(60, 50);
            this.btnEliminar1.TabIndex = 18;
            this.btnEliminar1.Text = "&Eliminar";
            this.btnEliminar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminar1.UseVisualStyleBackColor = true;
            this.btnEliminar1.Click += new System.EventHandler(this.btnEliminar1_Click);
            // 
            // btnMarcar
            // 
            this.btnMarcar.Location = new System.Drawing.Point(388, 367);
            this.btnMarcar.Name = "btnMarcar";
            this.btnMarcar.Size = new System.Drawing.Size(60, 52);
            this.btnMarcar.TabIndex = 20;
            this.btnMarcar.Text = "Marcar como Principal";
            this.btnMarcar.UseVisualStyleBackColor = true;
            this.btnMarcar.Click += new System.EventHandler(this.btnMarcar_Click);
            // 
            // txtNumerico2
            // 
            this.txtNumerico2.Format = "n2";
            this.txtNumerico2.Location = new System.Drawing.Point(259, 167);
            this.txtNumerico2.MaxLength = 7;
            this.txtNumerico2.Name = "txtNumerico2";
            this.txtNumerico2.Size = new System.Drawing.Size(100, 20);
            this.txtNumerico2.TabIndex = 22;
            this.txtNumerico2.TextChanged += new System.EventHandler(this.txtNumerico2_TextChanged);
            this.txtNumerico2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumerico2_KeyPress);
            // 
            // cboCodCiudad
            // 
            this.cboCodCiudad.Enabled = false;
            this.cboCodCiudad.FormattingEnabled = true;
            this.cboCodCiudad.Location = new System.Drawing.Point(206, 167);
            this.cboCodCiudad.Name = "cboCodCiudad";
            this.cboCodCiudad.Size = new System.Drawing.Size(47, 21);
            this.cboCodCiudad.TabIndex = 25;
            this.cboCodCiudad.SelectedIndexChanged += new System.EventHandler(this.cboCodCiudad_SelectedIndexChanged);
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(388, 311);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 26;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // frmRegistroNumerosTelf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 465);
            this.ControlBox = false;
            this.Controls.Add(this.btnAceptar1);
            this.Controls.Add(this.cboCodCiudad);
            this.Controls.Add(this.txtNumerico2);
            this.Controls.Add(this.btnMarcar);
            this.Controls.Add(this.btnEliminar1);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtCodCli);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.txtDNI);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.cboTipoTelefono1);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.txtNumerico1);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.btnAgregar1);
            this.Controls.Add(this.dtgRegTelefonos);
            this.Name = "frmRegistroNumerosTelf";
            this.Text = "Registro de Números Telfónicos";
            this.Controls.SetChildIndex(this.dtgRegTelefonos, 0);
            this.Controls.SetChildIndex(this.btnAgregar1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.txtNumerico1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.cboTipoTelefono1, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.txtDNI, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.txtCodCli, 0);
            this.Controls.SetChildIndex(this.txtNombre, 0);
            this.Controls.SetChildIndex(this.btnEliminar1, 0);
            this.Controls.SetChildIndex(this.btnMarcar, 0);
            this.Controls.SetChildIndex(this.txtNumerico2, 0);
            this.Controls.SetChildIndex(this.cboCodCiudad, 0);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgRegTelefonos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgRegTelefonos;
        private GEN.BotonesBase.btnAgregar btnAgregar1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtNumerico txtNumerico1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboTipoTelefono cboTipoTelefono1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtBase txtDNI;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.txtBase txtCodCli;
        private GEN.ControlesBase.txtBase txtNombre;
        private GEN.BotonesBase.btnEliminar btnEliminar1;
        private System.Windows.Forms.Button btnMarcar;
        private GEN.ControlesBase.txtNumerico txtNumerico2;
        private GEN.ControlesBase.cboBase cboCodCiudad;
        private GEN.BotonesBase.BtnAceptar btnAceptar1;
    }
}