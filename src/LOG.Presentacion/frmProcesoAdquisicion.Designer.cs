namespace LOG.Presentacion
{
    partial class frmProcesoAdquisicion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProcesoAdquisicion));
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.btnBusqueda = new GEN.BotonesBase.btnBusqueda();
            this.txtEstadoNotaSal = new GEN.ControlesBase.txtBase(this.components);
            this.txtNumNotaSal = new GEN.ControlesBase.txtBase(this.components);
            this.dtpFechaNS = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtgDetalleNS = new GEN.ControlesBase.dtgBase(this.components);
            this.txtSustento = new GEN.ControlesBase.txtBase(this.components);
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.txtCBEstUsuSol = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtCBAreaSol = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.txtCBUsuarioSol = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.txtCBNombre = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.btnQuitar = new GEN.BotonesBase.btnQuitar();
            this.btnAgregar = new GEN.BotonesBase.btnAgregar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.cboMoneda1 = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.grbBase2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleNS)).BeginInit();
            this.grbBase3.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.btnBusqueda);
            this.grbBase2.Controls.Add(this.txtEstadoNotaSal);
            this.grbBase2.Controls.Add(this.txtNumNotaSal);
            this.grbBase2.Controls.Add(this.dtpFechaNS);
            this.grbBase2.Controls.Add(this.lblBase5);
            this.grbBase2.Controls.Add(this.lblBase1);
            this.grbBase2.Controls.Add(this.lblBase2);
            this.grbBase2.Location = new System.Drawing.Point(12, 6);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(353, 101);
            this.grbBase2.TabIndex = 22;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Datos de Solicitud de Proceso de Adquisición";
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda.BackgroundImage")));
            this.btnBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda.Location = new System.Drawing.Point(287, 14);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda.TabIndex = 22;
            this.btnBusqueda.Text = "&Buscar";
            this.btnBusqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda.UseVisualStyleBackColor = true;
            // 
            // txtEstadoNotaSal
            // 
            this.txtEstadoNotaSal.Enabled = false;
            this.txtEstadoNotaSal.Location = new System.Drawing.Point(121, 49);
            this.txtEstadoNotaSal.Name = "txtEstadoNotaSal";
            this.txtEstadoNotaSal.Size = new System.Drawing.Size(160, 20);
            this.txtEstadoNotaSal.TabIndex = 21;
            // 
            // txtNumNotaSal
            // 
            this.txtNumNotaSal.Location = new System.Drawing.Point(121, 22);
            this.txtNumNotaSal.Name = "txtNumNotaSal";
            this.txtNumNotaSal.Size = new System.Drawing.Size(160, 20);
            this.txtNumNotaSal.TabIndex = 16;
            this.txtNumNotaSal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumNotaSal_KeyPress);
            // 
            // dtpFechaNS
            // 
            this.dtpFechaNS.Enabled = false;
            this.dtpFechaNS.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNS.Location = new System.Drawing.Point(121, 74);
            this.dtpFechaNS.Name = "dtpFechaNS";
            this.dtpFechaNS.Size = new System.Drawing.Size(160, 20);
            this.dtpFechaNS.TabIndex = 19;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(70, 80);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(45, 13);
            this.lblBase5.TabIndex = 20;
            this.lblBase5.Text = "Fecha:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(11, 25);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(109, 13);
            this.lblBase1.TabIndex = 17;
            this.lblBase1.Text = "Solicitud Proceso:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(65, 56);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(50, 13);
            this.lblBase2.TabIndex = 18;
            this.lblBase2.Text = "Estado:";
            // 
            // dtgDetalleNS
            // 
            this.dtgDetalleNS.AllowUserToAddRows = false;
            this.dtgDetalleNS.AllowUserToDeleteRows = false;
            this.dtgDetalleNS.AllowUserToResizeColumns = false;
            this.dtgDetalleNS.AllowUserToResizeRows = false;
            this.dtgDetalleNS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetalleNS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalleNS.Location = new System.Drawing.Point(22, 167);
            this.dtgDetalleNS.MultiSelect = false;
            this.dtgDetalleNS.Name = "dtgDetalleNS";
            this.dtgDetalleNS.ReadOnly = true;
            this.dtgDetalleNS.RowHeadersVisible = false;
            this.dtgDetalleNS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetalleNS.Size = new System.Drawing.Size(767, 253);
            this.dtgDetalleNS.TabIndex = 5;
            this.dtgDetalleNS.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDetalleNS_CellEndEdit);
            // 
            // txtSustento
            // 
            this.txtSustento.Location = new System.Drawing.Point(22, 437);
            this.txtSustento.Multiline = true;
            this.txtSustento.Name = "txtSustento";
            this.txtSustento.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSustento.Size = new System.Drawing.Size(767, 54);
            this.txtSustento.TabIndex = 28;
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.txtCBEstUsuSol);
            this.grbBase3.Controls.Add(this.txtCBAreaSol);
            this.grbBase3.Controls.Add(this.lblBase9);
            this.grbBase3.Controls.Add(this.txtCBUsuarioSol);
            this.grbBase3.Controls.Add(this.lblBase7);
            this.grbBase3.Controls.Add(this.txtCBNombre);
            this.grbBase3.Controls.Add(this.lblBase6);
            this.grbBase3.Controls.Add(this.lblBase8);
            this.grbBase3.Location = new System.Drawing.Point(371, 6);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(424, 101);
            this.grbBase3.TabIndex = 38;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Datos de Solicitante:";
            // 
            // txtCBEstUsuSol
            // 
            this.txtCBEstUsuSol.Enabled = false;
            this.txtCBEstUsuSol.Location = new System.Drawing.Point(289, 73);
            this.txtCBEstUsuSol.Name = "txtCBEstUsuSol";
            this.txtCBEstUsuSol.Size = new System.Drawing.Size(129, 20);
            this.txtCBEstUsuSol.TabIndex = 3;
            // 
            // txtCBAreaSol
            // 
            this.txtCBAreaSol.Enabled = false;
            this.txtCBAreaSol.Location = new System.Drawing.Point(112, 49);
            this.txtCBAreaSol.Name = "txtCBAreaSol";
            this.txtCBAreaSol.Size = new System.Drawing.Size(306, 20);
            this.txtCBAreaSol.TabIndex = 1;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(243, 80);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(50, 13);
            this.lblBase9.TabIndex = 18;
            this.lblBase9.Text = "Estado:";
            // 
            // txtCBUsuarioSol
            // 
            this.txtCBUsuarioSol.Enabled = false;
            this.txtCBUsuarioSol.Location = new System.Drawing.Point(111, 74);
            this.txtCBUsuarioSol.Name = "txtCBUsuarioSol";
            this.txtCBUsuarioSol.Size = new System.Drawing.Size(125, 20);
            this.txtCBUsuarioSol.TabIndex = 2;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(67, 52);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(39, 13);
            this.lblBase7.TabIndex = 15;
            this.lblBase7.Text = "Area:";
            // 
            // txtCBNombre
            // 
            this.txtCBNombre.Enabled = false;
            this.txtCBNombre.Location = new System.Drawing.Point(112, 24);
            this.txtCBNombre.Name = "txtCBNombre";
            this.txtCBNombre.Size = new System.Drawing.Size(306, 20);
            this.txtCBNombre.TabIndex = 0;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(7, 28);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(104, 13);
            this.lblBase6.TabIndex = 13;
            this.lblBase6.Text = "Ape. y Nombres:";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(51, 78);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(55, 13);
            this.lblBase8.TabIndex = 17;
            this.lblBase8.Text = "Usuario:";
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitar.BackgroundImage")));
            this.btnQuitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitar.Enabled = false;
            this.btnQuitar.Location = new System.Drawing.Point(732, 111);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(60, 50);
            this.btnQuitar.TabIndex = 30;
            this.btnQuitar.Text = "&Quitar";
            this.btnQuitar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar.BackgroundImage")));
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar.Enabled = false;
            this.btnAgregar.Location = new System.Drawing.Point(666, 111);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(60, 50);
            this.btnAgregar.TabIndex = 29;
            this.btnAgregar.Text = "&Agregar";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(660, 497);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 36;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Enabled = false;
            this.btnEditar.Location = new System.Drawing.Point(600, 497);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 34;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(540, 497);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 33;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(480, 497);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 32;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // cboMoneda1
            // 
            this.cboMoneda1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda1.FormattingEnabled = true;
            this.cboMoneda1.Location = new System.Drawing.Point(116, 119);
            this.cboMoneda1.Name = "cboMoneda1";
            this.cboMoneda1.Size = new System.Drawing.Size(177, 21);
            this.cboMoneda1.TabIndex = 39;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(26, 127);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(84, 13);
            this.lblBase3.TabIndex = 40;
            this.lblBase3.Text = "Tipo Moneda:";
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(726, 497);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 41;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // frmProcesoAdquisicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 572);
            this.Controls.Add(this.dtgDetalleNS);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.cboMoneda1);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtSustento);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.grbBase2);
            this.Name = "frmProcesoAdquisicion";
            this.Text = "Solicitud de Proceso de Adquisición";
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.txtSustento, 0);
            this.Controls.SetChildIndex(this.btnAgregar, 0);
            this.Controls.SetChildIndex(this.btnQuitar, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.cboMoneda1, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.dtgDetalleNS, 0);
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleNS)).EndInit();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.BotonesBase.btnBusqueda btnBusqueda;
        private GEN.ControlesBase.txtBase txtEstadoNotaSal;
        private GEN.ControlesBase.txtBase txtNumNotaSal;
        private GEN.ControlesBase.dtpCorto dtpFechaNS;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.BotonesBase.btnQuitar btnQuitar;
        private GEN.BotonesBase.btnAgregar btnAgregar;
        private GEN.ControlesBase.dtgBase dtgDetalleNS;
        private GEN.ControlesBase.txtBase txtSustento;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.txtCBNumerosEnteros txtCBEstUsuSol;
        private GEN.ControlesBase.txtCBNumerosEnteros txtCBAreaSol;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.txtCBNumerosEnteros txtCBUsuarioSol;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.txtCBNumerosEnteros txtCBNombre;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.cboMoneda cboMoneda1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.BotonesBase.btnSalir btnSalir1;
    }
}