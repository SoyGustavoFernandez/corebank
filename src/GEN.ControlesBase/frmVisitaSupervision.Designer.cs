namespace GEN.ControlesBase
{
    partial class frmVisitaSupervision
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVisitaSupervision));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.conFiltroSupervision1 = new GEN.ControlesBase.ConFiltroSupervision();
            this.dtgVisita = new GEN.ControlesBase.dtgBase(this.components);
            this.btnBusqueda1 = new GEN.BotonesBase.btnBusqueda();
            this.btnEliminar1 = new GEN.BotonesBase.btnEliminar();
            this.btnRevisar1 = new GEN.BotonesBase.btnRevisar();
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgVisita)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.conFiltroSupervision1);
            this.grbBase1.Location = new System.Drawing.Point(9, 4);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(862, 102);
            this.grbBase1.TabIndex = 5;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos a Filtrar";
            // 
            // conFiltroSupervision1
            // 
            this.conFiltroSupervision1.AutoSize = true;
            this.conFiltroSupervision1.Location = new System.Drawing.Point(0, 14);
            this.conFiltroSupervision1.Name = "conFiltroSupervision1";
            this.conFiltroSupervision1.Size = new System.Drawing.Size(864, 85);
            this.conFiltroSupervision1.TabIndex = 0;
            this.conFiltroSupervision1.FiltroChanged += new System.EventHandler(this.conFiltroSupervision1_FiltroChanged);
            // 
            // dtgVisita
            // 
            this.dtgVisita.AllowUserToAddRows = false;
            this.dtgVisita.AllowUserToDeleteRows = false;
            this.dtgVisita.AllowUserToResizeColumns = false;
            this.dtgVisita.AllowUserToResizeRows = false;
            this.dtgVisita.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgVisita.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgVisita.Location = new System.Drawing.Point(9, 112);
            this.dtgVisita.MultiSelect = false;
            this.dtgVisita.Name = "dtgVisita";
            this.dtgVisita.ReadOnly = true;
            this.dtgVisita.RowHeadersVisible = false;
            this.dtgVisita.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgVisita.Size = new System.Drawing.Size(945, 208);
            this.dtgVisita.TabIndex = 6;
            // 
            // btnBusqueda1
            // 
            this.btnBusqueda1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda1.BackgroundImage")));
            this.btnBusqueda1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda1.Location = new System.Drawing.Point(879, 56);
            this.btnBusqueda1.Name = "btnBusqueda1";
            this.btnBusqueda1.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda1.TabIndex = 11;
            this.btnBusqueda1.Text = "&Buscar";
            this.btnBusqueda1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda1.UseVisualStyleBackColor = true;
            this.btnBusqueda1.Click += new System.EventHandler(this.btnBusqueda1_Click);
            // 
            // btnEliminar1
            // 
            this.btnEliminar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar1.BackgroundImage")));
            this.btnEliminar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEliminar1.Enabled = false;
            this.btnEliminar1.Location = new System.Drawing.Point(693, 325);
            this.btnEliminar1.Name = "btnEliminar1";
            this.btnEliminar1.Size = new System.Drawing.Size(60, 50);
            this.btnEliminar1.TabIndex = 16;
            this.btnEliminar1.Text = "&Eliminar";
            this.btnEliminar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminar1.UseVisualStyleBackColor = true;
            this.btnEliminar1.Click += new System.EventHandler(this.btnEliminar1_Click);
            // 
            // btnRevisar1
            // 
            this.btnRevisar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRevisar1.BackgroundImage")));
            this.btnRevisar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRevisar1.Enabled = false;
            this.btnRevisar1.Location = new System.Drawing.Point(759, 325);
            this.btnRevisar1.Name = "btnRevisar1";
            this.btnRevisar1.Size = new System.Drawing.Size(60, 50);
            this.btnRevisar1.TabIndex = 15;
            this.btnRevisar1.Text = "Revisar";
            this.btnRevisar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRevisar1.UseVisualStyleBackColor = true;
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Location = new System.Drawing.Point(825, 325);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 14;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(890, 325);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 13;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // frmVisitaSupervision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 400);
            this.Controls.Add(this.btnEliminar1);
            this.Controls.Add(this.btnRevisar1);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnBusqueda1);
            this.Controls.Add(this.dtgVisita);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmVisitaSupervision";
            this.Text = "Evaluación de Visita de Supervisión";
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.dtgVisita, 0);
            this.Controls.SetChildIndex(this.btnBusqueda1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.btnRevisar1, 0);
            this.Controls.SetChildIndex(this.btnEliminar1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgVisita)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private grbBase grbBase1;
        private ConFiltroSupervision conFiltroSupervision1;
        private BotonesBase.btnBusqueda btnBusqueda1;
        private BotonesBase.btnEliminar btnEliminar1;
        private BotonesBase.btnNuevo btnNuevo1;
        private BotonesBase.btnSalir btnSalir1;
        public BotonesBase.btnRevisar btnRevisar1;
        private dtgBase dtgVisita;
    }
}