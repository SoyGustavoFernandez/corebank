namespace CRE.Presentacion
{
    partial class frmSolCondonaPorCuota
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSolCondonaPorCuota));
            this.dtgPpg = new GEN.ControlesBase.dtgBase(this.components);
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtCapital = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtInteres = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtInteresComp = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtMora = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtOtros = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblTipoCondonacion = new System.Windows.Forms.Label();
            this.txtTotalCondonar = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.txtTotalPagar = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblMaxPagar = new GEN.ControlesBase.lblBase();
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.cuotasCubiertas = new GEN.ControlesBase.txtNumerico(this.components);
            this.maxCondonar = new GEN.ControlesBase.lblBase();
            this.grbDetCondo = new GEN.ControlesBase.grbBase(this.components);
            this.grbITF = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase25 = new GEN.ControlesBase.lblBase();
            this.txtITF = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.btnDistribuir = new System.Windows.Forms.Button();
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPpg)).BeginInit();
            this.grbDetCondo.SuspendLayout();
            this.grbITF.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgPpg
            // 
            this.dtgPpg.AllowUserToAddRows = false;
            this.dtgPpg.AllowUserToDeleteRows = false;
            this.dtgPpg.AllowUserToResizeColumns = false;
            this.dtgPpg.AllowUserToResizeRows = false;
            this.dtgPpg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dtgPpg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPpg.Location = new System.Drawing.Point(4, 30);
            this.dtgPpg.MultiSelect = false;
            this.dtgPpg.Name = "dtgPpg";
            this.dtgPpg.ReadOnly = true;
            this.dtgPpg.RowHeadersVisible = false;
            this.dtgPpg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgPpg.Size = new System.Drawing.Size(797, 254);
            this.dtgPpg.TabIndex = 2;
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(679, 392);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 3;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(741, 392);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 4;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(19, 293);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(39, 13);
            this.lblBase1.TabIndex = 5;
            this.lblBase1.Text = "Cap.:";
            // 
            // txtCapital
            // 
            this.txtCapital.FormatoDecimal = false;
            this.txtCapital.Location = new System.Drawing.Point(55, 290);
            this.txtCapital.Name = "txtCapital";
            this.txtCapital.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtCapital.nNumDecimales = 2;
            this.txtCapital.nvalor = 0D;
            this.txtCapital.ReadOnly = true;
            this.txtCapital.Size = new System.Drawing.Size(70, 20);
            this.txtCapital.TabIndex = 6;
            this.txtCapital.Text = "0.00";
            // 
            // txtInteres
            // 
            this.txtInteres.FormatoDecimal = false;
            this.txtInteres.Location = new System.Drawing.Point(181, 290);
            this.txtInteres.Name = "txtInteres";
            this.txtInteres.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtInteres.nNumDecimales = 2;
            this.txtInteres.nvalor = 0D;
            this.txtInteres.ReadOnly = true;
            this.txtInteres.Size = new System.Drawing.Size(70, 20);
            this.txtInteres.TabIndex = 8;
            this.txtInteres.Text = "0.00";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(152, 293);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(32, 13);
            this.lblBase2.TabIndex = 7;
            this.lblBase2.Text = "Int.:";
            // 
            // txtInteresComp
            // 
            this.txtInteresComp.FormatoDecimal = false;
            this.txtInteresComp.Location = new System.Drawing.Point(326, 290);
            this.txtInteresComp.Name = "txtInteresComp";
            this.txtInteresComp.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtInteresComp.nNumDecimales = 2;
            this.txtInteresComp.nvalor = 0D;
            this.txtInteresComp.ReadOnly = true;
            this.txtInteresComp.Size = new System.Drawing.Size(70, 20);
            this.txtInteresComp.TabIndex = 10;
            this.txtInteresComp.Text = "0.00";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(263, 293);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(66, 13);
            this.lblBase3.TabIndex = 9;
            this.lblBase3.Text = "Int.Comp:";
            // 
            // txtMora
            // 
            this.txtMora.FormatoDecimal = false;
            this.txtMora.Location = new System.Drawing.Point(456, 290);
            this.txtMora.Name = "txtMora";
            this.txtMora.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMora.nNumDecimales = 2;
            this.txtMora.nvalor = 0D;
            this.txtMora.ReadOnly = true;
            this.txtMora.Size = new System.Drawing.Size(70, 20);
            this.txtMora.TabIndex = 12;
            this.txtMora.Text = "0.00";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(419, 293);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(40, 13);
            this.lblBase4.TabIndex = 11;
            this.lblBase4.Text = "Mora:";
            // 
            // txtOtros
            // 
            this.txtOtros.FormatoDecimal = false;
            this.txtOtros.Location = new System.Drawing.Point(585, 290);
            this.txtOtros.Name = "txtOtros";
            this.txtOtros.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtOtros.nNumDecimales = 2;
            this.txtOtros.nvalor = 0D;
            this.txtOtros.ReadOnly = true;
            this.txtOtros.Size = new System.Drawing.Size(73, 20);
            this.txtOtros.TabIndex = 14;
            this.txtOtros.Text = "0.00";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(546, 293);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(43, 13);
            this.lblBase5.TabIndex = 13;
            this.lblBase5.Text = "Otros:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(12, 9);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(114, 13);
            this.lblBase6.TabIndex = 15;
            this.lblBase6.Text = "Tipo Condonación:";
            // 
            // lblTipoCondonacion
            // 
            this.lblTipoCondonacion.AutoSize = true;
            this.lblTipoCondonacion.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.lblTipoCondonacion.ForeColor = System.Drawing.Color.Navy;
            this.lblTipoCondonacion.Location = new System.Drawing.Point(132, 9);
            this.lblTipoCondonacion.Name = "lblTipoCondonacion";
            this.lblTipoCondonacion.Size = new System.Drawing.Size(90, 13);
            this.lblTipoCondonacion.TabIndex = 17;
            this.lblTipoCondonacion.Text = "Condonacion";
            // 
            // txtTotalCondonar
            // 
            this.txtTotalCondonar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalCondonar.FormatoDecimal = false;
            this.txtTotalCondonar.Location = new System.Drawing.Point(322, 19);
            this.txtTotalCondonar.Name = "txtTotalCondonar";
            this.txtTotalCondonar.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtTotalCondonar.nNumDecimales = 2;
            this.txtTotalCondonar.nvalor = 0D;
            this.txtTotalCondonar.Size = new System.Drawing.Size(70, 20);
            this.txtTotalCondonar.TabIndex = 19;
            this.txtTotalCondonar.Text = "0.00";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(217, 22);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(99, 13);
            this.lblBase7.TabIndex = 18;
            this.lblBase7.Text = "Total Condonar:";
            // 
            // txtTotalPagar
            // 
            this.txtTotalPagar.Enabled = false;
            this.txtTotalPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPagar.FormatoDecimal = false;
            this.txtTotalPagar.Location = new System.Drawing.Point(581, 19);
            this.txtTotalPagar.Name = "txtTotalPagar";
            this.txtTotalPagar.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtTotalPagar.nNumDecimales = 2;
            this.txtTotalPagar.nvalor = 0D;
            this.txtTotalPagar.Size = new System.Drawing.Size(70, 20);
            this.txtTotalPagar.TabIndex = 21;
            this.txtTotalPagar.Text = "0.00";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(487, 22);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(87, 13);
            this.lblBase8.TabIndex = 20;
            this.lblBase8.Text = "Total a pagar:";
            // 
            // lblMaxPagar
            // 
            this.lblMaxPagar.AutoSize = true;
            this.lblMaxPagar.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblMaxPagar.ForeColor = System.Drawing.Color.Navy;
            this.lblMaxPagar.Location = new System.Drawing.Point(592, 38);
            this.lblMaxPagar.Name = "lblMaxPagar";
            this.lblMaxPagar.Size = new System.Drawing.Size(32, 13);
            this.lblMaxPagar.TabIndex = 23;
            this.lblMaxPagar.Text = "0.00";
            this.lblMaxPagar.Visible = false;
            // 
            // lblBase13
            // 
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(15, 22);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(121, 24);
            this.lblBase13.TabIndex = 31;
            this.lblBase13.Text = "Cuotas Cubiertas:";
            // 
            // cuotasCubiertas
            // 
            this.cuotasCubiertas.Format = "n2";
            this.cuotasCubiertas.Location = new System.Drawing.Point(131, 19);
            this.cuotasCubiertas.Name = "cuotasCubiertas";
            this.cuotasCubiertas.Size = new System.Drawing.Size(49, 20);
            this.cuotasCubiertas.TabIndex = 32;
            this.cuotasCubiertas.Text = "0";
            this.cuotasCubiertas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cuotasCubiertas_KeyPress);
            // 
            // maxCondonar
            // 
            this.maxCondonar.AutoSize = true;
            this.maxCondonar.Font = new System.Drawing.Font("Verdana", 8F);
            this.maxCondonar.ForeColor = System.Drawing.Color.Navy;
            this.maxCondonar.Location = new System.Drawing.Point(345, 46);
            this.maxCondonar.Name = "maxCondonar";
            this.maxCondonar.Size = new System.Drawing.Size(32, 13);
            this.maxCondonar.TabIndex = 22;
            this.maxCondonar.Text = "0.00";
            // 
            // grbDetCondo
            // 
            this.grbDetCondo.Controls.Add(this.grbITF);
            this.grbDetCondo.Controls.Add(this.lblBase9);
            this.grbDetCondo.Controls.Add(this.lblBase7);
            this.grbDetCondo.Controls.Add(this.txtTotalCondonar);
            this.grbDetCondo.Controls.Add(this.lblBase8);
            this.grbDetCondo.Controls.Add(this.cuotasCubiertas);
            this.grbDetCondo.Controls.Add(this.txtTotalPagar);
            this.grbDetCondo.Controls.Add(this.maxCondonar);
            this.grbDetCondo.Controls.Add(this.lblMaxPagar);
            this.grbDetCondo.Controls.Add(this.lblBase13);
            this.grbDetCondo.Location = new System.Drawing.Point(4, 328);
            this.grbDetCondo.Name = "grbDetCondo";
            this.grbDetCondo.Size = new System.Drawing.Size(669, 89);
            this.grbDetCondo.TabIndex = 33;
            this.grbDetCondo.TabStop = false;
            this.grbDetCondo.Text = "Detalle de condonación por cuota";
            // 
            // grbITF
            // 
            this.grbITF.Controls.Add(this.lblBase25);
            this.grbITF.Controls.Add(this.txtITF);
            this.grbITF.Location = new System.Drawing.Point(481, 54);
            this.grbITF.Name = "grbITF";
            this.grbITF.Size = new System.Drawing.Size(182, 33);
            this.grbITF.TabIndex = 61;
            this.grbITF.TabStop = false;
            // 
            // lblBase25
            // 
            this.lblBase25.AutoSize = true;
            this.lblBase25.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase25.ForeColor = System.Drawing.Color.Navy;
            this.lblBase25.Location = new System.Drawing.Point(61, 16);
            this.lblBase25.Name = "lblBase25";
            this.lblBase25.Size = new System.Drawing.Size(32, 13);
            this.lblBase25.TabIndex = 59;
            this.lblBase25.Text = "ITF.:";
            // 
            // txtITF
            // 
            this.txtITF.FormatoDecimal = false;
            this.txtITF.Location = new System.Drawing.Point(100, 7);
            this.txtITF.Name = "txtITF";
            this.txtITF.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtITF.nNumDecimales = 4;
            this.txtITF.nvalor = 0D;
            this.txtITF.ReadOnly = true;
            this.txtITF.Size = new System.Drawing.Size(70, 20);
            this.txtITF.TabIndex = 58;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(210, 46);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(106, 13);
            this.lblBase9.TabIndex = 33;
            this.lblBase9.Text = "Max a Condonar:";
            // 
            // btnDistribuir
            // 
            this.btnDistribuir.BackgroundImage = global::CRE.Presentacion.Properties.Resources.success;
            this.btnDistribuir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDistribuir.Location = new System.Drawing.Point(741, 328);
            this.btnDistribuir.Name = "btnDistribuir";
            this.btnDistribuir.Size = new System.Drawing.Size(60, 51);
            this.btnDistribuir.TabIndex = 62;
            this.btnDistribuir.Text = "Distribuir";
            this.btnDistribuir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDistribuir.UseVisualStyleBackColor = true;
            this.btnDistribuir.Click += new System.EventHandler(this.btnDistribuir_Click);
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(679, 329);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 63;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // frmSolCondonaPorCuota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 467);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.btnDistribuir);
            this.Controls.Add(this.grbDetCondo);
            this.Controls.Add(this.lblTipoCondonacion);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.txtOtros);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.txtMora);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.txtInteresComp);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.txtInteres);
            this.Controls.Add(this.btnAceptar1);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.txtCapital);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.dtgPpg);
            this.Name = "frmSolCondonaPorCuota";
            this.Text = "Condonación por cuota";
            this.Load += new System.EventHandler(this.frmSolCondonaPorCuota_Load);
            this.Controls.SetChildIndex(this.dtgPpg, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.txtCapital, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            this.Controls.SetChildIndex(this.txtInteres, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.txtInteresComp, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.txtMora, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.txtOtros, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.lblTipoCondonacion, 0);
            this.Controls.SetChildIndex(this.grbDetCondo, 0);
            this.Controls.SetChildIndex(this.btnDistribuir, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPpg)).EndInit();
            this.grbDetCondo.ResumeLayout(false);
            this.grbDetCondo.PerformLayout();
            this.grbITF.ResumeLayout(false);
            this.grbITF.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgPpg;
        private GEN.BotonesBase.BtnAceptar btnAceptar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtNumRea txtCapital;
        private GEN.ControlesBase.txtNumRea txtInteres;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtNumRea txtInteresComp;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtNumRea txtMora;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtNumRea txtOtros;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase6;
        private System.Windows.Forms.Label lblTipoCondonacion;
        private GEN.ControlesBase.txtNumRea txtTotalCondonar;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.txtNumRea txtTotalPagar;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.lblBase lblMaxPagar;
        private GEN.ControlesBase.lblBase lblBase13;
        private GEN.ControlesBase.txtNumerico cuotasCubiertas;
        private GEN.ControlesBase.lblBase maxCondonar;
        private GEN.ControlesBase.grbBase grbDetCondo;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.grbBase grbITF;
        private GEN.ControlesBase.lblBase lblBase25;
        private GEN.ControlesBase.txtNumRea txtITF;
        private System.Windows.Forms.Button btnDistribuir;
        private GEN.BotonesBase.btnEditar btnEditar1;
    }
}