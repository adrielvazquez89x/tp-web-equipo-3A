using Business;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_web
{
    public partial class Success : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Success"] != null)
            {
                if(Request.QueryString["Id"] != null)
                {
                    BusinessArticle artBusiness = new BusinessArticle();
                    Article selectedArt = new Article();
                    int id = int.Parse(Request.QueryString["Id"]);
                    selectedArt = artBusiness.findArticle(id);

                    lblCongrats.Visible = true;
                    lblP1.Visible = true;
                    lblP1.Text = "¡You are already participating for the "+ selectedArt.Name;
                    lbl2.Text = "We have sent a confirmation email to your address. Please check your inbox.";
                    Session.Remove("Success"); // Elimina el mensaje después de usarlo
                }
            }
            else
            {
                lblCongrats.Visible=false;
                lblP1.Visible = false;
                lbl2.Text= "Nothing to see here...";
            }
        }
    }
}