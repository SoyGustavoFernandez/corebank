using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using GEN.CapaNegocio;
using System.Data;

namespace GEN.ControlesBase
{
    public partial class cboFuenteRecurso : cboBase
    {

        public DataTable dtFuenteRecurso;
        public cboFuenteRecurso()
        {
            InitializeComponent();
        }

        public cboFuenteRecurso(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            dtFuenteRecurso = new clsCNFuenteRecurso().ListarFuenteRecurso();
            this.DataSource = dtFuenteRecurso;
            this.ValueMember = dtFuenteRecurso.Columns["idFuenteRecurso"].ToString();
            this.DisplayMember = dtFuenteRecurso.Columns["cFuenteRecurso"].ToString();
        }
        public void CargarItems()
        {
            DataView dtRecurso= new clsCNFuenteRecurso().ListarFuenteRecurso().DefaultView;
            dtRecurso.RowFilter = "idFuenteRecurso<>0";
            this.DataSource = dtRecurso;
            this.ValueMember = "idFuenteRecurso";
            this.DisplayMember = "cFuenteRecurso";
        }
    }
}
