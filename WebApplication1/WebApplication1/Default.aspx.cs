using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Text;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //ArrayList arr = new ArrayList(5);
                //arr.Add("Red");
                //arr.Add("Green");
                //arr.Add("Blue");
                //arr.Add("Orange");
                //arr.Add("White");

                //DropDownList1.DataSource = arr;
                //DropDownList1.DataBind();
                addDatePickerScript();

                this.Page.ClientScript.RegisterClientScriptBlock(typeof(_Default), "EntityLookup1", GetClientScript1(), true);
                this.Page.ClientScript.RegisterClientScriptBlock(typeof(_Default), "EntityLookup2", GetClientScript2(), true);

                this.DropDownList3.Attributes.Add("onChange", "javascript:OnSelectedIndexChange(this)");

                this.DropDownList4.Attributes.Add("onChange", "javascript:OnEntityChange(this);");

                this.RequiredFieldValidator1.Visible = false;
            }

            if (Page.IsPostBack)
            {
                this.Label1.Text = "page postback: " + DateTime.Now;
            }

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListItem item = ((DropDownList)sender).SelectedItem;

            //this.TextBox1.Text = ((DropDownList)sender).SelectedValue + " -> " + ((DropDownList)sender).Text;
            this.TextBox1.Text = item.Value + " -> " + item.Text;
        }

        private string GetClientScript1()
        {
            StringBuilder sb = new StringBuilder(1000);
            sb.Append("function OnSelectedIndexChange(c) {");
            sb.Append("var ddl = document.getElementById(_gDDLDepartmentID);");
            sb.Append("alert(ddl.id + \" -> \" + ddl.value);");
            sb.Append("}");
            return sb.ToString();
        }

        private string GetClientScript2()
        {
            StringBuilder sb = new StringBuilder(1000);
            sb.Append(string.Format("var _gDDLDepartmentID = \"{0}\";", this.DropDownList2.ClientID));
            return sb.ToString();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            this.TextBox4.Text = GetItemID(this.TextBox3.Text);
        }

        private string GetItemID(string value)
        {
            string Id = string.Empty;

            if (!string.IsNullOrEmpty(value))
            {
                Id = value.Substring(value.LastIndexOf(Convert.ToChar("/")) + 1);
                if (!string.IsNullOrEmpty(Id))
                {
                    Id = Id.Remove(Id.IndexOf(Convert.ToChar("_")));
                }
            }

            return Id;
        }

        private void addDatePickerScript()
        {
            string DatePicker_Script = string.Empty;
            DatePicker_Script += "<script type=\"text/javascript\">";
            DatePicker_Script += "$(function() {";
            DatePicker_Script += "$(\"#" + TextBox4.ClientID + "\").datepicker({";
            DatePicker_Script += "showOn: \"button\", buttonImage: \"IMAGES/calendar.gif\",";
            DatePicker_Script += "buttonImageOnly: true,";
            DatePicker_Script += "changeMonth: true,";
            DatePicker_Script += "changeYear: true,";
            DatePicker_Script += "minDate: null,";
            DatePicker_Script += "maxDate: 0,";
            DatePicker_Script += "yearRange: '1950:1990',";
            DatePicker_Script += "onSelect: function(selectedDate){";
            DatePicker_Script += "$('" + TextBox4.ClientID + "').value(selectedDate);}});";
            DatePicker_Script += "$('#ui-datepicker-div').addClass(\"ui-datepicker-us\");});";
            DatePicker_Script += "</script>";
            
            Page.ClientScript.RegisterStartupScript(this.GetType(), TextBox4.ID.ToString(), DatePicker_Script);

            
        }

        private void AddValidator() 
        {
            RequiredFieldValidator rfv = new RequiredFieldValidator();
            rfv.ID = "RequiredFieldValidator2";
            rfv.ControlToValidate   = this.TextBox2.ID;
            rfv.ErrorMessage = "Value is required for this field";
            Page.Controls.Add(rfv);
        }
    }
}
