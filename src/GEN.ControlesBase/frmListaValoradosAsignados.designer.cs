namespace GEN.ControlesBase
{
    partial class frmListaValoradosAsignados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaValoradosAsignados));
            this.grbValoradosAsignados = new GEN.ControlesBase.grbBase();
            this.dtgValAsigAge = new GEN.ControlesBase.dtgBase();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.grbValoradosAsignados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValAsigAge)).BeginInit();
            this.SuspendLayout();
            // 
            // grbValoradosAsignados
            // 
            this.grbValoradosAsignados.Controls.Add(this.dtgValAsigAge);
            this.grbValoradosAsignados.Location = new System.Drawing.Point(4, 6);
            this.grbValoradosAsignados.Name = "grbValoradosAsignados";
            this.grbValoradosAsignados.Size = new System.Drawing.Size(490, 189);
            this.grbValoradosAsignados.TabIndex = 4;
            this.grbValoradosAsignados.TabStop = false;
            this.grbValoradosAsignados.Text = "Valorados:";
            // 
            // dtgValAsigAge
            // 
            this.dtgValAsigAge.AllowUserToAddRows = false;
            this.dtgValAsigAge.AllowUserToDeleteRows = false;
            this.dtgValAsigAge.AllowUserToResizeColumns = false;
            this.dtgValAsigAge.AllowUserToResizeRows = false;
            this.dtgValAsigAge.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgValAsigAge.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgValAsigAge.Location = new System.Drawing.Point(7, 19);
            this.dtgValAsigAge.MultiSelect = false;
            this.dtgValAsigAge.Name = "dtgValAsigAge";
            this.dtgValAsigAge.ReadOnly = true;
            this.dtgValAsigAge.RowHeadersVisible = false;
            this.dtgValAsigAge.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgValAsigAge.Size = new System.Drawing.Size(476, 159);
            this.dtgValAsigAge.TabIndex = 5;
            this.dtgValAsigAge.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgValAsigAge_CellContentDoubleClick);
            this.dtgValAsigAge.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgValAsigAge_CellDoubleClick);
            this.dtgValAsigAge.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgValAsigAge_KeyDown);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(427, 202);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(361, 201);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmListaValoradosAsignados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 280);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.grbValoradosAsignados);
            this.Controls.Add(this.btnSalir);
            this.Name = "frmListaValoradosAsignados";
            this.Text = "Lista Valorados Asignados ";
            this.Load += new System.EventHandler(this.frmListaValoradosAsignados_Load);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.grbValoradosAsignados, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.grbValoradosAsignados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgValAsigAge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private grbBase grbValoradosAsignados;
        private dtgBase dtgValAsigAge;
        private BotonesBase.btnSalir btnSalir;
        private BotonesBase.BtnAceptar btnAceptar;
    }
}