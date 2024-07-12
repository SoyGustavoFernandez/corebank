using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using CRE.CapaNegocio;
using EntityLayer;

namespace CRE.Presentacion
{
    public partial class frmCapturarAJudiciales : frmBase
    {
        clsCNCredito Credito = new clsCNCredito();
        DataTable dtSolicitudesAprobadasCaptura = new DataTable("dtSolicitudesAprobadasCaptura");
        Boolean lAplicarATodos = false;
        public int nfilaseleccionada = 0;

        public frmCapturarAJudiciales()
        {
            InitializeComponent();
            rbtTasaInteresPactada.Checked = true;
            rbtTasaMoraPactada.Checked = true;
        }

        private void LimpiarDatos()
        {
            //Grid de cuentas del cliente
            this.dtgCuentas.DataSource = null;

            //botones
            this.btnGrabar.Enabled = false;
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            LimpiarDatos();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (ValidarRequisitosParaGrabar())
            {
                return;
            }

            DataSet ds = new DataSet("dsCapturaAJudiciales");
            //Seleccionar sólo las cuentas que tienen check (que se van a capturar)
            DataTable dtCuentas =  ArmarTablaCuentasSeleccionadas(dtSolicitudesAprobadasCaptura);

            int nIdcuenta=0;
            int nIdplanpagos=0;
            decimal nNuevaTasaInteres = 0;
            decimal nNuevaTasaMoratoria = 0;
            int nIdSolAproba=0;
            //Enviar uno por uno las cuentas para su captura
            for (int i = 0; i < dtCuentas.Rows.Count; i++)
            {
                nIdcuenta = Convert.ToInt32(dtCuentas.Rows[i]["idCuenta"]); 
                nIdplanpagos = Convert.ToInt32(dtCuentas.Rows[i]["idPlanPagos"]);
                nNuevaTasaInteres = Convert.ToDecimal(dtCuentas.Rows[i]["nNuevaTasaInteres"]);
                nNuevaTasaMoratoria = Convert.ToDecimal(dtCuentas.Rows[i]["nNuevaTasaMoratoria"]);
                nIdSolAproba = Convert.ToInt32(dtCuentas.Rows[i]["idSolAproba"]);
                DataTable dtRespuesta = Credito.InsCapturaAJudiciales(nIdcuenta, nIdplanpagos, nNuevaTasaInteres, nNuevaTasaMoratoria, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, nIdSolAproba);

                /*========================================================================================
                 * REGISTRO DE RASTREO
                 ========================================================================================*/

                this.registrarRastreo(Convert.ToInt32(dtCuentas.Rows[i]["idCli"]), nIdcuenta, "Captura de crédito a judiciales completada", btnGrabar);

                /*========================================================================================
                 * FIN DEL REGISTRO DE RASTREO
                 ========================================================================================*/
            }
            
            MessageBox.Show("La captura a Judiciales se ha realizado con éxito", "Captura a Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Information);

            



            //Quitar todas las cuentas
            for (int i = 0; i < dtSolicitudesAprobadasCaptura.Rows.Count; i++)
            {
                dtSolicitudesAprobadasCaptura.Rows.RemoveAt(0);
            }

            //Recargar la lsiat de cuentas Aprobadas para Captura
            ListarCuentas();
        }

        private DataTable ArmarTablaCuentasSeleccionadas(DataTable dtTablaCuentas)
        {   //Crear la estructura
            DataTable dtCuentasSeleccionadas = new DataTable("TablaCuentas");

            dtCuentasSeleccionadas.Columns.Add("idCuenta", typeof(int));
            dtCuentasSeleccionadas.Columns.Add("idPlanPagos", typeof(int));
            dtCuentasSeleccionadas.Columns.Add("nNuevaTasaInteres", typeof(decimal));
            dtCuentasSeleccionadas.Columns.Add("nNuevaTasaMoratoria", typeof(decimal));
            dtCuentasSeleccionadas.Columns.Add("idSolAproba", typeof(int));
            dtCuentasSeleccionadas.Columns.Add("idCli", typeof(int));

            for (int i = 0; i < dtTablaCuentas.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtTablaCuentas.Rows[i]["lAplica"])==true)
                {
                    DataRow dr = dtCuentasSeleccionadas.NewRow();

                    dr["idCuenta"] = dtTablaCuentas.Rows[i]["idCuenta"];
                    dr["idPlanPagos"] = dtTablaCuentas.Rows[i]["idPlanPagos"];
                    dr["idCli"] = dtTablaCuentas.Rows[i]["idCli"];

                    if (Convert.ToBoolean(dtTablaCuentas.Rows[i]["lUsarNuevaTasaInteres"]) == true)
                    {
                        dr["nNuevaTasaInteres"] = dtTablaCuentas.Rows[i]["nNuevaTasaInteres"];
                    }
                    if (Convert.ToBoolean(dtTablaCuentas.Rows[i]["lUsarNuevaTasaInteres"]) == false)
                    {
                        dr["nNuevaTasaInteres"] = dtTablaCuentas.Rows[i]["nTasaCompensatoria"];
                    }

                    if (Convert.ToBoolean(dtTablaCuentas.Rows[i]["lUsarNuevaTasaMoratoria"]) == true)
                    {
                        dr["nNuevaTasaMoratoria"] = dtTablaCuentas.Rows[i]["nNuevaTasaMoratoria"];
                    }
                    if (Convert.ToBoolean(dtTablaCuentas.Rows[i]["lUsarNuevaTasaMoratoria"]) == false)
                    {
                        dr["nNuevaTasaMoratoria"] = dtTablaCuentas.Rows[i]["nTasaMoratoria"];
                    }
                    dr["idSolAproba"] = dtTablaCuentas.Rows[i]["idSolAproba"];
                    dtCuentasSeleccionadas.Rows.Add(dr);
                }
            }
            return dtCuentasSeleccionadas;
        }

        private Boolean ValidarRequisitosParaGrabar()
        {
            Boolean lExistenErrores = false;

            StringBuilder sbErrorTasasInteres = new StringBuilder();
            StringBuilder sbErrorTasasInteresMoratoria = new StringBuilder();

            //Validación para NUEVA TASA INETERÉS
            for (int i = 0; i < dtSolicitudesAprobadasCaptura.Rows.Count; i++)
            {
                //Si se va usar una nueva tasa de interes verificar que sea diferente de 0
                if (Convert.ToBoolean(dtSolicitudesAprobadasCaptura.Rows[i]["lUsarNuevaTasaInteres"])==true)
                {
                    if (dtSolicitudesAprobadasCaptura.Rows[i]["nNuevaTasaInteres"].ToString().Trim().Equals(""))
                    {
                        dtSolicitudesAprobadasCaptura.Rows[i]["nNuevaTasaInteres"] = 0;
                    }
                    if (Convert.ToDecimal(dtSolicitudesAprobadasCaptura.Rows[i]["nNuevaTasaInteres"]) == 0)
                    {
                        sbErrorTasasInteres.Append("- " + dtSolicitudesAprobadasCaptura.Rows[i]["cNroCuenta"].ToString() + Environment.NewLine);
                        lExistenErrores = true;
                    }
                }

                //Si se va usar una nueva tasa de interes moratoria verificar que sea diferente de 0
                if (Convert.ToBoolean(dtSolicitudesAprobadasCaptura.Rows[i]["lUsarNuevaTasaMoratoria"]) == true)
                {
                    if (dtSolicitudesAprobadasCaptura.Rows[i]["nNuevaTasaMoratoria"].ToString().Trim().Equals(""))
                    {
                        dtSolicitudesAprobadasCaptura.Rows[i]["nNuevaTasaMoratoria"] = 0;
                    }
                    if (Convert.ToDecimal(dtSolicitudesAprobadasCaptura.Rows[i]["nNuevaTasaMoratoria"]) == 0)
                    {
                        sbErrorTasasInteresMoratoria.Append("- " + dtSolicitudesAprobadasCaptura.Rows[i]["cNroCuenta"].ToString() + Environment.NewLine);
                        lExistenErrores = true;
                    }
                }
            }

            if (lExistenErrores)
            {
                String cadena = "";
                String cErroresTasasInteres = sbErrorTasasInteres.ToString();
                String cErroresTasasInteresMoratoria = sbErrorTasasInteresMoratoria.ToString();
                if (cErroresTasasInteres.Trim().Equals("")==false)
                {
                    cadena = cadena + "Las cuentas :" + Environment.NewLine + cErroresTasasInteres + "Deben tener TASA ESPECIAL DE INTERÉS JUDICIAL diferente de 0";
                }
                if (cErroresTasasInteresMoratoria.Trim().Equals("")==false)
                {
                    cadena = cadena +Environment.NewLine+ "Las cuentas :" + Environment.NewLine + cErroresTasasInteresMoratoria + "Deben tener TASA ESPECIAL DE INTERÉS MORATORIA JUDICIAL diferente de 0";
                }

                MessageBox.Show(cadena, "Captura a Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTasaMoraPactada.Focus();
                return lExistenErrores;
            }
         
            Boolean lExistenCuentasSeleccionadas = false;
            //Verificar que existan cuentas seleccionadas para capturar a Judiciales
            for (int i = 0; i < dtSolicitudesAprobadasCaptura.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtSolicitudesAprobadasCaptura.Rows[i]["lAplica"])==true)
                {
                    lExistenCuentasSeleccionadas = true;
                    break;
                }
            }
            if (lExistenCuentasSeleccionadas==false)
            {
                MessageBox.Show("No ha seleccionado ninguna cuenta para CAPTURAR A JUDICIALES", "Captura a Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }

            if (dtSolicitudesAprobadasCaptura.AsEnumerable().Any(x => x.Field<bool>("lAplica") && x.Field<decimal>("nMonSalIntFec") < 0))
            {
                MessageBox.Show("No se pueden capturar cuentas con intereses pagados por adelantado.", "Captura a Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }

            return lExistenErrores;
        }

        private void frmCapturarAJudiciales_Load(object sender, EventArgs e)
        {
            ListarCuentas();
        }

        private void ListarCuentas()
        {
            //Recuperar Cuentas Aprobadas para captura a JUDICIALES (La cuentas se agrupan por solicitudes)
            dtSolicitudesAprobadasCaptura = Credito.ListarSolicitudesDeCapturaAprobadas();

            if (dtSolicitudesAprobadasCaptura.Rows.Count==0)
            {
                //MessageBox.Show("No se tiene ninguna cuenta Aprobada para Capturar a Judiciales", "Captura a Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnGrabar.Enabled = false;
                return;
            }
            
            //Dar permisos de Edición
            foreach (DataColumn dt in dtSolicitudesAprobadasCaptura.Columns)
            {
                if (dt.ColumnName.Equals("lAplica") || dt.ColumnName.Equals("lUsarNuevaTasaInteres") || dt.ColumnName.Equals("lUsarNuevaTasaMoratoria") || dt.ColumnName.Equals("nNuevaTasaInteres") || dt.ColumnName.Equals("nNuevaTasaMoratoria"))
                {
                    dt.ReadOnly = false;
                }
                else
                {
                    dt.ReadOnly = true;
                }
            }
            
            dtgCuentas.DataSource = dtSolicitudesAprobadasCaptura;
            DarFormatoGridCuentas();
            nfilaseleccionada = 0;
            CargarDatosDeCuenta(nfilaseleccionada);
            dtgCuentas.ReadOnly=false;
            //Dar permisos de Edicion al Grid de cuentas
            for (int i = 0; i < dtgCuentas.ColumnCount; i++)
            {
                if (dtgCuentas.Columns[i].Name.Equals("lAplica"))
                {
                    dtgCuentas.Columns[i].ReadOnly=false;
                }
                else
                {
                    dtgCuentas.Columns[i].ReadOnly = true;
                }
            }

            //Asignar DataBindings a pra las nuevas TASAS: Interes - Moratoria
            //TASA INTERES
            if (txtTasaInteresJudicial.DataBindings.Count == 0)
            {
                txtTasaInteresJudicial.DataBindings.Add("Text", dtSolicitudesAprobadasCaptura, "nNuevaTasaInteres");
            }
            else
            {
                txtTasaInteresJudicial.DataBindings.Remove(txtTasaInteresJudicial.DataBindings["Text"]);
            }
            txtTasaInteresJudicial.Enabled = false;

            //TASA MORATORIA
            if (txtTasaMoraJudicial.DataBindings.Count == 0)
            {
                txtTasaMoraJudicial.DataBindings.Add("Text", dtSolicitudesAprobadasCaptura, "nNuevaTasaMoratoria");
            }
            else
            {
                txtTasaMoraJudicial.DataBindings.Remove(txtTasaMoraJudicial.DataBindings["Text"]);
            }
            txtTasaMoraJudicial.Enabled = false;
        }

        private void DarFormatoGridCuentas()
        {
            dtgCuentas.Columns["idSolAproba"].Visible = false;
            dtgCuentas.Columns["lAplica"].HeaderText = "Aplicar";
            dtgCuentas.Columns["idCuenta"].Visible = false;
            dtgCuentas.Columns["cNroCuenta"].HeaderText = "Número de Cuenta";
            dtgCuentas.Columns["idCli"].Visible = false;
            dtgCuentas.Columns["cNombre"].HeaderText = "Cliente";
            dtgCuentas.Columns["idPlanPagos"].Visible = false;
            dtgCuentas.Columns["idMoneda"].Visible = false;
            dtgCuentas.Columns["cMoneda"].Visible = false;
            dtgCuentas.Columns["IdProducto"].Visible = false;
            dtgCuentas.Columns["cProducto"].HeaderText = "Producto";

            dtgCuentas.Columns["nMonSalCapital"].Visible = false;
            dtgCuentas.Columns["nMonSalInteres"].Visible = false;
            dtgCuentas.Columns["nMonSalMora"].Visible = false;
            dtgCuentas.Columns["nMonSalOtros"].Visible = false;

            dtgCuentas.Columns["nTasaCompensatoria"].Visible = false;
            dtgCuentas.Columns["nTasaMoratoria"].Visible = false;
            dtgCuentas.Columns["nAtraso"].Visible = false;
            dtgCuentas.Columns["cEstado"].Visible = false;

            dtgCuentas.Columns["nNuevaTasaInteres"].Visible = false;
            dtgCuentas.Columns["nNuevaTasaMoratoria"].Visible = false;

            dtgCuentas.Columns["lUsarNuevaTasaInteres"].Visible = false;
            dtgCuentas.Columns["lUsarNuevaTasaMoratoria"].Visible = false;

            dtgCuentas.Columns["cNombreAnalista"].Visible = false;
            //dar estilo
            dtgCuentas.Columns["lAplica"].Width = 45;
            dtgCuentas.Columns["cNroCuenta"].Width = 125;
            dtgCuentas.Columns["cNombre"].Width = 165;             
        }

        private void CargarDatosDeCuenta(int nfilaseleccionada)
        {
            //Grupo Detalles de Crédito
            txtSaldoCapital.Text = dtSolicitudesAprobadasCaptura.Rows[nfilaseleccionada]["nMonSalCapital"].ToString();
            txtSaldoInteres.Text = dtSolicitudesAprobadasCaptura.Rows[nfilaseleccionada]["nMonSalIntFec"].ToString();
            txtSaldoMora.Text = dtSolicitudesAprobadasCaptura.Rows[nfilaseleccionada]["nMonSalMora"].ToString();
            txtSaldoOtros.Text = dtSolicitudesAprobadasCaptura.Rows[nfilaseleccionada]["nMonSalOtros"].ToString();
            txtTotalDeuda.Text = (Convert.ToDecimal(txtSaldoCapital.Text) + Convert.ToDecimal(txtSaldoInteres.Text) + Convert.ToDecimal(txtSaldoMora.Text) + Convert.ToDecimal(txtSaldoOtros.Text)).ToString();

            //Grupo Otros
            txtMoneda.Text = dtSolicitudesAprobadasCaptura.Rows[nfilaseleccionada]["cMoneda"].ToString();
            txtTasaInteres.Text = dtSolicitudesAprobadasCaptura.Rows[nfilaseleccionada]["nTasaCompensatoria"].ToString();
            txtTasaMoratoria.Text = dtSolicitudesAprobadasCaptura.Rows[nfilaseleccionada]["nTasaMoratoria"].ToString();
            txtDiasAtraso.Text = dtSolicitudesAprobadasCaptura.Rows[nfilaseleccionada]["nAtraso"].ToString();
            txtEstadoCredito.Text = dtSolicitudesAprobadasCaptura.Rows[nfilaseleccionada]["cEstado"].ToString();
            txtAnalista.Text = dtSolicitudesAprobadasCaptura.Rows[nfilaseleccionada]["cNombreAnalista"].ToString();

            txtTasaInteresPactada.Text = dtSolicitudesAprobadasCaptura.Rows[nfilaseleccionada]["nTasaCompensatoria"].ToString();
            txtTasaMoraPactada.Text = dtSolicitudesAprobadasCaptura.Rows[nfilaseleccionada]["nTasaMoratoria"].ToString();
          
            //Dar estilo
            txtSaldoCapital.TextAlign = HorizontalAlignment.Right;
            txtSaldoInteres.TextAlign = HorizontalAlignment.Right;
            txtSaldoMora.TextAlign = HorizontalAlignment.Right;
            txtSaldoOtros.TextAlign = HorizontalAlignment.Right;
            txtTotalDeuda.TextAlign = HorizontalAlignment.Right;

            txtMoneda.TextAlign = HorizontalAlignment.Right;
            txtTasaInteres.TextAlign = HorizontalAlignment.Right;
            txtTasaMoratoria.TextAlign = HorizontalAlignment.Right;
            txtDiasAtraso.TextAlign = HorizontalAlignment.Right;
            txtEstadoCredito.TextAlign = HorizontalAlignment.Right;
            txtAnalista.TextAlign = HorizontalAlignment.Right;

            txtTasaInteresPactada.TextAlign = HorizontalAlignment.Right;
            txtTasaInteresJudicial.TextAlign = HorizontalAlignment.Right;

            txtTasaMoraPactada.TextAlign = HorizontalAlignment.Right;
            txtTasaMoraJudicial.TextAlign = HorizontalAlignment.Right;
            
            //Seleccionar los RadioButtons de acuerdo al uso o no de las Tasas Nuevas (Interes y Moratoria)
            if (Convert.ToBoolean(dtSolicitudesAprobadasCaptura.Rows[nfilaseleccionada]["lUsarNuevaTasaInteres"]) == true)
            {
                rbtTasaInteresJudicial.Checked = true;
                //Simular evento change
                rbtTasaInteresJudicial.Checked = false;
                rbtTasaInteresJudicial.Checked = true;
            }
            if (Convert.ToBoolean(dtSolicitudesAprobadasCaptura.Rows[nfilaseleccionada]["lUsarNuevaTasaInteres"]) == false)
            {
                rbtTasaInteresPactada.Checked = true;
                //Simular evento change
                rbtTasaInteresPactada.Checked = false;
                rbtTasaInteresPactada.Checked = true;
            }
            
            if (Convert.ToBoolean(dtSolicitudesAprobadasCaptura.Rows[nfilaseleccionada]["lUsarNuevaTasaMoratoria"]) == true)
            {        
                rbtTasaMoraJudicial.Checked = true;
                //Simular evento change
                rbtTasaMoraJudicial.Checked = false;
                rbtTasaMoraJudicial.Checked = true;
            }
            if (Convert.ToBoolean(dtSolicitudesAprobadasCaptura.Rows[nfilaseleccionada]["lUsarNuevaTasaMoratoria"]) == false)
            {
                rbtTasaMoraPactada.Checked = true;
                //Simular evento change
                rbtTasaMoraPactada.Checked = false;
                rbtTasaMoraPactada.Checked = true;
            }
        }

        private void chcSeleccionarTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (dtSolicitudesAprobadasCaptura.Rows.Count > 0)
            {
                if (lAplicarATodos == false)
                {
                    for (int i = 0; i < dtSolicitudesAprobadasCaptura.Rows.Count; i++)
                    {
                        dtSolicitudesAprobadasCaptura.Rows[i]["lAplica"] = true;
                    }
                    lAplicarATodos = true;
                }
                else
                {
                    for (int i = 0; i < dtSolicitudesAprobadasCaptura.Rows.Count; i++)
                    {
                        dtSolicitudesAprobadasCaptura.Rows[i]["lAplica"] = false;
                    }
                    lAplicarATodos = false;
                }
            }
        }

        private void rbtTasaInteresPactada_CheckedChanged(object sender, EventArgs e)
        {
            if (dtSolicitudesAprobadasCaptura.Rows.Count > 0)
            {
                if (rbtTasaInteresPactada.Checked == false)
                {
                    txtTasaInteresJudicial.Enabled = true;
                    dtSolicitudesAprobadasCaptura.Rows[nfilaseleccionada]["lUsarNuevaTasaInteres"] = true;
                }
                else
                {
                    txtTasaInteresJudicial.Enabled = false;
                    this.dtSolicitudesAprobadasCaptura.Rows[nfilaseleccionada]["lUsarNuevaTasaInteres"] = false;
                }
            }
        }

        private void rbtTasaMoraPactada_CheckedChanged(object sender, EventArgs e)
        {
            if (dtSolicitudesAprobadasCaptura.Rows.Count > 0)
            {
                if (rbtTasaMoraPactada.Checked == false)// va pasar de estado no check a Check
                {
                    txtTasaMoraJudicial.Enabled = true;
                    this.dtSolicitudesAprobadasCaptura.Rows[nfilaseleccionada]["lUsarNuevaTasaMoratoria"] = true;
                }
                else
                {
                    txtTasaMoraJudicial.Enabled = false;
                    this.dtSolicitudesAprobadasCaptura.Rows[nfilaseleccionada]["lUsarNuevaTasaMoratoria"] = false;
                }
            }
        }

        private void dtgCuentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtSolicitudesAprobadasCaptura.Rows.Count > 0)
            {
                nfilaseleccionada = Convert.ToInt32(dtgCuentas.CurrentRow.Index);
                CargarDatosDeCuenta(nfilaseleccionada);
            }
        }

        //Si se selecciona una cuenta, se tiene que seleccionar las demás cuentas que pertenecen a la misma SOLICITUD DE CAPTURA que se aprobó
        //similar, si se deselecciona una cuenta,se tiene que deseleccionar las demás cuentas que pertenecen a la misma SOLICITUD DE CAPTURA que se aprobó  
        private void SeleccionarTodasCuentasDeSolicitud(Int32 nfilaseleccionada)
        {
            Boolean lEstadoAplica= Convert.ToBoolean(dtSolicitudesAprobadasCaptura.Rows[nfilaseleccionada]["lAplica"]);

            for (int i = 0; i < dtSolicitudesAprobadasCaptura.Rows.Count; i++)
            {
                if (Convert.ToInt32(dtSolicitudesAprobadasCaptura.Rows[i]["idSolAproba"])==Convert.ToInt32(dtSolicitudesAprobadasCaptura.Rows[nfilaseleccionada]["idSolAproba"]))
                {
                    if (lEstadoAplica == true)//Va pasar de seleccionado a desseleccionado
                    {
                        dtSolicitudesAprobadasCaptura.Rows[i]["lAplica"] = false;
                    }
                    else//Va pasar de desseleccionado a seleccionado
                    {
                        dtSolicitudesAprobadasCaptura.Rows[i]["lAplica"] = true;
                    }
                }
            }
        }

        private void dtgCuentas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)//Tecla Flecha Abajo
            {
                nfilaseleccionada = Convert.ToInt32(this.dtgCuentas.CurrentRow.Index);

                if (nfilaseleccionada < dtgCuentas.Rows.Count)
                {
                    nfilaseleccionada = nfilaseleccionada + 1;
                    if (nfilaseleccionada < dtgCuentas.Rows.Count)
                    {
                        CargarDatosDeCuenta(nfilaseleccionada);
                        return;
                    }
                }
            }
            if (e.KeyCode == Keys.Up)//Tecla Flecha Arriba
            {
                nfilaseleccionada = Convert.ToInt32(this.dtgCuentas.CurrentRow.Index);

                if (nfilaseleccionada != 0)
                {
                    nfilaseleccionada = nfilaseleccionada - 1;
                    CargarDatosDeCuenta(nfilaseleccionada);
                    return;
                }
                else
                {
                    CargarDatosDeCuenta(nfilaseleccionada);
                    return;
                }
            }
        }

        private void dtgCuentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtSolicitudesAprobadasCaptura.Rows.Count > 0)
            {
                if (dtgCuentas.CurrentCell.OwningColumn.Name.Equals("lAplica"))
                {
                    SeleccionarTodasCuentasDeSolicitud(nfilaseleccionada);
                }
            }
        }

        private void dtgCuentas_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtSolicitudesAprobadasCaptura.Rows.Count > 0)
            {
                if (Convert.ToBoolean(dtSolicitudesAprobadasCaptura.Rows[nfilaseleccionada]["lAplica"])==true)
                {
                    dtSolicitudesAprobadasCaptura.Rows[nfilaseleccionada]["lAplica"] = true;
                }
                else
                {
                    dtSolicitudesAprobadasCaptura.Rows[nfilaseleccionada]["lAplica"] = false;
                }
            }
        }
   
    }
}
