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
using GEN.CapaNegocio;
using System.Reflection;
using System.IO;

namespace ADM.Presentacion
{
    public partial class frmControlObjetos : frmBase
    {
        #region Variables Globales

        clsCNFormulario objformulario = new clsCNFormulario();
        clslisControl controles = new clslisControl();
        clsFormulario form = new clsFormulario();
        Dictionary<string, Form> dictForm = new Dictionary<string, Form>();

        #endregion

        public frmControlObjetos()
        {
            InitializeComponent();
            cargarEventos();
        }

        #region Eventos

        private void Form1_Load(object sender, EventArgs e)
        {
            cboEventos_SelectedIndexChanged(sender, e);
            cargarFormularios((int)cboModulo.SelectedValue);
        }       

        private void lstFormularios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstFormularios.Items.Count>0)
            {
                clsFormulario objform = (clsFormulario)lstFormularios.SelectedItem;

                if (cboListaPerfil.SelectedValue is clsPerfil)
                {
                    return;
                }
                if (cboEventos.SelectedValue is clsTipoEvento)
                {
                    return;
                }

                cargarControles(objform.cFormulario, (int)cboListaPerfil.SelectedValue, (int)cboEventos.SelectedValue);
            }
            
        }

        private void lstControles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstControles.Items.Count>0)
            {
                clsControl objcontrol = (clsControl)lstControles.SelectedItem;

                asignarestado(objcontrol.idEstado);

            }
            
        }        

        private void cboListaPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboListaPerfil.SelectedIndex>=0)
            {
                cargarFormularios((int)cboModulo.SelectedValue);
                if (lstFormularios.Items.Count>0)
                {
                    cargarControles(lstFormularios.SelectedItem.ToString(), (int)cboListaPerfil.SelectedValue, (int)cboEventos.SelectedValue);
                }
                else
                {
                    cargarControles("", (int)cboListaPerfil.SelectedValue, (int)cboEventos.SelectedValue);
                }
            }
            
        }

        private void cboModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboModulo.SelectedIndex>=0)
            {
                cargarFormularios((int)cboModulo.SelectedValue);
                if (lstFormularios.Items.Count > 0)
                {
                    cargarControles(lstFormularios.SelectedItem.ToString(), (int)cboListaPerfil.SelectedValue,(int)cboEventos.SelectedValue);
                }
                else
                {
                    cargarControles("", (int)cboListaPerfil.SelectedValue, (int)cboEventos.SelectedValue);
                }
            }
            
        }

        private void rbtnNoVisible_CheckedChanged(object sender, EventArgs e)
        {
            if (lstControles.Items.Count>0)
            {
                if (rbtnNoVisible.Checked==true)
                {
                    ((clsControl)lstControles.SelectedItem).idEstado = 1;
                }
            }
            grbEstados.Refresh();
        }

        private void rbtnVisible_CheckedChanged(object sender, EventArgs e)
        {
            if (lstControles.Items.Count > 0)
            {
                if (rbtnVisible.Checked == true)
                {
                    ((clsControl)lstControles.SelectedItem).idEstado = 2;
                }
            }
            grbEstados.Refresh();
        }

        private void rbtnNoHabilitado_CheckedChanged(object sender, EventArgs e)
        {
            if (lstControles.Items.Count > 0)
            {
                if (rbtnNoHabilitado.Checked == true)
                {
                    ((clsControl)lstControles.SelectedItem).idEstado = 3;
                }
            }
            grbEstados.Refresh();
        }

        private void rbtnHabilitado_CheckedChanged(object sender, EventArgs e)
        {
            if (lstControles.Items.Count > 0)
            {
                if (rbtnHabilitado.Checked == true)
                {
                    ((clsControl)lstControles.SelectedItem).idEstado = 4;
                }
            }
            grbEstados.Refresh();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            clslisControl listacontrol = (clslisControl)lstControles.DataSource;

            objformulario.insertarCrontorlByPerfil(listacontrol, (int)cboListaPerfil.SelectedValue,(int)cboEventos.SelectedValue);

            MessageBox.Show("Se actualizaron los controles", "Inserción control objetos", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void cboEventos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEventos.SelectedIndex >= 0)
            {
                cargarFormularios((int)cboModulo.SelectedValue);
                if (lstFormularios.Items.Count > 0)
                {
                    cargarControles(lstFormularios.SelectedItem.ToString(), (int)cboListaPerfil.SelectedValue, (int)cboEventos.SelectedValue);
                }
                else
                {
                    cargarControles("", (int)cboListaPerfil.SelectedValue, (int)cboEventos.SelectedValue);
                }
            }
        }
        #endregion

        #region Metodos

        private void cargarFormularios(int idModulo)
        {
            lstFormularios.DataSource = new clsCNFormulario().listarFormularios(idModulo);
        }
        private void cargarReportes(int idModulo)
        {
            this.lstReportes.DataSource = new clsCNFormulario().listarFormularios(idModulo);
        }

        private void cargarControles(string cNombreForm, int idPerfil, int idTipoEvento)
        {
            lstControles.DataSource = objformulario.listarcontrolesByForm(cNombreForm, idPerfil, idTipoEvento);
        }

        private void asignarestado(int idEstado)
        {
            switch (idEstado)
            {
                case 1:
                    rbtnNoVisible.Checked = true;
                    rbtnVisible.Checked = false;
                    rbtnNoHabilitado.Checked = false;
                    rbtnHabilitado.Checked = false;
                    break;
                case 2:
                    rbtnNoVisible.Checked = false;
                    rbtnVisible.Checked = true;
                    rbtnNoHabilitado.Checked = false;
                    rbtnHabilitado.Checked = false;
                    break;

                case 3:
                    rbtnNoVisible.Checked = false;
                    rbtnVisible.Checked = false;
                    rbtnNoHabilitado.Checked = true;
                    rbtnHabilitado.Checked = false;
                    break;
                case 4:
                    rbtnNoVisible.Checked = false;
                    rbtnVisible.Checked = false;
                    rbtnNoHabilitado.Checked = false;
                    rbtnHabilitado.Checked = true;
                    break;
                default:
                    rbtnNoVisible.Checked = false;
                    rbtnVisible.Checked = false;
                    rbtnNoHabilitado.Checked = false;
                    rbtnHabilitado.Checked = false;
                    break;
            }
        }

        private void cargarEventos()
        {
            List<clsTipoEvento> listaeventos = new List<clsTipoEvento>();
            listaeventos.Add(new clsTipoEvento() { idTipoEvento = 1, cEvento = "INICIO" });
            listaeventos.Add(new clsTipoEvento() { idTipoEvento = 2, cEvento = "NUEVO" });
            listaeventos.Add(new clsTipoEvento() { idTipoEvento = 3, cEvento = "EDITAR" });
            listaeventos.Add(new clsTipoEvento() { idTipoEvento = 4, cEvento = "CANCELAR" });
            listaeventos.Add(new clsTipoEvento() { idTipoEvento = 5, cEvento = "GRABAR" });
            listaeventos.Add(new clsTipoEvento() { idTipoEvento = 6, cEvento = "IMPRIMIR" });
            
            cboEventos.SelectedIndexChanged -= new EventHandler(cboEventos_SelectedIndexChanged);            
            cboEventos.DataSource = listaeventos;
            cboEventos.DisplayMember = "cEvento";
            cboEventos.ValueMember = "idTipoEvento";
            cboEventos.SelectedIndexChanged += new EventHandler(cboEventos_SelectedIndexChanged);            
        }

        #endregion       

        private void tbcObjetosControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbcObjetosControl.SelectedIndex==0)
            {
                cboModulo.SelectedValue = 1;
                cboEventos.SelectedValue = 1;
                cboModulo.Enabled = true;
                cboEventos.Enabled = true;
                cargarFormularios((int)cboModulo.SelectedValue);
                if (lstFormularios.Items.Count > 0)
                {
                    cargarControles(lstFormularios.SelectedItem.ToString(), (int)cboListaPerfil.SelectedValue, (int)cboEventos.SelectedValue);
                }
                else
                {
                    cargarControles("", (int)cboListaPerfil.SelectedValue, (int)cboEventos.SelectedValue);
                }
                btnActualizar1.Visible = true;
            }
            if (tbcObjetosControl.SelectedIndex == 1)
            {
                cboModulo.SelectedValue = 11;
                cboEventos.SelectedValue = 1;
                cboModulo.Enabled = false;
                cboEventos.Enabled = false;

                cargarReportes(0);

                if (this.lstReportes.Items.Count > 0)
                {
                    cargarControlReportes(lstReportes.SelectedItem.ToString(), (int)cboListaPerfil.SelectedValue, (int)cboEventos.SelectedValue);
                }
                else
                {
                    cargarControlReportes("", (int)cboListaPerfil.SelectedValue, (int)cboEventos.SelectedValue);
                }
                btnActualizar1.Visible = false;
            }
        }

        private void cargarControlReportes(string cNombreForm, int idPerfil, int idTipoEvento)
        {
            //lstBotones.Items.Clear();
            this.lstBotones.DataSource = objformulario.listarcontrolesByForm(cNombreForm, idPerfil, 1);
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            
        }

        private void lstBotones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBotones.Items.Count > 0)
            {
                clsControl objcontrol = (clsControl)lstBotones.SelectedItem;

                asignarestadoReporte(objcontrol.idEstado);

            }
        }
        private void asignarestadoReporte(int idEstado)
        {
            switch (idEstado)
            {
                case 1:
                    rbtnRptNoVisible.Checked = true;
                    rbtnRptVisible.Checked = false;
                    break;
                case 2:
                    rbtnRptNoVisible.Checked = false;
                    rbtnRptVisible.Checked = true;
                    break;
                default:
                    rbtnRptNoVisible.Checked = false;
                    rbtnRptVisible.Checked = false;
                    break;
            }
        }
        private void lstReportes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstReportes.Items.Count > 0)
            {
                clsFormulario objform = (clsFormulario)lstReportes.SelectedItem;

                if (cboListaPerfil.SelectedValue is clsPerfil)
                {
                    return;
                }
                if (cboEventos.SelectedValue is clsTipoEvento)
                {
                    return;
                }

                cargarControlReportes(objform.cFormulario, (int)cboListaPerfil.SelectedValue, (int)cboEventos.SelectedValue);
            }
            
        }

        private void btnRptGrabar_Click(object sender, EventArgs e)
        {
            clslisControl listacontrol = (clslisControl)this.lstBotones.DataSource;

            objformulario.insertarCrontorlByPerfil(listacontrol, (int)cboListaPerfil.SelectedValue, (int)cboEventos.SelectedValue);

            MessageBox.Show("Se actualizaron los controles", "Insercion control objetos", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void rbtnRptNoVisible_CheckedChanged(object sender, EventArgs e)
        {
            if (this.lstBotones.Items.Count > 0)
            {
                if (rbtnRptNoVisible.Checked == true)
                {
                    ((clsControl)lstBotones.SelectedItem).idEstado = 1;
                }
            }
            grbEstadosRpt.Refresh();
        }

        private void rbtnRptVisible_CheckedChanged(object sender, EventArgs e)
        {
            if (lstBotones.Items.Count > 0)
            {
                if (rbtnRptVisible.Checked == true)
                {
                    ((clsControl)lstBotones.SelectedItem).idEstado = 2;
                }
            }
            grbEstadosRpt.Refresh();
        }

        private void btnActualizar1_Click(object sender, EventArgs e)
        {
            Assembly assembly = null;
            string cNombreDLL = ((DataRowView)this.cboModulo.SelectedItem)["cComponente"].ToString();

            if (File.Exists(clsVarGlobal.cRutPathApp + @"\" + cNombreDLL))
            {
                assembly = Assembly.LoadFrom(cNombreDLL);
            }
            else
            {
                return;
            }

            string cFullName = cNombreDLL.Replace("dll", "").Trim() + this.lstFormularios.SelectedItem.ToString().Trim();

            Form frm;
            if (!dictForm.TryGetValue(cFullName, out frm) || frm.IsDisposed)
            {
                var frm1 = assembly.CreateInstance(cFullName);
                if (frm1 is Form)
                {
                    actualizarControles((Form)frm1, (int)this.cboModulo.SelectedValue);
                    ((Form)frm1).Dispose();
                }
            }

            MessageBox.Show("El formulario: "+ this.lstFormularios.SelectedItem.ToString().Trim()+" se actualizó correctamente", "Actualizar Formulario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  
        }

        private void actualizarControles(Control frmControl, int idModulo)
        {
            controles.Clear();
            recorrerControles(frmControl);

            form.cFormulario = frmControl.Name;
            form.lisControles = controles;
            form.idTipoForm = 1;
            form.idModulo = idModulo;

            if (!string.IsNullOrEmpty(frmControl.Name))
            {
                objformulario.actualizarControles(form);
            }
        }

        private void recorrerControles(Control frmControl)
        {
            foreach (Control c in frmControl.Controls)
            {
                if (c.Name != "")
                    controles.Add(new clsControl() { cControl = c.Name, control = c });

                if (c.Controls.Count > 0)
                    recorrerControles(c);
            }
        }
    }
}
