namespace CRE.Presentacion
{
    partial class frmMantenimientoCanales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoCanales));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.DtgMantenimientoCanales = new System.Windows.Forms.DataGridView();
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.btnAgregar1 = new GEN.BotonesBase.btnAgregar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            ((System.ComponentModel.ISupportInitialize)(this.DtgMantenimientoCanales)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 12);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(169, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Listado de Canales de Venta";
            // 
            // DtgMantenimientoCanales
            // 
            this.DtgMantenimientoCanales.AllowUserToAddRows = false;
            this.DtgMantenimientoCanales.AllowUserToDeleteRows = false;
            this.DtgMantenimientoCanales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgMantenimientoCanales.Location = new System.Drawing.Point(15, 41);
            this.DtgMantenimientoCanales.Name = "DtgMantenimientoCanales";
            this.DtgMantenimientoCanales.ReadOnly = true;
            this.DtgMantenimientoCanales.Size = new System.Drawing.Size(462, 150);
            this.DtgMantenimientoCanales.TabIndex = 3;
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(353, 199);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 5;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // btnAgregar1
            // 
            this.btnAgregar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar1.BackgroundImage")));
            this.btnAgregar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar1.Location = new System.Drawing.Point(286, 198);
            this.btnAgregar1.Name = "btnAgregar1";
            this.btnAgregar1.Size = new System.Drawing.Size(60, 50);
            this.btnAgregar1.TabIndex = 6;
            this.btnAgregar1.Text = "&Agregar";
            this.btnAgregar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregar1.UseVisualStyleBackColor = true;
            this.btnAgregar1.Click += new System.EventHandler(this.btnAgregar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(418, 199);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 13;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // frmMantenimientoCanales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 281);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnAgregar1);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.DtgMantenimientoCanales);
            this.Controls.Add(this.lblBase1);
            this.Name = "frmMantenimientoCanales";
            this.Text = "Mantenimiento de Canales";
            this.Load += new System.EventHandler(this.frmMantenimientoCanales_Load);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.DtgMantenimientoCanales, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.btnAgregar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DtgMantenimientoCanales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private System.Windows.Forms.DataGridView DtgMantenimientoCanales;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.BotonesBase.btnAgregar btnAgregar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
    }
}