using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GEN.CapaNegocio;
using System.Data;
using CRE.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboEstadoExpediente : cboBase
    {
        
        clsCNControlExp CondicionExp = new clsCNControlExp();
        public cboEstadoExpediente()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboEstadoExpediente(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            DataTable dtCondicion = CondicionExp.CNListaEstadoExpediente();
           
            this.DataSource = dtCondicion;
            this.ValueMember = dtCondicion.Columns["idEstadoExp"].ToString();
            this.DisplayMember = dtCondicion.Columns["cDescripEstado"].ToString();
        }        
    }
}
