namespace RCP.Presentacion
{
    partial class frmRegistrarTelefonoRecupera
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistrarTelefonoRecupera));
            this.dtgTelefonos = new GEN.ControlesBase.dtgBase(this.components);
            this.cTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnMiniAgregar1 = new GEN.BotonesBase.btnMiniAgregar();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtTelefCel1 = new GEN.ControlesBase.txtTelefCel(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTelefonos)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgTelefonos
            // 
            this.dtgTelefonos.AllowUserToAddRows = false;
            this.dtgTelefonos.AllowUserToDeleteRows = false;
            this.dtgTelefonos.AllowUserToResizeColumns = false;
            this.dtgTelefonos.AllowUserToResizeRows = false;
            this.dtgTelefonos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgTelefonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTelefonos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cTelefono});
            this.dtgTelefonos.Location = new System.Drawing.Point(12, 36);
            this.dtgTelefonos.MultiSelect = false;
            this.dtgTelefonos.Name = "dtgTelefonos";
            this.dtgTelefonos.ReadOnly = true;
            this.dtgTelefonos.RowHeadersVisible = false;
            this.dtgTelefonos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgTelefonos.Size = new System.Drawing.Size(240, 150);
            this.dtgTelefonos.TabIndex = 2;
            // 
            // cTelefono
            // 
            this.cTelefono.DataPropertyName = "cTelefono";
            this.cTelefono.HeaderText = "Telefono";
            this.cTelefono.Name = "cTelefono";
            this.cTelefono.ReadOnly = true;
            // 
            // btnMiniAgregar1
            // 
            this.btnMiniAgregar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniAgregar1.BackgroundImage")));
            this.btnMiniAgregar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniAgregar1.Location = new System.Drawing.Point(204, 5);
            this.btnMiniAgregar1.Name = "btnMiniAgregar1";
            this.btnMiniAgregar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniAgregar1.TabIndex = 1;
            this.btnMiniAgregar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniAgregar1.UseVisualStyleBackColor = true;
            this.btnMiniAgregar1.Click += new System.EventHandler(this.btnMiniAgregar1_Click);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(13, 13);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(78, 13);
            this.lblBase1.TabIndex = 4;
            this.lblBase1.Text = "Tel./Celular:";
            // 
            // txtTelefCel1
            // 
            this.txtTelefCel1.Location = new System.Drawing.Point(98, 9);
            this.txtTelefCel1.MaxLength = 12;
            this.txtTelefCel1.Name = "txtTelefCel1";
            this.txtTelefCel1.Size = new System.Drawing.Size(100, 20);
            this.txtTelefCel1.TabIndex = 0;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(192, 192);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 3;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // frmRegistrarTelefonoRecupera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 274);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.txtTelefCel1);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.btnMiniAgregar1);
            this.Controls.Add(this.dtgTelefonos);
            this.Name = "frmRegistrarTelefonoRecupera";
            this.Text = "Registrar Telefono Recupera";
            this.Load += new System.EventHandler(this.frmRegistrarTelefonoRecupera_Load);
            this.Controls.SetChildIndex(this.dtgTelefonos, 0);
            this.Controls.SetChildIndex(this.btnMiniAgregar1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.txtTelefCel1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgTelefonos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgTelefonos;
        private GEN.BotonesBase.btnMiniAgregar btnMiniAgregar1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtTelefCel txtTelefCel1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTelefono;
    }
}