using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;

namespace CRE.ControlBase
{
    public partial class ConEvalCualitReferencias : UserControl
    {
        public event DataGridViewCellEventHandler EvalCualitativaCellValueChanged;
        public event EventHandler ActualizarEvalCualitativoClick;

        public ConEvalCualitReferencias()
        {
            InitializeComponent();
        }

        #region Métodos Públicos
        public void AsignarDatos(List<clsEvalCualitativa> _listEvalCualitativa, List<clsReferenciaEval> _listReferencia, DataTable _dtTipReferEval, DataTable _dtTipVinculoEval)
        {
            this.conEvalCualitativa.AsignarDatos(_listEvalCualitativa);
            this.conReferencias.AsignarDataTable(_dtTipReferEval, _dtTipVinculoEval);
            this.conReferencias.AsignarDatos(_listReferencia);
        }

        public void ActualizarDatos(List<clsEvalCualitativa> _listEvalCualitativa, List<clsReferenciaEval> _listReferencia)
        {
            this.conEvalCualitativa.AsignarDatos(_listEvalCualitativa);
            this.conReferencias.AsignarDatos(_listReferencia);
        }

        public void ActualizarEvalCualitativo(List<clsEvalCualitativa> _listEvalCualitativa)
        {
            this.conEvalCualitativa.AsignarDatos(_listEvalCualitativa);
        }

        public void ActualizarEvalCualitativo()
        {
            this.conEvalCualitativa.ActualizarDataGridView();
        }

        public decimal TotalPuntaje()
        {
            return this.conEvalCualitativa.TotalPuntaje();
        }
        #endregion

        #region Métodos Privados
        #endregion

        #region Eventos
        private void conEvalCualitativa_EvalCualitativaCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (EvalCualitativaCellValueChanged != null)
                EvalCualitativaCellValueChanged(sender, e);
        }

        private void conEvalCualitativa_ActualizarClick(object sender, EventArgs e)
        {
            if (ActualizarEvalCualitativoClick != null)
                ActualizarEvalCualitativoClick(sender, e);
        }
        #endregion
    }
}
