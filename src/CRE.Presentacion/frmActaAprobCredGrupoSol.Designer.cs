namespace CRE.Presentacion
{
    partial class frmActaAprobCredGrupoSol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmActaAprobCredGrupoSol));
            this.btnImpActaCredito = new GEN.BotonesBase.btnImprimir();
            this.txtIdGrupoSolidario = new GEN.ControlesBase.txtNumerico(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.dtpFechaIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.dtpFechaFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.btnMiniBusqueda1 = new GEN.BotonesBase.btnMiniBusqueda(this.components);
            this.dtgSolCredGrupAprob = new GEN.ControlesBase.dtgBase(this.components);
            this.chcGrupoSolidario = new GEN.ControlesBase.chcBase(this.components);
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolCredGrupAprob)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImpActaCredito
            // 
            this.btnImpActaCredito.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImpActaCredito.BackgroundImage")));
            this.btnImpActaCredito.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImpActaCredito.Location = new System.Drawing.Point(628, 251);
            this.btnImpActaCredito.Name = "btnImpActaCredito";
            this.btnImpActaCredito.Size = new System.Drawing.Size(60, 50);
            this.btnImpActaCredito.TabIndex = 8;
            this.btnImpActaCredito.Text = "&Imprimir";
            this.btnImpActaCredito.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImpActaCredito.UseVisualStyleBackColor = true;
            this.btnImpActaCredito.Click += new System.EventHandler(this.btnImpActaCredito_Click);
            // 
            // txtIdGrupoSolidario
            // 
            this.txtIdGrupoSolidario.Format = "n2";
            this.txtIdGrupoSolidario.Location = new System.Drawing.Point(567, 19);
            this.txtIdGrupoSolidario.Name = "txtIdGrupoSolidario";
            this.txtIdGrupoSolidario.Size = new System.Drawing.Size(78, 20);
            this.txtIdGrupoSolidario.TabIndex = 10;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.chcGrupoSolidario);
            this.grbBase1.Controls.Add(this.btnMiniBusqueda1);
            this.grbBase1.Controls.Add(this.txtIdGrupoSolidario);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.dtpFechaFin);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.dtpFechaIni);
            this.grbBase1.Location = new System.Drawing.Point(0, 0);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(688, 56);
            this.grbBase1.TabIndex = 11;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Filtros";
            // 
            // dtpFechaIni
            // 
            this.dtpFechaIni.Location = new System.Drawing.Point(89, 19);
            this.dtpFechaIni.Name = "dtpFechaIni";
            this.dtpFechaIni.Size = new System.Drawing.Size(133, 20);
            this.dtpFechaIni.TabIndex = 12;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(6, 22);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(83, 13);
            this.lblBase2.TabIndex = 12;
            this.lblBase2.Text = "Fecha Inicial:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(228, 22);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(75, 13);
            this.lblBase3.TabIndex = 13;
            this.lblBase3.Text = "Fecha Final:";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Location = new System.Drawing.Point(304, 19);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(133, 20);
            this.dtpFechaFin.TabIndex = 14;
            // 
            // btnMiniBusqueda1
            // 
            this.btnMiniBusqueda1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniBusqueda1.BackgroundImage")));
            this.btnMiniBusqueda1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMiniBusqueda1.Location = new System.Drawing.Point(651, 17);
            this.btnMiniBusqueda1.Name = "btnMiniBusqueda1";
            this.btnMiniBusqueda1.Size = new System.Drawing.Size(32, 25);
            this.btnMiniBusqueda1.TabIndex = 12;
            this.btnMiniBusqueda1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniBusqueda1.UseVisualStyleBackColor = true;
            this.btnMiniBusqueda1.Click += new System.EventHandler(this.btnMiniBusqueda1_Click);
            // 
            // dtgSolCredGrupAprob
            // 
            this.dtgSolCredGrupAprob.AllowUserToAddRows = false;
            this.dtgSolCredGrupAprob.AllowUserToDeleteRows = false;
            this.dtgSolCredGrupAprob.AllowUserToResizeColumns = false;
            this.dtgSolCredGrupAprob.AllowUserToResizeRows = false;
            this.dtgSolCredGrupAprob.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgSolCredGrupAprob.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSolCredGrupAprob.Location = new System.Drawing.Point(9, 62);
            this.dtgSolCredGrupAprob.MultiSelect = false;
            this.dtgSolCredGrupAprob.Name = "dtgSolCredGrupAprob";
            this.dtgSolCredGrupAprob.ReadOnly = true;
            this.dtgSolCredGrupAprob.RowHeadersVisible = false;
            this.dtgSolCredGrupAprob.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSolCredGrupAprob.Size = new System.Drawing.Size(679, 183);
            this.dtgSolCredGrupAprob.TabIndex = 12;
            // 
            // chcGrupoSolidario
            // 
            this.chcGrupoSolidario.AutoSize = true;
            this.chcGrupoSolidario.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chcGrupoSolidario.Location = new System.Drawing.Point(444, 21);
            this.chcGrupoSolidario.Name = "chcGrupoSolidario";
            this.chcGrupoSolidario.Size = new System.Drawing.Size(118, 17);
            this.chcGrupoSolidario.TabIndex = 13;
            this.chcGrupoSolidario.Text = "Nro Grupo Solidario";
            this.chcGrupoSolidario.UseVisualStyleBackColor = true;
            this.chcGrupoSolidario.CheckedChanged += new System.EventHandler(this.chcGrupoSolidario_CheckedChanged);
            // 
            // frmActaAprobCredGrupoSol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 326);
            this.Controls.Add(this.dtgSolCredGrupAprob);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnImpActaCredito);
            this.Name = "frmActaAprobCredGrupoSol";
            this.Text = "Impresión de Actas de Créditos";
            this.Controls.SetChildIndex(this.btnImpActaCredito, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.dtgSolCredGrupAprob, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolCredGrupAprob)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnImprimir btnImpActaCredito;
        private GEN.ControlesBase.txtNumerico txtIdGrupoSolidario;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.BotonesBase.btnMiniBusqueda btnMiniBusqueda1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.dtpCorto dtpFechaFin;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.dtpCorto dtpFechaIni;
        private GEN.ControlesBase.dtgBase dtgSolCredGrupAprob;
        private GEN.ControlesBase.chcBase chcGrupoSolidario;
    }
}