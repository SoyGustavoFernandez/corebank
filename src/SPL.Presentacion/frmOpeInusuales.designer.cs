namespace SPL.Presentacion
{
    partial class frmOpeInusuales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOpeInusuales));
            this.cboOperaciones = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtgLista = new GEN.ControlesBase.dtgBase(this.components);
            this.conFechaAñoMesHasta = new GEN.ControlesBase.ConFechaAñoMes();
            this.conFechaAñoMesDesde = new GEN.ControlesBase.ConFechaAñoMes();
            this.cboMeses = new GEN.ControlesBase.cboMeses(this.components);
            this.nudAnio = new GEN.ControlesBase.nudBase(this.components);
            this.btnProcesar1 = new GEN.BotonesBase.btnProcesar();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.conBusUbig1 = new GEN.ControlesBase.ConBusUbig();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.cboPerfiles = new GEN.ControlesBase.cboBase(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgLista)).BeginInit();
            this.conFechaAñoMesDesde.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).BeginInit();
            this.SuspendLayout();
            // 
            // cboOperaciones
            // 
            this.cboOperaciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOperaciones.FormattingEnabled = true;
            this.cboOperaciones.Location = new System.Drawing.Point(12, 22);
            this.cboOperaciones.Name = "cboOperaciones";
            this.cboOperaciones.Size = new System.Drawing.Size(121, 21);
            this.cboOperaciones.TabIndex = 11;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(12, 6);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(83, 13);
            this.lblBase2.TabIndex = 9;
            this.lblBase2.Text = "Operaciones:";
            // 
            // dtgLista
            // 
            this.dtgLista.AllowUserToAddRows = false;
            this.dtgLista.AllowUserToDeleteRows = false;
            this.dtgLista.AllowUserToResizeColumns = false;
            this.dtgLista.AllowUserToResizeRows = false;
            this.dtgLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgLista.Location = new System.Drawing.Point(7, 135);
            this.dtgLista.MultiSelect = false;
            this.dtgLista.Name = "dtgLista";
            this.dtgLista.ReadOnly = true;
            this.dtgLista.RowHeadersVisible = false;
            this.dtgLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgLista.Size = new System.Drawing.Size(770, 345);
            this.dtgLista.TabIndex = 7;
            // 
            // conFechaAñoMesHasta
            // 
            this.conFechaAñoMesHasta.anio = 1;
            this.conFechaAñoMesHasta.cMes = "ENERO";
            this.conFechaAñoMesHasta.idMes = 1;
            this.conFechaAñoMesHasta.Location = new System.Drawing.Point(236, 52);
            this.conFechaAñoMesHasta.Name = "conFechaAñoMesHasta";
            this.conFechaAñoMesHasta.Size = new System.Drawing.Size(164, 39);
            this.conFechaAñoMesHasta.TabIndex = 12;
            // 
            // conFechaAñoMesDesde
            // 
            this.conFechaAñoMesDesde.anio = 1;
            this.conFechaAñoMesDesde.cMes = "ENERO";
            this.conFechaAñoMesDesde.Controls.Add(this.cboMeses);
            this.conFechaAñoMesDesde.Controls.Add(this.nudAnio);
            this.conFechaAñoMesDesde.idMes = 1;
            this.conFechaAñoMesDesde.Location = new System.Drawing.Point(236, 7);
            this.conFechaAñoMesDesde.Name = "conFechaAñoMesDesde";
            this.conFechaAñoMesDesde.Size = new System.Drawing.Size(164, 39);
            this.conFechaAñoMesDesde.TabIndex = 13;
            // 
            // cboMeses
            // 
            this.cboMeses.DisplayMember = "cMes";
            this.cboMeses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMeses.FormattingEnabled = true;
            this.cboMeses.Location = new System.Drawing.Point(1, 15);
            this.cboMeses.Name = "cboMeses";
            this.cboMeses.Size = new System.Drawing.Size(106, 21);
            this.cboMeses.TabIndex = 2;
            this.cboMeses.ValueMember = "idMeses";
            // 
            // nudAnio
            // 
            this.nudAnio.Location = new System.Drawing.Point(110, 15);
            this.nudAnio.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAnio.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAnio.Name = "nudAnio";
            this.nudAnio.Size = new System.Drawing.Size(51, 20);
            this.nudAnio.TabIndex = 1;
            this.nudAnio.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnProcesar1
            // 
            this.btnProcesar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar1.BackgroundImage")));
            this.btnProcesar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar1.Location = new System.Drawing.Point(698, 12);
            this.btnProcesar1.Name = "btnProcesar1";
            this.btnProcesar1.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar1.TabIndex = 14;
            this.btnProcesar1.Text = "&Procesar";
            this.btnProcesar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar1.UseVisualStyleBackColor = true;
            this.btnProcesar1.Click += new System.EventHandler(this.btnProcesar1_Click);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(189, 22);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(48, 13);
            this.lblBase3.TabIndex = 9;
            this.lblBase3.Text = "Desde:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(193, 68);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(44, 13);
            this.lblBase1.TabIndex = 9;
            this.lblBase1.Text = "Hasta:";
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(514, 486);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 30;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(712, 486);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 28;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Location = new System.Drawing.Point(580, 486);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 32;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(646, 486);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 33;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // conBusUbig1
            // 
            this.conBusUbig1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.conBusUbig1.Location = new System.Drawing.Point(449, 0);
            this.conBusUbig1.Name = "conBusUbig1";
            this.conBusUbig1.nIdNodo = 0;
            this.conBusUbig1.Size = new System.Drawing.Size(232, 134);
            this.conBusUbig1.TabIndex = 15;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(12, 52);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(82, 13);
            this.lblBase4.TabIndex = 35;
            this.lblBase4.Text = "Perfil cliente:";
            // 
            // cboPerfiles
            // 
            this.cboPerfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPerfiles.FormattingEnabled = true;
            this.cboPerfiles.Location = new System.Drawing.Point(12, 68);
            this.cboPerfiles.Name = "cboPerfiles";
            this.cboPerfiles.Size = new System.Drawing.Size(150, 21);
            this.cboPerfiles.TabIndex = 34;
            // 
            // frmOpeInusuales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.cboPerfiles);
            this.Controls.Add(this.btnProcesar1);
            this.Controls.Add(this.conBusUbig1);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.conFechaAñoMesHasta);
            this.Controls.Add(this.cboOperaciones);
            this.Controls.Add(this.conFechaAñoMesDesde);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.dtgLista);
            this.Name = "frmOpeInusuales";
            this.Text = "Reporte de operaciones por perfil de clientes";
            this.Load += new System.EventHandler(this.frmOpeInusuales_Load);
            this.Controls.SetChildIndex(this.dtgLista, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.conFechaAñoMesDesde, 0);
            this.Controls.SetChildIndex(this.cboOperaciones, 0);
            this.Controls.SetChildIndex(this.conFechaAñoMesHasta, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.conBusUbig1, 0);
            this.Controls.SetChildIndex(this.btnProcesar1, 0);
            this.Controls.SetChildIndex(this.cboPerfiles, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgLista)).EndInit();
            this.conFechaAñoMesDesde.ResumeLayout(false);
            this.conFechaAñoMesDesde.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboBase cboOperaciones;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.dtgBase dtgLista;
        private GEN.ControlesBase.ConFechaAñoMes conFechaAñoMesHasta;
        private GEN.ControlesBase.ConFechaAñoMes conFechaAñoMesDesde;
        private GEN.ControlesBase.cboMeses cboMeses;
        private GEN.ControlesBase.nudBase nudAnio;
        private GEN.BotonesBase.btnProcesar btnProcesar1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.ConBusUbig conBusUbig1;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.cboBase cboPerfiles;
    }
}