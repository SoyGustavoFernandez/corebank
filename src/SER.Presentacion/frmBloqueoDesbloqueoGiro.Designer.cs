namespace SER.Presentacion
{
    partial class frmBloqueoDesbloqueoGiro
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBloqueoDesbloqueoGiro));
            this.dtgGiros = new GEN.ControlesBase.dtgBase(this.components);
            this.btnLiberar = new GEN.BotonesBase.btnLiberar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtUsuarioBlo = new GEN.ControlesBase.txtBase(this.components);
            this.txtAgeBlo = new System.Windows.Forms.TextBox();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.chcDesbloqueados = new GEN.ControlesBase.chcBase(this.components);
            this.btnMiniBusq = new GEN.BotonesBase.btnMiniBusq(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtBuscarNroGiro = new GEN.ControlesBase.txtNumRea(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgGiros)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgGiros
            // 
            this.dtgGiros.AllowUserToAddRows = false;
            this.dtgGiros.AllowUserToDeleteRows = false;
            this.dtgGiros.AllowUserToResizeColumns = false;
            this.dtgGiros.AllowUserToResizeRows = false;
            this.dtgGiros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgGiros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgGiros.Location = new System.Drawing.Point(5, 34);
            this.dtgGiros.MultiSelect = false;
            this.dtgGiros.Name = "dtgGiros";
            this.dtgGiros.ReadOnly = true;
            this.dtgGiros.RowHeadersVisible = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgGiros.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgGiros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgGiros.Size = new System.Drawing.Size(775, 203);
            this.dtgGiros.TabIndex = 2;
            this.dtgGiros.SelectionChanged += new System.EventHandler(this.dtgGiros_SelectionChanged);
            // 
            // btnLiberar
            // 
            this.btnLiberar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLiberar.BackgroundImage")));
            this.btnLiberar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLiberar.Location = new System.Drawing.Point(646, 263);
            this.btnLiberar.Name = "btnLiberar";
            this.btnLiberar.Size = new System.Drawing.Size(60, 50);
            this.btnLiberar.TabIndex = 3;
            this.btnLiberar.Text = "&Liberar";
            this.btnLiberar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLiberar.UseVisualStyleBackColor = true;
            this.btnLiberar.Click += new System.EventHandler(this.btnLiberar_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(712, 263);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 4;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.txtUsuarioBlo);
            this.grbBase1.Controls.Add(this.txtAgeBlo);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Location = new System.Drawing.Point(12, 241);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(370, 75);
            this.grbBase1.TabIndex = 7;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos de Bloqueo";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(4, 50);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(57, 13);
            this.lblBase2.TabIndex = 19;
            this.lblBase2.Text = "Agencia:";
            // 
            // txtUsuarioBlo
            // 
            this.txtUsuarioBlo.BackColor = System.Drawing.SystemColors.Control;
            this.txtUsuarioBlo.Enabled = false;
            this.txtUsuarioBlo.Location = new System.Drawing.Point(63, 22);
            this.txtUsuarioBlo.Name = "txtUsuarioBlo";
            this.txtUsuarioBlo.ReadOnly = true;
            this.txtUsuarioBlo.Size = new System.Drawing.Size(299, 20);
            this.txtUsuarioBlo.TabIndex = 2;
            // 
            // txtAgeBlo
            // 
            this.txtAgeBlo.BackColor = System.Drawing.SystemColors.Control;
            this.txtAgeBlo.Enabled = false;
            this.txtAgeBlo.Location = new System.Drawing.Point(63, 46);
            this.txtAgeBlo.Name = "txtAgeBlo";
            this.txtAgeBlo.ReadOnly = true;
            this.txtAgeBlo.Size = new System.Drawing.Size(177, 20);
            this.txtAgeBlo.TabIndex = 18;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 26);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(55, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Usuario:";
            // 
            // chcDesbloqueados
            // 
            this.chcDesbloqueados.AutoSize = true;
            this.chcDesbloqueados.Location = new System.Drawing.Point(648, 13);
            this.chcDesbloqueados.Name = "chcDesbloqueados";
            this.chcDesbloqueados.Size = new System.Drawing.Size(129, 17);
            this.chcDesbloqueados.TabIndex = 8;
            this.chcDesbloqueados.Text = "Ver todos bloqueados";
            this.chcDesbloqueados.UseVisualStyleBackColor = true;
            this.chcDesbloqueados.CheckedChanged += new System.EventHandler(this.chcDesbloqueados_CheckedChanged);
            // 
            // btnMiniBusq
            // 
            this.btnMiniBusq.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniBusq.BackgroundImage")));
            this.btnMiniBusq.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniBusq.Location = new System.Drawing.Point(164, 3);
            this.btnMiniBusq.Name = "btnMiniBusq";
            this.btnMiniBusq.Size = new System.Drawing.Size(36, 28);
            this.btnMiniBusq.TabIndex = 9;
            this.btnMiniBusq.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniBusq.UseVisualStyleBackColor = true;
            this.btnMiniBusq.Click += new System.EventHandler(this.btnMiniBusq_Click);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(8, 14);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(54, 13);
            this.lblBase3.TabIndex = 20;
            this.lblBase3.Text = "Nº Giro:";
            // 
            // txtBuscarNroGiro
            // 
            this.txtBuscarNroGiro.FormatoDecimal = false;
            this.txtBuscarNroGiro.Location = new System.Drawing.Point(63, 10);
            this.txtBuscarNroGiro.Name = "txtBuscarNroGiro";
            this.txtBuscarNroGiro.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtBuscarNroGiro.nNumDecimales = 4;
            this.txtBuscarNroGiro.nvalor = 0D;
            this.txtBuscarNroGiro.Size = new System.Drawing.Size(100, 20);
            this.txtBuscarNroGiro.TabIndex = 21;
            this.txtBuscarNroGiro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarNroGiro_KeyPress);
            // 
            // frmBloqueoDesbloqueoGiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 341);
            this.Controls.Add(this.txtBuscarNroGiro);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.btnMiniBusq);
            this.Controls.Add(this.chcDesbloqueados);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnLiberar);
            this.Controls.Add(this.dtgGiros);
            this.Name = "frmBloqueoDesbloqueoGiro";
            this.Text = "Desbloqueo lógico de Giro";
            this.Load += new System.EventHandler(this.frmBloqueoDesbloqueoGiro_Load);
            this.Controls.SetChildIndex(this.dtgGiros, 0);
            this.Controls.SetChildIndex(this.btnLiberar, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.chcDesbloqueados, 0);
            this.Controls.SetChildIndex(this.btnMiniBusq, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.txtBuscarNroGiro, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgGiros)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgGiros;
        private GEN.BotonesBase.btnLiberar btnLiberar;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtUsuarioBlo;
        private System.Windows.Forms.TextBox txtAgeBlo;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.chcBase chcDesbloqueados;
        private GEN.BotonesBase.btnMiniBusq btnMiniBusq;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtNumRea txtBuscarNroGiro;
    }
}