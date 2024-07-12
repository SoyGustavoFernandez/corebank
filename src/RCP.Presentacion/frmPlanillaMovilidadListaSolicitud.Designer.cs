namespace RCP.Presentacion
{
    partial class frmPlanillaMovilidadListaSolicitud
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlanillaMovilidadListaSolicitud));
            this.dtgPlanillaMovilidadSolicitado = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlanillaMovilidadSolicitado)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgPlanillaMovilidadSolicitado
            // 
            this.dtgPlanillaMovilidadSolicitado.AllowUserToAddRows = false;
            this.dtgPlanillaMovilidadSolicitado.AllowUserToDeleteRows = false;
            this.dtgPlanillaMovilidadSolicitado.AllowUserToResizeColumns = false;
            this.dtgPlanillaMovilidadSolicitado.AllowUserToResizeRows = false;
            this.dtgPlanillaMovilidadSolicitado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgPlanillaMovilidadSolicitado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPlanillaMovilidadSolicitado.Location = new System.Drawing.Point(12, 25);
            this.dtgPlanillaMovilidadSolicitado.MultiSelect = false;
            this.dtgPlanillaMovilidadSolicitado.Name = "dtgPlanillaMovilidadSolicitado";
            this.dtgPlanillaMovilidadSolicitado.ReadOnly = true;
            this.dtgPlanillaMovilidadSolicitado.RowHeadersVisible = false;
            this.dtgPlanillaMovilidadSolicitado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPlanillaMovilidadSolicitado.Size = new System.Drawing.Size(558, 146);
            this.dtgPlanillaMovilidadSolicitado.TabIndex = 2;
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(512, 177);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(446, 177);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 4;
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
            this.lblBase1.Location = new System.Drawing.Point(9, 9);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(244, 13);
            this.lblBase1.TabIndex = 5;
            this.lblBase1.Text = "Lista de Planillas de Movilidad solicitadas:";
            // 
            // frmPlanillaMovilidadListaSolicitud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dtgPlanillaMovilidadSolicitado);
            this.Name = "frmPlanillaMovilidadListaSolicitud";
            this.Text = "Planilas de Movilidad solicitadas";
            this.Load += new System.EventHandler(this.frmPlanillaMovilidadListaSolicitud_Load);
            this.Controls.SetChildIndex(this.dtgPlanillaMovilidadSolicitado, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlanillaMovilidadSolicitado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgPlanillaMovilidadSolicitado;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.ControlesBase.lblBase lblBase1;
    }
}