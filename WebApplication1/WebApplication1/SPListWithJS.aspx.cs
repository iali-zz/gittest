using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using System.Data;

namespace WebApplication1
{
    public partial class SPListWithJS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateEntities();
        }

        protected void PopulateEntities()
        {
            try
            {
                using (SPSite site = new SPSite("http://aku.iali.com/"))
                {
                    //SPWeb root = SPContext.Current.Site.RootWeb;
                    SPWeb root = site.OpenWeb();

                    SPList EntitiesList = root.Lists["Entities"];

                    SPListItemCollection allEntities = EntitiesList.Items;

                    DataTable dtEntities = EntitiesList.Items.GetDataTable();
                    DataView dvEntities = dtEntities.DefaultView;
                    dvEntities.Sort = "Title ASC";

                    for (int i = 0; i <= dvEntities.Count - 1; i++)
                    {
                        if (dvEntities[i] != null && dvEntities[i]["Title"] != null)
                        {
                            SPListItem item = allEntities.GetItemById((int)dvEntities[i]["ID"]);
                            //String discValue = item.UniqueId.ToString() + "##" + (item.Web.ServerRelativeUrl.Equals("/") ? "" : item.Web.ServerRelativeUrl) + "/" + item.Url;

                            this.DropDownList1.Items.Add(item["Title"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.Label1.Text = ex.Message;
            }
        }
    }
}