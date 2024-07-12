namespace LOG.Presentacion
{
    partial class frmFamiliaCatalogo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFamiliaCatalogo));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgDetalleNS = new GEN.ControlesBase.dtgBase(this.components);
            this.idDetalleNotaSalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idUniMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUnidMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objCatalogo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nCantidadSol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nCantidadApro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lVigente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.cboSubGrupo = new GEN.ControlesBase.cboGrupoCatalogo(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.cboTipoBien = new GEN.ControlesBase.cboTipoBien(this.components);
            this.cboGrupoBien = new GEN.ControlesBase.cboGrupoCatalogo(this.components);
            this.cboSubTipoBien = new GEN.ControlesBase.cboGrupoCatalogo(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnMiniAgregar1 = new GEN.BotonesBase.btnMiniAgregar();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleNS)).BeginInit();
            this.grbBase2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.btnMiniAgregar1);
            this.grbBase1.Controls.Add(this.dtgDetalleNS);
            this.grbBase1.Location = new System.Drawing.Point(0, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(526, 179);
            this.grbBase1.TabIndex = 14;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Items:";
            // 
            // dtgDetalleNS
            // 
            this.dtgDetalleNS.AllowUserToAddRows = false;
            this.dtgDetalleNS.AllowUserToDeleteRows = false;
            this.dtgDetalleNS.AllowUserToResizeColumns = false;
            this.dtgDetalleNS.AllowUserToResizeRows = false;
            this.dtgDetalleNS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetalleNS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalleNS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDetalleNotaSalida,
            this.idUniMedida,
            this.cUnidMedida,
            this.objCatalogo,
            this.cProducto,
            this.nStock,
            this.nCantidadSol,
            this.nCantidadApro,
            this.lVigente});
            this.dtgDetalleNS.Location = new System.Drawing.Point(10, 34);
            this.dtgDetalleNS.MultiSelect = false;
            this.dtgDetalleNS.Name = "dtgDetalleNS";
            this.dtgDetalleNS.ReadOnly = true;
            this.dtgDetalleNS.RowHeadersVisible = false;
            this.dtgDetalleNS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgDetalleNS.Size = new System.Drawing.Size(510, 139);
            this.dtgDetalleNS.TabIndex = 5;
            // 
            // idDetalleNotaSalida
            // 
            this.idDetalleNotaSalida.DataPropertyName = "idDetalleNotaSalida";
            this.idDetalleNotaSalida.HeaderText = "idDetalleNotaSalida";
            this.idDetalleNotaSalida.Name = "idDetalleNotaSalida";
            this.idDetalleNotaSalida.ReadOnly = true;
            this.idDetalleNotaSalida.Visible = false;
            // 
            // idUniMedida
            // 
            this.idUniMedida.DataPropertyName = "idUniMedida";
            this.idUniMedida.HeaderText = "idUnidaMedida";
            this.idUniMedida.Name = "idUniMedida";
            this.idUniMedida.ReadOnly = true;
            this.idUniMedida.Visible = false;
            // 
            // cUnidMedida
            // 
            this.cUnidMedida.DataPropertyName = "cUnidMedida";
            this.cUnidMedida.FillWeight = 50F;
            this.cUnidMedida.HeaderText = "Uni. Medida";
            this.cUnidMedida.Name = "cUnidMedida";
            this.cUnidMedida.ReadOnly = true;
            // 
            // objCatalogo
            // 
            this.objCatalogo.DataPropertyName = "objCatalogo";
            this.objCatalogo.HeaderText = "objCatalogo";
            this.objCatalogo.Name = "objCatalogo";
            this.objCatalogo.ReadOnly = true;
            this.objCatalogo.Visible = false;
            // 
            // cProducto
            // 
            this.cProducto.DataPropertyName = "cProducto";
            this.cProducto.FillWeight = 150F;
            this.cProducto.HeaderText = "Producto";
            this.cProducto.Name = "cProducto";
            this.cProducto.ReadOnly = true;
            // 
            // nStock
            // 
            this.nStock.DataPropertyName = "nStock";
            this.nStock.HeaderText = "Stock";
            this.nStock.Name = "nStock";
            this.nStock.ReadOnly = true;
            this.nStock.Visible = false;
            // 
            // nCantidadSol
            // 
            this.nCantidadSol.DataPropertyName = "nCantidadSol";
            this.nCantidadSol.FillWeight = 50F;
            this.nCantidadSol.HeaderText = "Cantidad";
            this.nCantidadSol.Name = "nCantidadSol";
            this.nCantidadSol.ReadOnly = true;
            // 
            // nCantidadApro
            // 
            this.nCantidadApro.DataPropertyName = "nCantidadApro";
            this.nCantidadApro.HeaderText = "nCantidadApro";
            this.nCantidadApro.Name = "nCantidadApro";
            this.nCantidadApro.ReadOnly = true;
            this.nCantidadApro.Visible = false;
            // 
            // lVigente
            // 
            this.lVigente.DataPropertyName = "lVigente";
            this.lVigente.HeaderText = "lVigente";
            this.lVigente.Name = "lVigente";
            this.lVigente.ReadOnly = true;
            this.lVigente.Visible = false;
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.cboSubGrupo);
            this.grbBase2.Controls.Add(this.lblBase4);
            this.grbBase2.Controls.Add(this.cboTipoBien);
            this.grbBase2.Controls.Add(this.cboGrupoBien);
            this.grbBase2.Controls.Add(this.cboSubTipoBien);
            this.grbBase2.Controls.Add(this.lblBase3);
            this.grbBase2.Controls.Add(this.lblBase2);
            this.grbBase2.Controls.Add(this.lblBase1);
            this.grbBase2.Location = new System.Drawing.Point(10, 197);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(516, 124);
            this.grbBase2.TabIndex = 15;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Familia de Bienes";
            // 
            // cboSubGrupo
            // 
            this.cboSubGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubGrupo.FormattingEnabled = true;
            this.cboSubGrupo.Location = new System.Drawing.Point(194, 94);
            this.cboSubGrupo.Name = "cboSubGrupo";
            this.cboSubGrupo.Size = new System.Drawing.Size(316, 21);
            this.cboSubGrupo.TabIndex = 47;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(115, 98);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(73, 13);
            this.lblBase4.TabIndex = 51;
            this.lblBase4.Text = "Sub Grupo:";
            // 
            // cboTipoBien
            // 
            this.cboTipoBien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoBien.FormattingEnabled = true;
            this.cboTipoBien.Location = new System.Drawing.Point(194, 19);
            this.cboTipoBien.Name = "cboTipoBien";
            this.cboTipoBien.Size = new System.Drawing.Size(316, 21);
            this.cboTipoBien.TabIndex = 44;
            this.cboTipoBien.SelectedIndexChanged += new System.EventHandler(this.cboTipoBien_SelectedIndexChanged);
            // 
            // cboGrupoBien
            // 
            this.cboGrupoBien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrupoBien.FormattingEnabled = true;
            this.cboGrupoBien.Location = new System.Drawing.Point(194, 69);
            this.cboGrupoBien.Name = "cboGrupoBien";
            this.cboGrupoBien.Size = new System.Drawing.Size(316, 21);
            this.cboGrupoBien.TabIndex = 46;
            this.cboGrupoBien.SelectedIndexChanged += new System.EventHandler(this.cboGrupoBien_SelectedIndexChanged);
            // 
            // cboSubTipoBien
            // 
            this.cboSubTipoBien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubTipoBien.FormattingEnabled = true;
            this.cboSubTipoBien.Location = new System.Drawing.Point(194, 44);
            this.cboSubTipoBien.Name = "cboSubTipoBien";
            this.cboSubTipoBien.Size = new System.Drawing.Size(316, 21);
            this.cboSubTipoBien.TabIndex = 45;
            this.cboSubTipoBien.SelectedIndexChanged += new System.EventHandler(this.cboSubTipoBien_SelectedIndexChanged);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(115, 73);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(47, 13);
            this.lblBase3.TabIndex = 50;
            this.lblBase3.Text = "Grupo:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(115, 48);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(62, 13);
            this.lblBase2.TabIndex = 49;
            this.lblBase2.Text = "Sub Tipo:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(115, 23);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(36, 13);
            this.lblBase1.TabIndex = 48;
            this.lblBase1.Text = "Tipo:";
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(400, 327);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 16;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(466, 327);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 17;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnMiniAgregar1
            // 
            this.btnMiniAgregar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniAgregar1.BackgroundImage")));
            this.btnMiniAgregar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniAgregar1.Location = new System.Drawing.Point(480, 0);
            this.btnMiniAgregar1.Name = "btnMiniAgregar1";
            this.btnMiniAgregar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniAgregar1.TabIndex = 6;
            this.btnMiniAgregar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniAgregar1.UseVisualStyleBackColor = true;
            this.btnMiniAgregar1.Click += new System.EventHandler(this.btnMiniAgregar1_Click);
            // 
            // frmFamiliaCatalogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 409);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmFamiliaCatalogo";
            this.Text = "frmFamiliaCatalogo";
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.grbBase1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleNS)).EndInit();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.dtgBase dtgDetalleNS;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDetalleNotaSalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUniMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUnidMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn objCatalogo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn nStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn nCantidadSol;
        private System.Windows.Forms.DataGridViewTextBoxColumn nCantidadApro;
        private System.Windows.Forms.DataGridViewTextBoxColumn lVigente;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.cboGrupoCatalogo cboSubGrupo;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.cboTipoBien cboTipoBien;
        private GEN.ControlesBase.cboGrupoCatalogo cboGrupoBien;
        private GEN.ControlesBase.cboGrupoCatalogo cboSubTipoBien;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnMiniAgregar btnMiniAgregar1;
    }
}