namespace CRE.Presentacion
{
    partial class frmBuscarEstadoPagoGrupal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarEstadoPagoGrupal));
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnGrupo1 = new GEN.BotonesBase.btnGrupo();
            this.conBusGrupoSol1 = new GEN.ControlesBase.ConBusGrupoSol();
            this.dtgBase1 = new GEN.ControlesBase.dtgBase(this.components);
            this.txtBase1 = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtBase2 = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBase1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(441, 275);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 2;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(574, 275);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 3;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(508, 275);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 4;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnGrupo1
            // 
            this.btnGrupo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrupo1.BackgroundImage")));
            this.btnGrupo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrupo1.Location = new System.Drawing.Point(346, 275);
            this.btnGrupo1.Name = "btnGrupo1";
            this.btnGrupo1.Size = new System.Drawing.Size(89, 40);
            this.btnGrupo1.TabIndex = 5;
            this.btnGrupo1.Text = "Historial de Credito";
            this.btnGrupo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrupo1.UseVisualStyleBackColor = true;
            this.btnGrupo1.Click += new System.EventHandler(this.btnGrupo1_Click);
            // 
            // conBusGrupoSol1
            // 
            this.conBusGrupoSol1.Location = new System.Drawing.Point(21, 12);
            this.conBusGrupoSol1.Name = "conBusGrupoSol1";
            this.conBusGrupoSol1.Size = new System.Drawing.Size(613, 73);
            this.conBusGrupoSol1.TabIndex = 6;
            this.conBusGrupoSol1.ClicBuscar += new System.EventHandler(this.conBusGrupoSol1_ClicBuscar);
            // 
            // dtgBase1
            // 
            this.dtgBase1.AllowUserToAddRows = false;
            this.dtgBase1.AllowUserToDeleteRows = false;
            this.dtgBase1.AllowUserToResizeColumns = false;
            this.dtgBase1.AllowUserToResizeRows = false;
            this.dtgBase1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgBase1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBase1.Location = new System.Drawing.Point(30, 110);
            this.dtgBase1.MultiSelect = false;
            this.dtgBase1.Name = "dtgBase1";
            this.dtgBase1.ReadOnly = true;
            this.dtgBase1.RowHeadersVisible = false;
            this.dtgBase1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgBase1.Size = new System.Drawing.Size(604, 145);
            this.dtgBase1.TabIndex = 53;
            // 
            // txtBase1
            // 
            this.txtBase1.Location = new System.Drawing.Point(84, 275);
            this.txtBase1.Name = "txtBase1";
            this.txtBase1.ReadOnly = true;
            this.txtBase1.Size = new System.Drawing.Size(256, 20);
            this.txtBase1.TabIndex = 54;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(27, 275);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(51, 13);
            this.lblBase1.TabIndex = 55;
            this.lblBase1.Text = "Asesor:";
            // 
            // txtBase2
            // 
            this.txtBase2.Location = new System.Drawing.Point(524, 61);
            this.txtBase2.Name = "txtBase2";
            this.txtBase2.ReadOnly = true;
            this.txtBase2.Size = new System.Drawing.Size(44, 20);
            this.txtBase2.TabIndex = 56;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(435, 65);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(88, 13);
            this.lblBase2.TabIndex = 57;
            this.lblBase2.Text = "Nro de Integ.:";
            // 
            // frmBuscarEstadoPagoGrupal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 361);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.txtBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.txtBase1);
            this.Controls.Add(this.dtgBase1);
            this.Controls.Add(this.conBusGrupoSol1);
            this.Controls.Add(this.btnGrupo1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnImprimir1);
            this.Name = "frmBuscarEstadoPagoGrupal";
            this.Text = "Historial de Crédito Grupal";
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnGrupo1, 0);
            this.Controls.SetChildIndex(this.conBusGrupoSol1, 0);
            this.Controls.SetChildIndex(this.dtgBase1, 0);
            this.Controls.SetChildIndex(this.txtBase1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.txtBase2, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgBase1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnGrupo btnGrupo1;
        private GEN.ControlesBase.ConBusGrupoSol conBusGrupoSol1;
        private GEN.ControlesBase.dtgBase dtgBase1;
        private GEN.ControlesBase.txtBase txtBase1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtBase2;
        private GEN.ControlesBase.lblBase lblBase2;
    }
}