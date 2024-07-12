namespace CRE.Presentacion
{
    partial class frmReglasGrupo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReglasGrupo));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgGrupo = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgSolicitudes = new GEN.ControlesBase.dtgBase(this.components);
            this.bindingSolicitudes = new System.Windows.Forms.BindingSource(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.bindingGrupo = new System.Windows.Forms.BindingSource(this.components);
            this.btnDetalle1 = new GEN.BotonesBase.btnDetalle();
            this.btnActualizar1 = new GEN.BotonesBase.btnActualizar();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGrupo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolicitudes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSolicitudes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingGrupo)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.dtgGrupo);
            this.grbBase1.Controls.Add(this.dtgSolicitudes);
            this.grbBase1.Location = new System.Drawing.Point(0, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(610, 233);
            this.grbBase1.TabIndex = 2;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Detalle de solicitud individual y grupo";
            // 
            // dtgGrupo
            // 
            this.dtgGrupo.AllowUserToAddRows = false;
            this.dtgGrupo.AllowUserToDeleteRows = false;
            this.dtgGrupo.AllowUserToResizeColumns = false;
            this.dtgGrupo.AllowUserToResizeRows = false;
            this.dtgGrupo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgGrupo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgGrupo.Enabled = false;
            this.dtgGrupo.Location = new System.Drawing.Point(9, 185);
            this.dtgGrupo.MultiSelect = false;
            this.dtgGrupo.Name = "dtgGrupo";
            this.dtgGrupo.ReadOnly = true;
            this.dtgGrupo.RowHeadersVisible = false;
            this.dtgGrupo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgGrupo.Size = new System.Drawing.Size(595, 41);
            this.dtgGrupo.TabIndex = 4;
            this.dtgGrupo.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgGrupo_DataBindingComplete);
            // 
            // dtgSolicitudes
            // 
            this.dtgSolicitudes.AllowUserToAddRows = false;
            this.dtgSolicitudes.AllowUserToDeleteRows = false;
            this.dtgSolicitudes.AllowUserToResizeColumns = false;
            this.dtgSolicitudes.AllowUserToResizeRows = false;
            this.dtgSolicitudes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSolicitudes.Location = new System.Drawing.Point(9, 19);
            this.dtgSolicitudes.MultiSelect = false;
            this.dtgSolicitudes.Name = "dtgSolicitudes";
            this.dtgSolicitudes.ReadOnly = true;
            this.dtgSolicitudes.RowHeadersVisible = false;
            this.dtgSolicitudes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSolicitudes.Size = new System.Drawing.Size(595, 160);
            this.dtgSolicitudes.TabIndex = 3;
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(544, 251);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 11;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnDetalle1
            // 
            this.btnDetalle1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDetalle1.BackgroundImage")));
            this.btnDetalle1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDetalle1.Location = new System.Drawing.Point(9, 251);
            this.btnDetalle1.Name = "btnDetalle1";
            this.btnDetalle1.Size = new System.Drawing.Size(60, 50);
            this.btnDetalle1.TabIndex = 13;
            this.btnDetalle1.Text = "&Detallar";
            this.btnDetalle1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDetalle1.texto = "&Detallar";
            this.btnDetalle1.UseVisualStyleBackColor = true;
            this.btnDetalle1.Click += new System.EventHandler(this.btnDetalle1_Click);
            // 
            // btnActualizar1
            // 
            this.btnActualizar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnActualizar1.BackgroundImage")));
            this.btnActualizar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnActualizar1.Location = new System.Drawing.Point(478, 251);
            this.btnActualizar1.Name = "btnActualizar1";
            this.btnActualizar1.Size = new System.Drawing.Size(60, 50);
            this.btnActualizar1.TabIndex = 14;
            this.btnActualizar1.Text = "Act&ualizar";
            this.btnActualizar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnActualizar1.texto = "Act&ualizar";
            this.btnActualizar1.UseVisualStyleBackColor = true;
            this.btnActualizar1.Click += new System.EventHandler(this.btnActualizar1_Click);
            // 
            // frmReglasGrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 331);
            this.Controls.Add(this.btnActualizar1);
            this.Controls.Add(this.btnDetalle1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmReglasGrupo";
            this.Text = "Validación de Reglas Dinámicas - Grupo Solidario";
            this.Shown += new System.EventHandler(this.frmReglasGrupo_Shown);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnDetalle1, 0);
            this.Controls.SetChildIndex(this.btnActualizar1, 0);
            this.grbBase1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgGrupo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolicitudes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSolicitudes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingGrupo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.dtgBase dtgSolicitudes;
        private System.Windows.Forms.BindingSource bindingSolicitudes;
        private GEN.BotonesBase.btnSalir btnSalir;
        private System.Windows.Forms.BindingSource bindingGrupo;
        private GEN.BotonesBase.btnDetalle btnDetalle1;
        private GEN.ControlesBase.dtgBase dtgGrupo;
        private GEN.BotonesBase.btnActualizar btnActualizar1;

    }
}