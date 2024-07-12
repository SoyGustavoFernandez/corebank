using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;
using System.Diagnostics;
using GRC.CapaNegocio;
using System.IO;

namespace GRC.Presentacion
{
    public partial class frmConsultaSesion : frmBase
    {
        #region Variables

        clsCNSesionConsejo sesionconsejo = new clsCNSesionConsejo();
       
        #endregion

        public frmConsultaSesion()
        {
            InitializeComponent();
        }

        #region Eventos

        private void Form1_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            dtpIni.Value = clsVarGlobal.dFecSystem;
            dtpFin.Value = clsVarGlobal.dFecSystem;
        }
        
        private void btnBusqueda1_Click(object sender, EventArgs e)
        {
            dtgSesiones.DataSource = null;
            dtgAsistentes.DataSource = null;
            dtgDocumentos.DataSource = null;
            buscarSesiones();
            if (dtgSesiones.Rows.Count>0)
            { 
                formatoGridSesiones();
                cargarDocumentos();
                if (dtgDocumentos.Rows.Count > 0)
                {
                    formatoGridDocumento();
                }
                cargarAsistentes();
                if (dtgAsistentes.Rows.Count>0)
                {
                    formatoGridAsistentes();
                }
            }
        }
        
        private void btnImprimir1_Click(object sender, EventArgs e)
        {

        }

        private void dtgDocumentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgDocumentos.Columns[e.ColumnIndex].Name == "ver")
            {
                verArchivo();
            }
        }

        private void dtgSesisones_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgSesiones.Rows.Count > 0)
            {
                cargarDocumentos();
                if (dtgDocumentos.Rows.Count > 0)
                {
                    formatoGridDocumento();
                }
                cargarAsistentes();
                if (dtgAsistentes.Rows.Count > 0)
                {
                    formatoGridAsistentes();
                }
            }
        }

        #endregion

        #region Metodos

        private void verArchivo()
        {
            if (dtgDocumentos.Rows.Count > 0)
            {
                int idDocumentoSesion = Convert.ToInt32(dtgDocumentos.SelectedRows[0].Cells["idDocumentoSesion"].Value);

                Byte[] data = new Byte[0];
                data = (Byte[])(this.dtgDocumentos.SelectedRows[0].Cells["vDocumentoSesion"].Value);

                Guid gNombreArc = Guid.NewGuid();

                string cRutaNombre = @"c:\solintels\tmp\" + gNombreArc.ToString() + dtgDocumentos.SelectedRows[0].Cells["cExtension"].Value.ToString();

                using (FileStream fsArchivo = new FileStream(cRutaNombre, FileMode.Create, FileAccess.ReadWrite))
                {
                    using (BinaryWriter bwArchivo = new BinaryWriter(fsArchivo))
                    {
                        bwArchivo.Write(data);
                        bwArchivo.Close();
                    }
                }
                Process abreDocumento = new Process();
                abreDocumento.StartInfo.FileName = cRutaNombre;
                abreDocumento.Start();
            }
        }

        private void buscarSesiones()
        {
            dtgSesiones.DataSource = null;
            var dtSesiones = sesionconsejo.BusquedaSesiones(Convert.ToInt32(cboTipoSesion1.SelectedValue),
                Convert.ToInt32(cboTipoConsejo1.SelectedValue), dtpIni.Value.Date, dtpFin.Value.Date);
            if (dtSesiones.Rows.Count>0)
            {                
                dtgSesiones.DataSource = dtSesiones;                
            }
        }

        private void formatoGridSesiones()
        {
            foreach (DataGridViewColumn item in dtgSesiones.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.Visible = false;
            }

            dtgSesiones.Columns["cConsejo"].Visible = true;
            dtgSesiones.Columns["cSesionConsejo"].Visible = true;
            dtgSesiones.Columns["dFecReg"].Visible = true;

            dtgSesiones.Columns["cConsejo"].HeaderText = "Nombre de Consejo";
            dtgSesiones.Columns["cSesionConsejo"].HeaderText = "Descripción de la Sesión";
            dtgSesiones.Columns["dFecReg"].HeaderText = "Fecha de la Sesión de Consejo";
            
        }

        private void cargarDocumentos()
        {
            dtgDocumentos.DataSource = null;
            if (dtgSesiones.SelectedRows.Count>0)
            {
                var idSesionConsejo = Convert.ToInt32(dtgSesiones.SelectedRows[0].Cells["idSesionConsejo"].Value);
                var dtDocumentos = sesionconsejo.ListarDocumentosSesionid(idSesionConsejo);

                dtgDocumentos.Columns.Clear();
                if (dtDocumentos.Rows.Count>0)
                {
                    dtgDocumentos.DataSource = dtDocumentos;
                }
            }
        }

        private void formatoGridDocumento()
        {
            foreach (DataGridViewColumn item in dtgDocumentos.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.Visible = false;
            }

            dtgDocumentos.Columns["cDocumentoSesion"].Visible = true;

            dtgDocumentos.Columns["cDocumentoSesion"].HeaderText = "Documento";

            DataGridViewButtonColumn btnColumnVer = new DataGridViewButtonColumn();
            btnColumnVer.HeaderText = "Ver";
            btnColumnVer.Text = "Vista";
            btnColumnVer.UseColumnTextForButtonValue = true;
            btnColumnVer.Name = "ver";
            dtgDocumentos.Columns.Insert(3, btnColumnVer);

            dtgDocumentos.Columns[3].Width = 40;
        }

        private void cargarAsistentes()
        {
            dtgAsistentes.DataSource = null;
            if (dtgSesiones.SelectedRows.Count>0)
            {
                var idSesionconsejo = Convert.ToInt32(dtgSesiones.SelectedRows[0].Cells["idSesionConsejo"].Value);
                var dtAsistente = sesionconsejo.ListarDetalleSesionidSesionConsejo(idSesionconsejo);
                if (dtAsistente.Rows.Count>0)
                {
                    dtgAsistentes.DataSource = dtAsistente;
                }
            }            
        }

        private void formatoGridAsistentes()
        {
            foreach (DataGridViewColumn item in dtgAsistentes.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.Visible = false;
            }

            dtgAsistentes.Columns["cNombre"].Visible = true;
            dtgAsistentes.Columns["cNombre"].HeaderText = "Nombres";
        }
        
        #endregion
    }
}
