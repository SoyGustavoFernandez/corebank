using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRE.CapaNegocio;
using EntityLayer;

namespace GEN.ControlesBase
{
    public partial class conDatCredito : UserControl
    {
        private clsCNCredito objcredito = new clsCNCredito();

        public bool lCredCoberSeg{get; set;} 

        public conDatCredito()
        {
            InitializeComponent();
        }

        private void conDatCredito_Load(object sender, EventArgs e)
        {
            
        }

        public void cargardatoscredito(int idCuenta)
        {
            DataTable datcre = objcredito.CNdtDataCreditoCobro(idCuenta);
            cboMoneda1.CargaDatos();
            cboMoneda1.SelectedValue = (int)datcre.Rows[0]["IdMoneda"];
            
            cboProducto1.CargarProductoModNivel(clsVarGlobal.idModulo,4);
            cboProducto1.SelectedValue = (int)datcre.Rows[0]["idProducto"];
            txtMonDesembolsado.Text = datcre.Rows[0]["nCapitalDesembolso"].ToString();
            txtNumCuotas.Text = datcre.Rows[0]["nCuotas"].ToString();
            txtTasaVigente.Text = datcre.Rows[0]["nTasaCompensatoria"].ToString();
            txtCodSolicitud.Text = datcre.Rows[0]["idSolicitud"].ToString();
            dtFechaDesembolso.Value = Convert.ToDateTime(datcre.Rows[0]["dFechaDesembolso"]);

            lCredCoberSeg = Convert.ToBoolean(datcre.Rows[0]["lCoberSegDesg"]);
        }


        public void cargardatoscreditoRec(int idCuenta)
        {
            DataTable datcre = objcredito.CNdtDataCreditoCobro(idCuenta);
            cboMoneda1.CargaDatos();
            cboMoneda1.SelectedValue = (int)datcre.Rows[0]["IdMoneda"];
            
            cboProducto1.CargarProductoModNivelRec(clsVarGlobal.idModulo,4);
            cboProducto1.SelectedValue = (int)datcre.Rows[0]["idProducto"];
            txtMonDesembolsado.Text = datcre.Rows[0]["nCapitalDesembolso"].ToString();
            txtNumCuotas.Text = datcre.Rows[0]["nCuotas"].ToString();
            txtTasaVigente.Text = datcre.Rows[0]["nTasaCompensatoria"].ToString();
            txtCodSolicitud.Text = datcre.Rows[0]["idSolicitud"].ToString();
            dtFechaDesembolso.Value = Convert.ToDateTime(datcre.Rows[0]["dFechaDesembolso"]);
        }

        public void limpiarcontroles()
        {
            cboMoneda1.SelectedValue =1;
            cboProducto1.CargarProducto(0);
            txtMonDesembolsado.Text = "0.00";
            txtNumCuotas.Text = "0";
            txtTasaVigente.Text = "0.00";
            txtCodSolicitud.Text = "0";
            dtFechaDesembolso.Value = clsVarGlobal.dFecSystem;
        }

        private void lblBase2_Click(object sender, EventArgs e)
        {

        }
    }
}
