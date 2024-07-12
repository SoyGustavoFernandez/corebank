using CNE.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.ControlesBase
{
    public partial class cboPDPEstado : cboBase
    {
        clsCNPdp cnRptPdp = new clsCNPdp();
        DataTable dt = new DataTable();

        public cboPDPEstado()
        {
            InitializeComponent();
        }

        public cboPDPEstado(IContainer container)
        {
            container.Add(this);
            InitializeComponent();         
        }

        private void cargarVigentes()
        {
            this.dt = cnRptPdp.ObtenerEstados();

            if (dt.AsEnumerable().Count(x => Convert.ToBoolean(x["lVigente"])) > 0)
            {
                dt = dt.AsEnumerable().Where(x => Convert.ToBoolean(x["lVigente"])).CopyToDataTable();
            }            

            DataRow dr = dt.NewRow();

            dr["idPDPEstado"] = 0;
            dr["cEstado"] = "TODOS";

            dt.Rows.InsertAt(dr, 0);                        
        }

        public void ModalidadPDPEstado(int nModalidad)
        {
            this.cargarVigentes();
            
            List<DataRow> drToDelete = new List<DataRow>();

            switch (nModalidad)
            { 
                case 1:                    
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (Convert.ToInt32(dr["idPDPEstado"]) != 0 && Convert.ToInt32(dr["idPDPEstado"]) != 1 && Convert.ToInt32(dr["idPDPEstado"]) != 2 && Convert.ToInt32(dr["idPDPEstado"]) != 6)
                        {
                            drToDelete.Add(dr);                            
                        }
                    }

                    foreach (DataRow dr in drToDelete)
                    {
                        dt.Rows.Remove(dr);                        
                    }
                    break;
                case 2:                    
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (Convert.ToInt32(dr["idPDPEstado"]) != 1 && Convert.ToInt32(dr["idPDPEstado"]) != 2)
                        {
                            drToDelete.Add(dr);                            
                        }
                    }

                    foreach (DataRow dr in drToDelete)
                    {
                        dt.Rows.Remove(dr);                        
                    }
                    break;               
                case 3:
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (Convert.ToInt32(dr["idPDPEstado"]) != 0 && Convert.ToInt32(dr["idPDPEstado"]) != 1 && Convert.ToInt32(dr["idPDPEstado"]) != 3 && Convert.ToInt32(dr["idPDPEstado"]) != 6)
                        {
                            drToDelete.Add(dr);
                        }
                    }

                    foreach (DataRow dr in drToDelete)
                    {
                        dt.Rows.Remove(dr);
                    }
                    break;
                case 4:
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (Convert.ToInt32(dr["idPDPEstado"]) != 1 && Convert.ToInt32(dr["idPDPEstado"]) != 3)
                        {
                            drToDelete.Add(dr);
                        }
                    }

                    foreach (DataRow dr in drToDelete)
                    {
                        dt.Rows.Remove(dr);
                    }
                    break;
                case 5:
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (Convert.ToInt32(dr["idPDPEstado"]) != 4 && Convert.ToInt32(dr["idPDPEstado"]) != 5 && Convert.ToInt32(dr["idPDPEstado"]) != 6)
                        {
                            drToDelete.Add(dr);
                        }
                    }

                    foreach (DataRow dr in drToDelete)
                    {
                        dt.Rows.Remove(dr);
                    }
                    break;
            }            

            ValueMember = "idPDPEstado";
            DisplayMember = "cEstado";
            DataSource = dt;
        }        
    }
}
