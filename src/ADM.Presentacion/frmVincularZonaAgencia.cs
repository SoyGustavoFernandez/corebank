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
using GEN.CapaNegocio;

namespace ADM.Presentacion
{
    public partial class frmVincularZonaAgencia : frmBase
    {
        #region Variable Globales

        clsCNRegionZona cnregionzona = new clsCNRegionZona();
        clsCNAgencia cnagencia = new clsCNAgencia();
        lstBase lstboxsel;

        #endregion

        public frmVincularZonaAgencia()
        {
            InitializeComponent();
            this.lstAgencias.AllowDrop = true;
            this.lstZonaAge.AllowDrop = true;

            lstAgencias.MouseDown += lstAgencias_MouseDown;
            lstZonaAge.MouseDown += lstZonaAge_MouseDown;

            lstZonaAge.DragOver += lstZonaAge_DragOver;
            lstAgencias.DragOver += lstAgencias_DragOver;

            lstZonaAge.DragDrop += lstZonaAge_DragDrop;
            lstAgencias.DragDrop += lstAgencias_DragDrop;
        }
        
        #region Eventos

        private void frmBase_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
            cargarOficinas();
            cargarZonas();
        }

        private void lstAgencias_MouseDown(object sender, MouseEventArgs e)
        {
            if (lstAgencias.Items.Count == 0)
                return;
            lstboxsel = lstAgencias;
            int index = lstAgencias.IndexFromPoint(e.X, e.Y);
            if (index>-1)
            {
                string s = lstAgencias.Items[index].ToString();
                DragDropEffects dde1 = DoDragDrop(s, DragDropEffects.All);

                if (dde1 == DragDropEffects.All)
                {
                    lstAgencias.Items.RemoveAt(lstAgencias.IndexFromPoint(e.X, e.Y));
                }
            }            
        }

        private void lstZonaAge_MouseDown(object sender, MouseEventArgs e)
        {
            if (lstZonaAge.Items.Count == 0)
                return;
            lstboxsel = lstZonaAge;
            int index = lstZonaAge.IndexFromPoint(e.X, e.Y);
            if (index > -1)
            {
                string s = lstZonaAge.Items[index].ToString();
                DragDropEffects dde1 = DoDragDrop(s, DragDropEffects.All);

                if (dde1 == DragDropEffects.All)
                {
                    lstZonaAge.Items.RemoveAt(lstZonaAge.IndexFromPoint(e.X, e.Y));

                }
            }
        }

        private void lstAgencias_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void lstZonaAge_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void lstAgencias_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {                
                Item obj = new Item();

                Item objSel = this.lstboxsel.SelectedItem as Item;
                if (objSel != null)
                {
                    obj.cText = objSel.cText;
                    obj.cValue = objSel.cValue;
                }

                this.lstAgencias.Items.Add(obj);
            }
        }

        private void lstZonaAge_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                Item obj = new Item();

                Item objSel = this.lstboxsel.SelectedItem as Item;
                if (objSel != null)
                {
                    obj.cText = objSel.cText;
                    obj.cValue = objSel.cValue;
                }
                this.lstZonaAge.Items.Add(obj);
            }
        }

        private void cboZona_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarZonaOficina();
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            habilitarControles(true);
            btnEditar1.Enabled = false;
            btnCancelar1.Enabled = true;
            btnGrabar1.Enabled = true;
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            cargarOficinas();
            cargarZonas();
            habilitarControles(false);
            btnEditar1.Enabled = true;
            btnCancelar1.Enabled = false;
            btnGrabar1.Enabled = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (lstAgencias.SelectedItems.Count > 0)
            {
                Item obj = new Item();

                Item objSel = this.lstAgencias.SelectedItem as Item;
                if (objSel != null)
                {
                    obj.cText = objSel.cText;
                    obj.cValue = objSel.cValue;
                }
                this.lstZonaAge.Items.Add(obj);
                lstAgencias.Items.RemoveAt(lstAgencias.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Seleccione la agencia por favor", "Paso a Región-zona", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (lstZonaAge.SelectedItems.Count > 0)
            {
                Item obj = new Item();

                Item objSel = this.lstZonaAge.SelectedItem as Item;
                if (objSel != null)
                {
                    obj.cText = objSel.cText;
                    obj.cValue = objSel.cValue;
                }
                this.lstAgencias.Items.Add(obj);
                lstZonaAge.Items.RemoveAt(lstZonaAge.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Seleccione la agencia por favor", "Paso a Región-zona", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                int idZona = (int)cboZona.SelectedValue;
                var dtResul = cnregionzona.CNVincularRegionZonaOficina(retornarXml());

                MessageBox.Show(dtResul.Rows[0][1].ToString(), "Registro de vinculación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cargarOficinas();
                cargarZonas();
                habilitarControles(false);
                cboZona.SelectedValue = idZona;
                btnEditar1.Enabled = true;
                btnCancelar1.Enabled = false;
                btnGrabar1.Enabled = false;
            }
        }

        #endregion

        #region Métodos

        private bool validar()
        {
            bool lValida = false;

            lValida = true;
            return lValida;
        }
       
        private void cargarOficinas()
        {
            lstAgencias.Items.Clear();
            foreach (DataRow item in cnregionzona.CNListarOficinaSinZona().Rows)
            {
                lstAgencias.Items.Add(new Item()
                {
                    cValue = item["idAgencia"].ToString(),
                    cText = item["cNombreAge"].ToString()
                });
            }
        }

        private void cargarZonas()
        {
            cboZona.DisplayMember = "cDesZona";
            cboZona.ValueMember = "idZona";
            cboZona.DataSource = cnregionzona.CNListarZona();
        }

        private void cargarZonaOficina()
        {
            this.lstZonaAge.Items.Clear();
            foreach (DataRow item in this.cnregionzona.CNListarOficinaByZona((int)cboZona.SelectedValue).Rows)
            {
                this.lstZonaAge.Items.Add(new Item()
                {
                    cValue = item["idAgencia"].ToString(),
                    cText = item["cNombreAge"].ToString()
                });
            }
        }

        private void habilitarControles(bool lEstado)
        {
            lstZonaAge.Enabled = lEstado;
            lstAgencias.Enabled = lEstado;
            btnAgregar.Enabled = lEstado;
            btnQuitar.Enabled = lEstado;
            cboZona.Enabled = !lEstado;
        }

        private string retornarXml()
        {
            DataSet dsAgeZona = new DataSet("dsAgeZona");
            DataTable dtAgeSinZona = new DataTable("dtAgeSinZona");
            dtAgeSinZona.Columns.Add("idAgencia", typeof(int)); 

            DataTable dtAgeZona = new DataTable("dtAgeZona");
            dtAgeZona.Columns.Add("idAgencia", typeof(int));
            dtAgeZona.Columns.Add("idZona", typeof(int));

            foreach (Item item in lstAgencias.Items)
            {
                DataRow drAge=dtAgeSinZona.NewRow();
                drAge["idAgencia"] = item.cValue;
                dtAgeSinZona.Rows.Add(drAge);
            }

            foreach (Item item in this.lstZonaAge.Items)
            {
                DataRow drAge = dtAgeZona.NewRow();
                drAge["idAgencia"] = item.cValue;
                drAge["idZona"] = cboZona.SelectedValue;
                dtAgeZona.Rows.Add(drAge);
            }

            dsAgeZona.Tables.Add(dtAgeSinZona);
            dsAgeZona.Tables.Add(dtAgeZona);

            return dsAgeZona.GetXml();
        }

        #endregion

    }

    public class Item
    {
        public string cText;
        public string cValue;
        public override string ToString()
        {
            return cText;
        }
    }
}
