using CRE.CapaNegocio;
using EntityLayer;
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

namespace CRE.Presentacion
{
    public partial class frmConfigurarAgenciaPaqSeguro : frmBase
    {
        #region Variables Globales
        public clsCNPaqueteSeguro PaqueteSeguro = new clsCNPaqueteSeguro();
        public int idPerfil, idZona, idEstablecimiento, idPaqueteSeguro, idUsuario = clsVarGlobal.User.idUsuario, Desactivar;
        public clsMantenimientoPaqueteSeguro clsMantenimientoPaqueteSeguro = new clsMantenimientoPaqueteSeguro();
        #endregion

        private void frmConfigurarEstablecimientoPaqSeguro_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO); 
            cboZona1.AgregarTodos();
        }

        private void cboZona1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idZonaSeleccionado = Convert.ToInt32(cboZona1.SelectedValue);
            cboAgencias1.FiltrarPorZonaAgenciaVigenteTodos(idZonaSeleccionado);
        }

        public frmConfigurarAgenciaPaqSeguro()
        {
            InitializeComponent();
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            AgregarEstablecimiento();
            this.Close();
        }
        public void asignarDatos(clsMantenimientoPaqueteSeguro _clsMantenimientoPaqueteSeguro)
        {
            clsMantenimientoPaqueteSeguro = _clsMantenimientoPaqueteSeguro;
        }
        public void AgregarEstablecimiento()
        {
            if (Convert.ToInt32(cboAgencias1.SelectedValue) == 0)
            {
                if (MessageBox.Show("En caso se marque esta opción se procederá a RESTABLECER la configuración para todos las agencias.","Agregar Agencia", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    clsMantenimientoPaqueteSeguro.listaPaqueteSeguroEstablecimiento.RemoveAll(x => x.idAgencia != 0);
                }
            }
            else
            {
                clsMantenimientoPaqueteSeguro.listaPaqueteSeguroEstablecimiento.RemoveAll(x => x.idAgencia == 0);
            }

            if (!validarAsignacion())
            {
                clsAgencia _clsAgencia = new clsAgencia();
                _clsAgencia.idAgencia = Convert.ToInt32(cboAgencias1.SelectedValue);
                _clsAgencia.cNombreAge = cboAgencias1.Text;
                _clsAgencia.cZona = cboZona1.Text;
                clsMantenimientoPaqueteSeguro.listaPaqueteSeguroEstablecimiento.Add(_clsAgencia);
                MessageBox.Show("Se ha agregado correctamente", "Agregar Agencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public bool validarAsignacion()
        {
            bool existeSimilitud = false;
            clsMantenimientoPaqueteSeguro.listaPaqueteSeguroEstablecimiento.AsEnumerable
                ().ToList().ForEach(x =>
                {
                    if (x.idAgencia == Convert.ToInt32(cboAgencias1.SelectedValue))
                    {
                        existeSimilitud = true;
                        MessageBox.Show("La agencia ya se encuentra asignada.", "Agregar Agencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                });
            return existeSimilitud;
        }
    }
}