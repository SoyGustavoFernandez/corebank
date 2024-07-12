namespace CRE.ControlBase
{
    partial class ConEvalCualitReferencias
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
            this.clsRefCliEvalBinding = new System.Windows.Forms.BindingSource(this.components);
            this.conReferencias = new GEN.ControlesBase.ConReferencias();
            this.conEvalCualitativa = new GEN.ControlesBase.ConEvalCualitativa();
            ((System.ComponentModel.ISupportInitialize)(this.clsRefCliEvalBinding)).BeginInit();
            this.SuspendLayout();
            // 
            // clsRefCliEvalBinding
            // 
            this.clsRefCliEvalBinding.DataSource = typeof(EntityLayer.clsRefCliEval);
            // 
            // conReferencias
            // 
            this.conReferencias.Location = new System.Drawing.Point(443, 3);
            this.conReferencias.Name = "conReferencias";
            this.conReferencias.Size = new System.Drawing.Size(496, 378);
            this.conReferencias.TabIndex = 4;
            // 
            // conEvalCualitativa
            // 
            this.conEvalCualitativa.Location = new System.Drawing.Point(1, 3);
            this.conEvalCualitativa.Name = "conEvalCualitativa";
            this.conEvalCualitativa.Size = new System.Drawing.Size(436, 497);
            this.conEvalCualitativa.TabIndex = 2;
            this.conEvalCualitativa.ActualizarClick += new System.EventHandler(this.conEvalCualitativa_ActualizarClick);
            this.conEvalCualitativa.EvalCualitativaCellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.conEvalCualitativa_EvalCualitativaCellValueChanged);
            // 
            // ConEvalCualitReferencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.conReferencias);
            this.Controls.Add(this.conEvalCualitativa);
            this.Name = "ConEvalCualitReferencias";
            this.Size = new System.Drawing.Size(1013, 506);
            ((System.ComponentModel.ISupportInitialize)(this.clsRefCliEvalBinding)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource clsRefCliEvalBinding;
        private GEN.ControlesBase.ConEvalCualitativa conEvalCualitativa;
        private GEN.ControlesBase.ConReferencias conReferencias;
    }
}
