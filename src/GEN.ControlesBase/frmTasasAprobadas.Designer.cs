namespace GEN.ControlesBase
{
    partial class frmTasasAprobadas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTasasAprobadas));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtgTasasAprobadas = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.conRastreoTasaNegociable = new GEN.ControlesBase.conRastreoTasaNegociable();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTasasAprobadas)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(675, 174);
            this.panel1.TabIndex = 91;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(675, 167);
            this.panel2.TabIndex = 78;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(673, 165);
            this.panel3.TabIndex = 25;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dtgTasasAprobadas);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 24);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(673, 141);
            this.panel4.TabIndex = 25;
            // 
            // dtgTasasAprobadas
            // 
            this.dtgTasasAprobadas.AllowUserToAddRows = false;
            this.dtgTasasAprobadas.AllowUserToDeleteRows = false;
            this.dtgTasasAprobadas.AllowUserToResizeColumns = false;
            this.dtgTasasAprobadas.AllowUserToResizeRows = false;
            this.dtgTasasAprobadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgTasasAprobadas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgTasasAprobadas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgTasasAprobadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTasasAprobadas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgTasasAprobadas.Location = new System.Drawing.Point(0, 0);
            this.dtgTasasAprobadas.MultiSelect = false;
            this.dtgTasasAprobadas.Name = "dtgTasasAprobadas";
            this.dtgTasasAprobadas.RowHeadersVisible = false;
            this.dtgTasasAprobadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgTasasAprobadas.Size = new System.Drawing.Size(673, 141);
            this.dtgTasasAprobadas.TabIndex = 10;
            this.dtgTasasAprobadas.TabStop = false;
            this.dtgTasasAprobadas.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgDetalleAprobacion);
            this.dtgTasasAprobadas.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgTasasAprobadas_DataBindingComplete);
            this.dtgTasasAprobadas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgTasasAprobadas_KeyDown);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.menuStrip1);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(673, 24);
            this.panel5.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.Location = new System.Drawing.Point(182, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(491, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.TabStop = true;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 24);
            this.label1.TabIndex = 100;
            this.label1.Text = "Tasas Solicitadas / Aprobadas ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(626, 354);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 94;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // conRastreoTasaNegociable
            // 
            this.conRastreoTasaNegociable.idSolicitud = 0;
            this.conRastreoTasaNegociable.idTasaNegociada = 0;
            this.conRastreoTasaNegociable.idUsuario = 0;
            this.conRastreoTasaNegociable.Location = new System.Drawing.Point(7, 199);
            this.conRastreoTasaNegociable.lstRastreoTasaNegociable = ((System.Collections.Generic.List<EntityLayer.clsRastreoTasaNegociable>)(resources.GetObject("conRastreoTasaNegociable.lstRastreoTasaNegociable")));
            this.conRastreoTasaNegociable.Name = "conRastreoTasaNegociable";
            this.conRastreoTasaNegociable.Size = new System.Drawing.Size(685, 150);
            this.conRastreoTasaNegociable.TabIndex = 95;
            // 
            // frmTasasAprobadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 435);
            this.Controls.Add(this.conRastreoTasaNegociable);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.panel1);
            this.Name = "frmTasasAprobadas";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tasas Negociables";
            this.Load += new System.EventHandler(this.frmTasasAprobadas_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.conRastreoTasaNegociable, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgTasasAprobadas)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dtgTasasAprobadas;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label label1;
        private BotonesBase.btnSalir btnSalir1;
        private conRastreoTasaNegociable conRastreoTasaNegociable;
    }
}