using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using CRE.CapaNegocio;
using EntityLayer;


namespace CRE.Presentacion
{
    public partial class frmAprobaExcepcionesCred : frmBase
    {
        int nNivelActual;
        int nNivelAprobacion;
        int idSolicitud;
        int idSolicitudCredGrupoSol;

        DataTable dtExcepciones = new DataTable();

        clsCNExcepcionesCreditos cnexcepcionesCreditos = new clsCNExcepcionesCreditos();

        public frmAprobaExcepcionesCred()
        {
            InitializeComponent();
        }

        public frmAprobaExcepcionesCred(int nNivelActual, int nNivelAprobacion, int idSolicitud, int idSolicitudCredGrupoSol)
        {
            InitializeComponent();
            this.nNivelActual = nNivelActual;
            this.nNivelAprobacion = nNivelAprobacion;
            this.idSolicitud = idSolicitud;
            this.idSolicitudCredGrupoSol = idSolicitudCredGrupoSol;
        }

        private void frmAprobaExcepcionesCred_Load(object sender, EventArgs e)
        {
            CargarVista();
        }

        private void CargarVista()
        {
            dtgBase1.DataSource = null;
            dtgBase1.ClearSelection();
            dtgBase1.Rows.Clear();
            dtgBase1.Columns.Clear();
            cargarExcepciones();

            if (nNivelActual == nNivelAprobacion)
            {
                formatGridNivelAprueba();
            }
            else
            {
                formatGridNivelPrevio();
            }
            DarColorGridReglas();
        }

        public void cargarExcepciones()
        {
            if (idSolicitudCredGrupoSol == 0)
            {
                dtExcepciones = cnexcepcionesCreditos.cargarDatosExcepciones(idSolicitud);
            }
            else
            {
                dtExcepciones = cnexcepcionesCreditos.cargarDatosExcepcionesGrupoSolidario(idSolicitudCredGrupoSol);
            }
            

            if (dtExcepciones.Rows.Count > 0)
            {
                dtgBase1.DataSource = dtExcepciones;
            }

            nroExcepciones.Text = dtExcepciones.Rows.Count.ToString();
        }

        public void formatGridNivelPrevio()
        {
            foreach (DataGridViewColumn columna in dtgBase1.Columns)
            {
                columna.Visible = false;
            }

            dtgBase1.ReadOnly = false;
            //dtgBase1.Columns["idExcepGen"].Visible = true;
            //dtgBase1.Columns["idSolicitud"].Visible = true;
            //dtgBase1.Columns["idCliente"].Visible = true;
            //dtgBase1.Columns["idTipoOperacion"].Visible = true;
            //dtgBase1.Columns["nIdOpcion"].Visible = true;
            //dtgBase1.Columns["dFecSolici"].Visible = true;
            //dtgBase1.Columns["cProducto"].Visible = true;
            dtgBase1.Columns["nIdRegla"].Visible = true;
            dtgBase1.Columns["cMensajeError"].Visible = true;
            //dtgBase1.Columns["lAutomatico"].Visible = true;
            //dtgBase1.Columns["idUsuRegist"].Visible = true;
            //dtgBase1.Columns["cWinUser"].Visible = true;
            dtgBase1.Columns["cEstadoExcepcion"].Visible = true;

            ////
            //dtgBase1.Columns["idExcepGen"].Visible = true;
            //dtgBase1.Columns["idSolicitud"].HeaderText = "Solicitud";
            //dtgBase1.Columns["idCliente"].Visible = true;
            //dtgBase1.Columns["idTipoOperacion"].Visible = true;
            //dtgBase1.Columns["nIdOpcion"].Visible = true;
            //dtgBase1.Columns["dFecSolici"].HeaderText = "Fec Solicitud";
            //dtgBase1.Columns["cProducto"].HeaderText = "Producto";
            dtgBase1.Columns["nIdRegla"].HeaderText = "Id. ";
            dtgBase1.Columns["cMensajeError"].HeaderText = "Descripción de Excepción";
            //dtgBase1.Columns["lAutomatico"].Visible = true;
            //dtgBase1.Columns["idUsuRegist"].Visible = true;
            //dtgBase1.Columns["cWinUser"].HeaderText = "Asesor";
            dtgBase1.Columns["cEstadoExcepcion"].HeaderText = "Estado";


            //dtgBase1.Columns["cMensajeError"].Width = 100;


            ////
            //dtgBase1.Columns["idExcepGen"].Visible = true;
            //dtgBase1.Columns["idSolicitud"].Width = 30;
            //dtgBase1.Columns["idCliente"].Visible = true;
            //dtgBase1.Columns["idTipoOperacion"].Visible = true;
            //dtgBase1.Columns["nIdOpcion"].Visible = true;
            //dtgBase1.Columns["dFecSolici"].Width = 35;
            //dtgBase1.Columns["cProducto"].Width = 50;
            //dtgBase1.Columns["nIdRegla"].Width = 40;
            //dtgBase1.Columns["cMensajeError"].Width = 300;
            //dtgBase1.Columns["lAutomatico"].Visible = true;
            //dtgBase1.Columns["idUsuRegist"].Visible = true;
            //dtgBase1.Columns["cWinUser"].Width = 50;
            //dtgBase1.Columns["cEstadoExcepcion"].Width = 80;
            
            DataGridViewButtonColumn btnAcepta = new DataGridViewButtonColumn();
            dtgBase1.Columns.Add(btnAcepta);
            btnAcepta.HeaderText = "Aceptar";
            btnAcepta.Text = "Aceptar";
            btnAcepta.Name = "btnAceptar";
            btnAcepta.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn btnDesestima = new DataGridViewButtonColumn();
            dtgBase1.Columns.Add(btnDesestima);
            btnDesestima.HeaderText = "Desestimar";
            btnDesestima.Text = "Desestimar";
            btnDesestima.Name = "btnDesestimar";
            btnDesestima.UseColumnTextForButtonValue = true;

            dtgBase1.Columns[8].Width = 70;
            dtgBase1.Columns[9].Width = 364;
            dtgBase1.Columns[14].Width = 95;
            dtgBase1.Columns[15].Width = 76;
            dtgBase1.Columns[16].Width = 76;

            if (idSolicitudCredGrupoSol != 0)
            {
                dtgBase1.Columns["idSolicitud"].Visible = true;
                dtgBase1.Columns["idSolicitud"].HeaderText = "Solicitud";
                dtgBase1.Columns["idSolicitud"].Width = 64;
                dtgBase1.Columns[9].Width = 300;
            }
            foreach (DataGridViewColumn item in dtgBase1.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;

            }
            dtgBase1.ReadOnly = true;
        }
        private void DarColorGridReglas()//Pintará las reglas no excepcionables de un color diferente
        {
            int ExcepAutomaticas = 0;
            int ExcepManuales = 0;
            foreach (DataGridViewRow dr in dtgBase1.Rows)
            {
                if (Convert.ToInt32(dr.Cells["lAutomatico"].Value) == 0)
                {
                    dr.DefaultCellStyle.BackColor = Color.FromArgb(255, 222, 188);
                }
                else
                {
                    dr.DefaultCellStyle.BackColor = Color.FromArgb(173, 239, 156);                    
                }
            }
        }

        public void formatGridNivelAprueba()
        {
            foreach (DataGridViewColumn columna in dtgBase1.Columns)
            {
                columna.Visible = false;
            }

            dtgBase1.ReadOnly = false;
            //dtgBase1.Columns["idExcepGen"].Visible = true;
            //dtgBase1.Columns["idSolicitud"].Visible = true;
            //dtgBase1.Columns["idCliente"].Visible = true;
            //dtgBase1.Columns["idTipoOperacion"].Visible = true;
            //dtgBase1.Columns["nIdOpcion"].Visible = true;
            //dtgBase1.Columns["dFecSolici"].Visible = true;
            //dtgBase1.Columns["cProducto"].Visible = true;
            dtgBase1.Columns["nIdRegla"].Visible = true;
            dtgBase1.Columns["cMensajeError"].Visible = true;
            //dtgBase1.Columns["lAutomatico"].Visible = true;
            //dtgBase1.Columns["idUsuRegist"].Visible = true;
            //dtgBase1.Columns["cWinUser"].Visible = true;
            dtgBase1.Columns["cEstadoExcepcion"].Visible = true;

            ////
            //dtgBase1.Columns["idExcepGen"].Visible = true;
            //dtgBase1.Columns["idSolicitud"].HeaderText = "Solicitud";
            //dtgBase1.Columns["idCliente"].Visible = true;
            //dtgBase1.Columns["idTipoOperacion"].Visible = true;
            //dtgBase1.Columns["nIdOpcion"].Visible = true;
            //dtgBase1.Columns["dFecSolici"].HeaderText = "Fec Solicitud";
            //dtgBase1.Columns["cProducto"].HeaderText = "Producto";
            dtgBase1.Columns["nIdRegla"].HeaderText = "Id. Regla";
            dtgBase1.Columns["cMensajeError"].HeaderText = "Regla";
            //dtgBase1.Columns["lAutomatico"].Visible = true;
            //dtgBase1.Columns["idUsuRegist"].Visible = true;
            //dtgBase1.Columns["cWinUser"].HeaderText = "Asesor";
            dtgBase1.Columns["cEstadoExcepcion"].HeaderText = "Estado";


            //dtgBase1.Columns["cMensajeError"].Width = 100;


            ////
            //dtgBase1.Columns["idExcepGen"].Visible = true;
            //dtgBase1.Columns["idSolicitud"].Width = 30;
            //dtgBase1.Columns["idCliente"].Visible = true;
            //dtgBase1.Columns["idTipoOperacion"].Visible = true;
            //dtgBase1.Columns["nIdOpcion"].Visible = true;
            //dtgBase1.Columns["dFecSolici"].Width = 35;
            //dtgBase1.Columns["cProducto"].Width = 50;
            //dtgBase1.Columns["nIdRegla"].Width = 40;
            //dtgBase1.Columns["cMensajeError"].Width = 300;
            //dtgBase1.Columns["lAutomatico"].Visible = true;
            //dtgBase1.Columns["idUsuRegist"].Visible = true;
            //dtgBase1.Columns["cWinUser"].Width = 50;
            //dtgBase1.Columns["cEstadoExcepcion"].Width = 80;

            DataGridViewButtonColumn btnAprobar = new DataGridViewButtonColumn();
            dtgBase1.Columns.Add(btnAprobar);
            btnAprobar.HeaderText = "Aprobar";
            btnAprobar.Text = "Aprobar";
            btnAprobar.Name = "btnAprobar";
            btnAprobar.UseColumnTextForButtonValue = true;
            
            DataGridViewButtonColumn btnRechazar = new DataGridViewButtonColumn();
            dtgBase1.Columns.Add(btnRechazar);
            btnRechazar.HeaderText = "Rechazar";
            btnRechazar.Text = "Rechazar";
            btnRechazar.Name = "btnRechazar";
            btnRechazar.UseColumnTextForButtonValue = true;


            if (idSolicitudCredGrupoSol != 0)
            {
                dtgBase1.Columns["idSolicitud"].Visible = true;
                dtgBase1.Columns["idSolicitud"].HeaderText = "Solicitud";
                dtgBase1.Columns["idSolicitud"].Width = 64;
                dtgBase1.Columns[9].Width = 300;
            }

            foreach (DataGridViewColumn item in dtgBase1.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            
        }
        private void UpdateDTG()
        {
            //foreach (System.Data.DataColumn col in dtgBase1.Columns) col.ReadOnly = false;
            foreach (DataGridViewColumn columna in dtgBase1.Columns)
            {
                columna.ReadOnly = false;
            }
        }
        private void dtgBase1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int idExcepGen = 0;
            int idSolicitud = 0;
            if (e.RowIndex >= 0)
            {
                idExcepGen = Convert.ToInt32(dtgBase1.Rows[e.RowIndex].Cells["idExcepGen"].Value.ToString());
                idSolicitud = Convert.ToInt32(dtgBase1.Rows[e.RowIndex].Cells["idSolicitud"].Value.ToString());   
            }

            if (e.ColumnIndex == 15 && e.RowIndex >= 0) // Aceptar - Aprobar
            {
                dtExcepciones = cnexcepcionesCreditos.GuardaOpinionExcepciones(nNivelActual, nNivelAprobacion, idSolicitud, idExcepGen, 3, clsVarGlobal.User.idUsuario);

                
                if (dtExcepciones.Rows.Count > 0)
                {
                    MessageBox.Show("Datos Registrados Correctamente", "Excepciones", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarVista();
                }

            }

            if (e.ColumnIndex == 16 && e.RowIndex >= 0) //Desestimar
            {
                dtExcepciones = cnexcepcionesCreditos.GuardaOpinionExcepciones(nNivelActual, nNivelAprobacion, idSolicitud, idExcepGen, 2, clsVarGlobal.User.idUsuario);

                
                if (dtExcepciones.Rows.Count > 0)
                {
                    MessageBox.Show("Datos Registrados Correctamente", "Excepciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //dtgBase1.Rows[e.RowIndex].Cells["cEstadoExcepcion"].Value = "Desestimado";
                    CargarVista();
                }
                
            }
        
        }

        
    }
}
