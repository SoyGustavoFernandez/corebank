namespace ADM.Presentacion
{
    partial class frmMantenimientoUsuarioZona
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoUsuarioZona));
            this.conBusCol1 = new GEN.ControlesBase.ConBusCol();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgZonas = new GEN.ControlesBase.dtgBase(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboZona1 = new GEN.ControlesBase.cboZona(this.components);
            this.btnMiniAgregar1 = new GEN.BotonesBase.btnMiniAgregar();
            this.btnMiniQuitar1 = new GEN.BotonesBase.btnMiniQuitar();
            this.grbDatos = new System.Windows.Forms.GroupBox();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgZonas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grbDatos.SuspendLayout();
            this.SuspendLayout();
            //
            // conBusCol1
            //
            this.conBusCol1.cEstado = "0";
            this.conBusCol1.Location = new System.Drawing.Point(12, 12);
            this.conBusCol1.Name = "conBusCol1";
            this.conBusCol1.Size = new System.Drawing.Size(390, 86);
            this.conBusCol1.TabIndex = 2;
            this.conBusCol1.BuscarUsuario += new System.EventHandler(this.conBusCol1_BuscarUsuario);
            //
            // groupBox2
            //
            this.groupBox2.Controls.Add(this.dtgZonas);
            this.groupBox2.Location = new System.Drawing.Point(6, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(331, 121);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Zonas asignadas";
            //
            // dtgZonas
            //
            this.dtgZonas.AllowUserToAddRows = false;
            this.dtgZonas.AllowUserToDeleteRows = false;
            this.dtgZonas.AllowUserToResizeColumns = false;
            this.dtgZonas.AllowUserToResizeRows = false;
            this.dtgZonas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgZonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgZonas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgZonas.Location = new System.Drawing.Point(3, 16);
            this.dtgZonas.MultiSelect = false;
            this.dtgZonas.Name = "dtgZonas";
            this.dtgZonas.ReadOnly = true;
            this.dtgZonas.RowHeadersVisible = false;
            this.dtgZonas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgZonas.Size = new System.Drawing.Size(325, 102);
            this.dtgZonas.TabIndex = 0;
            //
            // groupBox1
            //
            this.groupBox1.Controls.Add(this.lblBase1);
            this.groupBox1.Controls.Add(this.cboZona1);
            this.groupBox1.Location = new System.Drawing.Point(6, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(331, 51);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nuevo";
            //
            // lblBase1
            //
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(19, 23);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(41, 13);
            this.lblBase1.TabIndex = 9;
            this.lblBase1.Text = "Zona:";
            //
            // cboZona1
            //
            this.cboZona1.FormattingEnabled = true;
            this.cboZona1.Location = new System.Drawing.Point(70, 19);
            this.cboZona1.Name = "cboZona1";
            this.cboZona1.Size = new System.Drawing.Size(242, 21);
            this.cboZona1.TabIndex = 8;
            //
            // btnMiniAgregar1
            //
            this.btnMiniAgregar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniAgregar1.BackgroundImage")));
            this.btnMiniAgregar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniAgregar1.Location = new System.Drawing.Point(340, 30);
            this.btnMiniAgregar1.Name = "btnMiniAgregar1";
            this.btnMiniAgregar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniAgregar1.TabIndex = 10;
            this.btnMiniAgregar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniAgregar1.UseVisualStyleBackColor = true;
            this.btnMiniAgregar1.Click += new System.EventHandler(this.btnMiniAgregar1_Click);
            //
            // btnMiniQuitar1
            //
            this.btnMiniQuitar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniQuitar1.BackgroundImage")));
            this.btnMiniQuitar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniQuitar1.Location = new System.Drawing.Point(340, 88);
            this.btnMiniQuitar1.Name = "btnMiniQuitar1";
            this.btnMiniQuitar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniQuitar1.TabIndex = 6;
            this.btnMiniQuitar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniQuitar1.UseVisualStyleBackColor = true;
            this.btnMiniQuitar1.Click += new System.EventHandler(this.btnMiniQuitar1_Click);
            //
            // grbDatos
            //
            this.grbDatos.Controls.Add(this.groupBox1);
            this.grbDatos.Controls.Add(this.btnMiniAgregar1);
            this.grbDatos.Controls.Add(this.groupBox2);
            this.grbDatos.Controls.Add(this.btnMiniQuitar1);
            this.grbDatos.Location = new System.Drawing.Point(12, 104);
            this.grbDatos.Name = "grbDatos";
            this.grbDatos.Size = new System.Drawing.Size(388, 204);
            this.grbDatos.TabIndex = 11;
            this.grbDatos.TabStop = false;
            //
            // btnSalir1
            //
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(340, 314);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 12;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            //
            // btnCancelar1
            //
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(274, 314);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 13;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            //
            // frmMantenimientoUsuarioZona
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 395);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.grbDatos);
            this.Controls.Add(this.conBusCol1);
            this.Name = "frmMantenimientoUsuarioZona";
            this.Text = "Mantenimiento Usuario Zona";
            this.Load += new System.EventHandler(this.frmMantenimientoUsuarioZona_Load);
            this.Controls.SetChildIndex(this.conBusCol1, 0);
            this.Controls.SetChildIndex(this.grbDatos, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgZonas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbDatos.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.ConBusCol conBusCol1;
        private System.Windows.Forms.GroupBox groupBox2;
        private GEN.ControlesBase.dtgBase dtgZonas;
        private System.Windows.Forms.GroupBox groupBox1;
        private GEN.BotonesBase.btnMiniAgregar btnMiniAgregar1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboZona cboZona1;
        private GEN.BotonesBase.btnMiniQuitar btnMiniQuitar1;
        private System.Windows.Forms.GroupBox grbDatos;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
    }
}