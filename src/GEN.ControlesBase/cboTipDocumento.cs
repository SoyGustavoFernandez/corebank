using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GEN.CapaNegocio;
using System.Data;

namespace GEN.ControlesBase
{
    public partial class cboTipDocumento : cboBase
    {
        public cboTipDocumento()
        {
            InitializeComponent();
        }

        public cboTipDocumento(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            clsCNTipoDocumento ListadoTipoDocumento = new clsCNTipoDocumento();
            DataTable dt = ListadoTipoDocumento.listarTipoDocumento();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
        }

        public void CargarDocumentos(string cTipoFiltro)
        { 

            clsCNTipDocumento ListaTipDoc = new clsCNTipDocumento();
            DataTable tbTipDoc = ListaTipDoc.ListaTipDocFiltro(cTipoFiltro);
            this.DataSource = tbTipDoc;
            this.ValueMember = tbTipDoc.Columns[0].ToString();
            this.DisplayMember = tbTipDoc.Columns[1].ToString();
        }
        public void CargarDocumentosSplaftPep() 
        {
            clsCNTipoDocumento ListadoTipoDocumento = new clsCNTipoDocumento();
            DataTable dtTipDocs = ListadoTipoDocumento.listarTipoDocumento();

            IEnumerable<DataRow> consulta =
                from dr in dtTipDocs.AsEnumerable()
                where dr.Field<int>("idTipoDocumento") < 4
                select dr;

            DataTable dtTipoDocFinal = consulta.CopyToDataTable<DataRow>();
            this.DataSource = dtTipoDocFinal;
            this.ValueMember = dtTipoDocFinal.Columns[0].ToString();
            this.DisplayMember = dtTipoDocFinal.Columns[1].ToString();
        }
    }
}
