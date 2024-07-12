namespace GEN.ControlesBase
{
    partial class frmEstimacionPrecios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEstimacionPrecios));
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.dtpFechaNP = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgDetalleNP = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.btnMiniQuitar1 = new GEN.BotonesBase.btnMiniQuitar();
            this.btnMiniAgregar1 = new GEN.BotonesBase.btnMiniAgregar();
            this.dtgBase2 = new GEN.ControlesBase.dtgBase(this.components);
            this.txtCBNumerosEnteros1 = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtCBNumerosEnteros2 = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtCBNumerosEnteros3 = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtCBNumerosEnteros4 = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.chcBase1 = new GEN.ControlesBase.chcBase(this.components);
            this.txtNumNP = new GEN.ControlesBase.txtBase(this.components);
            this.txtUsuario = new GEN.ControlesBase.txtBase(this.components);
            this.txtMoneda = new GEN.ControlesBase.txtBase(this.components);
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleNP)).BeginInit();
            this.grbBase2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBase2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(12, 16);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(69, 13);
            this.lblBase4.TabIndex = 14;
            this.lblBase4.Text = "Nro de NP:";
            // 
            // dtpFechaNP
            // 
            this.dtpFechaNP.Enabled = false;
            this.dtpFechaNP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNP.Location = new System.Drawing.Point(477, 12);
            this.dtpFechaNP.Name = "dtpFechaNP";
            this.dtpFechaNP.Size = new System.Drawing.Size(122, 20);
            this.dtpFechaNP.TabIndex = 15;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(419, 16);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(45, 13);
            this.lblBase5.TabIndex = 16;
            this.lblBase5.Text = "Fecha:";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(216, 16);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(55, 13);
            this.lblBase8.TabIndex = 20;
            this.lblBase8.Text = "Usuario:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.dtgDetalleNP);
            this.grbBase1.Location = new System.Drawing.Point(12, 59);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(587, 169);
            this.grbBase1.TabIndex = 22;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Items:";
            // 
            // dtgDetalleNP
            // 
            this.dtgDetalleNP.AllowUserToAddRows = false;
            this.dtgDetalleNP.AllowUserToDeleteRows = false;
            this.dtgDetalleNP.AllowUserToResizeColumns = false;
            this.dtgDetalleNP.AllowUserToResizeRows = false;
            this.dtgDetalleNP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetalleNP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalleNP.Location = new System.Drawing.Point(6, 19);
            this.dtgDetalleNP.MultiSelect = false;
            this.dtgDetalleNP.Name = "dtgDetalleNP";
            this.dtgDetalleNP.ReadOnly = true;
            this.dtgDetalleNP.RowHeadersVisible = false;
            this.dtgDetalleNP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetalleNP.Size = new System.Drawing.Size(575, 139);
            this.dtgDetalleNP.TabIndex = 5;
            this.dtgDetalleNP.CurrentCellDirtyStateChanged += new System.EventHandler(this.dtgDetalleNP_CurrentCellDirtyStateChanged);
            this.dtgDetalleNP.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDetalleNP_RowEnter);
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.btnMiniQuitar1);
            this.grbBase2.Controls.Add(this.btnMiniAgregar1);
            this.grbBase2.Controls.Add(this.dtgBase2);
            this.grbBase2.Location = new System.Drawing.Point(9, 265);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(590, 99);
            this.grbBase2.TabIndex = 23;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Datos de Proveedor";
            // 
            // btnMiniQuitar1
            // 
            this.btnMiniQuitar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniQuitar1.BackgroundImage")));
            this.btnMiniQuitar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniQuitar1.Location = new System.Drawing.Point(548, 56);
            this.btnMiniQuitar1.Name = "btnMiniQuitar1";
            this.btnMiniQuitar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniQuitar1.TabIndex = 22;
            this.btnMiniQuitar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniQuitar1.UseVisualStyleBackColor = true;
            // 
            // btnMiniAgregar1
            // 
            this.btnMiniAgregar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniAgregar1.BackgroundImage")));
            this.btnMiniAgregar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniAgregar1.Location = new System.Drawing.Point(548, 22);
            this.btnMiniAgregar1.Name = "btnMiniAgregar1";
            this.btnMiniAgregar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniAgregar1.TabIndex = 21;
            this.btnMiniAgregar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniAgregar1.UseVisualStyleBackColor = true;
            this.btnMiniAgregar1.Click += new System.EventHandler(this.btnMiniAgregar1_Click);
            // 
            // dtgBase2
            // 
            this.dtgBase2.AllowUserToAddRows = false;
            this.dtgBase2.AllowUserToDeleteRows = false;
            this.dtgBase2.AllowUserToResizeColumns = false;
            this.dtgBase2.AllowUserToResizeRows = false;
            this.dtgBase2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgBase2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBase2.Location = new System.Drawing.Point(6, 22);
            this.dtgBase2.MultiSelect = false;
            this.dtgBase2.Name = "dtgBase2";
            this.dtgBase2.ReadOnly = true;
            this.dtgBase2.RowHeadersVisible = false;
            this.dtgBase2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgBase2.Size = new System.Drawing.Size(532, 62);
            this.dtgBase2.TabIndex = 20;
            // 
            // txtCBNumerosEnteros1
            // 
            this.txtCBNumerosEnteros1.Location = new System.Drawing.Point(236, 234);
            this.txtCBNumerosEnteros1.Name = "txtCBNumerosEnteros1";
            this.txtCBNumerosEnteros1.Size = new System.Drawing.Size(85, 20);
            this.txtCBNumerosEnteros1.TabIndex = 24;
            // 
            // txtCBNumerosEnteros2
            // 
            this.txtCBNumerosEnteros2.Location = new System.Drawing.Point(327, 234);
            this.txtCBNumerosEnteros2.Name = "txtCBNumerosEnteros2";
            this.txtCBNumerosEnteros2.Size = new System.Drawing.Size(85, 20);
            this.txtCBNumerosEnteros2.TabIndex = 25;
            // 
            // txtCBNumerosEnteros3
            // 
            this.txtCBNumerosEnteros3.Location = new System.Drawing.Point(418, 234);
            this.txtCBNumerosEnteros3.Name = "txtCBNumerosEnteros3";
            this.txtCBNumerosEnteros3.Size = new System.Drawing.Size(85, 20);
            this.txtCBNumerosEnteros3.TabIndex = 26;
            // 
            // txtCBNumerosEnteros4
            // 
            this.txtCBNumerosEnteros4.Location = new System.Drawing.Point(508, 234);
            this.txtCBNumerosEnteros4.Name = "txtCBNumerosEnteros4";
            this.txtCBNumerosEnteros4.Size = new System.Drawing.Size(85, 20);
            this.txtCBNumerosEnteros4.TabIndex = 27;
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(405, 370);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 28;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(537, 370);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 29;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(471, 370);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 30;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(419, 43);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(56, 13);
            this.lblBase1.TabIndex = 31;
            this.lblBase1.Text = "Moneda:";
            // 
            // chcBase1
            // 
            this.chcBase1.AutoSize = true;
            this.chcBase1.Location = new System.Drawing.Point(15, 237);
            this.chcBase1.Name = "chcBase1";
            this.chcBase1.Size = new System.Drawing.Size(177, 17);
            this.chcBase1.TabIndex = 33;
            this.chcBase1.Text = "Estimación por el Total de la NP";
            this.chcBase1.UseVisualStyleBackColor = true;
            // 
            // txtNumNP
            // 
            this.txtNumNP.Enabled = false;
            this.txtNumNP.Location = new System.Drawing.Point(88, 12);
            this.txtNumNP.Name = "txtNumNP";
            this.txtNumNP.Size = new System.Drawing.Size(122, 20);
            this.txtNumNP.TabIndex = 34;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Location = new System.Drawing.Point(277, 12);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(122, 20);
            this.txtUsuario.TabIndex = 35;
            // 
            // txtMoneda
            // 
            this.txtMoneda.Enabled = false;
            this.txtMoneda.Location = new System.Drawing.Point(477, 40);
            this.txtMoneda.Name = "txtMoneda";
            this.txtMoneda.Size = new System.Drawing.Size(122, 20);
            this.txtMoneda.TabIndex = 36;
            // 
            // frmEstimacionPrecios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 448);
            this.Controls.Add(this.txtMoneda);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.txtNumNP);
            this.Controls.Add(this.chcBase1);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.txtCBNumerosEnteros4);
            this.Controls.Add(this.txtCBNumerosEnteros3);
            this.Controls.Add(this.txtCBNumerosEnteros2);
            this.Controls.Add(this.txtCBNumerosEnteros1);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.lblBase8);
            this.Controls.Add(this.dtpFechaNP);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.lblBase4);
            this.Name = "frmEstimacionPrecios";
            this.Text = "Estimación de Precios";
            this.Load += new System.EventHandler(this.frmEstimacionPrecios_Load);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.dtpFechaNP, 0);
            this.Controls.SetChildIndex(this.lblBase8, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.txtCBNumerosEnteros1, 0);
            this.Controls.SetChildIndex(this.txtCBNumerosEnteros2, 0);
            this.Controls.SetChildIndex(this.txtCBNumerosEnteros3, 0);
            this.Controls.SetChildIndex(this.txtCBNumerosEnteros4, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.chcBase1, 0);
            this.Controls.SetChildIndex(this.txtNumNP, 0);
            this.Controls.SetChildIndex(this.txtUsuario, 0);
            this.Controls.SetChildIndex(this.txtMoneda, 0);
            this.grbBase1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleNP)).EndInit();
            this.grbBase2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgBase2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private lblBase lblBase4;
        private dtpCorto dtpFechaNP;
        private lblBase lblBase5;
        private lblBase lblBase8;
        private grbBase grbBase1;
        private dtgBase dtgDetalleNP;
        private grbBase grbBase2;
        private BotonesBase.btnMiniQuitar btnMiniQuitar1;
        private BotonesBase.btnMiniAgregar btnMiniAgregar1;
        private dtgBase dtgBase2;
        private txtCBNumerosEnteros txtCBNumerosEnteros1;
        private txtCBNumerosEnteros txtCBNumerosEnteros2;
        private txtCBNumerosEnteros txtCBNumerosEnteros3;
        private txtCBNumerosEnteros txtCBNumerosEnteros4;
        private BotonesBase.btnGrabar btnGrabar1;
        private BotonesBase.btnSalir btnSalir1;
        private BotonesBase.btnCancelar btnCancelar1;
        private lblBase lblBase1;
        private chcBase chcBase1;
        private txtBase txtNumNP;
        private txtBase txtUsuario;
        private txtBase txtMoneda;

    }
}