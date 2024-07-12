using CRE.CapaNegocio;
using EntityLayer;
using GEN.Funciones;
using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboPaqueteSeguro : cboBase
    {
        public cboPaqueteSeguro()
        {
            InitializeComponent();
        }

        public cboPaqueteSeguro(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            ValueMember = "idPaqueteSeguro";
            DisplayMember = "cNombreCompleto";
            DropDownStyle = ComboBoxStyle.DropDownList;
            DataSource = new List<clsMantenimientoPaqueteSeguro>();
        }

        public void CargarPaqueteSeguroVenta(int idDetalleGasto, int idPerfil, int idAgencia, int idpaqueteSeguro)
        {

            if (idDetalleGasto != 1) { DataSource = new List<clsMantenimientoPaqueteSeguro>(); return; }

            // Obtengo la lista de todos los paquetes de seguro vigentes
            List<clsMantenimientoPaqueteSeguro> lstPaqueteSeguros = DataTableToList.ConvertTo<clsMantenimientoPaqueteSeguro>(new clsCNPaqueteSeguro().CNListarTodosLosPaqueteDeSeguro()) as List<clsMantenimientoPaqueteSeguro>;

            //Obtengo la lista de todos los paquetes que se pueden vender segun el perfil y la agencia
            IEnumerable<clsPaqueteSeguro> lstPaqueteSegurosPermitidos = new clsCNPaqueteSeguro().CNObtenerPaqueteSeguroVenta(0, idPerfil, idAgencia);

            //Obtengo la lista de todos los paquetes que no se pueden vender para eliminarlos de la lista principal
            var lstPaquetesAEliminar = lstPaqueteSeguros.Where(x => !lstPaqueteSegurosPermitidos.Any(p => p.idTipoSeguro == x.idTipoSeguro)).ToList();

            //Valido que la lista a eliminar no incluya el paquete previo seleccionado
            lstPaquetesAEliminar.RemoveAll(x => x.idPaqueteSeguro == idpaqueteSeguro);

            lstPaqueteSeguros.RemoveAll(x => lstPaquetesAEliminar.Any(seguro => seguro.idTipoSeguro == x.idTipoSeguro));

            ValueMember = "idPaqueteSeguro";
            DisplayMember = "cNombreCompleto";
            DataSource = lstPaqueteSeguros;
        }

        public void AgregarNinguno()
        {
            clsMantenimientoPaqueteSeguro ps = new clsMantenimientoPaqueteSeguro() { idPaqueteSeguro = -1, cNombreCompleto = "NINGUNO", cNombreCorto = "NINGUNO" };
            var list = (DataSource as List<clsMantenimientoPaqueteSeguro>) ?? new List<clsMantenimientoPaqueteSeguro>();
            list.Add(ps);
            DataSource = list.OrderBy(x=>x.idPaqueteSeguro).ToList();
        }

        public clsMantenimientoPaqueteSeguro ObtenerPaqueteSeleccionado(int idPaqueteSeguro)
        {
            var listDataSource = DataSource as List<clsMantenimientoPaqueteSeguro>;
            var item = listDataSource.Find(x => x.idPaqueteSeguro == idPaqueteSeguro);
            return item;
        }
    }
}
