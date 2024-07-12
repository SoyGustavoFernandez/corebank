namespace CRE.Presentacion
{
    partial class frmExpedientesArchivar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExpedientesArchivar));
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.dtgListaExpRecib = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.chcTodos = new GEN.ControlesBase.chcBase(this.components);
            this.dtgDetalleExp = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.txtCBObservacion = new GEN.ControlesBase.txtCBLetra(this.components);
            this.cboPerfilesExp = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaExpRecib)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleExp)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase7
            // 
            this.lblBase7.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblBase7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(10, 5);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(523, 19);
            this.lblBase7.TabIndex = 84;
            this.lblBase7.Text = "EXPEDIENTES PARA ARCHIVAR";
            this.lblBase7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dtgListaExpRecib
            // 
            this.dtgListaExpRecib.AllowUserToAddRows = false;
            this.dtgListaExpRecib.AllowUserToDeleteRows = false;
            this.dtgListaExpRecib.AllowUserToResizeColumns = false;
            this.dtgListaExpRecib.AllowUserToResizeRows = false;
            this.dtgListaExpRecib.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgListaExpRecib.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaExpRecib.Location = new System.Drawing.Point(10, 51);
            this.dtgListaExpRecib.MultiSelect = false;
            this.dtgListaExpRecib.Name = "dtgListaExpRecib";
            this.dtgListaExpRecib.ReadOnly = true;
            this.dtgListaExpRecib.RowHeadersVisible = false;
            this.dtgListaExpRecib.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaExpRecib.Size = new System.Drawing.Size(523, 200);
            this.dtgListaExpRecib.TabIndex = 83;
            this.dtgListaExpRecib.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgListaExpRecib_CellContentClick);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(471, 570);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 88;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(405, 570);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 87;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(339, 570);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 86;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // chcTodos
            // 
            this.chcTodos.AutoSize = true;
            this.chcTodos.Location = new System.Drawing.Point(8, 255);
            this.chcTodos.Name = "chcTodos";
            this.chcTodos.Size = new System.Drawing.Size(56, 17);
            this.chcTodos.TabIndex = 89;
            this.chcTodos.Text = "Todos";
            this.chcTodos.UseVisualStyleBackColor = true;
            this.chcTodos.CheckedChanged += new System.EventHandler(this.chcTodos_CheckedChanged);
            // 
            // dtgDetalleExp
            // 
            this.dtgDetalleExp.AllowUserToAddRows = false;
            this.dtgDetalleExp.AllowUserToDeleteRows = false;
            this.dtgDetalleExp.AllowUserToResizeColumns = false;
            this.dtgDetalleExp.AllowUserToResizeRows = false;
            this.dtgDetalleExp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgDetalleExp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalleExp.Location = new System.Drawing.Point(12, 19);
            this.dtgDetalleExp.MultiSelect = false;
            this.dtgDetalleExp.Name = "dtgDetalleExp";
            this.dtgDetalleExp.ReadOnly = true;
            this.dtgDetalleExp.RowHeadersVisible = false;
            this.dtgDetalleExp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetalleExp.Size = new System.Drawing.Size(523, 204);
            this.dtgDetalleExp.TabIndex = 90;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.dtgDetalleExp);
            this.grbBase1.Location = new System.Drawing.Point(-2, 278);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(543, 230);
            this.grbBase1.TabIndex = 91;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Detalle del expediente";
            // 
            // txtCBObservacion
            // 
            this.txtCBObservacion.Location = new System.Drawing.Point(10, 518);
            this.txtCBObservacion.MaxLength = 200;
            this.txtCBObservacion.Multiline = true;
            this.txtCBObservacion.Name = "txtCBObservacion";
            this.txtCBObservacion.Size = new System.Drawing.Size(523, 47);
            this.txtCBObservacion.TabIndex = 92;
            // 
            // cboPerfilesExp
            // 
            this.cboPerfilesExp.FormattingEnabled = true;
            this.cboPerfilesExp.Location = new System.Drawing.Point(126, 27);
            this.cboPerfilesExp.Name = "cboPerfilesExp";
            this.cboPerfilesExp.Size = new System.Drawing.Size(277, 21);
            this.cboPerfilesExp.TabIndex = 93;
            this.cboPerfilesExp.SelectedIndexChanged += new System.EventHandler(this.cboBase1_SelectedIndexChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(10, 31);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(114, 13);
            this.lblBase1.TabIndex = 94;
            this.lblBase1.Text = "Filtrar Por Perfiles:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(10, 504);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(96, 13);
            this.lblBase2.TabIndex = 94;
            this.lblBase2.Text = "Observaciones:";
            // 
            // frmExpedientesArchivar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 646);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.cboPerfilesExp);
            this.Controls.Add(this.txtCBObservacion);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.chcTodos);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.dtgListaExpRecib);
            this.Name = "frmExpedientesArchivar";
            this.Text = "Archivar Expedientes";
            this.Load += new System.EventHandler(this.ExpedientesArchivar_Load);
            this.Controls.SetChildIndex(this.dtgListaExpRecib, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.chcTodos, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.txtCBObservacion, 0);
            this.Controls.SetChildIndex(this.cboPerfilesExp, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaExpRecib)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleExp)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.dtgBase dtgListaExpRecib;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.ControlesBase.chcBase chcTodos;
        private GEN.ControlesBase.dtgBase dtgDetalleExp;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.txtCBLetra txtCBObservacion;
        private GEN.ControlesBase.cboBase cboPerfilesExp;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;

    }
}