namespace GEN.ControlesBase
{
    partial class ConFlujoCajaRural
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConFlujoCajaRural));
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtConAlertas = new GEN.ControlesBase.txtNumerico(this.components);
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.lblAlertas = new GEN.ControlesBase.lblBase();
            this.btnValidar = new GEN.BotonesBase.btnValidar();
            this.dtgDisenioCrediticio = new GEN.ControlesBase.dtgBase(this.components);
            this.nudCuotas = new GEN.ControlesBase.nudBase(this.components);
            this.lblBaseCustom42 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBaseCustom41 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.txtMonto = new GEN.ControlesBase.txtNumRea(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgFlujoPrincipal = new GEN.ControlesBase.dtgBase(this.components);
            this.txtEgresos = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtNecesidadCredito = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtIngresos = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblEgresos = new GEN.ControlesBase.lblBase();
            this.lblIngresos = new GEN.ControlesBase.lblBase();
            this.txtSaldoAcumulado = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblSaldoAcumulado = new GEN.ControlesBase.lblBase();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.grbBase3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDisenioCrediticio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCuotas)).BeginInit();
            this.grbBase2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFlujoPrincipal)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // txtConAlertas
            // 
            this.txtConAlertas.Format = "n2";
            this.errorProvider.SetIconPadding(this.txtConAlertas, -5);
            this.txtConAlertas.Location = new System.Drawing.Point(340, 49);
            this.txtConAlertas.Name = "txtConAlertas";
            this.txtConAlertas.ReadOnly = true;
            this.txtConAlertas.Size = new System.Drawing.Size(42, 20);
            this.txtConAlertas.TabIndex = 144;
            this.txtConAlertas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.txtConAlertas);
            this.grbBase3.Controls.Add(this.lblAlertas);
            this.grbBase3.Controls.Add(this.btnValidar);
            this.grbBase3.Controls.Add(this.dtgDisenioCrediticio);
            this.grbBase3.Controls.Add(this.nudCuotas);
            this.grbBase3.Controls.Add(this.lblBaseCustom42);
            this.grbBase3.Controls.Add(this.cboMoneda);
            this.grbBase3.Controls.Add(this.lblBaseCustom41);
            this.grbBase3.Controls.Add(this.txtMonto);
            this.grbBase3.Location = new System.Drawing.Point(739, 19);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(487, 582);
            this.grbBase3.TabIndex = 144;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Diseño Crediticio";
            // 
            // lblAlertas
            // 
            this.lblAlertas.AutoSize = true;
            this.lblAlertas.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblAlertas.ForeColor = System.Drawing.Color.Navy;
            this.lblAlertas.Location = new System.Drawing.Point(337, 28);
            this.lblAlertas.Name = "lblAlertas";
            this.lblAlertas.Size = new System.Drawing.Size(56, 13);
            this.lblAlertas.TabIndex = 143;
            this.lblAlertas.Text = "Alertas: ";
            // 
            // btnValidar
            // 
            this.btnValidar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnValidar.BackgroundImage")));
            this.btnValidar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnValidar.Location = new System.Drawing.Point(399, 24);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(60, 50);
            this.btnValidar.TabIndex = 142;
            this.btnValidar.Text = "&Validar";
            this.btnValidar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnValidar.UseVisualStyleBackColor = true;
            this.btnValidar.Click += new System.EventHandler(this.btnValidar_click);
            // 
            // dtgDisenioCrediticio
            // 
            this.dtgDisenioCrediticio.AllowUserToAddRows = false;
            this.dtgDisenioCrediticio.AllowUserToDeleteRows = false;
            this.dtgDisenioCrediticio.AllowUserToResizeColumns = false;
            this.dtgDisenioCrediticio.AllowUserToResizeRows = false;
            this.dtgDisenioCrediticio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDisenioCrediticio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDisenioCrediticio.Location = new System.Drawing.Point(6, 100);
            this.dtgDisenioCrediticio.MultiSelect = false;
            this.dtgDisenioCrediticio.Name = "dtgDisenioCrediticio";
            this.dtgDisenioCrediticio.ReadOnly = true;
            this.dtgDisenioCrediticio.RowHeadersVisible = false;
            this.dtgDisenioCrediticio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDisenioCrediticio.Size = new System.Drawing.Size(473, 476);
            this.dtgDisenioCrediticio.TabIndex = 0;
            // 
            // nudCuotas
            // 
            this.nudCuotas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudCuotas.Location = new System.Drawing.Point(114, 60);
            this.nudCuotas.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudCuotas.Name = "nudCuotas";
            this.nudCuotas.ReadOnly = true;
            this.nudCuotas.Size = new System.Drawing.Size(52, 20);
            this.nudCuotas.TabIndex = 137;
            this.nudCuotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudCuotas.ValueChanged += new System.EventHandler(this.nudCuotas_ValueChange);
            // 
            // lblBaseCustom42
            // 
            this.lblBaseCustom42.AutoSize = true;
            this.lblBaseCustom42.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBaseCustom42.ForeColor = System.Drawing.Color.Navy;
            this.lblBaseCustom42.Location = new System.Drawing.Point(7, 64);
            this.lblBaseCustom42.Name = "lblBaseCustom42";
            this.lblBaseCustom42.Size = new System.Drawing.Size(101, 13);
            this.lblBaseCustom42.TabIndex = 138;
            this.lblBaseCustom42.Text = "Plazo de Credito";
            // 
            // cboMoneda
            // 
            this.cboMoneda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(93, 31);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(93, 21);
            this.cboMoneda.TabIndex = 139;
            // 
            // lblBaseCustom41
            // 
            this.lblBaseCustom41.AutoSize = true;
            this.lblBaseCustom41.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBaseCustom41.ForeColor = System.Drawing.Color.Navy;
            this.lblBaseCustom41.Location = new System.Drawing.Point(7, 35);
            this.lblBaseCustom41.Name = "lblBaseCustom41";
            this.lblBaseCustom41.Size = new System.Drawing.Size(75, 13);
            this.lblBaseCustom41.TabIndex = 141;
            this.lblBaseCustom41.Text = "Monto Prop.";
            // 
            // txtMonto
            // 
            this.txtMonto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonto.FormatoDecimal = false;
            this.txtMonto.Location = new System.Drawing.Point(192, 31);
            this.txtMonto.MaxLength = 9;
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMonto.nNumDecimales = 2;
            this.txtMonto.nvalor = 0D;
            this.txtMonto.Size = new System.Drawing.Size(91, 20);
            this.txtMonto.TabIndex = 140;
            this.txtMonto.Text = "0";
            this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMonto.TextChanged += new System.EventHandler(this.txtMonto_TextChanged);
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.dtgFlujoPrincipal);
            this.grbBase2.Controls.Add(this.txtEgresos);
            this.grbBase2.Controls.Add(this.txtNecesidadCredito);
            this.grbBase2.Controls.Add(this.lblBase1);
            this.grbBase2.Controls.Add(this.txtIngresos);
            this.grbBase2.Controls.Add(this.lblEgresos);
            this.grbBase2.Controls.Add(this.lblIngresos);
            this.grbBase2.Controls.Add(this.txtSaldoAcumulado);
            this.grbBase2.Controls.Add(this.lblSaldoAcumulado);
            this.grbBase2.Location = new System.Drawing.Point(17, 19);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(716, 582);
            this.grbBase2.TabIndex = 143;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Flujo de Caja";
            // 
            // dtgFlujoPrincipal
            // 
            this.dtgFlujoPrincipal.AllowUserToAddRows = false;
            this.dtgFlujoPrincipal.AllowUserToDeleteRows = false;
            this.dtgFlujoPrincipal.AllowUserToResizeColumns = false;
            this.dtgFlujoPrincipal.AllowUserToResizeRows = false;
            this.dtgFlujoPrincipal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgFlujoPrincipal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgFlujoPrincipal.Location = new System.Drawing.Point(6, 100);
            this.dtgFlujoPrincipal.MultiSelect = false;
            this.dtgFlujoPrincipal.Name = "dtgFlujoPrincipal";
            this.dtgFlujoPrincipal.ReadOnly = true;
            this.dtgFlujoPrincipal.RowHeadersVisible = false;
            this.dtgFlujoPrincipal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgFlujoPrincipal.Size = new System.Drawing.Size(704, 476);
            this.dtgFlujoPrincipal.TabIndex = 0;
            this.dtgFlujoPrincipal.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgFlujoPrincipal_CellFormatting);
            // 
            // txtEgresos
            // 
            this.txtEgresos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEgresos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEgresos.FormatoDecimal = true;
            this.txtEgresos.Location = new System.Drawing.Point(90, 59);
            this.txtEgresos.MaxLength = 14;
            this.txtEgresos.Name = "txtEgresos";
            this.txtEgresos.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtEgresos.nNumDecimales = 2;
            this.txtEgresos.nvalor = 0D;
            this.txtEgresos.ReadOnly = true;
            this.txtEgresos.Size = new System.Drawing.Size(120, 20);
            this.txtEgresos.TabIndex = 9;
            this.txtEgresos.Text = "00.00";
            this.txtEgresos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNecesidadCredito
            // 
            this.txtNecesidadCredito.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNecesidadCredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNecesidadCredito.FormatoDecimal = true;
            this.txtNecesidadCredito.Location = new System.Drawing.Point(356, 61);
            this.txtNecesidadCredito.MaxLength = 14;
            this.txtNecesidadCredito.Name = "txtNecesidadCredito";
            this.txtNecesidadCredito.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtNecesidadCredito.nNumDecimales = 2;
            this.txtNecesidadCredito.nvalor = 0D;
            this.txtNecesidadCredito.ReadOnly = true;
            this.txtNecesidadCredito.Size = new System.Drawing.Size(120, 20);
            this.txtNecesidadCredito.TabIndex = 11;
            this.txtNecesidadCredito.Text = "00.00";
            this.txtNecesidadCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(224, 64);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(129, 13);
            this.lblBase1.TabIndex = 6;
            this.lblBase1.Text = "Necesidad de Credito";
            this.lblBase1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtIngresos
            // 
            this.txtIngresos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIngresos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIngresos.FormatoDecimal = true;
            this.txtIngresos.Location = new System.Drawing.Point(90, 35);
            this.txtIngresos.MaxLength = 14;
            this.txtIngresos.Name = "txtIngresos";
            this.txtIngresos.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtIngresos.nNumDecimales = 2;
            this.txtIngresos.nvalor = 0D;
            this.txtIngresos.ReadOnly = true;
            this.txtIngresos.Size = new System.Drawing.Size(120, 20);
            this.txtIngresos.TabIndex = 8;
            this.txtIngresos.Text = "00.00";
            this.txtIngresos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblEgresos
            // 
            this.lblEgresos.AutoSize = true;
            this.lblEgresos.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblEgresos.ForeColor = System.Drawing.Color.Navy;
            this.lblEgresos.Location = new System.Drawing.Point(27, 61);
            this.lblEgresos.Name = "lblEgresos";
            this.lblEgresos.Size = new System.Drawing.Size(52, 13);
            this.lblEgresos.TabIndex = 4;
            this.lblEgresos.Text = "Egresos";
            this.lblEgresos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIngresos
            // 
            this.lblIngresos.AutoSize = true;
            this.lblIngresos.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblIngresos.ForeColor = System.Drawing.Color.Navy;
            this.lblIngresos.Location = new System.Drawing.Point(27, 38);
            this.lblIngresos.Name = "lblIngresos";
            this.lblIngresos.Size = new System.Drawing.Size(57, 13);
            this.lblIngresos.TabIndex = 3;
            this.lblIngresos.Text = "Ingresos";
            this.lblIngresos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSaldoAcumulado
            // 
            this.txtSaldoAcumulado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSaldoAcumulado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldoAcumulado.FormatoDecimal = true;
            this.txtSaldoAcumulado.Location = new System.Drawing.Point(356, 35);
            this.txtSaldoAcumulado.MaxLength = 14;
            this.txtSaldoAcumulado.Name = "txtSaldoAcumulado";
            this.txtSaldoAcumulado.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtSaldoAcumulado.nNumDecimales = 2;
            this.txtSaldoAcumulado.nvalor = 0D;
            this.txtSaldoAcumulado.ReadOnly = true;
            this.txtSaldoAcumulado.Size = new System.Drawing.Size(120, 20);
            this.txtSaldoAcumulado.TabIndex = 10;
            this.txtSaldoAcumulado.Text = "00.00";
            this.txtSaldoAcumulado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSaldoAcumulado
            // 
            this.lblSaldoAcumulado.AutoSize = true;
            this.lblSaldoAcumulado.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblSaldoAcumulado.ForeColor = System.Drawing.Color.Navy;
            this.lblSaldoAcumulado.Location = new System.Drawing.Point(242, 38);
            this.lblSaldoAcumulado.Name = "lblSaldoAcumulado";
            this.lblSaldoAcumulado.Size = new System.Drawing.Size(106, 13);
            this.lblSaldoAcumulado.TabIndex = 5;
            this.lblSaldoAcumulado.Text = "Saldo Acumulado";
            this.lblSaldoAcumulado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ConFlujoCajaRural
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.grbBase2);
            this.Name = "ConFlujoCajaRural";
            this.Size = new System.Drawing.Size(1241, 611);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDisenioCrediticio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCuotas)).EndInit();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFlujoPrincipal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private lblBase lblSaldoAcumulado;
        private lblBase lblEgresos;
        private lblBase lblIngresos;
        private dtgBase dtgFlujoPrincipal;
        private lblBase lblBase1;
        private nudBase nudCuotas;
        private txtNumRea txtNecesidadCredito;
        private txtNumRea txtSaldoAcumulado;
        private txtNumRea txtEgresos;
        private txtNumRea txtIngresos;
        private lblBaseCustom lblBaseCustom42;
        private lblBaseCustom lblBaseCustom41;
        private cboMoneda cboMoneda;
        private txtNumRea txtMonto;
        private dtgBase dtgDisenioCrediticio;
        private grbBase grbBase2;
        private grbBase grbBase3;
        private txtNumerico txtConAlertas;
        private lblBase lblAlertas;
        private BotonesBase.btnValidar btnValidar;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
