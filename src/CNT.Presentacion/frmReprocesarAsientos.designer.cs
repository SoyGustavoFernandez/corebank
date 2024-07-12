namespace CNT.Presentacion
{
    partial class frmReprocesarAsientos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReprocesarAsientos));
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnProcesar = new GEN.BotonesBase.btnProcesar();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtFecReproceso = new GEN.ControlesBase.dtLargoBase(this.components);
            this.dtgLisProCierre = new GEN.ControlesBase.dtgBase(this.components);
            this.dtFecRepFin = new GEN.ControlesBase.dtLargoBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.chcTodos = new GEN.ControlesBase.chcBase(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgLisProCierre)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(296, 356);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnProcesar
            // 
            this.btnProcesar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar.BackgroundImage")));
            this.btnProcesar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar.Location = new System.Drawing.Point(230, 356);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar.TabIndex = 4;
            this.btnProcesar.Text = "&Procesar";
            this.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(71, 22);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(236, 13);
            this.lblBase1.TabIndex = 8;
            this.lblBase1.Text = "REPROCESO DE ASIENTOS CONTABLES";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(19, 54);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(148, 13);
            this.lblBase2.TabIndex = 12;
            this.lblBase2.Text = "Fecha de Re-proceso del";
            // 
            // dtFecReproceso
            // 
            this.dtFecReproceso.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecReproceso.Location = new System.Drawing.Point(171, 50);
            this.dtFecReproceso.Name = "dtFecReproceso";
            this.dtFecReproceso.Size = new System.Drawing.Size(80, 20);
            this.dtFecReproceso.TabIndex = 0;
            // 
            // dtgLisProCierre
            // 
            this.dtgLisProCierre.AllowUserToAddRows = false;
            this.dtgLisProCierre.AllowUserToDeleteRows = false;
            this.dtgLisProCierre.AllowUserToResizeColumns = false;
            this.dtgLisProCierre.AllowUserToResizeRows = false;
            this.dtgLisProCierre.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgLisProCierre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgLisProCierre.Location = new System.Drawing.Point(22, 101);
            this.dtgLisProCierre.MultiSelect = false;
            this.dtgLisProCierre.Name = "dtgLisProCierre";
            this.dtgLisProCierre.ReadOnly = true;
            this.dtgLisProCierre.RowHeadersVisible = false;
            this.dtgLisProCierre.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgLisProCierre.Size = new System.Drawing.Size(334, 245);
            this.dtgLisProCierre.TabIndex = 3;
            // 
            // dtFecRepFin
            // 
            this.dtFecRepFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecRepFin.Location = new System.Drawing.Point(274, 50);
            this.dtFecRepFin.Name = "dtFecRepFin";
            this.dtFecRepFin.Size = new System.Drawing.Size(82, 20);
            this.dtFecRepFin.TabIndex = 1;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(255, 54);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(17, 13);
            this.lblBase3.TabIndex = 16;
            this.lblBase3.Text = "al";
            // 
            // chcTodos
            // 
            this.chcTodos.AutoSize = true;
            this.chcTodos.Location = new System.Drawing.Point(294, 78);
            this.chcTodos.Name = "chcTodos";
            this.chcTodos.Size = new System.Drawing.Size(62, 17);
            this.chcTodos.TabIndex = 2;
            this.chcTodos.Text = "Todos?";
            this.chcTodos.UseVisualStyleBackColor = true;
            this.chcTodos.CheckedChanged += new System.EventHandler(this.chcTodos_CheckedChanged);
            // 
            // frmReprocesarAsientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 438);
            this.Controls.Add(this.chcTodos);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.dtFecRepFin);
            this.Controls.Add(this.dtgLisProCierre);
            this.Controls.Add(this.dtFecReproceso);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.lblBase1);
            this.Name = "frmReprocesarAsientos";
            this.Text = "Reproceso de Asientos Contables";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmReprocesarAsientos_FormClosed);
            this.Load += new System.EventHandler(this.frmReprocesarAsientos_Load);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.btnProcesar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.dtFecReproceso, 0);
            this.Controls.SetChildIndex(this.dtgLisProCierre, 0);
            this.Controls.SetChildIndex(this.dtFecRepFin, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.chcTodos, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgLisProCierre)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnProcesar btnProcesar;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.dtLargoBase dtFecReproceso;
        private GEN.ControlesBase.dtgBase dtgLisProCierre;
        private GEN.ControlesBase.dtLargoBase dtFecRepFin;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.chcBase chcTodos;
    }
}