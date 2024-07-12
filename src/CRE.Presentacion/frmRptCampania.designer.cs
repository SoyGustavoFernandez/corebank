namespace CRE.Presentacion
{
    partial class frmRptCampania
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptCampania));
            this.cboTipCredito = new GEN.ControlesBase.cboProducto(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboSubTipo = new GEN.ControlesBase.cboProducto(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboSubProducto = new GEN.ControlesBase.cboProducto(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.cboProducto = new GEN.ControlesBase.cboProducto(this.components);
            this.nudPorCuoPagada = new GEN.ControlesBase.nudBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.txtAtrMaximo = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtPromedioAtraso = new GEN.ControlesBase.txtNumRea(this.components);
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            ((System.ComponentModel.ISupportInitialize)(this.nudPorCuoPagada)).BeginInit();
            this.SuspendLayout();
            // 
            // cboTipCredito
            // 
            this.cboTipCredito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipCredito.FormattingEnabled = true;
            this.cboTipCredito.Location = new System.Drawing.Point(121, 16);
            this.cboTipCredito.Name = "cboTipCredito";
            this.cboTipCredito.Size = new System.Drawing.Size(170, 21);
            this.cboTipCredito.TabIndex = 0;
            this.cboTipCredito.SelectedIndexChanged += new System.EventHandler(this.cboTipCredito_SelectedIndexChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(17, 20);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(77, 13);
            this.lblBase1.TabIndex = 3;
            this.lblBase1.Text = "Tipo Crédito";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(17, 49);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(57, 13);
            this.lblBase2.TabIndex = 5;
            this.lblBase2.Text = "Sub Tipo";
            // 
            // cboSubTipo
            // 
            this.cboSubTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubTipo.FormattingEnabled = true;
            this.cboSubTipo.Location = new System.Drawing.Point(121, 45);
            this.cboSubTipo.Name = "cboSubTipo";
            this.cboSubTipo.Size = new System.Drawing.Size(170, 21);
            this.cboSubTipo.TabIndex = 1;
            this.cboSubTipo.SelectedIndexChanged += new System.EventHandler(this.cboSubTipo_SelectedIndexChanged);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(17, 107);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(83, 13);
            this.lblBase3.TabIndex = 7;
            this.lblBase3.Text = "Sub Producto";
            // 
            // cboSubProducto
            // 
            this.cboSubProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubProducto.FormattingEnabled = true;
            this.cboSubProducto.Location = new System.Drawing.Point(121, 103);
            this.cboSubProducto.Name = "cboSubProducto";
            this.cboSubProducto.Size = new System.Drawing.Size(170, 21);
            this.cboSubProducto.TabIndex = 3;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(17, 78);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(57, 13);
            this.lblBase4.TabIndex = 9;
            this.lblBase4.Text = "Producto";
            // 
            // cboProducto
            // 
            this.cboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProducto.FormattingEnabled = true;
            this.cboProducto.Location = new System.Drawing.Point(121, 74);
            this.cboProducto.Name = "cboProducto";
            this.cboProducto.Size = new System.Drawing.Size(170, 21);
            this.cboProducto.TabIndex = 2;
            this.cboProducto.SelectedIndexChanged += new System.EventHandler(this.cboProducto_SelectedIndexChanged);
            // 
            // nudPorCuoPagada
            // 
            this.nudPorCuoPagada.Location = new System.Drawing.Point(216, 133);
            this.nudPorCuoPagada.Name = "nudPorCuoPagada";
            this.nudPorCuoPagada.Size = new System.Drawing.Size(60, 20);
            this.nudPorCuoPagada.TabIndex = 4;
            this.nudPorCuoPagada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(17, 137);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(187, 13);
            this.lblBase5.TabIndex = 11;
            this.lblBase5.Text = "Porcentaje Cuotas Canceladas:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(282, 137);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(19, 13);
            this.lblBase6.TabIndex = 12;
            this.lblBase6.Text = "%";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(17, 193);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(107, 13);
            this.lblBase7.TabIndex = 13;
            this.lblBase7.Text = "Promedio Atraso:";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(17, 165);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(97, 13);
            this.lblBase8.TabIndex = 14;
            this.lblBase8.Text = "Atraso Máximo:";
            // 
            // txtAtrMaximo
            // 
            this.txtAtrMaximo.FormatoDecimal = false;
            this.txtAtrMaximo.Location = new System.Drawing.Point(148, 161);
            this.txtAtrMaximo.Name = "txtAtrMaximo";
            this.txtAtrMaximo.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtAtrMaximo.nNumDecimales = 0;
            this.txtAtrMaximo.nvalor = 0D;
            this.txtAtrMaximo.Size = new System.Drawing.Size(100, 20);
            this.txtAtrMaximo.TabIndex = 5;
            this.txtAtrMaximo.Text = "0";
            this.txtAtrMaximo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPromedioAtraso
            // 
            this.txtPromedioAtraso.FormatoDecimal = false;
            this.txtPromedioAtraso.Location = new System.Drawing.Point(148, 189);
            this.txtPromedioAtraso.Name = "txtPromedioAtraso";
            this.txtPromedioAtraso.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPromedioAtraso.nNumDecimales = 0;
            this.txtPromedioAtraso.nvalor = 0D;
            this.txtPromedioAtraso.Size = new System.Drawing.Size(100, 20);
            this.txtPromedioAtraso.TabIndex = 6;
            this.txtPromedioAtraso.Text = "0";
            this.txtPromedioAtraso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(184, 237);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 7;
            this.btnImprimir1.Text = "&Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(250, 237);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 8;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(251, 165);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(32, 13);
            this.lblBase9.TabIndex = 15;
            this.lblBase9.Text = "Días";
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(251, 193);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(32, 13);
            this.lblBase10.TabIndex = 16;
            this.lblBase10.Text = "Días";
            // 
            // frmRptCampania
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 324);
            this.Controls.Add(this.lblBase10);
            this.Controls.Add(this.lblBase9);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.txtPromedioAtraso);
            this.Controls.Add(this.txtAtrMaximo);
            this.Controls.Add(this.lblBase8);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.nudPorCuoPagada);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.cboProducto);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.cboSubProducto);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.cboSubTipo);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.cboTipCredito);
            this.Name = "frmRptCampania";
            this.Text = "Reporte para Campañas";
            this.Controls.SetChildIndex(this.cboTipCredito, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.cboSubTipo, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.cboSubProducto, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.cboProducto, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.nudPorCuoPagada, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            this.Controls.SetChildIndex(this.lblBase8, 0);
            this.Controls.SetChildIndex(this.txtAtrMaximo, 0);
            this.Controls.SetChildIndex(this.txtPromedioAtraso, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.lblBase9, 0);
            this.Controls.SetChildIndex(this.lblBase10, 0);
            ((System.ComponentModel.ISupportInitialize)(this.nudPorCuoPagada)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboProducto cboTipCredito;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboProducto cboSubTipo;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.cboProducto cboSubProducto;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.cboProducto cboProducto;
        private GEN.ControlesBase.nudBase nudPorCuoPagada;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.txtNumRea txtAtrMaximo;
        private GEN.ControlesBase.txtNumRea txtPromedioAtraso;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.lblBase lblBase10;
    }
}