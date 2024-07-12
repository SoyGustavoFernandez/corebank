namespace RCP.Presentacion
{
    partial class frmPlanTrabajoListaSolicitud
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlanTrabajoListaSolicitud));
            this.dtgPlanTrabajoSolicitado = new GEN.ControlesBase.dtgBase(this.components);
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlanTrabajoSolicitado)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgPlanTrabajoSolicitado
            // 
            this.dtgPlanTrabajoSolicitado.AllowUserToAddRows = false;
            this.dtgPlanTrabajoSolicitado.AllowUserToDeleteRows = false;
            this.dtgPlanTrabajoSolicitado.AllowUserToResizeColumns = false;
            this.dtgPlanTrabajoSolicitado.AllowUserToResizeRows = false;
            this.dtgPlanTrabajoSolicitado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgPlanTrabajoSolicitado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPlanTrabajoSolicitado.Location = new System.Drawing.Point(13, 24);
            this.dtgPlanTrabajoSolicitado.MultiSelect = false;
            this.dtgPlanTrabajoSolicitado.Name = "dtgPlanTrabajoSolicitado";
            this.dtgPlanTrabajoSolicitado.ReadOnly = true;
            this.dtgPlanTrabajoSolicitado.RowHeadersVisible = false;
            this.dtgPlanTrabajoSolicitado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPlanTrabajoSolicitado.Size = new System.Drawing.Size(558, 146);
            this.dtgPlanTrabajoSolicitado.TabIndex = 2;
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(445, 176);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 3;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(511, 176);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 4;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(13, 5);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(228, 13);
            this.lblBase1.TabIndex = 5;
            this.lblBase1.Text = "Lista de Planes de Trabajo Pendientes:";
            // 
            // frmPlanTrabajoListaSolicitud
            // 
            this.AcceptButton = this.btnAceptar1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 258);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnAceptar1);
            this.Controls.Add(this.dtgPlanTrabajoSolicitado);
            this.Name = "frmPlanTrabajoListaSolicitud";
            this.Text = "Planes de Trabajo Pendientes";
            this.Load += new System.EventHandler(this.frmPlanTrabajoListaSolicitud_Load);
            this.Controls.SetChildIndex(this.dtgPlanTrabajoSolicitado, 0);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlanTrabajoSolicitado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgPlanTrabajoSolicitado;
        private GEN.BotonesBase.BtnAceptar btnAceptar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.lblBase lblBase1;
    }
}