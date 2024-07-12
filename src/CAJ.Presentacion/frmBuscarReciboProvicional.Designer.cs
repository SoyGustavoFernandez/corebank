using System;
namespace CAJ.Presentacion
{
    partial class frmBuscarReciboProvicional
    {
        private GEN.ControlesBase.ConBusCol conBusCol;
        private GEN.ControlesBase.dtgBase dtgClientes;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarReciboProvicional));
            this.conBusCol = new GEN.ControlesBase.ConBusCol();
            this.dtgClientes = new GEN.ControlesBase.dtgBase(this.components);
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtNroRecibo = new GEN.ControlesBase.txtBase(this.components);
            this.btnBusqueda1 = new GEN.BotonesBase.btnBusqueda();
            ((System.ComponentModel.ISupportInitialize)(this.dtgClientes)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // conBusCol
            // 
            this.conBusCol.cEstado = "0";
            this.conBusCol.Location = new System.Drawing.Point(12, 12);
            this.conBusCol.Name = "conBusCol";
            this.conBusCol.Size = new System.Drawing.Size(390, 86);
            this.conBusCol.TabIndex = 2;
            this.conBusCol.BuscarUsuario += new System.EventHandler(this.conBusCliente_ClicBuscar);
            // 
            // dtgClientes
            // 
            this.dtgClientes.AllowUserToAddRows = false;
            this.dtgClientes.AllowUserToDeleteRows = false;
            this.dtgClientes.AllowUserToResizeColumns = false;
            this.dtgClientes.AllowUserToResizeRows = false;
            this.dtgClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgClientes.Location = new System.Drawing.Point(12, 104);
            this.dtgClientes.MultiSelect = false;
            this.dtgClientes.Name = "dtgClientes";
            this.dtgClientes.ReadOnly = true;
            this.dtgClientes.RowHeadersVisible = false;
            this.dtgClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgClientes.Size = new System.Drawing.Size(895, 160);
            this.dtgClientes.TabIndex = 3;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(781, 270);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(847, 270);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 5;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.txtNroRecibo);
            this.grbBase1.Controls.Add(this.btnBusqueda1);
            this.grbBase1.Location = new System.Drawing.Point(687, 27);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(223, 71);
            this.grbBase1.TabIndex = 6;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Filtro de recibo provisional";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(11, 21);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(88, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Nro. de recibo";
            // 
            // txtNroRecibo
            // 
            this.txtNroRecibo.Location = new System.Drawing.Point(13, 42);
            this.txtNroRecibo.MaxLength = 8;
            this.txtNroRecibo.Name = "txtNroRecibo";
            this.txtNroRecibo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNroRecibo.Size = new System.Drawing.Size(134, 20);
            this.txtNroRecibo.TabIndex = 1;
            this.txtNroRecibo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroRecibo_KeyPress);
            // 
            // btnBusqueda1
            // 
            this.btnBusqueda1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda1.BackgroundImage")));
            this.btnBusqueda1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda1.Location = new System.Drawing.Point(153, 15);
            this.btnBusqueda1.Name = "btnBusqueda1";
            this.btnBusqueda1.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda1.TabIndex = 0;
            this.btnBusqueda1.Text = "&Buscar";
            this.btnBusqueda1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda1.UseVisualStyleBackColor = true;
            this.btnBusqueda1.Click += new System.EventHandler(this.btnBusqueda1_Click);
            // 
            // frmBuscarReciboProvicional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 349);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dtgClientes);
            this.Controls.Add(this.conBusCol);
            this.Name = "frmBuscarReciboProvicional";
            this.Text = "Recibos Provisionales";
            this.Controls.SetChildIndex(this.conBusCol, 0);
            this.Controls.SetChildIndex(this.dtgClientes, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgClientes)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion        

        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtNroRecibo;
        private GEN.BotonesBase.btnBusqueda btnBusqueda1;
   

    }
}