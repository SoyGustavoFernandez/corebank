namespace CRE.Presentacion
{
    partial class frmImpresionLomosExpediente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImpresionLomosExpediente));
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.conBusCli1 = new GEN.ControlesBase.ConBusCli();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgClientesParaImpresion = new GEN.ControlesBase.dtgBase(this.components);
            this.btnBusCliente1 = new GEN.BotonesBase.btnBusCliente();
            this.chcBase1 = new GEN.ControlesBase.chcBase(this.components);
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgClientesParaImpresion)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(351, 388);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 7;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(481, 388);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 2;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // conBusCli1
            // 
            this.conBusCli1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli1.idCli = 0;
            this.conBusCli1.Location = new System.Drawing.Point(6, 5);
            this.conBusCli1.Name = "conBusCli1";
            this.conBusCli1.Size = new System.Drawing.Size(532, 105);
            this.conBusCli1.TabIndex = 8;
            this.conBusCli1.ClicBuscar += new System.EventHandler(this.conBusCli1_ClicBuscar);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.dtgClientesParaImpresion);
            this.grbBase1.Location = new System.Drawing.Point(6, 116);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(532, 266);
            this.grbBase1.TabIndex = 9;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Lista de Clientes ";
            // 
            // dtgClientesParaImpresion
            // 
            this.dtgClientesParaImpresion.AllowUserToAddRows = false;
            this.dtgClientesParaImpresion.AllowUserToDeleteRows = false;
            this.dtgClientesParaImpresion.AllowUserToResizeColumns = false;
            this.dtgClientesParaImpresion.AllowUserToResizeRows = false;
            this.dtgClientesParaImpresion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgClientesParaImpresion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgClientesParaImpresion.Location = new System.Drawing.Point(6, 19);
            this.dtgClientesParaImpresion.MultiSelect = false;
            this.dtgClientesParaImpresion.Name = "dtgClientesParaImpresion";
            this.dtgClientesParaImpresion.ReadOnly = true;
            this.dtgClientesParaImpresion.RowHeadersVisible = false;
            this.dtgClientesParaImpresion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgClientesParaImpresion.Size = new System.Drawing.Size(520, 241);
            this.dtgClientesParaImpresion.TabIndex = 0;
            this.dtgClientesParaImpresion.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgClientesParaImpresion_CellContentClick);
            // 
            // btnBusCliente1
            // 
            this.btnBusCliente1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusCliente1.BackgroundImage")));
            this.btnBusCliente1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusCliente1.Location = new System.Drawing.Point(417, 388);
            this.btnBusCliente1.Name = "btnBusCliente1";
            this.btnBusCliente1.Size = new System.Drawing.Size(60, 50);
            this.btnBusCliente1.TabIndex = 11;
            this.btnBusCliente1.Text = "Cliente";
            this.btnBusCliente1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusCliente1.UseVisualStyleBackColor = true;
            this.btnBusCliente1.Click += new System.EventHandler(this.btnBusCliente1_Click);
            // 
            // chcBase1
            // 
            this.chcBase1.AutoSize = true;
            this.chcBase1.Location = new System.Drawing.Point(12, 384);
            this.chcBase1.Name = "chcBase1";
            this.chcBase1.Size = new System.Drawing.Size(56, 17);
            this.chcBase1.TabIndex = 1;
            this.chcBase1.Text = "Todos";
            this.chcBase1.UseVisualStyleBackColor = true;
            this.chcBase1.CheckedChanged += new System.EventHandler(this.chcBase1_CheckedChanged);
            // 
            // frmImpresionLomosExpediente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 463);
            this.Controls.Add(this.chcBase1);
            this.Controls.Add(this.btnBusCliente1);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.conBusCli1);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmImpresionLomosExpediente";
            this.Text = "Impresión de Lomos para Expedientes";
            this.Load += new System.EventHandler(this.frmBase_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.conBusCli1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnBusCliente1, 0);
            this.Controls.SetChildIndex(this.chcBase1, 0);
            this.grbBase1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgClientesParaImpresion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.ControlesBase.ConBusCli conBusCli1;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.dtgBase dtgClientesParaImpresion;
        private GEN.BotonesBase.btnBusCliente btnBusCliente1;
        private GEN.ControlesBase.chcBase chcBase1;
    }
}

