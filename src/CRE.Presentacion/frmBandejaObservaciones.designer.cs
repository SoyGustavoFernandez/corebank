namespace CRE.Presentacion
{
    partial class frmBandejaObservaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBandejaObservaciones));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtgSolicitudesObservadas = new GEN.ControlesBase.dtgBase(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgObservaciones = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolicitudesObservadas)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgObservaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtgSolicitudesObservadas);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(757, 188);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Solicitudes observadas";
            // 
            // dtgSolicitudesObservadas
            // 
            this.dtgSolicitudesObservadas.AllowUserToAddRows = false;
            this.dtgSolicitudesObservadas.AllowUserToDeleteRows = false;
            this.dtgSolicitudesObservadas.AllowUserToResizeColumns = false;
            this.dtgSolicitudesObservadas.AllowUserToResizeRows = false;
            this.dtgSolicitudesObservadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgSolicitudesObservadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSolicitudesObservadas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgSolicitudesObservadas.Location = new System.Drawing.Point(3, 16);
            this.dtgSolicitudesObservadas.MultiSelect = false;
            this.dtgSolicitudesObservadas.Name = "dtgSolicitudesObservadas";
            this.dtgSolicitudesObservadas.ReadOnly = true;
            this.dtgSolicitudesObservadas.RowHeadersVisible = false;
            this.dtgSolicitudesObservadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSolicitudesObservadas.Size = new System.Drawing.Size(751, 169);
            this.dtgSolicitudesObservadas.TabIndex = 0;
            this.dtgSolicitudesObservadas.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgSolicitudesObservadas_CellMouseUp);
            this.dtgSolicitudesObservadas.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgSolicitudesObservadas_RowEnter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtgObservaciones);
            this.groupBox2.Location = new System.Drawing.Point(15, 206);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(757, 267);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Observaciones";
            // 
            // dtgObservaciones
            // 
            this.dtgObservaciones.AllowUserToAddRows = false;
            this.dtgObservaciones.AllowUserToDeleteRows = false;
            this.dtgObservaciones.AllowUserToResizeColumns = false;
            this.dtgObservaciones.AllowUserToResizeRows = false;
            this.dtgObservaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgObservaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgObservaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgObservaciones.Location = new System.Drawing.Point(3, 16);
            this.dtgObservaciones.MultiSelect = false;
            this.dtgObservaciones.Name = "dtgObservaciones";
            this.dtgObservaciones.ReadOnly = true;
            this.dtgObservaciones.RowHeadersVisible = false;
            this.dtgObservaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgObservaciones.Size = new System.Drawing.Size(751, 248);
            this.dtgObservaciones.TabIndex = 0;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(712, 477);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 6;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // frmBandejaObservaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmBandejaObservaciones";
            this.Text = "Bandeja de Observaciones";
            this.Load += new System.EventHandler(this.frmBandejaObservaciones_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolicitudesObservadas)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgObservaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private GEN.ControlesBase.dtgBase dtgSolicitudesObservadas;
        private System.Windows.Forms.GroupBox groupBox2;
        private GEN.ControlesBase.dtgBase dtgObservaciones;
        private GEN.BotonesBase.btnSalir btnSalir1;
    }
}