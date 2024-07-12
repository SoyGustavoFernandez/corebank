namespace GEN.ControlesBase
{
    partial class conRastreoTasaNegociable
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(conRastreoTasaNegociable));
            this.grbSeguimiento = new GEN.ControlesBase.grbBase(this.components);
            this.btnMiniDetalle = new GEN.BotonesBase.btnMiniDetalle(this.components);
            this.dtgRastreoTasaNegociable = new GEN.ControlesBase.dtgBase(this.components);
            this.grbSeguimiento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRastreoTasaNegociable)).BeginInit();
            this.SuspendLayout();
            // 
            // grbSeguimiento
            // 
            this.grbSeguimiento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbSeguimiento.Controls.Add(this.btnMiniDetalle);
            this.grbSeguimiento.Controls.Add(this.dtgRastreoTasaNegociable);
            this.grbSeguimiento.Location = new System.Drawing.Point(0, 0);
            this.grbSeguimiento.Name = "grbSeguimiento";
            this.grbSeguimiento.Size = new System.Drawing.Size(635, 175);
            this.grbSeguimiento.TabIndex = 1;
            this.grbSeguimiento.TabStop = false;
            this.grbSeguimiento.Text = "Seguimiento de Propuesta";
            // 
            // btnMiniDetalle
            // 
            this.btnMiniDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMiniDetalle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniDetalle.BackgroundImage")));
            this.btnMiniDetalle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniDetalle.Location = new System.Drawing.Point(600, 17);
            this.btnMiniDetalle.Name = "btnMiniDetalle";
            this.btnMiniDetalle.Size = new System.Drawing.Size(36, 28);
            this.btnMiniDetalle.TabIndex = 1;
            this.btnMiniDetalle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniDetalle.UseVisualStyleBackColor = true;
            this.btnMiniDetalle.Click += new System.EventHandler(this.btnMiniDetalle_Click);
            // 
            // dtgRastreoTasaNegociable
            // 
            this.dtgRastreoTasaNegociable.AllowUserToAddRows = false;
            this.dtgRastreoTasaNegociable.AllowUserToDeleteRows = false;
            this.dtgRastreoTasaNegociable.AllowUserToResizeColumns = false;
            this.dtgRastreoTasaNegociable.AllowUserToResizeRows = false;
            this.dtgRastreoTasaNegociable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgRastreoTasaNegociable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgRastreoTasaNegociable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgRastreoTasaNegociable.Location = new System.Drawing.Point(5, 15);
            this.dtgRastreoTasaNegociable.MultiSelect = false;
            this.dtgRastreoTasaNegociable.Name = "dtgRastreoTasaNegociable";
            this.dtgRastreoTasaNegociable.ReadOnly = true;
            this.dtgRastreoTasaNegociable.RowHeadersVisible = false;
            this.dtgRastreoTasaNegociable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgRastreoTasaNegociable.Size = new System.Drawing.Size(595, 155);
            this.dtgRastreoTasaNegociable.TabIndex = 0;
            this.dtgRastreoTasaNegociable.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgRastreoTasaNegociable_CellContentDoubleClick);
            this.dtgRastreoTasaNegociable.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dtgRastreoTasaNegociable_CellPainting);
            // 
            // conRastreoTasaNegociable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbSeguimiento);
            this.Name = "conRastreoTasaNegociable";
            this.Size = new System.Drawing.Size(640, 175);
            this.grbSeguimiento.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgRastreoTasaNegociable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private dtgBase dtgRastreoTasaNegociable;
        private grbBase grbSeguimiento;
        private BotonesBase.btnMiniDetalle btnMiniDetalle;
    }
}
