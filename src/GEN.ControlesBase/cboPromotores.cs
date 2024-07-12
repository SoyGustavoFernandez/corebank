using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.CapaNegocio;
using System.Data;
using EntityLayer;
using CRE.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboPromotores : cboBase
    {
        Int32 idAgencia = clsVarGlobal.nIdAgencia;
        public cboPromotores()
        {
            InitializeComponent();
        }

        public cboPromotores(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            ListarPromotoresCred(idAgencia);
        }
        public void ListarPromotoresCred(int idAgencias)
        {
            clsCNPersonalCreditos ListaPersonalCre = new clsCNPersonalCreditos();
            DataTable dt = ListaPersonalCre.CNListaPromotorCred(idAgencias);
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
        }

        public void ListarPromotoresCredYNinguno(int idAgencias)
        {
            clsCNPersonalCreditos ListaPersonalCre = new clsCNPersonalCreditos();
            DataTable dt = ListaPersonalCre.CNListaPromotorCred(idAgencias);
            DataRow dr = dt.NewRow();
            dr[dt.Columns[0].ToString()] = 0;
            dr[dt.Columns[1].ToString()] = "***NINGUNO***";
            dt.Rows.InsertAt(dr,0);
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
        }

        public void filtrarPorCanal(int nCodCanal)
        {
            DataTable dtVendedor = new clsCNMantenimientoCanales().ListaMantenimientoVendedores(2, nCodCanal, clsVarGlobal.nIdAgencia);

            this.DataSource = dtVendedor;
            this.ValueMember = dtVendedor.Columns["idUsuario"].ToString();
            this.DisplayMember = dtVendedor.Columns["cNombreVendedor"].ToString();
        }
    }
}
