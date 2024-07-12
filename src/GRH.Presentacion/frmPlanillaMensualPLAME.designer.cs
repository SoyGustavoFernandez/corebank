namespace GRH.Presentacion
{
    partial class frmPlanillaMensualPLAME
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlanillaMensualPLAME));
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboPeriodoDeclaracion1 = new GEN.ControlesBase.cboPeriodoDeclaracion(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.btnExaminar = new GEN.BotonesBase.Boton2();
            this.txtRuta = new GEN.ControlesBase.txtBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgPlanillas = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnProcesar = new GEN.BotonesBase.btnProcesar();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlanillas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(12, 30);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(105, 13);
            this.lblBase2.TabIndex = 1;
            this.lblBase2.Text = "Periodo de Pago:";
            // 
            // cboPeriodoDeclaracion1
            // 
            this.cboPeriodoDeclaracion1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPeriodoDeclaracion1.FormattingEnabled = true;
            this.cboPeriodoDeclaracion1.Location = new System.Drawing.Point(123, 27);
            this.cboPeriodoDeclaracion1.Name = "cboPeriodoDeclaracion1";
            this.cboPeriodoDeclaracion1.Size = new System.Drawing.Size(173, 21);
            this.cboPeriodoDeclaracion1.TabIndex = 2;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(12, 57);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(109, 13);
            this.lblBase3.TabIndex = 3;
            this.lblBase3.Text = "Ruta de Archivos:";
            // 
            // btnExaminar
            // 
            this.btnExaminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExaminar.Location = new System.Drawing.Point(388, 53);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(60, 21);
            this.btnExaminar.TabIndex = 4;
            this.btnExaminar.Text = "Examinar";
            this.btnExaminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExaminar.UseVisualStyleBackColor = true;
            this.btnExaminar.Click += new System.EventHandler(this.btnExaminar_Click);
            // 
            // txtRuta
            // 
            this.txtRuta.Enabled = false;
            this.txtRuta.Location = new System.Drawing.Point(123, 54);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.Size = new System.Drawing.Size(262, 20);
            this.txtRuta.TabIndex = 5;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.txtRuta);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.btnExaminar);
            this.grbBase1.Controls.Add(this.cboPeriodoDeclaracion1);
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(17, 17);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(454, 86);
            this.grbBase1.TabIndex = 6;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Filtros para la creación de Planilla Mensual ";
            // 
            // dtgPlanillas
            // 
            this.dtgPlanillas.AllowUserToAddRows = false;
            this.dtgPlanillas.AllowUserToDeleteRows = false;
            this.dtgPlanillas.AllowUserToResizeColumns = false;
            this.dtgPlanillas.AllowUserToResizeRows = false;
            this.dtgPlanillas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgPlanillas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPlanillas.Location = new System.Drawing.Point(17, 111);
            this.dtgPlanillas.MultiSelect = false;
            this.dtgPlanillas.Name = "dtgPlanillas";
            this.dtgPlanillas.ReadOnly = true;
            this.dtgPlanillas.RowHeadersVisible = false;
            this.dtgPlanillas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPlanillas.Size = new System.Drawing.Size(454, 284);
            this.dtgPlanillas.TabIndex = 7;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(411, 401);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 8;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnProcesar
            // 
            this.btnProcesar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar.BackgroundImage")));
            this.btnProcesar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar.Location = new System.Drawing.Point(345, 401);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar.TabIndex = 9;
            this.btnProcesar.Text = "&Procesar";
            this.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // frmPlanillaMensualPLAME
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 485);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.dtgPlanillas);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmPlanillaMensualPLAME";
            this.Text = "Planilla Mensual - PLAME";
            this.Load += new System.EventHandler(this.frmPlanillaMensualPLAME_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.dtgPlanillas, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnProcesar, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlanillas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboPeriodoDeclaracion cboPeriodoDeclaracion1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.BotonesBase.Boton2 btnExaminar;
        private GEN.ControlesBase.txtBase txtRuta;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.dtgBase dtgPlanillas;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnProcesar btnProcesar;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}