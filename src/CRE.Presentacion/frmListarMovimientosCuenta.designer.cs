namespace CRE.Presentacion
{
    partial class frmListarMovimientosCuenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListarMovimientosCuenta));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtNroCuenta = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtgMovimientos = new GEN.ControlesBase.dtgBase(this.components);
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMovimientos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtNroCuenta);
            this.groupBox2.Controls.Add(this.lblBase1);
            this.groupBox2.Location = new System.Drawing.Point(125, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(294, 52);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cuenta";
            // 
            // txtNroCuenta
            // 
            this.txtNroCuenta.Enabled = false;
            this.txtNroCuenta.Location = new System.Drawing.Point(102, 19);
            this.txtNroCuenta.Name = "txtNroCuenta";
            this.txtNroCuenta.Size = new System.Drawing.Size(175, 20);
            this.txtNroCuenta.TabIndex = 2;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(15, 22);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(81, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Nro. Cuenta:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtgMovimientos);
            this.groupBox1.Location = new System.Drawing.Point(12, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(519, 212);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Movimiento de cuenta";
            // 
            // dtgMovimientos
            // 
            this.dtgMovimientos.AllowUserToAddRows = false;
            this.dtgMovimientos.AllowUserToDeleteRows = false;
            this.dtgMovimientos.AllowUserToResizeColumns = false;
            this.dtgMovimientos.AllowUserToResizeRows = false;
            this.dtgMovimientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMovimientos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgMovimientos.Location = new System.Drawing.Point(3, 16);
            this.dtgMovimientos.MultiSelect = false;
            this.dtgMovimientos.Name = "dtgMovimientos";
            this.dtgMovimientos.ReadOnly = true;
            this.dtgMovimientos.RowHeadersVisible = false;
            this.dtgMovimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgMovimientos.Size = new System.Drawing.Size(513, 193);
            this.dtgMovimientos.TabIndex = 2;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(465, 285);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 10;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(399, 285);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 9;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // frmListarMovimientosCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 376);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnAceptar1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmListarMovimientosCuenta";
            this.Text = "Movimientos de cuenta";
            this.Load += new System.EventHandler(this.frmListarMovimientosCuenta_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgMovimientos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.BtnAceptar btnAceptar1;
        private System.Windows.Forms.GroupBox groupBox2;
        private GEN.ControlesBase.txtBase txtNroCuenta;
        private GEN.ControlesBase.lblBase lblBase1;
        private System.Windows.Forms.GroupBox groupBox1;
        private GEN.ControlesBase.dtgBase dtgMovimientos;
    }
}