 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using GEN.CapaNegocio;
using EntityLayer;


namespace SolIntEls
{
    public partial class frmFeriado : frmBase
    {
        #region Variable Globales
        public DataTable dtFeriados;
        List<clsFeriado> lisfer= new List<clsFeriado>();
        #endregion

        #region Eventos del Formularios

        private void frmRegistroFeriado_Load(object sender, EventArgs e)
        {
            clsCNTipoFeriado dtTipoFeriado = new clsCNTipoFeriado();
            DataTable dt = dtTipoFeriado.ListaTipoFeriado();
            ListaFeriado.ValueMember = dt.Columns["idTipoFeriado"].ToString();
            ListaFeriado.DisplayMember = dt.Columns["cTipoFeriado"].ToString();
            ListaFeriado.DataSource = dt;
            btnGrabar1.Enabled = false;
            FormatoFeriado();
       }

        public frmFeriado()
        {
            InitializeComponent();
        
        }
        
        private void btnAgregar1_Click(object sender, EventArgs e)
        {
            try
            {
            
                if (Convert.ToInt32(cboAgencia1.SelectedValue) == 0)
                {
                    foreach (DataRow ag in cboAgencia1.dtAgencia.Rows)
                    {
                        if ((int)ag["idAgencia"]==0)
                        {
                            continue;
                        }
                        DataRow dr = dtFeriados.NewRow();
                        dr["dFeriado"] = dtpCalendario.Value.Date;
                        dr["Estado"] = 'N';
                        dr["idTipoFeriado"] = ListaFeriado.SelectedValue;
                        dr["lVigente"] = 1;
                        dr["idAgencia"] = (int)ag["idAgencia"];
                        dr["cNomCorto"] = (string)ag["cNomCorto"];
                        dr["cDescFeriado"] = txtMotivoFeriado.Text.Trim();

                        dtFeriados.Rows.Add(dr);

                        lisfer.Add(new clsFeriado()
                        {
                            dFeriado = dtpCalendario.Value.Date,
                            idTipoFeriado = (int)ListaFeriado.SelectedValue,
                            lVigente = true,
                            cEstado = 'N',
                            idAgencia = (int)ag["idAgencia"],
                            cNomCorto = (string)ag["cNomCorto"],
                            cDescFeriado = txtMotivoFeriado.Text.Trim(),
                        });
                    }
                }
                else
                {
                    DataRow dr = dtFeriados.NewRow();
                    dr["dFeriado"] = dtpCalendario.Value.Date;
                    dr["Estado"] = 'N';
                    dr["idTipoFeriado"] = ListaFeriado.SelectedValue;
                    dr["lVigente"] = 1;
                    dr["idAgencia"] = Convert.ToInt32(cboAgencia1.SelectedValue);
                    dr["cNomCorto"] = "";
                    dr["cDescFeriado"] = txtMotivoFeriado.Text.Trim();

                    lisfer.Add(new clsFeriado()
                    {
                        dFeriado = dtpCalendario.Value.Date,
                        idTipoFeriado = (int)ListaFeriado.SelectedValue,
                        lVigente = true,
                        cEstado = 'N',
                        idAgencia = Convert.ToInt32(cboAgencia1.SelectedValue),
                        cNomCorto = "",
                        cDescFeriado = txtMotivoFeriado.Text.Trim(),
                    });

                    dtFeriados.Rows.Add(dr);
                }
                btnGrabar1.Enabled = true;
                dtgFeriado.DataSource = dtFeriados;
            
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        
        }
   
        private void btnQuitar1_Click(object sender, EventArgs e)
        {
            if (dtgFeriado.Rows.Count > 0)
            {

                foreach (var item in lisfer)
                {
                    if (item.dFeriado == (DateTime)dtgFeriado.SelectedRows[0].Cells["dFeriado"].Value)
                    {
                        item.lVigente = false;
                        item.cEstado = 'E';
                    }
                }
                dtgFeriado.Rows.RemoveAt(dtgFeriado.SelectedCells[0].RowIndex);
                btnGrabar1.Enabled = true;
            }
            else
            {
                MessageBox.Show("Selecciona la Fecha para Eliminar", "Feriado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        public void btnGrabar1_Click(object sender, EventArgs e)
        {
            try
            {
                if (lisfer.Count() > 0)
                {
                    dtFeriados.Clear();
                    dtgFeriado.Refresh();
                    DataRow dr;

                    foreach (var item in lisfer)
                    {
                        dr = dtFeriados.NewRow();
                        dr["dFeriado"] = item.dFeriado;
                        dr["idTipoFeriado"] = item.idTipoFeriado;
                        dr["lVigente"] = item.lVigente;
                        dr["Estado"] = item.cEstado;
                        dr["idAgencia"] = item.idAgencia;
                        dr["cNomCorto"] = item.cNomCorto;
                        dr["cDescFeriado"] = item.cDescFeriado;

                        dtFeriados.Rows.Add(dr);
                    }

                    DataSet dsGuarFeriados = new DataSet("dsFeriado");
                    dsGuarFeriados.Tables.Add(dtFeriados);
                    String XMLFeriados = dsGuarFeriados.GetXml();

                    dsGuarFeriados.Tables.Clear();

                    clsCNGuardarFeriado GuardarFeria = new clsCNGuardarFeriado();
                    int idUsuario = clsVarGlobal.User.idUsuario;
                    GuardarFeria.GuardarFeriados(XMLFeriados, idUsuario);
                    dtgFeriado.Refresh();

                    MessageBox.Show("Se actualizó con éxito la fecha.", "Feriado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    lisfer = new List<clsFeriado>();
                    dtFeriados = new DataTable();
                    dtgFeriado.Refresh();
                    CargarFeriado((int)this.ListaFeriado.SelectedValue);
                    btnGrabar1.Enabled = false;

                }
                else
                {
                    MessageBox.Show("No existen cambios asignados.", "Feriado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                txtMotivoFeriado.Text = "";

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
           
        }

        private void ListaFeriado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListaFeriado.SelectedItem!=null)
            {
                Int32 niTipoFer = Convert.ToInt32(this.ListaFeriado.SelectedValue.ToString());
                this.CargarFeriado(niTipoFer);
            }
        }

        private void cboAgencia1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaFeriado.SetSelected(0, true);
            if (dtFeriados!=null)
            {
                dtFeriados.Clear();
                dtgFeriado.Refresh();
                CargarFeriado((int)this.ListaFeriado.SelectedValue);
            }
            else
            {
                ListaFeriado.SelectedIndex = -1;
                
            }

        }

        #endregion

        /// <summary>
        /// realiza la carga de feriados
        /// </summary>
        /// <param name="nIdTipoFeriado"></param>
        private void CargarFeriado(Int32 nIdTipoFeriado)
        {
            dtFeriados = new DataTable();
            lisfer = new List<clsFeriado>();
            clsCNGuardarFeriado Feriado = new clsCNGuardarFeriado();
            dtFeriados = Feriado.LisFeriados(nIdTipoFeriado, Convert.ToInt32(cboAgencia1.SelectedValue));
            foreach (DataRow item in dtFeriados.Rows)
            {
                lisfer.Add(new clsFeriado()
                {
                    dFeriado = (DateTime)item["dFeriado"],
                    idTipoFeriado = (int)item["idTipoFeriado"],
                    lVigente = (bool)item["lVigente"],
                    cEstado = 'A',
                    idAgencia = (int)item["idAgencia"],
                    cNomCorto = (string)item["cNomCorto"],
                    cDescFeriado = (string)item["cDescFeriado"]
                });
            }

            dtgFeriado.DataSource = dtFeriados;
            FormatoFeriado();
        }

        /// <summary>
        /// Asigna formato a la tabla
        /// </summary>
        private void FormatoFeriado()
        {
            dtFeriados.Columns["Estado"].ReadOnly = false;
            dtgFeriado.Columns["dFeriado"].Width = 80;
            dtgFeriado.Columns["idTipoFeriado"].Visible = false;
            dtgFeriado.Columns["lVigente"].Visible = false;
            dtgFeriado.Columns["Estado"].Visible = false;
            dtgFeriado.Columns["idAgencia"].Visible = false;
            dtgFeriado.Columns["cNomCorto"].HeaderText = "Agencia";
            dtgFeriado.Columns["cNomCorto"].Width = 30;
            dtgFeriado.Columns["dFeriado"].HeaderText = "Fecha Feriado";
            dtgFeriado.Columns["cDescFeriado"].HeaderText = "Motivo del Feriado";
            dtgFeriado.Columns["cDescFeriado"].Width = 140;
            dtgFeriado.Columns["dFeriado"].DefaultCellStyle.Format = "dddd , dd 'de' MMMM 'de' yyyy";
        }

    }
}
