using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using System.Collections;
using GEN.CapaNegocio;
using GEN.Funciones;
using GEN.BotonesBase;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using GEN.Servicio;

namespace CRE.Presentacion
{
    public partial class frmAprobacionReglasNoContempladas : frmBase
    {

        #region Variables Globales
        //        private string[] cEstadosBotones = new string[] { "Sin Estado", "Solicitado", "Espera", "Autorizado", "Aprobado", "Denegado" };
        //        /*                                                 0                 1               2           3           4           5 */
        private string[] cEstadosBotones = new string[] { "Denegado", "Aprobado", "Solicitado", "Espera", "Sin Estado", "Autorizado" };
        /*                                                   0            1            2           3         4            5   */

        DataGridViewRow row = null;
        private Hashtable hashtable = new Hashtable();
        private string cVer = "Ver";
        private int idNivelUsuario = 2;
        private int idNivelAprobacion = 0;//5; // puede ser 4 o 5
        private int idEstadoActual = 0; //puede ser 1,2,(3,4),5,6
        DataTable dtReglaSolicitud = new DataTable();
        DataTable dtSolicitud2 = new DataTable();
        DataTable dtSolicitud3 = new DataTable();
        DataTable dtSolicitud4 = new DataTable();
        DataTable dtResultado = new DataTable();
        clsCNSolicitud obCNSolicitud = new clsCNSolicitud();
        int idUsuario = clsVarGlobal.User.idUsuario;
        int idAgencia = clsVarGlobal.nIdAgencia;
        int idPerfil = clsVarGlobal.PerfilUsu.idPerfil;
        int idSoli = 0;
        int idReglaNoContemplada = 0;
        int nDecAsesor = 2;
        int nDecJOficina = 4;
        int nDecJCreditos = 4;
        int nDecGRegional = 4;
        int nDecGNegocios = 4;
        int nDecGGeneral = 4;
        int nDecEvalCredi = 4;
        string cTituloMsjes = "Aprobación Denegación de Reglas No Contempladas";
        private const int maximumSingleLineTooltipLength = 200;
        private string cIdPerfilAsesor;
        private string cIdPerfilNiveles;
        private string cIdPerfilConAutorizacion;
        private string cIdPerfilGNegocios;
        private string cIdPerfilGGeneral;

        String[] cArrayIdAsesor;
        String[] cArrayIdNiveles;
        String[] cArrayIdConAutorizacion;
        String[] cArrayIdGNegocios;
        String[] cArrayIdGGeneral;

        int[] nArrayIdAsesor;
        int[] nArrayIdNiveles;
        int[] nArrayIdConAutorizacion;
        int[] nArrayIdGNegocios;
        int[] nArrayIdGGeneral;


        private int nidReglaVisita;
        
        /** CREDITO JORNALERO - CANAL DE APROBACION DEL GERENTE REGIONAL **/
        private frmCreJorInjCanalAprobGR frmCanalGr;
        private clsExpedienteLinea clsProcesoExp = new clsExpedienteLinea();
        #endregion

        #region Eventos



        public frmAprobacionReglasNoContempladas()
        {

            /******************** Convierte a partir de si_finVaribale->perfiles asesores, y jefes ***************************/
            cIdPerfilAsesor = clsVarApl.dicVarGen["cIdPerfilAsesor"];
            cIdPerfilNiveles = clsVarApl.dicVarGen["cIdPerfilNiveles"];
            cIdPerfilConAutorizacion = clsVarApl.dicVarGen["cIdPerfilConAutorizacion"];
            cIdPerfilGNegocios = clsVarApl.dicVarGen["cIdPerfilGNegocios"];
            cIdPerfilGGeneral = clsVarApl.dicVarGen["cIdPerfilGGeneral"];


            cArrayIdAsesor = cIdPerfilAsesor.Split(',');
            nArrayIdAsesor = Array.ConvertAll<string, int>(cArrayIdAsesor, int.Parse);

            cArrayIdNiveles = cIdPerfilNiveles.Split(',');
            nArrayIdNiveles = Array.ConvertAll<string, int>(cArrayIdNiveles, int.Parse);

            cArrayIdConAutorizacion = cIdPerfilConAutorizacion.Split(',');
            nArrayIdConAutorizacion = Array.ConvertAll<string, int>(cArrayIdConAutorizacion, int.Parse);

            cArrayIdGNegocios = cIdPerfilGNegocios.Split(',');
            nArrayIdGNegocios = Array.ConvertAll<string, int>(cArrayIdGNegocios, int.Parse);

            cArrayIdGGeneral = cIdPerfilGGeneral.Split(',');
            nArrayIdGGeneral = Array.ConvertAll<string, int>(cArrayIdGGeneral, int.Parse);

            /*** Numero de la Regla de Visita*****/
            nidReglaVisita = Convert.ToInt32(clsVarApl.dicVarGen["nIdReglaVisita"]);
            /****************************************************************************************************/
            cargarTodo(1);
            this.lblEvalCred.Visible = false;
            this.btnEvalCre.Visible = false;
        }
        private void btnJefeOf_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Jefe de of");
            int idNivAprob = 2;
            cargarSustento(idReglaNoContemplada, idNivAprob);
        }
        private void btnGRegional_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("gerente regional");
            int idNivAprob = 3;
            cargarSustento(idReglaNoContemplada, idNivAprob);
        }
        private void btnJefeCred_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("jefe de creditos");
            int idNivAprob = 4;
            cargarSustento(idReglaNoContemplada, idNivAprob);
        }
        private void btnGNegocios_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("gerente de negocios");
            int idNivAprob = 5;
            cargarSustento(idReglaNoContemplada, idNivAprob);
        }
        private void btnGGeneral_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("gerente general");
            int idNivAprob = 6;
            cargarSustento(idReglaNoContemplada, idNivAprob);
        }
        private void btnEvalCre_Click(object sender, EventArgs e)
        {
            int idNivAprob = 7;
            cargarSustento(idReglaNoContemplada, idNivAprob);
        }

        private void btnAprobar1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtBase4.Text.Trim()))
            {
                MessageBox.Show("Debe de escribir un sustento válido.",
                       cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                string cSustento = Convert.ToString(this.txtBase4.Text.Trim());

                if (idNivelAprobacion == 5 || idNivelAprobacion == 7)
                {
                    if (cSustento == recuperarSustento(1) || cSustento == recuperarSustento(2) || cSustento == recuperarSustento(3)
                            || cSustento == recuperarSustento(4))
                    {
                        MessageBox.Show("Debe de escribir un sustento propio.",
                           cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.txtBase4.Enabled = true;
                        this.txtBase4.Text = "";
                        this.txtBase4.Focus();
                        this.txtBase20.Text = "";
                    }
                    else
                    {
                        aprobarDenegar(1);
                        this.txtBase4.Enabled = false;
                        this.btnAprobar1.Enabled = false;
                        this.btnDenegar1.Enabled = false;
                        cargarTodo(2);
                    }
                }
                else if (idNivelAprobacion == 6)
                {
                    if (cSustento == recuperarSustento(1) || cSustento == recuperarSustento(2) || cSustento == recuperarSustento(3)
                            || cSustento == recuperarSustento(4) || cSustento == recuperarSustento(5))
                    {
                        MessageBox.Show("Debe de escribir un sustento propio.",
                           cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.txtBase4.Enabled = true;
                        this.txtBase4.Text = "";
                        this.txtBase4.Focus();
                        this.txtBase20.Text = "";
                    }
                    else
                    {
                        aprobarDenegar(1);
                        this.txtBase4.Enabled = false;
                        this.btnAprobar1.Enabled = false;
                        this.btnDenegar1.Enabled = false;
                        cargarTodo(2);
                    }

                }
            }

        }
        private void btnDenegar1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtBase4.Text.Trim()))
            {
                MessageBox.Show("Debe de escribir un sustento válido.",
                       cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                string cSustento = Convert.ToString(this.txtBase4.Text.Trim());

                if (idNivelAprobacion == 5 || idNivelAprobacion == 7)
                {
                    if (cSustento == recuperarSustento(1) || cSustento == recuperarSustento(2) || cSustento == recuperarSustento(3)
                            || cSustento == recuperarSustento(4))
                    {
                        MessageBox.Show("Debe de escribir un sustento propio.",
                           cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.txtBase4.Enabled = true;
                        this.txtBase4.Text = "";
                        this.txtBase4.Focus();
                        this.txtBase20.Text = "";
                    }
                    else
                    {
                        aprobarDenegar(0);
                        this.txtBase4.Enabled = false;
                        this.btnAprobar1.Enabled = false;
                        this.btnDenegar1.Enabled = false;
                        cargarTodo(2);
                    }
                }
                else if (idNivelAprobacion == 6)
                {
                    if (cSustento == recuperarSustento(1) || cSustento == recuperarSustento(2) || cSustento == recuperarSustento(3)
                            || cSustento == recuperarSustento(4) || cSustento == recuperarSustento(5))
                    {
                        MessageBox.Show("Debe de escribir un sustento propio.",
                           cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.txtBase4.Enabled = true;
                        this.txtBase4.Text = "";
                        this.txtBase4.Focus();
                        this.txtBase20.Text = "";

                    }
                    else
                    {
                        aprobarDenegar(0);
                        this.txtBase4.Enabled = false;
                        this.btnAprobar1.Enabled = false;
                        this.btnDenegar1.Enabled = false;
                        cargarTodo(2);
                    }

                }
            }
        }
        private string recuperarSustento(int idNivelApro)
        {
            dtSolicitud3 = obCNSolicitud.cargarSustentoSolicitudRNC(idReglaNoContemplada, idNivelApro);

            if (dtSolicitud3.Rows.Count < 1)
            {
                string cSustentoSave = "SinComentario";
                return cSustentoSave;
            }
            else
            {
                string cSustentoSave = Convert.ToString(this.dtSolicitud3.Rows[0]["cSustento"]);
                return cSustentoSave;
            }
        }
        private void aprobarDenegar(int idEstado)
        {
            if (String.IsNullOrEmpty(this.txtBase4.Text.Trim()))
            {
                MessageBox.Show("Debe de escribir un sustento válido.",
                       cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                string cSustento = Convert.ToString(this.txtBase4.Text.Trim());

                if (idNivelAprobacion == 5 || idNivelAprobacion==7)
                {
                    //  if (cSustento == recuperarSustento(1) || cSustento == recuperarSustento(2) || cSustento == recuperarSustento(3)
                    //          || cSustento == recuperarSustento(4))
                    //  {
                    //      MessageBox.Show("Debe de escribir un sustento propio.",
                    //         cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //  }
                    //  else
                    //  {
                    guardarSustento(idEstado, cSustento);
                    // }
                }
                else if (idNivelAprobacion == 6)
                {
                    // if (cSustento == recuperarSustento(1) || cSustento == recuperarSustento(2) || cSustento == recuperarSustento(3)
                    //         || cSustento == recuperarSustento(4) || cSustento == recuperarSustento(5))
                    // {
                    //     MessageBox.Show("Debe de escribir un sustento propio.",
                    //        cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // }
                    // else
                    // {
                    guardarSustento(idEstado, cSustento);
                    // }

                }
            }
        }
        private void guardarSustento(int idEstado, string cSustento)
        {

            if (idEstado == 1)
            {
                if (idPerfil.In(nArrayIdConAutorizacion))//(idPerfil == 34 || idPerfil == 85 || idPerfil == 75 || idPerfil == 81)
                {
                    idEstado = 5;
                }
                else
                {
                    if (idPerfil.In(nArrayIdGNegocios))//71
                    {
                        if (idNivelAprobacion == 5)
                        {
                            idEstado = 1;
                        }
                        if (idNivelAprobacion == 6)
                        {
                            idEstado = 5;
                        }
                    }
                    if (idPerfil.In(nArrayIdGGeneral))//74
                    {
                        if (idNivelAprobacion == 6)
                        {
                            idEstado = 1;
                        }
                    }
                }
            }

            clsDBResp objDbResp;
            if (idNivelAprobacion == 7)
            {
                objDbResp = new clsCNSolicitud().CNAprobacionesSolicitudRNC(idReglaNoContemplada, cSustento, 7, idEstado, idUsuario);
            }
            else
            {
                objDbResp = new clsCNSolicitud().CNAprobacionesSolicitudRNC(idReglaNoContemplada, cSustento, idEstadoActual + 1, idEstado, idUsuario);
            }
           
            if (objDbResp.nMsje == 0)
            {

                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information); //ACEPTADA SOLICITUD

            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning); // LA SOLICITUD YA ESTA APROBADA / DENEGADA
            }

            if (idNivelAprobacion == 7 || idEstado == 1)
            {
                /*  Guardar Expedientes - Grupo Reglas No Contempladas  */
                clsProcesoExp.guardarCopiaExpediente("Aprobacion de Exepciones No Contempladas", idSoli, this);
            }

        }
        private void formatoGridSolicitudes()
        {
            foreach (DataGridViewColumn column in this.dtgBase1.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgBase1.Columns["idSolicitud"].Width = 10;
            dtgBase1.Columns["cNomAse"].Width = 100;
            dtgBase1.Columns["cNombreAge"].Width = 80;
            dtgBase1.Columns["idNivelActual"].Width = 10;
            dtgBase1.Columns["idNivelAprobacion"].Width = 10;
            dtgBase1.Columns["dFechaReg"].Width = 20;
            dtgBase1.Columns["dFechaMod"].Width = 20;


            dtgBase1.Columns["idSolicitud"].Visible = true;
            dtgBase1.Columns["cNomAse"].Visible = true;
            dtgBase1.Columns["cNombreAge"].Visible = true;
            dtgBase1.Columns["idNivelActual"].Visible = true;
            dtgBase1.Columns["idNivelAprobacion"].Visible = true;
            dtgBase1.Columns["dFechaReg"].Visible = true;
            dtgBase1.Columns["dFechaMod"].Visible = true;

            dtgBase1.Columns["idSolicitud"].HeaderText = "N° de Solicitud";
            dtgBase1.Columns["cNomAse"].HeaderText = "Asesor";
            dtgBase1.Columns["cNombreAge"].HeaderText = "Agencia";
            dtgBase1.Columns["idNivelActual"].HeaderText = "Niv. Act.";
            dtgBase1.Columns["idNivelAprobacion"].HeaderText = "Niv. Apro.";
            dtgBase1.Columns["dFechaReg"].HeaderText = "F.Registro";
            dtgBase1.Columns["dFechaMod"].HeaderText = "F.Modificación";




        }
        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            Reporte();
        }
        private void btnAsesor_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("asesor");
            int idNivAprob = 1;
            cargarSustento(idReglaNoContemplada, idNivAprob);

        }
        private void dtgBase1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgBase1.SelectedRows.Count != 0)
            {
                //DataGridViewRow 
                row = this.dtgBase1.SelectedRows[0];
                string idSolicitud = row.Cells["idSolicitud"].Value.ToString();
                string idNivAprob = row.Cells["idNivelAprobacion"].Value.ToString();
                string idEstActual = row.Cells["idNivelActual"].Value.ToString();
                string idReglaNC = row.Cells["idReglaNoContemplada"].Value.ToString();

                idNivelAprobacion = Convert.ToInt32(idNivAprob);
                idEstadoActual = Convert.ToInt32(idEstActual);
                idSoli = Convert.ToInt32(idSolicitud);
                idReglaNoContemplada = Convert.ToInt32(idReglaNC);
                cargarDatosSolicitud();
                cargarLblBtn(idReglaNoContemplada);
                procesarEstado();
                cargarBtn(1);

                this.frmCanalGr = new frmCreJorInjCanalAprobGR(
                    this.idSoli,
                    Convert.ToInt32(row.Cells["idRegla"].Value),
                    this.idReglaNoContemplada,
                    ref this.btnAprobar1,
                    ref this.btnDenegar1,
                    ref this.lblJefeCred,
                    ref this.lblGNegocios,
                    ref this.btnJefeCred,
                    ref this.btnGNegocios
                    );
            }
        }
        private void btnAsesor_MouseHover(object sender, EventArgs e)
        {
            toolTip1.ToolTipTitle = "Sustento del Asesor";
        }
        private void btnJefeOf_MouseHover(object sender, EventArgs e)
        {
            toolTip1.ToolTipTitle = "Sustento del Jefe de oficina";
        }
        private void btnGRegional_MouseHover(object sender, EventArgs e)
        {
            toolTip1.ToolTipTitle = "Sustento del Gerente Regional";
        }
        private void btnGNegocios_MouseHover(object sender, EventArgs e)
        {
            toolTip1.ToolTipTitle = "Sustento del Gerente de Negocios";
        }
        private void btnGGeneral_MouseHover(object sender, EventArgs e)
        {
            toolTip1.ToolTipTitle = "Sustento del Gerente General";
        }
        private void btnJefeCred_MouseHover(object sender, EventArgs e)
        {
            toolTip1.ToolTipTitle = "Sustento del Gerente General";
        }
        private void btnEvalCre_MouseHover(object sender, EventArgs e)
        {
            toolTip1.ToolTipTitle = "Sustento del Evaluador de Créditos";
        }
        private void btnAnular1_Click(object sender, EventArgs e)
        {

            clsDBResp objDbResp = new clsCNSolicitud().anularExcepcionNC(idReglaNoContemplada, clsVarApl.dicVarGen["dFechaAct"], idUsuario);
            if (objDbResp.nMsje == 0)
            {

                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information); //ACEPTADA SOLICITUD
                cargarTodo(2);

            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning); // LA SOLICITUD YA ESTA APROBADA / DENEGADA
            }

        }
        #endregion

        #region Metodos
        private void addHashtable()
        {
            hashtable.Add("Asesor", "");
            hashtable.Add("jefeOficina", "");
            hashtable.Add("jefeCreditos", "");
            hashtable.Add("gerenteRegional", "");
            hashtable.Add("gerenteNegocios", "");
            hashtable.Add("gerenteGeneral", "");
            hashtable.Add("evaluadorCreditos", "");

        }
        private void procesarEstado()
        {

            switch (idEstadoActual)
            {
                case 1:
                    hashtable["Asesor"] = cEstadosBotones[nDecAsesor];
                    hashtable["jefeOficina"] = cEstadosBotones[nDecJOficina];
                    hashtable["jefeCreditos"] = cEstadosBotones[nDecGRegional];
                    hashtable["gerenteRegional"] = cEstadosBotones[nDecJCreditos];
                    hashtable["gerenteNegocios"] = cEstadosBotones[nDecGNegocios];
                    hashtable["gerenteGeneral"] = cEstadosBotones[nDecGGeneral];
                    hashtable["evaluadorCreditos"] = cEstadosBotones[nDecEvalCredi];
                    break;
                case 2:
                    hashtable["Asesor"] = cEstadosBotones[nDecAsesor];
                    hashtable["jefeOficina"] = cEstadosBotones[nDecJOficina];
                    hashtable["jefeCreditos"] = cEstadosBotones[nDecGRegional];
                    hashtable["gerenteRegional"] = cEstadosBotones[nDecJCreditos];
                    hashtable["gerenteNegocios"] = cEstadosBotones[nDecGNegocios];
                    hashtable["gerenteGeneral"] = cEstadosBotones[nDecGGeneral];
                    break;
                case 3:
                    hashtable["Asesor"] = cEstadosBotones[nDecAsesor];
                    hashtable["jefeOficina"] = cEstadosBotones[nDecJOficina];
                    hashtable["jefeCreditos"] = cEstadosBotones[nDecGRegional];
                    hashtable["gerenteRegional"] = cEstadosBotones[nDecJCreditos];
                    hashtable["gerenteNegocios"] = cEstadosBotones[nDecGNegocios];
                    hashtable["gerenteGeneral"] = cEstadosBotones[nDecGGeneral];
                    break;
                case 4:
                    hashtable["Asesor"] = cEstadosBotones[nDecAsesor];
                    hashtable["jefeOficina"] = cEstadosBotones[nDecJOficina];
                    hashtable["jefeCreditos"] = cEstadosBotones[nDecGRegional];
                    hashtable["gerenteRegional"] = cEstadosBotones[nDecJCreditos];
                    hashtable["gerenteNegocios"] = cEstadosBotones[nDecGNegocios];
                    hashtable["gerenteGeneral"] = cEstadosBotones[nDecGGeneral];
                    break;
                case 5:
                    hashtable["Asesor"] = cEstadosBotones[nDecAsesor];
                    hashtable["jefeOficina"] = cEstadosBotones[nDecJOficina];
                    hashtable["jefeCreditos"] = cEstadosBotones[nDecGRegional];
                    hashtable["gerenteRegional"] = cEstadosBotones[nDecJCreditos];
                    hashtable["gerenteNegocios"] = cEstadosBotones[nDecGNegocios];
                    hashtable["gerenteGeneral"] = cEstadosBotones[nDecGGeneral];
                    break;
                case 6:
                    hashtable["Asesor"] = cEstadosBotones[nDecAsesor];
                    hashtable["jefeOficina"] = cEstadosBotones[nDecJOficina];
                    hashtable["jefeCreditos"] = cEstadosBotones[nDecGRegional];
                    hashtable["gerenteRegional"] = cEstadosBotones[nDecJCreditos];
                    hashtable["gerenteNegocios"] = cEstadosBotones[nDecGNegocios];
                    hashtable["gerenteGeneral"] = cEstadosBotones[nDecGGeneral];
                    break;
                case 7:
                    hashtable["Asesor"] = cEstadosBotones[nDecAsesor];
                    hashtable["evaluadorCreditos"] = cEstadosBotones[nDecEvalCredi];
                    break;

                default:
                    break;
            }
            this.btnAsesor.Text = hashtable["Asesor"].ToString();
            this.btnJefeOf.Text = hashtable["jefeOficina"].ToString();
            this.btnJefeCred.Text = hashtable["jefeCreditos"].ToString();
            this.btnGRegional.Text = hashtable["gerenteRegional"].ToString();
            this.btnGNegocios.Text = hashtable["gerenteNegocios"].ToString();
            this.btnGGeneral.Text = hashtable["gerenteGeneral"].ToString();
            this.btnEvalCre.Text = hashtable["evaluadorCreditos"].ToString();
        }
        private void mostrarGerente()
        {
            if (idNivelAprobacion == 5)
            {
                this.btnGGeneral.Enabled = false;
                this.lblGGeneral.Enabled = false;
                this.btnGGeneral.Visible = false;
                this.lblGGeneral.Visible = false;
            }
            else
            {
                this.btnGGeneral.Enabled = true;
                this.lblGGeneral.Enabled = true;
                this.btnGGeneral.Visible = true;
                this.lblGGeneral.Visible = true;
            }

        }
        private void mostrarTooltip()
        {
            //string cTexto = "En el ejemplo de código siguiente se crea una instancia de la ToolTip clase 20 3 y la asocia con el Form que se creó la instancia. A continuación, el código inicializa las propiedades de retraso AutoPopDelay, InitialDelay, y ReshowDelay. Además la instancia de la ToolTip clase establece la ShowAlways propiedad true para habilitar el texto ";

            string cTexto = "Al hacer Click en el Botón podrás ver el sustento del Asesor de Negocios.";
            string cTexto1 = "Al hacer Click en el Botón podrás ver el sustento del Jefe de Oficina.";
            string cTexto2 = "Al hacer Click en el Botón podrás ver el sustento del Gerente Regional.";
            string cTexto3 = "Al hacer Click en el Botón podrás ver el sustento del Jefe de Créditos.";
            string cTexto4 = "Al hacer Click en el Botón podrás ver el sustento del Gerente de Negocios.";
            string cTexto5 = "Al hacer Click en el Botón podrás ver el sustento del Gerente General.";
            string cTexto6 = "Al hacer Click en el Botón podrás ver el sustento del Evaluador de Créditos.";
            
            cTexto = AddNewLinesForTooltip(cTexto);
            cTexto1 = AddNewLinesForTooltip(cTexto1);
            cTexto2 = AddNewLinesForTooltip(cTexto2);
            cTexto3 = AddNewLinesForTooltip(cTexto3);
            cTexto4 = AddNewLinesForTooltip(cTexto4);
            cTexto5 = AddNewLinesForTooltip(cTexto5);
            cTexto6 = AddNewLinesForTooltip(cTexto6);

            toolTip1.SetToolTip(this.btnAsesor, cTexto);
            toolTip1.SetToolTip(this.btnJefeOf, cTexto1);
            toolTip1.SetToolTip(this.btnGRegional, cTexto2);
            toolTip1.SetToolTip(this.btnJefeCred, cTexto3);
            toolTip1.SetToolTip(this.btnGNegocios, cTexto4);
            toolTip1.SetToolTip(this.btnGGeneral, cTexto5);
            toolTip1.SetToolTip(this.btnEvalCre, cTexto6);


        }
        private static string AddNewLinesForTooltip(string text)
        {
            if (text.Length < maximumSingleLineTooltipLength)
                return text;
            int lineLength = (int)Math.Sqrt((double)text.Length) * 2;
            StringBuilder sb = new StringBuilder();
            int currentLinePosition = 0;
            for (int textIndex = 0; textIndex < text.Length; textIndex++)
            {
                // If we have reached the target line length and the next 
                // character is whitespace then begin a new line.
                if (currentLinePosition >= lineLength &&
                      char.IsWhiteSpace(text[textIndex]))
                {
                    sb.Append(Environment.NewLine);
                    currentLinePosition = 0;
                }
                // If we have just started a new line, skip all the whitespace.
                if (currentLinePosition == 0)
                    while (textIndex < text.Length && char.IsWhiteSpace(text[textIndex]))
                        textIndex++;
                // Append the next character.
                if (textIndex < text.Length)
                    sb.Append(text[textIndex]);

                currentLinePosition++;
            }
            return sb.ToString();
        }
        private void cargarLblBtn(int idRNC)
        {
            //nDecAsesor = cargarLblBtn1(idRNC, 1);
            nDecJOficina = cargarLblBtn1(idRNC, 2);
            nDecJCreditos = cargarLblBtn1(idRNC, 3);
            nDecGRegional = cargarLblBtn1(idRNC, 4);
            nDecGNegocios = cargarLblBtn1(idRNC, 5);
            nDecGGeneral = cargarLblBtn1(idRNC, 6);
            nDecEvalCredi = cargarLblBtn1(idRNC, 7);

        }
        private int cargarLblBtn1(int idRNC, int idNivelAprob)
        {
            dtSolicitud4 = obCNSolicitud.cargarLblBtnSolicitudRNC(idRNC, idNivelAprob);//consulta solicitud

            if (dtSolicitud4.Rows.Count < 1)
            {
                return 3; // -- espera
            }
            else
            {

                string cIdAprob = Convert.ToString(this.dtSolicitud4.Rows[0]["lAprobDesaprob"]);
                int idAprob = 0; // false

                if (String.IsNullOrEmpty(cIdAprob))
                {
                    idAprob = 4; // -- sin estado
                    return idAprob;
                }
                else
                {
                    idAprob = Convert.ToInt32(cIdAprob); // false -- denegado
                    return idAprob;
                }
            }
        }
        private void cargarDatos()
        {

            dtReglaSolicitud = obCNSolicitud.listarBandejaAprobDenegSolicitud(idUsuario, idAgencia, idPerfil);
            dtgBase1.DataSource = dtReglaSolicitud;
            formatoGridSolicitudes();
        }
        private void cargarDatosSolicitud()
        {
            dtSolicitud2 = obCNSolicitud.listarBandejaDatosSolicitud(idSoli);//consulta solicitud

            this.txtBase1.Text = Convert.ToString(this.dtSolicitud2.Rows[0]["idRegla"]);
            this.txtBase3.Text = Convert.ToString(this.dtSolicitud2.Rows[0]["cMensajeError"]);
            this.txtBase5.Text = Convert.ToString(this.dtSolicitud2.Rows[0]["idCli"]);
            this.txtBase2.Text = Convert.ToString(this.dtSolicitud2.Rows[0]["cNombre"]);
            this.txtBase6.Text = Convert.ToString(this.dtSolicitud2.Rows[0]["cDocumentoID"]);
            this.txtBase7.Text = Convert.ToString(this.dtSolicitud2.Rows[0]["cOperacion"]);
            this.txtBase8.Text = Convert.ToString(this.dtSolicitud2.Rows[0]["cMoneda"]);
            this.txtBase9.Text = Convert.ToString(this.dtSolicitud2.Rows[0]["nCuotas"]);
            this.txtBase10.Text = Convert.ToString(this.dtSolicitud2.Rows[0]["cDescripTipoPeriodo"]);
            this.txtBase11.Text = Convert.ToString(this.dtSolicitud2.Rows[0]["cProducto"]);
            this.txtBase13.Text = Convert.ToString(this.dtSolicitud2.Rows[0]["nCapitalSolicitado"]);
            this.txtBase12.Text = Convert.ToString(this.dtSolicitud2.Rows[0]["nPlazoCuota"]);
            this.txtBase14.Text = Convert.ToString(this.dtSolicitud2.Rows[0]["nCuotasGracia"]);


            if (Convert.ToInt32(dtSolicitud2.Rows[0]["idRegla"].ToString()) == nidReglaVisita)
            {
//                MessageBox.Show("Holiboi");
                ocultarBotones(true);
                procesarEstado();
                mostrarTooltip();
                inhabilitarBtnMensajes(1);//habilita ñlos botones
                if (idPerfil.In(nArrayIdAsesor))//34//115
                {
                    inhabilitarBtn(0);
                }
                else if (idPerfil.In(nArrayIdNiveles))//(idPerfil == 85 || idPerfil == 75 || idPerfil == 81 || idPerfil == 71 || idPerfil == 74)
                {
                    inhabilitarBtn(1);
                }

            }
            else
            {

                /** Vuelve a cargar los botones de estado ***/
                ocultarBotones(false);
                mostrarGerente();
                procesarEstado();
                mostrarTooltip();
                inhabilitarBtnMensajes(1);//habilita ñlos botones
                if (idPerfil.In(nArrayIdAsesor))//34//115
                {
                    inhabilitarBtn(0);
                }
                else if (idPerfil.In(nArrayIdNiveles))//(idPerfil == 85 || idPerfil == 75 || idPerfil == 81 || idPerfil == 71 || idPerfil == 74)
                {
                    inhabilitarBtn(1);
                }

                borrarDatosSustento();
            }
        }
        private void ocultarBotones(bool idOcultar)
        {
            if (idOcultar)
            {

                this.btnJefeOf.Visible = false;
                this.btnGRegional.Visible = false;
                this.btnJefeCred.Visible = false;
                this.btnGNegocios.Visible = false;
                this.btnGGeneral.Visible = false;
                
                this.lblJefeOf.Visible = false;
                this.lblGRegional.Visible = false;
                this.lblJefeCred.Visible = false;
                this.lblGNegocios.Visible = false;
                this.lblGGeneral.Visible = false;
                this.lblGGeneral.Visible = false;

                this.btnEvalCre.Visible = true;
                this.lblEvalCred.Visible = true;
                this.btnAsesor.Visible = true;
                this.lblAsesor.Visible = true;
                this.btnAsesor.Enabled = true;
            }
            else
            {
                this.btnJefeOf.Visible = true;
                this.btnGRegional.Visible = true;
                this.btnJefeCred.Visible = true;
                this.btnGNegocios.Visible = true;
                this.btnGGeneral.Visible = true;
                this.btnEvalCre.Visible = false;

                this.lblJefeOf.Visible = true;
                this.lblGRegional.Visible = true;
                this.lblJefeCred.Visible = true;
                this.lblGNegocios.Visible = true;
                this.lblGGeneral.Visible = true;
                this.lblEvalCred.Visible = false;
            }


        }
        private void borrarDatosSustento()
        {
            this.txtBase4.Text = null;
            this.txtBase20.Text = null;
            this.txtBase20.Enabled = false;
        }
        private void inhabilitarTxt()
        {
            this.txtBase1.Enabled = false;
            this.txtBase3.Enabled = false;
            this.txtBase5.Enabled = false;
            this.txtBase2.Enabled = false;
            this.txtBase6.Enabled = false;
            this.txtBase7.Enabled = false;
            this.txtBase8.Enabled = false;
            this.txtBase9.Enabled = false;
            this.txtBase10.Enabled = false;
            this.txtBase11.Enabled = false;
            this.txtBase13.Enabled = false;
            this.txtBase12.Enabled = false;
            this.txtBase14.Enabled = false;
            this.txtBase20.Enabled = false;
            this.txtBase4.Enabled = false;

        }
        private void inhabilitarBtn(int idEst)
        {
            if (idEst == 0)
            {
                this.btnAprobar1.Enabled = false;
                this.btnDenegar1.Enabled = false;
                this.btnAnular1.Visible = true;
            }
            else if (idEst == 1)
            {
                this.btnAprobar1.Enabled = true;
                this.btnDenegar1.Enabled = true;
                this.btnAnular1.Visible = false;
                this.btnAnular1.Enabled = false;

            }
        }
        private void inhabilitarBtnMensajes(int idEst)
        {
            if (idEst == 0)
            {
                this.btnAsesor.Enabled = false;
                this.btnJefeOf.Enabled = false;
                this.btnGRegional.Enabled = false;
                this.btnJefeCred.Enabled = false;
                this.btnGNegocios.Enabled = false;
                this.btnGGeneral.Enabled = false;

            }
            else if (idEst == 1)
            {
                this.btnAsesor.Enabled = true;
                this.btnJefeOf.Enabled = true;
                this.btnGRegional.Enabled = true;
                this.btnJefeCred.Enabled = true;
                this.btnGNegocios.Enabled = true;
                this.btnGGeneral.Enabled = true;
            }

        }
        private void cargarSustento(int idRNC, int idNivelAprob)
        {
            dtSolicitud3 = obCNSolicitud.cargarSustentoSolicitudRNC(idRNC, idNivelAprob);//consulta solicitud
            if (dtSolicitud3.Rows.Count < 1)
            {
                if (idPerfil.In(nArrayIdAsesor))//34,115
                {
                    return;
                }
                else if (idPerfil.In(nArrayIdNiveles))//(idPerfil == 85 || idPerfil == 75 || idPerfil == 81 || idPerfil == 71 || idPerfil == 74)
                {
                    this.txtBase20.Enabled = false;
                    this.txtBase4.Enabled = true;
                    borrarDatosSustento();
                }

            }
            else
            {
                this.txtBase20.Enabled = false;
                this.txtBase4.Enabled = false;
                this.txtBase20.Text = Convert.ToString(this.dtSolicitud3.Rows[0]["cNombre"]);
                this.txtBase4.Text = Convert.ToString(this.dtSolicitud3.Rows[0]["cSustento"]);
            }
        }
        private void limpiarDatos()
        {
            dtgBase1.DataSource = null;
        }
        private void cargarBtn(int idVisible)
        {
            if (idPerfil.In(nArrayIdAsesor))//34,115
            {
                this.btnAnular1.Visible = true;
                if (idVisible == 0)
                {
                    this.btnAnular1.Enabled = false;
                }
                else
                    this.btnAnular1.Enabled = true;

            }
            else if (idPerfil.In(nArrayIdNiveles))//(idPerfil == 85 || idPerfil == 75 || idPerfil == 81 || idPerfil == 71 || idPerfil == 74)
            {
                this.btnAnular1.Visible = false;
                this.btnAnular1.Enabled = false;
            }
        }
        private void cargarTodo(int idEstado)
        {
            if (idEstado == 1)
            {
                InitializeComponent();
                mostrarGerente();
                addHashtable();
                procesarEstado();
                mostrarTooltip();
                cargarDatos();
                inhabilitarTxt();
                inhabilitarBtn(0);
                cargarBtn(0);
                inhabilitarBtnMensajes(0);
            }
            else if (idEstado == 2)
            {
                InitializeComponent();
                mostrarGerente();
                procesarEstado();
                mostrarTooltip();
                cargarDatos();
                inhabilitarTxt();
                inhabilitarBtn(0);
                cargarBtn(0);
                inhabilitarBtnMensajes(0);
            }
        }
        private void Reporte()
        {
            clsCNSolicitud cnRptRNC = new clsCNSolicitud();
            DateTime dFecOpe = clsVarGlobal.dFecSystem;
            string cNomAgen = clsVarGlobal.cNomAge;

            DataTable dtData2 = cnRptRNC.ObtenerReporteRNC(idSoli);
            DataTable dtData3 = cnRptRNC.ObtenerReporteRNC1(idSoli);


            if (dtData2.Rows.Count > 0)
            {
                List<ReportDataSource> dtsList = new List<ReportDataSource>();
                dtsList.Add(new ReportDataSource("dsSolicitud", dtData2));
                dtsList.Add(new ReportDataSource("dsSolicitud2", dtData3));

                List<ReportParameter> paramlist = new List<ReportParameter>();

                paramlist.Add(new ReportParameter("idsolicitud", idSoli.ToString(), false));
                paramlist.Add(new ReportParameter("dFecOpe", dFecOpe.ToString(), false));
                paramlist.Add(new ReportParameter("cNomAgen", cNomAgen.ToString(), false));

                string reportPath = "rptSolcitudRNC.rdlc";
                new frmReporteLocal(dtsList, reportPath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen datos para esta Solicitud No Contemplada.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        #endregion



        


    }
}
