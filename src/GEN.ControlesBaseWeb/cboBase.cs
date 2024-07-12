using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

[assembly: TagPrefix("GEN.ControlesBaseWeb", "SolIntELS")]
namespace GEN.ControlesBaseWeb
{
    [System.Drawing.ToolboxBitmap(typeof(DropDownList))]

    [ToolboxData("<{0}:cboBase runat=server></{0}:cboBase>")]

    public class cboBase : DropDownList
    {
        private void Llenardropdown()
        {
            this.CssClass = "cmbBase";
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Llenardropdown();
        }
    }
}