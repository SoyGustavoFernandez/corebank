namespace LOG.Presentacion
{
    partial class frmSeleccionaGrupoProceso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSeleccionaGrupoProceso));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtgGruposProceso = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtProceso = new GEN.ControlesBase.txtBase(this.components);
            this.dtgDetalleGrupo = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGruposProceso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleGrupo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 33);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(182, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Selecciona Grupo del Proceso:";
            // 
            // dtgGruposProceso
            // 
            this.dtgGruposProceso.AllowUserToAddRows = false;
            this.dtgGruposProceso.AllowUserToDeleteRows = false;
            this.dtgGruposProceso.AllowUserToResizeColumns = false;
            this.dtgGruposProceso.AllowUserToResizeRows = false;
            this.dtgGruposProceso.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgGruposProceso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgGruposProceso.Location = new System.Drawing.Point(15, 50);
            this.dtgGruposProceso.MultiSelect = false;
            this.dtgGruposProceso.Name = "dtgGruposProceso";
            this.dtgGruposProceso.ReadOnly = true;
            this.dtgGruposProceso.RowHeadersVisible = false;
            this.dtgGruposProceso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgGruposProceso.Size = new System.Drawing.Size(347, 122);
            this.dtgGruposProceso.TabIndex = 3;
            this.dtgGruposProceso.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgGruposProceso_RowEnter);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(12, 9);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(94, 13);
            this.lblBase2.TabIndex = 4;
            this.lblBase2.Text = "Nro de Proceso";
            // 
            // txtProceso
            // 
            this.txtProceso.Location = new System.Drawing.Point(112, 6);
            this.txtProceso.Name = "txtProceso";
            this.txtProceso.Size = new System.Drawing.Size(91, 20);
            this.txtProceso.TabIndex = 5;
            this.txtProceso.Visible = false;
            // 
            // dtgDetalleGrupo
            // 
            this.dtgDetalleGrupo.AllowUserToAddRows = false;
            this.dtgDetalleGrupo.AllowUserToDeleteRows = false;
            this.dtgDetalleGrupo.AllowUserToResizeColumns = false;
            this.dtgDetalleGrupo.AllowUserToResizeRows = false;
            this.dtgDetalleGrupo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetalleGrupo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalleGrupo.Location = new System.Drawing.Point(15, 200);
            this.dtgDetalleGrupo.MultiSelect = false;
            this.dtgDetalleGrupo.Name = "dtgDetalleGrupo";
            this.dtgDetalleGrupo.ReadOnly = true;
            this.dtgDetalleGrupo.RowHeadersVisible = false;
            this.dtgDetalleGrupo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetalleGrupo.Size = new System.Drawing.Size(347, 122);
            this.dtgDetalleGrupo.TabIndex = 6;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(12, 184);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(105, 13);
            this.lblBase3.TabIndex = 7;
            this.lblBase3.Text = "Items del Grupo:";
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(306, 328);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 8;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(240, 328);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 9;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // frmSeleccionaGrupoProceso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 406);
            this.Controls.Add(this.btnAceptar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.dtgDetalleGrupo);
            this.Controls.Add(this.txtProceso);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.dtgGruposProceso);
            this.Controls.Add(this.lblBase1);
            this.Name = "frmSeleccionaGrupoProceso";
            this.Text = "Seleccionando  Grupo Proceso";
            this.Load += new System.EventHandler(this.frmSeleccionaGrupoProceso_Load);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.dtgGruposProceso, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.txtProceso, 0);
            this.Controls.SetChildIndex(this.dtgDetalleGrupo, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgGruposProceso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleGrupo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.dtgBase dtgGruposProceso;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtProceso;
        private GEN.ControlesBase.dtgBase dtgDetalleGrupo;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.BtnAceptar btnAceptar1;

    }
}