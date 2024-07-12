using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using System.Xml.Linq;
using EntityLayer;

namespace ADM.Presentacion
{
    public partial class frmRegPcUsu : frmBase
    {
        #region Variables Globales
        List<TipoActivo> listaTipo = new List<TipoActivo>()
                { 
                    new TipoActivo(){IdTipo=2,cDescri="Por Activar"}, 
                    new TipoActivo(){IdTipo=1,cDescri="Activos"}, 
                    new TipoActivo(){IdTipo=3,cDescri="Todos"},
                }
                ;
        clsPcUsuario objdatusu = new clsPcUsuario();
        DataTable dtDatUsu;
        struct TipoActivo
        {
            public int IdTipo { get; set; }
            public string cDescri { get; set; }
        }
        struct DatoPc
        {
            public int idRegistro { get; set; }
            public bool lIndActivo { get; set; }
        }

        #endregion

        public frmRegPcUsu()
        {
            InitializeComponent();
        }

        private void frmRegPcUsu_Load(object sender, EventArgs e)
        {
           
            this.cboTipoActi.DataSource = listaTipo;
            this.cboTipoActi.ValueMember = "IdTipo";
            this.cboTipoActi.DisplayMember = "cDescri";
        }

        private void cargarLista()
        {
                
                dtDatUsu = objdatusu.listarDatosPc(((TipoActivo)this.cboTipoActi.SelectedItem).IdTipo);

                if (dtDatUsu.Rows.Count > 0)
                {
                    this.chklbDatPcUsu.DataSource = dtDatUsu;
                    this.chklbDatPcUsu.ValueMember = dtDatUsu.Columns["idRegistro"].ToString();
                    this.chklbDatPcUsu.DisplayMember = dtDatUsu.Columns["cNomPcUsu"].ToString();
                    chcSelec.Checked = true;
                    seleccionar();
                }
                else
                {
                    this.chklbDatPcUsu.DataSource = null;
                    chcSelec.Checked = false;
                }

                chklbDatPcUsu.Focus();
        }

        private void seleccionar()
        {
            for (int i = 0; i < this.chklbDatPcUsu.Items.Count; i++)
            {
                this.chklbDatPcUsu.SetItemChecked(i, true);
            }
        }

        private void deseleccionar()
        {
            for (int i = 0; i < this.chklbDatPcUsu.Items.Count; i++)
            {
                this.chklbDatPcUsu.SetItemChecked(i, false);
            }
        }

        private void chcSelec_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chcSelec.Checked)
            {
                seleccionar();
            }
            else
            {
                deseleccionar();
            }
        }

        private void cboTipoActi_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarLista();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (this.chklbDatPcUsu.CheckedItems.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un item", "Validación Accesos Pc", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<DatoPc> lisDato = new List<DatoPc>();
            List<DatoPc> lisNoChecked = new List<DatoPc>();

            foreach (DataRowView item in this.chklbDatPcUsu.CheckedItems)
            {
                lisDato.Add(new DatoPc() { idRegistro = int.Parse(item.Row["idRegistro"].ToString()),lIndActivo=true });
            }

            var dtpcs=(DataTable)this.chklbDatPcUsu.DataSource;
            foreach (DataRow item in dtpcs.Rows)
            {
                if (lisDato.Where(x => x.idRegistro == Convert.ToInt32(item["idRegistro"])).Count() == 0)
                {
                    lisNoChecked.Add(new DatoPc() { idRegistro = int.Parse(item["idRegistro"].ToString()), lIndActivo = false  });
                }
                
            }

            var xDatosPC = new XElement("Datospc", from dato in lisDato
                                                       select new XElement("Data",
                                                           new XAttribute("idRegistro", dato.idRegistro),
                                                           new XAttribute("idUsuMod",clsVarGlobal.User.idUsuario )
                                                           ));

            var xNoCheckPC = new XElement("Datospc", from dato in lisNoChecked
                                                   select new XElement("Data",
                                                       new XAttribute("idRegistro", dato.idRegistro),
                                                           new XAttribute("idUsuMod",clsVarGlobal.User.idUsuario )
                                                               ));

            objdatusu.actualizarRegDatPc(clsCNFormatoXML.EncodingXML(xDatosPC.ToString()), clsCNFormatoXML.EncodingXML(xNoCheckPC.ToString()));
            MessageBox.Show("Se grabó correctamente el listado de pc's","Registro de pc Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cargarLista();
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            cargarLista();
        }
    }
}
