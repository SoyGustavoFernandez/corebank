namespace SPL.Presentacion
{
    partial class frmMantenimientoEstrucMapeo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoEstrucMapeo));
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.cboActividades = new GEN.ControlesBase.cboBase(this.components);
            this.chcVigencia = new GEN.ControlesBase.chcBase(this.components);
            this.dtgActividades = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.cboTipoMapeoSPLAFT1 = new GEN.ControlesBase.cboTipoMapeoSPLAFT(this.components);
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgActividades)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(246, 317);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 28;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(312, 317);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 26;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Location = new System.Drawing.Point(48, 317);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 24;
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
            this.btnGrabar1.Location = new System.Drawing.Point(180, 317);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 25;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.cboActividades);
            this.grbBase1.Controls.Add(this.chcVigencia);
            this.grbBase1.Controls.Add(this.dtgActividades);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Location = new System.Drawing.Point(12, 39);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(360, 272);
            this.grbBase1.TabIndex = 29;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Actividades";
            // 
            // cboActividades
            // 
            this.cboActividades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboActividades.FormattingEnabled = true;
            this.cboActividades.Location = new System.Drawing.Point(6, 245);
            this.cboActividades.Name = "cboActividades";
            this.cboActividades.Size = new System.Drawing.Size(272, 21);
            this.cboActividades.TabIndex = 12;
            // 
            // chcVigencia
            // 
            this.chcVigencia.AutoSize = true;
            this.chcVigencia.Location = new System.Drawing.Point(284, 226);
            this.chcVigencia.Name = "chcVigencia";
            this.chcVigencia.Size = new System.Drawing.Size(67, 17);
            this.chcVigencia.TabIndex = 11;
            this.chcVigencia.Text = "Vigencia";
            this.chcVigencia.UseVisualStyleBackColor = true;
            // 
            // dtgActividades
            // 
            this.dtgActividades.AllowUserToAddRows = false;
            this.dtgActividades.AllowUserToDeleteRows = false;
            this.dtgActividades.AllowUserToResizeColumns = false;
            this.dtgActividades.AllowUserToResizeRows = false;
            this.dtgActividades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgActividades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgActividades.Location = new System.Drawing.Point(6, 19);
            this.dtgActividades.MultiSelect = false;
            this.dtgActividades.Name = "dtgActividades";
            this.dtgActividades.ReadOnly = true;
            this.dtgActividades.RowHeadersVisible = false;
            this.dtgActividades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgActividades.Size = new System.Drawing.Size(348, 201);
            this.dtgActividades.TabIndex = 0;
            this.dtgActividades.SelectionChanged += new System.EventHandler(this.dtgActividades_SelectionChanged);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(0, 226);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(128, 13);
            this.lblBase2.TabIndex = 6;
            this.lblBase2.Text = "Seleccione actividad:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(9, 15);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(77, 13);
            this.lblBase1.TabIndex = 6;
            this.lblBase1.Text = "Tipo Mapeo:";
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(114, 317);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 27;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // cboTipoMapeoSPLAFT1
            // 
            this.cboTipoMapeoSPLAFT1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoMapeoSPLAFT1.FormattingEnabled = true;
            this.cboTipoMapeoSPLAFT1.Location = new System.Drawing.Point(90, 12);
            this.cboTipoMapeoSPLAFT1.Name = "cboTipoMapeoSPLAFT1";
            this.cboTipoMapeoSPLAFT1.Size = new System.Drawing.Size(150, 21);
            this.cboTipoMapeoSPLAFT1.TabIndex = 30;
            this.cboTipoMapeoSPLAFT1.SelectedIndexChanged += new System.EventHandler(this.cboTipoMapeoSPLAFT1_SelectedIndexChanged);
            // 
            // frmMantenimientoEstrucMapeo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 392);
            this.Controls.Add(this.cboTipoMapeoSPLAFT1);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.btnGrabar1);
            this.Name = "frmMantenimientoEstrucMapeo";
            this.Text = "Mantenimiento estructura tablas";
            this.Load += new System.EventHandler(this.frmMantenimientoEstrucMapeo_Load);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.cboTipoMapeoSPLAFT1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgActividades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.cboBase cboActividades;
        private GEN.ControlesBase.chcBase chcVigencia;
        private GEN.ControlesBase.dtgBase dtgActividades;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.ControlesBase.cboTipoMapeoSPLAFT cboTipoMapeoSPLAFT1;
    }
}