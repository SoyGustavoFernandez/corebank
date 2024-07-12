namespace LOG.Presentacion
{
    partial class frmBuscaAlmacen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscaAlmacen));
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.cboAgenciaOri = new GEN.ControlesBase.cboAgencias(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboAlmacenesOri = new GEN.ControlesBase.cboAlmacenes(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.cboAgenciaDes = new GEN.ControlesBase.cboAgencias(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboAlmacenesDes = new GEN.ControlesBase.cboAlmacenes(this.components);
            this.grbBase2.SuspendLayout();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.cboAgenciaOri);
            this.grbBase2.Controls.Add(this.lblBase1);
            this.grbBase2.Controls.Add(this.cboAlmacenesOri);
            this.grbBase2.Controls.Add(this.lblBase7);
            this.grbBase2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBase2.Location = new System.Drawing.Point(12, 12);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(222, 122);
            this.grbBase2.TabIndex = 71;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Seleccione Almacen de Origen";
            // 
            // cboAgenciaOri
            // 
            this.cboAgenciaOri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgenciaOri.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAgenciaOri.FormattingEnabled = true;
            this.cboAgenciaOri.Location = new System.Drawing.Point(14, 41);
            this.cboAgenciaOri.Name = "cboAgenciaOri";
            this.cboAgenciaOri.Size = new System.Drawing.Size(186, 21);
            this.cboAgenciaOri.TabIndex = 86;
            this.cboAgenciaOri.SelectedIndexChanged += new System.EventHandler(this.cboAgenciaOri_SelectedIndexChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(11, 72);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(103, 13);
            this.lblBase1.TabIndex = 84;
            this.lblBase1.Text = "Almacen Origen:";
            // 
            // cboAlmacenesOri
            // 
            this.cboAlmacenesOri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlmacenesOri.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAlmacenesOri.FormattingEnabled = true;
            this.cboAlmacenesOri.Location = new System.Drawing.Point(14, 86);
            this.cboAlmacenesOri.Name = "cboAlmacenesOri";
            this.cboAlmacenesOri.Size = new System.Drawing.Size(186, 21);
            this.cboAlmacenesOri.TabIndex = 83;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(11, 27);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(99, 13);
            this.lblBase7.TabIndex = 50;
            this.lblBase7.Text = "Agencia Origen:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(345, 140);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 80;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(411, 140);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 56;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.cboAgenciaDes);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.cboAlmacenesDes);
            this.grbBase1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBase1.Location = new System.Drawing.Point(240, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(231, 122);
            this.grbBase1.TabIndex = 85;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Seleccione Almacen de Destino";
            // 
            // cboAgenciaDes
            // 
            this.cboAgenciaDes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgenciaDes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAgenciaDes.FormattingEnabled = true;
            this.cboAgenciaDes.Location = new System.Drawing.Point(16, 41);
            this.cboAgenciaDes.Name = "cboAgenciaDes";
            this.cboAgenciaDes.Size = new System.Drawing.Size(186, 21);
            this.cboAgenciaDes.TabIndex = 86;
            this.cboAgenciaDes.SelectedIndexChanged += new System.EventHandler(this.cboAgenciaDes_SelectedIndexChanged);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(13, 72);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(108, 13);
            this.lblBase3.TabIndex = 86;
            this.lblBase3.Text = "Almacen Destino:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(13, 27);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(104, 13);
            this.lblBase5.TabIndex = 85;
            this.lblBase5.Text = "Agencia Destino:";
            // 
            // cboAlmacenesDes
            // 
            this.cboAlmacenesDes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlmacenesDes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAlmacenesDes.FormattingEnabled = true;
            this.cboAlmacenesDes.Location = new System.Drawing.Point(16, 86);
            this.cboAlmacenesDes.Name = "cboAlmacenesDes";
            this.cboAlmacenesDes.Size = new System.Drawing.Size(186, 21);
            this.cboAlmacenesDes.TabIndex = 83;
            // 
            // frmBuscaAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 218);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.btnSalir);
            this.Name = "frmBuscaAlmacen";
            this.Text = "Busca Almacen";
            this.Load += new System.EventHandler(this.frmBuscaAlmacen_Load);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.cboAlmacenes cboAlmacenesOri;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboAlmacenes cboAlmacenesDes;
        private GEN.ControlesBase.cboAgencias cboAgenciaOri;
        private GEN.ControlesBase.cboAgencias cboAgenciaDes;
    }
}