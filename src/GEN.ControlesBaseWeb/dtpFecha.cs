using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

[assembly: TagPrefix("GEN.ControlesBaseWeb", "SolIntELS")]
namespace GEN.ControlesBaseWeb
{
    [System.Drawing.ToolboxBitmap(typeof(Calendar))]
    [ToolboxData("<{0}:dtpFecha runat=server></{0}:dtpFecha>")]
    public class dtpFecha : CompositeControl
    {
        TextBox textBox;
        ImageButton imageButton;
        Calendar calendar;

        [Category("Appearance")]
        [Description("Setear la imagen para el calendario")]
        public string ImagenBotonUrl
        {
            get
            {
                EnsureChildControls();
                return imageButton.ImageUrl != null ? imageButton.ImageUrl : string.Empty;
            }
            set
            {
                EnsureChildControls();
                imageButton.ImageUrl = value;
            }
        }

        protected override void RecreateChildControls()
        {
            //permite que no se desaqparezca el contenido del valor de la propiedad
            //que se a creado
            EnsureChildControls();
        }

        protected override void CreateChildControls()
        {
            Controls.Clear();
            textBox = new TextBox();
            textBox.ID = "fechaTextBox";
            textBox.Width = Unit.Pixel(80);
            textBox.CssClass = "txtBase";

            imageButton = new ImageButton();
            //imageButton.ImageUrl = @"~/Images/btnCale.png";
            imageButton.ID = "ImagenBotonCalendario";
            imageButton.Click += new ImageClickEventHandler(imageButton_click);
            imageButton.CssClass = "IconoCalendario";

            calendar = new Calendar();
            calendar.ID = "ControlCalendario";
            calendar.Visible = false;

            calendar.CssClass = "CalendarioBase";
            calendar.DayStyle.CssClass = "DiaCalendarioBase";
            calendar.OtherMonthDayStyle.CssClass = "OtrosDiaCalendarioBase";
            calendar.SelectorStyle.CssClass = "SelectorDiaCalendarioBase";
            calendar.TitleStyle.CssClass = "TituloCalendarioBase";
            calendar.NextPrevStyle.CssClass = "NextPrevCalendarioBase";
            calendar.SelectionChanged += new EventHandler(calendar_SelectionChanged);

            //añadir controles hijos para calendario personalizado
            this.Controls.Add(textBox);
            this.Controls.Add(imageButton);
            this.Controls.Add(calendar);
        }

        [Category("Appearance")]
        [Description("Obtiene o asigna la fecha del calendario personalizado")]
        public DateTime obtenerFechaSeleccionada
        {
            get
            {
                EnsureChildControls();
                return string.IsNullOrEmpty(textBox.Text) ? DateTime.MinValue : Convert.ToDateTime(textBox.Text);
            }
            set
            {
                if (value != null)
                {
                    EnsureChildControls();
                    textBox.Text = value.ToShortDateString();
                    calendar.SelectedDate = value;
                }
                else
                {
                    EnsureChildControls();
                    textBox.Text = "";
                    calendar.VisibleDate = DateTime.Today;
                }
            }
        }

        void calendar_SelectionChanged(object sender, EventArgs e)
        {
            textBox.Text = calendar.SelectedDate.ToShortDateString();
            ObtenerValorFechaCalendarioEventArgs eventoFecha = new ObtenerValorFechaCalendarioEventArgs(calendar.SelectedDate);
            //llamamos al metodo que hemos creado
            OnDateSelection(eventoFecha);
            calendar.Visible = false;
        }

        //creamos el metodo para el evento click
        void imageButton_click(object sender, ImageClickEventArgs e)
        {
            if (calendar.Visible)
            {
                calendar.Visible = false;
            }
            else
            {
                calendar.Visible = true;
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    calendar.VisibleDate = DateTime.Today;
                }
                else
                {
                    DateTime output = DateTime.Today;
                    bool isConvertidoConExitoDateTime = DateTime.TryParse(textBox.Text, out output);
                    calendar.VisibleDate = output;
                }
            }
        }

        protected override void Render(HtmlTextWriter output)
        {
            AddAttributesToRender(output);
            output.AddAttribute(HtmlTextWriterAttribute.Cellpadding, "");

            output.RenderBeginTag(HtmlTextWriterTag.Table);
            output.RenderBeginTag(HtmlTextWriterTag.Tr);
            output.RenderBeginTag(HtmlTextWriterTag.Td);
            textBox.RenderControl(output);
            output.RenderEndTag();

            output.RenderBeginTag(HtmlTextWriterTag.Td);
            imageButton.RenderControl(output);
            output.RenderEndTag();

            output.RenderEndTag();//cierre tag tr
            output.RenderEndTag();//cierre tag table
            calendar.RenderControl(output);
        }

        public event ObtenerValorFechaCalendarioHandler FechaSeleccionada;

        protected virtual void OnDateSelection(ObtenerValorFechaCalendarioEventArgs e)
        {
            if (FechaSeleccionada != null)
            {
                FechaSeleccionada(this, e);
            }
        }
    }

    public class ObtenerValorFechaCalendarioEventArgs : EventArgs
    {
        private DateTime _fechaSeleccionada;

        public ObtenerValorFechaCalendarioEventArgs(DateTime fechaSeleccionada)
        {
            this._fechaSeleccionada = fechaSeleccionada;
        }
        public DateTime FechaSeleccionada
        {
            get
            {
                return this._fechaSeleccionada;
            }
        }

    }

    public delegate void ObtenerValorFechaCalendarioHandler(object sender, ObtenerValorFechaCalendarioEventArgs e);
}
