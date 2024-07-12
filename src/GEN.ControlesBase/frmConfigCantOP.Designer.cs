namespace GEN.ControlesBase
{
    partial class frmConfigCantOP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigCantOP));
            this.dtgConfigOP = new GEN.ControlesBase.dtgBase(this.components);
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.btnMiniAgregar1 = new GEN.BotonesBase.btnMiniAgregar();
            this.btnMiniQuitar1 = new GEN.BotonesBase.btnMiniQuitar();
            this.txtNumImpresion = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtTotal = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgConfigOP)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgConfigOP
            // 
            this.dtgConfigOP.AllowUserToAddRows = false;
            this.dtgConfigOP.AllowUserToDeleteRows = false;
            this.dtgConfigOP.AllowUserToResizeColumns = false;
            this.dtgConfigOP.AllowUserToResizeRows = false;
            this.dtgConfigOP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgConfigOP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgConfigOP.Location = new System.Drawing.Point(9, 37);
            this.dtgConfigOP.MultiSelect = false;
            this.dtgConfigOP.Name = "dtgConfigOP";
            this.dtgConfigOP.ReadOnly = true;
            this.dtgConfigOP.RowHeadersVisible = false;
            this.dtgConfigOP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgConfigOP.Size = new System.Drawing.Size(312, 150);
            this.dtgConfigOP.TabIndex = 2;
            this.dtgConfigOP.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgConfigOP_CellValueChanged);
            this.dtgConfigOP.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgConfigOP_EditingControlShowing);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(261, 218);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 14);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(134, 13);
            this.lblBase1.TabIndex = 7;
            this.lblBase1.Text = "Nro. OP de por grupo:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(160, 197);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(49, 13);
            this.lblBase2.TabIndex = 9;
            this.lblBase2.Text = "TOTAL:";
            // 
            // btnMiniAgregar1
            // 
            this.btnMiniAgregar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniAgregar1.BackgroundImage")));
            this.btnMiniAgregar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniAgregar1.Location = new System.Drawing.Point(245, 4);
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
            this.btnMiniQuitar1.Location = new System.Drawing.Point(285, 4);
            this.btnMiniQuitar1.Name = "btnMiniQuitar1";
            this.btnMiniQuitar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniQuitar1.TabIndex = 11;
            this.btnMiniQuitar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniQuitar1.UseVisualStyleBackColor = true;
            this.btnMiniQuitar1.Click += new System.EventHandler(this.btnMiniQuitar1_Click);
            // 
            // txtNumImpresion
            // 
            this.txtNumImpresion.Location = new System.Drawing.Point(137, 12);
            this.txtNumImpresion.Name = "txtNumImpresion";
            this.txtNumImpresion.Size = new System.Drawing.Size(100, 20);
            this.txtNumImpresion.TabIndex = 12;
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(221, 193);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(100, 20);
            this.txtTotal.TabIndex = 13;
            // 
            // frmConfigCantOP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 292);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtNumImpresion);
            this.Controls.Add(this.btnMiniQuitar1);
            this.Controls.Add(this.btnMiniAgregar1);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dtgConfigOP);
            this.Name = "frmConfigCantOP";
            this.Text = "Configuración de órdenes de pago";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmConfigCantOP_FormClosed);
            this.Load += new System.EventHandler(this.frmConfigCantOP_Load);
            this.Controls.SetChildIndex(this.dtgConfigOP, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.btnMiniAgregar1, 0);
            this.Controls.SetChildIndex(this.btnMiniQuitar1, 0);
            this.Controls.SetChildIndex(this.txtNumImpresion, 0);
            this.Controls.SetChildIndex(this.txtTotal, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgConfigOP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private dtgBase dtgConfigOP;
        private BotonesBase.BtnAceptar btnAceptar;
        private lblBase lblBase1;
        private lblBase lblBase2;
        private BotonesBase.btnMiniAgregar btnMiniAgregar1;
        private BotonesBase.btnMiniQuitar btnMiniQuitar1;
        private txtCBNumerosEnteros txtNumImpresion;
        private txtCBNumerosEnteros txtTotal;
    }
}