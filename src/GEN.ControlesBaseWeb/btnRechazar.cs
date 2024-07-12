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
    [ToolboxData("<{0}:btnRechazar runat=server></{0}:btnRechazar>")]
    public class btnRechazar : Button
    {
        protected override void Render(HtmlTextWriter writer)
        {
            this.Text = "Rechazar";
            this.CssClass = "btnBase_Cancelar";
            base.Render(writer);
        }
    }
}