namespace GEN.ControlesBase
{
    partial class ConListAgencias
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
            this.chklbAgencia1 = new GEN.ControlesBase.chklbAgencia(this.components);
            this.chcTodos = new GEN.ControlesBase.chcBase(this.components);
            this.SuspendLayout();
            // 
            // chklbAgencia1
            // 
            this.chklbAgencia1.FormattingEnabled = true;
            this.chklbAgencia1.Location = new System.Drawing.Point(3, 23);
            this.chklbAgencia1.Name = "chklbAgencia1";
            this.chklbAgencia1.Size = new System.Drawing.Size(214, 109);
            this.chklbAgencia1.TabIndex = 0;
            // 
            // chcTodos
            // 
            this.chcTodos.AutoSize = true;
            this.chcTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chcTodos.ForeColor = System.Drawing.Color.Navy;
            this.chcTodos.Location = new System.Drawing.Point(4, 4);
            this.chcTodos.Name = "chcTodos";
            this.chcTodos.Size = new System.Drawing.Size(136, 17);
            this.chcTodos.TabIndex = 1;
            this.chcTodos.Text = "Todas las agencias";
            this.chcTodos.UseVisualStyleBackColor = true;
            this.chcTodos.CheckedChanged += new System.EventHandler(this.chcTodos_CheckedChanged);
            // 
            // ConListAgencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chcTodos);
            this.Controls.Add(this.chklbAgencia1);
            this.Name = "ConListAgencias";
            this.Size = new System.Drawing.Size(221, 134);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private chklbAgencia chklbAgencia1;
        private chcBase chcTodos;
    }
}
