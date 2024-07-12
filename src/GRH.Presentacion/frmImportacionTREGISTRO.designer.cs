namespace GRH.Presentacion
{
    partial class frmImportacionTREGISTRO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportacionTREGISTRO));
            this.btnProcesar = new GEN.BotonesBase.btnProcesar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.dtgT_REGISTRO = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtRuta = new GEN.ControlesBase.txtBase(this.components);
            this.btnExaminar = new GEN.BotonesBase.Boton2();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboPeriodoDeclaracion1 = new GEN.ControlesBase.cboPeriodoDeclaracion(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgT_REGISTRO)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProcesar
            // 
            this.btnProcesar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar.BackgroundImage")));
            this.btnProcesar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar.Location = new System.Drawing.Point(344, 400);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar.TabIndex = 13;
            this.btnProcesar.Text = "&Procesar";
            this.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(410, 400);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 12;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // dtgT_REGISTRO
            // 
            this.dtgT_REGISTRO.AllowUserToAddRows = false;
            this.dtgT_REGISTRO.AllowUserToDeleteRows = false;
            this.dtgT_REGISTRO.AllowUserToResizeColumns = false;
            this.dtgT_REGISTRO.AllowUserToResizeRows = false;
            this.dtgT_REGISTRO.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgT_REGISTRO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgT_REGISTRO.Location = new System.Drawing.Point(16, 116);
            this.dtgT_REGISTRO.MultiSelect = false;
            this.dtgT_REGISTRO.Name = "dtgT_REGISTRO";
            this.dtgT_REGISTRO.ReadOnly = true;
            this.dtgT_REGISTRO.RowHeadersVisible = false;
            this.dtgT_REGISTRO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgT_REGISTRO.Size = new System.Drawing.Size(454, 278);
            this.dtgT_REGISTRO.TabIndex = 11;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.cboPeriodoDeclaracion1);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.txtRuta);
            this.grbBase1.Controls.Add(this.btnExaminar);
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(16, 16);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(454, 94);
            this.grbBase1.TabIndex = 10;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Filtros para la creación de Planilla Mensual ";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(12, 60);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(109, 13);
            this.lblBase3.TabIndex = 3;
            this.lblBase3.Text = "Ruta de Archivos:";
            // 
            // txtRuta
            // 
            this.txtRuta.Enabled = false;
            this.txtRuta.Location = new System.Drawing.Point(123, 57);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.Size = new System.Drawing.Size(262, 20);
            this.txtRuta.TabIndex = 5;
            // 
            // btnExaminar
            // 
            this.btnExaminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExaminar.Location = new System.Drawing.Point(388, 56);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(60, 21);
            this.btnExaminar.TabIndex = 4;
            this.btnExaminar.Text = "Examinar";
            this.btnExaminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExaminar.UseVisualStyleBackColor = true;
            this.btnExaminar.Click += new System.EventHandler(this.btnExaminar_Click);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(16, 28);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(105, 13);
            this.lblBase2.TabIndex = 6;
            this.lblBase2.Text = "Periodo de Pago:";
            // 
            // cboPeriodoDeclaracion1
            // 
            this.cboPeriodoDeclaracion1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPeriodoDeclaracion1.FormattingEnabled = true;
            this.cboPeriodoDeclaracion1.Location = new System.Drawing.Point(123, 25);
            this.cboPeriodoDeclaracion1.Name = "cboPeriodoDeclaracion1";
            this.cboPeriodoDeclaracion1.Size = new System.Drawing.Size(128, 21);
            this.cboPeriodoDeclaracion1.TabIndex = 7;
            // 
            // frmImportacionTREGISTRO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 478);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.dtgT_REGISTRO);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmImportacionTREGISTRO";
            this.Text = "Importación de T-REGISTRO";
            this.Load += new System.EventHandler(this.frmImportacionTREGISTRO_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.dtgT_REGISTRO, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnProcesar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgT_REGISTRO)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnProcesar btnProcesar;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.dtgBase dtgT_REGISTRO;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtBase txtRuta;
        private GEN.BotonesBase.Boton2 btnExaminar;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboPeriodoDeclaracion cboPeriodoDeclaracion1;
    }
}