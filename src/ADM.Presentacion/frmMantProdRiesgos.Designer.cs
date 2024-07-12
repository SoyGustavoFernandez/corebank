namespace ADM.Presentacion
{
    partial class frmMantProdRiesgos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantProdRiesgos));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtgBase1 = new GEN.ControlesBase.dtgBase(this.components);
            this.cboTipEvalCred1 = new GEN.ControlesBase.cboTipEvalCred(this.components);
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.bindingSourceProductos = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgBase1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 19);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(119, 13);
            this.lblBase1.TabIndex = 3;
            this.lblBase1.Text = "Tipo de Evaluación:";
            // 
            // dtgBase1
            // 
            this.dtgBase1.AllowUserToAddRows = false;
            this.dtgBase1.AllowUserToDeleteRows = false;
            this.dtgBase1.AllowUserToResizeColumns = false;
            this.dtgBase1.AllowUserToResizeRows = false;
            this.dtgBase1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgBase1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBase1.Location = new System.Drawing.Point(15, 43);
            this.dtgBase1.MultiSelect = false;
            this.dtgBase1.Name = "dtgBase1";
            this.dtgBase1.ReadOnly = true;
            this.dtgBase1.RowHeadersVisible = false;
            this.dtgBase1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgBase1.Size = new System.Drawing.Size(552, 454);
            this.dtgBase1.TabIndex = 6;
            // 
            // cboTipEvalCred1
            // 
            this.cboTipEvalCred1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipEvalCred1.FormattingEnabled = true;
            this.cboTipEvalCred1.Location = new System.Drawing.Point(146, 16);
            this.cboTipEvalCred1.Name = "cboTipEvalCred1";
            this.cboTipEvalCred1.Size = new System.Drawing.Size(220, 21);
            this.cboTipEvalCred1.TabIndex = 7;
            this.cboTipEvalCred1.SelectedValueChanged += new System.EventHandler(this.cboTipEvalCred1_SelectedValueChanged);
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(322, 503);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 8;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(519, 503);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 9;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(388, 503);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 10;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(453, 503);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 11;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // frmMantProdRiesgos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 578);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.cboTipEvalCred1);
            this.Controls.Add(this.dtgBase1);
            this.Controls.Add(this.lblBase1);
            this.Name = "frmMantProdRiesgos";
            this.Text = "Mantenimiento de Opinión Riesgos";
            this.Load += new System.EventHandler(this.frmMantProdRiesgos_Load);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.dtgBase1, 0);
            this.Controls.SetChildIndex(this.cboTipEvalCred1, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgBase1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.dtgBase dtgBase1;
        private GEN.ControlesBase.cboTipEvalCred cboTipEvalCred1;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private System.Windows.Forms.BindingSource bindingSourceProductos;
    }
}