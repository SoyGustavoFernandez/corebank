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
using System.IO.Ports;
using GEN.LibreriaOffice;
using GEN.Funciones;
using EntityLayer;
using SER.CapaNegocio;


namespace SER.Presentacion
{
    public partial class frmEnvioMensajesTexto : frmBase
    {
        private string cPuerto;
        clsEnvioMensajeTexto obj ;
        private OpenFileDialog OpenDialog;
        DataTable dtEnvioArchivos;
        BindingSource bSource;
        
        List<clsMensajeTexto> listMensajesEnvio; 
        List<clsMensajeTexto> listNoEnviados;
        List<clsMensajeTexto> listEnviados  ;

        private int nIntentos;
        private int nCuenta;

        private string cTitulo;

        clsCNMensajeTexto cnMensaje;

        Dictionary<string, Dictionary<string, int>> dColumns = new Dictionary<string, Dictionary<string, int>>
            {
                {"cNombres",	new Dictionary<string, int> { {"NOMBRE", 1}}},
                {"nNroCelular",	new Dictionary<string, int> { {"NRO CELULAR", 1}}},
                {"idCli", new Dictionary<string, int> {{"COD CLI", 0}}},
                {"idCuenta", new Dictionary<string, int> { {"NRO CUENTA", 0}}},
            };

        public frmEnvioMensajesTexto()
        {
            InitializeComponent();
            string[]aPorts =  SerialPort.GetPortNames();
            foreach (var item in aPorts)
            {
                cboPuerto.Items.Add(item);
            }
            OpenDialog = new OpenFileDialog();
            this.listNoEnviados = new List<clsMensajeTexto>();
            this.listEnviados = new List<clsMensajeTexto>();
            this.nIntentos = 3;
            this.nCuenta = 0;
            this.cTitulo = "Envio de Mensajes de Texto";
            this.cnMensaje = new clsCNMensajeTexto();
        }

        private void frmEnvioMensajesTexto_Load(object sender, EventArgs e)
        {
            ControlBotones(EventoFormulario.INICIO);
        }

        private void btnEnviar1_Click(object sender, EventArgs e)
        {
            if (!Validar(rbtMasivo.Checked))
            {
                return;
            }
            this.Cursor = Cursors.WaitCursor;

            if (this.EnviaMensajes())
            {
                ActualizarEnvios();
                DataTable dtRes = this.cnMensaje.CNGuardarEnvioMensajeTexto(clsUtils.ListToXml<clsMensajeTexto>(listMensajesEnvio));
                if (dtRes.Rows.Count > 0)
                {
                    List<clsMensajeTexto> lRes = DataTableToList.ConvertTo<clsMensajeTexto>(dtRes) as List<clsMensajeTexto>;
                    //foreach (clsMensajeTexto item in listMensajesEnvio)
                    for (int i = 0; i < listMensajesEnvio.Count; i++)
                    {
                        //foreach (clsMensajeTexto item2 in lRes)
                        for (int j = 0; j < lRes.Count; j++)
                        {
                            if (listMensajesEnvio[i].cNroCelular == lRes[j].cNroCelular)
                            {
                                listMensajesEnvio[i].idMensaje = lRes[j].idMensaje;
                            }
                        }
                    }
                    
                }
                this.dtgEnvio.Refresh();

                if (listMensajesEnvio.Where(x => x.lEnvio == false).ToList().Count > 0)
                {
                    MessageBox.Show("No se han podido enviar los siguientes mensajes \n " + this.DevolverNros(listMensajesEnvio.Where(x => x.lEnvio == false).ToList()), "Envio Mensajes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Se enviaron correctamente ", "Envio Mensajes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
             
            Cursor = Cursors.Default;
        }

        public void ControlBotones(EventoFormulario t)
        {
            switch (t)
            {
                case EventoFormulario.INICIO:// envio masivo
                    rbtMasivo.Checked = true;
                    grbIndividual.Visible = false;
                    btnExporExcel1.Visible = true;
                    break;
                case EventoFormulario.NUEVO: // individual

                    rbtIndividual.Checked = true;
                    grbIndividual.Visible = true;
                    btnExporExcel1.Visible = false;

                    break;
            }
        }

        public bool EnviaMensajes()
        {
            this.listNoEnviados = new List<clsMensajeTexto>();
            this.nCuenta = 0;

            this.iniciarBarra();
            
            //foreach (clsMensajeTexto item in listMensajesEnvio)
            for (int i = 0; i < listMensajesEnvio.Count; i++)
            {
                if (!listMensajesEnvio[i].lEnvio)
                {
                    clsMensajeTexto oMensaje = new clsMensajeTexto();
                    oMensaje.nNroCelular = listMensajesEnvio[i].nNroCelular;
                    oMensaje.cMensaje = txtMensaje.Text.Replace("&", listMensajesEnvio[i].cNombres);
                    oMensaje.idUsuarioRegistra = clsVarGlobal.User.idUsuario;
                    oMensaje.dFechaRegistro = clsVarGlobal.dFecSystem;
                    oMensaje.idUsuarioEnvio = clsVarGlobal.User.idUsuario;
                    oMensaje.dFechaEnvio = clsVarGlobal.dFecSystem;
                    oMensaje.idTipoMensaje = Convert.ToInt32(cboTipoMensaje1.SelectedValue);

                    obj.iniciarCuenta();
                    oMensaje = obj.EnviarMensaje(oMensaje);

                    listMensajesEnvio[i].idMensaje = oMensaje.idMensaje;
                    listMensajesEnvio[i].nNroCelular = oMensaje.nNroCelular;
                    listMensajesEnvio[i].idUsuarioRegistra = oMensaje.idUsuarioRegistra;
                    listMensajesEnvio[i].dFechaRegistro = oMensaje.dFechaRegistro;
                    listMensajesEnvio[i].dFechaEnvio = oMensaje.dFechaEnvio;
                    listMensajesEnvio[i].idUsuarioEnvio = oMensaje.idUsuarioEnvio;
                    listMensajesEnvio[i].idTipoMensaje = oMensaje.idTipoMensaje;
                    listMensajesEnvio[i].cMsgResultado = oMensaje.cMsgResultado;
                    listMensajesEnvio[i].cResultado = oMensaje.cResultado;
                    listMensajesEnvio[i].cMensaje = oMensaje.cMensaje;

                    if ((i + 1) % 100 == 0)
                    {
                        System.Threading.Thread.Sleep(1000 * 4);
                    }

                    if (oMensaje.idEstadoEnvio == EstadoEnvioSMS.ENVIADO)
                    {
                        listMensajesEnvio[i].lEnvio = true;
                    }
                }
            }

            //if (listMensajesEnvio.Where(x => x.lEnvio == false).ToList().Count > 0)
            //{
            //    if (this.nCuenta < this.nIntentos)
            //    {
            //        this.nCuenta++;
            //        return this.EnviaMensajes();
            //    }
            //    else
            //    {
            //        return true;
            //    }
            //}
            //else
            //{
                return true;
            //}

            
        }

        private void btnMiniLogin1_Click(object sender, EventArgs e)
        {
            clsConexion oConexion = new clsConexion();
            this.cPuerto = cboPuerto.Text;
            obj = new clsEnvioMensajeTexto(cPuerto);
            oConexion = obj.Conectar();
            MessageBox.Show(oConexion.cMensaje);
        }

        private void btnMiniCancelEst1_Click(object sender, EventArgs e)
        {
            clsConexion oConexion = new clsConexion();
            oConexion = obj.Desconectar();
            MessageBox.Show(oConexion.cMensaje);
        }

        private void btnExporExcel1_Click(object sender, EventArgs e)
        {
            cargar();
            ActualizarEnvios();
        }

        private void cargar()
        {
            OpenDialog.Filter = "Hojas de Excel(*.xls)|*.xls";
            OpenDialog.ShowDialog();
            //txtPath.Text = OpenDialog.FileName;

            if (String.IsNullOrEmpty(OpenDialog.FileName))
            {
                return;
            }

            try
            {
                ExcelHandler ex = new ExcelHandler();
                dtEnvioArchivos = ex.ImportExcelToDataTable(OpenDialog.FileName);
                dtEnvioArchivos.Columns.Add("cDetalleError", typeof(string));
                dtEnvioArchivos.Columns.Add("lEnvio", typeof(bool));

                dtEnvioArchivos = renombrarColumnas(dtEnvioArchivos);
                if (ValidarHoja(dtEnvioArchivos))
                {
                    // Verificar formato del excel 
                    DataSet ds = SepararFilasValidas(dtEnvioArchivos);

                    DataTable dt = ds.Tables["dtCorrecto"];
                    listMensajesEnvio = DataTableToList.ConvertTo<clsMensajeTexto>(dt) as List<clsMensajeTexto>;
                    bSource = new BindingSource();
                    bSource.DataSource = listMensajesEnvio;

                    dtgEnvio.DataSource = bSource;

                    formatogrid(dtgEnvio, 1);

                    //dtgClientesPepError.DataSource = ds.Tables["dtError"];
                    //formatogrid(dtgClientesPepError, 2);
                    ////contando registros
                    //lblNroRegError.Text = dtgClientesPepError.RowCount.ToString() + " fila(s)";
                    //lblNroRegBien.Text = dtgClientesCargaPep.RowCount.ToString() + " fila(s)";

                    //btnGrabar1.Enabled = false;
                    //if (dtgClientesCargaPep.Rows.Count > 0)
                    //{
                    //    btnGrabar1.Enabled = true;
                    //    btnNuevo1.Enabled = false;
                    //    btnBusqueda1.Enabled = false;
                    //}
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("No se ha podido cargar la hoja de Excel.", "Carga de Clientes PEP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private DataTable renombrarColumnas(DataTable dt)
        {
            foreach (KeyValuePair<string, Dictionary<string, int>> item in dColumns)
            {
                // dt.Columns[item.Value[0]].ColumnName = item.Key;
                foreach (KeyValuePair<string, int> item2 in item.Value)
                {
                    dt.Columns[item2.Key].ColumnName = item.Key;
                }


            }
            return dt;
        }

        private bool ValidarHoja(DataTable dt)
        {
            string cColumnasFaltantes = "";
            bool lValido = true;
            foreach (KeyValuePair<string, Dictionary<string, int>> item in dColumns)
            {
                if (!dt.Columns.Contains(item.Key))
                {
                    foreach (KeyValuePair<string, int> item2 in item.Value)
                    {
                        cColumnasFaltantes += "\t" + item2.Key + "\n";
                        lValido = false;
                    }

                }
            }

            if (!lValido)
            {
                MessageBox.Show("La tabla no tiene las siguientes columnas:" + cColumnasFaltantes + " ", "Carga de Clientes PEP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return lValido;
        }

        private DataSet SepararFilasValidas(DataTable dt)
        {
            DataSet ds = new DataSet("dsReturn");
            DataTable dtCorrecto = new DataTable("dtCorrecto");
            DataTable dtError = new DataTable("dtError");
            dtCorrecto = dt.Clone();
            dtError = dt.Clone();
            dtCorrecto.TableName = "dtCorrecto";
            dtError.TableName = "dtError";
            dtCorrecto.Clear();
            dtError.Clear();

            foreach (DataRow item in dt.Rows)
            {
                if (!ValidarCamposObligatorios(item))
                {
                    dtError.ImportRow(item);
                }
                else
                {
                    dtCorrecto.ImportRow(item);
                }
            }
            ds.Tables.Add(dtCorrecto);
            ds.Tables.Add(dtError);
            return ds;
        }

        private Boolean ValidarCamposObligatorios(DataRow dr)
        {
            int nIndice = 0;
            bool estado = true;
            string cError = "";
            foreach (KeyValuePair<string, Dictionary<string, int>> item in dColumns)
            {
                foreach (KeyValuePair<string, int> item2 in item.Value)
                {
                    if (item2.Value == 1) // valida campo obligatorio
                    {
                        if (String.IsNullOrEmpty(dr[item.Key].ToString()))
                        {
                            if (String.IsNullOrEmpty(cError))
                            {
                                cError = "Campos obligatorios: ";
                            }

                            cError += item.Key + "; ";
                            estado = false;
                        }
                    }
                }
            }
            dr["cDetalleError"] = cError;
            return estado;
        }

        private void formatogrid(DataGridView dtg, int error)
        {
            foreach (KeyValuePair<string, Dictionary<string, int>> item in dColumns)
            {
                foreach (KeyValuePair<string, int> item2 in item.Value)
                {
                    dtg.Columns[item.Key].HeaderText = item2.Key; // item.Value;    
                    dtg.Columns[item.Key].Visible = false;
                    if (item2.Value == 1) // si es obligatorio
                    {
                        dtg.Columns[item.Key].DefaultCellStyle.BackColor = Color.LightBlue;
                    }
                }
            }

            foreach (DataGridViewColumn item in dtg.Columns)
            {
                item.Visible = false;
            }
            //dtg.Columns["dFecIni"].DefaultCellStyle.Format = "d";
            //dtg.Columns["dFecFin"].DefaultCellStyle.Format = "d";
            //dtg.Columns["dFechaNac"].DefaultCellStyle.Format = "d";
            dtg.Columns["lEnvio"].HeaderText = "ENVIADO";

            dtg.Columns["cNombres"].Visible = true;
            dtg.Columns["nNroCelular"].Visible = true;
            dtg.Columns["idCli"].Visible = true;
            dtg.Columns["idCuenta"].Visible = true;
            dtg.Columns["lEnvio"].Visible = true;
           
            dtg.Columns["cDetalleError"].Visible = (error == 1) ? false : true;
        }

        private string DevolverNros(List<clsMensajeTexto> list)
        {
            string cReturn = "";
            foreach (clsMensajeTexto item in list)
            {
                cReturn += " - " + item.cNombres + " : " + item.cNroCelular + "\n";
            }

            return cReturn;
        }

        private void btnEnvioIndividual_Click(object sender, EventArgs e)
        {
            if (!Validar(rbtMasivo.Checked))
            {
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            clsMensajeTexto oMensaje = new clsMensajeTexto();
            oMensaje.nNroCelular = Convert.ToDouble(txtNroCel.Text);
            oMensaje.cMensaje = txtMensaje.Text;
            oMensaje.idUsuarioRegistra = clsVarGlobal.User.idUsuario;
            oMensaje.dFechaRegistro = clsVarGlobal.dFecSystem;
            oMensaje.idUsuarioEnvio = clsVarGlobal.User.idUsuario;
            oMensaje.dFechaEnvio = clsVarGlobal.dFecSystem;
            oMensaje.idTipoMensaje = Convert.ToInt32(cboTipoMensaje1.SelectedValue);

            oMensaje = obj.EnviarMensaje(oMensaje);
            this.Cursor = Cursors.Default;
        }

        private bool Validar(bool lMasivo = true)
        {
            bool lBool = true;
            
            if (lMasivo)
            {
                DialogResult dRes = MessageBox.Show("Se van a enviar el mensajes masivo. \n ¿Desea Continuar?", this.cTitulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dRes == DialogResult.No)
                {
                    lBool = false ;
                }
            }

            if(string.IsNullOrEmpty(txtMensaje.Text))
            {
                MessageBox.Show("El mensaje esta vacio. Registre un mensaje", this.cTitulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                lBool = false;
            }

            if (!lMasivo)
            {
                if (string.IsNullOrEmpty(txtNroCel.Text))
                {
                    MessageBox.Show("Ingrese un número de celular", this.cTitulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    lBool = false;
                }
            }

            return lBool;
        }

        private void rbtMasivo_CheckedChanged(object sender, EventArgs e)
        {
            rbtMasivo.CheckedChanged -= rbtMasivo_CheckedChanged;
            ControlBotones(EventoFormulario.INICIO);
            rbtMasivo.CheckedChanged += rbtMasivo_CheckedChanged;
        }

        private void rbtBase2_CheckedChanged(object sender, EventArgs e)
        {
            rbtIndividual.CheckedChanged -= rbtBase2_CheckedChanged;
            ControlBotones(EventoFormulario.NUEVO);
            rbtIndividual.CheckedChanged += rbtBase2_CheckedChanged;
        }

        private void tTimer_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
            lblBarMessage.Text = progressBar1.Value.ToString() + "% Completado";
            progressBar1.Value++;
            if (progressBar1.Value == progressBar1.Maximum)
            {
                tTimer.Stop();
                grbBar.Visible = false;
            }
        }

        private void iniciarBarra()
        {
            /*this.progressBar1.Value = 0;
            progressBar1.Maximum = listMensajesEnvio.Where(x => x.lEnvio == false).ToList().Count;
            tTimer.Interval = 250;
            tTimer.Start();
             * */
        }
        private void ActualizarEnvios()
        {
            txtEnviados.Text = listMensajesEnvio.Where(x => x.lEnvio == true).ToList().Count.ToString();
            txtNoEnviados.Text = listMensajesEnvio.Where(x => x.lEnvio == false).ToList().Count.ToString();
            txtTOTAL.Text = listMensajesEnvio.Count.ToString();
        }

    }
}
