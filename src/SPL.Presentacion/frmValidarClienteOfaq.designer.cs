namespace SPL.Presentacion
{
    partial class frmValidarClienteOfaq
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmValidarClienteOfaq));
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.dtgClientesOfaq = new GEN.ControlesBase.dtgBase(this.components);
            this.btnValidar1 = new GEN.BotonesBase.btnValidar();
            ((System.ComponentModel.ISupportInitialize)(this.dtgClientesOfaq)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(505, 273);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 2;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // dtgClientesOfaq
            // 
            this.dtgClientesOfaq.AllowUserToAddRows = false;
            this.dtgClientesOfaq.AllowUserToDeleteRows = false;
            this.dtgClientesOfaq.AllowUserToResizeColumns = false;
            this.dtgClientesOfaq.AllowUserToResizeRows = false;
            this.dtgClientesOfaq.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgClientesOfaq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgClientesOfaq.Location = new System.Drawing.Point(12, 21);
            this.dtgClientesOfaq.MultiSelect = false;
            this.dtgClientesOfaq.Name = "dtgClientesOfaq";
            this.dtgClientesOfaq.ReadOnly = true;
            this.dtgClientesOfaq.RowHeadersVisible = false;
            this.dtgClientesOfaq.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgClientesOfaq.Size = new System.Drawing.Size(910, 246);
            this.dtgClientesOfaq.TabIndex = 4;
            // 
            // btnValidar1
            // 
            this.btnValidar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnValidar1.BackgroundImage")));
            this.btnValidar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnValidar1.Location = new System.Drawing.Point(439, 273);
            this.btnValidar1.Name = "btnValidar1";
            this.btnValidar1.Size = new System.Drawing.Size(60, 50);
            this.btnValidar1.TabIndex = 5;
            this.btnValidar1.Text = "&Validar";
            this.btnValidar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnValidar1.UseVisualStyleBackColor = true;
            this.btnValidar1.Click += new System.EventHandler(this.btnValidar1_Click);
            // 
            // frmValidarClienteOfaq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 371);
            this.Controls.Add(this.btnValidar1);
            this.Controls.Add(this.dtgClientesOfaq);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmValidarClienteOfaq";
            this.Text = "Validación de Clientes en Lista Ofaq";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.dtgClientesOfaq, 0);
            this.Controls.SetChildIndex(this.btnValidar1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgClientesOfaq)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.dtgBase dtgClientesOfaq;
        private GEN.BotonesBase.btnValidar btnValidar1;
    }
}

