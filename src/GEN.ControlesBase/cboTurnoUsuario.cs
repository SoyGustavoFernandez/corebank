using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GRH.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboTurnoUsuario : cboBase
    {
        clsCNMantenimientoHorario objHorario = new clsCNMantenimientoHorario();
        public DataTable dtTurno;

        public cboTurnoUsuario()
        {
            InitializeComponent();

            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public cboTurnoUsuario(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        
        public void ListarTurnosFechaUsuario(int idUsuario, DateTime dFecha)
        {
            dtTurno = objHorario.CNListarTurnosFechaUsuario(idUsuario, dFecha);
            this.DataSource = dtTurno;
            this.ValueMember = dtTurno.Columns["idDetalleHorario"].ToString();
            this.DisplayMember = dtTurno.Columns["cDescripcionTurno"].ToString();
        }

        public void ListarTurnosFechaUsuarioTodos(int idUsuario, DateTime dFecha)
        {
            dtTurno = objHorario.CNListarTurnosFechaUsuario(idUsuario, dFecha);

            DataRow drTodos = dtTurno.NewRow();
            drTodos["idDetalleHorario"] = 0;
            drTodos["cDescripcionTurno"] = "TODO EL DIA";
            drTodos["cHoraIngreso"] = "00:00";
            drTodos["cHoraSalida"] = "23:59";
            drTodos["nNumDias"] = 1;
            dtTurno.Rows.Add(drTodos);

            this.DataSource = dtTurno;
            this.ValueMember = dtTurno.Columns["idDetalleHorario"].ToString();
            this.DisplayMember = dtTurno.Columns["cDescripcionTurno"].ToString();
        }
    }
}
