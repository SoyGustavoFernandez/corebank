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
    public partial class cboCondicionExp : cboBase
    {
        
        clsCNControlExp CondicionExp = new clsCNControlExp();
        public cboCondicionExp()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboCondicionExp(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            DataTable dtCondicion = CondicionExp.CNListaCondExpediente();
           
            this.DataSource = dtCondicion;
            this.ValueMember = dtCondicion.Columns["idCondicionExp"].ToString();
            this.DisplayMember = dtCondicion.Columns["cDescripCond"].ToString();
        }        
    }
}
