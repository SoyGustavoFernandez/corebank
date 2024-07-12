namespace CRE.Presentacion
{
    partial class frmOfertasClientesExclusivos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOfertasClientesExclusivos));
            this.conBusCli1 = new GEN.ControlesBase.ConBusCli();
            this.lblTipoClienteExclusivo = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblFrecuencia = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.pnlTieneOferta = new System.Windows.Forms.Panel();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.grbListaOfertas = new GEN.ControlesBase.grbBase(this.components);
            this.pnlListaOferta = new System.Windows.Forms.Panel();
            this.flpListaOfertaCliente = new System.Windows.Forms.FlowLayoutPanel();
            this.lblBaseCustom1 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.tbcOpcionBusqueda = new GEN.ControlesBase.tbcBase(this.components);
            this.tabBusquedaDNI = new System.Windows.Forms.TabPage();
            this.conBusPersona = new GEN.ControlesBase.ConBusPersona();
            this.tabBusquedaCliente = new System.Windows.Forms.TabPage();
            this.btnRegInfCli = new GEN.BotonesBase.btnBlanco();
            this.pnlTieneOferta.SuspendLayout();
            this.grbListaOfertas.SuspendLayout();
            this.pnlListaOferta.SuspendLayout();
            this.tbcOpcionBusqueda.SuspendLayout();
            this.tabBusquedaDNI.SuspendLayout();
            this.tabBusquedaCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // conBusCli1
            // 
            this.conBusCli1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli1.idCli = 0;
            this.conBusCli1.Location = new System.Drawing.Point(99, 3);
            this.conBusCli1.Name = "conBusCli1";
            this.conBusCli1.Size = new System.Drawing.Size(532, 111);
            this.conBusCli1.TabIndex = 2;
            this.conBusCli1.ClicBuscar += new System.EventHandler(this.conBusCli1_ClicBuscar);
            // 
            // lblTipoClienteExclusivo
            // 
            this.lblTipoClienteExclusivo.AutoSize = true;
            this.lblTipoClienteExclusivo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.lblTipoClienteExclusivo.ForeColor = System.Drawing.Color.Navy;
            this.lblTipoClienteExclusivo.Location = new System.Drawing.Point(106, 7);
            this.lblTipoClienteExclusivo.Name = "lblTipoClienteExclusivo";
            this.lblTipoClienteExclusivo.Size = new System.Drawing.Size(187, 18);
            this.lblTipoClienteExclusivo.TabIndex = 3;
            this.lblTipoClienteExclusivo.Text = "Q\'ORY - APROBADO";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(12, 34);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(73, 13);
            this.lblBase3.TabIndex = 11;
            this.lblBase3.Text = "Frecuencia:";
            // 
            // lblFrecuencia
            // 
            this.lblFrecuencia.AutoSize = true;
            this.lblFrecuencia.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.lblFrecuencia.ForeColor = System.Drawing.Color.Navy;
            this.lblFrecuencia.Location = new System.Drawing.Point(106, 30);
            this.lblFrecuencia.Name = "lblFrecuencia";
            this.lblFrecuencia.Size = new System.Drawing.Size(125, 18);
            this.lblFrecuencia.TabIndex = 10;
            this.lblFrecuencia.Text = "TRIMESTRAL";
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(649, 470);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 13;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(583, 470);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 14;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // pnlTieneOferta
            // 
            this.pnlTieneOferta.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlTieneOferta.Controls.Add(this.lblBase1);
            this.pnlTieneOferta.Controls.Add(this.grbListaOfertas);
            this.pnlTieneOferta.Controls.Add(this.lblBase3);
            this.pnlTieneOferta.Controls.Add(this.lblFrecuencia);
            this.pnlTieneOferta.Controls.Add(this.lblTipoClienteExclusivo);
            this.pnlTieneOferta.Location = new System.Drawing.Point(9, 154);
            this.pnlTieneOferta.Name = "pnlTieneOferta";
            this.pnlTieneOferta.Size = new System.Drawing.Size(720, 310);
            this.pnlTieneOferta.TabIndex = 15;
            this.pnlTieneOferta.Visible = false;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 10);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(47, 13);
            this.lblBase1.TabIndex = 18;
            this.lblBase1.Text = "Grupo:";
            // 
            // grbListaOfertas
            // 
            this.grbListaOfertas.Controls.Add(this.pnlListaOferta);
            this.grbListaOfertas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grbListaOfertas.Location = new System.Drawing.Point(0, 79);
            this.grbListaOfertas.Name = "grbListaOfertas";
            this.grbListaOfertas.Size = new System.Drawing.Size(720, 231);
            this.grbListaOfertas.TabIndex = 17;
            this.grbListaOfertas.TabStop = false;
            // 
            // pnlListaOferta
            // 
            this.pnlListaOferta.AutoScroll = true;
            this.pnlListaOferta.Controls.Add(this.flpListaOfertaCliente);
            this.pnlListaOferta.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlListaOferta.Location = new System.Drawing.Point(3, 8);
            this.pnlListaOferta.Name = "pnlListaOferta";
            this.pnlListaOferta.Size = new System.Drawing.Size(714, 220);
            this.pnlListaOferta.TabIndex = 18;
            // 
            // flpListaOfertaCliente
            // 
            this.flpListaOfertaCliente.AutoScroll = true;
            this.flpListaOfertaCliente.AutoSize = true;
            this.flpListaOfertaCliente.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.flpListaOfertaCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpListaOfertaCliente.Location = new System.Drawing.Point(0, 0);
            this.flpListaOfertaCliente.Name = "flpListaOfertaCliente";
            this.flpListaOfertaCliente.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.flpListaOfertaCliente.Size = new System.Drawing.Size(714, 220);
            this.flpListaOfertaCliente.TabIndex = 0;
            this.flpListaOfertaCliente.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.flpListaOfertaCliente_ControlAdded);
            // 
            // lblBaseCustom1
            // 
            this.lblBaseCustom1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblBaseCustom1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.lblBaseCustom1.ForeColor = System.Drawing.Color.Navy;
            this.lblBaseCustom1.Location = new System.Drawing.Point(176, 218);
            this.lblBaseCustom1.Name = "lblBaseCustom1";
            this.lblBaseCustom1.Size = new System.Drawing.Size(368, 157);
            this.lblBaseCustom1.TabIndex = 16;
            this.lblBaseCustom1.Text = "Cliente no tiene ninguna oferta.";
            this.lblBaseCustom1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBaseCustom1.Visible = false;
            // 
            // tbcOpcionBusqueda
            // 
            this.tbcOpcionBusqueda.Controls.Add(this.tabBusquedaDNI);
            this.tbcOpcionBusqueda.Controls.Add(this.tabBusquedaCliente);
            this.tbcOpcionBusqueda.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbcOpcionBusqueda.Location = new System.Drawing.Point(0, 0);
            this.tbcOpcionBusqueda.Name = "tbcOpcionBusqueda";
            this.tbcOpcionBusqueda.SelectedIndex = 0;
            this.tbcOpcionBusqueda.Size = new System.Drawing.Size(739, 146);
            this.tbcOpcionBusqueda.TabIndex = 16;
            // 
            // tabBusquedaDNI
            // 
            this.tabBusquedaDNI.Controls.Add(this.conBusPersona);
            this.tabBusquedaDNI.Location = new System.Drawing.Point(4, 22);
            this.tabBusquedaDNI.Name = "tabBusquedaDNI";
            this.tabBusquedaDNI.Padding = new System.Windows.Forms.Padding(3);
            this.tabBusquedaDNI.Size = new System.Drawing.Size(731, 120);
            this.tabBusquedaDNI.TabIndex = 1;
            this.tabBusquedaDNI.Text = "Busqueda por DNI";
            this.tabBusquedaDNI.UseVisualStyleBackColor = true;
            // 
            // conBusPersona
            // 
            this.conBusPersona.cDireccion = null;
            this.conBusPersona.cDocumentoID = null;
            this.conBusPersona.cNombreCompleto = null;
            this.conBusPersona.idCliente = 0;
            this.conBusPersona.idTipoDocumento = 0;
            this.conBusPersona.lEsCliente = false;
            this.conBusPersona.Location = new System.Drawing.Point(99, 7);
            this.conBusPersona.Name = "conBusPersona";
            this.conBusPersona.Size = new System.Drawing.Size(532, 105);
            this.conBusPersona.TabIndex = 0;
            this.conBusPersona.ClickBuscar += new System.EventHandler(this.conBusPersona_ClickBuscar);
            // 
            // tabBusquedaCliente
            // 
            this.tabBusquedaCliente.Controls.Add(this.conBusCli1);
            this.tabBusquedaCliente.Location = new System.Drawing.Point(4, 22);
            this.tabBusquedaCliente.Name = "tabBusquedaCliente";
            this.tabBusquedaCliente.Padding = new System.Windows.Forms.Padding(3);
            this.tabBusquedaCliente.Size = new System.Drawing.Size(731, 120);
            this.tabBusquedaCliente.TabIndex = 0;
            this.tabBusquedaCliente.Text = "Busqueda de Cliente";
            this.tabBusquedaCliente.UseVisualStyleBackColor = true;
            // 
            // btnRegInfCli
            // 
            this.btnRegInfCli.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRegInfCli.Location = new System.Drawing.Point(517, 470);
            this.btnRegInfCli.Name = "btnRegInfCli";
            this.btnRegInfCli.Size = new System.Drawing.Size(60, 50);
            this.btnRegInfCli.TabIndex = 17;
            this.btnRegInfCli.Text = "Registro de Contacto";
            this.btnRegInfCli.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRegInfCli.UseVisualStyleBackColor = true;
            this.btnRegInfCli.Click += new System.EventHandler(this.btnRegInfCli_Click);
            // 
            // frmOfertasClientesExclusivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 541);
            this.Controls.Add(this.btnRegInfCli);
            this.Controls.Add(this.tbcOpcionBusqueda);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.pnlTieneOferta);
            this.Controls.Add(this.lblBaseCustom1);
            this.Name = "frmOfertasClientesExclusivos";
            this.Text = "Ofertas de Clientes Exclusivos";
            this.Load += new System.EventHandler(this.frmOfertasClientesExclusivos_Load);
            this.Controls.SetChildIndex(this.lblBaseCustom1, 0);
            this.Controls.SetChildIndex(this.pnlTieneOferta, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.tbcOpcionBusqueda, 0);
            this.Controls.SetChildIndex(this.btnRegInfCli, 0);
            this.pnlTieneOferta.ResumeLayout(false);
            this.pnlTieneOferta.PerformLayout();
            this.grbListaOfertas.ResumeLayout(false);
            this.pnlListaOferta.ResumeLayout(false);
            this.pnlListaOferta.PerformLayout();
            this.tbcOpcionBusqueda.ResumeLayout(false);
            this.tabBusquedaDNI.ResumeLayout(false);
            this.tabBusquedaCliente.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.ConBusCli conBusCli1;
        private GEN.ControlesBase.lblBaseCustom lblTipoClienteExclusivo;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBaseCustom lblFrecuencia;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private System.Windows.Forms.Panel pnlTieneOferta;
        private GEN.ControlesBase.lblBaseCustom lblBaseCustom1;
        private GEN.ControlesBase.grbBase grbListaOfertas;
        private System.Windows.Forms.FlowLayoutPanel flpListaOfertaCliente;
        private GEN.ControlesBase.tbcBase tbcOpcionBusqueda;
        private System.Windows.Forms.TabPage tabBusquedaCliente;
        private System.Windows.Forms.TabPage tabBusquedaDNI;
        private GEN.ControlesBase.ConBusPersona conBusPersona;
        private System.Windows.Forms.Panel pnlListaOferta;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnBlanco btnRegInfCli;
    }
}