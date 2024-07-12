using ADM.CapaNegocio;
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
    public partial class frmConfigurarZonaPaqSeguro : frmBase
    {
        #region Variables Globales
        clsCNPaqueteSeguro PaqueteSeguro = new clsCNPaqueteSeguro();
        public int idPerfil, idZona, idEstablecimiento, idPaqueteSeguro, idUsuario = clsVarGlobal.User.idUsuario, Desactivar;
        public clsMantenimientoPaqueteSeguro clsMantenimientoPaqueteSeguro = new clsMantenimientoPaqueteSeguro();
        #endregion

        public frmConfigurarZonaPaqSeguro()
        {
            InitializeComponent();
        }
        private void frmConfigurarZonaPaqSeguro_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            cboZona1.AgregarTodos();
            cboZona1.SelectedIndex = 10;
        }
        public void asignarDatos(clsMantenimientoPaqueteSeguro _clsMantenimientoPaqueteSeguro)
        {
            clsMantenimientoPaqueteSeguro = _clsMantenimientoPaqueteSeguro;
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            AgregarZona();
            this.Close();
        }
        public void AgregarZona()
        {
            if (Convert.ToInt32(cboZona1.SelectedValue) == 0)
            {
                if (MessageBox.Show("En caso se marque esta opción se procederá a RESTABLECER la configuración para todas las zonas.",
                    "Agregar zonas", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    clsMantenimientoPaqueteSeguro.listaPaqueteSeguroZona.RemoveAll(x => x.idZona != 0);
                }
            }
            else
            {
                clsMantenimientoPaqueteSeguro.listaPaqueteSeguroZona.RemoveAll(x => x.idZona == 0);
            }

            if (!validarAsignacion())
            {
                clsPlanTrabajoZonaVisita _clsPlanTrabajoZonaVisita = new clsPlanTrabajoZonaVisita();
                _clsPlanTrabajoZonaVisita.idZona = Convert.ToInt32(cboZona1.SelectedValue);
                _clsPlanTrabajoZonaVisita.cZona = cboZona1.Text;
                clsMantenimientoPaqueteSeguro.listaPaqueteSeguroZona.Add(_clsPlanTrabajoZonaVisita);
                MessageBox.Show("Se ha agregado correctamente", "Agregar Zona", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public bool validarAsignacion()
        {
            bool existeSimilitud = false;

            clsMantenimientoPaqueteSeguro.listaPaqueteSeguroZona
                .AsEnumerable()
                .ToList()
                .ForEach(x =>
                {
                    if (x.idZona == Convert.ToInt32(cboZona1.SelectedValue))
                    {
                        existeSimilitud = true;
                        MessageBox.Show("La Zona ya se encuentra asignada.", "Agregar Zona", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                });

            return existeSimilitud;
        }
    }
}
