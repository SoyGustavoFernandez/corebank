namespace GEN.ControlesBase
{
    partial class frmClientesHomonimos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClientesHomonimos));
            this.dtgClientesHomonimos = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            ((System.ComponentModel.ISupportInitialize)(this.dtgClientesHomonimos)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgClientesHomonimos
            // 
            this.dtgClientesHomonimos.AllowUserToAddRows = false;
            this.dtgClientesHomonimos.AllowUserToDeleteRows = false;
            this.dtgClientesHomonimos.AllowUserToResizeColumns = false;
            this.dtgClientesHomonimos.AllowUserToResizeRows = false;
            this.dtgClientesHomonimos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgClientesHomonimos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgClientesHomonimos.Location = new System.Drawing.Point(6, 28);
            this.dtgClientesHomonimos.MultiSelect = false;
            this.dtgClientesHomonimos.Name = "dtgClientesHomonimos";
            this.dtgClientesHomonimos.ReadOnly = true;
            this.dtgClientesHomonimos.RowHeadersVisible = false;
            this.dtgClientesHomonimos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgClientesHomonimos.Size = new System.Drawing.Size(556, 143);
            this.dtgClientesHomonimos.TabIndex = 2;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(502, 177);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 3;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(4, 7);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(187, 13);
            this.lblBase1.TabIndex = 4;
            this.lblBase1.Text = "Listado de clientes homónimos:";
            // 
            // frmClientesHomonimos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 257);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.dtgClientesHomonimos);
            this.Name = "frmClientesHomonimos";
            this.Text = "Clientes Homónimos";
            this.Load += new System.EventHandler(this.frmClientesHomonimos_Load);
            this.Controls.SetChildIndex(this.dtgClientesHomonimos, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgClientesHomonimos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private dtgBase dtgClientesHomonimos;
        private BotonesBase.btnSalir btnSalir1;
        private lblBase lblBase1;
    }
}