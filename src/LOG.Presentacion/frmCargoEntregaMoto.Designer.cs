namespace LOG.Presentacion
{
    partial class frmCargoEntregaMoto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargoEntregaMoto));
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.lvlCproducto = new System.Windows.Forms.Label();
            this.txtCargoColaborador = new System.Windows.Forms.TextBox();
            this.lblCargoColaborador = new System.Windows.Forms.Label();
            this.lblTituloNombreColaborador = new System.Windows.Forms.Label();
            this.txtNombreColaborador = new System.Windows.Forms.TextBox();
            this.lblTituloFormulario = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFechaEntrega = new System.Windows.Forms.Label();
            this.txtFechaEntrega = new System.Windows.Forms.TextBox();
            this.txtOficinaActivo = new System.Windows.Forms.TextBox();
            this.lvlTitleOficina = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLicConducir = new System.Windows.Forms.TextBox();
            this.txtLicClase = new System.Windows.Forms.TextBox();
            this.lvlTitleLicClase = new System.Windows.Forms.Label();
            this.txtLicCategoria = new System.Windows.Forms.TextBox();
            this.lvlTitleLicCat = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tmrLicFecRevalidacion = new GEN.ControlesBase.DatePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMotoMotor = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMotoSerie = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMotoPlaca = new System.Windows.Forms.TextBox();
            this.txtMotoModelo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMotoMarca = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMotoAnioFab = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtMotoColor = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dtgPartesAccesorios = new System.Windows.Forms.DataGridView();
            this.txtKilometraje = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPartesAccesorios)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(15, 503);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 29;
            this.btnImprimir1.Text = "Continuar";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // lvlCproducto
            // 
            this.lvlCproducto.AutoSize = true;
            this.lvlCproducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvlCproducto.Location = new System.Drawing.Point(12, 309);
            this.lvlCproducto.Name = "lvlCproducto";
            this.lvlCproducto.Size = new System.Drawing.Size(155, 13);
            this.lvlCproducto.TabIndex = 25;
            this.lvlCproducto.Text = "PARTES Y ACCESORIOS:";
            // 
            // txtCargoColaborador
            // 
            this.txtCargoColaborador.Enabled = false;
            this.txtCargoColaborador.Location = new System.Drawing.Point(15, 176);
            this.txtCargoColaborador.Name = "txtCargoColaborador";
            this.txtCargoColaborador.Size = new System.Drawing.Size(336, 20);
            this.txtCargoColaborador.TabIndex = 20;
            // 
            // lblCargoColaborador
            // 
            this.lblCargoColaborador.AutoSize = true;
            this.lblCargoColaborador.Location = new System.Drawing.Point(18, 160);
            this.lblCargoColaborador.Name = "lblCargoColaborador";
            this.lblCargoColaborador.Size = new System.Drawing.Size(119, 13);
            this.lblCargoColaborador.TabIndex = 19;
            this.lblCargoColaborador.Text = "Cargo del Colaborador *";
            // 
            // lblTituloNombreColaborador
            // 
            this.lblTituloNombreColaborador.AutoSize = true;
            this.lblTituloNombreColaborador.Location = new System.Drawing.Point(16, 122);
            this.lblTituloNombreColaborador.Name = "lblTituloNombreColaborador";
            this.lblTituloNombreColaborador.Size = new System.Drawing.Size(128, 13);
            this.lblTituloNombreColaborador.TabIndex = 18;
            this.lblTituloNombreColaborador.Text = "Nombre del Colaborador *";
            // 
            // txtNombreColaborador
            // 
            this.txtNombreColaborador.Enabled = false;
            this.txtNombreColaborador.Location = new System.Drawing.Point(15, 138);
            this.txtNombreColaborador.Name = "txtNombreColaborador";
            this.txtNombreColaborador.Size = new System.Drawing.Size(336, 20);
            this.txtNombreColaborador.TabIndex = 17;
            // 
            // lblTituloFormulario
            // 
            this.lblTituloFormulario.AutoSize = true;
            this.lblTituloFormulario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloFormulario.Location = new System.Drawing.Point(12, 9);
            this.lblTituloFormulario.Name = "lblTituloFormulario";
            this.lblTituloFormulario.Size = new System.Drawing.Size(305, 13);
            this.lblTituloFormulario.TabIndex = 16;
            this.lblTituloFormulario.Text = "Comprube a continuacion los campos de información";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(247, 38);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(246, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "CARGO DE ENTREGA DE MOTOCICLETA";
            // 
            // lblFechaEntrega
            // 
            this.lblFechaEntrega.AutoSize = true;
            this.lblFechaEntrega.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaEntrega.Location = new System.Drawing.Point(12, 61);
            this.lblFechaEntrega.Name = "lblFechaEntrega";
            this.lblFechaEntrega.Size = new System.Drawing.Size(118, 13);
            this.lblFechaEntrega.TabIndex = 31;
            this.lblFechaEntrega.Text = "FECHA DE ENTREGA:";
            // 
            // txtFechaEntrega
            // 
            this.txtFechaEntrega.Enabled = false;
            this.txtFechaEntrega.Location = new System.Drawing.Point(15, 77);
            this.txtFechaEntrega.Name = "txtFechaEntrega";
            this.txtFechaEntrega.Size = new System.Drawing.Size(336, 20);
            this.txtFechaEntrega.TabIndex = 32;
            // 
            // txtOficinaActivo
            // 
            this.txtOficinaActivo.Enabled = false;
            this.txtOficinaActivo.Location = new System.Drawing.Point(357, 77);
            this.txtOficinaActivo.Name = "txtOficinaActivo";
            this.txtOficinaActivo.Size = new System.Drawing.Size(357, 20);
            this.txtOficinaActivo.TabIndex = 33;
            // 
            // lvlTitleOficina
            // 
            this.lvlTitleOficina.AutoSize = true;
            this.lvlTitleOficina.Location = new System.Drawing.Point(357, 61);
            this.lvlTitleOficina.Name = "lvlTitleOficina";
            this.lvlTitleOficina.Size = new System.Drawing.Size(52, 13);
            this.lvlTitleOficina.TabIndex = 34;
            this.lvlTitleOficina.Text = "OFICINA:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "DATOS RESPONSABLE:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(360, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Lic. Conducir:";
            // 
            // txtLicConducir
            // 
            this.txtLicConducir.Location = new System.Drawing.Point(363, 138);
            this.txtLicConducir.Name = "txtLicConducir";
            this.txtLicConducir.Size = new System.Drawing.Size(181, 20);
            this.txtLicConducir.TabIndex = 37;
            // 
            // txtLicClase
            // 
            this.txtLicClase.Location = new System.Drawing.Point(551, 138);
            this.txtLicClase.Name = "txtLicClase";
            this.txtLicClase.Size = new System.Drawing.Size(163, 20);
            this.txtLicClase.TabIndex = 38;
            // 
            // lvlTitleLicClase
            // 
            this.lvlTitleLicClase.AutoSize = true;
            this.lvlTitleLicClase.Location = new System.Drawing.Point(551, 121);
            this.lvlTitleLicClase.Name = "lvlTitleLicClase";
            this.lvlTitleLicClase.Size = new System.Drawing.Size(36, 13);
            this.lvlTitleLicClase.TabIndex = 39;
            this.lvlTitleLicClase.Text = "Clase:";
            // 
            // txtLicCategoria
            // 
            this.txtLicCategoria.Location = new System.Drawing.Point(363, 176);
            this.txtLicCategoria.Name = "txtLicCategoria";
            this.txtLicCategoria.Size = new System.Drawing.Size(181, 20);
            this.txtLicCategoria.TabIndex = 40;
            // 
            // lvlTitleLicCat
            // 
            this.lvlTitleLicCat.AutoSize = true;
            this.lvlTitleLicCat.Location = new System.Drawing.Point(363, 160);
            this.lvlTitleLicCat.Name = "lvlTitleLicCat";
            this.lvlTitleLicCat.Size = new System.Drawing.Size(55, 13);
            this.lvlTitleLicCat.TabIndex = 42;
            this.lvlTitleLicCat.Text = "Categoria:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(554, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "F. Revalidación:";
            // 
            // tmrLicFecRevalidacion
            // 
            this.tmrLicFecRevalidacion.CustomFormat = "dd/MM/yyyy";
            this.tmrLicFecRevalidacion.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tmrLicFecRevalidacion.Location = new System.Drawing.Point(550, 176);
            this.tmrLicFecRevalidacion.Name = "tmrLicFecRevalidacion";
            this.tmrLicFecRevalidacion.Size = new System.Drawing.Size(164, 20);
            this.tmrLicFecRevalidacion.TabIndex = 44;
            this.tmrLicFecRevalidacion.Value = new System.DateTime(2018, 2, 14, 13, 8, 41, 89);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(216, 13);
            this.label5.TabIndex = 45;
            this.label5.Text = "CARACTERISTICAS MOTOCICLETA:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 46;
            this.label6.Text = "Motor:";
            // 
            // txtMotoMotor
            // 
            this.txtMotoMotor.Location = new System.Drawing.Point(18, 233);
            this.txtMotoMotor.Name = "txtMotoMotor";
            this.txtMotoMotor.Size = new System.Drawing.Size(214, 20);
            this.txtMotoMotor.TabIndex = 47;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 261);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 48;
            this.label7.Text = "Chasis / Serie:";
            // 
            // txtMotoSerie
            // 
            this.txtMotoSerie.Enabled = false;
            this.txtMotoSerie.Location = new System.Drawing.Point(21, 277);
            this.txtMotoSerie.Name = "txtMotoSerie";
            this.txtMotoSerie.Size = new System.Drawing.Size(211, 20);
            this.txtMotoSerie.TabIndex = 49;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(238, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 50;
            this.label8.Text = "Placa:";
            // 
            // txtMotoPlaca
            // 
            this.txtMotoPlaca.Location = new System.Drawing.Point(239, 233);
            this.txtMotoPlaca.Name = "txtMotoPlaca";
            this.txtMotoPlaca.Size = new System.Drawing.Size(112, 20);
            this.txtMotoPlaca.TabIndex = 51;
            // 
            // txtMotoModelo
            // 
            this.txtMotoModelo.Enabled = false;
            this.txtMotoModelo.Location = new System.Drawing.Point(241, 277);
            this.txtMotoModelo.Name = "txtMotoModelo";
            this.txtMotoModelo.Size = new System.Drawing.Size(110, 20);
            this.txtMotoModelo.TabIndex = 52;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(241, 260);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 53;
            this.label9.Text = "Modelo:";
            // 
            // txtMotoMarca
            // 
            this.txtMotoMarca.Enabled = false;
            this.txtMotoMarca.Location = new System.Drawing.Point(363, 233);
            this.txtMotoMarca.Name = "txtMotoMarca";
            this.txtMotoMarca.Size = new System.Drawing.Size(181, 20);
            this.txtMotoMarca.TabIndex = 54;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(366, 216);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 55;
            this.label10.Text = "Marca:";
            // 
            // txtMotoAnioFab
            // 
            this.txtMotoAnioFab.Location = new System.Drawing.Point(363, 277);
            this.txtMotoAnioFab.Name = "txtMotoAnioFab";
            this.txtMotoAnioFab.Size = new System.Drawing.Size(181, 20);
            this.txtMotoAnioFab.TabIndex = 56;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(369, 259);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 13);
            this.label11.TabIndex = 57;
            this.label11.Text = "Año Fab:";
            // 
            // txtMotoColor
            // 
            this.txtMotoColor.Enabled = false;
            this.txtMotoColor.Location = new System.Drawing.Point(551, 233);
            this.txtMotoColor.Name = "txtMotoColor";
            this.txtMotoColor.Size = new System.Drawing.Size(163, 20);
            this.txtMotoColor.TabIndex = 58;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(554, 216);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 13);
            this.label12.TabIndex = 59;
            this.label12.Text = "Color:";
            // 
            // dtgPartesAccesorios
            // 
            this.dtgPartesAccesorios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPartesAccesorios.Location = new System.Drawing.Point(13, 326);
            this.dtgPartesAccesorios.Name = "dtgPartesAccesorios";
            this.dtgPartesAccesorios.RowHeadersVisible = false;
            this.dtgPartesAccesorios.Size = new System.Drawing.Size(701, 132);
            this.dtgPartesAccesorios.TabIndex = 60;
            this.dtgPartesAccesorios.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPartesAccesorios_CellValueChanged);
            // 
            // txtKilometraje
            // 
            this.txtKilometraje.Location = new System.Drawing.Point(81, 468);
            this.txtKilometraje.Name = "txtKilometraje";
            this.txtKilometraje.Size = new System.Drawing.Size(132, 20);
            this.txtKilometraje.TabIndex = 61;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 471);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 13);
            this.label13.TabIndex = 62;
            this.label13.Text = "Kilometraje:";
            // 
            // frmCargoEntregaMoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 578);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtKilometraje);
            this.Controls.Add(this.dtgPartesAccesorios);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtMotoColor);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtMotoAnioFab);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtMotoMarca);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtMotoModelo);
            this.Controls.Add(this.txtMotoPlaca);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtMotoSerie);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMotoMotor);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tmrLicFecRevalidacion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lvlTitleLicCat);
            this.Controls.Add(this.txtLicCategoria);
            this.Controls.Add(this.lvlTitleLicClase);
            this.Controls.Add(this.txtLicClase);
            this.Controls.Add(this.txtLicConducir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lvlTitleOficina);
            this.Controls.Add(this.txtOficinaActivo);
            this.Controls.Add(this.txtFechaEntrega);
            this.Controls.Add(this.lblFechaEntrega);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.lvlCproducto);
            this.Controls.Add(this.txtCargoColaborador);
            this.Controls.Add(this.lblCargoColaborador);
            this.Controls.Add(this.lblTituloNombreColaborador);
            this.Controls.Add(this.txtNombreColaborador);
            this.Controls.Add(this.lblTituloFormulario);
            this.Name = "frmCargoEntregaMoto";
            this.Text = "Formulario de Cargo de Entrega de Moto";
            this.Controls.SetChildIndex(this.lblTituloFormulario, 0);
            this.Controls.SetChildIndex(this.txtNombreColaborador, 0);
            this.Controls.SetChildIndex(this.lblTituloNombreColaborador, 0);
            this.Controls.SetChildIndex(this.lblCargoColaborador, 0);
            this.Controls.SetChildIndex(this.txtCargoColaborador, 0);
            this.Controls.SetChildIndex(this.lvlCproducto, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblFechaEntrega, 0);
            this.Controls.SetChildIndex(this.txtFechaEntrega, 0);
            this.Controls.SetChildIndex(this.txtOficinaActivo, 0);
            this.Controls.SetChildIndex(this.lvlTitleOficina, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtLicConducir, 0);
            this.Controls.SetChildIndex(this.txtLicClase, 0);
            this.Controls.SetChildIndex(this.lvlTitleLicClase, 0);
            this.Controls.SetChildIndex(this.txtLicCategoria, 0);
            this.Controls.SetChildIndex(this.lvlTitleLicCat, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.tmrLicFecRevalidacion, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtMotoMotor, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtMotoSerie, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtMotoPlaca, 0);
            this.Controls.SetChildIndex(this.txtMotoModelo, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.txtMotoMarca, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.txtMotoAnioFab, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.txtMotoColor, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.dtgPartesAccesorios, 0);
            this.Controls.SetChildIndex(this.txtKilometraje, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPartesAccesorios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private System.Windows.Forms.Label lvlCproducto;
        private System.Windows.Forms.TextBox txtCargoColaborador;
        private System.Windows.Forms.Label lblCargoColaborador;
        private System.Windows.Forms.Label lblTituloNombreColaborador;
        private System.Windows.Forms.TextBox txtNombreColaborador;
        private System.Windows.Forms.Label lblTituloFormulario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFechaEntrega;
        private System.Windows.Forms.TextBox txtFechaEntrega;
        private System.Windows.Forms.TextBox txtOficinaActivo;
        private System.Windows.Forms.Label lvlTitleOficina;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLicConducir;
        private System.Windows.Forms.TextBox txtLicClase;
        private System.Windows.Forms.Label lvlTitleLicClase;
        private System.Windows.Forms.TextBox txtLicCategoria;
        private System.Windows.Forms.Label lvlTitleLicCat;
        private System.Windows.Forms.Label label4;
        private GEN.ControlesBase.DatePicker tmrLicFecRevalidacion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMotoMotor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMotoSerie;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMotoPlaca;
        private System.Windows.Forms.TextBox txtMotoModelo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMotoMarca;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMotoAnioFab;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtMotoColor;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dtgPartesAccesorios;
        private System.Windows.Forms.TextBox txtKilometraje;
        private System.Windows.Forms.Label label13;
    }
}