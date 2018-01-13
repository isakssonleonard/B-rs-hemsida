using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Börs_hemsida
{
    public partial class index : System.Web.UI.Page
    {
        private void börser(Control page)
        {
            List<string> lista = new List<string>();
            try
            { 
                XDocument xDoc = XDocument.Load(Session["path"].ToString());
                foreach (var item in xDoc.Descendants("aktie"))
                {
                    lista.Add(item.Element("börslista").Value);
                    
                    if (!(DropDownList1.Items.FindByValue(item.Element("aktieslag").Value) != null))
                    {
                        DropDownList1.Items.Add(item.Element("aktieslag").Value);
                    }
                }
                IEnumerable<string> börser = lista.Distinct();
                Repeater1.DataSource = börser;
                Repeater1.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(page, page.GetType(), "Error", ex.Message, true);
            }          
        }

        private void visaEfterAktieslag(string aktieslag, string text, Control page)
        {
            List<Aktie> aktier = new List<Aktie>();           
            try
            {
                XDocument xDoc = XDocument.Load(Session["path"].ToString());
                foreach (var item in xDoc.Descendants("aktie"))
                {
                    if (item.Element("börslista").Value == text && item.Element("aktieslag").Value == aktieslag)
                    {
                        Aktie aktie = new Aktie(item.Attribute("namn").Value, Convert.ToDouble(item.Element("kostar").Value), Convert.ToDouble(item.Element("säljs").Value), item.Element("aktieslag").Value, item.Element("börslista").Value);
                        aktier.Add(aktie);
                    }
                }
                GridView.DataSource = aktier;
                GridView.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(page, page.GetType(), "Error", ex.Message, true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["path"] = Server.MapPath("XML/aktier.xml");
                börser(this);
                for (int i = 0; i < Repeater1.Items.Count; i++)
                {
                    LinkButton button = Repeater1.Items[i].FindControl("Text") as LinkButton;                   
                    button.Click += new EventHandler(button_OnClick);
                }      
            }
        }

        protected void button_OnClick(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            sök(button.Text, this);
            Session["aktivlänk"] = button.Text;
        }

        private void sök(string text, Control page) 
        {
            List<Aktie> aktier = new List<Aktie>();
            try
            {
                XDocument xDoc = XDocument.Load(Session["path"].ToString());
                foreach (var item in xDoc.Descendants("aktie"))
                {
                    if (item.Element("börslista").Value == text)
                    {
                        Aktie aktie = new Aktie(item.Attribute("namn").Value, Convert.ToDouble(item.Element("kostar").Value), Convert.ToDouble(item.Element("säljs").Value), item.Element("aktieslag").Value, item.Element("börslista").Value);
                        aktier.Add(aktie);
                    }
                }
                GridView.DataSource = aktier;
                GridView.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(page, page.GetType(), "Error", ex.Message, true);
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["aktivlänk"] != null)
            {
                visaEfterAktieslag(DropDownList1.SelectedItem.ToString(), Session["aktivlänk"].ToString(), this);
            }           
        }
    }
}