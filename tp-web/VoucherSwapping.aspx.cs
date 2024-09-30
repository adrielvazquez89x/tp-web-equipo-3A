using Business;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_web
{
    public partial class VoucherForm : System.Web.UI.Page
    {
        public List<Article> ArtList { get; set; }
        public int SelectedArticle;
        protected void Page_Load(object sender, EventArgs e)
        {
            BusinessArticle busines = new BusinessArticle();
            ArtList = busines.list();
            //ArtList = new List<Article>
            //{
            //    new Article { Id = 1, Name = "Cosa 1", Description = "Descripcion de la cosa 1", Price = 100, UrlImages = new List<Model.Image>{ new Model.Image() } },
            //    new Article { Id = 2, Name = "Cosa 2", Description = "Descripcion de la cosa 2", Price = 200, UrlImages = new List<Model.Image>{ new Model.Image() } },
            //    new Article { Id = 3, Name = "Cosa 3", Description = "Descripcion de la cosa 3", Price = 300, UrlImages = new List<Model.Image>{ new Model.Image() } }
            //};

            //ArtList[0].UrlImages[0].UrlImage = "https://st2.depositphotos.com/7691758/10586/i/450/depositphotos_105869850-stock-photo-ravioli-with-tomato-sauce-and.jpg";
            //ArtList[1].UrlImages[0].UrlImage = "https://media.minutouno.com/p/c5f011d97f01b34e511d0f8e3bb09cf0/adjuntos/150/imagenes/039/409/0039409544/ravioles.jpg";
            //ArtList[2].UrlImages[0].UrlImage = "https://www.cetraro.com.ar/wp-content/uploads/canelones-con-verdura.jpg";

            if(!IsPostBack)
            {
                rptListaDeCosas.DataSource = ArtList;
                rptListaDeCosas.DataBind();
            }
        }

        protected void btnSwap_Click(object sender, EventArgs e)
        {
            try
            {
                BusinessVoucher business = new BusinessVoucher();
                if (txtVoucherCode.Text != "") //aunque ya se verifica con bootstrap
                {
                    string code = txtVoucherCode.Text;
                    Voucher aux = business.getVoucherByCode(code);
                    if (aux.IDClient == -1)
                    {
                        ShowErrorAndRedirect("There is no voucher with that code");
                    }
                    else
                    {
                        if (aux.DateExchange.Year == 1)
                        {
                            Wizard1.ActiveStepIndex = 1;
                        }
                        else
                        {
                            ShowErrorAndRedirect("The voucher you entered has already been used");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ShowErrorAndRedirect(string script)
        {
            script = "alert('"+script+ "'); window.location.href='Default.aspx';";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
        }

        protected void Wizard1_NextButtonClick(object sender, WizardNavigationEventArgs e)  //esto no es necesario... o para que?
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        protected void btnPick_Click(object sender, EventArgs e)
        {
            SelectedArticle = int.Parse(((Button)sender).CommandArgument);
            consola.Text = "click: " + SelectedArticle;
            Wizard1.ActiveStepIndex = 2;
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            searchDNI(txtDni.Text);
            Wizard1.ActiveStepIndex = 3;
        }

        protected void searchDNI(string dni)
        {
            BusinessCustomer business = new BusinessCustomer();
                Customer aux = business.findCustomerByDNI(dni);
            if (aux.Id > 0)
            {
                txtName.Text = aux.Name;
                txtLastName.Text = aux.LastName;
                txtEmail.Text = aux.Email;
                txtAdress.Text = aux.Address;
                txtCity.Text = aux.City;
                txtCP.Text = aux.CP.ToString();
            }
        }
    }
}