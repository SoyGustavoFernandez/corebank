namespace DEP.Presentacion
{
    partial class frmRptDepositoMasivo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptDepositoMasivo));
            this.conBusCli = new GEN.ControlesBase.ConBusCli();
            this.txtCodInst = new GEN.ControlesBase.txtBase(this.components);
            this.txtCodAge = new GEN.ControlesBase.txtBase(this.components);
            this.txtDireccion = new GEN.ControlesBase.txtBase(this.components);
            this.txtCodCli = new GEN.ControlesBase.txtBase(this.components);
            this.txtNombre = new GEN.ControlesBase.txtBase(this.components);
            this.txtNroDoc = new GEN.ControlesBase.txtBase(this.components);
            this.dtgListaDepositosMasivos = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtpFecFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFecIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.btnProcesar = new GEN.BotonesBase.btnProcesar();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.chcTodos = new GEN.ControlesBase.chcBase(this.components);
            this.conBusCli.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaDepositosMasivos)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // conBusCli
            // 
            this.conBusCli.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli.Controls.Add(this.txtCodInst);
            this.conBusCli.Controls.Add(this.txtCodAge);
            this.conBusCli.Controls.Add(this.txtDireccion);
            this.conBusCli.Controls.Add(this.txtCodCli);
            this.conBusCli.Controls.Add(this.txtNombre);
            this.conBusCli.Controls.Add(this.txtNroDoc);
            this.conBusCli.idCli = 0;
            this.conBusCli.Location = new System.Drawing.Point(13, 12);
            this.conBusCli.Name = "conBusCli";
            this.conBusCli.Size = new System.Drawing.Size(528, 82);
            this.conBusCli.TabIndex = 66;
            this.conBusCli.ClicBuscar += new System.EventHandler(this.conBusCli1_ClicBuscar);
            // 
            // txtCodInst
            // 
            this.txtCodInst.Enabled = false;
            this.txtCodInst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodInst.Location = new System.Drawing.Point(161, 8);
            this.txtCodInst.Name = "txtCodInst";
            this.txtCodInst.Size = new System.Drawing.Size(27, 20);
            this.txtCodInst.TabIndex = 13;
            // 
            // txtCodAge
            // 
            this.txtCodAge.Enabled = false;
            this.txtCodAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodAge.Location = new System.Drawing.Point(186, 8);
            this.txtCodAge.Name = "txtCodAge";
            this.txtCodAge.Size = new System.Drawing.Size(27, 20);
            this.txtCodAge.TabIndex = 12;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(161, 79);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(357, 20);
            this.txtDireccion.TabIndex = 11;
            // 
            // txtCodCli
            // 
            this.txtCodCli.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodCli.Location = new System.Drawing.Point(211, 8);
            this.txtCodCli.MaxLength = 7;
            this.txtCodCli.Name = "txtCodCli";
            this.txtCodCli.Size = new System.Drawing.Size(130, 20);
            this.txtCodCli.TabIndex = 1;
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(161, 55);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(357, 20);
            this.txtNombre.TabIndex = 6;
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Enabled = false;
            this.txtNroDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroDoc.Location = new System.Drawing.Point(161, 31);
            this.txtNroDoc.MaxLength = 15;
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(180, 20);
            this.txtNroDoc.TabIndex = 5;
            // 
            // dtgListaDepositosMasivos
            // 
            this.dtgListaDepositosMasivos.AllowUserToAddRows = false;
            this.dtgListaDepositosMasivos.AllowUserToDeleteRows = false;
            this.dtgListaDepositosMasivos.AllowUserToResizeColumns = false;
            this.dtgListaDepositosMasivos.AllowUserToResizeRows = false;
            this.dtgListaDepositosMasivos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgListaDepositosMasivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaDepositosMasivos.Location = new System.Drawing.Point(12, 100);
            this.dtgListaDepositosMasivos.MultiSelect = false;
            this.dtgListaDepositosMasivos.Name = "dtgListaDepositosMasivos";
            this.dtgListaDepositosMasivos.ReadOnly = true;
            this.dtgListaDepositosMasivos.RowHeadersVisible = false;
            this.dtgListaDepositosMasivos.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgListaDepositosMasivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaDepositosMasivos.Size = new System.Drawing.Size(813, 251);
            this.dtgListaDepositosMasivos.TabIndex = 68;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(765, 357);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 69;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(699, 357);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 70;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(13, 18);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(52, 13);
            this.lblBase1.TabIndex = 71;
            this.lblBase1.Text = "Desde :";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(14, 44);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(48, 13);
            this.lblBase2.TabIndex = 72;
            this.lblBase2.Text = "Hasta :";
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecFin.Location = new System.Drawing.Point(67, 41);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(104, 20);
            this.dtpFecFin.TabIndex = 73;
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecIni.Location = new System.Drawing.Point(67, 14);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(104, 20);
            this.dtpFecIni.TabIndex = 74;
            // 
            // btnProcesar
            // 
            this.btnProcesar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar.BackgroundImage")));
            this.btnProcesar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar.Location = new System.Drawing.Point(765, 39);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar.TabIndex = 75;
            this.btnProcesar.Text = "&Procesar";
            this.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.dtpFecIni);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.dtpFecFin);
            this.grbBase1.Location = new System.Drawing.Point(556, 24);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(180, 67);
            this.grbBase1.TabIndex = 76;
            this.grbBase1.TabStop = false;
            // 
            // chcTodos
            // 
            this.chcTodos.AutoSize = true;
            this.chcTodos.ForeColor = System.Drawing.Color.Navy;
            this.chcTodos.Location = new System.Drawing.Point(13, 2);
            this.chcTodos.Name = "chcTodos";
            this.chcTodos.Size = new System.Drawing.Size(56, 17);
            this.chcTodos.TabIndex = 78;
            this.chcTodos.Text = "Todos";
            this.chcTodos.UseVisualStyleBackColor = true;
            this.chcTodos.CheckedChanged += new System.EventHandler(this.chcTodos_CheckedChanged);
            // 
            // frmRptDepositoMasivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 434);
            this.Controls.Add(this.chcTodos);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.dtgListaDepositosMasivos);
            this.Controls.Add(this.conBusCli);
            this.Name = "frmRptDepositoMasivo";
            this.Text = "Reporte de depósitos masivos";
            this.Load += new System.EventHandler(this.frmRptDepositoMasivo_Load);
            this.Controls.SetChildIndex(this.conBusCli, 0);
            this.Controls.SetChildIndex(this.dtgListaDepositosMasivos, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnProcesar, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.chcTodos, 0);
            this.conBusCli.ResumeLayout(false);
            this.conBusCli.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaDepositosMasivos)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.ConBusCli conBusCli;
        private GEN.ControlesBase.txtBase txtCodInst;
        private GEN.ControlesBase.txtBase txtCodAge;
        private GEN.ControlesBase.txtBase txtDireccion;
        private GEN.ControlesBase.txtBase txtCodCli;
        private GEN.ControlesBase.txtBase txtNombre;
        private GEN.ControlesBase.txtBase txtNroDoc;
        private GEN.ControlesBase.dtgBase dtgListaDepositosMasivos;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.dtpCorto dtpFecFin;
        private GEN.ControlesBase.dtpCorto dtpFecIni;
        private GEN.BotonesBase.btnProcesar btnProcesar;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.chcBase chcTodos;
    }
}