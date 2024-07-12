using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CLI.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;
using SPL.CapaNegocio;

namespace SPL.Presentacion
{
    public partial class frmDeclaracionJuradaSO : frmDeclaracionJurada
    {
        #region Variables
        clsCNRetDatosCliente cncliente = new clsCNRetDatosCliente();
        clsCNDirecCli cndireccion = new clsCNDirecCli();
        clsCNListaActivEco cnactividad = new clsCNListaActivEco();
        clsCNDeclaracionJurada cndeclaracion = new clsCNDeclaracionJurada();

        Transaccion estado = Transaccion.Nuevo;
        clsCliente cliente;

        private int idCli = 0,idActividad=0,idDireccion=0,idUbigeo=0;
        private string cActividad = "", cDireccion = "", cDistrito	 = "",cProvincia="",cDepartamento="";
        private bool lSujetoObligado = false, lOficialCumplimeito = false;

        #endregion

        public frmDeclaracionJuradaSO()
        {
            InitializeComponent();
           
        }

        private void frmDeclaracionJuradaSO_Load(object sender, EventArgs e)
        {

        }
      
    }
}
