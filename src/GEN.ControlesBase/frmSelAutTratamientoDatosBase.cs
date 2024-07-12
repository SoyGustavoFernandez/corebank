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
    public partial class frmSelAutTratamientoDatosBase : frmBase
    {
        ListaAutorizaTratamientoUsoDatos lstData;
        public AutorizaTratamientoUsoDatos datasel;
        public bool lAceptar = false;

        public frmSelAutTratamientoDatosBase()
        {
            InitializeComponent();
        } 
        public frmSelAutTratamientoDatosBase(ListaAutorizaTratamientoUsoDatos lstDataSend)
        {
            InitializeComponent();
            lstData = lstDataSend;
            BuscarAutTratamientoDatos();
        }
         private void BuscarAutTratamientoDatos()
         {
           
             this.dtgDatoAutorizacion.DataSource = lstData.Where(x=>x.idEstado==1).ToList();
             if (lstData.Count()>0)
             {
                 datasel = lstData[0];
             }
              
                 dtgDatoAutorizacion.Columns["cDescripcion"].Width = 110;
                 dtgDatoAutorizacion.Columns["cDescripcion"].Visible = false;
                 dtgDatoAutorizacion.Columns["idAutTraDatos"].Visible = false;
                 dtgDatoAutorizacion.Columns["cTelefono"].Visible = false;
                 dtgDatoAutorizacion.Columns["idCli"].Visible = false;
                 dtgDatoAutorizacion.Columns["idTipoDocumento"].Visible = false;
                 dtgDatoAutorizacion.Columns["cNroDocumento"].Visible = false;
                 dtgDatoAutorizacion.Columns["cNomCliente"].Visible = false;
                 dtgDatoAutorizacion.Columns["cDireccion"].Visible = false;
                 dtgDatoAutorizacion.Columns["idRegion"].Visible = false;
                 dtgDatoAutorizacion.Columns["idOficina"].Visible = false;
                 dtgDatoAutorizacion.Columns["cCodCliente"].Visible = false;
                 dtgDatoAutorizacion.Columns["cCodigoCuenta"].Visible = false;
                 dtgDatoAutorizacion.Columns["cResponsable"].Visible = false;
         
                 dtgDatoAutorizacion.Columns["idTipoAutorizacion"].Visible = false;
                 dtgDatoAutorizacion.Columns["idCanalRegistro"].Visible = false;
                 dtgDatoAutorizacion.Columns["idEstado"].Visible = false;
                 dtgDatoAutorizacion.Columns["idUsuRegistro"].Visible = false;
                 dtgDatoAutorizacion.Columns["dFecRegistro"].Visible = false;
                 dtgDatoAutorizacion.Columns["idUsuModifica"].Visible = false;
                 dtgDatoAutorizacion.Columns["dFecModifica"].Visible = false;
         
                 dtgDatoAutorizacion.Columns["IdTipoPersona"].Visible = false;
                 dtgDatoAutorizacion.Columns["cArchivoBinary"].Visible = false;
         
                 dtgDatoAutorizacion.Columns["nTiempoVigencia"].HeaderText = "Tiempo Vigencia";
                 dtgDatoAutorizacion.Columns["nTiempoVigencia"].Width = 60;
                 dtgDatoAutorizacion.Columns["nTiempoVigencia"].Visible = false;
         
                 dtgDatoAutorizacion.Columns["cRegion"].HeaderText = "Región";
                 dtgDatoAutorizacion.Columns["cRegion"].Width = 70;
                 dtgDatoAutorizacion.Columns["cRegion"].Visible = false;
         
                 dtgDatoAutorizacion.Columns["cOficina"].HeaderText = "Oficina";
                 dtgDatoAutorizacion.Columns["cOficina"].Width = 70;
                 dtgDatoAutorizacion.Columns["cOficina"].Visible = false;

                 dtgDatoAutorizacion.Columns["cTipoAutorizacion"].HeaderText = "Tipo Autoriación";
                 dtgDatoAutorizacion.Columns["cTipoAutorizacion"].Width = 140;
         
                 dtgDatoAutorizacion.Columns["cCanalRegistro"].HeaderText = "Canal";
                 dtgDatoAutorizacion.Columns["cCanalRegistro"].Width = 60;
                 dtgDatoAutorizacion.Columns["cCanalRegistro"].Visible = false;
          
                 dtgDatoAutorizacion.Columns["lIndicadorConcentimiento"].Visible = false;
         
                 dtgDatoAutorizacion.Columns["cEstado"].HeaderText = "Estado";
                 dtgDatoAutorizacion.Columns["cEstado"].Width = 80;
         
                 dtgDatoAutorizacion.Columns["dFechaInicio"].HeaderText = "Fec. Inicio";
                 dtgDatoAutorizacion.Columns["dFechaInicio"].Width = 70;
         
                 dtgDatoAutorizacion.Columns["dFechaFin"].HeaderText = "Fec. Fin";
                 dtgDatoAutorizacion.Columns["dFechaFin"].Width = 70;
         
         
         
                 dtgDatoAutorizacion.Columns["lVigente"].Width = 30;
                 dtgDatoAutorizacion.Columns["lVigente"].HeaderText = "Vig.";
                 dtgDatoAutorizacion.Columns["lVigente"].Visible = false;
         
                 dtgDatoAutorizacion.Columns["cUsoRegistro"].Visible = false;
                 dtgDatoAutorizacion.Columns["cFecRegistro"].Visible = false;
         
         
                 dtgDatoAutorizacion.Columns["cArchivo"].Visible = false;
                 dtgDatoAutorizacion.Columns["bArchivoBinary"].Visible = false;
                 dtgDatoAutorizacion.Columns["idModalidad"].Visible = false;
                 dtgDatoAutorizacion.Columns["idMotivo"].Visible = false;
         
                 dtgDatoAutorizacion.Columns["cModalidad"].Visible = false;
                 dtgDatoAutorizacion.Columns["cMotivo"].Visible = false; 
                 dtgDatoAutorizacion.Columns["cVerDocumento"].Visible = false;
                 dtgDatoAutorizacion.Columns["dFecDesistimiento"].Visible = false;
                 dtgDatoAutorizacion.Columns["cMotDesistimiento"].Visible = false;
                 dtgDatoAutorizacion.Columns["cDescDesistimiento"].Visible = false;
                 dtgDatoAutorizacion.Columns["idArchivo"].Visible = false;
                 dtgDatoAutorizacion.Columns["idEstablecimiento"].Visible = false;
                 dtgDatoAutorizacion.Columns["cEstablecimiento"].Visible = false; 
         } 
          
        private void dtgDatoAutorizacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dtgDatoAutorizacion.CommitEdit(DataGridViewDataErrorContexts.Commit);
            if (e.RowIndex < 0)
            {
                return;
            }
            datasel = (AutorizaTratamientoUsoDatos)dtgDatoAutorizacion.CurrentRow.DataBoundItem;
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (datasel != null)
            {
                if (lstData.Count(x => x.idTipoAutorizacion == 1) >= 1)
                {
                    if (datasel.idTipoAutorizacion == 3)//Tratamei
                    {
                        MessageBox.Show("Primero debe desistir el tipo " + lstData.FirstOrDefault(x => x.idTipoAutorizacion == 1).cTipoAutorizacion +".", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else if (datasel.idTipoAutorizacion == 2)
                    {
                        MessageBox.Show("Si el cliente solo requiere desistir de la recepción de PUBLICIDAD debe hacerlo desde el formulario de ''Gestión de autorización de tratamiento de datos''.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                     

                }
               
                this.lAceptar = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("No existe dato seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
           
        } 

        private void dtgDatoAutorizacion_RowEnter(object sender, DataGridViewCellEventArgs e)
        { 
        }

        private void frmSelAutTratamientoDatosBase_Load(object sender, EventArgs e)
        {

        }

        private void dtgDatoAutorizacion_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dtgDatoAutorizacion.CommitEdit(DataGridViewDataErrorContexts.Commit);
            if (e.RowIndex < 0)
            {
                return;
            }
            datasel = (AutorizaTratamientoUsoDatos)dtgDatoAutorizacion.CurrentRow.DataBoundItem;
        }

        private void dtgDatoAutorizacion_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dtgDatoAutorizacion.CommitEdit(DataGridViewDataErrorContexts.Commit);
            if (e.RowIndex < 0)
            {
                return;
            }
            datasel = (AutorizaTratamientoUsoDatos)dtgDatoAutorizacion.CurrentRow.DataBoundItem;
        }
    }
}
