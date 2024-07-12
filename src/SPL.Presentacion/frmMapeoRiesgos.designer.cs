namespace SPL.Presentacion
{
    partial class frmMapeoRiesgos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMapeoRiesgos));
            this.dtgMapeo = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.grbDetalle = new GEN.ControlesBase.grbBase(this.components);
            this.panOperacion = new System.Windows.Forms.Panel();
            this.cboModulo1 = new GEN.ControlesBase.cboModulo(this.components);
            this.cboTipoOperacion1 = new GEN.ControlesBase.cboTipoOperacion(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.panZona = new System.Windows.Forms.Panel();
            this.cboDep = new GEN.ControlesBase.cboUbigeo(this.components);
            this.cboProvincia = new GEN.ControlesBase.cboUbigeo(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboProductos = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboCalificRiesgo = new GEN.ControlesBase.cboBase(this.components);
            this.txtPuntaje = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.dtgActividades = new GEN.ControlesBase.dtgBase(this.components);
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.cboTipoMapeoSPLAFT1 = new GEN.ControlesBase.cboTipoMapeoSPLAFT(this.components);
            this.btnEliminar1 = new GEN.BotonesBase.btnEliminar();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMapeo)).BeginInit();
            this.grbDetalle.SuspendLayout();
            this.panOperacion.SuspendLayout();
            this.panZona.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgActividades)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgMapeo
            // 
            this.dtgMapeo.AllowUserToAddRows = false;
            this.dtgMapeo.AllowUserToDeleteRows = false;
            this.dtgMapeo.AllowUserToResizeColumns = false;
            this.dtgMapeo.AllowUserToResizeRows = false;
            this.dtgMapeo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgMapeo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMapeo.Location = new System.Drawing.Point(12, 39);
            this.dtgMapeo.MultiSelect = false;
            this.dtgMapeo.Name = "dtgMapeo";
            this.dtgMapeo.ReadOnly = true;
            this.dtgMapeo.RowHeadersVisible = false;
            this.dtgMapeo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgMapeo.Size = new System.Drawing.Size(380, 265);
            this.dtgMapeo.TabIndex = 1;
            this.dtgMapeo.SelectionChanged += new System.EventHandler(this.dtgMapeo_SelectionChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 15);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(77, 13);
            this.lblBase1.TabIndex = 4;
            this.lblBase1.Text = "Tipo Mapeo:";
            // 
            // grbDetalle
            // 
            this.grbDetalle.Controls.Add(this.panOperacion);
            this.grbDetalle.Controls.Add(this.panZona);
            this.grbDetalle.Controls.Add(this.cboProductos);
            this.grbDetalle.Controls.Add(this.lblBase2);
            this.grbDetalle.Location = new System.Drawing.Point(12, 310);
            this.grbDetalle.Name = "grbDetalle";
            this.grbDetalle.Size = new System.Drawing.Size(603, 71);
            this.grbDetalle.TabIndex = 5;
            this.grbDetalle.TabStop = false;
            this.grbDetalle.Text = "PRODUCTOS ACTIVOS";
            // 
            // panOperacion
            // 
            this.panOperacion.Controls.Add(this.cboModulo1);
            this.panOperacion.Controls.Add(this.cboTipoOperacion1);
            this.panOperacion.Controls.Add(this.lblBase7);
            this.panOperacion.Controls.Add(this.lblBase8);
            this.panOperacion.Location = new System.Drawing.Point(3, 13);
            this.panOperacion.Name = "panOperacion";
            this.panOperacion.Size = new System.Drawing.Size(399, 55);
            this.panOperacion.TabIndex = 21;
            this.panOperacion.Visible = false;
            // 
            // cboModulo1
            // 
            this.cboModulo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModulo1.FormattingEnabled = true;
            this.cboModulo1.Location = new System.Drawing.Point(71, 3);
            this.cboModulo1.Name = "cboModulo1";
            this.cboModulo1.Size = new System.Drawing.Size(121, 21);
            this.cboModulo1.TabIndex = 7;
            this.cboModulo1.SelectedIndexChanged += new System.EventHandler(this.cboModulo1_SelectedIndexChanged);
            // 
            // cboTipoOperacion1
            // 
            this.cboTipoOperacion1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoOperacion1.FormattingEnabled = true;
            this.cboTipoOperacion1.Location = new System.Drawing.Point(71, 29);
            this.cboTipoOperacion1.Name = "cboTipoOperacion1";
            this.cboTipoOperacion1.Size = new System.Drawing.Size(265, 21);
            this.cboTipoOperacion1.TabIndex = 6;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(3, 32);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(70, 13);
            this.lblBase7.TabIndex = 4;
            this.lblBase7.Text = "Operación:";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(3, 6);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(52, 13);
            this.lblBase8.TabIndex = 4;
            this.lblBase8.Text = "Modulo:";
            // 
            // panZona
            // 
            this.panZona.Controls.Add(this.cboDep);
            this.panZona.Controls.Add(this.cboProvincia);
            this.panZona.Controls.Add(this.lblBase6);
            this.panZona.Controls.Add(this.lblBase5);
            this.panZona.Location = new System.Drawing.Point(3, 13);
            this.panZona.Name = "panZona";
            this.panZona.Size = new System.Drawing.Size(252, 55);
            this.panZona.TabIndex = 10;
            this.panZona.Visible = false;
            // 
            // cboDep
            // 
            this.cboDep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDep.FormattingEnabled = true;
            this.cboDep.Location = new System.Drawing.Point(103, 3);
            this.cboDep.Name = "cboDep";
            this.cboDep.Size = new System.Drawing.Size(121, 21);
            this.cboDep.TabIndex = 10;
            this.cboDep.SelectedIndexChanged += new System.EventHandler(this.cboDep_SelectedIndexChanged);
            // 
            // cboProvincia
            // 
            this.cboProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProvincia.FormattingEnabled = true;
            this.cboProvincia.Location = new System.Drawing.Point(103, 29);
            this.cboProvincia.Name = "cboProvincia";
            this.cboProvincia.Size = new System.Drawing.Size(121, 21);
            this.cboProvincia.TabIndex = 20;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(33, 33);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(64, 13);
            this.lblBase6.TabIndex = 4;
            this.lblBase6.Text = "Provincia:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(3, 6);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(94, 13);
            this.lblBase5.TabIndex = 4;
            this.lblBase5.Text = "Departamento:";
            // 
            // cboProductos
            // 
            this.cboProductos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProductos.FormattingEnabled = true;
            this.cboProductos.Location = new System.Drawing.Point(74, 16);
            this.cboProductos.Name = "cboProductos";
            this.cboProductos.Size = new System.Drawing.Size(130, 21);
            this.cboProductos.TabIndex = 9;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(6, 19);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(62, 13);
            this.lblBase2.TabIndex = 4;
            this.lblBase2.Text = "Producto:";
            // 
            // cboCalificRiesgo
            // 
            this.cboCalificRiesgo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCalificRiesgo.FormattingEnabled = true;
            this.cboCalificRiesgo.Location = new System.Drawing.Point(485, 272);
            this.cboCalificRiesgo.Name = "cboCalificRiesgo";
            this.cboCalificRiesgo.Size = new System.Drawing.Size(130, 21);
            this.cboCalificRiesgo.TabIndex = 4;
            // 
            // txtPuntaje
            // 
            this.txtPuntaje.FormatoDecimal = false;
            this.txtPuntaje.Location = new System.Drawing.Point(565, 246);
            this.txtPuntaje.Name = "txtPuntaje";
            this.txtPuntaje.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPuntaje.nNumDecimales = 4;
            this.txtPuntaje.nvalor = 0D;
            this.txtPuntaje.ReadOnly = true;
            this.txtPuntaje.Size = new System.Drawing.Size(50, 20);
            this.txtPuntaje.TabIndex = 3;
            this.txtPuntaje.TextChanged += new System.EventHandler(this.txtPuntaje_TextChanged);
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(430, 275);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(50, 13);
            this.lblBase4.TabIndex = 4;
            this.lblBase4.Text = "Riesgo:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(504, 249);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(55, 13);
            this.lblBase3.TabIndex = 4;
            this.lblBase3.Text = "Puntaje:";
            // 
            // dtgActividades
            // 
            this.dtgActividades.AllowUserToAddRows = false;
            this.dtgActividades.AllowUserToDeleteRows = false;
            this.dtgActividades.AllowUserToResizeColumns = false;
            this.dtgActividades.AllowUserToResizeRows = false;
            this.dtgActividades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgActividades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgActividades.Location = new System.Drawing.Point(395, 39);
            this.dtgActividades.MultiSelect = false;
            this.dtgActividades.Name = "dtgActividades";
            this.dtgActividades.ReadOnly = true;
            this.dtgActividades.RowHeadersVisible = false;
            this.dtgActividades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgActividades.Size = new System.Drawing.Size(220, 200);
            this.dtgActividades.TabIndex = 2;
            this.dtgActividades.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgActividades_CellValueChanged);
            this.dtgActividades.CurrentCellDirtyStateChanged += new System.EventHandler(this.dtgActividades_CurrentCellDirtyStateChanged);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(423, 387);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 9;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(291, 386);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 7;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(555, 386);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 11;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Location = new System.Drawing.Point(225, 386);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 6;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Enabled = false;
            this.btnGrabar1.Location = new System.Drawing.Point(357, 387);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 8;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // cboTipoMapeoSPLAFT1
            // 
            this.cboTipoMapeoSPLAFT1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoMapeoSPLAFT1.FormattingEnabled = true;
            this.cboTipoMapeoSPLAFT1.Location = new System.Drawing.Point(95, 12);
            this.cboTipoMapeoSPLAFT1.Name = "cboTipoMapeoSPLAFT1";
            this.cboTipoMapeoSPLAFT1.Size = new System.Drawing.Size(150, 21);
            this.cboTipoMapeoSPLAFT1.TabIndex = 0;
            this.cboTipoMapeoSPLAFT1.SelectedIndexChanged += new System.EventHandler(this.cboTipoMapeoSPLAFT1_SelectedIndexChanged);
            // 
            // btnEliminar1
            // 
            this.btnEliminar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar1.BackgroundImage")));
            this.btnEliminar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEliminar1.Location = new System.Drawing.Point(489, 387);
            this.btnEliminar1.Name = "btnEliminar1";
            this.btnEliminar1.Size = new System.Drawing.Size(60, 50);
            this.btnEliminar1.TabIndex = 10;
            this.btnEliminar1.Text = "&Eliminar";
            this.btnEliminar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminar1.UseVisualStyleBackColor = true;
            this.btnEliminar1.Click += new System.EventHandler(this.btnEliminar1_Click);
            // 
            // frmMapeoRiesgos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 461);
            this.Controls.Add(this.btnEliminar1);
            this.Controls.Add(this.cboTipoMapeoSPLAFT1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.cboCalificRiesgo);
            this.Controls.Add(this.txtPuntaje);
            this.Controls.Add(this.dtgActividades);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.grbDetalle);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.dtgMapeo);
            this.Name = "frmMapeoRiesgos";
            this.Text = "Mapeo de riesgo";
            this.Load += new System.EventHandler(this.frmMapeoRiesgos_Load);
            this.Controls.SetChildIndex(this.dtgMapeo, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.grbDetalle, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.dtgActividades, 0);
            this.Controls.SetChildIndex(this.txtPuntaje, 0);
            this.Controls.SetChildIndex(this.cboCalificRiesgo, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.cboTipoMapeoSPLAFT1, 0);
            this.Controls.SetChildIndex(this.btnEliminar1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgMapeo)).EndInit();
            this.grbDetalle.ResumeLayout(false);
            this.grbDetalle.PerformLayout();
            this.panOperacion.ResumeLayout(false);
            this.panOperacion.PerformLayout();
            this.panZona.ResumeLayout(false);
            this.panZona.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgActividades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgMapeo;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.grbBase grbDetalle;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtNumRea txtPuntaje;
        private GEN.ControlesBase.dtgBase dtgActividades;
        private GEN.ControlesBase.cboBase cboCalificRiesgo;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.ControlesBase.cboTipoMapeoSPLAFT cboTipoMapeoSPLAFT1;
        private GEN.ControlesBase.cboBase cboProductos;
        private System.Windows.Forms.Panel panZona;
        private GEN.ControlesBase.cboUbigeo cboDep;
        private GEN.ControlesBase.cboUbigeo cboProvincia;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase5;
        private System.Windows.Forms.Panel panOperacion;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.cboTipoOperacion cboTipoOperacion1;
        private GEN.ControlesBase.cboModulo cboModulo1;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.BotonesBase.btnEliminar btnEliminar1;

    }
}