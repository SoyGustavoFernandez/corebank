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
using Microsoft.Reporting.WinForms;

namespace GEN.ControlesBase
{
    public partial class frmDeclaracionJurada : frmBase
    {
        #region Variables
        List<ReportParameter> paramlist = new List<ReportParameter>();
        List<ReportDataSource> dtslist = new List<ReportDataSource>();
        clsCNRetDatosCliente cncliente = new clsCNRetDatosCliente();
        clsCNDirecCli cndireccion = new clsCNDirecCli();
        clsCNListaActivEco cnactividad = new clsCNListaActivEco();
        clsCNDeclaracionJurada cndeclaracion = new clsCNDeclaracionJurada();

        Transaccion estado = Transaccion.Nuevo;
        clsCliente cliente;

        private int idCli = 0,idActividad=0,idDireccion=0,idUbigeo=0;
        private string cActividad = "", cDireccion = "", cDistrito	 = "",cProvincia="",cDepartamento="",cAnexo;
        private int nTipoPersona = 0;

        #endregion

        public frmDeclaracionJurada()
        {
            InitializeComponent();
            btnBusCliente1.Enabled = true;
            estado = Transaccion.Nuevo;
            cargarOcupaciones();
            chklbOcupaciones.Enabled = false;
            grbBase2.Enabled = false;
            grbBase3.Enabled = false;
            txtOtrasOcupaciones.Enabled = false;
            txtIngresoMensual.Enabled = false;
            desSelecionOcupaciones();
        }
        
        public frmDeclaracionJurada(int _idCli)
        {
            if (Convert.ToInt32(clsVarApl.dicVarGen["lActivarFrmSujetoObligado"]) == 0)
            {
                return;
            }

            var dtValida = cndeclaracion.validarSujetoObligado(_idCli);
            if (dtValida.Rows.Count <= 0)
            {
                this.Dispose();
                return;
            }

            
           

            if (dtValida.Rows[0]["nValida"].ToString() == "0" || dtValida.Rows[0]["nValida"].ToString() == "1")
            {
                this.Dispose();
                return;
            }

            else if (dtValida.Rows[0]["nValida"].ToString() == "2")
            {
                MessageBox.Show("Cliente cumple con características de Sujeto Obligado \n a continuación se procedera con el registro", "Sujeto Obligado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                InitializeComponent();

                btnBusCliente1.Enabled = false;
                estado = Transaccion.Edita;
                idCli = _idCli;
                cargarOcupaciones();
                desSelecionOcupaciones();
                chklbOcupaciones.Enabled = false;
                txtOtrasOcupaciones.Enabled = false;
                txtIngresoMensual.Enabled = false;
                btnSalir1.Enabled = false;
            }
                               
            if (this.Visible == true)
            {
                this.Show();
            }
            else
            {
                btnCancelar.Visible = false;
                this.ShowDialog();
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            conBusUbig1.cargar();
            if (estado== Transaccion.Edita)
            {
               cliente= cncliente.retornarCliente(idCli);
               nTipoPersona = cliente.IdTipoPersona;
               if (cliente.IdTipoPersona==1)
               {
                   conDatCli1.cargarCliente(idCli);
               }
               else
               {
                   rbtEsSOSi.Checked = true;
                   grbBase2.Enabled = false;
                   txtIngresoMensual.Enabled = true;
                   conDatCli1.cargarClienteJur(idCli);
               }

               cliente = conDatCli1.cliente;
               cargarActividad();
               cargarDireccion();
               btnGrabar1.Enabled       = true;
               btnSalir1.Enabled        = false;
               chklbOcupaciones.Enabled = false;               
            }
            else
            {
                btnSalir1.Enabled = true;
            }
        }

        private void btnBusCliente1_Click(object sender, EventArgs e)
        {
            FrmBusCli frmbuscli = new FrmBusCli();

            frmbuscli.ShowDialog();
            desSelecionOcupaciones();
            grbBase2.Enabled = false;
            grbBase3.Enabled = false;
            rbtCuentaOCNo.Checked = false;
            rbtCuentaOCSi.Checked = false;
            rbtEsSONo.Checked = false;
            rbtEsSOSi.Checked = false;

            if (frmbuscli.pcCodCli=="" ||frmbuscli.pcCodCli=="0")
            {
                return;
            }

            idCli = Convert.ToInt32(frmbuscli.pcCodCli);


            var dtValida = cndeclaracion.validarSujetoObligado(idCli);
            if (dtValida.Rows[0]["nValida"].ToString()=="0")
            {
                limpiarControles();
                btnGrabar1.Enabled=false;
                btnImprimir1.Enabled = false;
                MessageBox.Show("Cliente no cumple con las características de Sujeto Obligado", "Sujeto Obligado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;                
            }

            

            if (frmbuscli.pnTipoPersona == 1)
            {
                conDatCli1.cargarCliente(idCli);
                chklbOcupaciones.Enabled = true;
                nTipoPersona = 1;
            }
            else
            {
                conDatCli1.cargarClienteJur(idCli);
                chklbOcupaciones.Enabled = false;
                nTipoPersona = 2;
            }
            cliente = conDatCli1.cliente;
            cargarActividad();
            cargarDireccion();
            
            btnGrabar1.Enabled = true;
            grbBase2.Enabled = true;
            grbBase3.Enabled = true;

            if (dtValida.Rows[0]["nValida"].ToString() == "1")
            {
                btnGrabar1.Enabled = false;
                btnImprimir1.Enabled = true;
                chklbOcupaciones.Enabled = false;
                
                
                var dtDatDecJurada = cndeclaracion.retDatDecJurSujObli(idCli);
                // cambiando 
                if ((bool)dtDatDecJurada.Rows[0]["lSujetoObligado"]) 
                {
                    rbtEsSOSi.Checked = true;
                }
                else 
                {
                    rbtEsSONo.Checked = true;
                }
                if ((bool)dtDatDecJurada.Rows[0]["lOficialCumplimiento"])
                {
                    rbtCuentaOCSi.Checked = true;
                }
                else
                {
                    rbtCuentaOCNo.Checked = true;
                }
                txtOtrasOcupaciones.Text    = (string)dtDatDecJurada.Rows[0]["cOtraOcupacion"].ToString();
                txtIngresoMensual.Text      = (string)dtDatDecJurada.Rows[0]["nIngresosMensuales"].ToString();

                grbBase2.Enabled = false;
                grbBase3.Enabled = false;
                txtOtrasOcupaciones.Enabled = false;
                txtIngresoMensual.Enabled = false;
                chklbOcupaciones.Enabled = false;

                seleccionarOcupaciones(Convert.ToInt32(dtDatDecJurada.Rows[0]["idDeclaracion"]));
                MessageBox.Show("Ya existe el registro del cliente como Sujeto Obligado", "Sujeto Obligado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void cargarActividad()
        {   
            var dtbPAdre = cnactividad.BuscarPadre(cliente.nIdActivEco);
            cboActividadEco1.CargarActivEconomica(Convert.ToInt32(dtbPAdre.Rows[0][0]));
            cboActividadEco1.SelectedValue = cliente.nIdActivEco;
        }

        private void cargarUbigeo(int idUbigeo)
        {
            conBusUbig1.cargarUbigeo(idUbigeo);
        }

        private void cargarDireccion()
        {
            var dtdirecciones=cndireccion.ListaDirCli(idCli);
            var dirPrinci=dtdirecciones.AsEnumerable().Where(x => Convert.ToBoolean(x["lDirPrincipal"]) == true).First();

            txtDireccion.Text = dirPrinci["cDireccion"].ToString();
            cargarUbigeo(Convert.ToInt32(dirPrinci["idUbigeo"]));
            idDireccion = Convert.ToInt32(dirPrinci["idDireccion"]);
            cDireccion = dirPrinci["cDireccion"].ToString();
            idUbigeo=Convert.ToInt32(dirPrinci["idUbigeo"]);
            cActividad = cboActividadEco1.Text;
            idActividad = (int)cboActividadEco1.SelectedValue;
            cDepartamento = conBusUbig1.cboDepartamento.Text;
            cAnexo = conBusUbig1.cboAnexo.Text;
            cProvincia = conBusUbig1.cboProvincia.Text;
            cDistrito = conBusUbig1.cboDistrito.Text;
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (!rbtEsSONo.Checked && !rbtEsSOSi.Checked)
            {
                MessageBox.Show("No respondió la pregunta ¿Es Sujeto Obligado?", "Sujeto Obligado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!rbtCuentaOCSi.Checked && !rbtCuentaOCNo.Checked)
            {
                MessageBox.Show("No respondió la pregunta ¿Cuénta con Oficial de Cumplimiento?", "Sujeto Obligado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (chklbOcupaciones.CheckedItems.Count == 0  && rbtEsSONo.Checked && nTipoPersona == 1)
            {
                if (String.IsNullOrEmpty(txtOtrasOcupaciones.Text))
                {
                    MessageBox.Show("Seleccione al Menos una ocupación", "Sujeto Obligado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
            }
            
            if (rbtEsSOSi.Checked && txtIngresoMensual.nDecValor == 0 && nTipoPersona != 1)
            {
                MessageBox.Show("Falta Ingresos Mensuales del cliente", "Sujeto Obligado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtIngresoMensual.Text == "" && rbtEsSONo.Checked) 
            {
                MessageBox.Show("Falta Ingresos Mensuales del cliente", "Sujeto Obligado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (Convert.ToDecimal(txtIngresoMensual.nDecValor) == 0  && rbtEsSONo.Checked)
            {
                MessageBox.Show("Los ingresos mensuales no pueden ser iguales a 0", "Sujeto Obligado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            clsDeclaracionJurada declaracion= new clsDeclaracionJurada();

            declaracion.idCli = idCli;
            declaracion.lSujetoObligado = rbtEsSOSi.Checked;
            declaracion.lOficialCumplimiento = rbtCuentaOCSi.Checked;
            declaracion.idActividad = idActividad;
            declaracion.cActividad = cActividad;
            declaracion.idDireccion = idDireccion;
            declaracion.cDireccion = cDireccion;
            declaracion.idUbigeo = idUbigeo;
            declaracion.cDistrito = cDistrito;
            declaracion.cProvincia = cProvincia;
            declaracion.cDepartamento = cDepartamento;
            declaracion.cAnexo = cAnexo;
            declaracion.cOtraOcupacion = txtOtrasOcupaciones.Text;
            declaracion.nIngresosMensuales = txtIngresoMensual.nDecValor;
            declaracion.dFechaReg = clsVarGlobal.dFecSystem;
            declaracion.idUsuReg = clsVarGlobal.User.idUsuario;
            declaracion.idEstado = 1;

            DataTable dtOcupaciones = new DataTable("dtOcupaciones");
            dtOcupaciones.Columns.Add("idOcupacion", typeof(int));
            DataRow drOcupacion;
            foreach (DataRowView item in chklbOcupaciones.CheckedItems)
            {
                drOcupacion = dtOcupaciones.NewRow();
                drOcupacion["idOcupacion"] = (int)item.Row.ItemArray[0];
                dtOcupaciones.Rows.Add(drOcupacion);
            }
            DataSet dsOcupaciones = new DataSet("dsOcupaciones");
            dsOcupaciones.Tables.Add(dtOcupaciones);
            var cOcupaciones = dsOcupaciones.GetXml();
            cndeclaracion.insertaDeclaracionJurada(declaracion, cOcupaciones);

            MessageBox.Show("Se grabaron los datos correctamente", "Sujeto Obligado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnGrabar1.Enabled = false;
            btnBusCliente1.Enabled = false;
            btnImprimir1.Enabled = true;
            btnSalir1.Enabled = false;
            grbBase2.Enabled = false;
            grbBase3.Enabled = false;
            chklbOcupaciones.Enabled = false;
            txtIngresoMensual.Enabled = false;
            txtOtrasOcupaciones.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void limpiarControles()
        {
            conDatCli1.limpiarcontroles();
            txtDireccion.Clear();
            cboActividadEco1.CargarActivEconomica(0);
            rbtCuentaOCNo.Checked = false;
            rbtCuentaOCSi.Checked = false;
            rbtEsSONo.Checked = false;
            rbtEsSOSi.Checked = false;
            chklbOcupaciones.ClearSelected();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {            
            paramlist.Clear();
            //seleteando la ruta del reporte
            string reportpath = configuraReporte();
            frmReporteLocal reporte=new frmReporteLocal(dtslist, reportpath, paramlist);
            reporte.ShowDialog();
            btnCancelar.Enabled = true;
            btnSalir1.Enabled = true;
        }
        private void cargarOcupaciones()
        {
            clsCNOcupacion objOcupacion = new clsCNOcupacion();
            DataTable dtbOcupacion = objOcupacion.ListarOcupacion();
            dtbOcupacion.Rows[0].Delete();
            chklbOcupaciones.DataSource = dtbOcupacion;
            chklbOcupaciones.ValueMember = dtbOcupacion.Columns[0].ToString();
            chklbOcupaciones.DisplayMember = dtbOcupacion.Columns[1].ToString();
        }
        public void seleccionarOcupaciones(int idDeclaracion)
        {
            clsCNOcupacion objOcupacion = new clsCNOcupacion();
            DataTable dtbOcupacion = objOcupacion.ListaOcupacionPorIdDeclaracion(idDeclaracion);
            
            foreach (DataRow item in dtbOcupacion.Rows)
            {
                for (int i = 0; i < chklbOcupaciones.Items.Count; i++)
                {
                    if (((DataRowView)chklbOcupaciones.Items[i])[0].ToString() == item[0].ToString())
                    {
                        chklbOcupaciones.SetItemChecked(i, true);
                    }
                }    
            }
        }

        public void desSelecionOcupaciones()
        {
            for (int i = 0; i < chklbOcupaciones.Items.Count; i++)
            {
                chklbOcupaciones.SetItemChecked(i, false);
            }
        }
        private void rbtEsSONo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtEsSONo.Checked) 
            {
                grbBase3.Enabled            = false;
                rbtCuentaOCNo.Checked       = true;
                chklbOcupaciones.Enabled    = true;
                txtOtrasOcupaciones.Enabled = true;
                txtIngresoMensual.Enabled   = true;
                if (nTipoPersona != 1)
                {
                    chklbOcupaciones.Enabled = false;
                    txtOtrasOcupaciones.Enabled = true;
                }
            }
        }

        private void rbtEsSOSi_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtEsSOSi.Checked)
            {
                grbBase3.Enabled            = true;
                rbtCuentaOCNo.Checked       = false;
                chklbOcupaciones.Enabled    = false;
                txtOtrasOcupaciones.Enabled = false;
                txtIngresoMensual.Enabled   = false;
                desSelecionOcupaciones();
                txtOtrasOcupaciones.Text    = "";
                txtIngresoMensual.Text      = "";
            }
        }
        private string configuraReporte()
        {
            var dtDatDecJurada = cndeclaracion.retDatDecJurSujObli(idCli);
            DataTable dtDatDeclaracionJurada = cndeclaracion.retDatDeclaracionJurada(Convert.ToInt32(dtDatDecJurada.Rows[0]["idDeclaracion"].ToString()));
            //seteando parametros para reporte
            paramlist.Add(new ReportParameter("cRutaLogo", EntityLayer.clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cNombreCortoEmp", clsVarApl.dicVarGen["cNomCortoEmp"], false));

            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dsDeclaracionJurada", dtDatDeclaracionJurada));
            if (rbtEsSOSi.Checked)
            {
                if (nTipoPersona == 1)
                {
                    return "rptDecJurPerNat.rdlc";   
                }
                else
                {
                    return "rptDeclJuradaPerJur.rdlc";
                }
            }
            else
            {
                //agregando un data source
                DataTable dtDataOcupaciones = cndeclaracion.retDatOcupacionesDecla(Convert.ToInt32(dtDatDecJurada.Rows[0]["idDeclaracion"].ToString()));
                dtslist.Add(new ReportDataSource("dsOcupaciones", dtDataOcupaciones));
                return "rptDecJurActividad.rdlc";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            desSelecionOcupaciones();
            conDatCli1.limpiarcontroles();
            cboActividadEco1.SelectedValue = 0;
            txtDireccion.Clear();
            rbtEsSOSi.Checked = false;
            rbtEsSONo.Checked = false;
            rbtCuentaOCSi.Checked = false;
            rbtCuentaOCNo.Checked = false;
            txtIngresoMensual.Clear();
            txtOtrasOcupaciones.Clear();
            grbBase2.Enabled = false;
            grbBase3.Enabled = false;
            txtIngresoMensual.Enabled = false;
            txtOtrasOcupaciones.Enabled = false;
            chklbOcupaciones.Enabled = false;
            btnGrabar1.Enabled = false;
            btnImprimir1.Enabled = false;
            btnBusCliente1.Enabled = true;
            btnBusCliente1.Focus();
        }
    }
}
