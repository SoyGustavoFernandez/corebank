namespace CRE.Presentacion
{
    partial class frmListaDocObligatoriosCre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaDocObligatoriosCre));
            this.dtgListaSeleccionable = new GEN.ControlesBase.dtgBase(this.components);
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.conProducto1 = new GEN.ControlesBase.conProducto();
            this.cboTipoPersona1 = new GEN.ControlesBase.cboTipoPersona(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.btnBusqueda1 = new GEN.BotonesBase.btnBusqueda();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaSeleccionable)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgListaSeleccionable
            // 
            this.dtgListaSeleccionable.AllowUserToAddRows = false;
            this.dtgListaSeleccionable.AllowUserToDeleteRows = false;
            this.dtgListaSeleccionable.AllowUserToResizeColumns = false;
            this.dtgListaSeleccionable.AllowUserToResizeRows = false;
            this.dtgListaSeleccionable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgListaSeleccionable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaSeleccionable.Location = new System.Drawing.Point(10, 131);
            this.dtgListaSeleccionable.MultiSelect = false;
            this.dtgListaSeleccionable.Name = "dtgListaSeleccionable";
            this.dtgListaSeleccionable.ReadOnly = true;
            this.dtgListaSeleccionable.RowHeadersVisible = false;
            this.dtgListaSeleccionable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaSeleccionable.Size = new System.Drawing.Size(505, 383);
            this.dtgListaSeleccionable.TabIndex = 8;
            this.dtgListaSeleccionable.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgListaSeleccionable_CellValueChanged);
            this.dtgListaSeleccionable.CurrentCellDirtyStateChanged += new System.EventHandler(this.dtgListaSeleccionable_CurrentCellDirtyStateChanged);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(391, 521);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 4;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(456, 521);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 2;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(325, 521);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 5;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            // 
            // conProducto1
            // 
            this.conProducto1.AutoSize = true;
            this.conProducto1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conProducto1.lMostrarTipoCredito = true;
            this.conProducto1.Location = new System.Drawing.Point(10, 1);
            this.conProducto1.Name = "conProducto1";
            this.conProducto1.Size = new System.Drawing.Size(322, 92);
            this.conProducto1.TabIndex = 9;
            // 
            // cboTipoPersona1
            // 
            this.cboTipoPersona1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPersona1.FormattingEnabled = true;
            this.cboTipoPersona1.Location = new System.Drawing.Point(109, 95);
            this.cboTipoPersona1.Name = "cboTipoPersona1";
            this.cboTipoPersona1.Size = new System.Drawing.Size(217, 21);
            this.cboTipoPersona1.TabIndex = 10;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(21, 98);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(81, 13);
            this.lblBase2.TabIndex = 11;
            this.lblBase2.Text = "Tipo Persona";
            // 
            // btnBusqueda1
            // 
            this.btnBusqueda1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda1.BackgroundImage")));
            this.btnBusqueda1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda1.Location = new System.Drawing.Point(338, 66);
            this.btnBusqueda1.Name = "btnBusqueda1";
            this.btnBusqueda1.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda1.TabIndex = 12;
            this.btnBusqueda1.Text = "&Buscar";
            this.btnBusqueda1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda1.UseVisualStyleBackColor = true;
            this.btnBusqueda1.Click += new System.EventHandler(this.btnBusqueda1_Click);
            // 
            // frmListaDocObligatoriosCre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 602);
            this.Controls.Add(this.btnBusqueda1);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.cboTipoPersona1);
            this.Controls.Add(this.conProducto1);
            this.Controls.Add(this.dtgListaSeleccionable);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmListaDocObligatoriosCre";
            this.Text = "Check List - créditos";
            this.Load += new System.EventHandler(this.frmBase_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.dtgListaSeleccionable, 0);
            this.Controls.SetChildIndex(this.conProducto1, 0);
            this.Controls.SetChildIndex(this.cboTipoPersona1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.btnBusqueda1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaSeleccionable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.ControlesBase.dtgBase dtgListaSeleccionable;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.conProducto conProducto1;
        private GEN.ControlesBase.cboTipoPersona cboTipoPersona1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.BotonesBase.btnBusqueda btnBusqueda1;
    }
}

