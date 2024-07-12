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
    [ToolboxData("<{0}:btnImprimir runat=server></{0}:btnImprimir>")]
    public class btnImprimir : Button
    {
        protected override void Render(HtmlTextWriter writer)
        {
            this.Text = "Imprimir";
            this.CssClass = "btnBase_Imprimir";
            base.Render(writer);
        }
    }
}
