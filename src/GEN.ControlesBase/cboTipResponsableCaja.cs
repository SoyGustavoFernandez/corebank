using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Data;
using GEN.CapaNegocio;
using System.Windows.Forms;
namespace GEN.ControlesBase
{
    public partial class cboTipResponsableCaja : cboBase
    {        
        public cboTipResponsableCaja()
        {
            InitializeComponent();
        }

        public cboTipResponsableCaja(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public void cargarTipoResponsableCajaOpe(int idAgencia, DateTime dFecOperacion)
        {
            clsCNTipoResponsableCaja listaMotOperacion = new clsCNTipoResponsableCaja();
            DataTable dt = listaMotOperacion.ListaTipoRespobableCajaOpe(idAgencia, dFecOperacion);
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
        }
        public void cargarTipoResponsableCajaAdm(int idAgencia)
        {
            clsCNTipoResponsableCaja listaMotOperacion = new clsCNTipoResponsableCaja();
            DataTable dt = listaMotOperacion.ListaTipoRespobableCajaAdm(idAgencia);
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
        }

        public void cargarTipoResponsableSupervision(string cTipoVisita)
        {
            clsCNTipoResponsableCaja listaMotOperacion = new clsCNTipoResponsableCaja();
            DataTable dt = listaMotOperacion.ListaTipoRespobableCajaSupervision(cTipoVisita);
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();

            if (dt.Rows.Count > 0)
            {
                this.SelectedIndex = 0;
            }
        }
    }
}
