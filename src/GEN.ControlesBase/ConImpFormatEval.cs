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
using CRE.CapaNegocio;
using Microsoft.Reporting.WinForms;

namespace GEN.ControlesBase
{
    public partial class ConImpFormatEval : UserControl
    {
        #region Variables Globales
        
        private string cTituloMsg = "Impresión de formatos evaluaciones";
        private string cTipEval = "";
        private int nLugar = 0;
        
        private string cEvalPyme;
        private string cEvalAgro;
        private int nEvalPymeH2000;
        private int nEvalAgroH2000; 
        private string cEvalConsumo;
        private string cEvalConvenio;

        private int idEvalCre = 0;
        private int idSolicitud = 0;

        clsRptEvalImprimeServicio objServicioImp;
        clsRptEvalInterface objImprime;


        string cTipoEvalRpt = "";

        #endregion

        private bool _lCascada = false;
        #region "Properties"

        public bool lCascada  {
            get {
                return _lCascada;
            } 
            set {
                pnEvalSeparada.Visible = value;
                pnEvalCascada.Visible = !value;
                _lCascada = value;
            } 
        } 

        #endregion
        
        public ConImpFormatEval()
        {
            InitializeComponent();
        }

        #region Metodos

        public void cargarDatosEval(int idEvalCred, int idSoli, int nTipoEval)
        {
            this.idEvalCre = idEvalCred;
            this.idSolicitud = idSoli;
            this.cTipEval = obtenerCadenaTipEvalPorIdEval(nTipoEval);
            this.objServicioImp = new clsRptEvalImprimeServicio(objImprime);
        }

        private string obtenerCadenaTipEvalPorIdEval(int nTipEval)
        {
            cEvalPyme = clsVarApl.dicVarGen["cIDsTipEvalCredPyme"];
            cEvalAgro = clsVarApl.dicVarGen["cIDsTipEvalCredAgro"];
            nEvalPymeH2000 = Convert.ToInt32(clsVarApl.dicVarGen["cIDsTipEvalCredPymeHasta2000"]);
            nEvalAgroH2000 = Convert.ToInt32(clsVarApl.dicVarGen["cIDsTipEvalCredAgroHasta2000"]);
            cEvalConsumo = clsVarApl.dicVarGen["cIdTipoEvalCreConsumo"];
            cEvalConvenio = clsVarApl.dicVarGen["cIdTipoEvalCreConvenio"];

            String[] cEvalArrayPyme,
                    cEvalArrayAgro,
                    cEvalArrayConsumo,
                    cEvalArrayConvenio;

            int[] nEvalArrayPyme,
                    nEvalArrayAgro,
                    nEvalArrayConsumo,
                    nEvalArrayConvenio;

            cEvalArrayPyme = cEvalPyme.Split(',');
            cEvalArrayAgro = cEvalAgro.Split(',');
            cEvalArrayConsumo = cEvalConsumo.Split(',');
            cEvalArrayConvenio = cEvalConvenio.Split(',');

            nEvalArrayPyme = Array.ConvertAll<string, int>(cEvalArrayPyme, int.Parse);
            nEvalArrayAgro = Array.ConvertAll<string, int>(cEvalArrayAgro, int.Parse);
            nEvalArrayConsumo = Array.ConvertAll<string, int>(cEvalArrayConsumo, int.Parse);
            nEvalArrayConvenio = Array.ConvertAll<string, int>(cEvalArrayConvenio, int.Parse);

            /// --------------------------------------------------------------------------------------------------------
            /// validando el idTipoEval en cual cadena se encuentra y retorna la cadena de Tipo evaluación correspondiente
            /// seteando juego de botones
            /// --------------------------------------------------------------------------------------------------------

            if (nTipEval == nEvalPymeH2000)
            {
                // evaluación Pyme Hasta 2000
                btnPropuesta.Visible = true;
                btnEvalCualitativa.Visible = true;
                btnEEFF.Visible = true;
                btnHTrabajo.Visible = true;
                btnFCaja.Visible = true;
                objImprime = new clsRptEvalPymeH2000(this.idEvalCre, this.idSolicitud);
                return cEvalPyme;
            }
            else if (nTipEval == nEvalAgroH2000)
            {
                // evaluación Agropecuario Hasta 2000
                btnPropuesta.Visible = true;
                btnEvalCualitativa.Visible = true;
                btnEEFF.Visible = true;
                btnHTrabajo.Visible = true;
                btnFCaja.Visible = true;
                objImprime = new clsRptEvalAgroH2000(this.idEvalCre, this.idSolicitud);
                return cEvalAgro;
            }
            else if (nTipEval.In(nEvalArrayPyme)) 
            {
                // evaluación Pyme
                btnPropuesta.Visible = true;
                btnEvalCualitativa.Visible = true;
                btnEEFF.Visible = true;
                btnHTrabajo.Visible = true;
                btnFCaja.Visible = true;
                objImprime = new clsRptEvalPyme(this.idEvalCre, this.idSolicitud);
                return cEvalPyme;
            }
            else if (nTipEval.In(nEvalArrayAgro))
            {
                // evaluación Agropecuario

                btnPropuesta.Visible = true;
                btnEvalCualitativa.Visible = true;
                btnEEFF.Visible = true;
                btnHTrabajo.Visible = true;
                btnFCaja.Visible = true;
                objImprime = new clsRptEvalAgro(this.idEvalCre, this.idSolicitud);
                return cEvalAgro;
            }
            else if (nTipEval.In(nEvalArrayConsumo))
            {
                // evaluación Consumo
                btnPropuesta.Visible = true;
                btnEvalCualitativa.Visible = true;
                btnEEFF.Visible = false;
                btnHTrabajo.Visible = false;
                btnFCaja.Visible = false;
                objImprime = new clsRptEvalConsumo(this.idEvalCre, this.idSolicitud);
                return cEvalConsumo;
            }
            else if (nTipEval.In(nEvalArrayConvenio))
            {
                /*// evaluación Convenio
                btnPropuesta.Visible = true;
                btnEvalCualitativa.Visible = false;
                btnEEFF.Visible = false;
                btnHTrabajo.Visible = false;
                btnFCaja.Visible = false;
                //objImprime = new clsRptEvalConvenio(this.idEvalCre, this.idSolicitud);*/
                return "0";
            }
            else
            {
                return "0";
            }
        }

        private void ImprimirPropuesta()
        {
            this.objServicioImp.ImpPropuestaEval();
        }

        private void ImprimirEvalCualitativa()
        {
            this.objServicioImp.ImpEvalCualitativa();
        }

        private void ImprimirEEFF()
        {
            this.objServicioImp.ImpEEFF();
        }

        private void ImprimirFlujoCaja()
        {
            this.objServicioImp.ImpFlujoCaja();
        }

        #endregion

        #region Eventos

        public void ImprimirCascada()
        {
            this.objServicioImp.ImprimeCascada();
        }

        public void ImprimirFlujoCajaEval()
        {
            this.objServicioImp.ImpFlujoCaja();
        }

        private void btnPropuesta_Click(object sender, EventArgs e)
        {
            this.objServicioImp.ImpPropuestaEval();
        }

        private void btnImpCascada_Click(object sender, EventArgs e)
        {
            this.objServicioImp.ImprimeCascada();
        }
        
        private void btnEvalCualitativa_Click(object sender, EventArgs e)
        {
            this.objServicioImp.ImpEvalCualitativa();
        }
        
        private void btnEEFF_Click(object sender, EventArgs e)
        {
            this.objServicioImp.ImpEEFF();
        }

        private void btnHTrabajo_Click(object sender, EventArgs e)
        {
            this.objServicioImp.ImpHojaTrabajo();
        }

        private void btnFCaja_Click(object sender, EventArgs e)
        {
            this.objServicioImp.ImpFlujoCaja();
        }

        #endregion

    }
}
