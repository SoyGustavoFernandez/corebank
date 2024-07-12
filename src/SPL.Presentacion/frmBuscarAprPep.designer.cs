namespace SPL.Presentacion
{
    partial class frmBuscarAprPep
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarAprPep));
            this.dtgListaPep = new GEN.ControlesBase.dtgBase(this.components);
            this.idFam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtCBDNI1 = new GEN.ControlesBase.txtCBDNI(this.components);
            this.btnMiniBusq1 = new GEN.BotonesBase.btnMiniBusq(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaPep)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgListaPep
            // 
            this.dtgListaPep.AllowUserToAddRows = false;
            this.dtgListaPep.AllowUserToDeleteRows = false;
            this.dtgListaPep.AllowUserToResizeColumns = false;
            this.dtgListaPep.AllowUserToResizeRows = false;
            this.dtgListaPep.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgListaPep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaPep.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idFam});
            this.dtgListaPep.Location = new System.Drawing.Point(5, 38);
            this.dtgListaPep.MultiSelect = false;
            this.dtgListaPep.Name = "dtgListaPep";
            this.dtgListaPep.ReadOnly = true;
            this.dtgListaPep.RowHeadersVisible = false;
            this.dtgListaPep.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaPep.Size = new System.Drawing.Size(664, 173);
            this.dtgListaPep.TabIndex = 12;
            this.dtgListaPep.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgListaPep_CellEnter);
            this.dtgListaPep.DoubleClick += new System.EventHandler(this.dtgListaPep_DoubleClick);
            this.dtgListaPep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgListaPep_KeyDown);
            // 
            // idFam
            // 
            this.idFam.DataPropertyName = "idFam";
            this.idFam.HeaderText = "idFam";
            this.idFam.Name = "idFam";
            this.idFam.ReadOnly = true;
            this.idFam.Visible = false;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(540, 216);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 14;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(606, 217);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 13;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(2, 13);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(168, 13);
            this.lblBase1.TabIndex = 15;
            this.lblBase1.Text = "Buscar por nro. documento:";
            // 
            // txtCBDNI1
            // 
            this.txtCBDNI1.Location = new System.Drawing.Point(175, 10);
            this.txtCBDNI1.Name = "txtCBDNI1";
            this.txtCBDNI1.Size = new System.Drawing.Size(144, 20);
            this.txtCBDNI1.TabIndex = 16;
            this.txtCBDNI1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCBDNI1_KeyPress);
            // 
            // btnMiniBusq1
            // 
            this.btnMiniBusq1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniBusq1.BackgroundImage")));
            this.btnMiniBusq1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniBusq1.Location = new System.Drawing.Point(325, 4);
            this.btnMiniBusq1.Name = "btnMiniBusq1";
            this.btnMiniBusq1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniBusq1.TabIndex = 17;
            this.btnMiniBusq1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniBusq1.UseVisualStyleBackColor = true;
            this.btnMiniBusq1.Click += new System.EventHandler(this.btnMiniBusq1_Click);
            // 
            // frmBuscarAprPep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 294);
            this.Controls.Add(this.btnMiniBusq1);
            this.Controls.Add(this.txtCBDNI1);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dtgListaPep);
            this.Name = "frmBuscarAprPep";
            this.Text = "Solicitudes Pendientes de Aprobación (PEP)";
            this.Load += new System.EventHandler(this.frmBuscarAprPep_Load);
            this.Controls.SetChildIndex(this.dtgListaPep, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.txtCBDNI1, 0);
            this.Controls.SetChildIndex(this.btnMiniBusq1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaPep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgListaPep;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFam;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtCBDNI txtCBDNI1;
        private GEN.BotonesBase.btnMiniBusq btnMiniBusq1;
    }
}