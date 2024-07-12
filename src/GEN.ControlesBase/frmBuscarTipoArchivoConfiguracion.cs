using EntityLayer;
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
    public partial class frmBuscarTipoArchivoConfiguracion : frmBase
    {
        clsListaTipoArchivoEscaneado plistaDocumento = new clsListaTipoArchivoEscaneado();
        public clsTipoArchivoEscaneado tipArcOrigen;
        public bool lAceptado = false;
        public frmBuscarTipoArchivoConfiguracion()
        {
            InitializeComponent();
        }
        public frmBuscarTipoArchivoConfiguracion(clsListaTipoArchivoEscaneado listaDocumento)
        {
            InitializeComponent();
            dtgArchivoxGrupo.DataSource = listaDocumento;
        }
        private void dtgArchivoxGrupo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { 
        }

        private void dtgArchivoxGrupo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var obj = dtgArchivoxGrupo.CurrentRow.DataBoundItem as clsTipoArchivoEscaneado;
            if (obj != null)
            {
                tipArcOrigen = obj;
            }
            lAceptado = true;

                 this.Dispose();
        }
    }
}
