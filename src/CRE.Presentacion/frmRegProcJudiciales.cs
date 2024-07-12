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
using EntityLayer;
using CRE.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmRegProcJudiciales : frmBase
    {
        DataTable dtProcJudicial = new DataTable("dtProcJudicial");
        DataTable dtLstProcJud;
        DataTable dtCreditos = new DataTable();
        clsCNProcJud objProcJud = new clsCNProcJud();
        private bool lFlagValidar = true;        

        public frmRegProcJudiciales()
        {
            InitializeComponent();                     
        }

        private void frmRegProcJudiciales_Load(object sender, EventArgs e)
        {
            Habilitar(1);
            txtDNITerc.MaxLength = 15;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            dtProcJudicial = objProcJud.BusProcJud(0);
            DataRow row = dtProcJudicial.NewRow();
            row["idProcJudicial"] = 0;
            row["dFecRegExp"] = clsVarGlobal.dFecSystem;
            row["idUsuReg"] = clsVarGlobal.User.idCli;
            row["lVigente"] = 1;
            row["idTipoDocumento"] = 1;
            dtProcJudicial.Rows.Add(row);

            dtpFecEntrAse.Value = clsVarGlobal.dFecSystem; ;
            dtpFecRegExp.Value = clsVarGlobal.dFecSystem;

            Habilitar(2);
            dtCreditos = objProcJud.BusCtasCredRelacionadas(0);
            dtgCreditos.DataSource = dtCreditos;
            formatearDTGCreditos();            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Habilitar(3);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            Validar();
            if (!lFlagValidar) return;

            FillDataTableToSave();
            DataSet dsProcJudicial = new DataSet("dsProcJudicial");
            dsProcJudicial.Tables.Add(dtProcJudicial);
            dsProcJudicial.Tables.Add(dtCreditos);
            string xmlProcJudicial = dsProcJudicial.GetXml();

            dsProcJudicial.Tables.Clear();

            DataTable result = objProcJud.RegProcJud(xmlProcJudicial);

            if (result.Rows[0]["idMsje"].ToString() == "0")
            {
                this.txtNroProc.Text = result.Rows[0]["idProcJud"].ToString();
                MessageBox.Show("Proceso Judicial N° " + result.Rows[0]["idProcJud"].ToString() + " Guardado Correctamente", "Registro de Procesos Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Habilitar(4);
            }
            else
            {
                MessageBox.Show(result.Rows[0]["cMsje"].ToString(), "Registro de Procesos Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Habilitar(1);
        }    

        private void chcTerceria_CheckedChanged(object sender, EventArgs e)
        {
            if (chcTerceria.Checked && chcTerceria.Enabled)
            {
                grbDatTerceria.Enabled = true;
            }
            else
            {
                grbDatTerceria.Enabled = false;
                txtDNITerc.Text = "";
                txtNroProcTerc.Text = "";
                txtApePatTerc.Text = "";
                txtApMatTerc.Text = "";
                txtNomTerc.Text = "";
                txtDatAdTerc.Text = "";
            }
        }

        private void conBusCli_ClicBuscar(object sender, EventArgs e)
        {
            int idProcJudicial = 0, idCli = 0, idEstado = 0, idJuzgado = 0, idJuez = 0,
                idSecretario = 0, idAbogado = 0, idTipoProceso = 0, idTipoMedida = 0, idProcRel = 0, idTipoDocumento = 0;
            string cJuzgado = "", cJuez = "", cSecretario = "", cNroExpediente = "", cAbogado = "",
                    cTipoProceso = "", cTipoMedida = "", cAbogDemand = "", cDocDeman = "", cApePatDeman = "",
                    cApeMatDeman = "", cNomDeman = "", cDatAdicDeman = "";
            DateTime dFecRegExp = DateTime.Now.Date, dFecEntrAsesor = DateTime.Now.Date;
            bool lIndTerceria = false;

            if (string.IsNullOrEmpty(conBusCli.txtCodCli.Text))
            {
                MessageBox.Show("Elija un cliente primero", "Registro de Procesos Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            dtLstProcJud = objProcJud.BusLstProcJud(Convert.ToInt32(conBusCli.txtCodCli.Text));
            if (dtLstProcJud.Rows.Count > 0)
            {
                if (dtLstProcJud.Rows.Count > 1)
                {
                    frmListaProcJud frm = new frmListaProcJud();
                    frm.CargarDatos(Convert.ToInt32(conBusCli.txtCodCli.Text), (string.IsNullOrEmpty(txtNroProc.Text) ? 0 : Convert.ToInt32(txtNroProc.Text)));
                    frm.ShowDialog();
                    if (frm.idProcJudicial > 0)
                    {
                        idProcJudicial = frm.idProcJudicial;
                        dtProcJudicial = objProcJud.BusProcJud(idProcJudicial);
                        dtCreditos = objProcJud.BusCtasCredRelacionadas(idProcJudicial);
                        //carga de cuentas
                    }
                    else
                    {
                        MessageBox.Show("No eligio ningun proceso judicial.\nRealice nuevamente la busqueda.", "Registro de Procesos Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        Habilitar(1);
                        return;
                    }
                }
                else
                {
                    idProcJudicial = Convert.ToInt32(dtLstProcJud.Rows[0]["idProcJudicial"]);
                    dtProcJudicial = objProcJud.BusProcJud(idProcJudicial);
                    dtCreditos = objProcJud.BusCtasCredRelacionadas(idProcJudicial);
                }
                if (dtProcJudicial.Rows[0]["cNroExpediente"] != DBNull.Value)
                {
                    cNroExpediente = Convert.ToString(dtProcJudicial.Rows[0]["cNroExpediente"]);
                }
                idCli = Convert.ToInt32(dtProcJudicial.Rows[0]["idCli"]);
                idEstado = Convert.ToInt16(dtProcJudicial.Rows[0]["idEstado"]);
                dtgCreditos.DataSource = dtCreditos;
                formatearDTGCreditos();
                if (dtProcJudicial.Rows[0]["idJuzgado"] != DBNull.Value)
                {
                    idJuzgado = Convert.ToInt16(dtProcJudicial.Rows[0]["idJuzgado"]);
                }
                cJuzgado = Convert.ToString(dtProcJudicial.Rows[0]["idProcJudicial"]);
                idJuez = Convert.ToInt32(dtProcJudicial.Rows[0]["idJuez"]);
                cJuez = Convert.ToString(dtProcJudicial.Rows[0]["cJuez"]);
                idSecretario = Convert.ToInt32(dtProcJudicial.Rows[0]["idSecretario"]);
                cSecretario = Convert.ToString(dtProcJudicial.Rows[0]["cSecretario"]);
                if (dtProcJudicial.Rows[0]["idAbogado"] != DBNull.Value)
                {
                    idAbogado = Convert.ToInt32(dtProcJudicial.Rows[0]["idAbogado"]);
                }
                cAbogado = Convert.ToString(dtProcJudicial.Rows[0]["cAbogado"]);
                idTipoProceso = Convert.ToInt32(dtProcJudicial.Rows[0]["idTipoProceso"]);
                cTipoProceso = Convert.ToString(dtProcJudicial.Rows[0]["cTipoProceso"]);
                idTipoMedida = Convert.ToInt32(dtProcJudicial.Rows[0]["idTipoMedida"]);
                cTipoMedida = Convert.ToString(dtProcJudicial.Rows[0]["cTipoMedida"]);
                dFecRegExp = Convert.ToDateTime(dtProcJudicial.Rows[0]["dFecRegExp"]);
                lIndTerceria = Convert.ToBoolean(dtProcJudicial.Rows[0]["lIndTerceria"]);
                idTipoDocumento = Convert.ToInt32(dtProcJudicial.Rows[0]["idTipoDocumento"]);
                if (dtProcJudicial.Rows[0]["cAbogDemand"] != DBNull.Value)
                {
                    cAbogDemand = Convert.ToString(dtProcJudicial.Rows[0]["cAbogDemand"]);
                }

                if (dtProcJudicial.Rows[0]["dFecEntrAsesor"] != DBNull.Value)
                {
                    dFecEntrAsesor = Convert.ToDateTime(dtProcJudicial.Rows[0]["dFecEntrAsesor"]);
                }

                if (lIndTerceria)
                {
                    cboTipoDocumento1.SelectedValue = idTipoDocumento;
                    cDocDeman = Convert.ToString(dtProcJudicial.Rows[0]["cDocDeman"]);
                    cApePatDeman = Convert.ToString(dtProcJudicial.Rows[0]["cApePatDeman"]);
                    cApeMatDeman = Convert.ToString(dtProcJudicial.Rows[0]["cApeMatDeman"]);
                    cNomDeman = Convert.ToString(dtProcJudicial.Rows[0]["cNomDeman"]);
                    cDatAdicDeman = Convert.ToString(dtProcJudicial.Rows[0]["cDatAdicDeman"]);
                    idProcRel = Convert.ToInt32(dtProcJudicial.Rows[0]["idProcRel"]);
                }

                conBusCli.txtCodCli.Text = idCli.ToString();

                txtNroProc.Text = idProcJudicial.ToString();
                if (dtProcJudicial.Rows[0]["cNroExpediente"] != DBNull.Value)
                {
                    txtNroExp1.Text = cNroExpediente.Substring(0, 5);
                    txtNroExp2.Text = cNroExpediente.Substring(6, 4);
                    txtNroExp3.Text = cNroExpediente.Substring(11, 1);
                    txtNroExp4.Text = cNroExpediente.Substring(13, 4);
                    txtNroExp5.Text = cNroExpediente.Substring(18, 2);
                    txtNroExp6.Text = cNroExpediente.Substring(21, 2);
                    txtNroExp7.Text = cNroExpediente.Substring(24, 2);
                }
                cboEstProcJud.SelectedValue = Convert.ToInt16(idEstado);
                cboJuzgado.SelectedValue = Convert.ToInt16(idJuzgado);
                if (dtProcJudicial.Rows[0]["idJuzgado"] != DBNull.Value)
                {
                    txtJuzgado.Text = idJuzgado.ToString();
                }
                cboJuez.SelectedValue = Convert.ToInt16(idJuez);
                txtJuez.Text = idJuez.ToString();
                cboAbogado.SelectedValue = Convert.ToInt16(idAbogado);
                if (dtProcJudicial.Rows[0]["idAbogado"] != DBNull.Value)
                {
                    txtAbogado.Text = idAbogado.ToString();
                }
                cboSecretario.SelectedValue = Convert.ToInt16(idSecretario);
                txtSecretario.Text = idSecretario.ToString();
                cboTipoProcJud.SelectedValue = Convert.ToInt16(idTipoProceso);
                txtTipProc.Text = idTipoProceso.ToString();
                cboTipMedJud.SelectedValue = Convert.ToInt16(idTipoMedida);
                txtTipMed.Text = idTipoMedida.ToString();
                dtpFecRegExp.Value = dFecRegExp;
                if (dtProcJudicial.Rows[0]["cAbogDemand"] != DBNull.Value)
                {
                    txtAbogContr.Text = cAbogDemand;
                }

                if (dtProcJudicial.Rows[0]["dFecEntrAsesor"] != DBNull.Value)
                {
                    chcAsignar.Checked = true;
                    dtpFecEntrAse.Value = dFecEntrAsesor;
                }

                if (lIndTerceria)
                {
                    chcTerceria.Checked = true;

                    txtDNITerc.Text = cDocDeman;
                    txtNroProcTerc.Text = idProcRel.ToString();
                    txtApePatTerc.Text = cApePatDeman;
                    txtApMatTerc.Text = cApeMatDeman;
                    txtNomTerc.Text = cNomDeman;
                    txtDatAdTerc.Text = cDatAdicDeman;
                }
                else
                {
                    chcTerceria.Checked = false;
                }

                btnEditar.Enabled = true;
                btnNuevo.Enabled = true;
                btnCancelar.Enabled = true;
            }
            else
            {
                btnEditar.Enabled = false;
                btnNuevo.Enabled = true;
                btnCancelar.Enabled = true;
            }
            conBusCli.btnBusCliente.Enabled = false;
            dtpFecEntrAse.Enabled = false;
        }

        private void txtNroExp1_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNroExp1.Text.Trim()))
            {
                txtNroExp1.Text = txtNroExp1.Text.PadLeft(5, '0');
            }
        }

        private void txtNroExp2_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNroExp2.Text.Trim()))
            {
                txtNroExp2.Text = txtNroExp2.Text.PadLeft(4, '0');
            }
        }

        private void txtNroExp3_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNroExp3.Text.Trim()))
            {
                txtNroExp3.Text = txtNroExp3.Text.PadLeft(1, '0');
            }
        }

        private void txtNroExp4_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNroExp4.Text.Trim()))
            {
                txtNroExp4.Text = txtNroExp4.Text.PadLeft(4, '0');
            }
        }

        private void txtNroExp7_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNroExp7.Text.Trim()))
            {
                txtNroExp7.Text = txtNroExp7.Text.PadLeft(2, '0');
            }
        }

        private void cboJuzgado_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtJuzgado.Text = Convert.ToInt16(cboJuzgado.SelectedValue).ToString();
        }

        private void cboJuez_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtJuez.Text = Convert.ToInt16(cboJuez.SelectedValue).ToString();
        }

        private void cboSecretario_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSecretario.Text = Convert.ToInt16(cboSecretario.SelectedValue).ToString();
        }

        private void cboAbogado_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAbogado.Text = Convert.ToInt16(cboAbogado.SelectedValue).ToString();
        }

        private void cboTipoProcJud_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTipProc.Text = Convert.ToInt16(cboTipoProcJud.SelectedValue).ToString();
            cboEstProcJud.cargarPorTipoProc(Convert.ToInt32(cboTipoProcJud.SelectedValue));
        }

        private void cboTipMedJud_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTipMed.Text = Convert.ToInt16(cboTipMedJud.SelectedValue).ToString();
        }

        private void FillDataTableToSave()
        {
            dtProcJudicial.TableName = "dtProcJudicial";
            if (!(string.IsNullOrEmpty(txtNroExp1.Text) || string.IsNullOrEmpty(txtNroExp2.Text) || string.IsNullOrEmpty(txtNroExp3.Text) ||
                string.IsNullOrEmpty(txtNroExp4.Text) || string.IsNullOrEmpty(txtNroExp5.Text) || string.IsNullOrEmpty(txtNroExp6.Text) ||
                string.IsNullOrEmpty(txtNroExp7.Text)))
            {
                dtProcJudicial.Rows[0]["cNroExpediente"] = txtNroExp1.Text + "-" + txtNroExp2.Text + "-" + txtNroExp3.Text + "-" + txtNroExp4.Text + "-" + txtNroExp5.Text + "-" + txtNroExp6.Text + "-" + txtNroExp7.Text;
            }
            dtProcJudicial.Rows[0]["idCli"] = conBusCli.txtCodCli.Text;
            dtProcJudicial.Rows[0]["idEstado"] = Convert.ToInt16(cboEstProcJud.SelectedValue);
            if (cboJuzgado.SelectedIndex != -1)
            {
                dtProcJudicial.Rows[0]["idJuzgado"] = Convert.ToInt16(cboJuzgado.SelectedValue);
            }
            dtProcJudicial.Rows[0]["idJuez"] = Convert.ToInt16(cboJuez.SelectedValue); ;
            dtProcJudicial.Rows[0]["idSecretario"] = Convert.ToInt16(cboSecretario.SelectedValue);
            if (cboAbogado.SelectedIndex != -1)
            {
                dtProcJudicial.Rows[0]["idAbogado"] = Convert.ToInt16(cboAbogado.SelectedValue);
            }
            dtProcJudicial.Rows[0]["idTipoProceso"] = Convert.ToInt16(cboTipoProcJud.SelectedValue);
            dtProcJudicial.Rows[0]["idTipoMedida"] = Convert.ToInt16(cboTipMedJud.SelectedValue);          
            dtProcJudicial.Rows[0]["lIndTerceria"] = chcTerceria.Checked;
            dtProcJudicial.Rows[0]["cAbogDemand"] = txtAbogContr.Text;

            if (chcAsignar.Checked)
            {
                dtProcJudicial.Rows[0]["dFecEntrAsesor"] = dtpFecEntrAse.Value.Date;
            }

            if (chcTerceria.Checked)
            {
                dtProcJudicial.Rows[0]["cDocDeman"] = txtDNITerc.Text;
                dtProcJudicial.Rows[0]["cApePatDeman"] = txtApePatTerc.Text;
                dtProcJudicial.Rows[0]["cApeMatDeman"] = txtApMatTerc.Text;
                dtProcJudicial.Rows[0]["cNomDeman"] = txtNomTerc.Text;
                dtProcJudicial.Rows[0]["cDatAdicDeman"] = txtDatAdTerc.Text;
                dtProcJudicial.Rows[0]["idProcRel"] = txtNroProcTerc.Text;
                dtProcJudicial.Columns["idTipoDocumento"].ReadOnly = false;
                dtProcJudicial.Rows[0]["idTipoDocumento"] = cboTipoDocumento1.SelectedValue;
            }
        }

        private void Habilitar(int nOpcion)
        {
            if (nOpcion == 1) //Inicio o Cancelar
            {
                LimpiarComponentes();

                conBusCli.txtCodAge.Text = "";
                conBusCli.txtCodInst.Text = "";
                conBusCli.txtCodCli.Text = "";
                conBusCli.txtCodAge.Text = "";
                conBusCli.txtNroDoc.Text = "";
                conBusCli.txtNombre.Text = "";
                conBusCli.txtDireccion.Text = "";

                conBusCli.txtCodCli.Enabled = true;
                conBusCli.btnBusCliente.Enabled = true;
                txtNroExp1.Enabled = false;
                txtNroExp2.Enabled = false;
                txtNroExp3.Enabled = false;
                txtNroExp4.Enabled = false;
                txtNroExp5.Enabled = false;
                txtNroExp6.Enabled = false;
                txtNroExp7.Enabled = false;
                cboEstProcJud.Enabled = false;
                cboJuzgado.Enabled = false;
                cboJuez.Enabled = false;
                cboSecretario.Enabled = false;
                cboAbogado.Enabled = false;
                cboTipoProcJud.Enabled = false;
                cboTipMedJud.Enabled = false;
                dtpFecRegExp.Enabled = false;
                dtpFecEntrAse.Enabled = false;
                txtAbogContr.Enabled = false;

                chcAsignar.Enabled = false;

                chcTerceria.Enabled = false;

                grbDatTerceria.Enabled = false;

                btnNuevo.Enabled = false;
                btnCancelar.Enabled = false;
                btnEditar.Enabled = false;
                btnGrabar.Enabled = false;
                btnMiniQuitar1.Enabled = false;
                btnMiniAgregar1.Enabled = false;
                
                
            }
            else if (nOpcion == 2) //Nuevo
            {
                LimpiarComponentes();

                conBusCli.txtCodCli.Enabled = false;
                txtNroExp1.Enabled = true;
                txtNroExp2.Enabled = true;
                txtNroExp3.Enabled = true;
                txtNroExp4.Enabled = true;
                txtNroExp5.Enabled = true;
                txtNroExp6.Enabled = true;
                txtNroExp7.Enabled = true;
                cboEstProcJud.Enabled = true;
                cboJuzgado.Enabled = true;
                cboJuez.Enabled = true;
                cboSecretario.Enabled = true;
                cboAbogado.Enabled = true;
                cboTipoProcJud.Enabled = true;
                cboTipMedJud.Enabled = true;
                dtpFecRegExp.Enabled = false;
                dtpFecEntrAse.Enabled = false;
                txtAbogContr.Enabled = true;

                chcAsignar.Enabled = true;

                chcTerceria.Enabled = true;

                grbDatTerceria.Enabled = false;

                btnNuevo.Enabled = false;
                btnCancelar.Enabled = true;
                btnEditar.Enabled = false;
                btnGrabar.Enabled = true;
                btnMiniQuitar1.Enabled = true;
                btnMiniAgregar1.Enabled = true;
            }
            else if (nOpcion == 3) //Editar
            {
                conBusCli.txtCodCli.Enabled = false;
                txtNroExp1.Enabled = true;
                txtNroExp2.Enabled = true;
                txtNroExp3.Enabled = true;
                txtNroExp4.Enabled = true;
                txtNroExp5.Enabled = true;
                txtNroExp6.Enabled = true;
                txtNroExp7.Enabled = true;
                cboEstProcJud.Enabled = true;
                cboJuzgado.Enabled = true;
                cboJuez.Enabled = true;
                cboSecretario.Enabled = true;
                cboAbogado.Enabled = true;
                cboTipoProcJud.Enabled = true;
                cboTipMedJud.Enabled = true;
                dtpFecRegExp.Enabled = false;
                txtAbogContr.Enabled = true;

                chcAsignar.Enabled = true;

                if (chcAsignar.Checked)
                {
                    dtpFecEntrAse.Enabled = true;
                }
                else
                {
                    dtpFecEntrAse.Enabled = false;
                }           

                if (chcTerceria.Checked)
                {
                    grbDatTerceria.Enabled = true;
                }
                else
                {
                    grbDatTerceria.Enabled = false;
                }

                chcTerceria.Enabled = true;

                btnNuevo.Enabled = false;
                btnCancelar.Enabled = true;
                btnEditar.Enabled = false;
                btnGrabar.Enabled = true;
                btnMiniQuitar1.Enabled = true;
                btnMiniAgregar1.Enabled = true;
            }
            else if (nOpcion == 4) // Grabar
            {
                conBusCli.txtCodCli.Enabled = false;
                txtNroExp1.Enabled = false;
                txtNroExp2.Enabled = false;
                txtNroExp3.Enabled = false;
                txtNroExp4.Enabled = false;
                txtNroExp5.Enabled = false;
                txtNroExp6.Enabled = false;
                txtNroExp7.Enabled = false;
                cboEstProcJud.Enabled = false;
                cboJuzgado.Enabled = false;
                cboJuez.Enabled = false;
                cboSecretario.Enabled = false;
                cboAbogado.Enabled = false;
                cboTipoProcJud.Enabled = false;
                cboTipMedJud.Enabled = false;
                dtpFecRegExp.Enabled = false;
                dtpFecEntrAse.Enabled = false;
                txtAbogContr.Enabled = false;

                chcAsignar.Enabled = false;

                chcTerceria.Enabled = false;

                grbDatTerceria.Enabled = false;

                btnNuevo.Enabled = false;
                btnCancelar.Enabled = true;
                btnEditar.Enabled = false;
                btnGrabar.Enabled = false;
                btnMiniQuitar1.Enabled = false;
                btnMiniAgregar1.Enabled = false;
            }
        }

        private void LimpiarComponentes()
        {
            txtNroProc.Text = "";
            txtNroExp1.Text = "";
            txtNroExp2.Text = "";
            txtNroExp3.Text = "";
            txtNroExp4.Text = "";
            txtNroExp5.Text = "";
            txtNroExp6.Text = "";
            txtNroExp7.Text = "";
            cboEstProcJud.SelectedIndex = -1;
            txtJuzgado.Text = "";
            cboJuzgado.SelectedIndex = -1;
            txtJuez.Text = "";
            cboJuez.SelectedIndex = -1;
            txtSecretario.Text = "";
            cboSecretario.SelectedIndex = -1;
            txtAbogado.Text = "";
            cboAbogado.SelectedIndex = -1;
            txtTipProc.Text = "";
            cboTipoProcJud.SelectedIndex = -1;
            txtTipMed.Text = "";
            cboTipMedJud.SelectedIndex = -1;
            txtAbogContr.Text = "";
            dtpFecRegExp.Value = clsVarGlobal.dFecSystem;
            dtpFecEntrAse.Value = clsVarGlobal.dFecSystem;

            chcAsignar.Checked = false;

            txtNroProcTerc.Text = "";
            txtDNITerc.Text = "";
            txtApePatTerc.Text = "";
            txtApMatTerc.Text = "";
            txtNomTerc.Text = "";
            txtNroProc.Text = "";
            txtDatAdTerc.Text = "";

            chcTerceria.Checked = false;
            cboEstProcJud.cargarPorTipoProc(0);
            dtgCreditos.DataSource = null;
        }

        private void btnBusProcJud_Click(object sender, EventArgs e)
        {
            frmListaProcJud frm = new frmListaProcJud();
            frm.CargarDatos(Convert.ToInt32(conBusCli.txtCodCli.Text), (string.IsNullOrEmpty(txtNroProc.Text) ? 0 : Convert.ToInt32(txtNroProc.Text)));
            frm.ShowDialog();

            if (frm.idProcJudicial>0)
            {
                txtNroProcTerc.Text = frm.idProcJudicial.ToString();
            }
            else
            {
                MessageBox.Show("No se pudieron vincular los procesos", "Registro de Procesos Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNroProcTerc.Text="";
                chcTerceria.Checked = false;
            }

        }

        private void Validar()
        {
            string Msje = "";
            lFlagValidar = true;
            int cont = 0;

            if(string.IsNullOrEmpty(txtNroExp1.Text))cont++;
            if(string.IsNullOrEmpty(txtNroExp2.Text))cont++;
            if(string.IsNullOrEmpty(txtNroExp3.Text))cont++;
            if(string.IsNullOrEmpty(txtNroExp4.Text))cont++;
            if(string.IsNullOrEmpty(txtNroExp5.Text))cont++;
            if(string.IsNullOrEmpty(txtNroExp6.Text))cont++;
            if(string.IsNullOrEmpty(txtNroExp7.Text))cont++;

            if (cont>0 && cont <7)
            {
                Msje += "Ingrese todos los campos o ningun campo del Numero de expediente.\n";
                lFlagValidar = false;
                txtNroExp1.Focus();
            }

            if (txtNroExp5.Text.Length < 2 || txtNroExp6.Text.Length < 2)
            {
                Msje += "Formato de Numero de expediente invalido.\n";
                lFlagValidar = false;
                txtNroExp5.Focus();
            }

            if (cboEstProcJud.SelectedIndex < 0)
            {
                Msje += "Seleccione un Estado para el Proceso Judicial.\n";
                lFlagValidar = false;
                cboEstProcJud.Focus();
            }

            //if (Convert.ToInt16(cboJuzgado.SelectedIndex) == -1)
            //{
            //    Msje += "Seleccione un Estado para el Proceso Judicial.\n";
            //    lFlagValidar = false;
            //    cboJuzgado.Focus();
            //}

            if (cboJuez.SelectedIndex < 0)
            {
                Msje += "Seleccione un Juez para el Proceso Judicial.\n";
                lFlagValidar = false;
                cboJuez.Focus();
            }

            if (cboSecretario.SelectedIndex< 0)
            {
                Msje += "Seleccione un Secretario para el Proceso Judicial.\n";
                lFlagValidar = false;
                cboSecretario.Focus();
            }

            //if (Convert.ToInt16(cboAbogado.SelectedIndex) == -1)
            //{
            //    Msje += "Seleccione un Estado para el Proceso Judicial.\n";
            //    lFlagValidar = false;
            //    cboAbogado.Focus();
            //}

            if (cboTipoProcJud.SelectedIndex< 0)
            {
                Msje += "Seleccione el Tipo de Proceso.\n";
                lFlagValidar = false;
                cboTipoProcJud.Focus();
            }

            if (cboTipMedJud.SelectedIndex< 0)
            {
                Msje += "Seleccione el tipo de Medio Judicial.\n";
                lFlagValidar = false;
                cboTipMedJud.Focus();
            }

            //if (string.IsNullOrEmpty(txtAbogContr.Text))
            //{
            //    Msje += "Ingrese el nombre del abogado del cliente.\n";
            //    lFlagValidar = false;
            //    txtAbogContr.Focus();
            //}

            int cont2 = 0;

            if (cboAbogado.SelectedIndex < 0) cont2++;
            if (!chcAsignar.Checked) cont2++;
            if (cont2>0 && cont2<2)
            {
                Msje += "Seleccione el gestor legal del proceso y la fecha de asignacion.\n";
                lFlagValidar = false;
                cboTipMedJud.Focus();
            }

            if (chcTerceria.Checked)
            {
                if (string.IsNullOrEmpty(txtDNITerc.Text))
                {
                    Msje += "Ingrese el DOCUMENTO del Tercero demandante.\n";
                    lFlagValidar = false;
                    txtDNITerc.Focus();
                }

                if (string.IsNullOrEmpty(txtNroProcTerc.Text))
                {
                    Msje += "Busque el proceso a Vincular.\n";
                    lFlagValidar = false;
                    txtNroProcTerc.Focus();
                }

                if (string.IsNullOrEmpty(txtApePatTerc.Text) && txtApePatTerc.Enabled)
                {
                    Msje += "Ingrese el apellido paterno del demandante.\n";
                    lFlagValidar = false;
                    txtApePatTerc.Focus();
                }

                if (string.IsNullOrEmpty(txtApMatTerc.Text) && txtApMatTerc.Enabled)
                {
                    Msje += "Ingrese el el apellido materno del demandante.\n";
                    lFlagValidar = false;
                    txtApMatTerc.Focus();
                }

                if (string.IsNullOrEmpty(txtNomTerc.Text))
                {
                    Msje += "Ingrese el nombre o razón social del demandante.\n";
                    lFlagValidar = false;
                    txtNomTerc.Focus();
                }
            }

            if (!string.IsNullOrEmpty(Msje.Trim()))
            {
                MessageBox.Show(Msje, "Vincular Proceso Judicial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lFlagValidar = false;
            }
        }

        private void chcAsignar_CheckedChanged(object sender, EventArgs e)
        {
            if (chcAsignar.Checked)
            {
                dtpFecEntrAse.Enabled = true;
            }
            else
            {
                dtpFecEntrAse.Enabled = false;
            }
        }

        private void cboTipoDocumento1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoDocumento1.SelectedIndex >= 0)
            {
                if (cboTipoDocumento1.Text == "RUC")
                {
                    txtApMatTerc.Enabled = false;
                    txtApePatTerc.Enabled = false;
                    txtApMatTerc.Clear();
                    txtApePatTerc.Clear();
                }
                else
                {
                    txtApMatTerc.Enabled = true;
                    txtApePatTerc.Enabled = true;
                }
            }
        }

        private void btnMiniAgregar1_Click(object sender, EventArgs e)
        {
            GEN.ControlesBase.FrmBuscaCuentaCliente frmBuscaCuentaCliente = new GEN.ControlesBase.FrmBuscaCuentaCliente();
            frmBuscaCuentaCliente.CargarDatos(conBusCli.idCli, "C", "[5,6]");
            if (frmBuscaCuentaCliente.dtgDatosCreSol.Rows.Count <= 0)
            {
                MessageBox.Show("El cliente no registra cuenta alguna", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            frmBuscaCuentaCliente.ShowDialog();
            
            if (!String.IsNullOrEmpty(frmBuscaCuentaCliente.cIdCreSol))
            {
                var varCreditos = ( from item in dtCreditos.AsEnumerable()
                                    where Convert.ToInt32(item["idCuenta"]) == Convert.ToInt32(frmBuscaCuentaCliente.cIdCreSol)
                                    select item).ToList();

                if (varCreditos.Count <= 0)
                {
                    DataRow drNuevoCred = dtCreditos.NewRow();
                    drNuevoCred["idCuenta"] = frmBuscaCuentaCliente.cIdCreSol;
                    drNuevoCred["dFechaDesembolso"] = frmBuscaCuentaCliente.dFechaDesembolso;
                    drNuevoCred["cMoneda"] = frmBuscaCuentaCliente.cMoneda;
                    drNuevoCred["nCapitalDesembolso"] = frmBuscaCuentaCliente.nCapitalDesembolso;
                    drNuevoCred["cProducto"] = frmBuscaCuentaCliente.cProducto;
                    drNuevoCred["cEstado"] = frmBuscaCuentaCliente.cEstado;
                    dtCreditos.Rows.Add(drNuevoCred);
                    btnMiniQuitar1.Enabled = true;
                }
                else
                {
                    MessageBox.Show("La cuenta ya fue relacionada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        
        private void formatearDTGCreditos()
        {
            foreach (DataGridViewColumn columna in dtgCreditos.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.Automatic;
                columna.Visible = false;
            }

            dtgCreditos.Columns["idCuenta"].Visible = true;
            dtgCreditos.Columns["dFechaDesembolso"].Visible = true;
            dtgCreditos.Columns["cMoneda"].Visible = true;
            dtgCreditos.Columns["nCapitalDesembolso"].Visible = true;
            dtgCreditos.Columns["cProducto"].Visible = true;
            dtgCreditos.Columns["cEstado"].Visible = true;

            dtgCreditos.Columns["idCuenta"].HeaderText = "Cuenta";
            dtgCreditos.Columns["dFechaDesembolso"].HeaderText = "Fec. Desembolso";
            dtgCreditos.Columns["cMoneda"].HeaderText = "Moneda";
            dtgCreditos.Columns["nCapitalDesembolso"].HeaderText = "Capital desembolsado";
            dtgCreditos.Columns["cProducto"].HeaderText = "Producto";
            dtgCreditos.Columns["cEstado"].HeaderText = "Estado";

            dtgCreditos.Columns["idCuenta"].Width = 80;
            dtgCreditos.Columns["dFechaDesembolso"].Width = 80;
            dtgCreditos.Columns["cMoneda"].Width = 70;
            dtgCreditos.Columns["nCapitalDesembolso"].Width = 80;
            dtgCreditos.Columns["cProducto"].Width = 100;
            dtgCreditos.Columns["cEstado"].Width = 80;
        }

        private void btnMiniQuitar1_Click(object sender, EventArgs e)
        {
            if(dtgCreditos.SelectedRows.Count > 0)
            {
                dtCreditos.Rows.RemoveAt(dtgCreditos.SelectedRows[0].Index);
                btnMiniQuitar1.Enabled = (dtCreditos.Rows.Count > 0);
            }
        }

    }
}

