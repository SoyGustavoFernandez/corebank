namespace CRE.Presentacion
{
    partial class frmAsigProcJud
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAsigProcJud));
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.dtgProcJudAbogOrig = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblAbogOrig = new GEN.ControlesBase.lblBase();
            this.cboAbogOrig = new GEN.ControlesBase.cboAbogado(this.components);
            this.btnProcesar = new GEN.BotonesBase.btnProcesar();
            this.cboAbogDest = new GEN.ControlesBase.cboAbogado(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.dtgProcJudAbogDest = new GEN.ControlesBase.dtgBase(this.components);
            this.chcProcNoVinc = new GEN.ControlesBase.chcBase(this.components);
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProcJudAbogOrig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProcJudAbogDest)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(739, 273);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // dtgProcJudAbogOrig
            // 
            this.dtgProcJudAbogOrig.AllowUserToAddRows = false;
            this.dtgProcJudAbogOrig.AllowUserToDeleteRows = false;
            this.dtgProcJudAbogOrig.AllowUserToResizeColumns = false;
            this.dtgProcJudAbogOrig.AllowUserToResizeRows = false;
            this.dtgProcJudAbogOrig.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgProcJudAbogOrig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgProcJudAbogOrig.Location = new System.Drawing.Point(20, 85);
            this.dtgProcJudAbogOrig.MultiSelect = false;
            this.dtgProcJudAbogOrig.Name = "dtgProcJudAbogOrig";
            this.dtgProcJudAbogOrig.ReadOnly = true;
            this.dtgProcJudAbogOrig.RowHeadersVisible = false;
            this.dtgProcJudAbogOrig.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgProcJudAbogOrig.Size = new System.Drawing.Size(374, 182);
            this.dtgProcJudAbogOrig.TabIndex = 6;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(20, 60);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(121, 13);
            this.lblBase1.TabIndex = 7;
            this.lblBase1.Text = "Procesos Judiciales:";
            // 
            // lblAbogOrig
            // 
            this.lblAbogOrig.AutoSize = true;
            this.lblAbogOrig.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblAbogOrig.ForeColor = System.Drawing.Color.Navy;
            this.lblAbogOrig.Location = new System.Drawing.Point(20, 23);
            this.lblAbogOrig.Name = "lblAbogOrig";
            this.lblAbogOrig.Size = new System.Drawing.Size(104, 13);
            this.lblAbogOrig.TabIndex = 8;
            this.lblAbogOrig.Text = "Abogado Origen:";
            // 
            // cboAbogOrig
            // 
            this.cboAbogOrig.FormattingEnabled = true;
            this.cboAbogOrig.Location = new System.Drawing.Point(127, 19);
            this.cboAbogOrig.Name = "cboAbogOrig";
            this.cboAbogOrig.Size = new System.Drawing.Size(267, 21);
            this.cboAbogOrig.TabIndex = 9;
            this.cboAbogOrig.SelectedIndexChanged += new System.EventHandler(this.cboAbogOrig_SelectedIndexChanged);
            // 
            // btnProcesar
            // 
            this.btnProcesar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar.BackgroundImage")));
            this.btnProcesar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar.Location = new System.Drawing.Point(679, 273);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar.TabIndex = 10;
            this.btnProcesar.Text = "&Procesar";
            this.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // cboAbogDest
            // 
            this.cboAbogDest.FormattingEnabled = true;
            this.cboAbogDest.Location = new System.Drawing.Point(532, 19);
            this.cboAbogDest.Name = "cboAbogDest";
            this.cboAbogDest.Size = new System.Drawing.Size(267, 21);
            this.cboAbogDest.TabIndex = 14;
            this.cboAbogDest.SelectedIndexChanged += new System.EventHandler(this.cboAbogDest_SelectedIndexChanged);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(425, 23);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(109, 13);
            this.lblBase3.TabIndex = 13;
            this.lblBase3.Text = "Abogado Destino:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(425, 60);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(121, 13);
            this.lblBase4.TabIndex = 12;
            this.lblBase4.Text = "Procesos Judiciales:";
            // 
            // dtgProcJudAbogDest
            // 
            this.dtgProcJudAbogDest.AllowUserToAddRows = false;
            this.dtgProcJudAbogDest.AllowUserToDeleteRows = false;
            this.dtgProcJudAbogDest.AllowUserToResizeColumns = false;
            this.dtgProcJudAbogDest.AllowUserToResizeRows = false;
            this.dtgProcJudAbogDest.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgProcJudAbogDest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgProcJudAbogDest.Location = new System.Drawing.Point(425, 85);
            this.dtgProcJudAbogDest.MultiSelect = false;
            this.dtgProcJudAbogDest.Name = "dtgProcJudAbogDest";
            this.dtgProcJudAbogDest.ReadOnly = true;
            this.dtgProcJudAbogDest.RowHeadersVisible = false;
            this.dtgProcJudAbogDest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgProcJudAbogDest.Size = new System.Drawing.Size(374, 182);
            this.dtgProcJudAbogDest.TabIndex = 11;
            // 
            // chcProcNoVinc
            // 
            this.chcProcNoVinc.AutoSize = true;
            this.chcProcNoVinc.Location = new System.Drawing.Point(20, 273);
            this.chcProcNoVinc.Name = "chcProcNoVinc";
            this.chcProcNoVinc.Size = new System.Drawing.Size(180, 17);
            this.chcProcNoVinc.TabIndex = 15;
            this.chcProcNoVinc.Text = "Mostrar Procesos No Vinculados";
            this.chcProcNoVinc.UseVisualStyleBackColor = true;
            this.chcProcNoVinc.CheckedChanged += new System.EventHandler(this.chcProcNoVinc_CheckedChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(619, 273);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmAsigProcJud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 353);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.chcProcNoVinc);
            this.Controls.Add(this.cboAbogDest);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.dtgProcJudAbogDest);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.cboAbogOrig);
            this.Controls.Add(this.lblAbogOrig);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.dtgProcJudAbogOrig);
            this.Controls.Add(this.btnSalir);
            this.Name = "frmAsigProcJud";
            this.Text = "Reasignación de Procesos Judiciales";
            this.Load += new System.EventHandler(this.frmAsigProcJud_Load);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.dtgProcJudAbogOrig, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblAbogOrig, 0);
            this.Controls.SetChildIndex(this.cboAbogOrig, 0);
            this.Controls.SetChildIndex(this.btnProcesar, 0);
            this.Controls.SetChildIndex(this.dtgProcJudAbogDest, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.cboAbogDest, 0);
            this.Controls.SetChildIndex(this.chcProcNoVinc, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgProcJudAbogOrig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProcJudAbogDest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.dtgBase dtgProcJudAbogOrig;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblAbogOrig;
        private GEN.ControlesBase.cboAbogado cboAbogOrig;
        private GEN.BotonesBase.btnProcesar btnProcesar;
        private GEN.ControlesBase.cboAbogado cboAbogDest;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.dtgBase dtgProcJudAbogDest;
        private GEN.ControlesBase.chcBase chcProcNoVinc;
        private GEN.BotonesBase.btnCancelar btnCancelar;
    }
}