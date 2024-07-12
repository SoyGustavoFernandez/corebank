namespace GEN.ControlesBase
{
    partial class ConCalculadoraInversionRealizada
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelTotaldtgGOperativos = new GEN.ControlesBase.lblBase();
            this.txtTotalInsumoInversion = new GEN.ControlesBase.txtBase(this.components);
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.dtgvInsumos = new GEN.ControlesBase.dtgBase(this.components);
            this.panel10 = new System.Windows.Forms.Panel();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.tsmQuitar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAgregar = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.bindingInversionInsumos = new System.Windows.Forms.BindingSource(this.components);
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvInsumos)).BeginInit();
            this.panel10.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingInversionInsumos)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTotaldtgGOperativos
            // 
            this.labelTotaldtgGOperativos.Font = new System.Drawing.Font("Verdana", 8F);
            this.labelTotaldtgGOperativos.ForeColor = System.Drawing.Color.Navy;
            this.labelTotaldtgGOperativos.Location = new System.Drawing.Point(481, 223);
            this.labelTotaldtgGOperativos.Name = "labelTotaldtgGOperativos";
            this.labelTotaldtgGOperativos.Size = new System.Drawing.Size(47, 13);
            this.labelTotaldtgGOperativos.TabIndex = 88;
            this.labelTotaldtgGOperativos.Text = "Total";
            this.labelTotaldtgGOperativos.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtTotalInsumoInversion
            // 
            this.txtTotalInsumoInversion.Enabled = false;
            this.txtTotalInsumoInversion.Location = new System.Drawing.Point(534, 220);
            this.txtTotalInsumoInversion.Name = "txtTotalInsumoInversion";
            this.txtTotalInsumoInversion.Size = new System.Drawing.Size(82, 20);
            this.txtTotalInsumoInversion.TabIndex = 87;
            this.txtTotalInsumoInversion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(628, 204);
            this.panel7.TabIndex = 86;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.dtgvInsumos);
            this.panel8.Controls.Add(this.panel10);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(626, 202);
            this.panel8.TabIndex = 25;
            // 
            // dtgvInsumos
            // 
            this.dtgvInsumos.AllowUserToAddRows = false;
            this.dtgvInsumos.AllowUserToDeleteRows = false;
            this.dtgvInsumos.AllowUserToResizeColumns = false;
            this.dtgvInsumos.AllowUserToResizeRows = false;
            this.dtgvInsumos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvInsumos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvInsumos.Location = new System.Drawing.Point(-1, 23);
            this.dtgvInsumos.MultiSelect = false;
            this.dtgvInsumos.Name = "dtgvInsumos";
            this.dtgvInsumos.ReadOnly = true;
            this.dtgvInsumos.RowHeadersVisible = false;
            this.dtgvInsumos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvInsumos.Size = new System.Drawing.Size(628, 180);
            this.dtgvInsumos.TabIndex = 10;
            this.dtgvInsumos.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgvInsumos_DataError);
            this.dtgvInsumos.SelectionChanged += new System.EventHandler(this.dtgvInsumos_SelectionChanged);
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.menuStrip2);
            this.panel10.Controls.Add(this.label2);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Margin = new System.Windows.Forms.Padding(0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(626, 24);
            this.panel10.TabIndex = 9;
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.White;
            this.menuStrip2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmQuitar,
            this.tsmAgregar});
            this.menuStrip2.Location = new System.Drawing.Point(182, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(444, 24);
            this.menuStrip2.TabIndex = 7;
            this.menuStrip2.TabStop = true;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // tsmQuitar
            // 
            this.tsmQuitar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmQuitar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmQuitar.Enabled = false;
            this.tsmQuitar.Image = global::GEN.ControlesBase.Properties.Resources.btn_quitar;
            this.tsmQuitar.Name = "tsmQuitar";
            this.tsmQuitar.Size = new System.Drawing.Size(28, 20);
            this.tsmQuitar.Text = "toolStripMenuItem2";
            this.tsmQuitar.Click += new System.EventHandler(this.tsmQuitar_Click);
            // 
            // tsmAgregar
            // 
            this.tsmAgregar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmAgregar.Image = global::GEN.ControlesBase.Properties.Resources.btn_agregar;
            this.tsmAgregar.Name = "tsmAgregar";
            this.tsmAgregar.Size = new System.Drawing.Size(28, 20);
            this.tsmAgregar.Text = "toolStripMenuItem1";
            this.tsmAgregar.Click += new System.EventHandler(this.tsmAgregar_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 24);
            this.label2.TabIndex = 100;
            this.label2.Text = "Inversión Insumos";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bindingInversionInsumos
            // 
            this.bindingInversionInsumos.BindingComplete += new System.Windows.Forms.BindingCompleteEventHandler(this.bindingInversionInsumos_BindingComplete);
            // 
            // ConCalculadoraInversionRealizada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelTotaldtgGOperativos);
            this.Controls.Add(this.txtTotalInsumoInversion);
            this.Controls.Add(this.panel7);
            this.Name = "ConCalculadoraInversionRealizada";
            this.Size = new System.Drawing.Size(628, 261);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvInsumos)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingInversionInsumos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private lblBase labelTotaldtgGOperativos;
        private txtBase txtTotalInsumoInversion;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private dtgBase dtgvInsumos;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem tsmQuitar;
        private System.Windows.Forms.ToolStripMenuItem tsmAgregar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource bindingInversionInsumos;
    }
}
