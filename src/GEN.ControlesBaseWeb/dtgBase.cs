﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

[assembly: TagPrefix("GEN.ControlesBaseWeb", "SolIntELS")]
namespace GEN.ControlesBaseWeb
{
    public delegate void FilterCommandEventHandler(object sender, FilterCommandEventArgs e);

    public class FilterCommandEventArgs : EventArgs
    {
        private string filterExpression;

        public FilterCommandEventArgs()
        {
        }

        public FilterCommandEventArgs(string filterExpression)
        {
            this.filterExpression = filterExpression;
        }

        public string FilterExpression
        {
            get
            {
                return this.filterExpression;
            }
            set
            {
                this.filterExpression = value;
            }
        }
    }

    [ToolboxData("<{0}:dtgBase runat=server></{0}:dtgBase>")]
    public class dtgBase : GridView
    {
        TextBox m_txtPageNo = null;
        Hashtable m_txtFilter = new Hashtable();
        Hashtable m_ddlFilter = new Hashtable();

        private static readonly object EventFilterCommand = new object();
        [Category("Extend GridView Events"), Description("ExtededGridView_OnFilterCommand")]
        public event EventHandler FilterCommand
        {
            add
            {
                base.Events.AddHandler(EventFilterCommand, value);
            }
            remove
            {
                base.Events.RemoveHandler(EventFilterCommand, value);
            }
        }

        public dtgBase()
        {
            PagerSettings.Position = PagerPosition.TopAndBottom;
        }

        protected virtual void InitializeTopPager(GridViewRow row, int columnSpan, PagedDataSource pagedDataSource)
        {
            TableCell cell = new TableCell();
            if (columnSpan > 1)
            {
                cell.ColumnSpan = columnSpan;
            }
            Literal ltrlSpan = new Literal();
            ltrlSpan.Text = "<span style='float:left'>&nbsp;" +
                pagedDataSource.DataSourceCount.ToString() +
                "&nbsp;record(s)&nbsp;found.</span>";
            cell.Controls.Add(ltrlSpan);
            row.Cells.Add(cell);
        }

        protected virtual void InitializeBottomPager(GridViewRow row, int columnSpan, PagedDataSource pagedDataSource)
        {
            TableCell goToCell = new TableCell();
            goToCell.Style.Add(HtmlTextWriterStyle.Width, "100%");

            Table pagerTable = (Table)row.Cells[0].Controls[0];
            pagerTable.Rows[0].Cells.Add(goToCell);

            Literal ltrlSpanBegin = new Literal();
            ltrlSpanBegin.Text = "<span style='float:right'>Page&nbsp;";

            if (m_txtPageNo == null)
            {
                m_txtPageNo = new TextBox();
                m_txtPageNo.Width = new Unit(20);
                m_txtPageNo.Style.Add("height", "10px");
                m_txtPageNo.Font.Size = new FontUnit("10px");
                m_txtPageNo.CssClass = this.PagerStyle.CssClass;
            }

            Literal ltrlText = new Literal();
            ltrlText.Text = "&nbsp;of&nbsp;" + PageCount.ToString();

            Button btnGo = new Button();
            btnGo.Text = "Go";
            btnGo.CommandName = "Page1";
            btnGo.CommandArgument = "2";
            btnGo.ID = "ctl_PageIndex";
            btnGo.Height = new Unit("16px");
            btnGo.Font.Size = new FontUnit("10px");
            btnGo.CssClass = this.PagerStyle.CssClass;
            if (this.PagerStyle.ForeColor != null)
            {
                btnGo.Style.Add(HtmlTextWriterStyle.Color,
                    this.PagerStyle.ForeColor.ToString());
            }

            Literal ltrlSpanEnd = new Literal();
            ltrlSpanEnd.Text = "</span>";

            goToCell.Controls.Add(ltrlSpanBegin);
            goToCell.Controls.Add(m_txtPageNo);
            goToCell.Controls.Add(ltrlText);
            goToCell.Controls.Add(btnGo);
            goToCell.Controls.Add(ltrlSpanEnd);
        }

        protected override void InitializePager(GridViewRow row, int columnSpan, PagedDataSource pagedDataSource)
        {
            if (this.Controls[0].Controls.Count == 0 &&
               (this.PagerSettings.Position == PagerPosition.Top ||
                this.PagerSettings.Position == PagerPosition.TopAndBottom))
            {
                InitializeTopPager(row, columnSpan, pagedDataSource);
            }
            else
            {
                base.InitializePager(row, columnSpan, pagedDataSource);
                InitializeBottomPager(row, columnSpan, pagedDataSource);
            }
        }

        protected virtual void HandlePageCommand(GridViewCommandEventArgs e)
        {
            TextBox txtPageIndex;
            txtPageIndex = (TextBox)((System.Web.UI.Control)e.CommandSource).Parent.Controls[1];
            Button btnPageIndex = (Button)((System.Web.UI.Control)e.CommandSource).Parent.Controls[3];
            if (txtPageIndex.Text.Length > 0)
            {
                try
                {
                    int ndx = int.Parse(txtPageIndex.Text);
                    ndx = ndx - 1;
                    if (ndx >= PageCount)
                        ndx = PageCount - 1;
                    if (ndx < 0)
                        ndx = 0;
                    this.PageIndex = ndx;
                    btnPageIndex.CommandArgument = txtPageIndex.Text;
                }
                catch (Exception e1)
                {
                    if (e1.Message.Length == 0)
                        return;
                }
            }
        }

        protected override void OnRowCommand(GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Page1":
                    HandlePageCommand(e);
                    break;
                default:
                    base.OnRowCommand(e);
                    break;
            }
        }

        protected virtual void AddFilter(int columnIndex, TableCell headerCell, DataControlField field)
        {
            if (headerCell.Controls.Count == 0)
            {
                LiteralControl ltlHeaderText = new LiteralControl(headerCell.Text);
                headerCell.Controls.Add(ltlHeaderText);
            }

            LiteralControl ltlBreak = new LiteralControl("</br>");
            headerCell.Controls.Add(ltlBreak);
            TextBox txtFilter = null;
            if (m_txtFilter.Contains(columnIndex))
            {
                txtFilter = (TextBox)m_txtFilter[columnIndex];
            }
            else
            {
                txtFilter = new TextBox();
                txtFilter.ID = ID + "_txtFilter" + columnIndex.ToString();// +headerCell.ClientID;
                if (field.ItemStyle.Width.Value != 0.0)
                {
                    txtFilter.Style.Add(HtmlTextWriterStyle.Width, Convert.ToString(field.ItemStyle.Width.Value - 40) + "px");
                }
                else if (field.HeaderStyle.Width.Value != 0.0)
                {
                    txtFilter.Style.Add(HtmlTextWriterStyle.Width, Convert.ToString(field.HeaderStyle.Width.Value - 40) + "px");
                }
                txtFilter.Style.Add(HtmlTextWriterStyle.Height, "10px");
                txtFilter.Style.Add(HtmlTextWriterStyle.FontSize, "9px");
                m_txtFilter[columnIndex] = txtFilter;
            }

            DropDownList ddlFilter;
            if (m_ddlFilter.Contains(columnIndex))
            {
                ddlFilter = (DropDownList)m_ddlFilter[columnIndex];
            }
            else
            {
                ddlFilter = new DropDownList();
                ddlFilter.ID = ID + "_ddlFilter" + columnIndex.ToString();
                ddlFilter.Items.Add(" ");
                ddlFilter.Items.Add("=");
                ddlFilter.Items.Add("<");
                ddlFilter.Items.Add(">");
                ddlFilter.Items.Add("<=");
                ddlFilter.Items.Add(">=");
                ddlFilter.AutoPostBack = true;
                ddlFilter.SelectedIndexChanged += new EventHandler(this.HandleFilterCommand);
                //ddlFilter.SelectedIndex = 0;
                ddlFilter.Style.Add(HtmlTextWriterStyle.Width, "30px");
                ddlFilter.Height = new Unit("7px");
                ddlFilter.Style.Add(HtmlTextWriterStyle.Height, "8px");
                ddlFilter.Style.Add(HtmlTextWriterStyle.FontSize, "8px");
                m_ddlFilter[columnIndex] = ddlFilter;
            }

            headerCell.Controls.Add(txtFilter);
            headerCell.Controls.Add(ddlFilter);
        }

        protected virtual void AddFilters(GridViewRow headerRow, DataControlField[] fields)
        {
            for (int i = 0; i < Columns.Count; i++)
            {
                if (Columns[i].HeaderText.EndsWith(" "))
                {
                    AddFilter(i, headerRow.Cells[i], fields[i]);
                }
            }
        }

        protected virtual void AddGlyph(GridView grid, GridViewRow item)
        {
            Label glyph = new Label();
            glyph.EnableTheming = false;
            glyph.Font.Name = "webdings";
            glyph.Text = (grid.SortDirection == SortDirection.Ascending ? " 5" : " 6");
            //glyph.Font.Size = FontUnit.Medium;
            //glyph.Text = "&nbsp;" + (grid.SortDirection == SortDirection.Ascending ? "&#9650;" : "&#9660;");
            // Find the column you sorted by
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                string colExpr = grid.Columns[i].SortExpression;
                if (colExpr != "" && colExpr == grid.SortExpression)
                {
                    item.Cells[i].Controls.Add(glyph);
                }
            }
        }

        protected virtual void InitializeHeaderRow(GridViewRow row, DataControlField[] fields)
        {
            AddGlyph(this, row);
            AddFilters(row, fields);
        }

        protected override void InitializeRow(GridViewRow row, DataControlField[] fields)
        {
            base.InitializeRow(row, fields);
            if (row.RowType == DataControlRowType.Header)
            {
                InitializeHeaderRow(row, fields);
            }
        }

        protected virtual string GetFilterCommand()
        {
            string filterCommand = "";
            for (int i = 0; i < this.Columns.Count; i++)
            {
                if (this.Columns[i].HeaderText.EndsWith(" "))
                {
                    DataControlFieldHeaderCell headerCell = (DataControlFieldHeaderCell)this.HeaderRow.Cells[i];
                    TextBox txtFilter = (TextBox)m_txtFilter[i];
                    DropDownList ddlFilter = (DropDownList)m_ddlFilter[i];
                    BoundField aColumn;
                    if (!(this.Columns[i] is BoundField) || string.IsNullOrEmpty(ddlFilter.SelectedValue.Trim()))
                    {
                        continue;
                    }
                    aColumn = (BoundField)this.Columns[i];
                    if (string.IsNullOrEmpty(txtFilter.Text))
                    {
                        continue;
                    }
                    if (string.IsNullOrEmpty(filterCommand))
                    {
                        filterCommand = aColumn.DataField + " " + ddlFilter.SelectedValue + " " + txtFilter.Text;
                    }
                    else
                    {
                        filterCommand += " AND " + aColumn.DataField + " " + ddlFilter.SelectedValue + " " + txtFilter.Text;
                    }
                }
            }

            return filterCommand;
        }

        protected virtual void ApplyFilterCommand(string filterCommand)
        {
            DataSourceView dsv = this.GetData();
            if (dsv is SqlDataSourceView)
            {
                string selectCommand = ((SqlDataSourceView)dsv).SelectCommand;
                if (selectCommand.Contains(filterCommand))
                {
                    return;
                }
                if (selectCommand.Contains("WHERE"))
                {
                    selectCommand += " AND " + filterCommand;
                }
                else
                {
                    selectCommand += " WHERE " + filterCommand;
                }
                ((SqlDataSourceView)dsv).SelectCommand = selectCommand;
            }
        }

        protected virtual void OnFilterCommand(FilterCommandEventArgs e)
        {
            EventHandler handler = (EventHandler)base.Events[EventFilterCommand];
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void HandleFilterCommand(object sender, EventArgs e)
        {
            this.RequiresDataBinding = true;
            FilterCommandEventArgs filterArgs = new FilterCommandEventArgs();
            filterArgs.FilterExpression = GetFilterCommand();
            this.OnFilterCommand(filterArgs);
        }

        protected override void Render(HtmlTextWriter writer)
        {
            this.AllowPaging = true;
            this.AllowSorting = true;
            this.RowStyle.CssClass = "rowStyle";
            this.HeaderStyle.CssClass = "headerStyle";
            this.PagerStyle.CssClass = "pagerStyle";
            this.AlternatingRowStyle.CssClass = "alternateStyle";
            base.Render(writer);
        }

        protected override void OnPreRender(EventArgs e)
        {
            string filterCommand = GetFilterCommand();

            if (string.IsNullOrEmpty(filterCommand) == false)
            {
                ApplyFilterCommand(filterCommand);
            }
            base.OnPreRender(e);
        }
    }
}
