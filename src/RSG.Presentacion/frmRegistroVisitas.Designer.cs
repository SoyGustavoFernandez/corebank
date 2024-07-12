namespace RSG.Presentacion
{
    partial class frmRegistroVisitas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistroVisitas));
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.conBusCli1 = new GEN.ControlesBase.ConBusCli();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.dtpVisita = new GEN.ControlesBase.dtpCorto(this.components);
            this.cboTipoOperacionRiesgos1 = new GEN.ControlesBase.cboTipoOperacionRiesgos(this.components);
            this.cboResultadoVisitaRiesgos1 = new GEN.ControlesBase.cboResultadoVisitaRiesgos(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.lblBase14 = new GEN.ControlesBase.lblBase();
            this.lblBase15 = new GEN.ControlesBase.lblBase();
            this.cboRelacionAsesor = new GEN.ControlesBase.cboVisitaEscala(this.components);
            this.rbtnConoceAsesSi = new GEN.ControlesBase.rbtnBase(this.components);
            this.rbtnConoceAsesNo = new GEN.ControlesBase.rbtnBase(this.components);
            this.cboEntornoFamilia = new GEN.ControlesBase.cboVisitaEscala(this.components);
            this.cboEntornoTrabajo = new GEN.ControlesBase.cboVisitaEscala(this.components);
            this.cboReferencias = new GEN.ControlesBase.cboVisitaEscala(this.components);
            this.cboTipoVerificacionAsesor1 = new GEN.ControlesBase.cboTipoVerificacionAsesor(this.components);
            this.cboTipoVerificaAutonomia1 = new GEN.ControlesBase.cboTipoVerificaAutonomia(this.components);
            this.cboTipoRiesgoOperacional1 = new GEN.ControlesBase.cboTipoRiesgoOperacional(this.components);
            this.cboMotivoMoraRiesgos1 = new GEN.ControlesBase.cboMotivoMoraRiesgos(this.components);
            this.cboUbicaVisitaNegocio = new GEN.ControlesBase.cboUbicaVisita(this.components);
            this.cboUbicaVisitaCliente = new GEN.ControlesBase.cboUbicaVisita(this.components);
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(649, 313);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 19;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Location = new System.Drawing.Point(450, 313);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 20;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(584, 313);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 18;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(518, 313);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 21;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // conBusCli1
            // 
            this.conBusCli1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli1.idCli = 0;
            this.conBusCli1.Location = new System.Drawing.Point(12, 12);
            this.conBusCli1.Name = "conBusCli1";
            this.conBusCli1.Size = new System.Drawing.Size(532, 105);
            this.conBusCli1.TabIndex = 0;
            this.conBusCli1.ClicBuscar += new System.EventHandler(this.conBusCli1_ClicBuscar);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(412, 127);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(98, 13);
            this.lblBase2.TabIndex = 10;
            this.lblBase2.Text = "Tipo Operación:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(29, 150);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(121, 13);
            this.lblBase3.TabIndex = 10;
            this.lblBase3.Text = "Resultado de Visita:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(52, 127);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(98, 13);
            this.lblBase4.TabIndex = 9;
            this.lblBase4.Text = "Fecha de Visita:";
            // 
            // dtpVisita
            // 
            this.dtpVisita.Location = new System.Drawing.Point(159, 124);
            this.dtpVisita.Name = "dtpVisita";
            this.dtpVisita.Size = new System.Drawing.Size(150, 20);
            this.dtpVisita.TabIndex = 1;
            // 
            // cboTipoOperacionRiesgos1
            // 
            this.cboTipoOperacionRiesgos1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoOperacionRiesgos1.FormattingEnabled = true;
            this.cboTipoOperacionRiesgos1.Location = new System.Drawing.Point(516, 124);
            this.cboTipoOperacionRiesgos1.Name = "cboTipoOperacionRiesgos1";
            this.cboTipoOperacionRiesgos1.Size = new System.Drawing.Size(191, 21);
            this.cboTipoOperacionRiesgos1.TabIndex = 2;
            // 
            // cboResultadoVisitaRiesgos1
            // 
            this.cboResultadoVisitaRiesgos1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboResultadoVisitaRiesgos1.FormattingEnabled = true;
            this.cboResultadoVisitaRiesgos1.Location = new System.Drawing.Point(159, 147);
            this.cboResultadoVisitaRiesgos1.Name = "cboResultadoVisitaRiesgos1";
            this.cboResultadoVisitaRiesgos1.Size = new System.Drawing.Size(191, 21);
            this.cboResultadoVisitaRiesgos1.TabIndex = 3;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(399, 151);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(111, 13);
            this.lblBase1.TabIndex = 10;
            this.lblBase1.Text = "Conoce al asesor:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(9, 176);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(141, 13);
            this.lblBase5.TabIndex = 10;
            this.lblBase5.Text = "Relación con el Asesor:";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(406, 176);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(104, 13);
            this.lblBase7.TabIndex = 10;
            this.lblBase7.Text = "Entorno Familiar:";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(29, 202);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(121, 13);
            this.lblBase8.TabIndex = 10;
            this.lblBase8.Text = "Entorno de Trabajo:";
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(431, 202);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(79, 13);
            this.lblBase9.TabIndex = 10;
            this.lblBase9.Text = "Referencias:";
            // 
            // lblBase10
            // 
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(12, 222);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(138, 29);
            this.lblBase10.TabIndex = 10;
            this.lblBase10.Text = "Verificación del Negocio por Asesor:";
            this.lblBase10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBase11
            // 
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(372, 222);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(138, 30);
            this.lblBase11.TabIndex = 17;
            this.lblBase11.Text = "Verificación del Nivel de Autonomía:";
            this.lblBase11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(28, 256);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(122, 13);
            this.lblBase12.TabIndex = 18;
            this.lblBase12.Text = "Riesgo Operacional:";
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(411, 256);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(99, 13);
            this.lblBase13.TabIndex = 19;
            this.lblBase13.Text = "Motivo de Mora:";
            // 
            // lblBase14
            // 
            this.lblBase14.AutoSize = true;
            this.lblBase14.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase14.ForeColor = System.Drawing.Color.Navy;
            this.lblBase14.Location = new System.Drawing.Point(1, 281);
            this.lblBase14.Name = "lblBase14";
            this.lblBase14.Size = new System.Drawing.Size(149, 13);
            this.lblBase14.TabIndex = 20;
            this.lblBase14.Text = "Ubicabilidad del negocio:";
            // 
            // lblBase15
            // 
            this.lblBase15.AutoSize = true;
            this.lblBase15.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase15.ForeColor = System.Drawing.Color.Navy;
            this.lblBase15.Location = new System.Drawing.Point(368, 281);
            this.lblBase15.Name = "lblBase15";
            this.lblBase15.Size = new System.Drawing.Size(142, 13);
            this.lblBase15.TabIndex = 21;
            this.lblBase15.Text = "Ubicabilidad del cliente:";
            // 
            // cboRelacionAsesor
            // 
            this.cboRelacionAsesor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRelacionAsesor.FormattingEnabled = true;
            this.cboRelacionAsesor.Location = new System.Drawing.Point(159, 172);
            this.cboRelacionAsesor.Name = "cboRelacionAsesor";
            this.cboRelacionAsesor.Size = new System.Drawing.Size(191, 21);
            this.cboRelacionAsesor.TabIndex = 6;
            // 
            // rbtnConoceAsesSi
            // 
            this.rbtnConoceAsesSi.AutoSize = true;
            this.rbtnConoceAsesSi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtnConoceAsesSi.Location = new System.Drawing.Point(519, 149);
            this.rbtnConoceAsesSi.Name = "rbtnConoceAsesSi";
            this.rbtnConoceAsesSi.Size = new System.Drawing.Size(36, 17);
            this.rbtnConoceAsesSi.TabIndex = 4;
            this.rbtnConoceAsesSi.TabStop = true;
            this.rbtnConoceAsesSi.Text = "Sí";
            this.rbtnConoceAsesSi.UseVisualStyleBackColor = true;
            // 
            // rbtnConoceAsesNo
            // 
            this.rbtnConoceAsesNo.AutoSize = true;
            this.rbtnConoceAsesNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtnConoceAsesNo.Location = new System.Drawing.Point(561, 149);
            this.rbtnConoceAsesNo.Name = "rbtnConoceAsesNo";
            this.rbtnConoceAsesNo.Size = new System.Drawing.Size(39, 17);
            this.rbtnConoceAsesNo.TabIndex = 5;
            this.rbtnConoceAsesNo.TabStop = true;
            this.rbtnConoceAsesNo.Text = "No";
            this.rbtnConoceAsesNo.UseVisualStyleBackColor = true;
            // 
            // cboEntornoFamilia
            // 
            this.cboEntornoFamilia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEntornoFamilia.FormattingEnabled = true;
            this.cboEntornoFamilia.Location = new System.Drawing.Point(516, 172);
            this.cboEntornoFamilia.Name = "cboEntornoFamilia";
            this.cboEntornoFamilia.Size = new System.Drawing.Size(191, 21);
            this.cboEntornoFamilia.TabIndex = 7;
            // 
            // cboEntornoTrabajo
            // 
            this.cboEntornoTrabajo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEntornoTrabajo.FormattingEnabled = true;
            this.cboEntornoTrabajo.Location = new System.Drawing.Point(159, 198);
            this.cboEntornoTrabajo.Name = "cboEntornoTrabajo";
            this.cboEntornoTrabajo.Size = new System.Drawing.Size(191, 21);
            this.cboEntornoTrabajo.TabIndex = 8;
            // 
            // cboReferencias
            // 
            this.cboReferencias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReferencias.FormattingEnabled = true;
            this.cboReferencias.Location = new System.Drawing.Point(516, 199);
            this.cboReferencias.Name = "cboReferencias";
            this.cboReferencias.Size = new System.Drawing.Size(191, 21);
            this.cboReferencias.TabIndex = 9;
            // 
            // cboTipoVerificacionAsesor1
            // 
            this.cboTipoVerificacionAsesor1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoVerificacionAsesor1.FormattingEnabled = true;
            this.cboTipoVerificacionAsesor1.Location = new System.Drawing.Point(159, 225);
            this.cboTipoVerificacionAsesor1.Name = "cboTipoVerificacionAsesor1";
            this.cboTipoVerificacionAsesor1.Size = new System.Drawing.Size(191, 21);
            this.cboTipoVerificacionAsesor1.TabIndex = 10;
            // 
            // cboTipoVerificaAutonomia1
            // 
            this.cboTipoVerificaAutonomia1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoVerificaAutonomia1.FormattingEnabled = true;
            this.cboTipoVerificaAutonomia1.Location = new System.Drawing.Point(516, 225);
            this.cboTipoVerificaAutonomia1.Name = "cboTipoVerificaAutonomia1";
            this.cboTipoVerificaAutonomia1.Size = new System.Drawing.Size(191, 21);
            this.cboTipoVerificaAutonomia1.TabIndex = 11;
            // 
            // cboTipoRiesgoOperacional1
            // 
            this.cboTipoRiesgoOperacional1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoRiesgoOperacional1.FormattingEnabled = true;
            this.cboTipoRiesgoOperacional1.Location = new System.Drawing.Point(159, 252);
            this.cboTipoRiesgoOperacional1.Name = "cboTipoRiesgoOperacional1";
            this.cboTipoRiesgoOperacional1.Size = new System.Drawing.Size(191, 21);
            this.cboTipoRiesgoOperacional1.TabIndex = 12;
            // 
            // cboMotivoMoraRiesgos1
            // 
            this.cboMotivoMoraRiesgos1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMotivoMoraRiesgos1.FormattingEnabled = true;
            this.cboMotivoMoraRiesgos1.Location = new System.Drawing.Point(516, 252);
            this.cboMotivoMoraRiesgos1.Name = "cboMotivoMoraRiesgos1";
            this.cboMotivoMoraRiesgos1.Size = new System.Drawing.Size(191, 21);
            this.cboMotivoMoraRiesgos1.TabIndex = 13;
            // 
            // cboUbicaVisitaNegocio
            // 
            this.cboUbicaVisitaNegocio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUbicaVisitaNegocio.FormattingEnabled = true;
            this.cboUbicaVisitaNegocio.Location = new System.Drawing.Point(159, 278);
            this.cboUbicaVisitaNegocio.Name = "cboUbicaVisitaNegocio";
            this.cboUbicaVisitaNegocio.Size = new System.Drawing.Size(191, 21);
            this.cboUbicaVisitaNegocio.TabIndex = 14;
            // 
            // cboUbicaVisitaCliente
            // 
            this.cboUbicaVisitaCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUbicaVisitaCliente.FormattingEnabled = true;
            this.cboUbicaVisitaCliente.Location = new System.Drawing.Point(516, 278);
            this.cboUbicaVisitaCliente.Name = "cboUbicaVisitaCliente";
            this.cboUbicaVisitaCliente.Size = new System.Drawing.Size(191, 21);
            this.cboUbicaVisitaCliente.TabIndex = 15;
            // 
            // frmRegistroVisitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 392);
            this.Controls.Add(this.cboUbicaVisitaCliente);
            this.Controls.Add(this.cboUbicaVisitaNegocio);
            this.Controls.Add(this.cboMotivoMoraRiesgos1);
            this.Controls.Add(this.cboTipoRiesgoOperacional1);
            this.Controls.Add(this.cboTipoVerificaAutonomia1);
            this.Controls.Add(this.cboTipoVerificacionAsesor1);
            this.Controls.Add(this.rbtnConoceAsesNo);
            this.Controls.Add(this.rbtnConoceAsesSi);
            this.Controls.Add(this.cboEntornoFamilia);
            this.Controls.Add(this.cboReferencias);
            this.Controls.Add(this.cboEntornoTrabajo);
            this.Controls.Add(this.cboRelacionAsesor);
            this.Controls.Add(this.lblBase15);
            this.Controls.Add(this.lblBase14);
            this.Controls.Add(this.lblBase13);
            this.Controls.Add(this.lblBase12);
            this.Controls.Add(this.lblBase11);
            this.Controls.Add(this.cboResultadoVisitaRiesgos1);
            this.Controls.Add(this.cboTipoOperacionRiesgos1);
            this.Controls.Add(this.dtpVisita);
            this.Controls.Add(this.lblBase10);
            this.Controls.Add(this.lblBase9);
            this.Controls.Add(this.lblBase8);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.conBusCli1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmRegistroVisitas";
            this.Text = "Registro visitas";
            this.Load += new System.EventHandler(this.frmBase_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.conBusCli1, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            this.Controls.SetChildIndex(this.lblBase8, 0);
            this.Controls.SetChildIndex(this.lblBase9, 0);
            this.Controls.SetChildIndex(this.lblBase10, 0);
            this.Controls.SetChildIndex(this.dtpVisita, 0);
            this.Controls.SetChildIndex(this.cboTipoOperacionRiesgos1, 0);
            this.Controls.SetChildIndex(this.cboResultadoVisitaRiesgos1, 0);
            this.Controls.SetChildIndex(this.lblBase11, 0);
            this.Controls.SetChildIndex(this.lblBase12, 0);
            this.Controls.SetChildIndex(this.lblBase13, 0);
            this.Controls.SetChildIndex(this.lblBase14, 0);
            this.Controls.SetChildIndex(this.lblBase15, 0);
            this.Controls.SetChildIndex(this.cboRelacionAsesor, 0);
            this.Controls.SetChildIndex(this.cboEntornoTrabajo, 0);
            this.Controls.SetChildIndex(this.cboReferencias, 0);
            this.Controls.SetChildIndex(this.cboEntornoFamilia, 0);
            this.Controls.SetChildIndex(this.rbtnConoceAsesSi, 0);
            this.Controls.SetChildIndex(this.rbtnConoceAsesNo, 0);
            this.Controls.SetChildIndex(this.cboTipoVerificacionAsesor1, 0);
            this.Controls.SetChildIndex(this.cboTipoVerificaAutonomia1, 0);
            this.Controls.SetChildIndex(this.cboTipoRiesgoOperacional1, 0);
            this.Controls.SetChildIndex(this.cboMotivoMoraRiesgos1, 0);
            this.Controls.SetChildIndex(this.cboUbicaVisitaNegocio, 0);
            this.Controls.SetChildIndex(this.cboUbicaVisitaCliente, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.ConBusCli conBusCli1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.dtpCorto dtpVisita;
        private GEN.ControlesBase.cboTipoOperacionRiesgos cboTipoOperacionRiesgos1;
        private GEN.ControlesBase.cboResultadoVisitaRiesgos cboResultadoVisitaRiesgos1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.lblBase lblBase13;
        private GEN.ControlesBase.lblBase lblBase14;
        private GEN.ControlesBase.lblBase lblBase15;
        private GEN.ControlesBase.cboVisitaEscala cboRelacionAsesor;
        private GEN.ControlesBase.rbtnBase rbtnConoceAsesSi;
        private GEN.ControlesBase.rbtnBase rbtnConoceAsesNo;
        private GEN.ControlesBase.cboVisitaEscala cboEntornoFamilia;
        private GEN.ControlesBase.cboVisitaEscala cboEntornoTrabajo;
        private GEN.ControlesBase.cboVisitaEscala cboReferencias;
        private GEN.ControlesBase.cboTipoVerificacionAsesor cboTipoVerificacionAsesor1;
        private GEN.ControlesBase.cboTipoVerificaAutonomia cboTipoVerificaAutonomia1;
        private GEN.ControlesBase.cboTipoRiesgoOperacional cboTipoRiesgoOperacional1;
        private GEN.ControlesBase.cboMotivoMoraRiesgos cboMotivoMoraRiesgos1;
        private GEN.ControlesBase.cboUbicaVisita cboUbicaVisitaNegocio;
        private GEN.ControlesBase.cboUbicaVisita cboUbicaVisitaCliente;
    }
}

