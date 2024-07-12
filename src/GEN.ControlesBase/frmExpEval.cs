using EntityLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class frmExpEval : Form
    {
        #region Variables Globales

        private string cTipEval = "";
        private string cEvalPyme;
        private string cEvalAgro;
        private int nEvalPymeH2000;
        private int nEvalAgroH2000;
        private string cEvalConsumo;
        private string cEvalConvenio;
        private string cEvalAgricola;
        private string cEvalPreyApro;
        private string cEvalResConsumo;
        private string cEvalResApro;
        
        private string cSoliAprRapida;
        private string cGrupoSolidario;

        private int idEvalCre;
        private int idSolicitud;
        private int idSolicitudCredGS=0;
        private int idGrupoSol = 0;
        private int idEvalCredGrupoSol = 0;

        clsRptEvalImprimeServicio objServicioImp;
        clsRptEvalInterface objImprime;

        public int idDocumentacion = 0;//, idClient;
        #endregion

        public frmExpEval()
        {
            InitializeComponent();
        }

        public frmExpEval(int idEvalCred, int idSoli, int nTipoEval)
        {
            InitializeComponent();

            this.menuStrip1.Items.Clear();

            if (nTipoEval == 19)
                nTipoEval = 18;
            else if (nTipoEval == 20)
                nTipoEval = 16;
            else if (nTipoEval == 21)
                nTipoEval = 17;

            this.idEvalCre = idEvalCred;
            this.idSolicitud = idSoli;
            this.cTipEval = obtenerCadenaTipEvalPorIdEval(nTipoEval);
            this.objServicioImp = new clsRptEvalImprimeServicio(objImprime);
        }

        public frmExpEval(int idEvalCred, int idSoli, int nTipoEval, int Documentacion)//,int nIdCliente)
        {
            if (nTipoEval == 19)
                nTipoEval = 18;
            else if (nTipoEval == 20)
                nTipoEval = 16;
            else if (nTipoEval == 21)
                nTipoEval = 17;

            if (Documentacion == 1)
            {
                InitializeComponent();
                this.idDocumentacion = Documentacion;
                //this.idClient = nIdCliente;
                this.menuStrip1.Items.Clear();

                this.idEvalCre = idEvalCred;
                this.idSolicitud = idSoli;
                this.cTipEval = obtenerCadenaTipEvalPorIdEval(nTipoEval);
                this.objServicioImp = new clsRptEvalImprimeServicio(objImprime);
            }
            else if (Documentacion == 2)
            {
                InitializeComponent();
                this.idDocumentacion = Documentacion;
                //this.idClient = nIdCliente;
                this.menuStrip1.Items.Clear();

                this.idGrupoSol = idEvalCred;
                this.idSolicitudCredGS = idSoli;
                this.idEvalCredGrupoSol = nTipoEval;
                nTipoEval = 14;
                this.idEvalCre = 0;
                this.idSolicitud = 0;
                this.cTipEval = obtenerCadenaTipEvalPorIdEval(nTipoEval);
                this.objServicioImp = new clsRptEvalImprimeServicio(objImprime);
            }


        }

        #region Métodos Privados
        private string obtenerCadenaTipEvalPorIdEval(int nTipEval)
        {
            cEvalPyme = clsVarApl.dicVarGen["cIDsTipEvalCredPyme"];
            cEvalAgro = clsVarApl.dicVarGen["cIDsTipEvalCredAgro"];
            nEvalPymeH2000 = Convert.ToInt32(clsVarApl.dicVarGen["cIDsTipEvalCredPymeHasta2000"]);
            nEvalAgroH2000 = Convert.ToInt32(clsVarApl.dicVarGen["cIDsTipEvalCredAgroHasta2000"]);
            cEvalConsumo = clsVarApl.dicVarGen["cIdTipoEvalCreConsumo"];
            cEvalConvenio = clsVarApl.dicVarGen["cIdTipoEvalCreConvenio"];
            cEvalAgricola = clsVarApl.dicVarGen["cIdTipoEvalCreAgricola"];
            cEvalPreyApro = clsVarApl.dicVarGen["cIdEvalPreyApro"];
            cEvalResConsumo = clsVarApl.dicVarGen["cIdEvalResConsumo"];
            cEvalResApro = clsVarApl.dicVarGen["cIdEvalResApro"];
            int nEvalAgricola = Convert.ToInt32(cEvalAgricola);

            String[] cEvalArrayPyme,
                    cEvalArrayAgro,
                    cEvalArrayConsumo,
                    cEvalArrayConvenio,
                    cEvalArrayPreyApro,
                    cEvalArrayResConsumo,
                    cEvalArrayResApro;

            int[] nEvalArrayPyme,
                    nEvalArrayAgro,
                    nEvalArrayConsumo,
                    nEvalArrayConvenio,
                    nEvalArrayPreyApro,
                    nEvalArrayResConsumo,
                    nEvalArrayResApro;

            cEvalArrayPyme = cEvalPyme.Split(',');
            cEvalArrayAgro = cEvalAgro.Split(',');
            cEvalArrayConsumo = cEvalConsumo.Split(',');
            cEvalArrayConvenio = cEvalConvenio.Split(',');
            cEvalArrayPreyApro = cEvalPreyApro.Split(',');
            cEvalArrayResConsumo = cEvalResConsumo.Split(',');
            cEvalArrayResApro = cEvalResApro.Split(',');

            nEvalArrayPyme = Array.ConvertAll<string, int>(cEvalArrayPyme, int.Parse);
            nEvalArrayAgro = Array.ConvertAll<string, int>(cEvalArrayAgro, int.Parse);
            nEvalArrayConsumo = Array.ConvertAll<string, int>(cEvalArrayConsumo, int.Parse);
            nEvalArrayConvenio = Array.ConvertAll<string, int>(cEvalArrayConvenio, int.Parse);
            nEvalArrayPreyApro = Array.ConvertAll<string, int>(cEvalArrayPreyApro, int.Parse);
            nEvalArrayResConsumo = Array.ConvertAll<string, int>(cEvalArrayResConsumo, int.Parse);
            nEvalArrayResApro = Array.ConvertAll<string, int>(cEvalArrayResApro, int.Parse);

            /// --------------------------------------------------------------------------------------------------------
            /// validando el idTipoEval en cual cadena se encuentra y retorna la cadena de Tipo evaluación correspondiente
            /// seteando juego de botones
            /// --------------------------------------------------------------------------------------------------------

            if (nTipEval == nEvalPymeH2000)
            {
                // evaluación Pyme Hasta 2000

                obtenerCabeceras();
                //this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                //this.tmsCualitativo,
                //this.tmsPropuesta,
                //this.tmsEEFF,
                //this.tmsFlujoCaja});

                //this.tmsCualitativo.Text = "1. Cualitativo";
                //this.tmsPropuesta.Text = "2. Propuesta";
                //this.tmsEEFF.Text = "3. EEFF";
                //this.tmsFlujoCaja.Text = "4. Flujo de Caja";

                objImprime = new clsRptEvalPymeH2000(this.idEvalCre, this.idSolicitud, this);
                return cEvalPyme;
            }
            else if (nTipEval == nEvalAgroH2000)
            {
                // evaluación Agropecuario Hasta 2000

                obtenerCabeceras();

                //this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                //this.tmsCualitativo,
                //this.tmsPropuesta,
                //this.tmsEEFF,
                //this.tmsFlujoCaja});

                //this.tmsCualitativo.Text = "1. Cualitativo";
                //this.tmsPropuesta.Text = "2. Propuesta";
                //this.tmsEEFF.Text = "3. EEFF";
                //this.tmsFlujoCaja.Text = "4. Flujo de Caja";

                objImprime = new clsRptEvalAgroH2000(this.idEvalCre, this.idSolicitud, this);
                return cEvalAgro;
            }
            else if (nTipEval.In(nEvalArrayPyme))
            {
                // evaluación Pyme
                obtenerCabeceras();

                //this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                //    this.tmsCualitativo,
                //    this.tmsPropuesta,
                //    this.tmsEEFF,
                //    this.tmsHojaTrabajo,
                //    this.tmsFlujoCaja});
                                    
                //        this.tmsCualitativo.Text = "1. Cualitativo";
                //        this.tmsPropuesta.Text = "2. Propuesta";
                //        this.tmsEEFF.Text = "3. EEFF";
                //        this.tmsHojaTrabajo.Text = "4. Hoja de Trabajo";
                //        this.tmsFlujoCaja.Text = "5. Flujo de Caja";
                
         



                objImprime = new clsRptEvalPyme(this.idEvalCre, this.idSolicitud, this);
                return cEvalPyme;
            }
            else if (nTipEval.In(nEvalArrayAgro))
            {
                // evaluación Agropecuario
                obtenerCabeceras();
                //this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                //this.tmsCualitativo,
                //this.tmsPropuesta,
                //this.tmsEEFF,
                //this.tmsHojaTrabajo,
                //this.tmsFlujoCaja});

                //this.tmsCualitativo.Text = "1. Cualitativo";
                //this.tmsPropuesta.Text = "2. Propuesta";
                //this.tmsEEFF.Text = "3. EEFF";
                //this.tmsHojaTrabajo.Text = "4. Hoja de Trabajo";
                //this.tmsFlujoCaja.Text = "5. Flujo de Caja";

                objImprime = new clsRptEvalAgro(this.idEvalCre, this.idSolicitud, this);
                return cEvalAgro;
            }
            else if (nTipEval.In(nEvalArrayConsumo))
            {
                // evaluación Consumo

                if (idDocumentacion == 1)
                {
                    this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                    this.tmsSolicitud,
                    this.tmsActaApro,
                    this.tmsCualitativo,
                    this.tmsPropuesta,
                    this.tmsOpRiesgos,
                    this.tmsOpRecup,
                    this.tmsVisita,
                    this.tmsScore});

                    this.tmsSolicitud.Text = "1. Solicitud";
                    this.tmsActaApro.Text = "2. Acta de Aprobación";
                    this.tmsCualitativo.Text = "3. Cualitativo";
                    this.tmsPropuesta.Text = "4. Propuesta";
                    this.tmsOpRiesgos.Text = "5. Opinión de Riesgos";
                    this.tmsOpRecup.Text = "6. Opinión de Recuperaciones";
                    this.tmsVisita.Text = "7. Visita";
                    this.tmsScore.Text = "8. Score";
                }

                else
                {
                    this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                    this.tmsCualitativo,
                    this.tmsPropuesta,
                    this.tmsVisita,
                    this.tmsScore});

                    this.tmsCualitativo.Text = "1. Cualitativo";
                    this.tmsPropuesta.Text = "2. Propuesta";
                    this.tmsVisita.Text = "3. Visita";
                    this.tmsScore.Text = "4. Score";
                }
                objImprime = new clsRptEvalConsumo(this.idEvalCre, this.idSolicitud, this);
                return cEvalConsumo;
            }
            else if (nTipEval.In(nEvalArrayConvenio))
            {
                // evaluación Convenio

                obtenerCabeceras2();
                //this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                //this.tmsPropuesta});

                //this.tmsPropuesta.Text = "1. Propuesta";

                objImprime = new clsRptEvalConvenio(this.idEvalCre, this.idSolicitud, this);
                return cEvalConvenio;
            }
            else if (nTipEval == nEvalAgricola)
            {
                // evaluación Agropecuario
                if (idDocumentacion == 1)
                {
                    this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                    this.tmsSolicitud,
                    this.tmsActaApro,
                    this.tmsCualitativo,
                    this.tmsPropuesta,
                    this.tmsEEFF,
                    this.tmsOpRiesgos,
                    this.tmsOpRecup,
                    this.tmsVisita,
                    this.tmsScore
                    });

                    this.tmsSolicitud.Text = "1. Solicitud";
                    this.tmsActaApro.Text = "2. Acta de Aprobación";
                    this.tmsCualitativo.Text = "3. Cualitativo";
                    this.tmsPropuesta.Text = "4. Propuesta";
                    this.tmsEEFF.Text = "5. EEFF";
                    this.tmsOpRiesgos.Text = "6. Opinión de Riesgos";
                    this.tmsOpRecup.Text = "7. Opinión de Recuperaciones";
                    this.tmsVisita.Text = "8. Visita";
                    this.tmsScore.Text = "9. Score";

                }
                else
                {
                this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.tmsCualitativo,
                this.tmsPropuesta,
                this.tmsEEFF,
                this.tmsVisita,
                this.tmsScore
                /*,
                this.tmsHojaTrabajo,
                this.tmsFlujoCaja*/});

                    this.tmsCualitativo.Text = "1. Cualitativo";
                    this.tmsPropuesta.Text = "2. Propuesta";
                    this.tmsEEFF.Text = "3. EEFF";
                    this.tmsVisita.Text = "3. Visita";
                    this.tmsScore.Text = "4. Score";
                    //this.tmsHojaTrabajo.Text = "4. Hoja de Trabajo";
                    //this.tmsFlujoCaja.Text = "5. Flujo de Caja";
                }

                objImprime = new clsRptEvalAgri(this.idEvalCre, this.idSolicitud, this);
                return cEvalAgricola;
            }
            else if (nTipEval.In(nEvalArrayPreyApro))
	        {
                obtenerCabeceras2();
                //this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                //this.tmsPropuesta});

                //this.tmsPropuesta.Text = "1. Propuesta";
                objImprime = new clsRptEvalPreyApro(this.idEvalCre, this.idSolicitud, this);
                return cEvalPreyApro;
	        }
            else if (nTipEval.In(nEvalArrayResConsumo))
	        {
                obtenerCabeceras2();
                //this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                //this.tmsPropuesta});

                //this.tmsPropuesta.Text = "1. Propuesta";
                objImprime = new clsRptEvalResumConsumo(this.idEvalCre, this.idSolicitud, this);
                return cEvalResConsumo;
	        }
            else if (nTipEval.In(nEvalArrayResApro))
            {
                obtenerCabeceras2();
                //this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                //this.tmsPropuesta});

                //this.tmsPropuesta.Text = "1. Propuesta";
                         

                objImprime = new clsRptEvalResumApro(this.idEvalCre, this.idSolicitud, this);
                return cEvalResConsumo;
            }
            else if (nTipEval == 14)
            {
                this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                        this.tmsSolicitud,
                        this.tmsActaApro,
                        this.tmsCualitativo,
                        this.tmsEEFF,
                        this.tmsVisita});
                this.tmsSolicitud.Text = "1. Solicitud";
                this.tmsActaApro.Text = "2. Acta de Aprobación";
                this.tmsCualitativo.Text = "3. Eval Cualitativo";
                this.tmsEEFF.Text = "4. Eval Integrantes";
                this.tmsVisita.Text = "5. Visita";
                
                objImprime = new clsRptGrupoSolidario(this.idGrupoSol, this.idSolicitudCredGS, this.idEvalCredGrupoSol, this);
                return cSoliAprRapida;
            
            
            }
            else if (nTipEval == 0)
            {
               
                    this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                        this.tmsSolicitud,
                        this.tmsVisita,
                        this.tmsScore});
                    this.tmsSolicitud.Text = "1. Solicitud y Datos de Aprobación";
                    this.tmsVisita.Text = "2. Visita";
                    this.tmsScore.Text = "3. Score";
                    
                    objImprime = new clsRptSoliAprRapida(this.idEvalCre, this.idSolicitud, this);
                    return cSoliAprRapida;
            
            }
            else
            {
                return "0";
            }
        }

        private void obtenerCabeceras()
        {

            if (idDocumentacion == 1)
            {
                this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.tmsSolicitud,
                this.tmsActaApro,
                this.tmsCualitativo,
                this.tmsPropuesta,
                this.tmsEEFF,
                this.tmsHojaTrabajo,
                this.tmsFlujoCaja,
                this.tmsOpRiesgos,
                this.tmsOpRecup,
                this.tmsVisita,
                this.tmsScore});

                this.tmsSolicitud.Text = "1. Solicitud";
                this.tmsActaApro.Text = "2. Acta Aprobacion";
                this.tmsCualitativo.Text = "3. Cualitativo";
                this.tmsPropuesta.Text = "4. Propuesta";
                this.tmsEEFF.Text = "5. EEFF";
                this.tmsHojaTrabajo.Text = "6. Hoja de Trabajo";
                this.tmsFlujoCaja.Text = "7. Flujo de Caja";
                this.tmsOpRiesgos.Text = "8. Op. Riesgos";
                this.tmsOpRecup.Text = "9. Op. Recup.";
                this.tmsVisita.Text = "10. Visita";
                this.tmsScore.Text = "11. Score";

            }
            else
            {
                this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                    this.tmsCualitativo,
                    this.tmsPropuesta,
                    this.tmsEEFF,
                    this.tmsHojaTrabajo,
                    this.tmsFlujoCaja,
                    this.tmsVisita,
                    this.tmsScore});

                this.tmsCualitativo.Text = "1. Cualitativo";
                this.tmsPropuesta.Text = "2. Propuesta";
                this.tmsEEFF.Text = "3. EEFF";
                this.tmsHojaTrabajo.Text = "4. Hoja de Trabajo";
                this.tmsFlujoCaja.Text = "5. Flujo de Caja";
                this.tmsVisita.Text = "6. Visita";
                this.tmsScore.Text = "7. Score";

            }
        
        }
        private void obtenerCabeceras2()
        {
            if (idDocumentacion == 1)
            {
                this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                        this.tmsSolicitud,
                        this.tmsActaApro,
                        this.tmsPropuesta,
                        this.tmsOpRiesgos,
                        this.tmsOpRecup,
                        this.tmsVisita,
                        this.tmsScore});

                this.tmsSolicitud.Text = "1. Solicitud";
                this.tmsActaApro.Text = "2. Acta de Aprobación";
                this.tmsPropuesta.Text = "3. Propuesta";
                this.tmsOpRiesgos.Text = "4. Op. Riesgos";
                this.tmsOpRecup.Text = "5. Op. Recuperaciones";
                this.tmsVisita.Text = "6. Visita";
                this.tmsScore.Text = "7. Score";
                
            }
            else
            {

                this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                    this.tmsPropuesta,
                    this.tmsVisita,
                    this.tmsScore});

                this.tmsPropuesta.Text = "1. Propuesta";
                this.tmsVisita.Text = "2. Visita";
                this.tmsScore.Text = "3. Score";
            }
        }
        #endregion

        #region Eventos
        private void tmsCualitativo_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = true;
            this.objServicioImp.ImpEvalCualitativa();
            this.panel1.Visible = false;
        }

        private void tmsPropuesta_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = true;
            this.objServicioImp.ImpPropuestaEval();
            this.panel1.Visible = false;
        }

        private void tmsEEFF_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = true;
            this.objServicioImp.ImpEEFF();
            this.panel1.Visible = false;
        }

        private void tmsHojaTrabajo_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = true;
            this.objServicioImp.ImpHojaTrabajo();
            this.panel1.Visible = false;
        }

        private void tmsFlujoCaja_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = true;
            this.objServicioImp.ImpFlujoCaja();
            this.panel1.Visible = false;
        }

        private void tmsSolicitud_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = true;
            this.objServicioImp.ImpSolicitud();
            this.panel1.Visible = false;
        }

        private void tmsActaApro_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = true;
            this.objServicioImp.ImpActaAprob();
            this.panel1.Visible = false;
        }

        private void tmsOpRiesgos_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = true;
            this.objServicioImp.ImpOpRiesgos();
            this.panel1.Visible = false;

        }

        private void tmsOpRecup_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = true;
            this.objServicioImp.ImpOpRecu();
            this.panel1.Visible = false;
        }

        private void tmsAproRapida_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = true;
            this.objServicioImp.ImpAproRapida();
            this.panel1.Visible = false;
        }

        private void tmsVisita_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = true;
            this.objServicioImp.VerVisita();
            this.panel1.Visible = false;
        }

        private void tmsScore_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = true;
            this.objServicioImp.impScore();
            this.panel1.Visible = false;
        }

        #endregion
    }
}
