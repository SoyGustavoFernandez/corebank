using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class ConBusCol : UserControl
    {
        public string idUsu, cNom, cDocID, idCargoPer, cCargoPer, idCliPer, idAgencia, idRelLab, idEstUsu, idArea;
        public int nPorLibVia;
        public event EventHandler BuscarUsuario;
        private string _cEstado = "0";
        public bool lMinDat;

        [Browsable(true),
        Description("Indica el estado del personal a buscar, 0=>Todos, 1=>Activos, 2=>Cesados")]
        public string cEstado
        {
            get { return _cEstado; }

            set { _cEstado = value; }
        }
        public ConBusCol()
        {
            InitializeComponent();
        }

        private void txtCod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                CleanData();
                BusPerByCod();
                if (BuscarUsuario != null)
                    BuscarUsuario(sender, e);
            }
        }

        public void BusPerByCod()
        {
            if (txtCod.Text == "")
            {
                MessageBox.Show(this, "Debe asignar un codigo de usuario valido", "Progresando", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CleanData();
                FillData();
                return;
            }
            clsCNBuscaPersonal lisPer = new clsCNBuscaPersonal();
            DataTable dtPer = lisPer.BusPerByCod(Convert.ToInt32(txtCod.Text), Convert.ToInt32(_cEstado), lMinDat);

            if (dtPer.Rows.Count > 0)
            {
                idUsu = Convert.ToString(dtPer.Rows[0]["idUsuario"]);
                idCliPer = Convert.ToString(dtPer.Rows[0]["idCli"]);
                cNom = Convert.ToString(dtPer.Rows[0]["cNombre"]);
                cDocID = Convert.ToString(dtPer.Rows[0]["cDocumentoID"]);
                idRelLab = Convert.ToString(dtPer.Rows[0]["idRelacionLab"]);
                idCargoPer = Convert.ToString(dtPer.Rows[0]["idCargo"]);
                cCargoPer = Convert.ToString(dtPer.Rows[0]["cCargo"]);
                idEstUsu = Convert.ToString(dtPer.Rows[0]["idEstado"]);
                nPorLibVia = Convert.ToInt32(dtPer.Rows[0]["nPorcenLibreVia"]);
                idAgencia = Convert.ToString(dtPer.Rows[0]["idAgencia"]);
                idArea = Convert.ToString(dtPer.Rows[0]["idArea"]);
                txtCod.Enabled = false;
            }
            else
            {
                CleanData();
            }

            FillData();

        }

        public void LimpiarDatos()
        {
            this.txtCod.Text = "";
            this.txtCargo.Text = "";
            this.txtNom.Text = "";
            this.idUsu = "";
        }

        private void FillData()
        {
            txtCod.Text = idUsu;
            txtCargo.Text = cCargoPer;
            txtNom.Text = cNom;
        }

        private void CleanData()
        {
            idUsu = "";
            idCliPer = "";
            cNom = "";
            cDocID = "";
            idRelLab = "";
            idCargoPer = "";
            cCargoPer = "";
            idEstUsu = "";
            nPorLibVia = 0;
            idAgencia = "";
            idArea = "";
        }

        public void HabilitarControles(bool lHabilitar)
        {
            txtCod.Enabled = lHabilitar;
            btnConsultar.Enabled = lHabilitar;
        }

        private void btnConsultar1_Click(object sender, EventArgs e)
        {
            CleanData();
            FrmBusCol frm = new FrmBusCol();
            frm.cEstado = _cEstado;
            frm.ShowDialog();
            if (frm.idUsu != "")
            {
                idUsu = frm.idUsu;
                idCliPer = frm.idCliPer;
                cNom = frm.cNom;
                cDocID = frm.cDocID;
                idRelLab = frm.idRelLab;
                idCargoPer = frm.idCargoPer;
                cCargoPer = frm.cCargoPer;
                idEstUsu = frm.idEstUsu;
                nPorLibVia = frm.nPorLibVia;
                idAgencia = frm.nidAgencia;
                idArea = frm.nidArea;
            }
            FillData();
            if (BuscarUsuario != null)
                BuscarUsuario(sender, e);
        }

        private void grbBase1_Enter(object sender, EventArgs e)
        {

        }

        public void CargarColaboradorxUsuario(int idUsuario)
        {
            txtCod.Text = Convert.ToString(idUsuario);
            CleanData();
            BusPerByCod();
        }

        public bool ValidarColaboradorSeleccionado()
        {
            if (string.IsNullOrEmpty(this.idUsu))// cambiar verificación
            {
                return false;
            }

            return true;
        }

        public void Reset()
        {
            this.CleanData();
            this.LimpiarDatos();
            this.HabilitarControles(true);
        }
    }
}
