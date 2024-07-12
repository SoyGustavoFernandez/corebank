namespace CLI.Presentacion
{
    partial class frmConsultaMasivaDni
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaMasivaDni));
            this.dtgBase1 = new GEN.ControlesBase.dtgBase(this.components);
            this.btnImportar1 = new GEN.BotonesBase.btnImportar();
            this.btnConsultar1 = new GEN.BotonesBase.btnConsultar();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.tbcBase1 = new GEN.ControlesBase.tbcBase(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtRutaArchivo = new GEN.ControlesBase.txtBase(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.datePicker2 = new GEN.ControlesBase.DatePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtBase1 = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtBase2 = new GEN.ControlesBase.rbtBase(this.components);
            this.btnImprimir2 = new GEN.BotonesBase.btnImprimir();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBase1)).BeginInit();
            this.tbcBase1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgBase1
            // 
            this.dtgBase1.AllowUserToAddRows = false;
            this.dtgBase1.AllowUserToDeleteRows = false;
            this.dtgBase1.AllowUserToResizeColumns = false;
            this.dtgBase1.AllowUserToResizeRows = false;
            this.dtgBase1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgBase1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBase1.Location = new System.Drawing.Point(11, 66);
            this.dtgBase1.MultiSelect = false;
            this.dtgBase1.Name = "dtgBase1";
            this.dtgBase1.ReadOnly = true;
            this.dtgBase1.RowHeadersVisible = false;
            this.dtgBase1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgBase1.Size = new System.Drawing.Size(275, 160);
            this.dtgBase1.TabIndex = 2;
            // 
            // btnImportar1
            // 
            this.btnImportar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImportar1.BackgroundImage")));
            this.btnImportar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImportar1.Location = new System.Drawing.Point(303, 63);
            this.btnImportar1.Name = "btnImportar1";
            this.btnImportar1.Size = new System.Drawing.Size(60, 50);
            this.btnImportar1.TabIndex = 3;
            this.btnImportar1.Text = "&Importar";
            this.btnImportar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImportar1.UseVisualStyleBackColor = true;
            this.btnImportar1.Click += new System.EventHandler(this.btnImportar1_Click);
            // 
            // btnConsultar1
            // 
            this.btnConsultar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConsultar1.BackgroundImage")));
            this.btnConsultar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnConsultar1.Location = new System.Drawing.Point(303, 119);
            this.btnConsultar1.Name = "btnConsultar1";
            this.btnConsultar1.Size = new System.Drawing.Size(60, 50);
            this.btnConsultar1.TabIndex = 4;
            this.btnConsultar1.Text = "&Consultar";
            this.btnConsultar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConsultar1.UseVisualStyleBackColor = true;
            this.btnConsultar1.Click += new System.EventHandler(this.btnConsultar1_Click);
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(166, 67);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 5;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(265, 293);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 7;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(331, 293);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 9;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(8, 18);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(157, 13);
            this.lblBase1.TabIndex = 10;
            this.lblBase1.Text = "Consulta Masiva de DNI´s";
            // 
            // tbcBase1
            // 
            this.tbcBase1.Controls.Add(this.tabPage1);
            this.tbcBase1.Controls.Add(this.tabPage2);
            this.tbcBase1.Location = new System.Drawing.Point(12, 12);
            this.tbcBase1.Name = "tbcBase1";
            this.tbcBase1.SelectedIndex = 0;
            this.tbcBase1.Size = new System.Drawing.Size(383, 260);
            this.tbcBase1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnImprimir2);
            this.tabPage1.Controls.Add(this.lblBase3);
            this.tabPage1.Controls.Add(this.txtRutaArchivo);
            this.tabPage1.Controls.Add(this.lblBase1);
            this.tabPage1.Controls.Add(this.dtgBase1);
            this.tabPage1.Controls.Add(this.btnImportar1);
            this.tabPage1.Controls.Add(this.btnConsultar1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(375, 234);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Consulta";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(6, 37);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(106, 13);
            this.lblBase3.TabIndex = 13;
            this.lblBase3.Text = "Ruta de archivo :";
            // 
            // txtRutaArchivo
            // 
            this.txtRutaArchivo.Enabled = false;
            this.txtRutaArchivo.Location = new System.Drawing.Point(114, 34);
            this.txtRutaArchivo.Name = "txtRutaArchivo";
            this.txtRutaArchivo.Size = new System.Drawing.Size(254, 20);
            this.txtRutaArchivo.TabIndex = 12;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblBase4);
            this.tabPage2.Controls.Add(this.lblBase2);
            this.tabPage2.Controls.Add(this.datePicker2);
            this.tabPage2.Controls.Add(this.btnImprimir1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(375, 234);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Reporte";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(81, 41);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(38, 13);
            this.lblBase4.TabIndex = 4;
            this.lblBase4.Text = "Mes :";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(19, 16);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(130, 13);
            this.lblBase2.TabIndex = 2;
            this.lblBase2.Text = "Reporte de Consultas";
            // 
            // datePicker2
            // 
            this.datePicker2.CustomFormat = "MM/yyyy";
            this.datePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePicker2.Location = new System.Drawing.Point(125, 41);
            this.datePicker2.Name = "datePicker2";
            this.datePicker2.Size = new System.Drawing.Size(101, 20);
            this.datePicker2.TabIndex = 1;
            this.datePicker2.Value = new System.DateTime(2020, 6, 18, 16, 25, 4, 826);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtBase2);
            this.groupBox1.Controls.Add(this.rbtBase1);
            this.groupBox1.Location = new System.Drawing.Point(12, 278);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 76);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione la forma de Presentacion de Reporte :";
            // 
            // rbtBase1
            // 
            this.rbtBase1.AutoSize = true;
            this.rbtBase1.ForeColor = System.Drawing.Color.Navy;
            this.rbtBase1.Location = new System.Drawing.Point(61, 19);
            this.rbtBase1.Name = "rbtBase1";
            this.rbtBase1.Size = new System.Drawing.Size(142, 17);
            this.rbtBase1.TabIndex = 0;
            this.rbtBase1.TabStop = true;
            this.rbtBase1.Text = "Visualizacion de Reporte";
            this.rbtBase1.UseVisualStyleBackColor = true;
            // 
            // rbtBase2
            // 
            this.rbtBase2.AutoSize = true;
            this.rbtBase2.ForeColor = System.Drawing.Color.Navy;
            this.rbtBase2.Location = new System.Drawing.Point(61, 42);
            this.rbtBase2.Name = "rbtBase2";
            this.rbtBase2.Size = new System.Drawing.Size(115, 17);
            this.rbtBase2.TabIndex = 1;
            this.rbtBase2.TabStop = true;
            this.rbtBase2.Text = "Descarga en Excel";
            this.rbtBase2.UseVisualStyleBackColor = true;
            // 
            // btnImprimir2
            // 
            this.btnImprimir2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir2.BackgroundImage")));
            this.btnImprimir2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir2.Location = new System.Drawing.Point(303, 176);
            this.btnImprimir2.Name = "btnImprimir2";
            this.btnImprimir2.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir2.TabIndex = 14;
            this.btnImprimir2.Text = "Imprimir";
            this.btnImprimir2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir2.UseVisualStyleBackColor = true;
            this.btnImprimir2.Click += new System.EventHandler(this.btnImprimir2_Click);
            // 
            // frmConsultaMasivaDni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 382);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbcBase1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnCancelar1);
            this.Name = "frmConsultaMasivaDni";
            this.Text = "Consulta Masiva Reniec";
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.tbcBase1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgBase1)).EndInit();
            this.tbcBase1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgBase1;
        private GEN.BotonesBase.btnImportar btnImportar1;
        private GEN.BotonesBase.btnConsultar btnConsultar1;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.tbcBase tbcBase1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.DatePicker datePicker2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtBase txtRutaArchivo;
        private System.Windows.Forms.GroupBox groupBox1;
        private GEN.ControlesBase.rbtBase rbtBase2;
        private GEN.ControlesBase.rbtBase rbtBase1;
        private GEN.BotonesBase.btnImprimir btnImprimir2;
    }
}