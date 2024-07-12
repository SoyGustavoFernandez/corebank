namespace SER.Presentacion
{
    partial class frmEnvioMensajesTexto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEnvioMensajesTexto));
            this.txtNroCel = new GEN.ControlesBase.txtBase(this.components);
            this.txtMensaje = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.btnEnviar1 = new GEN.BotonesBase.btnEnviar();
            this.cboPuerto = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.btnMiniLogin1 = new GEN.BotonesBase.btnMiniLogin(this.components);
            this.btnMiniCancelEst1 = new GEN.BotonesBase.btnMiniCancelEst();
            this.dtgEnvio = new GEN.ControlesBase.dtgBase(this.components);
            this.btnExporExcel1 = new GEN.BotonesBase.btnExporExcel();
            this.cboTipoMensaje1 = new GEN.ControlesBase.cboTipoMensaje(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBaseCustom1 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.rbtIndividual = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtMasivo = new GEN.ControlesBase.rbtBase(this.components);
            this.btnEnvioIndividual = new System.Windows.Forms.Button();
            this.grbIndividual = new GEN.ControlesBase.grbBase(this.components);
            this.tTimer = new System.Windows.Forms.Timer(this.components);
            this.grbBar = new GEN.ControlesBase.grbBase(this.components);
            this.lblBarMessage = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.txtEnviados = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtNoEnviados = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtTOTAL = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEnvio)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.grbIndividual.SuspendLayout();
            this.grbBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNroCel
            // 
            this.txtNroCel.Location = new System.Drawing.Point(9, 23);
            this.txtNroCel.Name = "txtNroCel";
            this.txtNroCel.Size = new System.Drawing.Size(116, 20);
            this.txtNroCel.TabIndex = 2;
            // 
            // txtMensaje
            // 
            this.txtMensaje.Location = new System.Drawing.Point(13, 99);
            this.txtMensaje.MaxLength = 150;
            this.txtMensaje.Multiline = true;
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Size = new System.Drawing.Size(917, 49);
            this.txtMensaje.TabIndex = 3;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 7);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(76, 13);
            this.lblBase1.TabIndex = 4;
            this.lblBase1.Text = "Nro. Celular";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(10, 80);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(54, 13);
            this.lblBase2.TabIndex = 4;
            this.lblBase2.Text = "Mensaje";
            // 
            // btnEnviar1
            // 
            this.btnEnviar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEnviar1.BackgroundImage")));
            this.btnEnviar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEnviar1.Location = new System.Drawing.Point(870, 406);
            this.btnEnviar1.Name = "btnEnviar1";
            this.btnEnviar1.Size = new System.Drawing.Size(60, 50);
            this.btnEnviar1.TabIndex = 5;
            this.btnEnviar1.Text = "&Enviar";
            this.btnEnviar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnviar1.UseVisualStyleBackColor = true;
            this.btnEnviar1.Click += new System.EventHandler(this.btnEnviar1_Click);
            // 
            // cboPuerto
            // 
            this.cboPuerto.FormattingEnabled = true;
            this.cboPuerto.Location = new System.Drawing.Point(805, 41);
            this.cboPuerto.Name = "cboPuerto";
            this.cboPuerto.Size = new System.Drawing.Size(121, 21);
            this.cboPuerto.TabIndex = 6;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(750, 44);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(49, 13);
            this.lblBase3.TabIndex = 7;
            this.lblBase3.Text = "Puerto:";
            // 
            // btnMiniLogin1
            // 
            this.btnMiniLogin1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniLogin1.BackgroundImage")));
            this.btnMiniLogin1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniLogin1.Location = new System.Drawing.Point(890, 64);
            this.btnMiniLogin1.Name = "btnMiniLogin1";
            this.btnMiniLogin1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniLogin1.TabIndex = 8;
            this.btnMiniLogin1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniLogin1.UseVisualStyleBackColor = true;
            this.btnMiniLogin1.Click += new System.EventHandler(this.btnMiniLogin1_Click);
            // 
            // btnMiniCancelEst1
            // 
            this.btnMiniCancelEst1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniCancelEst1.BackgroundImage")));
            this.btnMiniCancelEst1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniCancelEst1.Location = new System.Drawing.Point(848, 64);
            this.btnMiniCancelEst1.Name = "btnMiniCancelEst1";
            this.btnMiniCancelEst1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniCancelEst1.TabIndex = 9;
            this.btnMiniCancelEst1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniCancelEst1.UseVisualStyleBackColor = true;
            this.btnMiniCancelEst1.Click += new System.EventHandler(this.btnMiniCancelEst1_Click);
            // 
            // dtgEnvio
            // 
            this.dtgEnvio.AllowUserToAddRows = false;
            this.dtgEnvio.AllowUserToDeleteRows = false;
            this.dtgEnvio.AllowUserToResizeColumns = false;
            this.dtgEnvio.AllowUserToResizeRows = false;
            this.dtgEnvio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgEnvio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEnvio.Location = new System.Drawing.Point(13, 152);
            this.dtgEnvio.MultiSelect = false;
            this.dtgEnvio.Name = "dtgEnvio";
            this.dtgEnvio.ReadOnly = true;
            this.dtgEnvio.RowHeadersVisible = false;
            this.dtgEnvio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgEnvio.Size = new System.Drawing.Size(917, 248);
            this.dtgEnvio.TabIndex = 10;
            // 
            // btnExporExcel1
            // 
            this.btnExporExcel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExporExcel1.BackgroundImage")));
            this.btnExporExcel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExporExcel1.Location = new System.Drawing.Point(804, 406);
            this.btnExporExcel1.Name = "btnExporExcel1";
            this.btnExporExcel1.Size = new System.Drawing.Size(60, 50);
            this.btnExporExcel1.TabIndex = 11;
            this.btnExporExcel1.Text = "E&xcel";
            this.btnExporExcel1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExporExcel1.UseVisualStyleBackColor = true;
            this.btnExporExcel1.Click += new System.EventHandler(this.btnExporExcel1_Click);
            // 
            // cboTipoMensaje1
            // 
            this.cboTipoMensaje1.FormattingEnabled = true;
            this.cboTipoMensaje1.Location = new System.Drawing.Point(16, 57);
            this.cboTipoMensaje1.Name = "cboTipoMensaje1";
            this.cboTipoMensaje1.Size = new System.Drawing.Size(121, 21);
            this.cboTipoMensaje1.TabIndex = 12;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(13, 41);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(87, 13);
            this.lblBase4.TabIndex = 13;
            this.lblBase4.Text = "Tipo Mensaje:";
            // 
            // lblBaseCustom1
            // 
            this.lblBaseCustom1.AutoSize = true;
            this.lblBaseCustom1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBaseCustom1.ForeColor = System.Drawing.Color.Red;
            this.lblBaseCustom1.Location = new System.Drawing.Point(60, 81);
            this.lblBaseCustom1.Name = "lblBaseCustom1";
            this.lblBaseCustom1.Size = new System.Drawing.Size(442, 13);
            this.lblBaseCustom1.TabIndex = 14;
            this.lblBaseCustom1.Text = "El caracter (&&)  se reemplazara por el Nombre, (Máximo de caracteres 150)";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(4, 10);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(586, 23);
            this.progressBar1.TabIndex = 15;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.rbtIndividual);
            this.grbBase1.Controls.Add(this.rbtMasivo);
            this.grbBase1.Location = new System.Drawing.Point(16, -3);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(269, 33);
            this.grbBase1.TabIndex = 16;
            this.grbBase1.TabStop = false;
            // 
            // rbtIndividual
            // 
            this.rbtIndividual.AutoSize = true;
            this.rbtIndividual.ForeColor = System.Drawing.Color.Navy;
            this.rbtIndividual.Location = new System.Drawing.Point(114, 10);
            this.rbtIndividual.Name = "rbtIndividual";
            this.rbtIndividual.Size = new System.Drawing.Size(113, 17);
            this.rbtIndividual.TabIndex = 18;
            this.rbtIndividual.TabStop = true;
            this.rbtIndividual.Text = "Mensaje Individual";
            this.rbtIndividual.UseVisualStyleBackColor = true;
            this.rbtIndividual.CheckedChanged += new System.EventHandler(this.rbtBase2_CheckedChanged);
            // 
            // rbtMasivo
            // 
            this.rbtMasivo.AutoSize = true;
            this.rbtMasivo.ForeColor = System.Drawing.Color.Navy;
            this.rbtMasivo.Location = new System.Drawing.Point(6, 10);
            this.rbtMasivo.Name = "rbtMasivo";
            this.rbtMasivo.Size = new System.Drawing.Size(102, 17);
            this.rbtMasivo.TabIndex = 17;
            this.rbtMasivo.TabStop = true;
            this.rbtMasivo.Text = "Mensaje Masivo";
            this.rbtMasivo.UseVisualStyleBackColor = true;
            this.rbtMasivo.CheckedChanged += new System.EventHandler(this.rbtMasivo_CheckedChanged);
            // 
            // btnEnvioIndividual
            // 
            this.btnEnvioIndividual.Location = new System.Drawing.Point(131, 21);
            this.btnEnvioIndividual.Name = "btnEnvioIndividual";
            this.btnEnvioIndividual.Size = new System.Drawing.Size(49, 23);
            this.btnEnvioIndividual.TabIndex = 17;
            this.btnEnvioIndividual.Text = "Enviar";
            this.btnEnvioIndividual.UseVisualStyleBackColor = true;
            this.btnEnvioIndividual.Click += new System.EventHandler(this.btnEnvioIndividual_Click);
            // 
            // grbIndividual
            // 
            this.grbIndividual.Controls.Add(this.lblBase1);
            this.grbIndividual.Controls.Add(this.btnEnvioIndividual);
            this.grbIndividual.Controls.Add(this.txtNroCel);
            this.grbIndividual.Location = new System.Drawing.Point(142, 34);
            this.grbIndividual.Name = "grbIndividual";
            this.grbIndividual.Size = new System.Drawing.Size(200, 48);
            this.grbIndividual.TabIndex = 18;
            this.grbIndividual.TabStop = false;
            // 
            // tTimer
            // 
            this.tTimer.Tick += new System.EventHandler(this.tTimer_Tick);
            // 
            // grbBar
            // 
            this.grbBar.Controls.Add(this.lblBarMessage);
            this.grbBar.Controls.Add(this.progressBar1);
            this.grbBar.Location = new System.Drawing.Point(13, 407);
            this.grbBar.Name = "grbBar";
            this.grbBar.Size = new System.Drawing.Size(596, 49);
            this.grbBar.TabIndex = 19;
            this.grbBar.TabStop = false;
            // 
            // lblBarMessage
            // 
            this.lblBarMessage.AutoSize = true;
            this.lblBarMessage.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBarMessage.ForeColor = System.Drawing.Color.Navy;
            this.lblBarMessage.Location = new System.Drawing.Point(353, 35);
            this.lblBarMessage.Name = "lblBarMessage";
            this.lblBarMessage.Size = new System.Drawing.Size(0, 13);
            this.lblBarMessage.TabIndex = 16;
            // 
            // txtEnviados
            // 
            this.txtEnviados.Enabled = false;
            this.txtEnviados.Location = new System.Drawing.Point(703, 406);
            this.txtEnviados.Name = "txtEnviados";
            this.txtEnviados.Size = new System.Drawing.Size(87, 20);
            this.txtEnviados.TabIndex = 20;
            // 
            // txtNoEnviados
            // 
            this.txtNoEnviados.Enabled = false;
            this.txtNoEnviados.Location = new System.Drawing.Point(703, 428);
            this.txtNoEnviados.Name = "txtNoEnviados";
            this.txtNoEnviados.Size = new System.Drawing.Size(87, 20);
            this.txtNoEnviados.TabIndex = 21;
            // 
            // txtTOTAL
            // 
            this.txtTOTAL.Enabled = false;
            this.txtTOTAL.Location = new System.Drawing.Point(703, 450);
            this.txtTOTAL.Name = "txtTOTAL";
            this.txtTOTAL.Size = new System.Drawing.Size(87, 20);
            this.txtTOTAL.TabIndex = 22;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(634, 409);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(63, 13);
            this.lblBase5.TabIndex = 23;
            this.lblBase5.Text = "Enviados:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(615, 431);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(82, 13);
            this.lblBase6.TabIndex = 24;
            this.lblBase6.Text = "No Enviados:";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(649, 453);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(48, 13);
            this.lblBase7.TabIndex = 25;
            this.lblBase7.Text = "TOTAL:";
            // 
            // frmEnvioMensajesTexto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 503);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.txtTOTAL);
            this.Controls.Add(this.txtNoEnviados);
            this.Controls.Add(this.txtEnviados);
            this.Controls.Add(this.grbBar);
            this.Controls.Add(this.grbIndividual);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.lblBaseCustom1);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.cboTipoMensaje1);
            this.Controls.Add(this.btnExporExcel1);
            this.Controls.Add(this.dtgEnvio);
            this.Controls.Add(this.btnMiniCancelEst1);
            this.Controls.Add(this.btnMiniLogin1);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.cboPuerto);
            this.Controls.Add(this.btnEnviar1);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.txtMensaje);
            this.Name = "frmEnvioMensajesTexto";
            this.Text = "Envio Mensaje Texto";
            this.Load += new System.EventHandler(this.frmEnvioMensajesTexto_Load);
            this.Controls.SetChildIndex(this.txtMensaje, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.btnEnviar1, 0);
            this.Controls.SetChildIndex(this.cboPuerto, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.btnMiniLogin1, 0);
            this.Controls.SetChildIndex(this.btnMiniCancelEst1, 0);
            this.Controls.SetChildIndex(this.dtgEnvio, 0);
            this.Controls.SetChildIndex(this.btnExporExcel1, 0);
            this.Controls.SetChildIndex(this.cboTipoMensaje1, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.lblBaseCustom1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbIndividual, 0);
            this.Controls.SetChildIndex(this.grbBar, 0);
            this.Controls.SetChildIndex(this.txtEnviados, 0);
            this.Controls.SetChildIndex(this.txtNoEnviados, 0);
            this.Controls.SetChildIndex(this.txtTOTAL, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgEnvio)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbIndividual.ResumeLayout(false);
            this.grbIndividual.PerformLayout();
            this.grbBar.ResumeLayout(false);
            this.grbBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.txtBase txtNroCel;
        private GEN.ControlesBase.txtBase txtMensaje;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.BotonesBase.btnEnviar btnEnviar1;
        private GEN.ControlesBase.cboBase cboPuerto;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.BotonesBase.btnMiniLogin btnMiniLogin1;
        private GEN.BotonesBase.btnMiniCancelEst btnMiniCancelEst1;
        private GEN.ControlesBase.dtgBase dtgEnvio;
        private GEN.BotonesBase.btnExporExcel btnExporExcel1;
        private GEN.ControlesBase.cboTipoMensaje cboTipoMensaje1;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBaseCustom lblBaseCustom1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.rbtBase rbtIndividual;
        private GEN.ControlesBase.rbtBase rbtMasivo;
        private System.Windows.Forms.Button btnEnvioIndividual;
        private GEN.ControlesBase.grbBase grbIndividual;
        private System.Windows.Forms.Timer tTimer;
        private GEN.ControlesBase.grbBase grbBar;
        private GEN.ControlesBase.lblBaseCustom lblBarMessage;
        private GEN.ControlesBase.txtCBNumerosEnteros txtEnviados;
        private GEN.ControlesBase.txtCBNumerosEnteros txtNoEnviados;
        private GEN.ControlesBase.txtCBNumerosEnteros txtTOTAL;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase7;
    }
}