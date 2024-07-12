using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using SPL.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPL.Presentacion
{
    public partial class frmMonitorOperaciones : frmBase
    {
        #region Varibles globales
        clsCNMapeoRiesgoYOpeInusual cnmapeoriesgoyopeinusual = new clsCNMapeoRiesgoYOpeInusual();
        String cTitulo = "Monitor operaciones inusuales";
        DataTable dtClienteS = new DataTable();
        #endregion
        public frmMonitorOperaciones()
        {
            InitializeComponent();            
           
        }
        #region Eventos        
        private void frmMonitorSeguimientoSPLAFT_Load(object sender, EventArgs e)
        {
            cargarCboPerfilCli();
            this.cboOperaciones.SelectedIndexChanged -= new EventHandler(cboOperaciones_SelectedIndexChanged);            
            cargarCboOperaciones();         
            this.cboOperaciones.SelectedIndexChanged += new EventHandler(cboOperaciones_SelectedIndexChanged);
            this.conBusUbig1.cargar();
            this.conBusUbig1.cboPais.SelectedValue = 173;
            this.dtpHasta.Value = clsVarGlobal.dFecSystem;
            this.dtpDesde.Value = clsVarGlobal.dFecSystem;
        }

        private void cboOperaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            cambiarOpcionesOperaciones();                
        }
        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            imprimir();
        }
        private void btnProcesar1_Click(object sender, EventArgs e)
        {
            this.dtgLista.DataSource = null;
            cargarClientesSegui();
        }

        private void btnEliminar1_Click(object sender, EventArgs e)
        {
            eliminarCliDeLista();
        }
        #endregion
        #region Metodos
        private void cargarClientesSegui()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (Convert.ToInt32(this.cboOperaciones.SelectedValue) == 0)
            {
                dtClienteS = cnmapeoriesgoyopeinusual.listaClientesXPerfil(Convert.ToInt32(this.cboPerfiles.SelectedValue), this.conBusUbig1.nIdNodo, clsVarGlobal.dFecSystem);
                this.dtgLista.DataSource = dtClienteS;
                Cursor.Current = Cursors.Default;
            }
            else
            {
                if (Convert.ToDateTime(this.dtpDesde.Value) <= Convert.ToDateTime(this.dtpHasta.Value))
                {
                    if (Convert.ToInt32(this.cboOperaciones.SelectedValue) == 1)
                    {
                        dtClienteS = cnmapeoriesgoyopeinusual.listaClientesSeguiCreditos(Convert.ToInt32(this.cboPerfiles.SelectedValue), Convert.ToDateTime(this.dtpDesde.Value), Convert.ToDateTime(this.dtpHasta.Value));
                        this.dtgLista.DataSource = dtClienteS;
                    }
                    else if (Convert.ToInt32(this.cboOperaciones.SelectedValue) == 2)
                    {
                        dtClienteS = cnmapeoriesgoyopeinusual.listaClientesSeguiAhorros(Convert.ToInt32(this.cboPerfiles.SelectedValue), Convert.ToDateTime(this.dtpDesde.Value), Convert.ToDateTime(this.dtpHasta.Value));
                        this.dtgLista.DataSource = dtClienteS;
                    }
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("La fecha inicial no puede ser mayor a la fecha final", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                pintarAlertaCancel();
            }               

            if (dtClienteS.Rows.Count == 0)
            {
                MessageBox.Show("No existen registros para esta búsqueda", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            formatoDTGClientesSegui();
            
        }
        private void formatoDTGClientesSegui()
        {
            Boolean lMostrar = true;
            foreach (DataGridViewColumn item in this.dtgLista.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                if (item.Name == "lDesdeAquiNoMostrar")
                {
                    lMostrar = false;       
                }
                item.Visible = lMostrar;  
            }
            if (Convert.ToInt32(this.cboOperaciones.SelectedValue) == 0)
            {        
                this.dtgLista.Columns["cPerfilCliOpeInusual"].HeaderText = "Perfil riesgo";
                this.dtgLista.Columns["ID_cli"].HeaderText = "Cod.Cli.";
                this.dtgLista.Columns["Tipo_Persona"].HeaderText = "Tipo persona";
                this.dtgLista.Columns["Tipo_Doc"].HeaderText = "Tipo Doc.";
                this.dtgLista.Columns["Num_Documento"].HeaderText = "Nº documento";
                this.dtgLista.Columns["Nombres"].HeaderText = "Nombres";
                this.dtgLista.Columns["Edad"].HeaderText = "Edad";
                this.dtgLista.Columns["Actividad"].HeaderText = "Actividad";                
                this.dtgLista.Columns["Pais"].HeaderText = "País";
                this.dtgLista.Columns["Departamento"].HeaderText = "Departamento";
                this.dtgLista.Columns["Provincia"].HeaderText = "Provincia";
                this.dtgLista.Columns["Distrito"].HeaderText = "Distrito";
                this.dtgLista.Columns["Domicilio"].HeaderText = "Domicilio";
                this.dtgLista.Columns["PjeZona"].HeaderText = "Ptj.Riesgo Zona";
                this.dtgLista.Columns["CalificZona"].HeaderText = "Calific.Riesgo Zona";
                this.dtgLista.Columns["TipoCuenta"].HeaderText = "Tipo Cuenta";
                this.dtgLista.Columns["cProducto"].HeaderText = "Producto";
                this.dtgLista.Columns["idCuenta"].HeaderText = "N° Cuenta";
                this.dtgLista.Columns["PtjProd"].HeaderText = "Ptj.Riesgo Prod.";
                this.dtgLista.Columns["CalificProd"].HeaderText = "Calific.Riesgo Prod.";
                                
                return;
            }                     
          
            if (Convert.ToInt32(this.cboOperaciones.SelectedValue) == 1)
            {                
                this.dtgLista.Columns["Monto_Desblso"].DefaultCellStyle.Format = "N2";
                this.dtgLista.Columns["Monto_Desblso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                this.dtgLista.Columns["Age_Suscrita"].HeaderText = "Agencia suscrita";
                this.dtgLista.Columns["Monto_Desblso"].HeaderText = "Monto desembolso";
                this.dtgLista.Columns["Cuotas"].HeaderText = "Cuotas";
                this.dtgLista.Columns["Tasa"].HeaderText = "Tasa";
                this.dtgLista.Columns["Fecha_Desblso"].HeaderText = "Fecha desembolso";
                this.dtgLista.Columns["Fecha_Vencto"].HeaderText = "Fecha vencimiento";
            }
            else if (Convert.ToInt32(this.cboOperaciones.SelectedValue) == 2)
            {                
                this.dtgLista.Columns["Monto_Apert"].DefaultCellStyle.Format = "N2";
                this.dtgLista.Columns["Monto_Apert"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                this.dtgLista.Columns["Age_Apert"].HeaderText = "Agencia apertura";
                this.dtgLista.Columns["Monto_Apert"].HeaderText = "Monto apertura";
                this.dtgLista.Columns["Plazo"].HeaderText = "Plazo";
                this.dtgLista.Columns["TEA"].HeaderText = "TEA";
                this.dtgLista.Columns["Fecha_Apert"].HeaderText = "Fecha apertura";
                this.dtgLista.Columns["Fecha_Normal_Cancel"].HeaderText = "Fecha normal Cancel.";
            }            
            this.dtgLista.Columns["Monto_Ope"].DefaultCellStyle.Format = "N2";
            this.dtgLista.Columns["Monto_Dolares"].DefaultCellStyle.Format = "N2";
            this.dtgLista.Columns["Saldo_Capital"].DefaultCellStyle.Format = "N2";
            this.dtgLista.Columns["Saldo_Interes"].DefaultCellStyle.Format = "N2";
            this.dtgLista.Columns["Umbral_Age_Ope"].DefaultCellStyle.Format = "N2";

            this.dtgLista.Columns["Monto_Ope"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dtgLista.Columns["Monto_Dolares"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dtgLista.Columns["Saldo_Capital"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dtgLista.Columns["Saldo_Interes"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dtgLista.Columns["Umbral_Age_Ope"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.dtgLista.Columns["Z"].DefaultCellStyle.Font = new Font(this.dtgLista.Font, FontStyle.Bold);
            this.dtgLista.Columns["Z"].DefaultCellStyle.ForeColor = Color.LightGray;
            this.dtgLista.Columns["P"].DefaultCellStyle.Font = new Font(this.dtgLista.Font, FontStyle.Bold);
            this.dtgLista.Columns["P"].DefaultCellStyle.ForeColor = Color.LightGray;

            this.dtgLista.Columns["Z"].HeaderText = "Z";
            this.dtgLista.Columns["P"].HeaderText = "P";
            this.dtgLista.Columns["Tip_Doc_Fis"].HeaderText = "Tip.Doc.Fis.";
            this.dtgLista.Columns["N_Doc_Fis"].HeaderText = "Nº Doc.Fis.";
            this.dtgLista.Columns["Persona_Fisica"].HeaderText = "Persona Física";
            this.dtgLista.Columns["Tip_Doc_Ord"].HeaderText = "Tip.Doc.Ord.";
            this.dtgLista.Columns["N_Doc_Ord"].HeaderText = "Nº Doc.Ord.";
            this.dtgLista.Columns["Persona_Ordenante"].HeaderText = "Persona Ordenante";
            this.dtgLista.Columns["ID"].HeaderText = "Cod.Cliente";
            this.dtgLista.Columns["Tip_Doc"].HeaderText = "Tip.Doc.";
            this.dtgLista.Columns["N_Doc"].HeaderText = "Nº Doc.";
            this.dtgLista.Columns["RUC"].HeaderText = "RUC";
            this.dtgLista.Columns["Cliente"].HeaderText = "Nombres cliente";
            this.dtgLista.Columns["Edad"].HeaderText = "Edad";
            this.dtgLista.Columns["Pais"].HeaderText = "País";
            this.dtgLista.Columns["Departamento"].HeaderText = "Departamento";
            this.dtgLista.Columns["Provincia"].HeaderText = "Provincia";
            this.dtgLista.Columns["Distrito"].HeaderText = "Distrito";
            this.dtgLista.Columns["Domicilio"].HeaderText = "Domicilio";            
            this.dtgLista.Columns["Ptj_Riesgo_Zona"].HeaderText = "Ptj.Riesgo Zona";
            this.dtgLista.Columns["Riesgo_Zona"].HeaderText = "Calific.Riesgo Zona";
            this.dtgLista.Columns["Actividad"].HeaderText = "Actividad";
            this.dtgLista.Columns["Tipo_Cuenta"].HeaderText = "Tipo cuenta";
            this.dtgLista.Columns["N_Cuenta"].HeaderText = "Nº Cuenta";
            //this.dtgLista.Columns["Age_Apert"].HeaderText = "Agencia apertura";
            //this.dtgLista.Columns["Monto_Apert"].HeaderText = "Monto apertura";
            this.dtgLista.Columns["MonedaAper"].HeaderText = "Moneda apertura";
            //this.dtgLista.Columns["Plazo"].HeaderText = "Plazo";
            //this.dtgLista.Columns["TEA"].HeaderText = "TEA";
            //this.dtgLista.Columns["Fecha_Apert"].HeaderText = "Fecha apertura";
            //this.dtgLista.Columns["Fecha_Normal_Cancel"].HeaderText = "Fecha normal cancel.";
            this.dtgLista.Columns["Producto"].HeaderText = "Producto";
            this.dtgLista.Columns["Ptj_Riesgo_Prod"].HeaderText = "Ptj.Riesgo Prod.";
            this.dtgLista.Columns["Riesgo_Prod"].HeaderText = "Calific.Riesgo Prod.";
            this.dtgLista.Columns["Tipo_Ope"].HeaderText = "Tipo operación";
            this.dtgLista.Columns["Motivo_Ope"].HeaderText = "Motivo operación";
            this.dtgLista.Columns["N_Ope"].HeaderText = "Nº Kardex";
            this.dtgLista.Columns["MonedaOpe"].HeaderText = "Moneda Ope.";
            this.dtgLista.Columns["Monto_Ope"].HeaderText = "Monto Ope.";
            this.dtgLista.Columns["Monto_Dolares"].HeaderText = "Monto dolares Ope.";
            this.dtgLista.Columns["Umbral_Age_Ope"].HeaderText = "Umbral agencia";            
            this.dtgLista.Columns["Dias_Faltantes"].HeaderText = "Dias faltantes";
            this.dtgLista.Columns["Saldo_Capital"].HeaderText = "Saldo capital";
            this.dtgLista.Columns["Saldo_Interes"].HeaderText = "Saldo interés";
            this.dtgLista.Columns["Usuario_Ope"].HeaderText = "Usuario Ope.";
            this.dtgLista.Columns["Age_Ope"].HeaderText = "Agencia Ope.";
            this.dtgLista.Columns["Fecha_Ope"].HeaderText = "Fecha Ope.";
            this.dtgLista.Columns["Origen"].HeaderText = "Origen fondos";
        }
        private void cargarCboPerfilCli()
        {
            DataTable dtPerfiles = cnmapeoriesgoyopeinusual.listaPerfilCli(0);
            dtPerfiles.DefaultView.RowFilter = "lVigente = 1";

            this.cboPerfiles.DataSource = dtPerfiles;
            this.cboPerfiles.DisplayMember = "cPerfilCliOpeInusual";
            this.cboPerfiles.ValueMember = "idPerfilCliOpeInusual";
        }
        private void cargarCboOperaciones()
        {
            DataTable dtOpe = new DataTable();
            dtOpe.Columns.Add("idOpe", typeof(int));
            dtOpe.Columns.Add("cOpe", typeof(String));
            DataRow drOpe0 = dtOpe.NewRow();
            drOpe0["idOpe"] = 0;
            drOpe0["cOpe"] = "CLIENTES";
            dtOpe.Rows.Add(drOpe0);
            DataRow drOpe1 = dtOpe.NewRow();
            drOpe1["idOpe"] = 1;
            drOpe1["cOpe"] = "OPE.CREDITOS";
            dtOpe.Rows.Add(drOpe1);
            DataRow drOpe2 = dtOpe.NewRow();
            drOpe2["idOpe"] = 2;
            drOpe2["cOpe"] = "OPE.AHORROS";
            dtOpe.Rows.Add(drOpe2);

            this.cboOperaciones.DataSource = dtOpe;
            this.cboOperaciones.DisplayMember = "cOpe";
            this.cboOperaciones.ValueMember = "idOpe";
        }
        private void pintarAlertaCancel()
        {
            int idMotivo;
            int idTipoOpe;
            foreach (DataGridViewRow item in this.dtgLista.Rows)
            {
                item.Cells["Z"].Style.ForeColor = Color.FromName(Convert.ToString(item.Cells["ColorRiesgoZona"].Value));
                item.Cells["P"].Style.ForeColor = Color.FromName(Convert.ToString(item.Cells["ColorRiesgoProd"].Value));
                
                //pintamos alertas de operaciones de cancelaciones anticipadas
                item.DefaultCellStyle.BackColor = Color.FromName(Convert.ToString(item.Cells["cColorRegistro"].Value));                 
            }
        }
        private void cambiarOpcionesOperaciones()
        {
            if (Convert.ToInt32(this.cboOperaciones.SelectedValue) == 0)
            {
                this.conBusUbig1.Visible = true;
                this.pnlRangoFecha.Visible = false;
            }
            else
            {
                this.conBusUbig1.Visible = false;
                this.pnlRangoFecha.Visible = true;
            }
        }
        private void imprimir()
        {
            if (this.dtgLista.Rows.Count == 0)
            {
                MessageBox.Show("No existen registros para imprimir", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            String cPerfil = Convert.ToString(((DataRowView)this.cboPerfiles.SelectedItem)["cPerfilCliOpeInusual"]);
            List<ReportParameter> paramlist = new List<ReportParameter>();
            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            paramlist.Add(new ReportParameter("cNomAgen", clsVarApl.dicVarGen["cNomAge"], false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

            if (Convert.ToInt32(this.cboOperaciones.SelectedValue) == 0)
            {
                paramlist.Add(new ReportParameter("idUbigeo", this.conBusUbig1.nIdNodo.ToString(), false));
                paramlist.Add(new ReportParameter("idPerfil", this.cboPerfiles.SelectedValue.ToString(), false));
                paramlist.Add(new ReportParameter("dFechaHoy", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                string reportpath = "rptClientesXperfilRiesgo.rdlc";
                dtslist.Add(new ReportDataSource("DataSet1", this.dtClienteS));

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            if (Convert.ToInt32(this.cboOperaciones.SelectedValue) == 1)
            {
                paramlist.Add(new ReportParameter("dFechaDesde", this.dtpDesde.Value.ToString(), false));
                paramlist.Add(new ReportParameter("dFechaHasta", this.dtpHasta.Value.ToString(), false));
                paramlist.Add(new ReportParameter("cPerfilCli", cPerfil, false));
                string reportpath = "rptMonitorOpeCreditos.rdlc";
                dtslist.Add(new ReportDataSource("DSclientes", this.dtClienteS));

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else if (Convert.ToInt32(this.cboOperaciones.SelectedValue) == 2)
            {
                paramlist.Add(new ReportParameter("dFechaDesde", this.dtpDesde.Value.ToString(), false));
                paramlist.Add(new ReportParameter("dFechaHasta", this.dtpHasta.Value.ToString(), false));
                paramlist.Add(new ReportParameter("cPerfilCli", cPerfil, false));
                string reportpath = "rptMonitorOpeAhorros.rdlc";
                dtslist.Add(new ReportDataSource("DSclientes", this.dtClienteS));

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }
        private void eliminarCliDeLista()
        {
            if (this.dtgLista.Rows.Count == 0)
            {
                MessageBox.Show("No existen registros para eliminar", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.dtgLista.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un registro para eliminar", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            int id;
            try
            {
                id = Convert.ToInt32(this.dtgLista.SelectedRows[0].Cells["idClienteOpeInusual"].Value);
                if (MessageBox.Show("¿Está seguro de eliminar el cliente?", cTitulo, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    DataTable dtInsercion = cnmapeoriesgoyopeinusual.eliminaClienteDeSeguiOpe(id, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
                    MessageBox.Show(dtInsercion.Rows[0]["cMensaje"].ToString(), cTitulo, MessageBoxButtons.OK, ((int)dtInsercion.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
                    cargarClientesSegui();
                }
            }
            catch
            {
                MessageBox.Show("No se registraron operaciones", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }
        #endregion
    }
}
