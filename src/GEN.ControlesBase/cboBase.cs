using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboBase : ComboBox
    {
        private bool _agregarItemTodos = false;

        [DefaultValue(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AgregarItemTodos
        {
            get
            {
                return _agregarItemTodos;
            }
            set
            {
                _agregarItemTodos = value;
                if (_agregarItemTodos && DataSource != null)
                    AgregarTodos();
            }
        }

        public cboBase()
        {
            InitializeComponent();
        }

        public cboBase(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        protected void AgregarTodos()
        {
            AgregarItem(0, "TODOS");
        }

        protected void AgregarItem(int valor, string texto, int indice = 0)
        {
            if (DataSource is DataTable)
            {
                var datos = (DataTable)DataSource;
                var displayMember = DisplayMember;
                var valueMember = ValueMember;
                DataSource = null;
                DisplayMember = displayMember;
                ValueMember = valueMember;
                foreach (DataColumn column in datos.Columns)
                {
                    column.ReadOnly = false;
                }
                var row = datos.NewRow();
                row[ValueMember] = valor;
                row[DisplayMember] = texto;
                if (datos.Rows.Count == 0)
                {
                    datos.Rows.Add(row);
                }
                else
                {
                    datos.Rows.InsertAt(row, indice);
                }
                DataSource = datos;
            }
            else if (DataSource is IList)
            {
                var datos = (IList)DataSource;
                var tipo = datos.GetType().GetGenericArguments().FirstOrDefault();
                if (tipo != null)
                {
                    var obj = Activator.CreateInstance(tipo);
                    var valueProperty = tipo.GetProperty(ValueMember);
                    var displayProperty = tipo.GetProperty(DisplayMember);
                    valueProperty.SetValue(obj, valor, null);
                    displayProperty.SetValue(obj, texto, null);
                    datos.Insert(indice, obj);
                    var listType = typeof(List<>);
                    var constructedListType = listType.MakeGenericType(tipo);
                    var instance = (IList)Activator.CreateInstance(constructedListType);
                    foreach (var item in datos)
                    {
                        instance.Add(item);
                    }
                    DataSource = instance;
                }
            }
        }

    }
}
