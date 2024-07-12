namespace GEN.ControlesBase
{
    partial class frmBusquedaCatalogo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBusquedaCatalogo));
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.dtgDetalleCatalogo = new GEN.ControlesBase.dtgBase(this.components);
            this.txtBuscar = new GEN.ControlesBase.txtBase(this.components);
            this.cboSubTipoBien = new GEN.ControlesBase.cboGrupoCatalogo(this.components);
            this.cboGrupoBien = new GEN.ControlesBase.cboGrupoCatalogo(this.components);
            this.cboTipoBien = new GEN.ControlesBase.cboTipoBien(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.cboUnidadMedida = new GEN.ControlesBase.cboUnidadMedida(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.cboSubGrupo = new GEN.ControlesBase.cboGrupoCatalogo(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleCatalogo)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(11, 66);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(47, 13);
            this.lblBase3.TabIndex = 20;
            this.lblBase3.Text = "Grupo:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(11, 41);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(62, 13);
            this.lblBase2.TabIndex = 19;
            this.lblBase2.Text = "Sub Tipo:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(11, 16);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(36, 13);
            this.lblBase1.TabIndex = 18;
            this.lblBase1.Text = "Tipo:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(6, 17);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(68, 13);
            this.lblBase5.TabIndex = 26;
            this.lblBase5.Text = "Búsqueda:";
            // 
            // dtgDetalleCatalogo
            // 
            this.dtgDetalleCatalogo.AllowUserToAddRows = false;
            this.dtgDetalleCatalogo.AllowUserToDeleteRows = false;
            this.dtgDetalleCatalogo.AllowUserToResizeColumns = false;
            this.dtgDetalleCatalogo.AllowUserToResizeRows = false;
            this.dtgDetalleCatalogo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetalleCatalogo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalleCatalogo.Location = new System.Drawing.Point(6, 37);
            this.dtgDetalleCatalogo.MultiSelect = false;
            this.dtgDetalleCatalogo.Name = "dtgDetalleCatalogo";
            this.dtgDetalleCatalogo.ReadOnly = true;
            this.dtgDetalleCatalogo.RowHeadersVisible = false;
            this.dtgDetalleCatalogo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetalleCatalogo.Size = new System.Drawing.Size(651, 200);
            this.dtgDetalleCatalogo.TabIndex = 27;
            this.dtgDetalleCatalogo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDetalleCatalogo_CellDoubleClick);
            this.dtgDetalleCatalogo.SelectionChanged += new System.EventHandler(this.dtgDetalleCatalogo_SelectionChanged);
            this.dtgDetalleCatalogo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgDetalleCatalogo_KeyDown);
            // 
            // txtBuscar
            // 
            this.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscar.Enabled = false;
            this.txtBuscar.Location = new System.Drawing.Point(80, 14);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(318, 20);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCatalogo_KeyPress);
            // 
            // cboSubTipoBien
            // 
            this.cboSubTipoBien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubTipoBien.FormattingEnabled = true;
            this.cboSubTipoBien.Location = new System.Drawing.Point(90, 37);
            this.cboSubTipoBien.Name = "cboSubTipoBien";
            this.cboSubTipoBien.Size = new System.Drawing.Size(316, 21);
            this.cboSubTipoBien.TabIndex = 1;
            this.cboSubTipoBien.SelectedIndexChanged += new System.EventHandler(this.cboSubTipoBien_SelectedIndexChanged);
            // 
            // cboGrupoBien
            // 
            this.cboGrupoBien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrupoBien.FormattingEnabled = true;
            this.cboGrupoBien.Location = new System.Drawing.Point(90, 62);
            this.cboGrupoBien.Name = "cboGrupoBien";
            this.cboGrupoBien.Size = new System.Drawing.Size(316, 21);
            this.cboGrupoBien.TabIndex = 2;
            this.cboGrupoBien.SelectedIndexChanged += new System.EventHandler(this.cboGrupoBien_SelectedIndexChanged);
            // 
            // cboTipoBien
            // 
            this.cboTipoBien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoBien.FormattingEnabled = true;
            this.cboTipoBien.Location = new System.Drawing.Point(90, 12);
            this.cboTipoBien.Name = "cboTipoBien";
            this.cboTipoBien.Size = new System.Drawing.Size(316, 21);
            this.cboTipoBien.TabIndex = 0;
            this.cboTipoBien.SelectedIndexChanged += new System.EventHandler(this.cboTipoBien_SelectedIndexChanged);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(602, 363);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(536, 363);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.dtgDetalleCatalogo);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.txtBuscar);
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(8, 114);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(663, 243);
            this.grbBase1.TabIndex = 41;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Detalle";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(266, 366);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(113, 13);
            this.lblBase6.TabIndex = 39;
            this.lblBase6.Text = "Unidad de Medida:";
            // 
            // cboUnidadMedida
            // 
            this.cboUnidadMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUnidadMedida.FormattingEnabled = true;
            this.cboUnidadMedida.Location = new System.Drawing.Point(385, 363);
            this.cboUnidadMedida.Name = "cboUnidadMedida";
            this.cboUnidadMedida.Size = new System.Drawing.Size(145, 21);
            this.cboUnidadMedida.TabIndex = 42;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(11, 91);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(73, 13);
            this.lblBase4.TabIndex = 43;
            this.lblBase4.Text = "Sub Grupo:";
            // 
            // cboSubGrupo
            // 
            this.cboSubGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubGrupo.FormattingEnabled = true;
            this.cboSubGrupo.Location = new System.Drawing.Point(90, 87);
            this.cboSubGrupo.Name = "cboSubGrupo";
            this.cboSubGrupo.Size = new System.Drawing.Size(316, 21);
            this.cboSubGrupo.TabIndex = 3;
            this.cboSubGrupo.SelectedIndexChanged += new System.EventHandler(this.cboSubGrupo_SelectedIndexChanged);
            // 
            // frmBusquedaCatalogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 446);
            this.Controls.Add(this.cboSubGrupo);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.cboUnidadMedida);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.cboTipoBien);
            this.Controls.Add(this.cboGrupoBien);
            this.Controls.Add(this.cboSubTipoBien);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Name = "frmBusquedaCatalogo";
            this.Text = "Busqueda de Catálogo";
            this.Load += new System.EventHandler(this.frmBusquedaCatalogo_Load);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.cboSubTipoBien, 0);
            this.Controls.SetChildIndex(this.cboGrupoBien, 0);
            this.Controls.SetChildIndex(this.cboTipoBien, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.cboUnidadMedida, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.cboSubGrupo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleCatalogo)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private lblBase lblBase3;
        private lblBase lblBase2;
        private lblBase lblBase1;
        private lblBase lblBase5;
        private dtgBase dtgDetalleCatalogo;
        private txtBase txtBuscar;
        private cboGrupoCatalogo cboSubTipoBien;
        private cboGrupoCatalogo cboGrupoBien;
        private cboTipoBien cboTipoBien;
        private BotonesBase.btnSalir btnSalir;
        private BotonesBase.BtnAceptar btnAceptar;
        private grbBase grbBase1;
        private lblBase lblBase6;
        private cboUnidadMedida cboUnidadMedida;
        private lblBase lblBase4;
        private cboGrupoCatalogo cboSubGrupo;
    }
}