namespace GEN.ControlesBase
{
    partial class conTLVBalance
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
            this.listViewEditable1 = new GEN.ControlesBase.ListViewEditable();
            this.colDescripcion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMonto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listViewEditable1
            // 
            this.listViewEditable1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDescripcion,
            this.colMonto});
            this.listViewEditable1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewEditable1.FullRowSelect = true;
            this.listViewEditable1.GridLines = true;
            this.listViewEditable1.Location = new System.Drawing.Point(6, 6);
            this.listViewEditable1.MultiSelect = false;
            this.listViewEditable1.Name = "listViewEditable1";
            this.listViewEditable1.Size = new System.Drawing.Size(474, 522);
            this.listViewEditable1.TabIndex = 0;
            this.listViewEditable1.UseCompatibleStateImageBehavior = false;
            this.listViewEditable1.View = System.Windows.Forms.View.Details;
            // 
            // colDescripcion
            // 
            this.colDescripcion.Text = "Descripción";
            this.colDescripcion.Width = 370;
            // 
            // colMonto
            // 
            this.colMonto.Text = "Monto";
            this.colMonto.Width = 100;
            // 
            // conTLVBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listViewEditable1);
            this.Name = "conTLVBalance";
            this.Size = new System.Drawing.Size(489, 545);
            this.Load += new System.EventHandler(this.conTLVBalance_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader colDescripcion;
        private System.Windows.Forms.ColumnHeader colMonto;
        public ListViewEditable listViewEditable1;

    }
}
