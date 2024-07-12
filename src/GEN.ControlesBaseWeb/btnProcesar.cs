using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

[assembly: TagPrefix("GEN.ControlesBaseWeb", "SolIntELS")]
namespace GEN.ControlesBaseWeb
{

    [ToolboxData("<{0}:btnProcesar runat=server></{0}:btnProcesar>")]
    public class btnProcesar : btnGrabar
    {
        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);
            this.Text = "Procesar";
            this.CssClass = "btnBase_Procesar";
        }
    }
}
