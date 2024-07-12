namespace GEN.ControlesBase
{
    partial class frmBusCtaAhoVinculacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBusCtaAhoVinculacion));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.dtgCtasAho = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.btnMiniNuevo = new GEN.BotonesBase.btnMiniNuevo(this.components);
            this.lblCuentaVinculada = new GEN.ControlesBase.lblBase();
            this.lblNroCuentaVinculada = new GEN.ControlesBase.lblBase();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCtasAho)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(782, 165);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 51;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(719, 165);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 50;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // dtgCtasAho
            // 
            this.dtgCtasAho.AllowUserToAddRows = false;
            this.dtgCtasAho.AllowUserToDeleteRows = false;
            this.dtgCtasAho.AllowUserToResizeColumns = false;
            this.dtgCtasAho.AllowUserToResizeRows = false;
            this.dtgCtasAho.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgCtasAho.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgCtasAho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgCtasAho.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgCtasAho.Location = new System.Drawing.Point(2, 48);
            this.dtgCtasAho.MultiSelect = false;
            this.dtgCtasAho.Name = "dtgCtasAho";
            this.dtgCtasAho.ReadOnly = true;
            this.dtgCtasAho.RowHeadersVisible = false;
            this.dtgCtasAho.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCtasAho.Size = new System.Drawing.Size(852, 111);
            this.dtgCtasAho.TabIndex = 49;
            this.dtgCtasAho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgCtasAho_KeyDown);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(0, 29);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(123, 13);
            this.lblBase1.TabIndex = 52;
            this.lblBase1.Text = "Cuentas Permitidas:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(648, 14);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(158, 13);
            this.lblBase2.TabIndex = 54;
            this.lblBase2.Text = "Crear Cuenta Automatica:";
            // 
            // btnMiniNuevo
            // 
            this.btnMiniNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniNuevo.BackgroundImage")));
            this.btnMiniNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniNuevo.Location = new System.Drawing.Point(806, 6);
            this.btnMiniNuevo.Name = "btnMiniNuevo";
            this.btnMiniNuevo.Size = new System.Drawing.Size(36, 28);
            this.btnMiniNuevo.TabIndex = 55;
            this.btnMiniNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniNuevo.UseVisualStyleBackColor = true;
            this.btnMiniNuevo.Click += new System.EventHandler(this.btnMiniNuevo_Click);
            // 
            // lblCuentaVinculada
            // 
            this.lblCuentaVinculada.AutoSize = true;
            this.lblCuentaVinculada.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblCuentaVinculada.ForeColor = System.Drawing.Color.Navy;
            this.lblCuentaVinculada.Location = new System.Drawing.Point(0, 14);
            this.lblCuentaVinculada.Name = "lblCuentaVinculada";
            this.lblCuentaVinculada.Size = new System.Drawing.Size(112, 13);
            this.lblCuentaVinculada.TabIndex = 56;
            this.lblCuentaVinculada.Text = "Cuenta Vinculada:";
            // 
            // lblNroCuentaVinculada
            // 
            this.lblNroCuentaVinculada.AutoSize = true;
            this.lblNroCuentaVinculada.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblNroCuentaVinculada.ForeColor = System.Drawing.Color.Navy;
            this.lblNroCuentaVinculada.Location = new System.Drawing.Point(112, 14);
            this.lblNroCuentaVinculada.Name = "lblNroCuentaVinculada";
            this.lblNroCuentaVinculada.Size = new System.Drawing.Size(12, 13);
            this.lblNroCuentaVinculada.TabIndex = 57;
            this.lblNroCuentaVinculada.Text = "-";
            // 
            // frmBusCtaAhoVinculacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 244);
            this.Controls.Add(this.lblNroCuentaVinculada);
            this.Controls.Add(this.lblCuentaVinculada);
            this.Controls.Add(this.btnMiniNuevo);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dtgCtasAho);
            this.Name = "frmBusCtaAhoVinculacion";
            this.Text = "Cuentas de Ahorro del Cliente";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBusCtaAhoVinculacion_FormClosing);
            this.Load += new System.EventHandler(this.frmBusCtaAhoVinculacion_Load);
            this.Controls.SetChildIndex(this.dtgCtasAho, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.btnMiniNuevo, 0);
            this.Controls.SetChildIndex(this.lblCuentaVinculada, 0);
            this.Controls.SetChildIndex(this.lblNroCuentaVinculada, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCtasAho)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BotonesBase.btnSalir btnSalir;
        private BotonesBase.BtnAceptar btnAceptar;
        private dtgBase dtgCtasAho;
        private lblBase lblBase1;
        private lblBase lblBase2;
        private BotonesBase.btnMiniNuevo btnMiniNuevo;
        private lblBase lblCuentaVinculada;
        private lblBase lblNroCuentaVinculada;
    }
}