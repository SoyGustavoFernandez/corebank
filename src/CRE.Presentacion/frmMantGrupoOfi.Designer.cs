namespace CRE.Presentacion
{
    partial class frmMantGrupoOfi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantGrupoOfi));
            this.dtgGrupoCatOfi = new GEN.ControlesBase.dtgBase(this.components);
            this.btnMiniAgregar1 = new GEN.BotonesBase.btnMiniAgregar();
            this.btnMiniQuitar1 = new GEN.BotonesBase.btnMiniQuitar();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboPeriodoCateOfi1 = new GEN.ControlesBase.cboPeriodoCateOfi(this.components);
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.lblValor = new GEN.ControlesBase.lblBaseCustom(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgGrupoCatOfi)).BeginInit();
            this.grbBase2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgGrupoCatOfi
            // 
            this.dtgGrupoCatOfi.AllowUserToAddRows = false;
            this.dtgGrupoCatOfi.AllowUserToDeleteRows = false;
            this.dtgGrupoCatOfi.AllowUserToResizeColumns = false;
            this.dtgGrupoCatOfi.AllowUserToResizeRows = false;
            this.dtgGrupoCatOfi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgGrupoCatOfi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgGrupoCatOfi.Location = new System.Drawing.Point(6, 19);
            this.dtgGrupoCatOfi.MultiSelect = false;
            this.dtgGrupoCatOfi.Name = "dtgGrupoCatOfi";
            this.dtgGrupoCatOfi.ReadOnly = true;
            this.dtgGrupoCatOfi.RowHeadersVisible = false;
            this.dtgGrupoCatOfi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgGrupoCatOfi.Size = new System.Drawing.Size(566, 204);
            this.dtgGrupoCatOfi.TabIndex = 2;
            this.dtgGrupoCatOfi.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dtgGrupoCatOfi_CellBeginEdit);
            this.dtgGrupoCatOfi.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgGrupoCatOfi_CellEndEdit);
            this.dtgGrupoCatOfi.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dtgGrupoCatOfi_CellValidating);
            this.dtgGrupoCatOfi.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgGrupoCatOfi_CellValueChanged);
            this.dtgGrupoCatOfi.CurrentCellDirtyStateChanged += new System.EventHandler(this.dtgGrupoCatOfi_CurrentCellDirtyStateChanged);
            this.dtgGrupoCatOfi.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgGrupoCatOfi_DataError);
            this.dtgGrupoCatOfi.SelectionChanged += new System.EventHandler(this.dtgGrupoCatOfi_SelectionChanged);
            // 
            // btnMiniAgregar1
            // 
            this.btnMiniAgregar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniAgregar1.BackgroundImage")));
            this.btnMiniAgregar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniAgregar1.Location = new System.Drawing.Point(578, 19);
            this.btnMiniAgregar1.Name = "btnMiniAgregar1";
            this.btnMiniAgregar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniAgregar1.TabIndex = 3;
            this.btnMiniAgregar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniAgregar1.UseVisualStyleBackColor = true;
            this.btnMiniAgregar1.Click += new System.EventHandler(this.btnMiniAgregar1_Click);
            // 
            // btnMiniQuitar1
            // 
            this.btnMiniQuitar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniQuitar1.BackgroundImage")));
            this.btnMiniQuitar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniQuitar1.Location = new System.Drawing.Point(578, 53);
            this.btnMiniQuitar1.Name = "btnMiniQuitar1";
            this.btnMiniQuitar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniQuitar1.TabIndex = 4;
            this.btnMiniQuitar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniQuitar1.UseVisualStyleBackColor = true;
            this.btnMiniQuitar1.Click += new System.EventHandler(this.btnMiniQuitar1_Click);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(15, 15);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(55, 13);
            this.lblBase5.TabIndex = 15;
            this.lblBase5.Text = "Periodo:";
            // 
            // cboPeriodoCateOfi1
            // 
            this.cboPeriodoCateOfi1.FormattingEnabled = true;
            this.cboPeriodoCateOfi1.Location = new System.Drawing.Point(91, 12);
            this.cboPeriodoCateOfi1.Name = "cboPeriodoCateOfi1";
            this.cboPeriodoCateOfi1.Size = new System.Drawing.Size(180, 21);
            this.cboPeriodoCateOfi1.TabIndex = 13;
            this.cboPeriodoCateOfi1.SelectedIndexChanged += new System.EventHandler(this.cboPeriodoCateOfi1_SelectedIndexChanged);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(444, 274);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 7;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(577, 274);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 8;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(510, 274);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 9;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.dtgGrupoCatOfi);
            this.grbBase2.Controls.Add(this.btnMiniAgregar1);
            this.grbBase2.Controls.Add(this.btnMiniQuitar1);
            this.grbBase2.Location = new System.Drawing.Point(12, 39);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(624, 229);
            this.grbBase2.TabIndex = 10;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Grupos de Categorizacion de Oficinas";
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(378, 274);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 11;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValor.ForeColor = System.Drawing.Color.Navy;
            this.lblValor.Location = new System.Drawing.Point(277, 15);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(13, 13);
            this.lblValor.TabIndex = 16;
            this.lblValor.Text = "-";
            // 
            // frmMantGrupoOfi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 357);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.cboPeriodoCateOfi1);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnGrabar1);
            this.Name = "frmMantGrupoOfi";
            this.Text = "Mantenimiento de Grupos";
            this.Load += new System.EventHandler(this.frmMantGrupoOfi_Load);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.cboPeriodoCateOfi1, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.lblValor, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgGrupoCatOfi)).EndInit();
            this.grbBase2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgGrupoCatOfi;
        private GEN.BotonesBase.btnMiniAgregar btnMiniAgregar1;
        private GEN.BotonesBase.btnMiniQuitar btnMiniQuitar1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.ControlesBase.cboPeriodoCateOfi cboPeriodoCateOfi1;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBaseCustom lblValor;
    }
}