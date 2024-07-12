namespace CRE.Presentacion
{
    partial class frmVincGrupoCategoriaOfi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVincGrupoCategoriaOfi));
            this.dtgVincGrupoCateOfi = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.cboPeriodoCateOfi1 = new GEN.ControlesBase.cboPeriodoCateOfi(this.components);
            this.lblValor = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            ((System.ComponentModel.ISupportInitialize)(this.dtgVincGrupoCateOfi)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgVincGrupoCateOfi
            // 
            this.dtgVincGrupoCateOfi.AllowUserToAddRows = false;
            this.dtgVincGrupoCateOfi.AllowUserToDeleteRows = false;
            this.dtgVincGrupoCateOfi.AllowUserToResizeColumns = false;
            this.dtgVincGrupoCateOfi.AllowUserToResizeRows = false;
            this.dtgVincGrupoCateOfi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgVincGrupoCateOfi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgVincGrupoCateOfi.Location = new System.Drawing.Point(10, 19);
            this.dtgVincGrupoCateOfi.MultiSelect = false;
            this.dtgVincGrupoCateOfi.Name = "dtgVincGrupoCateOfi";
            this.dtgVincGrupoCateOfi.ReadOnly = true;
            this.dtgVincGrupoCateOfi.RowHeadersVisible = false;
            this.dtgVincGrupoCateOfi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgVincGrupoCateOfi.Size = new System.Drawing.Size(656, 369);
            this.dtgVincGrupoCateOfi.TabIndex = 0;
            this.dtgVincGrupoCateOfi.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dtgVincGrupoCateOfi_CellBeginEdit);
            this.dtgVincGrupoCateOfi.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgVincGrupoCateOfi_CellEndEdit);
            this.dtgVincGrupoCateOfi.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dtgVincGrupoCateOfi_CellValidating);
            this.dtgVincGrupoCateOfi.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgVincGrupoCateOfi_CellValueChanged_1);
            this.dtgVincGrupoCateOfi.CurrentCellDirtyStateChanged += new System.EventHandler(this.dtgVincGrupoCateOfi_CurrentCellDirtyStateChanged);
            this.dtgVincGrupoCateOfi.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgVincGrupoCateOfi_DataError);
            this.dtgVincGrupoCateOfi.SelectionChanged += new System.EventHandler(this.dtgVincGrupoCateOfi_SelectionChanged);
            this.dtgVincGrupoCateOfi.Sorted += new System.EventHandler(this.dtgVincGrupoCateOfi_Sorted);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.cboPeriodoCateOfi1);
            this.grbBase1.Controls.Add(this.lblValor);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Location = new System.Drawing.Point(12, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(679, 67);
            this.grbBase1.TabIndex = 1;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Periodo de Categorizacion";
            // 
            // cboPeriodoCateOfi1
            // 
            this.cboPeriodoCateOfi1.FormattingEnabled = true;
            this.cboPeriodoCateOfi1.Location = new System.Drawing.Point(158, 27);
            this.cboPeriodoCateOfi1.Name = "cboPeriodoCateOfi1";
            this.cboPeriodoCateOfi1.Size = new System.Drawing.Size(216, 21);
            this.cboPeriodoCateOfi1.TabIndex = 0;
            this.cboPeriodoCateOfi1.SelectedIndexChanged += new System.EventHandler(this.cboPeriodoCateOfi1_SelectedIndexChanged);
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.lblValor.ForeColor = System.Drawing.Color.Navy;
            this.lblValor.Location = new System.Drawing.Point(381, 30);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(13, 13);
            this.lblValor.TabIndex = 1;
            this.lblValor.Text = "-";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(7, 30);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(145, 13);
            this.lblBase1.TabIndex = 3;
            this.lblBase1.Text = "Periodo de clasificación:";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.dtgVincGrupoCateOfi);
            this.grbBase2.Location = new System.Drawing.Point(12, 85);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(679, 395);
            this.grbBase2.TabIndex = 2;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Configuracion de Condiciones de Categorizacion";
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(431, 501);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 3;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(497, 501);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 4;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(564, 501);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 5;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(630, 501);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 6;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // frmVincGrupoCategoriaOfi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 578);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmVincGrupoCategoriaOfi";
            this.Text = "frmVincGrupoCategoriaOfi";
            this.Load += new System.EventHandler(this.frmVincGrupoCategoriaOfi_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgVincGrupoCateOfi)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgVincGrupoCateOfi;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.lblBaseCustom lblValor;
        private GEN.ControlesBase.cboPeriodoCateOfi cboPeriodoCateOfi1;
    }
}