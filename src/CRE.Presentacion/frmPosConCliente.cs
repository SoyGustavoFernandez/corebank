using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using CRE.CapaNegocio;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.Reporting.WinForms;
using EntityLayer.SentinelData;
using System.Globalization;


namespace CRE.Presentacion
{
    public partial class frmPosConCliente : frmBase
    {
        private int idClienteT = 0;
        private int idTipoDocumentoT = 0;
        private string cDocumentoIDT = String.Empty;
        private int idTipoPersonaT = 0;
        private int idClasifInternaT = 0;
        private string cClasifInternaT = String.Empty;


        clsCNCredito Credito = new clsCNCredito();
        DataTable dtLisCredxCli = new DataTable();
        DataTable dtLisDetPep = new DataTable();
        DataTable dtLisBaseNeg = new DataTable();
        DataTable dtLiberacionsBaseNeg = new DataTable();
        DataTable dtLisOferta = new DataTable();
        DataTable dtLisVacio = new DataTable();
        DataTable dResultado = new DataTable();
        DataTable dtClasificacionCliente = new DataTable();
        DataTable dtConyuge = new DataTable();
        DataTable dtHistSaldosSBS_Titular;
        ClsCNClienteExclusivo objCE = new ClsCNClienteExclusivo();
        List<TitularConyuge> objLisTituConyuge;
        clsCNIntervCre cninterviniente = new clsCNIntervCre();
        DataGridViewButtonColumn colDetalle = new DataGridViewButtonColumn();
        DataGridViewButtonColumn colSeguimiento = new DataGridViewButtonColumn();
        DataGridViewButtonColumn colOtorgar = new DataGridViewButtonColumn();

        clsApiCentralRsgExterno objCentraRsgExterno = new clsApiCentralRsgExterno();
        GEN.CapaNegocio.clsCNValidaReglasDinamicas ValidaReglasDinamicas = new GEN.CapaNegocio.clsCNValidaReglasDinamicas();
        Response objRespuesta;

        Response objRespuestaTitular;
        Response objRespuestaConyuge;

        DataSenInfBasica dataBasicoSunat;
        List<DataSenInfGenDirecc> Direcc;
        List<DataSenConBasVen> ListProtestoDeuLaboralSentinel;
        string cTipoPersona = string.Empty;
        string cSemaforoTitular = string.Empty;
        string cSemaforoConyuge = string.Empty;
        List<DataSenAvalDe> LisAvalista;//Avalista
        List<DataSenAvalPor> Listavalado;//Avalado
        List<DataSenAvalCodDeu> ListCodeuda;//Codeudor
        List<DataSenConBasSBSMicr> DetSBSMicr;
        List<DataSenConBasUtiLinCre> UtiLinCre;
        List<DataSenInfGenRepLeg> ListRepLeg;
        List<DataSenInfGenEsRepLeg> ListEsRepLegDe;
        DataTable dtMicrTitular;
        DataRow rowMicrTitular;
        DataTable dtMicrConyuge;
        DataRow rowMicrConyuge;
        DataColumn columnMicrTitular;
        DataColumn columnMicrConyuge;
        DataTable dtAvalado;
        DataColumn columnAvaladoTitular;
        DataRow rowAvaladoTitular;

        DataTable dtAvaladoConyuge;
        DataColumn columnAvaladoConyuge;
        DataRow rowAvaladoConyuge;
  
        DataTable dtDeudaTitular;
        DataColumn columnDeudaTitular;
        DataRow rowDeudaTitular;

        DataTable dtDeudaConyuge;
        DataColumn columnDeudaConyuge;
        DataRow rowDeudaConyuge;

        DataTable dtAvalistaTitular;
        DataColumn columnAvalistaTitular;
        DataRow rowAvalistaTitular;

        DataTable dtAvalistaConyuge;
        DataColumn columnAvalistaConyuge;
        DataRow rowAvalistaConyuge;

        DataTable dtBasicoSunatTitular;
        DataColumn columnBasicoSunatTitular;
        DataRow rowBasicoSunatTitular;

        DataTable dtBSunatDireccionTitular;
        DataColumn columnBSunatDireccionTitular;
        DataRow rowBSunatDireccionTitular;

        DataTable dtBSunatDireccionConyuge;
        DataColumn columnBSunatDireccionConyuge;
        DataRow rowBSunatDireccionConyuge;

        DataTable dtRlegalTitular;
        DataColumn columnRlegalTitular;
        DataRow rowRlegalTitular;

        DataTable dtRlegalConyuge;
        DataColumn columnRlegalConyuge;
        DataRow rowRlegalConyuge;

        DataTable dtBasicoSunatConyuge;
        DataColumn columnBasicoSunatConyuge;
        DataRow rowBasicoSunatConyuge;

        DataTable dtDeudaSentinelDirectaTitular;
        DataTable dtDeudaSentinelDirectaConyuge;

        DataTable dtlCredNoUtilizadaT;
        DataColumn columnlCredNoUtilizadaT;
        DataRow rowlCredNoUtilizadaT;

        DataTable dtlCredNoUtilizadaC;
        DataColumn columnlCredNoUtilizadaC;
        DataRow rowlCredNoUtilizadaC;

        DataTable dtHistorialSentinelTitular;
        DataRow rowHistorialSentinelTitular;
        DataColumn columnHistorialSentinelTitular;

        DataTable dtHistorialSentinelConyuge;
        DataRow rowHistorialSentinelConyuge;
        DataColumn columnHistorialSentinelConyuge;

        double deudaCalif0_PastelTitular;
        double deudaCalif1_PastelTitular;
        double deudaCalif2_PastelTitular;
        double deudaCalif3_PastelTitular;
        double deudaCalif4_PastelTitular;

        double deudaCalif0_PastelConyuge;
        double deudaCalif1_PastelConyuge;
        double deudaCalif2_PastelConyuge;
        double deudaCalif3_PastelConyuge;
        double deudaCalif4_PastelConyuge;

        public frmPosConCliente()
        {
            InitializeComponent();
        }

        private void frmPosConCliente_Load(object sender, EventArgs e)
        {
            colOtorgar.Name = "btnOtorgar";
            colOtorgar.HeaderText = "Otorgar";
            colOtorgar.Text = "Otorgar";
            colOtorgar.UseColumnTextForButtonValue = true;
            dtgOfertas.Columns.Add(colOtorgar);

        
            colSeguimiento.Name = "btnSeguimiento";
            colSeguimiento.HeaderText = "Seguimiento";
            colSeguimiento.Text = "Seguimiento";
            colSeguimiento.UseColumnTextForButtonValue = true;
            dtgOfertas.Columns.Add(colSeguimiento);

       
            colDetalle.Name = "btnVerDetalle";
            colDetalle.HeaderText = "Ver";
            colDetalle.Text = "Detalle";
            colDetalle.UseColumnTextForButtonValue = true;
            dtgCreditos.Columns.Add(colDetalle);

            dtLisVacio.Columns.Add("Código");
            dtLisVacio.Columns.Add("Mensaje");

            CreaTablaMicrofinanzasTitular();
            CreaTablaMicrofinanzasConyuge();
            CreaTablaAvaladoTitular();
            CreaTablaAvaladoConyuge();
            CreaTablaDeudaConyuge();
            CreaTablaDeudaTitular();
            CreaTablaAvalistaTitular();
            CreaTablaAvalistaConyuge();
            CreaTablaBasicoSunatTitular();
            CreaTablaBasicoSunatConyuge();
            CreaTablaBSunatDireccionTitular();
            CreaTablaBSunatDireccionConyuge();
            CreaTablaRLegalTitular();
            CreaTablalCredNoUtilTitular();
            CreaTablalCredNoUtilConyuge();
            CreaTablaRLegalConyuge();
            CreaTablaHistorialSentinelTitular();
            CreaTablaHistorialSentinelConyuge();
            lblClasifInt.Text = string.Empty;
            cargarEstados();
            conBusDocumento.Focus();
            conBusDocumento.txtDocumentoID.Focus();

        }
        public void CreaTablalCredNoUtilTitular()
        {

            dtlCredNoUtilizadaT = new DataTable();
            columnlCredNoUtilizadaT = new DataColumn();
            columnlCredNoUtilizadaT.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaT.ColumnName = "Condicion";
            dtlCredNoUtilizadaT.Columns.Add(columnlCredNoUtilizadaT);

            columnlCredNoUtilizadaT = new DataColumn();
            columnlCredNoUtilizadaT.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaT.ColumnName = "Inst";
            dtlCredNoUtilizadaT.Columns.Add(columnlCredNoUtilizadaT);

            columnlCredNoUtilizadaT = new DataColumn();
            columnlCredNoUtilizadaT.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaT.ColumnName = "LinApr";
            dtlCredNoUtilizadaT.Columns.Add(columnlCredNoUtilizadaT);

            columnlCredNoUtilizadaT = new DataColumn();
            columnlCredNoUtilizadaT.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaT.ColumnName = "LinNoUti";
            dtlCredNoUtilizadaT.Columns.Add(columnlCredNoUtilizadaT);

            columnlCredNoUtilizadaT = new DataColumn();
            columnlCredNoUtilizadaT.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaT.ColumnName = "LinUti";
            dtlCredNoUtilizadaT.Columns.Add(columnlCredNoUtilizadaT);

            columnlCredNoUtilizadaT = new DataColumn();
            columnlCredNoUtilizadaT.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaT.ColumnName = "TipCred";
            dtlCredNoUtilizadaT.Columns.Add(columnlCredNoUtilizadaT);
        }
        public void CreaTablalCredNoUtilConyuge()
        {

            dtlCredNoUtilizadaC = new DataTable();
            columnlCredNoUtilizadaC = new DataColumn();
            columnlCredNoUtilizadaC.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaC.ColumnName = "Condicion";
            dtlCredNoUtilizadaC.Columns.Add(columnlCredNoUtilizadaC);

            columnlCredNoUtilizadaC = new DataColumn();
            columnlCredNoUtilizadaC.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaC.ColumnName = "Inst";
            dtlCredNoUtilizadaC.Columns.Add(columnlCredNoUtilizadaC);

            columnlCredNoUtilizadaC = new DataColumn();
            columnlCredNoUtilizadaC.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaC.ColumnName = "LinApr";
            dtlCredNoUtilizadaC.Columns.Add(columnlCredNoUtilizadaC);

            columnlCredNoUtilizadaC = new DataColumn();
            columnlCredNoUtilizadaC.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaC.ColumnName = "LinNoUti";
            dtlCredNoUtilizadaC.Columns.Add(columnlCredNoUtilizadaC);

            columnlCredNoUtilizadaC = new DataColumn();
            columnlCredNoUtilizadaC.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaC.ColumnName = "LinUti";
            dtlCredNoUtilizadaC.Columns.Add(columnlCredNoUtilizadaC);

            columnlCredNoUtilizadaC = new DataColumn();
            columnlCredNoUtilizadaC.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaC.ColumnName = "TipCred";
            dtlCredNoUtilizadaC.Columns.Add(columnlCredNoUtilizadaC);
        }
        public void CreaTablaBasicoSunatTitular()
        {

            dtBasicoSunatTitular = new DataTable();
            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "TDoc";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "NDoc";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "RelTDoc";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "RelNDOC";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "RazSoc";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "NomCom";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "TipCon";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "IniAct";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "ActEco";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "FchInsRRPP";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "AgeRet";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "ApePat";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "ApeMat";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "Nom";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "Sex";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "EstCon";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "EstDom";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "EstDomic";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "CondDomic";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

        }
        public void CreaTablaBasicoSunatConyuge()
        {

            dtBasicoSunatConyuge = new DataTable();
            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "TDoc";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "NDoc";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "RelTDoc";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "RelNDOC";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "RazSoc";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "NomCom";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "TipCon";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "IniAct";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "ActEco";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "FchInsRRPP";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "AgeRet";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "ApePat";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "ApeMat";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "Nom";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "Sex";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "EstCon";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "EstDom";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "EstDomic";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "CondDomic";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

        }
        public void CreaTablaBSunatDireccionTitular()
        {

            dtBSunatDireccionTitular = new DataTable();
            columnBSunatDireccionTitular = new DataColumn();
            columnBSunatDireccionTitular.DataType = System.Type.GetType("System.String");
            columnBSunatDireccionTitular.ColumnName = "Direccion";
            dtBSunatDireccionTitular.Columns.Add(columnBSunatDireccionTitular);

            columnBSunatDireccionTitular = new DataColumn();
            columnBSunatDireccionTitular.DataType = System.Type.GetType("System.String");
            columnBSunatDireccionTitular.ColumnName = "Fuente";
            dtBSunatDireccionTitular.Columns.Add(columnBSunatDireccionTitular);

        }
        public void CreaTablaBSunatDireccionConyuge()
        {

            dtBSunatDireccionConyuge = new DataTable();
            columnBSunatDireccionConyuge = new DataColumn();
            columnBSunatDireccionConyuge.DataType = System.Type.GetType("System.String");
            columnBSunatDireccionConyuge.ColumnName = "Direccion";
            dtBSunatDireccionConyuge.Columns.Add(columnBSunatDireccionConyuge);

            columnBSunatDireccionConyuge = new DataColumn();
            columnBSunatDireccionConyuge.DataType = System.Type.GetType("System.String");
            columnBSunatDireccionConyuge.ColumnName = "Fuente";
            dtBSunatDireccionConyuge.Columns.Add(columnBSunatDireccionConyuge);

        }
        public void CreaTablaRLegalTitular()
        {

            dtRlegalTitular = new DataTable();
            columnRlegalTitular = new DataColumn();
            columnRlegalTitular.DataType = System.Type.GetType("System.String");
            columnRlegalTitular.ColumnName = "TDOC";
            dtRlegalTitular.Columns.Add(columnRlegalTitular);

            columnRlegalTitular = new DataColumn();
            columnRlegalTitular.DataType = System.Type.GetType("System.String");
            columnRlegalTitular.ColumnName = "NDOC";
            dtRlegalTitular.Columns.Add(columnRlegalTitular);

            columnRlegalTitular = new DataColumn();
            columnRlegalTitular.DataType = System.Type.GetType("System.String");
            columnRlegalTitular.ColumnName = "Nombre";
            dtRlegalTitular.Columns.Add(columnRlegalTitular);

            columnRlegalTitular = new DataColumn();
            columnRlegalTitular.DataType = System.Type.GetType("System.String");
            columnRlegalTitular.ColumnName = "FecIniCar";
            dtRlegalTitular.Columns.Add(columnRlegalTitular);

            columnRlegalTitular = new DataColumn();
            columnRlegalTitular.DataType = System.Type.GetType("System.String");
            columnRlegalTitular.ColumnName = "Cargo";
            dtRlegalTitular.Columns.Add(columnRlegalTitular);
        }
        public void CreaTablaRLegalConyuge()
        {

            dtRlegalConyuge = new DataTable();
            columnRlegalConyuge = new DataColumn();
            columnRlegalConyuge.DataType = System.Type.GetType("System.String");
            columnRlegalConyuge.ColumnName = "TDOC";
            dtRlegalConyuge.Columns.Add(columnRlegalConyuge);

            columnRlegalConyuge = new DataColumn();
            columnRlegalConyuge.DataType = System.Type.GetType("System.String");
            columnRlegalConyuge.ColumnName = "NDOC";
            dtRlegalConyuge.Columns.Add(columnRlegalConyuge);

            columnRlegalConyuge = new DataColumn();
            columnRlegalConyuge.DataType = System.Type.GetType("System.String");
            columnRlegalConyuge.ColumnName = "Nombre";
            dtRlegalConyuge.Columns.Add(columnRlegalConyuge);

            columnRlegalConyuge = new DataColumn();
            columnRlegalConyuge.DataType = System.Type.GetType("System.String");
            columnRlegalConyuge.ColumnName = "FecIniCar";
            dtRlegalConyuge.Columns.Add(columnRlegalConyuge);

            columnRlegalConyuge = new DataColumn();
            columnRlegalConyuge.DataType = System.Type.GetType("System.String");
            columnRlegalConyuge.ColumnName = "Cargo";
            dtRlegalConyuge.Columns.Add(columnRlegalConyuge);
        }
        public void CreaTablaAvaladoTitular()
        {
            ///Crea Tabla Avalado Titular
            dtAvalado = new DataTable();

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "Condicion";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "ndoc";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "tDoc";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "razSoc";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "semAct";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "Sem12Mes";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "tDocAcre";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "nDocAcre";
            dtAvalado.Columns.Add(columnAvaladoTitular);
        
            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "razSocAcre";
            dtAvalado.Columns.Add(columnAvaladoTitular);
            
            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "cal";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "tipEnt";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "salDeu";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "fecRep";
            dtAvalado.Columns.Add(columnAvaladoTitular);
         
 
        }
        public void CreaTablaAvaladoConyuge()
        {
            dtAvaladoConyuge = new DataTable();

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "Condicion";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "ndoc";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "tDoc";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "razSoc";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "semAct";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "Sem12Mes";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "tDocAcre";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "nDocAcre";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "razSocAcre";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "cal";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "tipEnt";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "salDeu";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "fecRep";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);
         
        }
        public void CreaTablaMicrofinanzasTitular()
        {
            dtMicrTitular = new DataTable();

            columnMicrTitular = new DataColumn();
            columnMicrTitular.DataType = System.Type.GetType("System.String");
            columnMicrTitular.ColumnName = "Condicion";
            dtMicrTitular.Columns.Add(columnMicrTitular);

            columnMicrTitular = new DataColumn();
            columnMicrTitular.DataType = System.Type.GetType("System.String");
            columnMicrTitular.ColumnName = "NomEnt";
            dtMicrTitular.Columns.Add(columnMicrTitular);

            columnMicrTitular = new DataColumn();
            columnMicrTitular.DataType = System.Type.GetType("System.String");
            columnMicrTitular.ColumnName = "Cal";
            dtMicrTitular.Columns.Add(columnMicrTitular);


            columnMicrTitular = new DataColumn();
            columnMicrTitular.DataType = System.Type.GetType("System.String");
            columnMicrTitular.ColumnName = "SalDeu";
            dtMicrTitular.Columns.Add(columnMicrTitular);


            columnMicrTitular = new DataColumn();
            columnMicrTitular.DataType = System.Type.GetType("System.Int32");
            columnMicrTitular.ColumnName = "DiaVen";
            dtMicrTitular.Columns.Add(columnMicrTitular);


            columnMicrTitular = new DataColumn();
            columnMicrTitular.DataType = System.Type.GetType("System.String");
            columnMicrTitular.ColumnName = "FchPro";
            dtMicrTitular.Columns.Add(columnMicrTitular);


            columnMicrTitular = new DataColumn();
            columnMicrTitular.DataType = System.Type.GetType("System.String");
            columnMicrTitular.ColumnName = "FchRep";
            dtMicrTitular.Columns.Add(columnMicrTitular);

            columnMicrTitular = new DataColumn();
            columnMicrTitular.DataType = System.Type.GetType("System.String");
            columnMicrTitular.ColumnName = "FchProNumero";
            dtMicrTitular.Columns.Add(columnMicrTitular);

            columnMicrTitular = new DataColumn();
            columnMicrTitular.DataType = System.Type.GetType("System.String");
            columnMicrTitular.ColumnName = "DeudaTotal";
            dtMicrTitular.Columns.Add(columnMicrTitular);
        }
        public void CreaTablaMicrofinanzasConyuge()
        {
            dtMicrConyuge = new DataTable();
            
            columnMicrConyuge = new DataColumn();
            columnMicrConyuge.DataType = System.Type.GetType("System.String");
            columnMicrConyuge.ColumnName = "Condicion";
            dtMicrConyuge.Columns.Add(columnMicrConyuge);

            columnMicrConyuge = new DataColumn();
            columnMicrConyuge.DataType = System.Type.GetType("System.String");
            columnMicrConyuge.ColumnName = "NomEnt";
            dtMicrConyuge.Columns.Add(columnMicrConyuge);


            columnMicrConyuge = new DataColumn();
            columnMicrConyuge.DataType = System.Type.GetType("System.String");
            columnMicrConyuge.ColumnName = "Cal";
            dtMicrConyuge.Columns.Add(columnMicrConyuge);


            columnMicrConyuge = new DataColumn();
            columnMicrConyuge.DataType = System.Type.GetType("System.String");
            columnMicrConyuge.ColumnName = "SalDeu";
            dtMicrConyuge.Columns.Add(columnMicrConyuge);


            columnMicrConyuge = new DataColumn();
            columnMicrConyuge.DataType = System.Type.GetType("System.Int32");
            columnMicrConyuge.ColumnName = "DiaVen";
            dtMicrConyuge.Columns.Add(columnMicrConyuge);


            columnMicrConyuge = new DataColumn();
            columnMicrConyuge.DataType = System.Type.GetType("System.String");
            columnMicrConyuge.ColumnName = "FchPro";
            dtMicrConyuge.Columns.Add(columnMicrConyuge);


            columnMicrConyuge = new DataColumn();
            columnMicrConyuge.DataType = System.Type.GetType("System.String");
            columnMicrConyuge.ColumnName = "FchRep";
            dtMicrConyuge.Columns.Add(columnMicrConyuge);

            columnMicrConyuge = new DataColumn();
            columnMicrConyuge.DataType = System.Type.GetType("System.String");
            columnMicrConyuge.ColumnName = "FchProNumero";
            dtMicrConyuge.Columns.Add(columnMicrConyuge);

            columnMicrConyuge = new DataColumn();
            columnMicrConyuge.DataType = System.Type.GetType("System.String");
            columnMicrConyuge.ColumnName = "DeudaTotal";
            dtMicrConyuge.Columns.Add(columnMicrConyuge);
        }
        public void CreaTablaDeudaTitular()
        {
            dtDeudaTitular = new DataTable();

            columnDeudaTitular = new DataColumn();
            columnDeudaTitular.DataType = System.Type.GetType("System.String");
            columnDeudaTitular.ColumnName = "Condicion";
            dtDeudaTitular.Columns.Add(columnDeudaTitular);

            columnDeudaTitular = new DataColumn();
            columnDeudaTitular.DataType = System.Type.GetType("System.Int32");
            columnDeudaTitular.ColumnName = "idFue";
            dtDeudaTitular.Columns.Add(columnDeudaTitular);

            columnDeudaTitular = new DataColumn();
            columnDeudaTitular.DataType = System.Type.GetType("System.String");
            columnDeudaTitular.ColumnName = "MaxDiaVen";
            dtDeudaTitular.Columns.Add(columnDeudaTitular);

            columnDeudaTitular = new DataColumn();
            columnDeudaTitular.DataType = System.Type.GetType("System.String");
            columnDeudaTitular.ColumnName = "NomFue";
            dtDeudaTitular.Columns.Add(columnDeudaTitular);

            columnDeudaTitular = new DataColumn();
            columnDeudaTitular.DataType = System.Type.GetType("System.String");
            columnDeudaTitular.ColumnName = "VenTot";
            dtDeudaTitular.Columns.Add(columnDeudaTitular);

            columnDeudaTitular = new DataColumn();
            columnDeudaTitular.DataType = System.Type.GetType("System.String");
            columnDeudaTitular.ColumnName = "NomEnt";
            dtDeudaTitular.Columns.Add(columnDeudaTitular);

            columnDeudaTitular = new DataColumn();
            columnDeudaTitular.DataType = System.Type.GetType("System.String");
            columnDeudaTitular.ColumnName = "MontDeu";
            dtDeudaTitular.Columns.Add(columnDeudaTitular);


            columnDeudaTitular = new DataColumn();
            columnDeudaTitular.DataType = System.Type.GetType("System.String");
            columnDeudaTitular.ColumnName = "DiaVen";
            dtDeudaTitular.Columns.Add(columnDeudaTitular);

            columnDeudaTitular = new DataColumn();
            columnDeudaTitular.DataType = System.Type.GetType("System.String");
            columnDeudaTitular.ColumnName = "NumDoc";
            dtDeudaTitular.Columns.Add(columnDeudaTitular);
        
        }
        public void CreaTablaHistorialSentinelTitular()
        {
            dtHistorialSentinelTitular = new DataTable();

            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelTitular.ColumnName = "FechPro";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);

            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelTitular.ColumnName = "SemaActual";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);

            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.Int32");
            columnHistorialSentinelTitular.ColumnName = "NroEntidad";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);


            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelTitular.ColumnName = "DeudaTotal";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);


            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelTitular.ColumnName = "Calificacion";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);

            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelTitular.ColumnName = "PorcentajeNOR";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);

            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelTitular.ColumnName = "PorcentajeCPP";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);

            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelTitular.ColumnName = "PorcentajeDEF";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);

            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelTitular.ColumnName = "PorcentajeDUD";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);

            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelTitular.ColumnName = "PorcentajePER";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);

            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelTitular.ColumnName = "PorcentajeSCAL";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);

            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelTitular.ColumnName = "FchProNumero";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);
            

        }
        public void CreaTablaHistorialSentinelConyuge()
        {
            dtHistorialSentinelConyuge = new DataTable();

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelConyuge.ColumnName = "FechPro";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelConyuge.ColumnName = "SemaActual";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.Int32");
            columnHistorialSentinelConyuge.ColumnName = "NroEntidad";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelConyuge.ColumnName = "DeudaTotal";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelConyuge.ColumnName = "Calificacion";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelConyuge.ColumnName = "PorcentajeNOR";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelConyuge.ColumnName = "PorcentajeCPP";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelConyuge.ColumnName = "PorcentajeDEF";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelConyuge.ColumnName = "PorcentajeDUD";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelConyuge.ColumnName = "PorcentajePER";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelConyuge.ColumnName = "PorcentajeSCAL";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelConyuge.ColumnName = "FchProNumero";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);
            
        }
        public void CreaTablaDeudaConyuge()
        {
            dtDeudaConyuge = new DataTable();

            columnDeudaConyuge = new DataColumn();
            columnDeudaConyuge.DataType = System.Type.GetType("System.String");
            columnDeudaConyuge.ColumnName = "Condicion";
            dtDeudaConyuge.Columns.Add(columnDeudaConyuge);

            columnDeudaConyuge = new DataColumn();
            columnDeudaConyuge.DataType = System.Type.GetType("System.Int32");
            columnDeudaConyuge.ColumnName = "idFue";
            dtDeudaConyuge.Columns.Add(columnDeudaConyuge);

            columnDeudaConyuge = new DataColumn();
            columnDeudaConyuge.DataType = System.Type.GetType("System.String");
            columnDeudaConyuge.ColumnName = "MaxDiaVen";
            dtDeudaConyuge.Columns.Add(columnDeudaConyuge);

            columnDeudaConyuge = new DataColumn();
            columnDeudaConyuge.DataType = System.Type.GetType("System.String");
            columnDeudaConyuge.ColumnName = "NomFue";
            dtDeudaConyuge.Columns.Add(columnDeudaConyuge);

            columnDeudaConyuge = new DataColumn();
            columnDeudaConyuge.DataType = System.Type.GetType("System.String");
            columnDeudaConyuge.ColumnName = "VenTot";
            dtDeudaConyuge.Columns.Add(columnDeudaConyuge);

            columnDeudaConyuge = new DataColumn();
            columnDeudaConyuge.DataType = System.Type.GetType("System.String");
            columnDeudaConyuge.ColumnName = "NomEnt";
            dtDeudaConyuge.Columns.Add(columnDeudaConyuge);

            columnDeudaConyuge = new DataColumn();
            columnDeudaConyuge.DataType = System.Type.GetType("System.String");
            columnDeudaConyuge.ColumnName = "MontDeu";
            dtDeudaConyuge.Columns.Add(columnDeudaConyuge);


            columnDeudaConyuge = new DataColumn();
            columnDeudaConyuge.DataType = System.Type.GetType("System.String");
            columnDeudaConyuge.ColumnName = "DiaVen";
            dtDeudaConyuge.Columns.Add(columnDeudaConyuge);

            columnDeudaConyuge = new DataColumn();
            columnDeudaConyuge.DataType = System.Type.GetType("System.String");
            columnDeudaConyuge.ColumnName = "NumDoc";
            dtDeudaConyuge.Columns.Add(columnDeudaConyuge);
        }

        public void CreaTablaAvalistaTitular()
        {
            dtAvalistaTitular = new DataTable();

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "Condicion";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "NDoc";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "RazSoc";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "Sem12Mes";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "SemAct";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "SemPre";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "NDocAcre";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "RazSocAcre";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "Cal";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "SalDeu";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "TipEnt";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "FecRep";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);
        
        }
        public void CreaTablaAvalistaConyuge()
        {
            dtAvalistaConyuge = new DataTable();

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "Condicion";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "NDoc";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);
            
            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "RazSoc";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "Sem12Mes";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "SemAct";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "SemPre";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "NDocAcre";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "RazSocAcre";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "Cal";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "SalDeu";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "TipEnt";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "FecRep";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);


        }

        private void FormatoGridCreditos()
        {
            foreach (DataGridViewColumn item in dtgCreditos.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgCreditos.Columns["nProvisionSoles"].Visible = false;
            dtgCreditos.Columns["idEstado"].Visible = false;
            dtgCreditos.Columns["idCondContableNormal"].Visible = false;
            dtgCreditos.Columns["idCondContableVenc"].Visible = false;
            dtgCreditos.Columns["cTipoCliente"].Visible = false;

            dtgCreditos.Columns["cOperacion"].HeaderText = "Operación";
            dtgCreditos.Columns["cModalidadCredito"].HeaderText = "Modalidad de crédito";
            dtgCreditos.Columns["nNumOrdCre"].HeaderText = "Nro.";
            dtgCreditos.Columns["dFechaDesembolso"].HeaderText = "Fecha desembolso";
            dtgCreditos.Columns["dFechaCancelacion"].HeaderText = "Fecha cancelación";
            dtgCreditos.Columns["idCuenta"].HeaderText = "N° cuenta";
            dtgCreditos.Columns["cNombreAge"].HeaderText = "Agencia";
            dtgCreditos.Columns["cProducto"].HeaderText = "Producto";
            dtgCreditos.Columns["cEstado"].HeaderText = "Estado";
            dtgCreditos.Columns["nAtraso"].HeaderText = "Dias atraso";
            dtgCreditos.Columns["nDiasAtrPro"].HeaderText = "Dias Promedio Atraso";
            dtgCreditos.Columns["nCuotas"].HeaderText = "N° cuotas";
            //dtgCreditos.Columns["nPlazoCuota"].HeaderText = "Plazo(meses)";
            dtgCreditos.Columns["nPlazoCuota"].Visible = false;
            dtgCreditos.Columns["cAsesorAct"].HeaderText = "Asesor actual";
            dtgCreditos.Columns["cAsesorIni"].HeaderText = "Asesor inicial";
            dtgCreditos.Columns["cTipoCliente"].HeaderText = "Tipo cliente";
            dtgCreditos.Columns["nTasaCompensatoria"].HeaderText = "Tasa comp.(%)";
            dtgCreditos.Columns["nTasaMoratoria"].HeaderText = "Tasa morat.(%)";
            dtgCreditos.Columns["nTasaCostoEfectivo"].HeaderText = "Tasa cost. efec.(%)";
            dtgCreditos.Columns["nCapitalDesembolso"].HeaderText = "Cap. desemb.";
            dtgCreditos.Columns["nCapitalPagado"].HeaderText = "Cap. pagado";
            dtgCreditos.Columns["nSalCap"].HeaderText = "Saldo cap.";
            dtgCreditos.Columns["nCapitalPagado"].HeaderText = "Cap. pag.";
            dtgCreditos.Columns["nInteresPactado"].HeaderText = "Int. pac.";
            dtgCreditos.Columns["nInteresPagado"].HeaderText = "Int. pag.";
            dtgCreditos.Columns["nSaliNT"].HeaderText = "Saldo int.";
            dtgCreditos.Columns["nInteresComp"].HeaderText = "Int. comp.";
            dtgCreditos.Columns["nInteresCompPago"].HeaderText = "Int. comp. pag.";
            dtgCreditos.Columns["nIntCompSal"].HeaderText = "Saldo int. comp.";
            dtgCreditos.Columns["nMoraGenerado"].HeaderText = "Mora gen.";
            dtgCreditos.Columns["nMoraPagada"].HeaderText = "Mora pag.";
            dtgCreditos.Columns["nSalMor"].HeaderText = "Saldo mora";
            dtgCreditos.Columns["nOtrosGenerado"].HeaderText = "Otros gen.";
            dtgCreditos.Columns["nOtrosPagado"].HeaderText = "Otros pag.";
            dtgCreditos.Columns["nSalOtr"].HeaderText = "Saldo otr.";
            dtgCreditos.Columns["nSalTot"].HeaderText = "Saldo tot.";
            dtgCreditos.Columns["cCodigoExped"].HeaderText = "Expediente";
            dtgCreditos.Columns["cDestino"].HeaderText = "Destino";
            dtgCreditos.Columns["idSolicitud"].HeaderText = "N° sol.";
            dtgCreditos.Columns["cCuenta"].HeaderText = "Cuenta";
            dtgCreditos.Columns["cMoneda"].HeaderText = "Moneda";
            dtgCreditos.Columns["nTotSalVen"].HeaderText = "Saldo Vencido";
            dtgCreditos.Columns["nTotCuoVen"].HeaderText = "Cuotas Vencidas";
            dtgCreditos.Columns["cCondContNormal"].HeaderText = "Cond. Contable Normal";
            dtgCreditos.Columns["cCondContVenc"].HeaderText = "Cond. Contable Vencido";
            dtgCreditos.Columns["cTipo"].HeaderText = "Tipo.Periodo";
            dtgCreditos.Columns["cRecuperador"].HeaderText = "Usuario.Recuperador";
            
            dtgCreditos.Columns["nTasaCompensatoria"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nTasaMoratoria"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nTasaCostoEfectivo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nCapitalDesembolso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nCapitalPagado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nSalCap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nCapitalPagado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nInteresPactado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nInteresPagado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nSaliNT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nInteresComp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nInteresCompPago"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nIntCompSal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nMoraGenerado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nMoraPagada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nSalMor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nOtrosGenerado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nOtrosPagado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nSalOtr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nSalTot"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nTotSalVen"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nTasaCompensatoria"].DefaultCellStyle.Format = "#,0.0000";
            dtgCreditos.Columns["nTasaMoratoria"].DefaultCellStyle.Format = "#,0.0000";
            dtgCreditos.Columns["nTasaCostoEfectivo"].DefaultCellStyle.Format = "#,0.0000";
            dtgCreditos.Columns["nCapitalDesembolso"].DefaultCellStyle.Format = "#,0.00";
            dtgCreditos.Columns["nCapitalPagado"].DefaultCellStyle.Format = "#,0.00";
            dtgCreditos.Columns["nSalCap"].DefaultCellStyle.Format = "#,0.00";
            dtgCreditos.Columns["nCapitalPagado"].DefaultCellStyle.Format = "#,0.00";
            dtgCreditos.Columns["nInteresPactado"].DefaultCellStyle.Format = "#,0.00";
            dtgCreditos.Columns["nInteresPagado"].DefaultCellStyle.Format = "#,0.00";
            dtgCreditos.Columns["nSaliNT"].DefaultCellStyle.Format = "#,0.00";
            dtgCreditos.Columns["nInteresComp"].DefaultCellStyle.Format = "#,0.00";
            dtgCreditos.Columns["nInteresCompPago"].DefaultCellStyle.Format = "#,0.00";
            dtgCreditos.Columns["nIntCompSal"].DefaultCellStyle.Format = "#,0.00";
            dtgCreditos.Columns["nMoraGenerado"].DefaultCellStyle.Format = "#,0.00";
            dtgCreditos.Columns["nMoraPagada"].DefaultCellStyle.Format = "#,0.00";
            dtgCreditos.Columns["nSalMor"].DefaultCellStyle.Format = "#,0.00";
            dtgCreditos.Columns["nOtrosGenerado"].DefaultCellStyle.Format = "#,0.00";
            dtgCreditos.Columns["nOtrosPagado"].DefaultCellStyle.Format = "#,0.00";
            dtgCreditos.Columns["nSalOtr"].DefaultCellStyle.Format = "#,0.00";
            dtgCreditos.Columns["nSalTot"].DefaultCellStyle.Format = "#,0.00";
            dtgCreditos.Columns["nTotSalVen"].DefaultCellStyle.Format = "#,0.00";
        }
   
        private void FormatoAvalado()
        {
            foreach (DataGridViewColumn item in dtgAvaladoTitular.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgAvaladoTitular.Columns["ndoc"].HeaderText = "Nro.Documento";
            dtgAvaladoTitular.Columns["tDoc"].HeaderText = "Tipo Documento";
            dtgAvaladoTitular.Columns["razSoc"].HeaderText = "Razón.Social";
            dtgAvaladoTitular.Columns["razSoc"].Width = 300;
            dtgAvaladoTitular.Columns["semAct"].HeaderText = "Semaforo.Actual";
            dtgAvaladoTitular.Columns["Sem12Mes"].HeaderText = "Semaforo 12 Meses";
            dtgAvaladoTitular.Columns["tDocAcre"].HeaderText = "Tipo.Documento.Acreedor";
            dtgAvaladoTitular.Columns["tDocAcre"].Width = 200;
            dtgAvaladoTitular.Columns["nDocAcre"].HeaderText = "Nro.Documento.Acreedor";
            dtgAvaladoTitular.Columns["nDocAcre"].Width = 200;
            dtgAvaladoTitular.Columns["razSocAcre"].HeaderText = "Razón.Social Acreedor";
            dtgAvaladoTitular.Columns["razSocAcre"].Width = 300;
            dtgAvaladoTitular.Columns["cal"].HeaderText = "Calificación";
            dtgAvaladoTitular.Columns["tipEnt"].HeaderText = "Tipo Entidad Acreedora";
            dtgAvaladoTitular.Columns["salDeu"].HeaderText = "Saldo.Deuda";
            dtgAvaladoTitular.Columns["fecRep"].HeaderText = "Fecha Reporte Deuda";

        
        }
        private void FormatoAvalista()
        {
            foreach (DataGridViewColumn item in dtgAvalistaTitular.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgAvalistaTitular.Columns["Condicion"].Visible = false;
            dtgAvalistaTitular.Columns["NDoc"].HeaderText = "Nro.Documento";
            dtgAvalistaTitular.Columns["NDoc"].Width = 100;
            dtgAvalistaTitular.Columns["razSoc"].HeaderText = "Razón.Social";
            dtgAvalistaTitular.Columns["razSoc"].Width = 250;
            dtgAvalistaTitular.Columns["semAct"].HeaderText = "Semáforo.Actual";
            dtgAvalistaTitular.Columns["Sem12Mes"].HeaderText = "Semáforo 12 Meses";
            dtgAvalistaTitular.Columns["SemPre"].HeaderText = "Semáforo Previo";
            dtgAvalistaTitular.Columns["NDocAcre"].HeaderText = "Nro.Documento Acreedor";
            dtgAvalistaTitular.Columns["RazSocAcre"].HeaderText = "Razón Social Acreedor";
            dtgAvalistaTitular.Columns["RazSocAcre"].Width = 280;
            dtgAvalistaTitular.Columns["Cal"].HeaderText = "Calificación";
            dtgAvalistaTitular.Columns["SalDeu"].HeaderText = "Saldo de la Deuda";
            dtgAvalistaTitular.Columns["TipEnt"].HeaderText = "Tipo entidad Acreedora";
            dtgAvalistaTitular.Columns["FecRep"].HeaderText = "Fecha Reporte Deuda";
            dtgAvalistaTitular.Columns["NDoc"].DisplayIndex = 0;
            dtgAvalistaTitular.Columns["razSoc"].DisplayIndex = 1;
            dtgAvalistaTitular.Columns["semAct"].DisplayIndex = 2;
            dtgAvalistaTitular.Columns["SemPre"].DisplayIndex = 3;
            dtgAvalistaTitular.Columns["Sem12Mes"].DisplayIndex = 4;
            dtgAvalistaTitular.Columns["NDocAcre"].DisplayIndex = 5;
            dtgAvalistaTitular.Columns["RazSocAcre"].DisplayIndex = 6;
            dtgAvalistaTitular.Columns["Cal"].DisplayIndex = 7;
            dtgAvalistaTitular.Columns["SalDeu"].DisplayIndex = 8;
            dtgAvalistaTitular.Columns["TipEnt"].DisplayIndex = 9;
            dtgAvalistaTitular.Columns["FecRep"].DisplayIndex = 10;
            dtgAvalistaTitular.Columns["Condicion"].DisplayIndex = 11;
        }
        private void FormatoLineCreditoConyuge()
        {
            foreach (DataGridViewColumn item in dtgLineaCreditoNoUtilConyuge.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dtgLineaCreditoNoUtilConyuge.Columns["Condicion"].Visible = false;
            dtgLineaCreditoNoUtilConyuge.Columns["inst"].HeaderText = "Entidad Acreedora";
            dtgLineaCreditoNoUtilConyuge.Columns["inst"].Width = 300;
            dtgLineaCreditoNoUtilConyuge.Columns["LinApr"].HeaderText = "Línea Aprobada";
            dtgLineaCreditoNoUtilConyuge.Columns["LinNoUti"].HeaderText = "Línea No Utilizada";
            dtgLineaCreditoNoUtilConyuge.Columns["LinUti"].HeaderText = "Línea Utilizada";
            dtgLineaCreditoNoUtilConyuge.Columns["TipCred"].HeaderText = "Tipo Línea Crédito";
        }
        private void FormatoLineCreditoTitular()
        {
            foreach (DataGridViewColumn item in dtgLineaCreditoNoUtilTitular.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dtgLineaCreditoNoUtilTitular.Columns["Condicion"].Visible = false;
            dtgLineaCreditoNoUtilTitular.Columns["inst"].HeaderText = "Entidad Acreedora";
            dtgLineaCreditoNoUtilTitular.Columns["inst"].Width = 300;
            dtgLineaCreditoNoUtilTitular.Columns["LinApr"].HeaderText = "Línea Aprobada";
            dtgLineaCreditoNoUtilTitular.Columns["LinNoUti"].HeaderText = "Línea No Utilizada";
            dtgLineaCreditoNoUtilTitular.Columns["LinUti"].HeaderText = "Línea Utilizada";
            dtgLineaCreditoNoUtilTitular.Columns["TipCred"].HeaderText = "Tipo Línea Crédito";
        }
        private void FormatoAvalistaConyuge()
        {
            foreach (DataGridViewColumn item in dtgAvalistaConyuge.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dtgAvalistaConyuge.Columns["Condicion"].Visible = false;
            dtgAvalistaConyuge.Columns["NDoc"].HeaderText = "Nro.Documento";
            dtgAvalistaConyuge.Columns["NDoc"].Width = 100;
            dtgAvalistaConyuge.Columns["razSoc"].HeaderText = "Razón.Social";
            dtgAvalistaConyuge.Columns["razSoc"].Width = 250;
            dtgAvalistaConyuge.Columns["semAct"].HeaderText = "Semáforo.Actual";
            dtgAvalistaConyuge.Columns["Sem12Mes"].HeaderText = "Semáforo 12 Meses";
            dtgAvalistaConyuge.Columns["SemPre"].HeaderText = "Semáforo Previo";
            dtgAvalistaConyuge.Columns["NDocAcre"].HeaderText = "Nro.Documento Acreedor";
            dtgAvalistaConyuge.Columns["RazSocAcre"].HeaderText = "Razón Social Acreedor";
            dtgAvalistaConyuge.Columns["RazSocAcre"].Width = 280;
            dtgAvalistaConyuge.Columns["Cal"].HeaderText = "Calificación";
            dtgAvalistaConyuge.Columns["SalDeu"].HeaderText = "Saldo de la Deuda";
            dtgAvalistaConyuge.Columns["TipEnt"].HeaderText = "Tipo entidad Acreedora";
            dtgAvalistaConyuge.Columns["FecRep"].HeaderText = "Fecha Reporte Deuda";

            dtgAvalistaConyuge.Columns["NDoc"].DisplayIndex = 0;
            dtgAvalistaConyuge.Columns["razSoc"].DisplayIndex = 1;
            dtgAvalistaConyuge.Columns["semAct"].DisplayIndex = 2;
            dtgAvalistaConyuge.Columns["SemPre"].DisplayIndex = 3;
            dtgAvalistaConyuge.Columns["Sem12Mes"].DisplayIndex = 4;
       
            dtgAvalistaConyuge.Columns["NDocAcre"].DisplayIndex = 5;
            dtgAvalistaConyuge.Columns["RazSocAcre"].DisplayIndex = 6;
            dtgAvalistaConyuge.Columns["Cal"].DisplayIndex = 7;
            dtgAvalistaConyuge.Columns["SalDeu"].DisplayIndex = 8;
            dtgAvalistaConyuge.Columns["TipEnt"].DisplayIndex = 9;
            dtgAvalistaConyuge.Columns["FecRep"].DisplayIndex = 10;
            dtgAvalistaConyuge.Columns["Condicion"].DisplayIndex = 11;
        }
        private void FormatoAvaladoConyuge()
        {
            foreach (DataGridViewColumn item in dtgAvaladoConyuge.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgAvaladoConyuge.Columns["ndoc"].HeaderText = "Nro.Documento";
            dtgAvaladoConyuge.Columns["tDoc"].HeaderText = "Tipo Documento";
            dtgAvaladoConyuge.Columns["razSoc"].HeaderText = "Razón.Social";
            dtgAvaladoConyuge.Columns["razSoc"].Width = 300;
            dtgAvaladoConyuge.Columns["semAct"].HeaderText = "Semaforo.Actual";
            dtgAvaladoConyuge.Columns["Sem12Mes"].HeaderText = "Semaforo 12 Meses";
            dtgAvaladoConyuge.Columns["tDocAcre"].HeaderText = "Tipo.Documento.Acreedor";
            dtgAvaladoConyuge.Columns["tDocAcre"].Width = 200;
            dtgAvaladoConyuge.Columns["nDocAcre"].HeaderText = "Nro.Documento.Acreedor";
            dtgAvaladoConyuge.Columns["nDocAcre"].Width = 200;
            dtgAvaladoConyuge.Columns["razSocAcre"].HeaderText = "Razón.Social Acreedor";
            dtgAvaladoConyuge.Columns["razSocAcre"].Width = 300;
            dtgAvaladoConyuge.Columns["cal"].HeaderText = "Calificación";
            dtgAvaladoConyuge.Columns["tipEnt"].HeaderText = "Tipo Entidad Acreedora";
            dtgAvaladoConyuge.Columns["salDeu"].HeaderText = "Saldo.Deuda";
            dtgAvaladoConyuge.Columns["fecRep"].HeaderText = "Fecha Reporte Deuda";
        }
   
        private void cargardatos()
        {
            if (conBusCli.txtCodCli.Text != String.Empty)
            {
                idClienteT = Convert.ToInt32(conBusCli.txtCodCli.Text);
                cDocumentoIDT = Convert.ToString(conBusCli.txtNroDoc.Text);
                idTipoDocumentoT = Convert.ToInt32(conBusCli.nidTipoDocumento);
                idTipoPersonaT = conBusCli.nidTipoPersona;
                idClasifInternaT = conBusCli.nIdClasifInterna;
                cClasifInternaT = conBusCli.cClasifInterna;
            }
            else
            {
                idClienteT = conBusDocumento.idCliente;
                cDocumentoIDT = conBusDocumento.cDocumentoID;
                idTipoDocumentoT = conBusDocumento.idTipoDocumento;
                idTipoPersonaT = conBusDocumento.idTipoPersona;
                idClasifInternaT = conBusDocumento.idClasifInterna;
                cClasifInternaT = conBusDocumento.cClasifInterna;
            }

            if (!String.IsNullOrWhiteSpace(cDocumentoIDT))
            {

                cboMes1.cargarTodos(cDocumentoIDT, idTipoDocumentoT, idTipoDocumentoT);
                cboMes1.SelectedIndex = 0;
                lblClasifInt.Text = (idClasifInternaT == 0) ? string.Empty : cClasifInternaT;

                //Clasificacion Cliente
                dtClasificacionCliente = objCE.CNObtenerClasificacionTitularConyuge(cDocumentoIDT, idTipoDocumentoT);
       
                if (dtClasificacionCliente.Rows.Count > 1)
                {
                    dtConyuge = dtClasificacionCliente.AsEnumerable().Where(r => r.Field<string>("cCondicion") == "Conyuge").CopyToDataTable();
                }
             
               //Recupera informacion Posicion integral de intervinientes
                var dtTodosCreditos = Credito.CNdtLisCrexCli(idClienteT);
                dtLisCredxCli = dtTodosCreditos.Clone();

                var idEstado = Convert.ToInt32(cboEstadoCredito.SelectedValue);

                if (idEstado == 0)
                {
                    dtLisCredxCli = dtTodosCreditos;
                }
                else
                {
                    (from item in dtTodosCreditos.AsEnumerable()
                     where Convert.ToInt32(item["idEstado"]) == idEstado
                     select item).CopyToDataTable(dtLisCredxCli, LoadOption.OverwriteChanges);

                    dtLisCredxCli.Columns["nNumOrdCre"].ReadOnly = false;

                    for (int i = 0; i < dtLisCredxCli.Rows.Count; i++)
                    {
                        dtLisCredxCli.Rows[i]["nNumOrdCre"] = i + 1;
                    }
                }

                //Carga datos posicionintegral de intervinientes
                dtgCreditos.DataSource = dtLisCredxCli;
                //Realiza Grafico
                MostrarGrafico(cDocumentoIDT);

                this.FormatoGridCreditos();
                this.btnCancelar.Enabled = true;
                this.btnImprimir1.Enabled = true;
                btnBusqueda1.Enabled = true;
   
                cboMes1.Enabled = true;
        
                //Lista PEP
                dtLisDetPep = ConvertToDataTable(cninterviniente.dtLisPEPPosInterv(idTipoDocumentoT, cDocumentoIDT).AsEnumerable().OrderBy(r => Convert.ToInt32(r.Field<Int32>("nvinculado"))).Select(dr => new 
                     {
                    nvinculado = dr["nvinculado"].ToString() == "1" ? "Titular" : "Conyuge",
                    dfecini = Convert.ToDateTime(dr["dfecini"]).ToString("dd/MM/yyyy"),
                    dfecfin = Convert.ToDateTime(dr["dfecfin"]).ToString("dd/MM/yyyy"),
                    cubigeo = dr["cubigeo"].ToString(),
                    ccargo = dr["ccargo"].ToString()
                }).ToList());

                if (dtLisDetPep.Rows.Count > 0)
                {
                    dtgDetPep.DataSource = dtLisDetPep;
                    FormatoListaPep();
                }
                else
                {
                    dtLisVacio.Clear();

                    dtLisVacio.Rows.Add(0, "No se encontraron Registro");
                    dtgDetPep.DataSource = dtLisVacio;
                }
                //Lista Base Negativa
                dtLisBaseNeg = ConvertToDataTable(cninterviniente.dtLisBaseNegativa(idTipoDocumentoT, cDocumentoIDT).AsEnumerable().OrderBy(r => Convert.ToInt32(r.Field<Int32>("nvinculado"))).Select(dr => new 
                {
                    nvinculado = dr["nvinculado"].ToString() == "1" ? "Titular" : "Conyuge",
                    dfechaReg = Convert.ToDateTime(dr["dfechaReg"]).ToString("dd/MM/yyyy"),
                    cDescripcion = dr["cDescripcion"].ToString(),
                    cMotivo = dr["cMotivo"].ToString(),
                    cNombre = dr["cNombre"].ToString(),
              
                }).ToList());
    

                if (dtLisBaseNeg.Rows.Count > 0)
                {
                    dtgDetBaseNeg.DataSource = dtLisBaseNeg;
                    FormatoDetalleBaseNegativa();
                }
                else
                {
                    dtLisVacio.Clear();

                    dtLisVacio.Rows.Add(0, "No se encontraron Registro");
                    dtgDetBaseNeg.DataSource = dtLisVacio;
                }
            
                //Liberación Base Negativa
                dtLiberacionsBaseNeg = ConvertToDataTable(cninterviniente.dtLisLibBaseNegativa(idTipoDocumentoT, cDocumentoIDT).AsEnumerable().OrderBy(r => Convert.ToInt32(r.Field<Int32>("nvinculado"))).Select(dr => new 
                 {
                    nvinculado = dr["nvinculado"].ToString() == "1" ? "Titular" : "Conyuge",
                    dFecHoraRegistro = Convert.ToDateTime(dr["dFecHoraRegistro"]).ToString("dd/MM/yyyy"),
                    cDescripcion = dr["cDescripcion"].ToString(),
                    cSustento = dr["cSustento"].ToString(),
                    cNombreMod = dr["cNombreMod"].ToString(),
              
                }).ToList());
                if (dtLiberacionsBaseNeg.Rows.Count > 0)
                {
                    dtgLiberacionBaseNeg.DataSource = dtLiberacionsBaseNeg;
                    FormatoLiberacionBaseNeg();
                }
                else
                {

                    dtLisVacio.Clear();

                    dtLisVacio.Rows.Add(0, "No se encontraron Registro");
                    dtgLiberacionBaseNeg.DataSource = dtLisVacio;

                }

                //Carga Oferta
                dtLisOferta = objCE.CNObterneOfertaPersonaMoneda(cDocumentoIDT, idTipoDocumentoT);
                #region FORMATO GRILLA LISTA OFERTA
                if (dtLisOferta.Rows.Count > 0)
                {
                    dtgOfertas.DataSource = dtLisOferta;
                    dtgOfertas.Columns["btnOtorgar"].Visible = true;
                    dtgOfertas.Columns["btnSeguimiento"].Visible = true;
                    dtgOfertas.Columns["btnOtorgar"].DisplayIndex = 0;
                    dtgOfertas.Columns["btnSeguimiento"].DisplayIndex = 1;
                    dtgOfertas.Columns["cTipoClienteExclusivo"].DisplayIndex = 2;
                    dtgOfertas.Columns["cTipoClienteExclusivo"].HeaderText = "Tipo Cliente Exclusivo";
                    dtgOfertas.Columns["cTipoGrupoCamp"].DisplayIndex = 3;
                    dtgOfertas.Columns["cTipoGrupoCamp"].HeaderText = "Tipo Grupo Campaña";
                    dtgOfertas.Columns["cPeriodoCred"].DisplayIndex = 4;
                    dtgOfertas.Columns["cPeriodoCred"].HeaderText = "Tipo Periodo";
                    dtgOfertas.Columns["cMoneda"].DisplayIndex = 5;
                    dtgOfertas.Columns["cMoneda"].HeaderText = "Moneda";
                    dtgOfertas.Columns["cGrupoProducto"].DisplayIndex = 6;
                    dtgOfertas.Columns["cGrupoProducto"].HeaderText = "Grupo Producto";
                    dtgOfertas.Columns["cGrupoProducto"].Width = 370;
                    dtgOfertas.Columns["nMontoOferta"].DisplayIndex = 7;
                    dtgOfertas.Columns["nMontoOferta"].HeaderText = "Monto";
                    dtgOfertas.Columns["nPlazo"].DisplayIndex = 8;
                    dtgOfertas.Columns["nPlazo"].HeaderText = "Plazo";
                    dtgOfertas.Columns["cOperacion"].DisplayIndex = 9;
                    dtgOfertas.Columns["cOperacion"].HeaderText = "Operación";
                    dtgOfertas.Columns["cGrupoCamp"].DisplayIndex = 10;
                    dtgOfertas.Columns["cGrupoCamp"].HeaderText = "Grupo Campaña";
                    dtgOfertas.Columns["cGrupoCamp"].Width = 370;
                    dtgOfertas.Columns["idGrupoProducto"].Visible = false;
                    dtgOfertas.Columns["idTipoClienteExclusivo"].Visible = false;
                    dtgOfertas.Columns["idTipoGrupoCamp"].Visible = false;
                    dtgOfertas.Columns["idPeriodoCre"].Visible = false;
                    dtgOfertas.Columns["idOperacion"].Visible = false;
                    dtgOfertas.Columns["idModalidadCredito"].Visible = false;
                    dtgOfertas.Columns["cModalidadCredito"].Visible = false;
                    dtgOfertas.Columns["nMeses"].Visible = false;
                    dtgOfertas.Columns["idGrupoCamp"].Visible = false;
                    dtgOfertas.Columns["cDocumentoID"].Visible = false;
                    dtgOfertas.Columns["idTipoDocumento"].Visible = false;
                    dtgOfertas.Columns["cTipoDocumento"].Visible = false;
                    dtgOfertas.Columns["cNombreCliOferta"].Visible = false;
                    dtgOfertas.Columns["idDestinoCredito"].Visible = false;
                    dtgOfertas.Columns["cDestinoCredito"].Visible = false;
                    dtgOfertas.Columns["lCargaAutomaticaProd"].DisplayIndex = 11;
                    dtgOfertas.Columns["idOferta"].Visible = false;
                    dtgOfertas.Columns["idCli"].Visible = false;
                }
                else
                {

                    dtLisVacio.Clear();

                    dtLisVacio.Rows.Add(0, "No se encontraron Registro");
                    dtgOfertas.DataSource = dtLisVacio;
                    dtgOfertas.Columns["btnOtorgar"].Visible = false;
                    dtgOfertas.Columns["btnSeguimiento"].Visible = false;

                }
                #endregion

            }
            else
            {
                this.btnCancelar.Enabled = false;
                this.btnImprimir1.Enabled = false;
                btnBusqueda1.Enabled = false;
      
                cboMes1.Enabled = false;
         
                this.conBusDocumento.txtDocumentoID.Focus();
                this.LimpiarControles();

            }
            this.dtgCreditos.Focus();
            objLisTituConyuge = new List<TitularConyuge>();
            List<DataSenInfBasica> ListaSunatInfoSentinelTitular = new List<DataSenInfBasica>();
            List<DataSenInfBasica> ListaSunatInfoSentinelConyuge = new List<DataSenInfBasica>();
    
            for (int i = 0; i < dtClasificacionCliente.Rows.Count; i++)
            {
                string dni = dtClasificacionCliente.Rows[i]["cNumDocumento"].ToString();
                TitularConyuge modelTituConyuge = new TitularConyuge();
                modelTituConyuge.cCondicion = dtClasificacionCliente.Rows[i]["cCondicion"].ToString();
                modelTituConyuge.ctipoDocumento = dtClasificacionCliente.Rows[i]["ctipoDocumento"].ToString();
                modelTituConyuge.cnombre = dtClasificacionCliente.Rows[i]["cnombre"].ToString();
                modelTituConyuge.cNumDocumento = dtClasificacionCliente.Rows[i]["cNumDocumento"].ToString();
                modelTituConyuge.idCli = Convert.ToInt32(dtClasificacionCliente.Rows[i]["idCli"].ToString());
                modelTituConyuge.cCalificacion = dtClasificacionCliente.Rows[i]["cCalificacion"].ToString();
                modelTituConyuge.cEstadoCivil = dtClasificacionCliente.Rows[i]["cEstadoCivil"].ToString();
                modelTituConyuge.cEdad = dtClasificacionCliente.Rows[i]["cEdad"].ToString();
                modelTituConyuge.cTipoCliente = dtClasificacionCliente.Rows[i]["cTipoCliente"].ToString();
                modelTituConyuge.idTipoDocumento = Convert.ToInt32(dtClasificacionCliente.Rows[i]["idTipoDocumento"].ToString());
                //Sentinel
                if (idTipoDocumentoT==1) //PERSONA NATURAL
                {
                    objRespuesta = objCentraRsgExterno.ConsultaClienteExterno(clsVarGlobal.User.idUsuario, dtClasificacionCliente.Rows[i]["cNumDocumento"].ToString(), "D");
                    if (dtClasificacionCliente.Rows[i]["cCondicion"].ToString() == "Titular")
                    {
                        objRespuestaTitular = objRespuesta;
                    }
                    else
                    {
                        objRespuestaConyuge = objRespuesta;
                    }
                }
                if (idTipoDocumentoT == 4)//PERSONA JURIDICA
                {
                    objRespuesta = objCentraRsgExterno.ConsultaClienteExterno(clsVarGlobal.User.idUsuario, dtClasificacionCliente.Rows[i]["cNumDocumento"].ToString(), "R");
                    if (dtClasificacionCliente.Rows[i]["cCondicion"].ToString() == "Titular")
                    {
                        objRespuestaTitular = objRespuesta;
                    }
                }
                if (objRespuesta.Data == null || objRespuesta.Data.Count == 0)
                {
                    MessageBox.Show("El Servicio no está devolviendo los datos correctamente. Por Favor Contacte con el Area de Soporte","Posicion Consolidada",MessageBoxButtons.OK,MessageBoxIcon.Warning);

                    modelTituConyuge.PuntajeScore = "";
                    modelTituConyuge.nRiesgo = "";
                    modelTituConyuge.CapacidadPago = "";
                    modelTituConyuge.cRelNDoc = "";
                    objLisTituConyuge.Add(modelTituConyuge);
                    return;
                }

                DataSenEvalSabio dataSabio = objRespuesta.Data[0].Sabio;
                modelTituConyuge.PuntajeScore = dataSabio.ScoreSabio == 0 ? "" : Convert.ToString(dataSabio.ScoreSabio);
                modelTituConyuge.nRiesgo = dataSabio.NivelRiesgo;
                modelTituConyuge.CapacidadPago = dataSabio.CapacidadPago;
    
                #region LINEA DE CREDITO NO UTILIZADA
                //LINEA DE CREDITO NO UTILIZADA
                if (objRespuesta.Data[0].ConRap.UtiLinCre.Count > 0)
                {
                    UtiLinCre = objRespuesta.Data[0].ConRap.UtiLinCre;
                    switch (dtClasificacionCliente.Rows[i]["cCondicion"].ToString())
                    {
                        case "Titular":
                            dtlCredNoUtilizadaT.Clear();
                            dtgLineaCreditoNoUtilTitular.DataSource = null;
                            for (int iLCredNoUtili = 0; iLCredNoUtili < UtiLinCre.Count; iLCredNoUtili++)
                            {
                                DataRow rowlCredNoUtilizadaT = dtlCredNoUtilizadaT.NewRow();
                                rowlCredNoUtilizadaT["Condicion"]= "Titular";
                                rowlCredNoUtilizadaT["Inst"]     = UtiLinCre[iLCredNoUtili].Inst;
                                rowlCredNoUtilizadaT["LinApr"]   = UtiLinCre[iLCredNoUtili].LinApr.ToString();
                                rowlCredNoUtilizadaT["LinNoUti"] = UtiLinCre[iLCredNoUtili].LinNoUti.ToString();
                                rowlCredNoUtilizadaT["LinUti"]   = UtiLinCre[iLCredNoUtili].LinUti.ToString();
                                rowlCredNoUtilizadaT["TipCred"]  = UtiLinCre[iLCredNoUtili].TipCred.ToString();
                                dtlCredNoUtilizadaT.Rows.Add(rowlCredNoUtilizadaT);
                            }

                            dtgLineaCreditoNoUtilTitular.DataSource = dtlCredNoUtilizadaT;
                            FormatoLineCreditoTitular();

                            break;
                        case "Conyuge":
                            dtlCredNoUtilizadaC.Clear();
                            dtgLineaCreditoNoUtilConyuge.DataSource = null;
                            for (int iLCredNoUtiliConyuge = 0; iLCredNoUtiliConyuge < UtiLinCre.Count; iLCredNoUtiliConyuge++)
                            {
                                DataRow rowlCredNoUtilizadaC = dtlCredNoUtilizadaC.NewRow();
                                rowlCredNoUtilizadaC["Condicion"] = "Cónyuge";
                                rowlCredNoUtilizadaC["Inst"] = UtiLinCre[iLCredNoUtiliConyuge].Inst;
                                rowlCredNoUtilizadaC["LinApr"] = UtiLinCre[iLCredNoUtiliConyuge].LinApr.ToString();
                                rowlCredNoUtilizadaC["LinNoUti"] = UtiLinCre[iLCredNoUtiliConyuge].LinNoUti.ToString();
                                rowlCredNoUtilizadaC["LinUti"] = UtiLinCre[iLCredNoUtiliConyuge].LinUti.ToString();
                                rowlCredNoUtilizadaC["TipCred"] = UtiLinCre[iLCredNoUtiliConyuge].TipCred.ToString();
                                dtlCredNoUtilizadaC.Rows.Add(rowlCredNoUtilizadaC);
                            }
                            dtgLineaCreditoNoUtilConyuge.DataSource = dtlCredNoUtilizadaC;
                            FormatoLineCreditoConyuge();
                            break;
                    }
                }
                else
                {
                    dtLisVacio.Clear();
                    dtLisVacio.Rows.Add(0, "No se encontraron Registro");
                    if (i==0)
                    {
                        dtgLineaCreditoNoUtilTitular.DataSource = dtLisVacio;
                    }
                    if (i == 1)
                    {
                        dtgLineaCreditoNoUtilConyuge.DataSource = dtLisVacio;
                    }
                   
                   
                  
                }
                #endregion
                #region HISTORICO DEUDA
                if (objRespuesta.Data[0].ConRap.DetSBSMicr.Count > 0)
                {
                    DetSBSMicr = objRespuesta.Data[0].ConRap.DetSBSMicr;
                   
                    switch (dtClasificacionCliente.Rows[i]["cCondicion"].ToString())
                    {
                        case "Titular":
                            dtMicrTitular.Clear();
                            dtgEntNoSupervisada.DataSource = null;
                            for (int iSBSMicro = 0; iSBSMicro < objRespuesta.Data[0].ConRap.DetSBSMicr.Count; iSBSMicro++)
                            {                                 
                                DateTime dtFechaProc = new DateTime(objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].ano, objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].mes, 1);
                                for (int iDetalle = 0; iDetalle < objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle.Count; iDetalle++)
                                {
                                    rowMicrTitular = dtMicrTitular.NewRow();

                                    rowMicrTitular["Condicion"] = "Titular";
                                    rowMicrTitular["NomEnt"]    = objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle[iDetalle].NomEnt;
                                    rowMicrTitular["Cal"]       =objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle[iDetalle].Cal;
                                    rowMicrTitular["SalDeu"]    = objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle[iDetalle].SalDeu;
                                    rowMicrTitular["DiaVen"]    = objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle[iDetalle].DiaVen;
                                    rowMicrTitular["FchPro"]    = fechaformateada(objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle[iDetalle].FchPro);
                                    rowMicrTitular["FchRep"]    = objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle[iDetalle].FchRep;
                                    rowMicrTitular["FchProNumero"] = dtFechaProc.ToString("yyyy-MM");
                                    rowMicrTitular["DeudaTotal"] = objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle.Sum(x => Convert.ToDecimal(x.SalDeu)); 

                                    dtMicrTitular.Rows.Add(rowMicrTitular);
                                }
                                if (objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle.Count==0)
                                {
                                    rowMicrTitular = dtMicrTitular.NewRow();
                                    rowMicrTitular["Condicion"] = "Titular";
                                    rowMicrTitular["NomEnt"]    = "";
                                    rowMicrTitular["Cal"]       ="SCAL";
                                    rowMicrTitular["SalDeu"]    = 0;
                                    rowMicrTitular["DiaVen"]    = 0;
                                    rowMicrTitular["FchPro"]    = fechaformateada(objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].ano+"-"+objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].mes);
                                    rowMicrTitular["FchRep"]    = "";
                                    rowMicrTitular["FchProNumero"] = dtFechaProc.ToString("yyyy-MM");
                                    rowMicrTitular["DeudaTotal"] = 0; 
                                    dtMicrTitular.Rows.Add(rowMicrTitular);
                                }

                                
                            }
                            LLenarComboHistoricoDeduaSentinelTitular(dtMicrTitular);
                            BuscarDeudaSentinelTitular();
                            btnBuscaDeudaSentinelTitular.Enabled = true;
                            btnBuscaDeudaSentinelConyuge.Enabled = true;
                            cSemaforoTitular = objRespuesta.Data[0].ConRap.Resumen_ConRap.Semaforos;
                           
                  
                            break;
                        case "Conyuge":
                            dtMicrConyuge.Clear();
                            dtgEntNoSupervisadaConyuge.DataSource = null;
                            for (int iSBSMicro = 0; iSBSMicro < objRespuesta.Data[0].ConRap.DetSBSMicr.Count; iSBSMicro++)
                            {
                                DateTime dtFechaProc = new DateTime(objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].ano, objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].mes, 1);
                                for (int iDetalle = 0; iDetalle < objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle.Count; iDetalle++)
                                {
                                    rowMicrConyuge = dtMicrConyuge.NewRow();
                                    rowMicrConyuge["Condicion"] = "Cónyuge";
                                    rowMicrConyuge["NomEnt"] = objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle[iDetalle].NomEnt;
                                    rowMicrConyuge["Cal"] = objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle[iDetalle].Cal;
                                    rowMicrConyuge["SalDeu"] = objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle[iDetalle].SalDeu;
                                    rowMicrConyuge["DiaVen"] = objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle[iDetalle].DiaVen;
                                    rowMicrConyuge["FchPro"] = fechaformateada(objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle[iDetalle].FchPro);
                                    rowMicrConyuge["FchRep"] = objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle[iDetalle].FchRep;
                                    rowMicrConyuge["FchProNumero"] = dtFechaProc.ToString("yyyy-MM"); 
                                    dtMicrConyuge.Rows.Add(rowMicrConyuge);
                                }
                                if (objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle.Count == 0)
                                {
                                    rowMicrConyuge = dtMicrConyuge.NewRow();
                                    rowMicrConyuge["Condicion"] = "Cónyuge";
                                    rowMicrConyuge["NomEnt"] = "";
                                    rowMicrConyuge["Cal"] = "SCAL";
                                    rowMicrConyuge["SalDeu"] = 0;
                                    rowMicrConyuge["DiaVen"] = 0;
                                    rowMicrConyuge["FchPro"] = fechaformateada(objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].ano + "-" + objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].mes);
                                    rowMicrConyuge["FchRep"] = "";
                                    rowMicrConyuge["FchProNumero"] = dtFechaProc.ToString("yyyy-MM");

                                    dtMicrConyuge.Rows.Add(rowMicrConyuge);
                                }
                            }
                            LLenarComboHistoricoDeduaSentinelConyuge(dtMicrConyuge);
                            BuscarDeudaSentinelConyuge();
                            btnBuscaDeudaSentinelConyuge.Enabled = true;
                            cSemaforoConyuge = objRespuesta.Data[0].ConRap.Resumen_ConRap.Semaforos;
                         

                            break;
                    }
                }
                else
                {
                    
                    dtLisVacio.Clear();
                    dtLisVacio.Rows.Add(0, "No se encontraron Registro");
                    if (i==0)
                    {
                        dtgEntNoSupervisada.DataSource = dtLisVacio;
                    }
                    if (i == 1)
                    {
                        dtgEntNoSupervisadaConyuge.DataSource = dtLisVacio;
                    }
                  

                }
                #endregion
   
                #region DATOS BASICO SUNAT 
                dataBasicoSunat = objRespuesta.Data[0].InfBas;
                modelTituConyuge.cRelNDoc = dataBasicoSunat.RelNDoc;
                if (dataBasicoSunat!=null)
                {
                    if (idTipoDocumentoT == 1) //PERSONA NATURAL
                    {
                        switch (dtClasificacionCliente.Rows[i]["cCondicion"].ToString())
                        {
                            case "Titular":
                                dtBasicoSunatTitular.Clear();
                                ListaSunatInfoSentinelTitular.Add(dataBasicoSunat);
                                dtgvSentinelSunatTitular.DataSource = ListaSunatInfoSentinelTitular;

                                FormatoSentinelInfoBasicaTitular();

                                DataRow rowBasicoSunatTitular = dtBasicoSunatTitular.NewRow();

                                rowBasicoSunatTitular["TDoc"]       = dataBasicoSunat.TDoc;
                                rowBasicoSunatTitular["NDoc"]       = dataBasicoSunat.NDoc;
                                rowBasicoSunatTitular["RelTDOC"]    = dataBasicoSunat.RelTDoc;
                                rowBasicoSunatTitular["RelNDoc"]    = dataBasicoSunat.RelNDoc;
                                rowBasicoSunatTitular["RazSoc"]     = dataBasicoSunat.RazSoc;
                                rowBasicoSunatTitular["NomCom"]     = dataBasicoSunat.NomCom;
                                rowBasicoSunatTitular["TipCon"]     = dataBasicoSunat.TipCon;
                                rowBasicoSunatTitular["IniAct"]     = dataBasicoSunat.IniAct;
                                rowBasicoSunatTitular["ActEco"]     = dataBasicoSunat.ActEco;
                                rowBasicoSunatTitular["FchInsRRPP"] = dataBasicoSunat.FchInsRRPP;
                                rowBasicoSunatTitular["AgeRet"]     = dataBasicoSunat.AgeRet;
                                rowBasicoSunatTitular["ApePat"]     = dataBasicoSunat.ApePat;
                                rowBasicoSunatTitular["ApeMat"]     = dataBasicoSunat.ApeMat;
                                rowBasicoSunatTitular["Nom"]        = dataBasicoSunat.Nom;
                                rowBasicoSunatTitular["Sex"]        = dataBasicoSunat.Sex;
                                rowBasicoSunatTitular["EstCon"]     = dataBasicoSunat.EstCon;
                                rowBasicoSunatTitular["EstDom"]     = dataBasicoSunat.EstCon;
                                rowBasicoSunatTitular["EstDomic"]   = dataBasicoSunat.EstCon;
                                rowBasicoSunatTitular["CondDomic"]  = dataBasicoSunat.EstCon;
                                dtBasicoSunatTitular.Rows.Add(rowBasicoSunatTitular);
                                break;
                            case "Conyuge":
                                dtBasicoSunatConyuge.Clear();
                                ListaSunatInfoSentinelConyuge.Add(dataBasicoSunat);
                                dtgvSentinelSunatConyuge.DataSource = ListaSunatInfoSentinelConyuge;
                                FormatoSentinelInfoBasicaConyuge();

                                DataRow rowBasicoSunatConyuge = dtBasicoSunatConyuge.NewRow();

                                rowBasicoSunatConyuge["TDoc"] = dataBasicoSunat.TDoc;
                                rowBasicoSunatConyuge["NDoc"] = dataBasicoSunat.NDoc;
                                rowBasicoSunatConyuge["RelTDOC"] = dataBasicoSunat.RelTDoc;
                                rowBasicoSunatConyuge["RelNDoc"] = dataBasicoSunat.RelNDoc;
                                rowBasicoSunatConyuge["RazSoc"] = dataBasicoSunat.RazSoc;
                                rowBasicoSunatConyuge["NomCom"] = dataBasicoSunat.NomCom;
                                rowBasicoSunatConyuge["TipCon"] = dataBasicoSunat.TipCon;
                                rowBasicoSunatConyuge["IniAct"] = dataBasicoSunat.IniAct;
                                rowBasicoSunatConyuge["ActEco"] = dataBasicoSunat.ActEco;
                                rowBasicoSunatConyuge["FchInsRRPP"] = dataBasicoSunat.FchInsRRPP;
                                rowBasicoSunatConyuge["AgeRet"] = dataBasicoSunat.AgeRet;
                                rowBasicoSunatConyuge["ApePat"] = dataBasicoSunat.ApePat;
                                rowBasicoSunatConyuge["ApeMat"] = dataBasicoSunat.ApeMat;
                                rowBasicoSunatConyuge["Nom"] = dataBasicoSunat.Nom;
                                rowBasicoSunatConyuge["Sex"] = dataBasicoSunat.Sex;
                                rowBasicoSunatConyuge["EstCon"] = dataBasicoSunat.EstCon;
                                rowBasicoSunatConyuge["EstDom"] = dataBasicoSunat.EstCon;
                                rowBasicoSunatConyuge["EstDomic"] = dataBasicoSunat.EstCon;
                                rowBasicoSunatConyuge["CondDomic"] = dataBasicoSunat.EstCon;
                                dtBasicoSunatConyuge.Rows.Add(rowBasicoSunatConyuge);
                                break;

                        }
                    }
                    if (idTipoDocumentoT == 4)//PERSONA JURIDICA
                    {
                        dtBasicoSunatTitular.Clear();
                        ListaSunatInfoSentinelTitular.Add(dataBasicoSunat);
                        dtgvSentinelSunatTitular.DataSource = ListaSunatInfoSentinelTitular;

                        FormatoSentinelInfoBasicaTitular();

                        DataRow rowBasicoSunatTitular = dtBasicoSunatTitular.NewRow();

                        rowBasicoSunatTitular["TDoc"] = dataBasicoSunat.TDoc;
                        rowBasicoSunatTitular["NDoc"] = dataBasicoSunat.NDoc;
                        rowBasicoSunatTitular["RelTDOC"] = dataBasicoSunat.RelTDoc;
                        rowBasicoSunatTitular["RelNDoc"] = dataBasicoSunat.RelNDoc;
                        rowBasicoSunatTitular["RazSoc"] = dataBasicoSunat.RazSoc;
                        rowBasicoSunatTitular["NomCom"] = dataBasicoSunat.NomCom;
                        rowBasicoSunatTitular["TipCon"] = dataBasicoSunat.TipCon;
                        rowBasicoSunatTitular["IniAct"] = dataBasicoSunat.IniAct;
                        rowBasicoSunatTitular["ActEco"] = dataBasicoSunat.ActEco;
                        rowBasicoSunatTitular["FchInsRRPP"] = dataBasicoSunat.FchInsRRPP;
                        rowBasicoSunatTitular["AgeRet"] = dataBasicoSunat.AgeRet;
                        rowBasicoSunatTitular["ApePat"] = dataBasicoSunat.ApePat;
                        rowBasicoSunatTitular["ApeMat"] = dataBasicoSunat.ApeMat;
                        rowBasicoSunatTitular["Nom"] = dataBasicoSunat.Nom;
                        rowBasicoSunatTitular["Sex"] = dataBasicoSunat.Sex;
                        rowBasicoSunatTitular["EstCon"] = dataBasicoSunat.EstCon;
                        rowBasicoSunatTitular["EstDom"] = dataBasicoSunat.EstCon;
                        rowBasicoSunatTitular["EstDomic"] = dataBasicoSunat.EstCon;
                        rowBasicoSunatTitular["CondDomic"] = dataBasicoSunat.EstCon;
                        dtBasicoSunatTitular.Rows.Add(rowBasicoSunatTitular);

                    }

                }
                #endregion
                objLisTituConyuge.Add(modelTituConyuge);
                #region ES REPLEGAL
                ListEsRepLegDe = objRespuesta.Data[0].InfGen.EsRepLegDe;
                if (ListEsRepLegDe.Count > 0)
                {
                    if (idTipoDocumentoT == 1) //PERSONA NATURAL
                    {
                        switch (dtClasificacionCliente.Rows[i]["cCondicion"].ToString())
                        {
                            case "Titular":
                                dtRlegalTitular.Clear();
                                dtgvRLegalTitular.DataSource = ListEsRepLegDe;
                                FormatoRepresentanteLegalTitular(idTipoDocumentoT);

                                for (int iRlegalTitular = 0; iRlegalTitular < ListEsRepLegDe.Count; iRlegalTitular++)
                                {
                                    DataRow rowRlegalTitular = dtRlegalTitular.NewRow();

                                    rowRlegalTitular["TDOC"] = ListEsRepLegDe[iRlegalTitular].TDOC;
                                    rowRlegalTitular["NDOC"] = ListEsRepLegDe[iRlegalTitular].NDOC.ToString();
                                    rowRlegalTitular["Nombre"] = ListEsRepLegDe[iRlegalTitular].RazSoc.ToString();
                                    rowRlegalTitular["FecIniCar"] = ListEsRepLegDe[iRlegalTitular].FecIniCar.ToString();
                                    rowRlegalTitular["Cargo"] = ListEsRepLegDe[iRlegalTitular].Cargo.ToString();
                                    dtRlegalTitular.Rows.Add(rowRlegalTitular);
                                }


                                break;
                            case "Conyuge":
                                dtRlegalConyuge.Clear();
                                dtgvRLegalConyuge.DataSource = ListEsRepLegDe;
                                FormatoRepresentanteLegalConyuge(idTipoDocumentoT);

                                for (int iRlegalConyuge = 0; iRlegalConyuge < ListEsRepLegDe.Count; iRlegalConyuge++)
                                {
                                    DataRow rowRlegalConyuge = dtRlegalConyuge.NewRow();

                                    rowRlegalConyuge["TDOC"] = ListEsRepLegDe[iRlegalConyuge].TDOC;
                                    rowRlegalConyuge["NDOC"] = ListEsRepLegDe[iRlegalConyuge].NDOC.ToString();
                                    rowRlegalConyuge["Nombre"] = ListEsRepLegDe[iRlegalConyuge].RazSoc.ToString();
                                    rowRlegalConyuge["FecIniCar"] = ListEsRepLegDe[iRlegalConyuge].FecIniCar.ToString();
                                    rowRlegalConyuge["Cargo"] = ListEsRepLegDe[iRlegalConyuge].Cargo.ToString();
                                    dtRlegalConyuge.Rows.Add(rowRlegalConyuge);
                                }
                                break;
                        }
                    }
                }
                #endregion
                #region LISTA REPLEGAL
                ListRepLeg = objRespuesta.Data[0].InfGen.RepLeg;
                if (ListRepLeg.Count > 0)
                {
                    if (idTipoDocumentoT == 4)//PERSONA JURIDICA
                    {
                        dtRlegalTitular.Clear();
                        dtgvRLegalTitular.DataSource = ListRepLeg;
                        FormatoRepresentanteLegalTitular(idTipoDocumentoT);

                        for (int iRlegalTitular = 0; iRlegalTitular < ListRepLeg.Count; iRlegalTitular++)
                        {
                            DataRow rowRlegalTitular = dtRlegalTitular.NewRow();

                            rowRlegalTitular["TDOC"] = ListRepLeg[iRlegalTitular].TDOC;
                            rowRlegalTitular["NDOC"] = ListRepLeg[iRlegalTitular].NDOC.ToString();
                            rowRlegalTitular["Nombre"] = ListRepLeg[iRlegalTitular].Nombre.ToString();
                            rowRlegalTitular["FecIniCar"] = ListRepLeg[iRlegalTitular].FecIniCar.ToString();
                            rowRlegalTitular["Cargo"] = ListRepLeg[iRlegalTitular].Cargo.ToString();
                            dtRlegalTitular.Rows.Add(rowRlegalTitular);
                        }


                    }
                }
                #endregion
                #region DIRECCIONES 
                //Direcciones TITULAR, CONYUGE, JURIDICA
                Direcc = objRespuesta.Data[0].InfGen.Direcc;

                if (Direcc.Count > 0)
                {
                    if (idTipoDocumentoT == 1) //PERSONA NATURAL
                    {
                        switch (dtClasificacionCliente.Rows[i]["cCondicion"].ToString())
                        {
                            case "Titular":
                                dtBSunatDireccionTitular.Clear();
                                dtgDireccionTitular.DataSource = Direcc;
                                dtgDireccionTitular.Columns[0].Width = 500;
                                dtgDireccionTitular.Columns[1].Width = 200;

                                for (int iDireccSunatT = 0; iDireccSunatT < Direcc.Count; iDireccSunatT++)
                                {
                                    DataRow rowBSunatDireccionTitular = dtBSunatDireccionTitular.NewRow();
                                    rowBSunatDireccionTitular["Direccion"] = Direcc[iDireccSunatT].Direccion;
                                    rowBSunatDireccionTitular["Fuente"] = Direcc[iDireccSunatT].Fuente;
                                    dtBSunatDireccionTitular.Rows.Add(rowBSunatDireccionTitular);
                                }


                                break;
                            case "Conyuge":
                                dtBSunatDireccionConyuge.Clear();
                                dtgDireccionConyuge.DataSource = Direcc;
                                dtgDireccionConyuge.Columns[0].Width = 500;
                                dtgDireccionConyuge.Columns[1].Width = 200;

                                for (int iDireccSunatC = 0; iDireccSunatC < Direcc.Count; iDireccSunatC++)
                                {
                                    DataRow rowBSunatDireccionConyuge = dtBSunatDireccionConyuge.NewRow();
                                    rowBSunatDireccionConyuge["Direccion"] = Direcc[iDireccSunatC].Direccion;
                                    rowBSunatDireccionConyuge["Fuente"] = Direcc[iDireccSunatC].Fuente;
                                    dtBSunatDireccionConyuge.Rows.Add(rowBSunatDireccionConyuge);
                                }

                                break;
                        }
                    }
                    if (idTipoDocumentoT == 4)//PERSONA JURIDICA
                    {
                        dtBSunatDireccionTitular.Clear();
                        dtgDireccionTitular.DataSource = Direcc;
                        dtgDireccionTitular.Columns[0].Width = 500;
                        dtgDireccionTitular.Columns[1].Width = 200;

                        for (int iDireccSunatT = 0; iDireccSunatT < Direcc.Count; iDireccSunatT++)
                        {
                            DataRow rowBSunatDireccionTitular = dtBSunatDireccionTitular.NewRow();
                            rowBSunatDireccionTitular["Direccion"] = Direcc[iDireccSunatT].Direccion;
                            rowBSunatDireccionTitular["Fuente"] = Direcc[iDireccSunatT].Fuente;
                            dtBSunatDireccionTitular.Rows.Add(rowBSunatDireccionTitular);
                        }

                    }
                }
                #endregion
                #region LISTA PROTESTO DEUDA LABORAL
                ListProtestoDeuLaboralSentinel = objRespuesta.Data[0].ConRap.DetVen;
                if (ListProtestoDeuLaboralSentinel != null)
                {
                    if (ListProtestoDeuLaboralSentinel.Count > 0)
                    {
                        switch (dtClasificacionCliente.Rows[i]["cCondicion"].ToString())
                        {
                            case "Titular":
                                dtDeudaTitular.Clear();

                                dtgDeudasTitular.DataSource = null;

                                for (int iDeudaTitular = 0; iDeudaTitular < ListProtestoDeuLaboralSentinel.Count; iDeudaTitular++)
                                {
                                    for (int iVenciDeudaTitular = 0; iVenciDeudaTitular < ListProtestoDeuLaboralSentinel[iDeudaTitular].DetalleVencidos.Count; iVenciDeudaTitular++)
                                    {
                                        DataRow rowDeudaTitular = dtDeudaTitular.NewRow();
                                        rowDeudaTitular["Condicion"] = "Titular";
                                        rowDeudaTitular["idFue"] = ListProtestoDeuLaboralSentinel[iDeudaTitular].IdFue;
                                        rowDeudaTitular["MaxDiaVen"] = ListProtestoDeuLaboralSentinel[iDeudaTitular].MaxDiaVen.ToString();
                                        rowDeudaTitular["NomFue"] = ListProtestoDeuLaboralSentinel[iDeudaTitular].NomFue.ToString();
                                        rowDeudaTitular["VenTot"] = ListProtestoDeuLaboralSentinel[iDeudaTitular].VenTot.ToString();
                                        rowDeudaTitular["NomEnt"] = ListProtestoDeuLaboralSentinel[iDeudaTitular].DetalleVencidos[iVenciDeudaTitular].NomEnt.ToString();
                                        rowDeudaTitular["MontDeu"] = ListProtestoDeuLaboralSentinel[iDeudaTitular].DetalleVencidos[iVenciDeudaTitular].MontDeu.ToString();
                                        rowDeudaTitular["DiaVen"] = ListProtestoDeuLaboralSentinel[iDeudaTitular].DetalleVencidos[iVenciDeudaTitular].DiaVen.ToString();
                                        rowDeudaTitular["NumDoc"] = ListProtestoDeuLaboralSentinel[iDeudaTitular].DetalleVencidos[iVenciDeudaTitular].NumDoc.ToString();

                                        dtDeudaTitular.Rows.Add(rowDeudaTitular);
                                    }
                                }
                                dtgDeudasTitular.DataSource = dtDeudaTitular;
                                dtgDeudasTitular.Columns["Condicion"].Visible = false;
                                dtgDeudasTitular.Columns["idFue"].HeaderText = "ID.de la Fuente";
                                dtgDeudasTitular.Columns["idFue"].DisplayIndex = 1;
                                dtgDeudasTitular.Columns["Nomfue"].HeaderText = "Nombre de la Fuente";
                                dtgDeudasTitular.Columns["Nomfue"].DisplayIndex = 2;
                                dtgDeudasTitular.Columns["Nomfue"].Width = 200;
                                dtgDeudasTitular.Columns["VenTot"].HeaderText = "Deuda Vencido Total";
                                dtgDeudasTitular.Columns["Nomfue"].DisplayIndex = 3;
                                dtgDeudasTitular.Columns["MaxDiaVen"].HeaderText = "Maximo Nro Dias Vencidos";
                                dtgDeudasTitular.Columns["MaxDiaVen"].DisplayIndex = 4;
                                dtgDeudasTitular.Columns["NomEnt"].HeaderText = "Razón Social";
                                dtgDeudasTitular.Columns["NomEnt"].Width = 200;
                                dtgDeudasTitular.Columns["MontDeu"].HeaderText = "Monto.Deuda";
                                dtgDeudasTitular.Columns["MontDeu"].Width = 100;
                                dtgDeudasTitular.Columns["DiaVen"].HeaderText = "Días.Vencidos";
                                dtgDeudasTitular.Columns["DiaVen"].Width = 100;
                                dtgDeudasTitular.Columns["NumDoc"].HeaderText = "Nro.Doc.Vencidos";
                                dtgDeudasTitular.Columns["NumDoc"].Width = 150;
                                break;
                            case "Conyuge":
                                dtDeudaConyuge.Clear();

                                dtgDeudasConyuge.DataSource = null;

                                for (int iDeudaConyuge = 0; iDeudaConyuge < ListProtestoDeuLaboralSentinel.Count; iDeudaConyuge++)
                                {
                                    for (int iVenciDeudaConyuge = 0; iVenciDeudaConyuge < ListProtestoDeuLaboralSentinel[iDeudaConyuge].DetalleVencidos.Count; iVenciDeudaConyuge++)
                                    {
                                        DataRow rowDeudaConyuge = dtDeudaConyuge.NewRow();
                                        rowDeudaConyuge["Condicion"] = "Cónyuge";
                                        rowDeudaConyuge["idFue"] = ListProtestoDeuLaboralSentinel[iDeudaConyuge].IdFue;
                                        rowDeudaConyuge["MaxDiaVen"] = ListProtestoDeuLaboralSentinel[iDeudaConyuge].MaxDiaVen.ToString();
                                        rowDeudaConyuge["NomFue"] = ListProtestoDeuLaboralSentinel[iDeudaConyuge].NomFue.ToString();
                                        rowDeudaConyuge["VenTot"] = ListProtestoDeuLaboralSentinel[iDeudaConyuge].VenTot.ToString();

                                        rowDeudaConyuge["NomEnt"] = ListProtestoDeuLaboralSentinel[iDeudaConyuge].DetalleVencidos[iVenciDeudaConyuge].NomEnt.ToString();
                                        rowDeudaConyuge["MontDeu"] = ListProtestoDeuLaboralSentinel[iDeudaConyuge].DetalleVencidos[iVenciDeudaConyuge].MontDeu.ToString();
                                        rowDeudaConyuge["DiaVen"] = ListProtestoDeuLaboralSentinel[iDeudaConyuge].DetalleVencidos[iVenciDeudaConyuge].DiaVen.ToString();
                                        rowDeudaConyuge["NumDoc"] = ListProtestoDeuLaboralSentinel[iDeudaConyuge].DetalleVencidos[iVenciDeudaConyuge].NumDoc.ToString();
                                        dtDeudaConyuge.Rows.Add(rowDeudaConyuge);

                                    }

                                }

                                dtgDeudasConyuge.DataSource = dtDeudaConyuge;
                                dtgDeudasConyuge.Columns["Condicion"].Visible = false;
                                dtgDeudasConyuge.Columns["idFue"].HeaderText = "ID.de la Fuente";
                                dtgDeudasConyuge.Columns["idFue"].DisplayIndex = 1;
                                dtgDeudasConyuge.Columns["Nomfue"].HeaderText = "Nombre de la Fuente";
                                dtgDeudasConyuge.Columns["Nomfue"].DisplayIndex = 2;
                                dtgDeudasConyuge.Columns["Nomfue"].Width = 200;
                                dtgDeudasConyuge.Columns["VenTot"].HeaderText = "Deuda Vencido Total";
                                dtgDeudasConyuge.Columns["Nomfue"].DisplayIndex = 3;
                                dtgDeudasConyuge.Columns["MaxDiaVen"].HeaderText = "Maximo Nro Dias Vencidos";
                                dtgDeudasConyuge.Columns["MaxDiaVen"].DisplayIndex = 4;
                                dtgDeudasConyuge.Columns["NomEnt"].HeaderText = "Razón Social";
                                dtgDeudasConyuge.Columns["NomEnt"].Width = 200;
                                dtgDeudasConyuge.Columns["MontDeu"].HeaderText = "Monto.Deuda";
                                dtgDeudasConyuge.Columns["MontDeu"].Width = 100;
                                dtgDeudasConyuge.Columns["DiaVen"].HeaderText = "Días.Vencidos";
                                dtgDeudasConyuge.Columns["DiaVen"].Width = 100;
                                dtgDeudasConyuge.Columns["NumDoc"].HeaderText = "Nro.Doc.Vencidos";
                                dtgDeudasConyuge.Columns["NumDoc"].Width = 150;
                                break;
                        }
                    }
                }
                #endregion
                #region LISTA AVALISTA
                LisAvalista = objRespuesta.Data[0].AvalCod.AvalDe;//Avalista
                if (LisAvalista != null)
                {
                    if (LisAvalista.Count > 0)
                    {
                        switch (dtClasificacionCliente.Rows[i]["cCondicion"].ToString())
                        {

                            case "Titular":
                                dtAvalistaTitular.Clear();

                                dtgAvalistaTitular.DataSource = null;

                                for (int iAvalista = 0; iAvalista < LisAvalista.Count; iAvalista++)
                                {
                                    for (int iAcredorAvalista = 0; iAcredorAvalista < LisAvalista[iAvalista].Acreedor.Count; iAcredorAvalista++)
                                    {
                                        DataRow rowAvalistaTitular = dtAvalistaTitular.NewRow();
                                        rowAvalistaTitular["Condicion"] = "Titular";
                                        rowAvalistaTitular["NDoc"] = LisAvalista[iAvalista].NDoc.ToString();
                                        rowAvalistaTitular["RazSoc"] = LisAvalista[iAvalista].RazSoc.ToString();
                                        rowAvalistaTitular["Sem12Mes"] = LisAvalista[iAvalista].Sem12Mes.ToString();
                                        rowAvalistaTitular["SemAct"] = LisAvalista[iAvalista].SemAct.ToString();
                                        rowAvalistaTitular["SemPre"] = LisAvalista[iAvalista].SemPre.ToString();
                                        rowAvalistaTitular["NDocAcre"] = LisAvalista[iAvalista].Acreedor[iAcredorAvalista].NDoc.ToString();
                                        rowAvalistaTitular["RazSocAcre"] = LisAvalista[iAvalista].Acreedor[iAcredorAvalista].RazSoc.ToString();
                                        rowAvalistaTitular["Cal"] = LisAvalista[iAvalista].Acreedor[iAcredorAvalista].Cal.ToString();
                                        rowAvalistaTitular["SalDeu"] = LisAvalista[iAvalista].Acreedor[iAcredorAvalista].SalDeu.ToString();
                                        rowAvalistaTitular["TipEnt"] = LisAvalista[iAvalista].Acreedor[iAcredorAvalista].TipEnt.ToString();
                                        rowAvalistaTitular["FecRep"] = LisAvalista[iAvalista].Acreedor[iAcredorAvalista].FecRep.ToString();

                                        dtAvalistaTitular.Rows.Add(rowAvalistaTitular);

                                    }
                                }

                                dtgAvalistaTitular.DataSource = dtAvalistaTitular;
                                FormatoAvalista();
                                break;
                            case "Conyuge":
                                dtAvalistaConyuge.Clear();

                                dtgAvalistaConyuge.DataSource = null;

                                for (int iAvalistaConyuge = 0; iAvalistaConyuge < LisAvalista.Count; iAvalistaConyuge++)
                                {
                                    for (int iAcredorAvalistaConyuge = 0; iAcredorAvalistaConyuge < LisAvalista[iAvalistaConyuge].Acreedor.Count; iAcredorAvalistaConyuge++)
                                    {
                                        DataRow rowAvalistaConyuge = dtAvalistaConyuge.NewRow();
                                        rowAvalistaConyuge["Condicion"] = "Cónyuge";
                                        rowAvalistaConyuge["NDoc"] = LisAvalista[iAvalistaConyuge].NDoc.ToString();
                                        rowAvalistaConyuge["RazSoc"] = LisAvalista[iAvalistaConyuge].RazSoc.ToString();
                                        rowAvalistaConyuge["Sem12Mes"] = LisAvalista[iAvalistaConyuge].Sem12Mes.ToString();
                                        rowAvalistaConyuge["SemAct"] = LisAvalista[iAvalistaConyuge].SemAct.ToString();
                                        rowAvalistaConyuge["SemPre"] = LisAvalista[iAvalistaConyuge].SemPre.ToString();

                                        rowAvalistaConyuge["NDocAcre"] = LisAvalista[iAvalistaConyuge].Acreedor[iAcredorAvalistaConyuge].NDoc.ToString();
                                        rowAvalistaConyuge["RazSocAcre"] = LisAvalista[iAvalistaConyuge].Acreedor[iAcredorAvalistaConyuge].RazSoc.ToString();
                                        rowAvalistaConyuge["Cal"] = LisAvalista[iAvalistaConyuge].Acreedor[iAcredorAvalistaConyuge].Cal.ToString();
                                        rowAvalistaConyuge["SalDeu"] = LisAvalista[iAvalistaConyuge].Acreedor[iAcredorAvalistaConyuge].SalDeu.ToString();
                                        rowAvalistaConyuge["TipEnt"] = LisAvalista[iAvalistaConyuge].Acreedor[iAcredorAvalistaConyuge].TipEnt.ToString();
                                        rowAvalistaConyuge["FecRep"] = LisAvalista[iAvalistaConyuge].Acreedor[iAcredorAvalistaConyuge].FecRep.ToString();
                                        dtAvalistaConyuge.Rows.Add(rowAvalistaConyuge);

                                    }

                                }
                                dtgAvalistaConyuge.DataSource = dtAvalistaConyuge;
                                FormatoAvalistaConyuge();
                                break;
                        }
                    }
                }
                #endregion
                #region LISTA AVALADO
                Listavalado = objRespuesta.Data[0].AvalCod.QuiAval;//Avalado
                if (Listavalado != null)
                {
                    if (Listavalado.Count > 0)
                    {
                        switch (dtClasificacionCliente.Rows[i]["cCondicion"].ToString())
                        {
                            case "Titular":
                                dtAvalado.Clear();

                                dtgAvaladoTitular.DataSource = null;

                                for (int iAvalado = 0; iAvalado < Listavalado.Count; iAvalado++)
                                {
                                    for (int iAcreedorTitular = 0; iAcreedorTitular < Listavalado[iAvalado].Acreedor.Count; iAcreedorTitular++)
                                    {
                                        rowAvaladoTitular = dtAvalado.NewRow();
                                        rowAvaladoTitular["Condicion"] = "Titular";
                                        rowAvaladoTitular["ndoc"] = Listavalado[iAvalado].NDoc.ToString();
                                        rowAvaladoTitular["tDoc"] = DevuelveTipoDocumento(Listavalado[iAvalado].TDoc.ToString());
                                        rowAvaladoTitular["razSoc"] = Listavalado[iAvalado].RazSoc.ToString();
                                        rowAvaladoTitular["semAct"] = Listavalado[iAvalado].SemAct.ToString();
                                        rowAvaladoTitular["Sem12Mes"] = Listavalado[iAvalado].Sem12Mes.ToString();
                                        rowAvaladoTitular["tDocAcre"] = DevuelveTipoDocumento(Listavalado[iAvalado].Acreedor[iAcreedorTitular].TDoc.ToString());
                                        rowAvaladoTitular["nDocAcre"] = Listavalado[iAvalado].Acreedor[iAcreedorTitular].NDoc.ToString();
                                        rowAvaladoTitular["razSocAcre"] = Listavalado[iAvalado].Acreedor[iAcreedorTitular].RazSoc.ToString();
                                        rowAvaladoTitular["cal"] = Listavalado[iAvalado].Acreedor[iAcreedorTitular].Cal.ToString();
                                        rowAvaladoTitular["tipEnt"] = Listavalado[iAvalado].Acreedor[iAcreedorTitular].TipEnt.ToString();
                                        rowAvaladoTitular["salDeu"] = Listavalado[iAvalado].Acreedor[iAcreedorTitular].SalDeu.ToString();
                                        rowAvaladoTitular["fecRep"] = Listavalado[iAvalado].Acreedor[iAcreedorTitular].FecRep.ToString();

                                        dtAvalado.Rows.Add(rowAvaladoTitular);
                                    }

                                }
                                dtgAvaladoTitular.DataSource = dtAvalado;
                                FormatoAvalado();


                                break;
                            case "Conyuge":
                                dtAvaladoConyuge.Clear();

                                dtgAvaladoConyuge.DataSource = null;

                                for (int iAvaladoConyuge = 0; iAvaladoConyuge < Listavalado.Count; iAvaladoConyuge++)
                                {

                                    for (int iAcreedorConyuge = 0; iAcreedorConyuge < Listavalado[iAvaladoConyuge].Acreedor.Count; iAcreedorConyuge++)
                                    {
                                        rowAvaladoConyuge = dtAvaladoConyuge.NewRow();
                                        rowAvaladoConyuge["Condicion"] = "Cónyuge";
                                        rowAvaladoConyuge["ndoc"] = Listavalado[iAvaladoConyuge].NDoc.ToString();
                                        rowAvaladoConyuge["tDoc"] = DevuelveTipoDocumento(Listavalado[iAvaladoConyuge].TDoc.ToString());
                                        rowAvaladoConyuge["razSoc"] = Listavalado[iAvaladoConyuge].RazSoc.ToString();
                                        rowAvaladoConyuge["semAct"] = Listavalado[iAvaladoConyuge].SemAct.ToString();
                                        rowAvaladoConyuge["Sem12Mes"] = Listavalado[iAvaladoConyuge].Sem12Mes.ToString();

                                        rowAvaladoConyuge["tDocAcre"] = Listavalado[iAvaladoConyuge].Acreedor[iAcreedorConyuge].TDoc.ToString();
                                        rowAvaladoConyuge["nDocAcre"] = DevuelveTipoDocumento(Listavalado[iAvaladoConyuge].Acreedor[iAcreedorConyuge].NDoc.ToString());
                                        rowAvaladoConyuge["razSocAcre"] = Listavalado[iAvaladoConyuge].Acreedor[iAcreedorConyuge].RazSoc.ToString();
                                        rowAvaladoConyuge["cal"] = Listavalado[iAvaladoConyuge].Acreedor[iAcreedorConyuge].Cal.ToString();
                                        rowAvaladoConyuge["tipEnt"] = Listavalado[iAvaladoConyuge].Acreedor[iAcreedorConyuge].TipEnt.ToString();
                                        rowAvaladoConyuge["salDeu"] = Listavalado[iAvaladoConyuge].Acreedor[iAcreedorConyuge].SalDeu.ToString();
                                        rowAvaladoConyuge["fecRep"] = Listavalado[iAvaladoConyuge].Acreedor[iAcreedorConyuge].FecRep.ToString();
                                        dtAvaladoConyuge.Rows.Add(rowAvaladoConyuge);


                                    }

                                }
                                dtgAvaladoConyuge.DataSource = dtAvaladoConyuge;
                                FormatoAvaladoConyuge();

                                break;
                        }
                    }
                }
                #endregion
                #region LISTA CODEUDA
                ListCodeuda = objRespuesta.Data[0].AvalCod.Codeuda;//Codeudor

                if (ListCodeuda != null)
                {
                    if (ListCodeuda.Count > 0)
                    {
                        switch (dtClasificacionCliente.Rows[i]["cCondicion"].ToString())
                        {
                            case "Titular":
                                TDocCodeudorTitular.Text = ListCodeuda[0].TDoc.ToString();
                                NDocCodeudorTitular.Text = ListCodeuda[0].NDoc.ToString();
                                RazSocCodeudorTitular.Text = ListCodeuda[0].RazSoc.ToString();
                                FecProCodeudorTitular.Text = ListCodeuda[0].FecPro.ToString();
                                IDCredCodeudorTitular.Text = ListCodeuda[0].IDCred.ToString();
                                TipCodCodeudorTitular.Text = ListCodeuda[0].TipCod.ToString();
                                MonDeuCodeudorTitular.Text = ListCodeuda[0].MonDeu.ToString();

                                dtgCodeudoresTitular.DataSource = ListCodeuda[0].codeudor;

                                break;
                            case "Conyuge":
                                TDocCodeudorConyuge.Text = ListCodeuda[0].TDoc.ToString();
                                NDocCodeudorConyuge.Text = ListCodeuda[0].NDoc.ToString();
                                RazSocCodeudorConyuge.Text = ListCodeuda[0].RazSoc.ToString();
                                FecProCodeudorConyuge.Text = ListCodeuda[0].FecPro.ToString();
                                IDCredCodeudorConyuge.Text = ListCodeuda[0].IDCred.ToString();
                                TipCodCodeudorConyuge.Text = ListCodeuda[0].TipCod.ToString();
                                MonDeuCodeudorConyuge.Text = ListCodeuda[0].MonDeu.ToString();

                                dtgCodeudoresConyuge.DataSource = ListCodeuda[0].codeudor;


                                break;
                        }
                    }
                }
                #endregion

            }


            dtgClasificacionSemaforo.DataSource = objLisTituConyuge;
           

            dtgClasificacionSemaforo.Columns["cCondicion"].HeaderText = "";
            dtgClasificacionSemaforo.Columns["cCondicion"].Width = 75;
            dtgClasificacionSemaforo.Columns["ctipoDocumento"].HeaderText = "Tipo Doc";
            dtgClasificacionSemaforo.Columns["ctipoDocumento"].Width = 90;
            dtgClasificacionSemaforo.Columns["cnombre"].HeaderText = "Nombre";
            dtgClasificacionSemaforo.Columns["cnombre"].Width = 250;
            dtgClasificacionSemaforo.Columns["cNumDocumento"].HeaderText = "Nro.Doc";
            dtgClasificacionSemaforo.Columns["idCli"].Visible = false;
            dtgClasificacionSemaforo.Columns["cCalificacion"].HeaderText = "Clasificación Interna";
            dtgClasificacionSemaforo.Columns["cCalificacion"].Width = 80;
            dtgClasificacionSemaforo.Columns["cEstadoCivil"].HeaderText = "Estado Civil";
            dtgClasificacionSemaforo.Columns["cEdad"].HeaderText = "Edad";
            dtgClasificacionSemaforo.Columns["cEdad"].Width = 150;
            dtgClasificacionSemaforo.Columns["cRelNDoc"].Visible = false;
            dtgClasificacionSemaforo.Columns["cTipoCliente"].Visible = false;
            dtgClasificacionSemaforo.Columns["nRiesgo"].HeaderText = "Nivel.Riesgo";
            dtgClasificacionSemaforo.Columns["nRiesgo"].Visible = false;//Nivel de Riesgo Oculto
            dtgClasificacionSemaforo.Columns["CapacidadPago"].Visible = false;//Capacidad de Pago Oculto

        }
        private void FormatoSentinelInfoBasicaTitular()
        {
            foreach (DataGridViewColumn item in dtgvSentinelSunatTitular.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }


            dtgvSentinelSunatTitular.Columns["TDoc"].HeaderText = "Tipo.Doc";
            dtgvSentinelSunatTitular.Columns["NDoc"].HeaderText = "Nro.Doc Consultado";
            dtgvSentinelSunatTitular.Columns["RelTDOC"].HeaderText = "Tipo.Doc Relacionado";
            dtgvSentinelSunatTitular.Columns["RelNDOC"].HeaderText = "Nro.Doc Relacionado";
            dtgvSentinelSunatTitular.Columns["RazSoc"].HeaderText = "Razón Social";
            dtgvSentinelSunatTitular.Columns["RazSoc"].Width = 350;
            dtgvSentinelSunatTitular.Columns["NomCom"].HeaderText = "Nombre Comercial";
            dtgvSentinelSunatTitular.Columns["NomCom"].Width = 320;
            dtgvSentinelSunatTitular.Columns["TipCon"].HeaderText = "Tipo Contribuyente";
            dtgvSentinelSunatTitular.Columns["TipCon"].Width = 300;
            dtgvSentinelSunatTitular.Columns["IniAct"].HeaderText = "Inicio Actividad";
            dtgvSentinelSunatTitular.Columns["ActEco"].HeaderText = "Actividad Económica";
            dtgvSentinelSunatTitular.Columns["ActEco"].Width = 380;
            dtgvSentinelSunatTitular.Columns["FchInsRRPP"].HeaderText = "Fech.Inscrip.Registros.Públicos";
            dtgvSentinelSunatTitular.Columns["AgeRet"].HeaderText = "¿Es Agente retención?";
            dtgvSentinelSunatTitular.Columns["ApePat"].HeaderText = "Apellido Paterno";
            dtgvSentinelSunatTitular.Columns["ApeMat"].HeaderText = "Apellido Materno";
            dtgvSentinelSunatTitular.Columns["Nom"].HeaderText = "Nombre Completo";
            dtgvSentinelSunatTitular.Columns["Sex"].HeaderText = "Sexo";
            dtgvSentinelSunatTitular.Columns["EstCon"].HeaderText = "Estado Contibuyente";
            dtgvSentinelSunatTitular.Columns["EstDom"].HeaderText = "Estado Domicilio";
            dtgvSentinelSunatTitular.Columns["EstDomic"].HeaderText = "Estado de Contibuyente";
            dtgvSentinelSunatTitular.Columns["CondDomic"].HeaderText = "Estado Domicilio";
            dtgvSentinelSunatTitular.Columns["NumParReg"].Visible = false;
            dtgvSentinelSunatTitular.Columns["Fol"].Visible = false;
            dtgvSentinelSunatTitular.Columns["Asi"].Visible = false;
            dtgvSentinelSunatTitular.Columns["DigVer"].Visible = false;
            dtgvSentinelSunatTitular.Columns["FecNac"].Visible = false;
        }
        private void FormatoSentinelInfoBasicaConyuge()
        {
            foreach (DataGridViewColumn item in dtgvSentinelSunatConyuge.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }


            dtgvSentinelSunatConyuge.Columns["TDoc"].HeaderText = "Tipo.Doc";
            dtgvSentinelSunatConyuge.Columns["NDoc"].HeaderText = "Nro.Doc Consultado";
            dtgvSentinelSunatConyuge.Columns["RelTDOC"].HeaderText = "Tipo.Doc Relacionado";
            dtgvSentinelSunatConyuge.Columns["RelNDOC"].HeaderText = "Nro.Doc Relacionado";
            dtgvSentinelSunatConyuge.Columns["RazSoc"].HeaderText = "Razón Social";
            dtgvSentinelSunatConyuge.Columns["RazSoc"].Width = 350;
            dtgvSentinelSunatConyuge.Columns["NomCom"].HeaderText = "Nombre Comercial";
            dtgvSentinelSunatConyuge.Columns["NomCom"].Width = 320;
            dtgvSentinelSunatConyuge.Columns["TipCon"].HeaderText = "Tipo Contribuyente";
            dtgvSentinelSunatConyuge.Columns["TipCon"].Width = 300;
            dtgvSentinelSunatConyuge.Columns["IniAct"].HeaderText = "Inicio Actividad";
            dtgvSentinelSunatConyuge.Columns["ActEco"].HeaderText = "Actividad Económica";
            dtgvSentinelSunatConyuge.Columns["ActEco"].Width = 380;
            dtgvSentinelSunatConyuge.Columns["FchInsRRPP"].HeaderText = "Fech.Inscrip.Registros.Públicos";
            dtgvSentinelSunatConyuge.Columns["AgeRet"].HeaderText = "¿Es Agente retención?";
            dtgvSentinelSunatConyuge.Columns["ApePat"].HeaderText = "Apellido Paterno";
            dtgvSentinelSunatConyuge.Columns["ApeMat"].HeaderText = "Apellido Materno";
            dtgvSentinelSunatConyuge.Columns["Nom"].HeaderText = "Nombre Completo";
            dtgvSentinelSunatConyuge.Columns["Sex"].HeaderText = "Sexo";
            dtgvSentinelSunatConyuge.Columns["EstCon"].HeaderText = "Estado Contibuyente";
            dtgvSentinelSunatConyuge.Columns["EstDom"].HeaderText = "Estado Domicilio";
            dtgvSentinelSunatConyuge.Columns["EstDomic"].HeaderText = "Estado de Contibuyente";
            dtgvSentinelSunatConyuge.Columns["CondDomic"].HeaderText = "Estado Domicilio";
            dtgvSentinelSunatConyuge.Columns["NumParReg"].Visible = false;
            dtgvSentinelSunatConyuge.Columns["Fol"].Visible = false;
            dtgvSentinelSunatConyuge.Columns["Asi"].Visible = false;
            dtgvSentinelSunatConyuge.Columns["DigVer"].Visible = false;
            dtgvSentinelSunatConyuge.Columns["FecNac"].Visible = false;
        }

        private void FormatoRepresentanteLegalTitular(int nTipoDoc)
        {
            string Dato = string.Empty;
            foreach (DataGridViewColumn item in dtgvRLegalTitular.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        
            dtgvRLegalTitular.Columns["TDOC"].HeaderText = "Tipo.Doc";
            dtgvRLegalTitular.Columns["NDOC"].HeaderText = "Nro.Documento";
            if (nTipoDoc == 1)//NATURAL
            {
                Dato = "Razoó Social";
                dtgvRLegalTitular.Columns["razSoc"].HeaderText = Dato;
                dtgvRLegalTitular.Columns["razSoc"].Width = 350;
            }
            if (nTipoDoc == 4)//JURIDICO
            {
                Dato = "Nombre Representante.Legal";
                dtgvRLegalTitular.Columns["Nombre"].HeaderText = Dato;
                dtgvRLegalTitular.Columns["Nombre"].Width = 350;
            }
            dtgvRLegalTitular.Columns["FecIniCar"].HeaderText = "Fecha Inicio Cargo";
            dtgvRLegalTitular.Columns["Cargo"].HeaderText = "Cargo";
            dtgvRLegalTitular.Columns["Cargo"].Width = 200;

        }
        private void FormatoRepresentanteLegalConyuge(int nTipoDoc)
        {
            string Dato = string.Empty;
            foreach (DataGridViewColumn item in dtgvRLegalConyuge.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            if (nTipoDoc==1)//NATURAL
            {
                Dato = "Razoó Social";
                dtgvRLegalConyuge.Columns["razSoc"].HeaderText = Dato;
                dtgvRLegalConyuge.Columns["razSoc"].Width = 350;
            }
            if (nTipoDoc == 4)//JURIDICO
            {
                Dato = "Nombre Representante.Legal";
                dtgvRLegalConyuge.Columns["Nombre"].HeaderText = Dato;
                dtgvRLegalConyuge.Columns["Nombre"].Width = 350;
            }
            dtgvRLegalConyuge.Columns["TDOC"].HeaderText = "Tipo.Doc";
            dtgvRLegalConyuge.Columns["NDOC"].HeaderText = "Nro.Documento";

            dtgvRLegalConyuge.Columns["FecIniCar"].HeaderText = "Fecha Inicio Cargo";
            dtgvRLegalConyuge.Columns["Cargo"].HeaderText = "Cargo";
            dtgvRLegalConyuge.Columns["Cargo"].Width = 200;

        }
        
        private void FormatoEntidadNoSupervisada()
        {
            foreach (DataGridViewColumn item in dtgEntNoSupervisada.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }


            dtgEntNoSupervisada.Columns["Condicion"].Visible = false;
            dtgEntNoSupervisada.Columns["NomEnt"].Width = 300;
            dtgEntNoSupervisada.Columns["NomEnt"].HeaderText = "Nombre Entidad Acreedora";
            dtgEntNoSupervisada.Columns["Cal"].HeaderText = "Calificación";
            dtgEntNoSupervisada.Columns["SalDeu"].HeaderText = "Saldo Deuda";
            dtgEntNoSupervisada.Columns["DiaVen"].HeaderText = "Días Vencidos";
            dtgEntNoSupervisada.Columns["FchPro"].HeaderText = "Fecha Proceso";
            dtgEntNoSupervisada.Columns["FchRep"].HeaderText = "Fecha Reporte";

        }
        private void FormatoEntidadNoSupervisadaConyuge()
        {
            foreach (DataGridViewColumn item in dtgEntNoSupervisadaConyuge.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgEntNoSupervisadaConyuge.Columns["Condicion"].Visible = false;
            dtgEntNoSupervisadaConyuge.Columns["NomEnt"].Width = 300;
            dtgEntNoSupervisadaConyuge.Columns["NomEnt"].HeaderText = "Nombre Entidad Acreedora";
            dtgEntNoSupervisadaConyuge.Columns["Cal"].HeaderText = "Calificación";
            dtgEntNoSupervisadaConyuge.Columns["SalDeu"].HeaderText = "Saldo Deuda";
            dtgEntNoSupervisadaConyuge.Columns["DiaVen"].HeaderText = "Días Vencidos";
            dtgEntNoSupervisadaConyuge.Columns["FchPro"].HeaderText = "Fecha Proceso";
            dtgEntNoSupervisadaConyuge.Columns["FchRep"].HeaderText = "Fecha Reporte";

        }
        private void FormatoDetalleBaseNegativa()
        {
            foreach (DataGridViewColumn item in dtgDetBaseNeg.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

           dtgDetBaseNeg.Columns["nvinculado"].HeaderText = "";
           dtgDetBaseNeg.Columns["nvinculado"].Width = 100;
           dtgDetBaseNeg.Columns["dfechaReg"].HeaderText = "Fecha Registro";
           dtgDetBaseNeg.Columns["cDescripcion"].HeaderText = "Descripción";
           dtgDetBaseNeg.Columns["cDescripcion"].Width = 300;
           dtgDetBaseNeg.Columns["cMotivo"].HeaderText = "Motivo";
           dtgDetBaseNeg.Columns["cMotivo"].Width = 300;
           dtgDetBaseNeg.Columns["cNombre"].HeaderText = "Usuario Registro";
           dtgDetBaseNeg.Columns["cNombre"].Width = 150;

        }
          private void FormatoLiberacionBaseNeg()
        {
            foreach (DataGridViewColumn item in dtgLiberacionBaseNeg.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgLiberacionBaseNeg.Columns["nvinculado"].HeaderText = "";
            dtgLiberacionBaseNeg.Columns["nvinculado"].Width = 100;
            dtgLiberacionBaseNeg.Columns["dFecHoraRegistro"].HeaderText = "Fecha liberación";
            dtgLiberacionBaseNeg.Columns["cDescripcion"].HeaderText = "Descripción";
            dtgLiberacionBaseNeg.Columns["cDescripcion"].Width = 300;
            dtgLiberacionBaseNeg.Columns["cSustento"].HeaderText = "Motivo liberación";
            dtgLiberacionBaseNeg.Columns["cSustento"].Width = 150;
            dtgLiberacionBaseNeg.Columns["cNombreMod"].HeaderText = "Usuario Desbloqueo";
            dtgLiberacionBaseNeg.Columns["cNombreMod"].Width = 300;

        }
        
        private void FormatoListaPep()
        {
            foreach (DataGridViewColumn item in dtgDetPep.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgDetPep.Columns["nvinculado"].HeaderText = "";
            dtgDetPep.Columns["nvinculado"].Width = 100;
            dtgDetPep.Columns["dfecini"].HeaderText = "Fecha.Inicio";
            dtgDetPep.Columns["dfecfin"].HeaderText = "Fecha.Final";

            dtgDetPep.Columns["cubigeo"].HeaderText = "Ubigeo";
            dtgDetPep.Columns["cubigeo"].Width = 350;
            dtgDetPep.Columns["ccargo"].HeaderText = "Cargo";
            dtgDetPep.Columns["ccargo"].Width = 250;

        }
    
        public string fechaformateada(string fecha)
        {
     
            string[] valores=fecha.Split('-');
            string Mes = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToInt32(valores[1]));
            string Anio=valores[0];
            string Resultado = Mes.Replace(".","").Replace("Set","Sep") + " " + Anio;
            return Resultado;
        }
        private DataTable ArmarTablaParametros()
        {
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

            DataRow drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCli";
            drfila[1] = idClienteT;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nidTipoPersona";
            drfila[1] = idTipoPersonaT;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaActual";
            drfila[1] = "'" + clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd") + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "cDocumentoID";
            drfila[1] = "'" + cDocumentoIDT + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoDocumento";
            drfila[1] = "'" + idTipoDocumentoT + "'";
            dtTablaParametros.Rows.Add(drfila);
         
            return dtTablaParametros;
        }
        private void LimpiarControles()
        {
            dtgCreditos.DataSource = "";

            this.lblClasifInt.Text = string.Empty;

            this.conBusCli.txtCodCli.Text = "";
            this.conBusCli.txtNombre.Text = "";
            this.conBusCli.txtNroDoc.Text = "";
            this.conBusCli.txtCodAge.Text = "";
            this.conBusCli.txtCodInst.Text = "";
            this.conBusCli.txtDireccion.Text = "";

      
            this.conBusCli.txtCodCli.Enabled = true;
            this.conBusCli.txtCodCli.Focus();

            this.conBusDocumento.limpiarControles();

            TDocCodeudorTitular.Text = "";
            NDocCodeudorTitular.Text = "";
            RazSocCodeudorTitular.Text = "";
            FecProCodeudorTitular.Text = "";
            IDCredCodeudorTitular.Text = "";
            TipCodCodeudorTitular.Text = "";
            MonDeuCodeudorTitular.Text = "";
            TDocCodeudorConyuge.Text = "";
            NDocCodeudorConyuge.Text = "";
            RazSocCodeudorConyuge.Text = "";
            FecProCodeudorConyuge.Text = "";
            IDCredCodeudorConyuge.Text = "";
            TipCodCodeudorConyuge.Text = "";
            MonDeuCodeudorConyuge.Text = "";

            dtgDetPep.DataSource = "";
            dtgDetBaseNeg.DataSource = "";
            dtgDireccionTitular.DataSource = "";
            dtgDireccionConyuge.DataSource = "";
            dtgLiberacionBaseNeg.DataSource = "";
           
            ChartPastelTitular.Series.Clear();
            chartBarraTitular.Series.Clear();
            ChartPastelConyuge.Series.Clear();
            chartBarraConyuge.Series.Clear();
            ChartPastelTitular.Titles.Clear();
            ChartPastelConyuge.Titles.Clear();
            chartBarraTitular.Titles.Clear();
            chartBarraConyuge.Titles.Clear();
        }
        private void cargarEstados()
        {
            var dtEstados = cboEstadoCredito.retornarTodosEstado();
            var dtEstadoFiltro = dtEstados.Clone();

            (from item in dtEstados.AsEnumerable()
             where Convert.ToInt32(item["IdEstado"]).In(5, 6)
             select item).CopyToDataTable(dtEstadoFiltro, LoadOption.OverwriteChanges);

            var drTotdos = dtEstadoFiltro.NewRow();
            drTotdos["IdEstado"] = 0;
            drTotdos["cEstado"] = "*** TODOS ***";
            dtEstadoFiltro.Rows.Add(drTotdos);

            cboEstadoCredito.DataSource = dtEstadoFiltro;
            cboEstadoCredito.ValueMember = dtEstadoFiltro.Columns[0].ToString();
            cboEstadoCredito.DisplayMember = dtEstadoFiltro.Columns[1].ToString();
        }

        private void cboEstadoCredito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEstadoCredito.SelectedIndex > -1)
            {
                if (cboEstadoCredito.SelectedValue is DataRowView) return;

                if (conBusCli.idCli > 0)
                {
                    cargardatos();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            conBusCli.btnBusCliente.Enabled = true;
            btnBusqueda1.Enabled = false;
        
            this.LimpiarControles();
            this.btnCancelar.Enabled = false;
            this.cboMes1.Enabled = false;
          
            cboMes1.DataSource = null;
           
            dtgOfertas.DataSource = null;
            dtgDeudasConyuge.DataSource = null;
            dtgDeudasTitular.DataSource = null;
            dgtvCondiciones.DataSource = null;
            dtgvResumenCondicion.DataSource = null;
            dtgClasificacionSemaforo.DataSource = null;
            btnImprimir1.Enabled = false;

            dtgvSentinelSunatTitular.DataSource = null;
            dtgvSentinelSunatConyuge.DataSource = null;

            dtgEntNoSupervisada.DataSource = null;
            dtgEntNoSupervisadaConyuge.DataSource = null;
            dtgOfertas.Columns["btnOtorgar"].Visible = false;
            dtgOfertas.Columns["btnSeguimiento"].Visible = false;
            dtgAvaladoTitular.DataSource = null;
            dtgAvaladoConyuge.DataSource = null;

            dtgLineaCreditoNoUtilTitular.DataSource = null;
            dtgLineaCreditoNoUtilConyuge.DataSource = null;

            dtDeudaConyuge = new DataTable();

            dtDeudaTitular = new DataTable();
            dtAvalado = new DataTable();

            dtAvaladoConyuge = new DataTable();

            dtDeudaSentinelDirectaTitular = new DataTable();
            dtDeudaSentinelDirectaConyuge = new DataTable();
            dtlCredNoUtilizadaT = new DataTable();
            dtlCredNoUtilizadaC = new DataTable();
            dtAvalistaTitular = new DataTable();
            dtAvalistaConyuge = new DataTable();
            dtBasicoSunatTitular = new DataTable();
            dtBSunatDireccionTitular = new DataTable();
            dtRlegalTitular = new DataTable();
            dtBasicoSunatConyuge = new DataTable();
            dtBSunatDireccionConyuge = new DataTable();
            dtRlegalConyuge = new DataTable();
            dtHistorialSentinelTitular = new DataTable();
            dtHistorialSentinelConyuge = new DataTable();
            objLisTituConyuge = new List<TitularConyuge>();
            dtClasificacionCliente = new DataTable();
            dtMicrTitular = new DataTable();
            dtMicrConyuge = new DataTable();

            CreaTablaMicrofinanzasTitular();
            CreaTablaMicrofinanzasConyuge();
            CreaTablaAvaladoTitular();
            CreaTablaAvaladoConyuge();
            CreaTablaDeudaConyuge();
            CreaTablaDeudaTitular();
            CreaTablaAvalistaTitular();
            CreaTablaAvalistaConyuge();
            CreaTablaBasicoSunatTitular();
            CreaTablaBasicoSunatConyuge();
            CreaTablaBSunatDireccionTitular();
            CreaTablaBSunatDireccionConyuge();
            CreaTablaRLegalTitular();
            CreaTablalCredNoUtilTitular();
            CreaTablalCredNoUtilConyuge();
            CreaTablaRLegalConyuge();
            CreaTablaHistorialSentinelTitular();
            CreaTablaHistorialSentinelConyuge();

            dtgAvalistaConyuge.DataSource = null;
            dtgEntNoSupervisada.DataSource = null;
            dtgEntNoSupervisadaConyuge.DataSource = null;
            dtgvRLegalTitular.DataSource = null;
            dtgvRLegalConyuge.DataSource = null;
            btnBuscaDeudaSentinelTitular.Enabled = false;
            btnBuscaDeudaSentinelConyuge.Enabled = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
          
            this.Close();
        }

        private void conBusCli_ClicBuscar(object sender, EventArgs e)
        {
            if (conBusCli.txtCodCli.Text != String.Empty)
            {
                idClienteT = Convert.ToInt32(conBusCli.txtCodCli.Text);
                cDocumentoIDT = Convert.ToString(conBusCli.txtNroDoc.Text);
                idTipoDocumentoT = Convert.ToInt32(conBusCli.nidTipoDocumento);
                idTipoPersonaT = conBusCli.nidTipoPersona;
            }
            else
            {
                idClienteT = conBusDocumento.idCliente;
                cDocumentoIDT = conBusDocumento.cDocumentoID;
                idTipoDocumentoT = conBusDocumento.idTipoDocumento;
                idTipoPersonaT = conBusDocumento.idTipoPersona;
            }

            if (idClienteT!=0)
            {
                cargardatos();
                conBusCli.btnBusCliente.Enabled = false;
                if (idTipoPersonaT == 1)
                {
                    cTipoPersona = "N";
                }
                if (idTipoPersonaT == 2 || idTipoPersonaT == 3)
                {
                    cTipoPersona = "J";
                }
              

                //Validar REGLAS DINÁMICAS
                dResultado = ValidaReglasDinamicas.ValidarReglasCondiciones(ArmarTablaParametros(), this.Name, cTipoPersona);

                dgtvCondiciones.DataSource = dResultado;

                foreach (DataGridViewRow row in dgtvCondiciones.Rows)
                {
                    if (Convert.ToString(row.Cells["Resultado"].Value) == "NO CUMPLE")
                    {
                        //row.DefaultCellStyle.BackColor = Color.Red;
                        row.Cells["Resultado"].Style.BackColor = Color.Red;
                        row.Cells["Resultado"].Style.ForeColor = Color.White;
                    }
                    else
                    {
                        row.Cells["Resultado"].Style.BackColor = Color.FromArgb(146, 208, 80);
                        row.Cells["Resultado"].Style.ForeColor = Color.Black;
                    }
                }

                foreach (DataGridViewColumn Col in dgtvCondiciones.Columns)
                {
                    Col.SortMode = DataGridViewColumnSortMode.NotSortable;

                }
                dgtvCondiciones.Columns[0].Width = 40;
                dgtvCondiciones.Columns[1].Width = 500;
                dgtvCondiciones.Columns[2].Width = 220;
                dgtvCondiciones.Columns[3].Width = 115;
                dgtvCondiciones.Columns[4].Visible = false;

                dtgvResumenCondicion.DataSource = GeneraResumenCondiciones(dResultado);

                foreach (DataGridViewColumn row in dgtvCondiciones.Columns)
                {
                    row.Visible = false;
                }

                dgtvCondiciones.Columns["Nro"].Visible = true;
                dgtvCondiciones.Columns["Condiciones"].Visible = true;
                dgtvCondiciones.Columns["Mensaje"].Visible = true;
                dgtvCondiciones.Columns["Resultado"].Visible = true;

                foreach (DataGridViewRow row in dtgvResumenCondicion.Rows)
                {
                    if (Convert.ToString(row.Cells["Resultado"].Value).Contains("NO CUMPLE"))
                    {
                        row.Cells["Resultado"].Style.BackColor = Color.Red;
                        row.Cells["Resultado"].Style.ForeColor = Color.White;
                    }
                    else
                    {
                        row.Cells["Resultado"].Style.BackColor = Color.FromArgb(146, 208, 80);
                        row.Cells["Resultado"].Style.ForeColor = Color.Black;
                    }
                }

                dtgvResumenCondicion.Columns[0].Width = 260;
                dtgvResumenCondicion.Columns[1].Width = 900;

                registrarRastreoPosicionConsolidada(idClienteT, 0, "Consulta - Posición Consolidada Cliente", conBusCli.btnBusCliente, cDocumentoIDT);
            
            }
            
        }
        public DataTable GeneraResumenCondiciones(DataTable dt)
        {
            DataTable dtRespuesta=new DataTable();
            dtRespuesta.Columns.Add("Mensaje", typeof(string));
            dtRespuesta.Columns.Add("Resultado", typeof(string));

            DataTable dtRespuestaDetCumple = dtRespuesta.Clone();
            DataTable dtRespuestaDetNoCumple = dtRespuesta.Clone();

            DataTable dtGeneral = dtRespuesta.Clone();
            dtGeneral = dt.AsEnumerable()
                                .Where(b => Convert.ToString(b.Field<string>("cTipoCondicion")) == "GENERAL")
                                .GroupBy(x => x.Field<string>("Mensaje"))
                                .Select(y => dtRespuesta.Rows.Add(Convert.ToString(y.First().Field<string>("Mensaje")), Convert.ToString(y.First().Field<string>("Resultado")))).CopyToDataTable();

            DataTable dtProducto = dtRespuesta.Clone();
            dtProducto  = dt.AsEnumerable().Where(x => Convert.ToString(x.Field<string>("cTipoCondicion")) == "PRODUCTO").CopyToDataTable();

            IEnumerable<IGrouping<string, string>> lstCumple = dtProducto.AsEnumerable().Where(b => Convert.ToString(b.Field<string>("Resultado")) == "CUMPLE").GroupBy(grp => grp.Field<string>("Mensaje"), grp => grp.Field<string>("Oculto"));
            IEnumerable<IGrouping<string, string>> lstNoCumple = dtProducto.AsEnumerable().Where(b => Convert.ToString(b.Field<string>("Resultado")) == "NO CUMPLE").GroupBy(grp => grp.Field<string>("Mensaje"), grp => grp.Field<string>("Oculto"));

            foreach (IGrouping<string, string> oNoCumple in lstNoCumple)
            {
                string cNoCumpleDet = (dtProducto.AsEnumerable().Any(x => Convert.ToString(x.Field<string>("Resultado")) == "NO CUMPLE" && Convert.ToString(x.Field<string>("Mensaje")) == oNoCumple.Key)) ? "NO CUMPLE:" : "";
                cNoCumpleDet = cNoCumpleDet + " " + String.Join(", ", oNoCumple);
                dtRespuestaDetNoCumple.Rows.Add(oNoCumple.Key, cNoCumpleDet);
            }

            foreach (IGrouping<string, string> oCumple in lstCumple)
            {
                string cCumpleDet = (dtProducto.AsEnumerable().Any(x => Convert.ToString(x.Field<string>("Resultado")) == "CUMPLE" && Convert.ToString(x.Field<string>("Mensaje")) == oCumple.Key)) ? "CUMPLE" : "";
                dtRespuestaDetCumple.Rows.Add(oCumple.Key, cCumpleDet);
            }

            dtRespuestaDetCumple.Merge(dtRespuestaDetNoCumple, true, MissingSchemaAction.AddWithKey);

            dtRespuestaDetCumple.AsEnumerable()
                .GroupBy(grp => grp.Field<string>("Mensaje"))
                .Select(x => new { Mensaje = x.Key, Resultado = String.Join(" - ",x.Select( i => i.Field<string>("Resultado"))) }).ToList()
                .ForEach(x => { dtRespuesta.Rows.Add(x.Mensaje, x.Resultado); });

            return dtRespuesta;
        }
   
        private void btnBusqueda1_Click(object sender, EventArgs e)
        {
      
            MostrarGrafico(cDocumentoIDT);

        }

        public void MostrarGrafico(string cDocumento)
        {
        
            string fecha = cboMes1.SelectedValue.ToString();
            //RECUPERA INFORMACION DE CALIFICACIONES
            DataTable dtCalfInterv = cninterviniente.ADdtListClienCalifSBS_Fecha(idTipoDocumentoT,cDocumento, fecha);
            var lValidaCalificacionTitular = dtCalfInterv.AsEnumerable().Where(r => r.Field<Int32>("nVinculado") == 1).Any();
            if (lValidaCalificacionTitular)
            {
                GraficoPastelTitular(dtCalfInterv.AsEnumerable().Where(r => r.Field<Int32>("nVinculado") == 1).CopyToDataTable());
            }

            //RECUPERA INFORMACION DE ENTIDAD FINANCIERA
            dtHistSaldosSBS_Titular = cninterviniente.dtsaldosEntidadFinanciera(idTipoDocumentoT, cDocumento, fecha);

          
            var lValidaSaldoEntidadTitular = dtHistSaldosSBS_Titular.AsEnumerable().Where(r => r.Field<Int32>("nVinculado") == 1).Any();
            if (lValidaSaldoEntidadTitular)
            {
                GraficoBarraTitular(dtHistSaldosSBS_Titular.AsEnumerable().Where(r => r.Field<Int32>("nVinculado") == 1).CopyToDataTable());
            }
         
            if (dtClasificacionCliente.Rows.Count > 1)
            {
                var lValidaCalificacionConyuge = dtCalfInterv.AsEnumerable().Where(r => r.Field<Int32>("nVinculado") == 2).Any();
                if (lValidaCalificacionConyuge)
                  {
                      GraficoPastelConyuge(dtCalfInterv.AsEnumerable().Where(r => r.Field<Int32>("nVinculado") == 2).CopyToDataTable());
                     
                  }
                var lValidaSaldoEntidadConyge = dtHistSaldosSBS_Titular.AsEnumerable().Where(r => r.Field<Int32>("nVinculado") == 2).Any();
                if (lValidaSaldoEntidadConyge)
                {
                    GraficoBarraConyuge(dtHistSaldosSBS_Titular.AsEnumerable().Where(r => r.Field<Int32>("nVinculado") == 2).CopyToDataTable()); 
                }
               
            }
            
                    
        }

        public void GraficoPastelTitular(DataTable dtCali)
        {
            ChartPastelTitular.Series.Clear();
            ChartPastelTitular.Series.Add("Pastel");
            ChartPastelTitular.Titles.Clear();
            Series series=ChartPastelTitular.Series["Pastel"];
            // tipo de grafico
           series.ChartType = SeriesChartType.Pie;
           series.IsValueShownAsLabel = true;
           series.LabelFormat = "#.##";

            deudaCalif0_PastelTitular=0;
            deudaCalif1_PastelTitular=0;
            deudaCalif2_PastelTitular=0;
            deudaCalif3_PastelTitular=0;
            deudaCalif4_PastelTitular=0;

 
           //series.Font = new Font("Times New Roman", 15);
            for (int i = 0; i < dtCali.Rows.Count; i++)
            {
                deudaCalif0_PastelTitular = dtCali.Rows[i]["deudaCalif0"] == DBNull.Value ? Double.NaN : Convert.ToDouble(dtCali.Rows[i]["deudaCalif0"]);
                deudaCalif1_PastelTitular = dtCali.Rows[i]["deudaCalif1"] == DBNull.Value ? Double.NaN : Convert.ToDouble(dtCali.Rows[i]["deudaCalif1"]);
                deudaCalif2_PastelTitular = dtCali.Rows[i]["deudaCalif2"] == DBNull.Value ? Double.NaN : Convert.ToDouble(dtCali.Rows[i]["deudaCalif2"]);
                deudaCalif3_PastelTitular = dtCali.Rows[i]["deudaCalif3"] == DBNull.Value ? Double.NaN : Convert.ToDouble(dtCali.Rows[i]["deudaCalif3"]);
                deudaCalif4_PastelTitular = dtCali.Rows[i]["deudaCalif4"] == DBNull.Value ? Double.NaN : Convert.ToDouble(dtCali.Rows[i]["deudaCalif4"]);
            }

            if (ValidaGraficoPastel(deudaCalif0_PastelTitular, deudaCalif1_PastelTitular, deudaCalif2_PastelTitular, deudaCalif3_PastelTitular, deudaCalif4_PastelTitular))
            {
                ChartPastelTitular.Titles.Add("NO HAY DATO A MOSTRAR PARA EL GRAFICO DE PASTEL TITULAR");
            }
            else
            {
                ChartPastelTitular.Titles.Add("CLASIFICACIÓN DE DEUDAS TITULAR");
                series.Points.AddXY("NORMAL", deudaCalif0_PastelTitular);
                series.Points.AddXY("CPP", deudaCalif1_PastelTitular);
                series.Points.AddXY("DEFICIENTE", deudaCalif2_PastelTitular);
                series.Points.AddXY("DUDOSO", deudaCalif3_PastelTitular);
                series.Points.AddXY("PERDIDA", deudaCalif4_PastelTitular);
                ChartPastelTitular.Series[0].Points[0].Color = Color.FromArgb(0,176,80);
                ChartPastelTitular.Series[0].Points[1].Color = Color.FromArgb(255,255,0);
                ChartPastelTitular.Series[0].Points[2].Color = Color.FromArgb(255,192,0);
                ChartPastelTitular.Series[0].Points[3].Color = Color.FromArgb(226,107,10);
                ChartPastelTitular.Series[0].Points[4].Color = Color.FromArgb(255,0,0);

                //ChartPastelTitular.Series[0].Points[4].LabelForeColor = Color.White;

                ChartPastelTitular.Series[0].LegendText = "#VALX (#PERCENT)";
                ChartPastelTitular.Legends[0].Enabled = true;
                ChartPastelTitular.Legends[0].Docking = Docking.Bottom;
                ChartPastelTitular.Legends[0].Alignment = System.Drawing.StringAlignment.Center;
            }
           

          
        }

        public bool ValidaGraficoPastel(double deudaCalif0, double deudaCalif1, double deudaCalif2, double deudaCalif3, double deudaCalif4)
        {
            string cValorNAN = "NaN";
            double vCERO = 0;
            bool lSinDato = false;

            if ((deudaCalif0.ToString() == cValorNAN || deudaCalif0 == vCERO) && (deudaCalif1.ToString() == cValorNAN || deudaCalif1 == vCERO) && (deudaCalif2.ToString() == cValorNAN || deudaCalif2 == vCERO) && (deudaCalif3.ToString() == cValorNAN || deudaCalif3 == vCERO) && (deudaCalif4.ToString() == cValorNAN || deudaCalif4 == vCERO))
            {
                lSinDato = true;
               
            }
            else
            {
                lSinDato = false;
                return lSinDato;
            }
           

            return lSinDato;

        }
        public void GraficoPastelConyuge(DataTable dtCali)
        {
            ChartPastelConyuge.Series.Clear();
            ChartPastelConyuge.Series.Add("PastelConyuge");
            ChartPastelConyuge.Titles.Clear();
            Series series = ChartPastelConyuge.Series["PastelConyuge"];
            // tipo de grafico
            series.ChartType = SeriesChartType.Pie;
            series.IsValueShownAsLabel = true;
            series.LabelFormat = "#.##";

           deudaCalif0_PastelConyuge=0;
           deudaCalif1_PastelConyuge=0;
           deudaCalif2_PastelConyuge=0;
           deudaCalif3_PastelConyuge=0;
           deudaCalif4_PastelConyuge=0;

            //series.Font = new Font("Times New Roman", 15);
           for (int i = 0; i < dtCali.Rows.Count; i++)
           {
               deudaCalif0_PastelConyuge = dtCali.Rows[i]["deudaCalif0"] == DBNull.Value ? Double.NaN : Convert.ToDouble(dtCali.Rows[i]["deudaCalif0"]);
               deudaCalif1_PastelConyuge = dtCali.Rows[i]["deudaCalif1"] == DBNull.Value ? Double.NaN : Convert.ToDouble(dtCali.Rows[i]["deudaCalif1"]);
               deudaCalif2_PastelConyuge = dtCali.Rows[i]["deudaCalif2"] == DBNull.Value ? Double.NaN : Convert.ToDouble(dtCali.Rows[i]["deudaCalif2"]);
               deudaCalif3_PastelConyuge = dtCali.Rows[i]["deudaCalif3"] == DBNull.Value ? Double.NaN : Convert.ToDouble(dtCali.Rows[i]["deudaCalif3"]);
               deudaCalif4_PastelConyuge = dtCali.Rows[i]["deudaCalif4"] == DBNull.Value ? Double.NaN : Convert.ToDouble(dtCali.Rows[i]["deudaCalif4"]);


               if (ValidaGraficoPastel(deudaCalif0_PastelConyuge, deudaCalif1_PastelConyuge, deudaCalif2_PastelConyuge, deudaCalif3_PastelConyuge, deudaCalif4_PastelConyuge))
               {
                   ChartPastelConyuge.Titles.Add("NO HAY DATO A MOSTRAR PARA EL GRAFICO DE PASTEL CONYUGE");
       
               }
               else
               {
                   ChartPastelConyuge.Titles.Add("CLASIFICACIÓN DE DEUDAS CONYUGE");
                   series.Points.AddXY("NORMAL", deudaCalif0_PastelConyuge);
                   series.Points.AddXY("CPP", deudaCalif1_PastelConyuge);
                   series.Points.AddXY("DEFICIENTE", deudaCalif2_PastelConyuge);
                   series.Points.AddXY("DUDOSO", deudaCalif3_PastelConyuge);
                   series.Points.AddXY("PERDIDA", deudaCalif4_PastelConyuge);

                   ChartPastelConyuge.Series[0].Points[0].Color = Color.FromArgb(0, 176, 80);
                   ChartPastelConyuge.Series[0].Points[1].Color = Color.FromArgb(255, 255, 0);
                   ChartPastelConyuge.Series[0].Points[2].Color = Color.FromArgb(255, 192, 0);
                   ChartPastelConyuge.Series[0].Points[3].Color = Color.FromArgb(226, 107, 10);
                   ChartPastelConyuge.Series[0].Points[4].Color = Color.FromArgb(255, 0, 0);

                   //ChartPastelConyuge.Series[0].Points[4].LabelForeColor = Color.White;

                   ChartPastelConyuge.Series[0].LegendText = "#VALX (#PERCENT)";
                   ChartPastelConyuge.Legends[0].Enabled = true;
                   ChartPastelConyuge.Legends[0].Docking = Docking.Bottom;
                   ChartPastelConyuge.Legends[0].Alignment = System.Drawing.StringAlignment.Center;
               }



           }
        }
 
        public void GraficoBarraTitular(DataTable dtHisto)
        {
            if (dtHisto.Rows.Count > 0)
            {
                chartBarraTitular.Titles.Clear();
                chartBarraTitular.Titles.Add("SALDOS ENTIDADES FINANCIERAS TITULAR");
                List<BarraTitularConyuge> ListaBarraTitular = new List<BarraTitularConyuge>();
                BarraTitularConyuge objModelBarraTitular = new BarraTitularConyuge();
                objModelBarraTitular.fechaCalfSBS = dtHisto.Rows[0]["fechaCalfSBS"].ToString();
                objModelBarraTitular.saldo = dtHisto.Rows[0]["saldo"] == DBNull.Value ? Convert.ToDouble(0) : Convert.ToDouble(dtHisto.Rows[0]["saldo"]);
                //objModelBarraTitular.nSaldoCastigado = (dtHisto.Rows[0]["nSaldoCastigado"] == DBNull.Value || Convert.ToDouble(dtHisto.Rows[0]["nSaldoCastigado"]) == Convert.ToDouble(0)) ? Double.NaN : Convert.ToDouble(dtHisto.Rows[0]["nSaldoCastigado"]);
                objModelBarraTitular.nSaldoCastigado = dtHisto.Rows[0]["nSaldoCastigado"] == DBNull.Value ? Convert.ToDouble(0) : Convert.ToDouble(dtHisto.Rows[0]["nSaldoCastigado"]);
                ListaBarraTitular.Add(objModelBarraTitular);
                chartBarraTitular.DataSource = ListaBarraTitular;
                chartBarraTitular.Series.Clear();

                var saldoBarra = chartBarraTitular.Series.Add("saldo");
                saldoBarra.XValueMember = "fechaCalfSBS";
                saldoBarra.YValueMembers = "saldo";
                saldoBarra.ChartType = SeriesChartType.Column;

                var nSaldoCastigadoBarra = chartBarraTitular.Series.Add("nSaldoCastigado");
                nSaldoCastigadoBarra.XValueMember = "fechaCalfSBS";
                nSaldoCastigadoBarra.YValueMembers = "nSaldoCastigado";
                nSaldoCastigadoBarra.ChartType = SeriesChartType.Column;

                chartBarraTitular.Legends[0].Docking = Docking.Bottom;
                chartBarraTitular.Legends[0].Alignment = System.Drawing.StringAlignment.Center;
                chartBarraTitular.Series[0].IsValueShownAsLabel = true;
                chartBarraTitular.Series[1].IsValueShownAsLabel = true;

                chartBarraTitular.Series[0].Color = Color.FromArgb(65, 140, 240);
                chartBarraTitular.Series[1].Color = Color.FromArgb(188, 31, 38);

            }
         
        }
        public void GraficoBarraConyuge(DataTable dtHistoConyuge)
        {
            if (dtHistoConyuge.Rows.Count > 0)
            {
                chartBarraConyuge.Titles.Clear();
                chartBarraConyuge.Titles.Add("SALDOS ENTIDADES FINANCIERAS CONYUGE");
                List<BarraTitularConyuge> ListaBarraConyuge = new List<BarraTitularConyuge>();
                BarraTitularConyuge objModelBarraConyuge = new BarraTitularConyuge();
                objModelBarraConyuge.fechaCalfSBS = dtHistoConyuge.Rows[0]["fechaCalfSBS"].ToString();
                objModelBarraConyuge.saldo = dtHistoConyuge.Rows[0]["saldo"] == DBNull.Value ? Convert.ToDouble(0) : Convert.ToDouble(dtHistoConyuge.Rows[0]["saldo"]);
                objModelBarraConyuge.nSaldoCastigado = dtHistoConyuge.Rows[0]["nSaldoCastigado"] == DBNull.Value  ? Convert.ToDouble(0): Convert.ToDouble(dtHistoConyuge.Rows[0]["nSaldoCastigado"]);

                ListaBarraConyuge.Add(objModelBarraConyuge);
                chartBarraConyuge.DataSource = ListaBarraConyuge;
                chartBarraConyuge.Series.Clear();

                var saldoBarraConyuge = chartBarraConyuge.Series.Add("saldo");
                saldoBarraConyuge.XValueMember = "fechaCalfSBS";
                saldoBarraConyuge.YValueMembers = "saldo";
                saldoBarraConyuge.ChartType = SeriesChartType.Column;

                var nSaldoCastigadoBarraConyuge = chartBarraConyuge.Series.Add("nSaldoCastigado");
                nSaldoCastigadoBarraConyuge.XValueMember = "fechaCalfSBS";
                nSaldoCastigadoBarraConyuge.YValueMembers = "nSaldoCastigado";
                nSaldoCastigadoBarraConyuge.ChartType = SeriesChartType.Column;

                chartBarraConyuge.Legends[0].Docking = Docking.Bottom;
                chartBarraConyuge.Legends[0].Alignment = System.Drawing.StringAlignment.Center;
                chartBarraConyuge.Series[0].IsValueShownAsLabel = true;
                chartBarraConyuge.Series[1].IsValueShownAsLabel = true;

                chartBarraConyuge.Series[0].Color = Color.FromArgb(65, 140, 240);
                chartBarraConyuge.Series[1].Color = Color.FromArgb(188, 31, 38);
            }

        }
        private void dtgCreditos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string Asesor               = string.Empty;
            string GestorRecuperaciones = string.Empty;
            string Expediente           = string.Empty;
            string MontoDesembolsado    = string.Empty;
            string FechaDesembolso      = string.Empty;
            string Estado               = string.Empty;
            string Cuenta               = string.Empty;
            string Moneda               = string.Empty;
            int idSolicitud             = 0;
            int idCuenta                = 0;
            if (e.ColumnIndex==dtgCreditos.Columns.IndexOf(colDetalle))
            {

                // Cargar datos del Crédito
                Asesor                  = dtgCreditos.CurrentRow.Cells["cAsesorAct"].Value.ToString();
                GestorRecuperaciones    = dtgCreditos.CurrentRow.Cells["cRecuperador"].Value.ToString();
                Expediente              = dtgCreditos.CurrentRow.Cells["cCodigoExped"].Value.ToString();
                MontoDesembolsado       = dtgCreditos.CurrentRow.Cells["nCapitalDesembolso"].Value.ToString();
                FechaDesembolso         = dtgCreditos.CurrentRow.Cells["dFechaDesembolso"].Value.ToString();
                Estado                  = dtgCreditos.CurrentRow.Cells["cEstado"].Value.ToString();
                Cuenta                  = dtgCreditos.CurrentRow.Cells["idCuenta"].Value.ToString();
                Moneda                  = dtgCreditos.CurrentRow.Cells["cMoneda"].Value.ToString();
                idSolicitud             = Convert.ToInt32(dtgCreditos.CurrentRow.Cells["idSolicitud"].Value.ToString());
                idCuenta                = Convert.ToInt32(dtgCreditos.CurrentRow.Cells["idCuenta"].Value.ToString());

                //si hay dato llama al formulario con los datos del cliente
                FrmPosConDetCliente frmdet = new FrmPosConDetCliente(idSolicitud, Asesor, GestorRecuperaciones, Expediente, MontoDesembolsado, FechaDesembolso, Estado, Cuenta, Moneda, idCuenta);

                frmdet.ShowDialog();


            }
        }
        private void dtgOfertas_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dtgOfertas.RowCount>0)
            {
                if (e.ColumnIndex == dtgOfertas.Columns.IndexOf(colOtorgar))
                {

                    ClsOfertaClienteExclusivoMejorado objOferta = new ClsOfertaClienteExclusivoMejorado();
                    objOferta.idOferta = (int)dtgOfertas.CurrentRow.Cells["idOferta"].Value;
                    objOferta.idCli = (int)dtgOfertas.CurrentRow.Cells["idCli"].Value;
                    objOferta.nPlazo = (int)dtgOfertas.CurrentRow.Cells["nPlazo"].Value;
                    objOferta.nMontoOferta = (decimal)dtgOfertas.CurrentRow.Cells["nMontoOferta"].Value;
                    objOferta.cGrupoProducto = dtgOfertas.CurrentRow.Cells["cGrupoProducto"].Value.ToString();
                    objOferta.cTipoClienteExclusivo = dtgOfertas.CurrentRow.Cells["cTipoClienteExclusivo"].Value.ToString();
                    objOferta.cTipoGrupoCamp = dtgOfertas.CurrentRow.Cells["cTipoGrupoCamp"].Value.ToString();
                    objOferta.cPeriodoCred = dtgOfertas.CurrentRow.Cells["cPeriodoCred"].Value.ToString();
                    objOferta.idGrupoProducto = (int)dtgOfertas.CurrentRow.Cells["idGrupoProducto"].Value;
                    objOferta.idTipoClienteExclusivo = (int)dtgOfertas.CurrentRow.Cells["idTipoClienteExclusivo"].Value;
                    objOferta.idTipoGrupoCamp = (int)dtgOfertas.CurrentRow.Cells["idTipoGrupoCamp"].Value;
                    objOferta.idPeriodoCre = (int)dtgOfertas.CurrentRow.Cells["idPeriodoCre"].Value;
                    objOferta.idOperacion = (int)dtgOfertas.CurrentRow.Cells["idOperacion"].Value;
                    objOferta.cOperacion = dtgOfertas.CurrentRow.Cells["cOperacion"].Value.ToString();
                    objOferta.idModalidadCredito = (int)dtgOfertas.CurrentRow.Cells["idModalidadCredito"].Value;
                    objOferta.cModalidadCredito = dtgOfertas.CurrentRow.Cells["cModalidadCredito"].Value.ToString();
                    objOferta.nMeses = (int)dtgOfertas.CurrentRow.Cells["nMeses"].Value;
                    objOferta.idGrupoCamp = (int)dtgOfertas.CurrentRow.Cells["idGrupoCamp"].Value;
                    objOferta.cGrupoCamp = dtgOfertas.CurrentRow.Cells["cGrupoCamp"].Value.ToString();
                    objOferta.cDocumentoID = dtgOfertas.CurrentRow.Cells["cDocumentoID"].Value.ToString();
                    objOferta.idTipoDocumento = (int)dtgOfertas.CurrentRow.Cells["idTipoDocumento"].Value;
                    objOferta.cTipoDocumento = dtgOfertas.CurrentRow.Cells["cTipoDocumento"].Value.ToString();
                    objOferta.cNombreCliOferta = dtgOfertas.CurrentRow.Cells["cNombreCliOferta"].Value.ToString();
                    objOferta.idDestinoCredito = (int)dtgOfertas.CurrentRow.Cells["idDestinoCredito"].Value;
                    objOferta.cDestinoCredito = dtgOfertas.CurrentRow.Cells["cDestinoCredito"].Value.ToString();


                    objOferta.lCargaAutomaticoProd = Convert.ToInt32(dtgOfertas.CurrentRow.Cells["lCargaAutomaticaProd"].Value.ToString());

                    frmRegistroSolicitudCredito frm = new frmRegistroSolicitudCredito(objOferta);

                    frm.ShowDialog();

                }

                if (e.ColumnIndex == dtgOfertas.Columns.IndexOf(colSeguimiento))
                {


                    frmRegistroInfClienteOferta frm = new frmRegistroInfClienteOferta(idClienteT, cDocumentoIDT);
                    frm.ShowDialog();

                }
            }
           

            
        }
        public static bool ConvertirStrBool(string cadena)
        {
            switch (cadena.ToLower())
            {
                case "1":
                    return true;
                case "0":
                    return false;

                default:
                    throw new InvalidCastException("Este valor no se puede convertir a bool");
            }
        }

        protected bool IsCellValueSame(int column, int row)
        {
            DataGridViewCell cell1 = dgtvCondiciones[column, row];
            DataGridViewCell cell2 = dgtvCondiciones[column, row - 1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }
        private void dgtvCondiciones_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
            {
                return;
            }
            if (this.IsCellValueSame(e.ColumnIndex, e.RowIndex))
           
            {
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            }
            else
            {
                e.AdvancedBorderStyle.Top = dgtvCondiciones.AdvancedCellBorderStyle.Top;
            }
        }

        private void dgtvCondiciones_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                if (this.IsCellValueSame(e.ColumnIndex, e.RowIndex))
                {
                    e.Value = "";
                }
            }
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {

            HistoricoSentinel_Titular();
            HistoricoSentinel_Conyuge();
            nuevoReporte(idTipoDocumentoT,cDocumentoIDT);
        }
        public void HistoricoSentinel_Titular()
        {
            if (dtMicrTitular.Rows.Count>0)
            {
                dtHistorialSentinelTitular.Clear();
                var dataTitular = dtMicrTitular.AsEnumerable().GroupBy(X => X["FchPro"]).Select(X => X.CopyToDataTable());
                var SemaforoActual = InvertirCadena(cSemaforoTitular);

                decimal DeutaTotal;
                int nNumeroEntidad;
                string cCalificacion;
                string cfechaPRo;
               List<ListOrdenSemaforo> DataSemaforoTitular=LLenaListaSemaforo(SemaforoActual);

                for (int iDataTitular = 0; iDataTitular < dataTitular.Count(); iDataTitular++)
                {
                    var DataTitularAgrupada = dataTitular.ElementAt(iDataTitular);
                    DeutaTotal = 0;
                    nNumeroEntidad = 0;
                    cCalificacion = String.Empty;
                    cfechaPRo = string.Empty;
                    decimal nValorDeudaNOR = Decimal.Zero;
                    decimal nValorDeudaCPP = Decimal.Zero;
                    decimal nValorDeudaDEF = Decimal.Zero;
                    decimal nValorDeudaDUD = Decimal.Zero;
                    decimal nValorDeudaPER = Decimal.Zero;
                    decimal nValorDeudaSCAL = Decimal.Zero;
                    string cFechProNumero = String.Empty;

                    for (int y = 0; y < DataTitularAgrupada.Rows.Count; y++)
                    {
                        DeutaTotal += Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]);
                        nNumeroEntidad += 1;
                        cCalificacion = DataTitularAgrupada.Rows[y]["Cal"].ToString();
                        cfechaPRo = DataTitularAgrupada.Rows[y]["FchPro"].ToString();

                        nValorDeudaNOR  += (cCalificacion == "NOR" ) ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]): Decimal.Zero;
                        nValorDeudaCPP  += (cCalificacion == "CPP" ) ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]): Decimal.Zero;
                        nValorDeudaDEF  += (cCalificacion == "DEF" ) ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]): Decimal.Zero;
                        nValorDeudaDUD  += (cCalificacion == "DUD" ) ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]): Decimal.Zero;
                        nValorDeudaPER  += (cCalificacion == "PER" ) ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]): Decimal.Zero;
                        nValorDeudaSCAL += (cCalificacion == "SCAL") ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]): Decimal.Zero;

                        cFechProNumero = Convert.ToString(DataTitularAgrupada.Rows[y]["FchProNumero"]);
                    }

                    rowHistorialSentinelTitular = dtHistorialSentinelTitular.NewRow();

                    rowHistorialSentinelTitular["FechPro"] = cfechaPRo;
                    rowHistorialSentinelTitular["SemaActual"] = DataSemaforoTitular.Where(S => S.codigo == iDataTitular).Select(S => S.Semaforo).ToList()[0];
                    rowHistorialSentinelTitular["NroEntidad"] = nNumeroEntidad;
                    rowHistorialSentinelTitular["DeudaTotal"] = DeutaTotal;
                    rowHistorialSentinelTitular["Calificacion"] = cCalificacion;

                    rowHistorialSentinelTitular["PorcentajeNOR"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaNOR * 100 / DeutaTotal),0);
                    rowHistorialSentinelTitular["PorcentajeCPP"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaCPP * 100 / DeutaTotal),0);
                    rowHistorialSentinelTitular["PorcentajeDEF"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaDEF * 100 / DeutaTotal),0);
                    rowHistorialSentinelTitular["PorcentajeDUD"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaDUD * 100 / DeutaTotal),0);
                    rowHistorialSentinelTitular["PorcentajePER"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaPER * 100 / DeutaTotal),0);
                    rowHistorialSentinelTitular["PorcentajeSCAL"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaSCAL * 100 / DeutaTotal), 0);

                    rowHistorialSentinelTitular["FchProNumero"] = cFechProNumero;

                    dtHistorialSentinelTitular.Rows.Add(rowHistorialSentinelTitular);
                }
            }
         
        }
        public void HistoricoSentinel_Conyuge()
        {
            if (dtMicrConyuge.Rows.Count > 0)
            {
                dtHistorialSentinelConyuge.Clear();
                var dataConyuge = dtMicrConyuge.AsEnumerable().GroupBy(X => X["FchPro"]).Select(X => X.CopyToDataTable());
                var SemaforoActual = InvertirCadena(cSemaforoConyuge);

                decimal DeutaTotal;
                int nNumeroEntidad;
                string cCalificacion;
                string cfechaPRo;
                List<ListOrdenSemaforo> DataSemaforoTitular = LLenaListaSemaforo(SemaforoActual);

                for (int iDataConyuge = 0; iDataConyuge < dataConyuge.Count(); iDataConyuge++)
                {
                    var DataTitularAgrupada = dataConyuge.ElementAt(iDataConyuge);
                    DeutaTotal = 0;
                    nNumeroEntidad = 0;
                    cCalificacion = String.Empty;
                    cfechaPRo = string.Empty;
                    decimal nValorDeudaNOR = Decimal.Zero;
                    decimal nValorDeudaCPP = Decimal.Zero;
                    decimal nValorDeudaDEF = Decimal.Zero;
                    decimal nValorDeudaDUD = Decimal.Zero;
                    decimal nValorDeudaPER = Decimal.Zero;
                    decimal nValorDeudaSCAL = Decimal.Zero;
                    string cFechProNumero = String.Empty;

                    for (int y = 0; y < DataTitularAgrupada.Rows.Count; y++)
                    {
                        DeutaTotal += Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]);
                        nNumeroEntidad += 1;
                        cCalificacion = DataTitularAgrupada.Rows[y]["Cal"].ToString();
                        cfechaPRo = DataTitularAgrupada.Rows[y]["FchPro"].ToString();

                        nValorDeudaNOR += (cCalificacion == "NOR") ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]) : Decimal.Zero;
                        nValorDeudaCPP += (cCalificacion == "CPP") ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]) : Decimal.Zero;
                        nValorDeudaDEF += (cCalificacion == "DEF") ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]) : Decimal.Zero;
                        nValorDeudaDUD += (cCalificacion == "DUD") ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]) : Decimal.Zero;
                        nValorDeudaPER += (cCalificacion == "PER") ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]) : Decimal.Zero;
                        nValorDeudaSCAL += (cCalificacion == "SCAL") ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]) : Decimal.Zero;
                        cFechProNumero = Convert.ToString(DataTitularAgrupada.Rows[y]["FchProNumero"]);
                    }

                    rowHistorialSentinelConyuge = dtHistorialSentinelConyuge.NewRow();

                    rowHistorialSentinelConyuge["FechPro"] = cfechaPRo;
                    rowHistorialSentinelConyuge["SemaActual"] = DataSemaforoTitular.Where(S => S.codigo == iDataConyuge).Select(S => S.Semaforo).ToList()[0];
                    rowHistorialSentinelConyuge["NroEntidad"] = nNumeroEntidad;
                    rowHistorialSentinelConyuge["DeudaTotal"] = DeutaTotal;
                    rowHistorialSentinelConyuge["Calificacion"] = cCalificacion;

                    rowHistorialSentinelConyuge["PorcentajeNOR"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaNOR * 100 / DeutaTotal),0);
                    rowHistorialSentinelConyuge["PorcentajeCPP"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaCPP * 100 / DeutaTotal),0);
                    rowHistorialSentinelConyuge["PorcentajeDEF"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaDEF * 100 / DeutaTotal),0);
                    rowHistorialSentinelConyuge["PorcentajeDUD"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaDUD * 100 / DeutaTotal),0);
                    rowHistorialSentinelConyuge["PorcentajePER"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaPER * 100 / DeutaTotal),0);
                    rowHistorialSentinelConyuge["PorcentajeSCAL"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaSCAL * 100 / DeutaTotal),0);

                    rowHistorialSentinelConyuge["FchProNumero"] = cFechProNumero;

                    dtHistorialSentinelConyuge.Rows.Add(rowHistorialSentinelConyuge);
                }
            }

        }
        public void nuevoReporte(int idTipoDocumento, string cDocumentoID)
        {
            List<ReportParameter> listPar = new List<ReportParameter>();
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            DataTable dtCombinedDeudaSentinel = new DataTable();
            if (dtDeudaSentinelDirectaTitular!=null)
            {
                dtCombinedDeudaSentinel = dtDeudaSentinelDirectaTitular.Copy();
            }
         
            if (dtDeudaSentinelDirectaConyuge!=null)
            {
                dtCombinedDeudaSentinel.Merge(dtDeudaSentinelDirectaConyuge);
            }

            DataTable dtCombinedLineaCreditoSentinel = new DataTable();
            if (dtlCredNoUtilizadaT!=null)
            {
                dtCombinedLineaCreditoSentinel = dtlCredNoUtilizadaT.Copy();
            }
            if (dtlCredNoUtilizadaC!=null)
            {
                dtCombinedLineaCreditoSentinel.Merge(dtlCredNoUtilizadaC);
            }

            DataTable dtCombinedVencidoSentinel = new DataTable();
            if (dtDeudaTitular != null)
            {
                dtCombinedVencidoSentinel = dtDeudaTitular.Copy();
            }
            if (dtDeudaConyuge != null)
            {
                dtCombinedVencidoSentinel.Merge(dtDeudaConyuge);
            }

            DataTable dtCombinedAvalistaSentinel = new DataTable();
            if (dtAvalistaTitular != null)
            {
                dtCombinedAvalistaSentinel = dtAvalistaTitular.Copy();
            }
            if (dtAvalistaConyuge != null)
            {
                dtCombinedAvalistaSentinel.Merge(dtAvalistaConyuge);
            }

            DataTable dtCombinedAvaladoSentinel = new DataTable();
            if (dtAvalado != null)
            {
                dtCombinedAvaladoSentinel = dtAvalado.Copy();
            }
            if (dtAvaladoConyuge != null)
            {
                dtCombinedAvaladoSentinel.Merge(dtAvaladoConyuge);
            }

            if (objRespuestaTitular.Data != null)
            {
                foreach (DataSenConBasSBSMicr objDeuda in objRespuestaTitular.Data[0].ConRap.DetSBSMicr)
                {
                    DateTime dtFechaProc = new DateTime(objDeuda.ano, objDeuda.mes, 1);
                    rowMicrTitular = dtMicrTitular.NewRow();
                    rowMicrTitular["Condicion"] = "Titular";
                    rowMicrTitular["NomEnt"] = "DEUDA TOTAL";
                    rowMicrTitular["Cal"] = "SCAL";
                    rowMicrTitular["SalDeu"] = objDeuda.Detalle.Sum(x => Convert.ToDecimal(x.SalDeu));
                    rowMicrTitular["DiaVen"] = (objDeuda.Detalle.Count > 0) ? objDeuda.Detalle.Max(x => Convert.ToInt32(x.DiaVen)) : 0;
                    rowMicrTitular["FchPro"] = fechaformateada(objDeuda.ano + "-" + objDeuda.mes);
                    rowMicrTitular["FchRep"] = objDeuda.Detalle.Max(x => Convert.ToString(x.FchRep)); ;
                    rowMicrTitular["FchProNumero"] = dtFechaProc.ToString("yyyy-MM");
                    rowMicrTitular["DeudaTotal"] = objDeuda.Detalle.Sum(x => Convert.ToDecimal(x.SalDeu));
                    dtMicrTitular.Rows.Add(rowMicrTitular);
                }
            }

            if (objRespuestaConyuge != null)
            {
                foreach (DataSenConBasSBSMicr objDeuda in objRespuestaConyuge.Data[0].ConRap.DetSBSMicr)
                {
                    DateTime dtFechaProc = new DateTime(objDeuda.ano, objDeuda.mes, 1);
                    rowMicrConyuge = dtMicrConyuge.NewRow();
                    rowMicrConyuge["Condicion"] = "Conyuge";
                    rowMicrConyuge["NomEnt"] = "DEUDA TOTAL";
                    rowMicrConyuge["Cal"] = "SCAL";
                    rowMicrConyuge["SalDeu"] = objDeuda.Detalle.Sum(x => Convert.ToDecimal(x.SalDeu));
                    rowMicrConyuge["DiaVen"] = (objDeuda.Detalle.Count > 0) ? objDeuda.Detalle.Max(x => Convert.ToInt32(x.DiaVen)) : 0;
                    rowMicrConyuge["FchPro"] = fechaformateada(objDeuda.ano + "-" + objDeuda.mes);
                    rowMicrConyuge["FchRep"] = objDeuda.Detalle.Max(x => Convert.ToString(x.FchRep)); ;
                    rowMicrConyuge["FchProNumero"] = dtFechaProc.ToString("yyyy-MM");
                    rowMicrConyuge["DeudaTotal"] = objDeuda.Detalle.Sum(x => Convert.ToDecimal(x.SalDeu));
                    dtMicrConyuge.Rows.Add(rowMicrConyuge);
                }
            }
            


            listPar.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            listPar.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            listPar.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            listPar.Add(new ReportParameter("dFechaConsulta", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            listPar.Add(new ReportParameter("idTipoDocumento", Convert.ToString(idTipoDocumento), false));
            listPar.Add(new ReportParameter("cNumDocumento", cDocumentoID, false));

            dtslist.Add(new ReportDataSource("dtsLisVinculadosaCli", cninterviniente.CNdtLisVinculadosaCli(cDocumentoID, idTipoDocumento)));
            dtslist.Add(new ReportDataSource("dtsLisCliCreMismaDire", cninterviniente.CNdtLisCliCreMismaDire(cDocumentoID, idTipoDocumento)));
            dtslist.Add(new ReportDataSource("dtsRastreo", cninterviniente.CNdtLstRastreoPosicionConsolidada(cDocumentoIDT)));
            dtslist.Add(new ReportDataSource("dtCRE_PI2_CalifEntityRccSbs_SP", cninterviniente.dtCalifEntityRccSbs(idTipoDocumento, cDocumentoID)));
            dtslist.Add(new ReportDataSource("dtCRE_PI2_saldosSbsTitCony_SP", cninterviniente.dtsaldosSbsTitCony(idTipoDocumento, cDocumentoID)));
            dtslist.Add(new ReportDataSource("dtCRE_PI2_LisAvaladosRCCSBS_SP", cninterviniente.dtLisAvaladosRCCSBS(idTipoDocumento, cDocumentoID)));
            dtslist.Add(new ReportDataSource("dtCRE_PI2_LisCreCliFiSol_SP", cninterviniente.dtLisCreCliFiSol(idTipoDocumento, cDocumentoID)));
            dtslist.Add(new ReportDataSource("dtCRE_PI2_ListaCartasFianzaCliente_SP", cninterviniente.dtListaCartasFianzaCliente(idTipoDocumento, cDocumentoID)));
            dtslist.Add(new ReportDataSource("dtCRE_PI2_ClasifiInternaCaja_SP", cninterviniente.dtClasifiInternaCaja(idTipoDocumento, cDocumentoID)));
            dtslist.Add(new ReportDataSource("dtCRE_PI2_LisPEPPosInterv_SP", cninterviniente.dtLisPEPPosInterv(idTipoDocumento, cDocumentoID)));
            dtslist.Add(new ReportDataSource("dtCRE_PI2_LisBaseNegativa_SP", cninterviniente.dtLisBaseNegativa(idTipoDocumento, cDocumentoID)));
            dtslist.Add(new ReportDataSource("dtCRE_PI2_LisLibBaseNegativa_SP", cninterviniente.dtLisLibBaseNegativa(idTipoDocumento, cDocumentoID)));
            dtslist.Add(new ReportDataSource("dtCRE_PI2_LstSolicitudesCli_sp", cninterviniente.dtLstSolicitudesCli(idTipoDocumento, cDocumentoID)));
            dtslist.Add(new ReportDataSource("dtCRE_PI2_LisCrexCli_SP", cninterviniente.dtLisCrexCli(idTipoDocumento, cDocumentoID)));
            dtslist.Add(new ReportDataSource("dtCRE_PI2_LisCredPreApro_SP", cninterviniente.dtLisCredPreApro(idTipoDocumento, cDocumentoID)));
            dtslist.Add(new ReportDataSource("dtCRE_PI2_LisGarOtrUtixCli_SP", cninterviniente.dtLisGarOtrUtixCli(idTipoDocumento, cDocumentoID)));
            dtslist.Add(new ReportDataSource("dtCRE_PI2_LisGarxCli_SP", cninterviniente.dtLisGarxCli(idTipoDocumento, cDocumentoID)));
            dtslist.Add(new ReportDataSource("dtCRE_PI2_LisCtaAhoxCli_SP", cninterviniente.dtLisCtaAhoxCli(idTipoDocumento, cDocumentoID)));
            dtslist.Add(new ReportDataSource("dtCRE_PI2_LisCliCreMismaDire_SP", cninterviniente.dtLisCliCreMismaDire(idTipoDocumento, cDocumentoID)));
            dtslist.Add(new ReportDataSource("dtCRE_PI2_LisCliRelaGrupoEcono_SP", cninterviniente.dtLisCliRelaGrupoEcono(idTipoDocumento, cDocumentoID)));
            dtslist.Add(new ReportDataSource("dtCRE_PI2_CliPosiblesParientes_SP", cninterviniente.dtCliPosiblesParientes(idTipoDocumento, cDocumentoID)));
            dtslist.Add(new ReportDataSource("dtCRE_PI2_LisCliMismaGar_SP", cninterviniente.dtLisCliMismaGar(idTipoDocumento, cDocumentoID)));
            dtslist.Add(new ReportDataSource("dtCRE_PI2_LisDirNumTelPar_SP", cninterviniente.dtLisDirNumTelPar(idTipoDocumento, cDocumentoID)));
            dtslist.Add(new ReportDataSource("DtValidacionCondiciones", GeneraResumenCondiciones(dResultado)));
            dtslist.Add(new ReportDataSource("dtDetalleCampania",  objCE.CNObterneOfertaPersonaMoneda(cDocumentoIDT, idTipoDocumentoT)));
            dtslist.Add(new ReportDataSource("dtsbSunatTitular", dtBasicoSunatTitular));
            dtslist.Add(new ReportDataSource("dtsBSunatDireccionT", dtBSunatDireccionTitular));
            dtslist.Add(new ReportDataSource("dtsRLegalTitular", dtRlegalTitular));
            dtslist.Add(new ReportDataSource("dtsbSunatConyuge", dtBasicoSunatConyuge));
            dtslist.Add(new ReportDataSource("dtsBSunatDireccionC", dtBSunatDireccionConyuge));
            dtslist.Add(new ReportDataSource("dtsRLegalConyuge", dtRlegalConyuge));
            dtslist.Add(new ReportDataSource("dtsDeudaSentinelDirecta", dtCombinedDeudaSentinel));
            dtslist.Add(new ReportDataSource("dtsLCreditoNoUtil", dtCombinedLineaCreditoSentinel));
            dtslist.Add(new ReportDataSource("dtsVencidoSentinel", dtCombinedVencidoSentinel));
            dtslist.Add(new ReportDataSource("dtsListAvalista", dtCombinedAvalistaSentinel));
            dtslist.Add(new ReportDataSource("dtsListAvalado", dtCombinedAvaladoSentinel));
            dtslist.Add(new ReportDataSource("dtsHistoricoSentinel", dtHistorialSentinelTitular));
            dtslist.Add(new ReportDataSource("dtsHistoricoSentinelC", dtHistorialSentinelConyuge));
            dtslist.Add(new ReportDataSource("dtsCalificacionTConyuge", objLisTituConyuge));
            dtslist.Add(new ReportDataSource("dtsEndeudamientoTitular", dtMicrTitular));
            dtslist.Add(new ReportDataSource("dtsEndeudamientoConyuge", dtMicrConyuge));
            
            string reportpath = "RptPosIntConsol.rdlc";

            new frmReporteLocal(dtslist, reportpath, listPar).ShowDialog();
        }
      
        private void cboEstadoCredito_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cboEstadoCredito.SelectedIndex > -1)
            {
                if (cboEstadoCredito.SelectedValue is DataRowView) return;

                if (conBusCli.idCli > 0)
                {
                    cargardatos();
                }
            }
        }
        public static string InvertirCadena(string cadena)
        {
            // Convertir a arreglo
            char[] cadenaComoCaracteres = cadena.ToCharArray();
            // Invertir el arreglo usando métodos incorporados
            Array.Reverse(cadenaComoCaracteres);
            // Convertir de nuevo el arreglo a cadena
            return new string(cadenaComoCaracteres);
        }
        public List<ListOrdenSemaforo> LLenaListaSemaforo(string cadena)
        {

            List<ListOrdenSemaforo> lista = new List<ListOrdenSemaforo>();
            for (int i = 0; i < cadena.Length; i++)
            {
                ListOrdenSemaforo objmodel = new ListOrdenSemaforo();
                objmodel.codigo = i;
                objmodel.Semaforo = cadena[i].ToString();
                //char c = dato[i];
                lista.Add(objmodel);

            }

            return lista;
        }
        public void LLenarComboHistoricoDeduaSentinelTitular(DataTable dtMicrTitular)
        {
            var dataFechaTitularDeuda = dtMicrTitular.AsEnumerable().GroupBy(r => new {FchPro=r.Field<string>("FchPro")}).Select(x => {
                DataRow row =dtMicrTitular.NewRow();
                row["FchPro"]=x.Key.FchPro;
                return row;
            }).CopyToDataTable();

            cboTitularHistoricoDeuda.DataSource = dataFechaTitularDeuda;
            cboTitularHistoricoDeuda.ValueMember = dataFechaTitularDeuda.Columns["FchPro"].ToString();
            cboTitularHistoricoDeuda.DisplayMember = dataFechaTitularDeuda.Columns["FchPro"].ToString();
            cboTitularHistoricoDeuda.DropDownStyle = ComboBoxStyle.DropDownList;

        }
        public void LLenarComboHistoricoDeduaSentinelConyuge(DataTable dtMicrConyuge)
        {
            var dataFechaConyugeDeuda = dtMicrConyuge.AsEnumerable().GroupBy(r => new { FchPro = r.Field<string>("FchPro") }).Select(x =>
            {
                DataRow row = dtMicrConyuge.NewRow();
                row["FchPro"] = x.Key.FchPro;
                return row;
            }).CopyToDataTable();

            cboConyugeHistoricoDeuda.DataSource = dataFechaConyugeDeuda;
            cboConyugeHistoricoDeuda.ValueMember = dataFechaConyugeDeuda.Columns["FchPro"].ToString();
            cboConyugeHistoricoDeuda.DisplayMember = dataFechaConyugeDeuda.Columns["FchPro"].ToString();
            cboConyugeHistoricoDeuda.DropDownStyle = ComboBoxStyle.DropDownList;

        }
        private void btnBuscaDeudaSentinelTitular_Click(object sender, EventArgs e)
        {
            BuscarDeudaSentinelTitular();
           
        }
        public void BuscarDeudaSentinelTitular()
        {
             var dtExisteDataMesAnioSBSMicr = dtMicrTitular.AsEnumerable().Where(r => r.Field<string>("FchPro") == Convert.ToString(cboTitularHistoricoDeuda.SelectedValue)).Any();

            if (dtExisteDataMesAnioSBSMicr)
            {
                dtDeudaSentinelDirectaTitular = dtMicrTitular.AsEnumerable().Where(r => r.Field<string>("FchPro") == Convert.ToString(cboTitularHistoricoDeuda.SelectedValue)).CopyToDataTable();
                dtgEntNoSupervisada.DataSource = dtDeudaSentinelDirectaTitular;
                FormatoEntidadNoSupervisada();
            }
            else
            {
                dtgEntNoSupervisada.DataSource = null;
            }
        }
        public void BuscarDeudaSentinelConyuge()
        {
            var dtExisteDataMesAnioSBSMicrConyuge = dtMicrConyuge.AsEnumerable().Where(r => r.Field<string>("FchPro") == Convert.ToString(cboConyugeHistoricoDeuda.SelectedValue)).Any();
            if (dtExisteDataMesAnioSBSMicrConyuge)
            {
                dtDeudaSentinelDirectaConyuge = dtMicrConyuge.AsEnumerable().Where(r => r.Field<string>("FchPro") == Convert.ToString(cboConyugeHistoricoDeuda.SelectedValue)).CopyToDataTable();
                dtgEntNoSupervisadaConyuge.DataSource = dtDeudaSentinelDirectaConyuge;
                FormatoEntidadNoSupervisadaConyuge();
            }
            else
            {
                dtgEntNoSupervisadaConyuge.DataSource = null;
            }
        }
        private void btnBuscaDeudaSentinelConyuge_Click(object sender, EventArgs e)
        {
            BuscarDeudaSentinelConyuge();
        }

        private void dtgAvaladoTitular_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            switch (dtgAvaladoTitular.Columns[e.ColumnIndex].Name)
            {
                case "semAct":
                    if (e.Value != null)
                    {
                        if (e.Value.GetType() != typeof(System.DBNull))
                        {

                            if ((Convert.ToInt32(e.Value) == 1))
                            {
                                e.CellStyle.BackColor = Color.Red;
                                e.CellStyle.ForeColor = Color.Red;
                            };
                            if ((Convert.ToInt32(e.Value) == 2))
                            {
                                e.CellStyle.BackColor = Color.Yellow;
                                e.CellStyle.ForeColor = Color.Yellow;
                            };
                            if ((Convert.ToInt32(e.Value) == 3))
                            {
                                e.CellStyle.BackColor = Color.Gray;
                                e.CellStyle.ForeColor = Color.Gray;
                            };
                            if ((Convert.ToInt32(e.Value) == 4))
                            {
                                e.CellStyle.BackColor = Color.Green;
                                e.CellStyle.ForeColor = Color.Green;
                            };


                        }
                    }
                    break;
                case "cal":
                    if (e.Value != null)
                    {
                        if (e.Value.GetType() != typeof(System.DBNull))
                        {
                            if (e.Value.ToString() == "NOR")
                            {
                                e.CellStyle.BackColor = Color.Green;
                                e.CellStyle.ForeColor = Color.White;
                            };
                            if (e.Value.ToString() == "CPP")
                            {
                                e.CellStyle.BackColor = Color.Yellow;
                                e.CellStyle.ForeColor = Color.Black;
                            };
                            if (e.Value.ToString() == "DEF")
                            {
                                e.CellStyle.BackColor = Color.Orange;
                                e.CellStyle.ForeColor = Color.Black;
                            };
                            if (e.Value.ToString() == "DUD")
                            {
                                e.CellStyle.BackColor = Color.DarkOrange;
                                e.CellStyle.ForeColor = Color.Black;
                            };
                            if (e.Value.ToString() == "PER")
                            {
                                e.CellStyle.BackColor = Color.Red;
                                e.CellStyle.ForeColor = Color.White;
                            };

                        }
                    }
                    break;
                default:
                    break;
            }
       
            
        }

        private void dtgAvaladoConyuge_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            switch (dtgAvaladoConyuge.Columns[e.ColumnIndex].Name)
            {
                case "semAct":
                    if (e.Value != null)
                    {
                        if (e.Value.GetType() != typeof(System.DBNull))
                        {

                            if ((Convert.ToInt32(e.Value) == 1))
                            {
                                e.CellStyle.BackColor = Color.Red;
                                e.CellStyle.ForeColor = Color.Red;
                            };
                            if ((Convert.ToInt32(e.Value) == 2))
                            {
                                e.CellStyle.BackColor = Color.Yellow;
                                e.CellStyle.ForeColor = Color.Yellow;
                            };
                            if ((Convert.ToInt32(e.Value) == 3))
                            {
                                e.CellStyle.BackColor = Color.Gray;
                                e.CellStyle.ForeColor = Color.Gray;
                            };
                            if ((Convert.ToInt32(e.Value) == 4))
                            {
                                e.CellStyle.BackColor = Color.Green;
                                e.CellStyle.ForeColor = Color.Green;
                            };


                        }
                    }
                    break;
                case "cal":
                    if (e.Value != null)
                    {
                        if (e.Value.GetType() != typeof(System.DBNull))
                        {
                            if (e.Value.ToString() == "NOR")
                            {
                                e.CellStyle.BackColor = Color.Green;
                                e.CellStyle.ForeColor = Color.White;
                            };
                            if (e.Value.ToString() == "CPP")
                            {
                                e.CellStyle.BackColor = Color.Yellow;
                                e.CellStyle.ForeColor = Color.Black;
                            };
                            if (e.Value.ToString() == "DEF")
                            {
                                e.CellStyle.BackColor = Color.Orange;
                                e.CellStyle.ForeColor = Color.Black;
                            };
                            if (e.Value.ToString() == "DUD")
                            {
                                e.CellStyle.BackColor = Color.DarkOrange;
                                e.CellStyle.ForeColor = Color.Black;
                            };
                            if (e.Value.ToString() == "PER")
                            {
                                e.CellStyle.BackColor = Color.Red;
                                e.CellStyle.ForeColor = Color.White;
                            };

                        }
                    }
                    break;
                default:
                    break;
            }

        }
        public string DevuelveTipoDocumento(string cValor)
        {
            string cRespuesta = string.Empty;
            switch (cValor)
            {
                case "D":
                    cRespuesta = "DNI";
                    break;
                case "R":
                    cRespuesta = "RUC";
                    break;
                case "4":
                    cRespuesta = "CARNET EXTRANJERIA";
                    break;
                case "5":
                    cRespuesta = "PASAPORTE";
                    break;
                case "S":
                    cRespuesta = "RUC(SBS)";
                    break;
                default:
                    break;
            }
            return cRespuesta;
        }

        private void dtgAvalistaTitular_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            switch (dtgAvalistaTitular.Columns[e.ColumnIndex].Name)
            {
                case "SemAct":
                    if (e.Value != null)
                    {
                        if (e.Value.GetType() != typeof(System.DBNull))
                        {

                            if ((Convert.ToInt32(e.Value) == 1))
                            {
                                e.CellStyle.BackColor = Color.Red;
                                e.CellStyle.ForeColor = Color.Red;
                            };
                            if ((Convert.ToInt32(e.Value) == 2))
                            {
                                e.CellStyle.BackColor = Color.Yellow;
                                e.CellStyle.ForeColor = Color.Yellow;
                            };
                            if ((Convert.ToInt32(e.Value) == 3))
                            {
                                e.CellStyle.BackColor = Color.Gray;
                                e.CellStyle.ForeColor = Color.Gray;
                            };
                            if ((Convert.ToInt32(e.Value) == 4))
                            {
                                e.CellStyle.BackColor = Color.Green;
                                e.CellStyle.ForeColor = Color.Green;
                            };


                        }
                    }
                    break;
                case "SemPre":
                    if (e.Value != null)
                    {
                        if (e.Value.GetType() != typeof(System.DBNull))
                        {

                            if ((Convert.ToInt32(e.Value) == 1))
                            {
                                e.CellStyle.BackColor = Color.Red;
                                e.CellStyle.ForeColor = Color.Red;
                            };
                            if ((Convert.ToInt32(e.Value) == 2))
                            {
                                e.CellStyle.BackColor = Color.Yellow;
                                e.CellStyle.ForeColor = Color.Yellow;
                            };
                            if ((Convert.ToInt32(e.Value) == 3))
                            {
                                e.CellStyle.BackColor = Color.Gray;
                                e.CellStyle.ForeColor = Color.Gray;
                            };
                            if ((Convert.ToInt32(e.Value) == 4))
                            {
                                e.CellStyle.BackColor = Color.Green;
                                e.CellStyle.ForeColor = Color.Green;
                            };


                        }
                    }
                    break;
                case "Cal":
                    if (e.Value != null)
                    {
                        if (e.Value.GetType() != typeof(System.DBNull))
                        {
                            if (e.Value.ToString() == "NOR")
                            {
                                e.CellStyle.BackColor = Color.Green;
                                e.CellStyle.ForeColor = Color.White;
                            };
                            if (e.Value.ToString() == "CPP")
                            {
                                e.CellStyle.BackColor = Color.Yellow;
                                e.CellStyle.ForeColor = Color.Black;
                            };
                            if (e.Value.ToString() == "DEF")
                            {
                                e.CellStyle.BackColor = Color.Orange;
                                e.CellStyle.ForeColor = Color.Black;
                            };
                            if (e.Value.ToString() == "DUD")
                            {
                                e.CellStyle.BackColor = Color.DarkOrange;
                                e.CellStyle.ForeColor = Color.Black;
                            };
                            if (e.Value.ToString() == "PER")
                            {
                                e.CellStyle.BackColor = Color.Red;
                                e.CellStyle.ForeColor = Color.White;
                            };

                        }
                    }
                    break;
                    
                default:
                    break;
            }
       
            
        }

        private void dtgAvalistaConyuge_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            switch (dtgAvalistaConyuge.Columns[e.ColumnIndex].Name)
            {
                case "SemAct":
                    if (e.Value != null)
                    {
                        if (e.Value.GetType() != typeof(System.DBNull))
                        {

                            if ((Convert.ToInt32(e.Value) == 1))
                            {
                                e.CellStyle.BackColor = Color.Red;
                                e.CellStyle.ForeColor = Color.Red;
                            };
                            if ((Convert.ToInt32(e.Value) == 2))
                            {
                                e.CellStyle.BackColor = Color.Yellow;
                                e.CellStyle.ForeColor = Color.Yellow;
                            };
                            if ((Convert.ToInt32(e.Value) == 3))
                            {
                                e.CellStyle.BackColor = Color.Gray;
                                e.CellStyle.ForeColor = Color.Gray;
                            };
                            if ((Convert.ToInt32(e.Value) == 4))
                            {
                                e.CellStyle.BackColor = Color.Green;
                                e.CellStyle.ForeColor = Color.Green;
                            };


                        }
                    }
                    break;
                case "SemPre":
                    if (e.Value != null)
                    {
                        if (e.Value.GetType() != typeof(System.DBNull))
                        {

                            if ((Convert.ToInt32(e.Value) == 1))
                            {
                                e.CellStyle.BackColor = Color.Red;
                                e.CellStyle.ForeColor = Color.Red;
                            };
                            if ((Convert.ToInt32(e.Value) == 2))
                            {
                                e.CellStyle.BackColor = Color.Yellow;
                                e.CellStyle.ForeColor = Color.Yellow;
                            };
                            if ((Convert.ToInt32(e.Value) == 3))
                            {
                                e.CellStyle.BackColor = Color.Gray;
                                e.CellStyle.ForeColor = Color.Gray;
                            };
                            if ((Convert.ToInt32(e.Value) == 4))
                            {
                                e.CellStyle.BackColor = Color.Green;
                                e.CellStyle.ForeColor = Color.Green;
                            };


                        }
                    }
                    break;
                case "Cal":
                    if (e.Value != null)
                    {
                        if (e.Value.GetType() != typeof(System.DBNull))
                        {
                            if (e.Value.ToString() == "NOR")
                            {
                                e.CellStyle.BackColor = Color.Green;
                                e.CellStyle.ForeColor = Color.White;
                            };
                            if (e.Value.ToString() == "CPP")
                            {
                                e.CellStyle.BackColor = Color.Yellow;
                                e.CellStyle.ForeColor = Color.Black;
                            };
                            if (e.Value.ToString() == "DEF")
                            {
                                e.CellStyle.BackColor = Color.Orange;
                                e.CellStyle.ForeColor = Color.Black;
                            };
                            if (e.Value.ToString() == "DUD")
                            {
                                e.CellStyle.BackColor = Color.DarkOrange;
                                e.CellStyle.ForeColor = Color.Black;
                            };
                            if (e.Value.ToString() == "PER")
                            {
                                e.CellStyle.BackColor = Color.Red;
                                e.CellStyle.ForeColor = Color.White;
                            };

                        }
                    }
                    break;
                default:
                    break;
            }
       
        }
        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));

            DataTable table = new DataTable();

            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        private void conBusDocumento_ClickBuscar(object sender, EventArgs e)
        {
            idClienteT = conBusDocumento.idCliente;
            cDocumentoIDT = conBusDocumento.cDocumentoID;
            idTipoDocumentoT = conBusDocumento.idTipoDocumento;
            idTipoPersonaT = conBusDocumento.idTipoPersona;

            if (!String.IsNullOrWhiteSpace(cDocumentoIDT))
            {
                cargardatos();
                conBusCli.btnBusCliente.Enabled = false;
                if (idTipoPersonaT == 1)
                {
                    cTipoPersona = "N";
                }
                if (idTipoPersonaT == 2 || idTipoPersonaT == 3)
                {
                    cTipoPersona = "J";
                }


                //Validar REGLAS DINÁMICAS
                dResultado = ValidaReglasDinamicas.ValidarReglasCondiciones(ArmarTablaParametros(), this.Name, cTipoPersona);

                dgtvCondiciones.DataSource = dResultado;

                foreach (DataGridViewRow row in dgtvCondiciones.Rows)
                {
                    if (row.Cells["Resultado"].Value == "NO CUMPLE")
                    {
                        row.Cells["Resultado"].Style.BackColor = Color.Red;
                        row.Cells["Resultado"].Style.ForeColor = Color.White;
                    }
                    else
                    {
                        row.Cells["Resultado"].Style.BackColor = Color.FromArgb(146, 208, 80);
                        row.Cells["Resultado"].Style.ForeColor = Color.Black;
                    }
                }

                foreach (DataGridViewColumn Col in dgtvCondiciones.Columns)
                {
                    Col.SortMode = DataGridViewColumnSortMode.NotSortable;

                }
                dgtvCondiciones.Columns[0].Width = 40;
                dgtvCondiciones.Columns[1].Width = 500;
                dgtvCondiciones.Columns[2].Width = 220;
                dgtvCondiciones.Columns[3].Width = 115;
                dgtvCondiciones.Columns[4].Visible = false;

                dtgvResumenCondicion.DataSource = GeneraResumenCondiciones(dResultado);

                foreach (DataGridViewColumn row in dgtvCondiciones.Columns)
                {
                    row.Visible = false;
                }

                dgtvCondiciones.Columns["Nro"].Visible = true;
                dgtvCondiciones.Columns["Condiciones"].Visible = true;
                dgtvCondiciones.Columns["Mensaje"].Visible = true;
                dgtvCondiciones.Columns["Resultado"].Visible = true;

                foreach (DataGridViewRow row in dtgvResumenCondicion.Rows)
                {
                    if (Convert.ToString(row.Cells["Resultado"].Value).Contains("NO CUMPLE"))
                    {
                        row.Cells["Resultado"].Style.BackColor = Color.Red;
                        row.Cells["Resultado"].Style.ForeColor = Color.White;
                    }
                    else
                    {
                        row.Cells["Resultado"].Style.BackColor = Color.FromArgb(146, 208, 80);
                        row.Cells["Resultado"].Style.ForeColor = Color.Black;
                    }
                }

                dtgvResumenCondicion.Columns[0].Width = 260;
                dtgvResumenCondicion.Columns[1].Width = 900;

                registrarRastreoPosicionConsolidada(idClienteT, 0, "Consulta - Posición Consolidada Cliente", conBusDocumento.btnBuscarCliente, cDocumentoIDT);

            }
        }

    }
}
public class ClsOfertaClienteExclusivoMejorado
{
    public int idOferta { get; set; }
    public int idCli { get; set; }
    public int nPlazo { get; set; }
    public decimal nMontoOferta { get; set; }
    public string cGrupoProducto { get; set; }
    public string cTipoClienteExclusivo { get; set; }
    public string cTipoGrupoCamp { get; set; }
    public string cPeriodoCred { get; set; }
    public int idGrupoProducto { get; set; }
    public int idTipoClienteExclusivo { get; set; }
    public int idTipoGrupoCamp { get; set; }
    public int idPeriodoCre { get; set; }
    public int idOperacion { get; set; }
    public string cOperacion { get; set; }
    public int idModalidadCredito { get; set; }
    public string cModalidadCredito { get; set; }
    public int nMeses { get; set; }
    public int idGrupoCamp { get; set; }
    public string cGrupoCamp { get; set; }
    public string cDocumentoID { get; set; }
    public int idTipoDocumento { get; set; }
    public string cTipoDocumento { get; set; }
    public string cNombreCliOferta { get; set; }
    public int idDestinoCredito { get; set; }
    public string cDestinoCredito { get; set; }
    public int lCargaAutomaticoProd { get; set; }
    public int idClasifInterna { get; set; }

}
public class TitularConyuge
{

    public string cCondicion { get; set; }
    public string ctipoDocumento { get; set; }
    public string cnombre { get; set; }
    public string cNumDocumento { get; set; }
    public int idCli { get; set; }
    public string cCalificacion { get; set; }
    public string cEstadoCivil { get; set; }
    public string cEdad { get; set; }
    public string cRelNDoc { get; set; }
    public string cTipoCliente { get; set; }
    public string PuntajeScore { get; set; }
    public string nRiesgo { get; set; }
    public string CapacidadPago { get; set; }
    public int idTipoDocumento { get; set; }
    //public string Color { get; set; }

}

public class BarraTitularConyuge
{
    public string fechaCalfSBS { get; set; }
    public double saldo { get; set; }
    public double nSaldoCastigado { get; set; }

}
public class ListOrdenSemaforo
{
    public int codigo { get; set; }
    public string Semaforo { get; set; }
}