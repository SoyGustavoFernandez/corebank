namespace CRE.Presentacion
{
    partial class frmVistaObservacionesApro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVistaObservacionesApro));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.bindingObsAprobador = new System.Windows.Forms.BindingSource(this.components);
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.dtgObsAprobador = new System.Windows.Forms.DataGridView();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingObsAprobador)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgObsAprobador)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.panel6);
            this.grbBase1.Location = new System.Drawing.Point(12, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(702, 256);
            this.grbBase1.TabIndex = 2;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Lista de Observaciones";
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(648, 274);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 1;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Location = new System.Drawing.Point(6, 19);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(690, 222);
            this.panel6.TabIndex = 105;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(690, 219);
            this.panel7.TabIndex = 78;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.panel9);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(688, 217);
            this.panel8.TabIndex = 25;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.dtgObsAprobador);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(688, 217);
            this.panel9.TabIndex = 25;
            // 
            // dtgObsAprobador
            // 
            this.dtgObsAprobador.AllowUserToAddRows = false;
            this.dtgObsAprobador.AllowUserToDeleteRows = false;
            this.dtgObsAprobador.AllowUserToResizeColumns = false;
            this.dtgObsAprobador.AllowUserToResizeRows = false;
            this.dtgObsAprobador.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgObsAprobador.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgObsAprobador.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgObsAprobador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgObsAprobador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgObsAprobador.Location = new System.Drawing.Point(0, 0);
            this.dtgObsAprobador.MultiSelect = false;
            this.dtgObsAprobador.Name = "dtgObsAprobador";
            this.dtgObsAprobador.RowHeadersVisible = false;
            this.dtgObsAprobador.Size = new System.Drawing.Size(688, 217);
            this.dtgObsAprobador.TabIndex = 10;
            this.dtgObsAprobador.TabStop = false;
            // 
            // frmVistaObservacionesApro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 356);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmVistaObservacionesApro";
            this.Text = "Vista Observaciones";
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.grbBase1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingObsAprobador)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgObsAprobador)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private System.Windows.Forms.BindingSource bindingObsAprobador;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.DataGridView dtgObsAprobador;
    }
}