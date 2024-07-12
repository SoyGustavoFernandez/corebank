namespace RCP.Presentacion
{
    partial class frmMoraUbigeoRecuperador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMoraUbigeoRecuperador));
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.cboTipoDireccion = new GEN.ControlesBase.cboBase(this.components);
            this.cboTipoIntervCre1 = new GEN.ControlesBase.cboTipoIntervCre(this.components);
            this.conBusUbig1 = new GEN.ControlesBase.ConBusUbig();
            this.cboAnexo = new GEN.ControlesBase.cboUbigeo(this.components);
            this.cboDistrito = new GEN.ControlesBase.cboUbigeo(this.components);
            this.cboProvincia = new GEN.ControlesBase.cboUbigeo(this.components);
            this.cboDepartamento = new GEN.ControlesBase.cboUbigeo(this.components);
            this.cboPais = new GEN.ControlesBase.cboUbigeo(this.components);
            this.chcTodos = new GEN.ControlesBase.chcBase(this.components);
            this.btnProcesar = new GEN.BotonesBase.btnProcesar();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtMonIni = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtMonFin = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtAtrIni = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtAtrFin = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.chkRecuperadores = new GEN.ControlesBase.chklbBase(this.components);
            this.rbtnCatigados = new GEN.ControlesBase.rbtnBase(this.components);
            this.rbtnSinCastigo = new GEN.ControlesBase.rbtnBase(this.components);
            this.rbtnTodos = new GEN.ControlesBase.rbtnBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.conBusUbig1.SuspendLayout();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(459, 224);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 11;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(292, 18);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(113, 13);
            this.lblBase7.TabIndex = 37;
            this.lblBase7.Text = "Tipo Interviniente:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(292, 44);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(93, 13);
            this.lblBase6.TabIndex = 36;
            this.lblBase6.Text = "Tipo Dirección:";
            // 
            // cboTipoDireccion
            // 
            this.cboTipoDireccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoDireccion.FormattingEnabled = true;
            this.cboTipoDireccion.Location = new System.Drawing.Point(406, 40);
            this.cboTipoDireccion.Name = "cboTipoDireccion";
            this.cboTipoDireccion.Size = new System.Drawing.Size(121, 21);
            this.cboTipoDireccion.TabIndex = 8;
            // 
            // cboTipoIntervCre1
            // 
            this.cboTipoIntervCre1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoIntervCre1.FormattingEnabled = true;
            this.cboTipoIntervCre1.Location = new System.Drawing.Point(406, 14);
            this.cboTipoIntervCre1.Name = "cboTipoIntervCre1";
            this.cboTipoIntervCre1.Size = new System.Drawing.Size(121, 21);
            this.cboTipoIntervCre1.TabIndex = 7;
            // 
            // conBusUbig1
            // 
            this.conBusUbig1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.conBusUbig1.Controls.Add(this.cboAnexo);
            this.conBusUbig1.Controls.Add(this.cboDistrito);
            this.conBusUbig1.Controls.Add(this.cboProvincia);
            this.conBusUbig1.Controls.Add(this.cboDepartamento);
            this.conBusUbig1.Controls.Add(this.cboPais);
            this.conBusUbig1.Location = new System.Drawing.Point(295, 69);
            this.conBusUbig1.Name = "conBusUbig1";
            this.conBusUbig1.nIdNodo = 0;
            this.conBusUbig1.Size = new System.Drawing.Size(232, 106);
            this.conBusUbig1.TabIndex = 9;
            // 
            // cboAnexo
            // 
            this.cboAnexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnexo.FormattingEnabled = true;
            this.cboAnexo.Location = new System.Drawing.Point(103, 106);
            this.cboAnexo.Name = "cboAnexo";
            this.cboAnexo.Size = new System.Drawing.Size(121, 21);
            this.cboAnexo.TabIndex = 36;
            // 
            // cboDistrito
            // 
            this.cboDistrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDistrito.FormattingEnabled = true;
            this.cboDistrito.Location = new System.Drawing.Point(103, 81);
            this.cboDistrito.Name = "cboDistrito";
            this.cboDistrito.Size = new System.Drawing.Size(121, 21);
            this.cboDistrito.TabIndex = 3;
            // 
            // cboProvincia
            // 
            this.cboProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProvincia.FormattingEnabled = true;
            this.cboProvincia.Location = new System.Drawing.Point(103, 56);
            this.cboProvincia.Name = "cboProvincia";
            this.cboProvincia.Size = new System.Drawing.Size(121, 21);
            this.cboProvincia.TabIndex = 2;
            // 
            // cboDepartamento
            // 
            this.cboDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartamento.FormattingEnabled = true;
            this.cboDepartamento.Location = new System.Drawing.Point(103, 31);
            this.cboDepartamento.Name = "cboDepartamento";
            this.cboDepartamento.Size = new System.Drawing.Size(121, 21);
            this.cboDepartamento.TabIndex = 1;
            // 
            // cboPais
            // 
            this.cboPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPais.FormattingEnabled = true;
            this.cboPais.Location = new System.Drawing.Point(103, 6);
            this.cboPais.Name = "cboPais";
            this.cboPais.Size = new System.Drawing.Size(121, 21);
            this.cboPais.TabIndex = 0;
            // 
            // chcTodos
            // 
            this.chcTodos.AutoSize = true;
            this.chcTodos.Location = new System.Drawing.Point(14, 199);
            this.chcTodos.Name = "chcTodos";
            this.chcTodos.Size = new System.Drawing.Size(56, 17);
            this.chcTodos.TabIndex = 5;
            this.chcTodos.Text = "Todos";
            this.chcTodos.UseVisualStyleBackColor = true;
            this.chcTodos.CheckedChanged += new System.EventHandler(this.chcTodos_CheckedChanged);
            // 
            // btnProcesar
            // 
            this.btnProcesar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar.BackgroundImage")));
            this.btnProcesar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar.Location = new System.Drawing.Point(393, 224);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar.TabIndex = 10;
            this.btnProcesar.Text = "&Procesar";
            this.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(11, 68);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(103, 13);
            this.lblBase5.TabIndex = 30;
            this.lblBase5.Text = "Recuperador(es)";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(190, 44);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(14, 13);
            this.lblBase3.TabIndex = 28;
            this.lblBase3.Text = "a";
            // 
            // txtMonIni
            // 
            this.txtMonIni.Location = new System.Drawing.Point(134, 40);
            this.txtMonIni.Name = "txtMonIni";
            this.txtMonIni.Size = new System.Drawing.Size(54, 20);
            this.txtMonIni.TabIndex = 2;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(11, 44);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(123, 13);
            this.lblBase4.TabIndex = 27;
            this.lblBase4.Text = "Rango de Montos de";
            // 
            // txtMonFin
            // 
            this.txtMonFin.Location = new System.Drawing.Point(208, 40);
            this.txtMonFin.Name = "txtMonFin";
            this.txtMonFin.Size = new System.Drawing.Size(62, 20);
            this.txtMonFin.TabIndex = 3;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(190, 18);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(14, 13);
            this.lblBase2.TabIndex = 24;
            this.lblBase2.Text = "a";
            // 
            // txtAtrIni
            // 
            this.txtAtrIni.Location = new System.Drawing.Point(134, 14);
            this.txtAtrIni.Name = "txtAtrIni";
            this.txtAtrIni.Size = new System.Drawing.Size(54, 20);
            this.txtAtrIni.TabIndex = 0;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(11, 18);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(120, 13);
            this.lblBase1.TabIndex = 23;
            this.lblBase1.Text = "Rango de Atraso de";
            // 
            // txtAtrFin
            // 
            this.txtAtrFin.Location = new System.Drawing.Point(208, 14);
            this.txtAtrFin.Name = "txtAtrFin";
            this.txtAtrFin.Size = new System.Drawing.Size(62, 20);
            this.txtAtrFin.TabIndex = 1;
            // 
            // chkRecuperadores
            // 
            this.chkRecuperadores.FormattingEnabled = true;
            this.chkRecuperadores.Location = new System.Drawing.Point(14, 84);
            this.chkRecuperadores.Name = "chkRecuperadores";
            this.chkRecuperadores.Size = new System.Drawing.Size(256, 109);
            this.chkRecuperadores.TabIndex = 4;
            // 
            // rbtnCatigados
            // 
            this.rbtnCatigados.AutoSize = true;
            this.rbtnCatigados.Font = new System.Drawing.Font("Verdana", 8F);
            this.rbtnCatigados.ForeColor = System.Drawing.Color.Navy;
            this.rbtnCatigados.Location = new System.Drawing.Point(8, 13);
            this.rbtnCatigados.Name = "rbtnCatigados";
            this.rbtnCatigados.Size = new System.Drawing.Size(117, 17);
            this.rbtnCatigados.TabIndex = 0;
            this.rbtnCatigados.Text = "Sólo Castigados";
            this.rbtnCatigados.UseVisualStyleBackColor = true;
            this.rbtnCatigados.CheckedChanged += new System.EventHandler(this.rbtnCatigados_CheckedChanged);
            // 
            // rbtnSinCastigo
            // 
            this.rbtnSinCastigo.AutoSize = true;
            this.rbtnSinCastigo.Font = new System.Drawing.Font("Verdana", 8F);
            this.rbtnSinCastigo.ForeColor = System.Drawing.Color.Navy;
            this.rbtnSinCastigo.Location = new System.Drawing.Point(131, 13);
            this.rbtnSinCastigo.Name = "rbtnSinCastigo";
            this.rbtnSinCastigo.Size = new System.Drawing.Size(110, 17);
            this.rbtnSinCastigo.TabIndex = 1;
            this.rbtnSinCastigo.Text = "Sin Castigados";
            this.rbtnSinCastigo.UseVisualStyleBackColor = true;
            this.rbtnSinCastigo.CheckedChanged += new System.EventHandler(this.rbtnSinCastigo_CheckedChanged);
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.Checked = true;
            this.rbtnTodos.Font = new System.Drawing.Font("Verdana", 8F);
            this.rbtnTodos.ForeColor = System.Drawing.Color.Navy;
            this.rbtnTodos.Location = new System.Drawing.Point(247, 13);
            this.rbtnTodos.Name = "rbtnTodos";
            this.rbtnTodos.Size = new System.Drawing.Size(58, 17);
            this.rbtnTodos.TabIndex = 2;
            this.rbtnTodos.TabStop = true;
            this.rbtnTodos.Text = "Todos";
            this.rbtnTodos.UseVisualStyleBackColor = true;
            this.rbtnTodos.CheckedChanged += new System.EventHandler(this.rbtnTodos_CheckedChanged);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.rbtnCatigados);
            this.grbBase1.Controls.Add(this.rbtnTodos);
            this.grbBase1.Controls.Add(this.rbtnSinCastigo);
            this.grbBase1.Location = new System.Drawing.Point(14, 235);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(315, 39);
            this.grbBase1.TabIndex = 6;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Seleccionar";
            // 
            // frmMoraUbigeoRecuperador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 313);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.chkRecuperadores);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.cboTipoDireccion);
            this.Controls.Add(this.cboTipoIntervCre1);
            this.Controls.Add(this.conBusUbig1);
            this.Controls.Add(this.chcTodos);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.txtMonIni);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.txtMonFin);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.txtAtrIni);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.txtAtrFin);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.lblBase5);
            this.Name = "frmMoraUbigeoRecuperador";
            this.Text = "Reporte Mora por Ubigeo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.txtAtrFin, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.txtAtrIni, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.txtMonFin, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.txtMonIni, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.btnProcesar, 0);
            this.Controls.SetChildIndex(this.chcTodos, 0);
            this.Controls.SetChildIndex(this.conBusUbig1, 0);
            this.Controls.SetChildIndex(this.cboTipoIntervCre1, 0);
            this.Controls.SetChildIndex(this.cboTipoDireccion, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            this.Controls.SetChildIndex(this.chkRecuperadores, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.conBusUbig1.ResumeLayout(false);
            this.conBusUbig1.PerformLayout();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.cboBase cboTipoDireccion;
        private GEN.ControlesBase.cboTipoIntervCre cboTipoIntervCre1;
        private GEN.ControlesBase.ConBusUbig conBusUbig1;
        private GEN.ControlesBase.cboUbigeo cboAnexo;
        private GEN.ControlesBase.cboUbigeo cboDistrito;
        private GEN.ControlesBase.cboUbigeo cboProvincia;
        private GEN.ControlesBase.cboUbigeo cboDepartamento;
        private GEN.ControlesBase.cboUbigeo cboPais;
        private GEN.ControlesBase.chcBase chcTodos;
        private GEN.BotonesBase.btnProcesar btnProcesar;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtCBNumerosEnteros txtMonIni;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtCBNumerosEnteros txtMonFin;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtCBNumerosEnteros txtAtrIni;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtCBNumerosEnteros txtAtrFin;
        private GEN.ControlesBase.chklbBase chkRecuperadores;
        private GEN.ControlesBase.rbtnBase rbtnCatigados;
        private GEN.ControlesBase.rbtnBase rbtnSinCastigo;
        private GEN.ControlesBase.rbtnBase rbtnTodos;
        private GEN.ControlesBase.grbBase grbBase1;
    }
}

