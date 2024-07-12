using CRE.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.ControlesBase
{
    public partial class cboTipoCorrespondencia : cboBase
    {
        public cboTipoCorrespondencia()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboTipoCorrespondencia(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            ListaTipoCorrespondencia();
        }
        public void ListaTipoCorrespondencia()
        {
            clsCNCondonacion cnTipoCorrespondencia = new clsCNCondonacion();
            DataTable dt = cnTipoCorrespondencia.listaTipoCorrespondencia();

            this.DataSource = dt;
            this.ValueMember = dt.Columns["idTipoCorr"].ToString();
            this.DisplayMember = dt.Columns["cCorrespondencia"].ToString();
        }
        public void ListaTipoCorrespondenciaEspecific()
        {
            clsCNCondonacion cnTipoCorrespondencia = new clsCNCondonacion();
            DataTable dt = cnTipoCorrespondencia.listaTipoCorrespondencia();
            dt.DefaultView.RowFilter = ("idTipoCorr = 1");

            this.DataSource = dt;
            this.ValueMember = dt.Columns["idTipoCorr"].ToString();
            this.DisplayMember = dt.Columns["cCorrespondencia"].ToString();
        }
    }
}
