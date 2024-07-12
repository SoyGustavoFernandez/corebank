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
    [ToolboxData("<{0}:btnConsultar runat=server></{0}:btnConsultar>")]
    public class btnConsultar : Button
    {
        protected override void Render(HtmlTextWriter writer)
        {
            this.Text = "Consultar";
            this.CssClass = "btnBase_Consultar";
            base.Render(writer);
        } 
    }
}