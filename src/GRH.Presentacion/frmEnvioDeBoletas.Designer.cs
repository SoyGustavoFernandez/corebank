namespace GRH.Presentacion
{
    partial class frmEnvioDeBoletas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEnvioDeBoletas));
            this.txtBase1 = new GEN.ControlesBase.txtBase(this.components);
            this.txtBase2 = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtBase3 = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.btnCargarFile1 = new GEN.BotonesBase.btnCargarFile();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnValidar1 = new GEN.BotonesBase.btnValidar();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.dtgBase1 = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnEnviar1 = new GEN.BotonesBase.btnEnviar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnExporExcel1 = new GEN.BotonesBase.btnExporExcel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBase1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBase1
            // 
            this.txtBase1.Location = new System.Drawing.Point(129, 12);
            this.txtBase1.Name = "txtBase1";
            this.txtBase1.Size = new System.Drawing.Size(111, 20);
            this.txtBase1.TabIndex = 2;
            // 
            // txtBase2
            // 
            this.txtBase2.Location = new System.Drawing.Point(129, 38);
            this.txtBase2.Name = "txtBase2";
            this.txtBase2.PasswordChar = '*';
            this.txtBase2.Size = new System.Drawing.Size(201, 20);
            this.txtBase2.TabIndex = 3;
            this.txtBase2.Text = "123456789";
            this.txtBase2.Visible = false;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(1, 12);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(122, 13);
            this.lblBase1.TabIndex = 4;
            this.lblBase1.Text = "Correo electrónico :";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(41, 38);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(82, 13);
            this.lblBase2.TabIndex = 5;
            this.lblBase2.Text = "Contraseña :";
            this.lblBase2.Visible = false;
            // 
            // txtBase3
            // 
            this.txtBase3.Location = new System.Drawing.Point(15, 100);
            this.txtBase3.Name = "txtBase3";
            this.txtBase3.Size = new System.Drawing.Size(315, 20);
            this.txtBase3.TabIndex = 8;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(12, 84);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(313, 13);
            this.lblBase4.TabIndex = 9;
            this.lblBase4.Text = "Seleccionar Carpeta donde se encuentran las Boletas";
            // 
            // btnCargarFile1
            // 
            this.btnCargarFile1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCargarFile1.BackgroundImage")));
            this.btnCargarFile1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCargarFile1.Location = new System.Drawing.Point(419, 76);
            this.btnCargarFile1.Name = "btnCargarFile1";
            this.btnCargarFile1.Size = new System.Drawing.Size(60, 50);
            this.btnCargarFile1.TabIndex = 10;
            this.btnCargarFile1.Text = "Examinar";
            this.btnCargarFile1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCargarFile1.UseVisualStyleBackColor = true;
            this.btnCargarFile1.Click += new System.EventHandler(this.btnCargarFile1_Click);
            // 
            // btnValidar1
            // 
            this.btnValidar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnValidar1.BackgroundImage")));
            this.btnValidar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnValidar1.Location = new System.Drawing.Point(419, 8);
            this.btnValidar1.Name = "btnValidar1";
            this.btnValidar1.Size = new System.Drawing.Size(60, 50);
            this.btnValidar1.TabIndex = 11;
            this.btnValidar1.Text = "&Validar";
            this.btnValidar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnValidar1.UseVisualStyleBackColor = true;
            this.btnValidar1.Click += new System.EventHandler(this.btnValidar1_Click);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(12, 171);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(138, 13);
            this.lblBase3.TabIndex = 13;
            this.lblBase3.Text = "Datos de Colaborador:";
            // 
            // dtgBase1
            // 
            this.dtgBase1.AllowUserToAddRows = false;
            this.dtgBase1.AllowUserToDeleteRows = false;
            this.dtgBase1.AllowUserToResizeColumns = false;
            this.dtgBase1.AllowUserToResizeRows = false;
            this.dtgBase1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgBase1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBase1.Location = new System.Drawing.Point(12, 194);
            this.dtgBase1.MultiSelect = false;
            this.dtgBase1.Name = "dtgBase1";
            this.dtgBase1.ReadOnly = true;
            this.dtgBase1.RowHeadersVisible = false;
            this.dtgBase1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgBase1.Size = new System.Drawing.Size(500, 203);
            this.dtgBase1.TabIndex = 15;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(419, 403);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 16;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnEnviar1
            // 
            this.btnEnviar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEnviar1.BackgroundImage")));
            this.btnEnviar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEnviar1.Location = new System.Drawing.Point(287, 403);
            this.btnEnviar1.Name = "btnEnviar1";
            this.btnEnviar1.Size = new System.Drawing.Size(60, 50);
            this.btnEnviar1.TabIndex = 17;
            this.btnEnviar1.Text = "&Enviar";
            this.btnEnviar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnviar1.UseVisualStyleBackColor = true;
            this.btnEnviar1.Click += new System.EventHandler(this.btnEnviar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(353, 403);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 18;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnExporExcel1
            // 
            this.btnExporExcel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExporExcel1.BackgroundImage")));
            this.btnExporExcel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExporExcel1.Location = new System.Drawing.Point(419, 138);
            this.btnExporExcel1.Name = "btnExporExcel1";
            this.btnExporExcel1.Size = new System.Drawing.Size(60, 50);
            this.btnExporExcel1.TabIndex = 19;
            this.btnExporExcel1.Text = "E&xcel";
            this.btnExporExcel1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExporExcel1.UseVisualStyleBackColor = true;
            this.btnExporExcel1.Click += new System.EventHandler(this.btnExporExcel1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(239, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 25);
            this.label1.TabIndex = 21;
            this.label1.Text = "@cajalosandes.pe";
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(221, 403);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 22;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // frmEnvioDeBoletas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 484);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExporExcel1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnEnviar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.dtgBase1);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.btnValidar1);
            this.Controls.Add(this.btnCargarFile1);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.txtBase3);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.txtBase2);
            this.Controls.Add(this.txtBase1);
            this.Name = "frmEnvioDeBoletas";
            this.Text = "Envío de Boletas de Pago CRACLA SA";
            this.Controls.SetChildIndex(this.txtBase1, 0);
            this.Controls.SetChildIndex(this.txtBase2, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.txtBase3, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.btnCargarFile1, 0);
            this.Controls.SetChildIndex(this.btnValidar1, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.dtgBase1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnEnviar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnExporExcel1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgBase1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.txtBase txtBase1;
        private GEN.ControlesBase.txtBase txtBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.BotonesBase.btnCargarFile btnCargarFile1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private GEN.BotonesBase.btnValidar btnValidar1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.dtgBase dtgBase1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnEnviar btnEnviar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnExporExcel btnExporExcel1;
        private System.Windows.Forms.Label label1;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
    }
}