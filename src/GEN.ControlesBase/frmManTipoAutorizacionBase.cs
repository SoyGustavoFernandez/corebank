using EntityLayer;
using GEN.ControlesBase;
using GEN.ControlesBase.Model;
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
    public partial class frmManTipoAutorizacionBase : frmBase
    {
        public string pcTipOpe = "N"; //Puede ser N --> Nuevo, A--> Actualizar
        TipoAutorizacion[] lstData;
        TipoAutorizacion datasel;
        public frmManTipoAutorizacionBase()
        {
            InitializeComponent();
            this.habilitarBotones(true);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            pcTipOpe = "N";
    
            Limpiar();
            HabilitarControles(true);
            this.habilitarBotones(false);
            CBVigente.Checked = true;
            CBVigente.Enabled = false;

            this.dtgTipoAutorizacion.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (datasel.idTipo != null)
            {
                pcTipOpe = "A";

                HabilitarControles(true);
                this.habilitarBotones(false);
                this.dtgTipoAutorizacion.Enabled = false;
            }
      
        }

        private async void btnGrabar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos() == "ERROR")
            {
                return;
            }

            TipoAutorizacion dato = new TipoAutorizacion();
            dato.cTipo = txtTipoAutorizacion.Text.Trim();
            dato.nTiempoVigencia = (int)txtTiempoVigencia.nvalor;
    
            dato.lVigente = Convert.ToBoolean(CBVigente.Checked);
            string Uri =  clsVarApl.dicVarGen["CRUTAAUTUSODATOS"]+ "TipoAutorizacion";
            
            //Instanciamos un objeto Reply
            clsApiRespuesta oRespuesta = new clsApiRespuesta();

            if (pcTipOpe == "A")
            {
                dato.idTipo =datasel.idTipo;
                dato.dFecModifica = clsVarGlobal.dFecSystem.Date;
                dato.idUsuModifica = clsVarGlobal.User.idUsuario;
                //poblamos el objeto con el método generic Execute
                oRespuesta = await clsApiConsumer.Execute<RespuestaAutTraDatos>(Uri, methodHttp.POST, dato);
                //Poblamos el datagridview
                RespuestaAutTraDatos respuesta = (RespuestaAutTraDatos)oRespuesta.Data; 
                //Mostramos el statuscode devuelto, podemos añadirle lógica de validación
                if (oRespuesta.StatusCode == "OK")
                {

                    this.dtgTipoAutorizacion.Enabled = false;
                    MessageBox.Show(oRespuesta.StatusCode + ": " + respuesta.cMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //cargar de nuevo y seleccionar el registro modificado
                    BuscarTipoAutorizacion();
 
                    int n = 0;
                    foreach (DataGridViewRow fila in dtgTipoAutorizacion.Rows)
                    {
                        n += 1;
                        if (Convert.ToInt32(fila.Cells["idTipo"].Value) == dato.idTipo)
                        {
                            dtgTipoAutorizacion.CurrentCell = dtgTipoAutorizacion.Rows[n - 1].Cells[1];
                            int filaseleccionada = Convert.ToInt32(this.dtgTipoAutorizacion.CurrentRow.Index);
                            MostrarDatos(filaseleccionada);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Error al actualizar los datos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (pcTipOpe == "N")
            {
                dato.idTipo = 0;
                //poblamos el objeto con el método generic Execute
                oRespuesta = await clsApiConsumer.Execute<RespuestaAutTraDatos>(Uri, methodHttp.POST, dato);
                //Poblamos el datagridview
                RespuestaAutTraDatos respuesta = (RespuestaAutTraDatos)oRespuesta.Data; 
                //Mostramos el statuscode devuelto, podemos añadirle lógica de validación
                if (oRespuesta.StatusCode == "OK")
                {
                    dato.idTipo = Convert.ToInt32(respuesta.nCodigo);
                    dato.dFecRegistro = clsVarGlobal.dFecSystem.Date;
                    dato.idUsuRegistro = clsVarGlobal.User.idUsuario;
                    this.dtgTipoAutorizacion.Enabled = false;
                    MessageBox.Show(oRespuesta.StatusCode + ": " + respuesta.cMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //cargar de nuevo y seleccionar el registro modificado
                    BuscarTipoAutorizacion();
                    //MantConceptos.ActualizarConcepto(idTipo, NombConcepto, lVigente);

                    int n = 0;
                    foreach (DataGridViewRow fila in dtgTipoAutorizacion.Rows)
                    {
                        n += 1;
                        if (Convert.ToInt32(fila.Cells["idTipo"].Value) == dato.idTipo)
                        {
                            dtgTipoAutorizacion.CurrentCell = dtgTipoAutorizacion.Rows[n - 1].Cells[1];
                            int filaseleccionada = Convert.ToInt32(this.dtgTipoAutorizacion.CurrentRow.Index);
                            MostrarDatos(filaseleccionada);
                        }
                    }
                    this.habilitarBotones(true);
                }
                else
                {
                    MessageBox.Show("Error al registrar los datos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            HabilitarControles(false);
            int filaseleccionada = 0;
            if (this.dtgTipoAutorizacion.CurrentRow != null)
            {
                filaseleccionada = Convert.ToInt32(this.dtgTipoAutorizacion.CurrentRow.Index);
            } 
            MostrarDatos(filaseleccionada);

            this.dtgTipoAutorizacion.Enabled = true;
        }
        private void habilitarBotones(bool lActivo)
        {
            this.btnNuevo.Enabled = lActivo;
            this.btnEditar.Enabled = lActivo;
            this.btnGrabar.Enabled = !lActivo;
            this.btnCancelar.Enabled = !lActivo; 
        }
        private void Limpiar()
        {
            this.txtTipoAutorizacion.Clear();
            this.txtTiempoVigencia.Clear();
            this.CBVigente.Checked = false;
        }
        private void HabilitarControles(Boolean Val)
        {
            this.txtTipoAutorizacion.Enabled = Val;
            this.txtTiempoVigencia.Enabled = Val;
            this.CBVigente.Enabled = Val;
        }

        private async void BuscarTipoAutorizacion()
        {
            cprogressbar.Visible = true;
            string Uri = clsVarApl.dicVarGen["CRUTAAUTUSODATOS"] + "TipoAutorizacion";
            //Creamos el listado de Posts a llenar
            RespLisTipoAutorizacion listado = new RespLisTipoAutorizacion();
            //Instanciamos un objeto Reply
            clsApiRespuesta oRespuesta = new clsApiRespuesta();
            //poblamos el objeto con el método generic Execute
            oRespuesta = await clsApiConsumer.Execute<RespLisTipoAutorizacion>(Uri, methodHttp.GET, listado);
            //Poblamos el datagridview
            RespLisTipoAutorizacion respuesta = (RespLisTipoAutorizacion)oRespuesta.Data;
            lstData= respuesta.LisTipoAutorizacion;
            this.dtgTipoAutorizacion.DataSource = lstData;
            if(lstData.Count()>0){
                this.MostrarDatos(0);
            }
            //Mostramos el statuscode devuelto, podemos añadirle lógica de validación
            if (oRespuesta.StatusCode == "OK")
            {

                dtgTipoAutorizacion.Columns["cTipo"].Width = 140;
                dtgTipoAutorizacion.Columns["cTipo"].HeaderText = "Nombre";
                dtgTipoAutorizacion.Columns["cTipo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtgTipoAutorizacion.Columns["idTipo"].Visible = false;

                dtgTipoAutorizacion.Columns["idUsuRegistro"].Visible = false;
                dtgTipoAutorizacion.Columns["dFecRegistro"].Visible = false;
                dtgTipoAutorizacion.Columns["idUsuModifica"].Visible = false;
                dtgTipoAutorizacion.Columns["dFecModifica"].Visible = false;

                dtgTipoAutorizacion.Columns["nTiempoVigencia"].HeaderText = "Tiempo Vigencia";
                dtgTipoAutorizacion.Columns["nTiempoVigencia"].Width = 80;

                dtgTipoAutorizacion.Columns["lVigente"].Width = 30;
                dtgTipoAutorizacion.Columns["lVigente"].HeaderText = "Vig.";
                dtgTipoAutorizacion.Columns["lVigente"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


               // MessageBox.Show(oRespuesta.StatusCode + ": " + respuesta.EstadoRpt.cMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            else
            {
                MessageBox.Show("Error al buscar los datos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            cprogressbar.Visible = false;

        }

        private void MostrarDatos(int filaseleccionada)
        {

            if (dtgTipoAutorizacion.SelectedRows.Count > 0)
            {
                datasel = lstData[filaseleccionada];
                this.txtTipoAutorizacion.Text = datasel.cTipo;
                this.txtTiempoVigencia.Text =  datasel.nTiempoVigencia.ToString();
                this.CBVigente.Checked = datasel.lVigente;

                HabilitarControles(false);    
                this.habilitarBotones(true);
                pcTipOpe = "A"; 
            }

        }
        private string ValidarDatos()
        {
            if (txtTipoAutorizacion.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el tipo de autorización",this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTipoAutorizacion.Focus();
                return "ERROR";
            }
            if (txtTiempoVigencia.Text.Trim() == "" || txtTiempoVigencia.Text.Trim() == "0")
            {
                MessageBox.Show("Ingrese el tiempo de vigenncia", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTiempoVigencia.Focus();
                return "ERROR";
            }
            if (pcTipOpe == "N")
            {
                for (int i = 0; i < dtgTipoAutorizacion.Rows.Count; i++)
                {
                    if (Convert.ToString(dtgTipoAutorizacion.Rows[i].Cells["cTipo"].Value) == txtTipoAutorizacion.Text.Trim())
                    {
                        MessageBox.Show("Ya existe una autorización con ese nombre. Verifique", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtTipoAutorizacion.Focus();
                        return "ERROR";
                    }
                }
            }

            if (pcTipOpe == "A")
            {
                int filaseleccionada = Convert.ToInt32(this.dtgTipoAutorizacion.CurrentRow.Index);

                for (int i = 0; i < dtgTipoAutorizacion.Rows.Count; i++)
                {
                    if (filaseleccionada != i)
                    {
                        if (Convert.ToString(dtgTipoAutorizacion.Rows[i].Cells["cTipo"].Value) == txtTipoAutorizacion.Text.Trim())
                        {
                            MessageBox.Show("Ya existe un tipo de autorización con ese nombre. Verifique", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtTipoAutorizacion.Focus();
                            return "ERROR";
                        }
                    }
                }
            }

            return "OK";
        }

        private void frmManTipoAutorizacion_Load(object sender, EventArgs e)
        {
            Limpiar();
            HabilitarControles(false);
            if (clsVarApl.dicVarGen["nIndTrabAutUsoDat"] == 1)
            {
                BuscarTipoAutorizacion();
               
            }
            else
            {
                MessageBox.Show("Servicio de autorización de uso de datos no habilitado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information); 
            }
        }

   
 

        private void dtgTipoAutorizacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }

        private void dtgTipoAutorizacion_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
          
            this.MostrarDatos(e.RowIndex);
        }
    }
}
