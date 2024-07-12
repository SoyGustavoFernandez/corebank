using CRE.CapaNegocio;
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
    public partial class cboMes : cboBase
    {
        clsCNIntervCre cninterviniente = new clsCNIntervCre();
        DataTable dt;
        public cboMes()
        {
            InitializeComponent();
        }

       public cboMes(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
    
        }

       public void cargarTodos(string nroDoc, int idTipoDoc, int idTipoDocumento)
        {
            

            if (idTipoDocumento == 1) //PERSONA NATURAL
            {
                dt = cninterviniente.dtCalifEntityRccSbs(idTipoDoc, nroDoc).AsEnumerable().Where(r => r.Field<Int32>("nVinculado") == 1).OrderByDescending(r =>Convert.ToInt32(r.Field<long>("nOrden"))).CopyToDataTable();
            }

            if (idTipoDocumento == 4)//PERSONA JURIDICA
            {
                dt = cninterviniente.dtCalifEntityRccSbs(idTipoDoc, nroDoc).AsEnumerable().OrderByDescending(r => Convert.ToInt32(r.Field<long>("nOrden"))).CopyToDataTable();
            }

            this.DataSource = dt;
            this.ValueMember = dt.Columns["fechaCalfSBS"].ToString();
            this.DisplayMember = dt.Columns["fechaCalfSBS"].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
