using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Text.RegularExpressions;

namespace WebApplication1
{
    public partial class datetime : System.Web.UI.Page
    {
        private const string ERROR_EMPTY_INPUT = "You must specify a value for this required field.";
        private const string ERROR_INVALID_END_DATETIME ="You must specify a valid date within the range of {0} and 12/31/8900.";
        private const string ERROR_INVALID_START_DATETIME = "You must specify a valid date within the range of 1/1/1900 and 12/31/8900.";
        private const string ERROR_SMALLER_START_DATETIME = "Start date time must be greater than end date time.";

        protected void Page_Load(object sender, EventArgs e)
        {
            ClearErrors();

            if (!Page.IsPostBack)
            {
                FillHours(this.ddlHours1);
                FillHours(this.ddlHours2);
                FillMinutes(this.ddlMinutes1);
                FillMinutes(this.ddlMinutes2);
            }

            AddDatePickerScript(this.txtStartDate);
            AddDatePickerScript(this.txtEndDate);

            this.ddlHours1.Text = "7 AM";
            this.ddlMinutes1.Text = "30";
        }

        private void FillHours(DropDownList ddl) 
        {
            ArrayList al = new ArrayList() { "12 AM", "1 AM", "2 AM", "3 AM", "4 AM", "5 AM", "6 AM", "7 AM", "8 AM", "9 AM", "10 AM", "11 AM", "12 PM", "1 PM", "2 PM", "3 PM", "4 PM", "5 PM", "6 PM", "7 PM", "8 PM", "9 PM", "10 PM", "11 PM" };
            
            ddl.DataSource = al;
            ddl.DataBind();

            ddl.SelectedIndex = 0;
        }

        private void FillMinutes(DropDownList ddl) 
        {
            ArrayList al = new ArrayList() { "00", "05", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55" };

            ddl.DataSource = al;
            ddl.DataBind();

            ddl.SelectedIndex = 0;
        }

        private void AddDatePickerScript(TextBox txt)
        {
            string DatePicker_Script = string.Empty;
            DatePicker_Script += "<script type='text/javascript'>";
            DatePicker_Script += "$(function() {";
            DatePicker_Script += "$('#" + txt.ClientID + "').datepicker({";
            DatePicker_Script += "showOn: 'button', buttonImage: 'IMAGES/calendar.gif',";
            DatePicker_Script += "buttonImageOnly: true";
            //DatePicker_Script += "changeMonth: true,";
            //DatePicker_Script += "changeYear: true,";
            //DatePicker_Script += "minDate: null,";
            //DatePicker_Script += "maxDate: 0,";
            //DatePicker_Script += "onSelect: function(selectedDate){";
            //DatePicker_Script += "$('" + txt.ClientID + "').value(selectedDate);}";
            DatePicker_Script += "});";
            DatePicker_Script += "$('#ui-datepicker-div').addClass('ui-datepicker-us');});";
            DatePicker_Script += "</script>";

            Page.ClientScript.RegisterStartupScript(this.GetType(), txt.ID.ToString(), DatePicker_Script);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ValidateInput();
        }

        private void ValidateInput() 
        {
            bool IsValidInput = true;

            if (string.IsNullOrEmpty(this.txtStartDate.Text)) 
            {
                this.ShowErrorPanel1(ERROR_EMPTY_INPUT);
            }

            if (string.IsNullOrEmpty(this.txtEndDate.Text)) 
            {
                this.ShowErrorPanel2(ERROR_EMPTY_INPUT);
            }

            // validate date formats
            Regex regex = new Regex(@"^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$");
            if (!string.IsNullOrEmpty(this.txtStartDate.Text) && !regex.IsMatch(this.txtStartDate.Text))
            {
                ShowErrorPanel1(ERROR_INVALID_START_DATETIME);
                IsValidInput = false;
            }
            if (!string.IsNullOrEmpty(this.txtEndDate.Text) && !regex.IsMatch(this.txtEndDate.Text))
            {
                ShowErrorPanel2(string.Format(ERROR_INVALID_END_DATETIME,DateTime.Today.ToShortDateString()));
                IsValidInput = false;
            }

            if (!IsValidInput)
                return;
            
            // validate end date is greater than equals to Now
            if (!string.IsNullOrEmpty(this.txtStartDate.Text) && !string.IsNullOrEmpty(this.txtEndDate.Text)) 
            {
                DateTime startDateTime;
                DateTime endDateTime;

                if (DateTime.TryParse(string.Format("{0} {1}", this.txtEndDate.Text, GetTime(this.ddlHours2.Text, this.ddlMinutes2.Text)), out endDateTime))
                {
                    if (endDateTime < DateTime.Now)
                    {
                        ShowErrorPanel2(string.Format(ERROR_INVALID_END_DATETIME, DateTime.Today.ToShortDateString()));
                    }
                    else 
                    {
                        // validate end date is greater than start date            
                        if (DateTime.TryParse(string.Format("{0} {1}", this.txtStartDate.Text, GetTime(this.ddlHours1.Text, this.ddlMinutes1.Text)), out startDateTime))
                        {
                            if (startDateTime < endDateTime)
                            {
                                ShowErrorPanel1(ERROR_SMALLER_START_DATETIME);
                            }
                        }
                        else 
                        {
                            ShowErrorPanel1(ERROR_INVALID_START_DATETIME);
                        }
                    }
                }
                else 
                {
                    ShowErrorPanel2(string.Format(ERROR_INVALID_END_DATETIME, DateTime.Today.ToShortDateString()));
                }
            }
        }

        private string GetTime(string hour, string minute) 
        {
            string[] hr = hour.Split(Convert.ToChar(" "));
            return  string.Format("{0}:{1} {2}", hr[0], minute, hr[1]);
        }

        private void ShowErrorPanel1(string msg) 
        {
            litScript.Text += "<script type='text/javascript'>$('#divError1').toggle();</script>";
            this.lblError1.Text = msg;
        }

        private void ShowErrorPanel2(string msg) 
        {
            litScript.Text += "<script type='text/javascript'>$('#divError2').toggle();</script>";
            this.lblError2.Text = msg;
        }

        private void ClearErrors() 
        {
            litScript.Text = string.Empty;
        }
    }
}