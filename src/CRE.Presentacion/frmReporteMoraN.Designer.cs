namespace CRE.Presentacion
{
    partial class frmReporteMoraN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteMoraN));
            this.groupBoxFecha = new System.Windows.Forms.GroupBox();
            this.chcBaseTodos = new GEN.ControlesBase.chcBase(this.components);
            this.nudBaseDesde = new GEN.ControlesBase.nudBase(this.components);
            this.nudBaseHasta = new GEN.ControlesBase.nudBase(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.groupBoxAsesor = new System.Windows.Forms.GroupBox();
            this.btnImprimirAsesor = new GEN.BotonesBase.btnImprimir();
            this.btnSalir2 = new GEN.BotonesBase.btnSalir();
            this.groupBoxJefeOficina = new System.Windows.Forms.GroupBox();
            this.cboPersonalCreditosJefeOficina = new GEN.ControlesBase.cboPersonalCreditos(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.btnImprimirOficina = new GEN.BotonesBase.btnImprimir();
            this.btnSalir3 = new GEN.BotonesBase.btnSalir();
            this.groupBoxGerenteRegional = new System.Windows.Forms.GroupBox();
            this.cboAgenciasGerenteRegional = new GEN.ControlesBase.cboAgencias(this.components);
            this.cboPersonalCreditosGerenteRegional = new GEN.ControlesBase.cboPersonalCreditos(this.components);
            this.btnImprimirGerenteRegional = new GEN.BotonesBase.btnImprimir();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.btnSalir4 = new GEN.BotonesBase.btnSalir();
            this.groupBoxAdministrador = new System.Windows.Forms.GroupBox();
            this.cboZonaAdministrador = new GEN.ControlesBase.cboZona(this.components);
            this.cboAgenciasAdministrador = new GEN.ControlesBase.cboAgencias(this.components);
            this.cboPersonalCreditosAdministrador = new GEN.ControlesBase.cboPersonalCreditos(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.btnImprimirAdministrador = new GEN.BotonesBase.btnImprimir();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.labelNoCorresponde = new System.Windows.Forms.Label();
            this.btnSalirNoCorresponde = new GEN.BotonesBase.btnSalir();
            this.groupBoxFecha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBaseDesde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBaseHasta)).BeginInit();
            this.groupBoxAsesor.SuspendLayout();
            this.groupBoxJefeOficina.SuspendLayout();
            this.groupBoxGerenteRegional.SuspendLayout();
            this.groupBoxAdministrador.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxFecha
            // 
            this.groupBoxFecha.Controls.Add(this.chcBaseTodos);
            this.groupBoxFecha.Controls.Add(this.nudBaseDesde);
            this.groupBoxFecha.Controls.Add(this.nudBaseHasta);
            this.groupBoxFecha.Controls.Add(this.lblBase8);
            this.groupBoxFecha.Controls.Add(this.lblBase1);
            this.groupBoxFecha.Location = new System.Drawing.Point(12, 12);
            this.groupBoxFecha.Name = "groupBoxFecha";
            this.groupBoxFecha.Size = new System.Drawing.Size(313, 53);
            this.groupBoxFecha.TabIndex = 3;
            this.groupBoxFecha.TabStop = false;
            this.groupBoxFecha.Text = "Rango de Mora (días)";
            // 
            // chcBaseTodos
            // 
            this.chcBaseTodos.AutoSize = true;
            this.chcBaseTodos.ForeColor = System.Drawing.Color.Navy;
            this.chcBaseTodos.Location = new System.Drawing.Point(243, 22);
            this.chcBaseTodos.Name = "chcBaseTodos";
            this.chcBaseTodos.Size = new System.Drawing.Size(56, 17);
            this.chcBaseTodos.TabIndex = 3;
            this.chcBaseTodos.Text = "Todos";
            this.chcBaseTodos.UseVisualStyleBackColor = true;
            this.chcBaseTodos.CheckedChanged += new System.EventHandler(this.chcBaseTodos_Changed);
            // 
            // nudBaseDesde
            // 
            this.nudBaseDesde.Location = new System.Drawing.Point(64, 21);
            this.nudBaseDesde.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudBaseDesde.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBaseDesde.Name = "nudBaseDesde";
            this.nudBaseDesde.Size = new System.Drawing.Size(56, 20);
            this.nudBaseDesde.TabIndex = 1;
            this.nudBaseDesde.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudBaseHasta
            // 
            this.nudBaseHasta.Location = new System.Drawing.Point(166, 20);
            this.nudBaseHasta.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudBaseHasta.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBaseHasta.Name = "nudBaseHasta";
            this.nudBaseHasta.Size = new System.Drawing.Size(57, 20);
            this.nudBaseHasta.TabIndex = 2;
            this.nudBaseHasta.Value = new decimal(new int[] {
            999,
            0,
            0,
            0});
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(122, 23);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(44, 13);
            this.lblBase8.TabIndex = 7;
            this.lblBase8.Text = "Hasta:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(16, 23);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(48, 13);
            this.lblBase1.TabIndex = 6;
            this.lblBase1.Text = "Desde:";
            // 
            // groupBoxAsesor
            // 
            this.groupBoxAsesor.Controls.Add(this.btnImprimirAsesor);
            this.groupBoxAsesor.Controls.Add(this.btnSalir2);
            this.groupBoxAsesor.Location = new System.Drawing.Point(12, 71);
            this.groupBoxAsesor.Name = "groupBoxAsesor";
            this.groupBoxAsesor.Size = new System.Drawing.Size(313, 80);
            this.groupBoxAsesor.TabIndex = 6;
            this.groupBoxAsesor.TabStop = false;
            this.groupBoxAsesor.Visible = false;
            // 
            // btnImprimirAsesor
            // 
            this.btnImprimirAsesor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimirAsesor.BackgroundImage")));
            this.btnImprimirAsesor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimirAsesor.Location = new System.Drawing.Point(85, 19);
            this.btnImprimirAsesor.Name = "btnImprimirAsesor";
            this.btnImprimirAsesor.Size = new System.Drawing.Size(60, 50);
            this.btnImprimirAsesor.TabIndex = 4;
            this.btnImprimirAsesor.Text = "Imprimir";
            this.btnImprimirAsesor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimirAsesor.UseVisualStyleBackColor = true;
            this.btnImprimirAsesor.Click += new System.EventHandler(this.btnImprimirAsesor_Click);
            // 
            // btnSalir2
            // 
            this.btnSalir2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir2.BackgroundImage")));
            this.btnSalir2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir2.Location = new System.Drawing.Point(166, 19);
            this.btnSalir2.Name = "btnSalir2";
            this.btnSalir2.Size = new System.Drawing.Size(60, 50);
            this.btnSalir2.TabIndex = 5;
            this.btnSalir2.Text = "&Salir";
            this.btnSalir2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir2.UseVisualStyleBackColor = true;
            // 
            // groupBoxJefeOficina
            // 
            this.groupBoxJefeOficina.Controls.Add(this.cboPersonalCreditosJefeOficina);
            this.groupBoxJefeOficina.Controls.Add(this.lblBase2);
            this.groupBoxJefeOficina.Controls.Add(this.btnImprimirOficina);
            this.groupBoxJefeOficina.Controls.Add(this.btnSalir3);
            this.groupBoxJefeOficina.Location = new System.Drawing.Point(12, 157);
            this.groupBoxJefeOficina.Name = "groupBoxJefeOficina";
            this.groupBoxJefeOficina.Size = new System.Drawing.Size(313, 121);
            this.groupBoxJefeOficina.TabIndex = 7;
            this.groupBoxJefeOficina.TabStop = false;
            this.groupBoxJefeOficina.Visible = false;
            // 
            // cboPersonalCreditosJefeOficina
            // 
            this.cboPersonalCreditosJefeOficina.FormattingEnabled = true;
            this.cboPersonalCreditosJefeOficina.Location = new System.Drawing.Point(94, 22);
            this.cboPersonalCreditosJefeOficina.Name = "cboPersonalCreditosJefeOficina";
            this.cboPersonalCreditosJefeOficina.Size = new System.Drawing.Size(202, 21);
            this.cboPersonalCreditosJefeOficina.TabIndex = 6;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(43, 25);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(51, 13);
            this.lblBase2.TabIndex = 7;
            this.lblBase2.Text = "Asesor:";
            // 
            // btnImprimirOficina
            // 
            this.btnImprimirOficina.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimirOficina.BackgroundImage")));
            this.btnImprimirOficina.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimirOficina.Location = new System.Drawing.Point(85, 59);
            this.btnImprimirOficina.Name = "btnImprimirOficina";
            this.btnImprimirOficina.Size = new System.Drawing.Size(60, 50);
            this.btnImprimirOficina.TabIndex = 7;
            this.btnImprimirOficina.Text = "Imprimir";
            this.btnImprimirOficina.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimirOficina.UseVisualStyleBackColor = true;
            this.btnImprimirOficina.Click += new System.EventHandler(this.btnImprimirOficina_Click);
            // 
            // btnSalir3
            // 
            this.btnSalir3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir3.BackgroundImage")));
            this.btnSalir3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir3.Location = new System.Drawing.Point(166, 59);
            this.btnSalir3.Name = "btnSalir3";
            this.btnSalir3.Size = new System.Drawing.Size(60, 50);
            this.btnSalir3.TabIndex = 8;
            this.btnSalir3.Text = "&Salir";
            this.btnSalir3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir3.UseVisualStyleBackColor = true;
            // 
            // groupBoxGerenteRegional
            // 
            this.groupBoxGerenteRegional.Controls.Add(this.cboAgenciasGerenteRegional);
            this.groupBoxGerenteRegional.Controls.Add(this.cboPersonalCreditosGerenteRegional);
            this.groupBoxGerenteRegional.Controls.Add(this.btnImprimirGerenteRegional);
            this.groupBoxGerenteRegional.Controls.Add(this.lblBase4);
            this.groupBoxGerenteRegional.Controls.Add(this.lblBase3);
            this.groupBoxGerenteRegional.Controls.Add(this.btnSalir4);
            this.groupBoxGerenteRegional.Location = new System.Drawing.Point(12, 284);
            this.groupBoxGerenteRegional.Name = "groupBoxGerenteRegional";
            this.groupBoxGerenteRegional.Size = new System.Drawing.Size(313, 155);
            this.groupBoxGerenteRegional.TabIndex = 8;
            this.groupBoxGerenteRegional.TabStop = false;
            this.groupBoxGerenteRegional.Visible = false;
            // 
            // cboAgenciasGerenteRegional
            // 
            this.cboAgenciasGerenteRegional.FormattingEnabled = true;
            this.cboAgenciasGerenteRegional.Location = new System.Drawing.Point(94, 25);
            this.cboAgenciasGerenteRegional.Name = "cboAgenciasGerenteRegional";
            this.cboAgenciasGerenteRegional.Size = new System.Drawing.Size(202, 21);
            this.cboAgenciasGerenteRegional.TabIndex = 9;
            this.cboAgenciasGerenteRegional.SelectedValueChanged += new System.EventHandler(this.cboAgenciasGerenteRegional_Change);
            // 
            // cboPersonalCreditosGerenteRegional
            // 
            this.cboPersonalCreditosGerenteRegional.FormattingEnabled = true;
            this.cboPersonalCreditosGerenteRegional.Location = new System.Drawing.Point(94, 55);
            this.cboPersonalCreditosGerenteRegional.Name = "cboPersonalCreditosGerenteRegional";
            this.cboPersonalCreditosGerenteRegional.Size = new System.Drawing.Size(202, 21);
            this.cboPersonalCreditosGerenteRegional.TabIndex = 10;
            // 
            // btnImprimirGerenteRegional
            // 
            this.btnImprimirGerenteRegional.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimirGerenteRegional.BackgroundImage")));
            this.btnImprimirGerenteRegional.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimirGerenteRegional.Location = new System.Drawing.Point(85, 92);
            this.btnImprimirGerenteRegional.Name = "btnImprimirGerenteRegional";
            this.btnImprimirGerenteRegional.Size = new System.Drawing.Size(60, 50);
            this.btnImprimirGerenteRegional.TabIndex = 11;
            this.btnImprimirGerenteRegional.Text = "Imprimir";
            this.btnImprimirGerenteRegional.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimirGerenteRegional.UseVisualStyleBackColor = true;
            this.btnImprimirGerenteRegional.Click += new System.EventHandler(this.btnImprimirGerenteRegional_Click);
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(43, 58);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(51, 13);
            this.lblBase4.TabIndex = 9;
            this.lblBase4.Text = "Asesor:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(37, 28);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(57, 13);
            this.lblBase3.TabIndex = 9;
            this.lblBase3.Text = "Agencia:";
            // 
            // btnSalir4
            // 
            this.btnSalir4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir4.BackgroundImage")));
            this.btnSalir4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir4.Location = new System.Drawing.Point(165, 92);
            this.btnSalir4.Name = "btnSalir4";
            this.btnSalir4.Size = new System.Drawing.Size(60, 50);
            this.btnSalir4.TabIndex = 12;
            this.btnSalir4.Text = "&Salir";
            this.btnSalir4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir4.UseVisualStyleBackColor = true;
            // 
            // groupBoxAdministrador
            // 
            this.groupBoxAdministrador.Controls.Add(this.cboZonaAdministrador);
            this.groupBoxAdministrador.Controls.Add(this.cboAgenciasAdministrador);
            this.groupBoxAdministrador.Controls.Add(this.cboPersonalCreditosAdministrador);
            this.groupBoxAdministrador.Controls.Add(this.lblBase7);
            this.groupBoxAdministrador.Controls.Add(this.btnImprimirAdministrador);
            this.groupBoxAdministrador.Controls.Add(this.lblBase5);
            this.groupBoxAdministrador.Controls.Add(this.lblBase6);
            this.groupBoxAdministrador.Controls.Add(this.btnSalir1);
            this.groupBoxAdministrador.Location = new System.Drawing.Point(12, 445);
            this.groupBoxAdministrador.Name = "groupBoxAdministrador";
            this.groupBoxAdministrador.Size = new System.Drawing.Size(313, 184);
            this.groupBoxAdministrador.TabIndex = 12;
            this.groupBoxAdministrador.TabStop = false;
            this.groupBoxAdministrador.Visible = false;
            // 
            // cboZonaAdministrador
            // 
            this.cboZonaAdministrador.FormattingEnabled = true;
            this.cboZonaAdministrador.Location = new System.Drawing.Point(94, 24);
            this.cboZonaAdministrador.Name = "cboZonaAdministrador";
            this.cboZonaAdministrador.Size = new System.Drawing.Size(202, 21);
            this.cboZonaAdministrador.TabIndex = 13;
            this.cboZonaAdministrador.SelectedValueChanged += new System.EventHandler(this.cboZonaAdministrador_Change);
            // 
            // cboAgenciasAdministrador
            // 
            this.cboAgenciasAdministrador.FormattingEnabled = true;
            this.cboAgenciasAdministrador.Location = new System.Drawing.Point(94, 55);
            this.cboAgenciasAdministrador.Name = "cboAgenciasAdministrador";
            this.cboAgenciasAdministrador.Size = new System.Drawing.Size(202, 21);
            this.cboAgenciasAdministrador.TabIndex = 14;
            this.cboAgenciasAdministrador.SelectedValueChanged += new System.EventHandler(this.cboAgenciasAdministrador_Change);
            // 
            // cboPersonalCreditosAdministrador
            // 
            this.cboPersonalCreditosAdministrador.FormattingEnabled = true;
            this.cboPersonalCreditosAdministrador.Location = new System.Drawing.Point(94, 85);
            this.cboPersonalCreditosAdministrador.Name = "cboPersonalCreditosAdministrador";
            this.cboPersonalCreditosAdministrador.Size = new System.Drawing.Size(202, 21);
            this.cboPersonalCreditosAdministrador.TabIndex = 15;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(9, 27);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(85, 13);
            this.lblBase7.TabIndex = 12;
            this.lblBase7.Text = "Región/Zona:";
            // 
            // btnImprimirAdministrador
            // 
            this.btnImprimirAdministrador.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimirAdministrador.BackgroundImage")));
            this.btnImprimirAdministrador.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimirAdministrador.Location = new System.Drawing.Point(85, 121);
            this.btnImprimirAdministrador.Name = "btnImprimirAdministrador";
            this.btnImprimirAdministrador.Size = new System.Drawing.Size(60, 50);
            this.btnImprimirAdministrador.TabIndex = 16;
            this.btnImprimirAdministrador.Text = "Imprimir";
            this.btnImprimirAdministrador.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimirAdministrador.UseVisualStyleBackColor = true;
            this.btnImprimirAdministrador.Click += new System.EventHandler(this.btnImprimirAdministrador_Click);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(43, 88);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(51, 13);
            this.lblBase5.TabIndex = 9;
            this.lblBase5.Text = "Asesor:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(37, 58);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(57, 13);
            this.lblBase6.TabIndex = 9;
            this.lblBase6.Text = "Agencia:";
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(165, 121);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 17;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // labelNoCorresponde
            // 
            this.labelNoCorresponde.AutoSize = true;
            this.labelNoCorresponde.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNoCorresponde.Image = global::CRE.Presentacion.Properties.Resources.warning;
            this.labelNoCorresponde.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelNoCorresponde.Location = new System.Drawing.Point(83, 668);
            this.labelNoCorresponde.Name = "labelNoCorresponde";
            this.labelNoCorresponde.Size = new System.Drawing.Size(167, 20);
            this.labelNoCorresponde.TabIndex = 14;
            this.labelNoCorresponde.Text = "     No Le Corresponde";
            this.labelNoCorresponde.Visible = false;
            // 
            // btnSalirNoCorresponde
            // 
            this.btnSalirNoCorresponde.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalirNoCorresponde.BackgroundImage")));
            this.btnSalirNoCorresponde.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalirNoCorresponde.Location = new System.Drawing.Point(135, 691);
            this.btnSalirNoCorresponde.Name = "btnSalirNoCorresponde";
            this.btnSalirNoCorresponde.Size = new System.Drawing.Size(60, 50);
            this.btnSalirNoCorresponde.TabIndex = 18;
            this.btnSalirNoCorresponde.Text = "&Salir";
            this.btnSalirNoCorresponde.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalirNoCorresponde.UseVisualStyleBackColor = true;
            this.btnSalirNoCorresponde.Visible = false;
            // 
            // frmReporteMoraN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 779);
            this.Controls.Add(this.btnSalirNoCorresponde);
            this.Controls.Add(this.labelNoCorresponde);
            this.Controls.Add(this.groupBoxAdministrador);
            this.Controls.Add(this.groupBoxGerenteRegional);
            this.Controls.Add(this.groupBoxJefeOficina);
            this.Controls.Add(this.groupBoxAsesor);
            this.Controls.Add(this.groupBoxFecha);
            this.Name = "frmReporteMoraN";
            this.Text = "Reporte mora 1 a N días de atrazo";
            this.Controls.SetChildIndex(this.groupBoxFecha, 0);
            this.Controls.SetChildIndex(this.groupBoxAsesor, 0);
            this.Controls.SetChildIndex(this.groupBoxJefeOficina, 0);
            this.Controls.SetChildIndex(this.groupBoxGerenteRegional, 0);
            this.Controls.SetChildIndex(this.groupBoxAdministrador, 0);
            this.Controls.SetChildIndex(this.labelNoCorresponde, 0);
            this.Controls.SetChildIndex(this.btnSalirNoCorresponde, 0);
            this.groupBoxFecha.ResumeLayout(false);
            this.groupBoxFecha.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBaseDesde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBaseHasta)).EndInit();
            this.groupBoxAsesor.ResumeLayout(false);
            this.groupBoxJefeOficina.ResumeLayout(false);
            this.groupBoxJefeOficina.PerformLayout();
            this.groupBoxGerenteRegional.ResumeLayout(false);
            this.groupBoxGerenteRegional.PerformLayout();
            this.groupBoxAdministrador.ResumeLayout(false);
            this.groupBoxAdministrador.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxFecha;
        private GEN.ControlesBase.lblBase lblBase1;
        private System.Windows.Forms.GroupBox groupBoxAsesor;
        private System.Windows.Forms.GroupBox groupBoxJefeOficina;
        private System.Windows.Forms.GroupBox groupBoxGerenteRegional;
        private GEN.BotonesBase.btnImprimir btnImprimirAsesor;
        private GEN.BotonesBase.btnSalir btnSalir2;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.BotonesBase.btnImprimir btnImprimirOficina;
        private GEN.BotonesBase.btnSalir btnSalir3;
        private GEN.BotonesBase.btnSalir btnSalir4;
        private GEN.BotonesBase.btnImprimir btnImprimirGerenteRegional;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase3;
        private System.Windows.Forms.GroupBox groupBoxAdministrador;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.BotonesBase.btnImprimir btnImprimirAdministrador;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private System.Windows.Forms.Label labelNoCorresponde;
        private GEN.BotonesBase.btnSalir btnSalirNoCorresponde;
        private GEN.ControlesBase.cboPersonalCreditos cboPersonalCreditosJefeOficina;
        private GEN.ControlesBase.cboPersonalCreditos cboPersonalCreditosGerenteRegional;
        private GEN.ControlesBase.cboPersonalCreditos cboPersonalCreditosAdministrador;
        private GEN.ControlesBase.cboAgencias cboAgenciasGerenteRegional;
        private GEN.ControlesBase.cboAgencias cboAgenciasAdministrador;
        private GEN.ControlesBase.cboZona cboZonaAdministrador;
        private GEN.ControlesBase.chcBase chcBaseTodos;
        private GEN.ControlesBase.nudBase nudBaseDesde;
        private GEN.ControlesBase.nudBase nudBaseHasta;
        private GEN.ControlesBase.lblBase lblBase8;

    }
}