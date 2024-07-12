namespace GEN.ControlesBase
{
    partial class frmRegistroDocumentoObs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistroDocumentoObs));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnObservar = new GEN.BotonesBase.btnObservacion();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtgRegDocObs = new GEN.ControlesBase.dtgBase(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.pbxAyuda = new GEN.ControlesBase.pbxAyuda();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmQuitarDetalle = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAgregarDetalle = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnVistoBueno = new GEN.BotonesBase.btnAprobar();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRegDocObs)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAyuda)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnObservar
            // 
            this.btnObservar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnObservar.BackgroundImage")));
            this.btnObservar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnObservar.Location = new System.Drawing.Point(3, 3);
            this.btnObservar.Name = "btnObservar";
            this.btnObservar.Size = new System.Drawing.Size(60, 50);
            this.btnObservar.TabIndex = 4;
            this.btnObservar.Text = "&Obs.";
            this.btnObservar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnObservar.UseVisualStyleBackColor = true;
            this.btnObservar.Click += new System.EventHandler(this.btnObservar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(3, 171);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(0, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1045, 225);
            this.panel1.TabIndex = 10;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dtgRegDocObs);
            this.panel4.Location = new System.Drawing.Point(3, 30);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1039, 192);
            this.panel4.TabIndex = 13;
            // 
            // dtgRegDocObs
            // 
            this.dtgRegDocObs.AllowUserToAddRows = false;
            this.dtgRegDocObs.AllowUserToDeleteRows = false;
            this.dtgRegDocObs.AllowUserToResizeColumns = false;
            this.dtgRegDocObs.AllowUserToResizeRows = false;
            this.dtgRegDocObs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgRegDocObs.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgRegDocObs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgRegDocObs.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgRegDocObs.Location = new System.Drawing.Point(0, 1);
            this.dtgRegDocObs.MultiSelect = false;
            this.dtgRegDocObs.Name = "dtgRegDocObs";
            this.dtgRegDocObs.ReadOnly = true;
            this.dtgRegDocObs.RowHeadersVisible = false;
            this.dtgRegDocObs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgRegDocObs.Size = new System.Drawing.Size(1039, 194);
            this.dtgRegDocObs.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pbxAyuda);
            this.panel3.Controls.Add(this.menuStrip1);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1039, 28);
            this.panel3.TabIndex = 12;
            // 
            // pbxAyuda
            // 
            this.pbxAyuda.Image = ((System.Drawing.Image)(resources.GetObject("pbxAyuda.Image")));
            this.pbxAyuda.Location = new System.Drawing.Point(3, 2);
            this.pbxAyuda.Name = "pbxAyuda";
            this.pbxAyuda.Size = new System.Drawing.Size(20, 20);
            this.pbxAyuda.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxAyuda.TabIndex = 1;
            this.pbxAyuda.TabStop = false;
            this.pbxAyuda.Click += new System.EventHandler(this.pbxAyuda_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmQuitarDetalle,
            this.tsmAgregarDetalle});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1039, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmQuitarDetalle
            // 
            this.tsmQuitarDetalle.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmQuitarDetalle.Checked = true;
            this.tsmQuitarDetalle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmQuitarDetalle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmQuitarDetalle.Image = ((System.Drawing.Image)(resources.GetObject("tsmQuitarDetalle.Image")));
            this.tsmQuitarDetalle.Name = "tsmQuitarDetalle";
            this.tsmQuitarDetalle.Size = new System.Drawing.Size(28, 20);
            this.tsmQuitarDetalle.Text = "Quitar";
            this.tsmQuitarDetalle.ToolTipText = "Eliminar registro seleccionado.";
            this.tsmQuitarDetalle.Click += new System.EventHandler(this.tsmQuitarDetalle_Click);
            // 
            // tsmAgregarDetalle
            // 
            this.tsmAgregarDetalle.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmAgregarDetalle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmAgregarDetalle.Image = ((System.Drawing.Image)(resources.GetObject("tsmAgregarDetalle.Image")));
            this.tsmAgregarDetalle.Name = "tsmAgregarDetalle";
            this.tsmAgregarDetalle.Size = new System.Drawing.Size(28, 20);
            this.tsmAgregarDetalle.Text = "Agregar";
            this.tsmAgregarDetalle.ToolTipText = "Agregar registro del formulario.";
            this.tsmAgregarDetalle.Click += new System.EventHandler(this.tsmAgregarDetalle_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnGrabar1);
            this.panel2.Controls.Add(this.btnVistoBueno);
            this.panel2.Controls.Add(this.btnSalir);
            this.panel2.Controls.Add(this.btnObservar);
            this.panel2.Location = new System.Drawing.Point(1056, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(68, 225);
            this.panel2.TabIndex = 11;
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Enabled = false;
            this.btnGrabar1.Location = new System.Drawing.Point(3, 115);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 10;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnVistoBueno
            // 
            this.btnVistoBueno.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVistoBueno.BackgroundImage")));
            this.btnVistoBueno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnVistoBueno.Location = new System.Drawing.Point(3, 59);
            this.btnVistoBueno.Name = "btnVistoBueno";
            this.btnVistoBueno.Size = new System.Drawing.Size(60, 50);
            this.btnVistoBueno.TabIndex = 9;
            this.btnVistoBueno.Text = "&Aprobar";
            this.btnVistoBueno.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVistoBueno.UseVisualStyleBackColor = true;
            this.btnVistoBueno.Click += new System.EventHandler(this.btnVistoBueno_Click);
            // 
            // frmRegistroDocumentoObs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 262);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmRegistroDocumentoObs";
            this.Text = "Registro de Documentos Observados";
            this.Load += new System.EventHandler(this.frmRegistroDocumentoObs_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgRegDocObs)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAyuda)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BotonesBase.btnObservacion btnObservar;
        private BotonesBase.btnSalir btnSalir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private dtgBase dtgRegDocObs;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ToolStripMenuItem tsmQuitarDetalle;
        private System.Windows.Forms.ToolStripMenuItem tsmAgregarDetalle;
        private pbxAyuda pbxAyuda;
        private BotonesBase.btnAprobar btnVistoBueno;
        private BotonesBase.btnGrabar btnGrabar1;
    }
}