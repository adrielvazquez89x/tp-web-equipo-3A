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
        public Customer customer = new Customer();
        public Voucher voucher = new Voucher();
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

            if (!IsPostBack)
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
                    voucher = business.getVoucherByCode(code);

                    if (voucher.IDClient == -1)
                    {
                        Session["error"] = "There is no voucher with that code.";
                        Response.Redirect("Error.aspx");
                    }
                    else
                    {
                        if (voucher.DateExchange.Year == 1)
                        {
                            ViewState["VoucherCode"] = voucher.Code; //necesario para que no se pierda este dato
                            Wizard1.ActiveStepIndex = 1;
                        }
                        else
                        {
                            Session["error"] = "The voucher you entered has already been used.";
                            Response.Redirect("Error.aspx"); 
                        }
                    }
                }
                else
                {
                    Session["error"] = "The voucher code field cannot be empty.";
                    Response.Redirect("Error.aspx");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //private void ShowErrorAndRedirect(string script)
        //{
        //    script = "alert('" + script + "'); window.location.href='Default.aspx';";
        //    ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
        //}

        protected void Wizard1_NextButtonClick(object sender, WizardNavigationEventArgs e)  //esto no es necesario... o para que?
        {

        }

        protected void btnPick_Click(object sender, EventArgs e)
        {
            SelectedArticle = int.Parse(((Button)sender).CommandArgument);
            consola.Text = "click: " + SelectedArticle;
            ViewState["SelectedArticle"] = SelectedArticle; //necesario para que no se pierda este dato
            Wizard1.ActiveStepIndex = 2;
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                switch (Model.Validation.onlyDNI(txtDni.Text))
                {
                    case 0: //caso exitoso
                        lblError.Visible = false;
                        customer.Document = int.Parse(txtDni.Text);  //aca asigno el dni ingresado
                        customer.Id = searchDNI(customer.Document);
                        ViewState["CustomerDocument"] = customer.Document; //necesario para que no se pierda este dato
                        ViewState["CustomerId"] = customer.Id; //necesario para que no se pierda este dato
                        Wizard1.ActiveStepIndex = 3;
                        break;
                    case -1: //ingresaron caracter no numerico
                        lblError.Visible = true;
                        lblError.Text = "Only Numbers";
                        break;
                    case -2: //el largo no es 8
                        lblError.Visible = true;
                        lblError.Text = "DNI must be exactly 8 digits long";
                        break;
                    case -3: //inicia con 0
                        lblError.Visible = true;
                        lblError.Text = "DNI cannot start with 0";
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected int searchDNI(int dni)
        {
            BusinessCustomer business = new BusinessCustomer();
            customer = business.findCustomerByDNI(dni);
            if (customer.Id > 0)
            {
                txtName.Text = customer.Name;
                txtLastName.Text = customer.LastName;
                txtEmail.Text = customer.Email;
                txtAdress.Text = customer.Address;
                txtCity.Text = customer.City;
                txtCP.Text = customer.CP.ToString();
            }
            return customer.Id;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            try
            {
                //aca van validaciones de los datos del cliente previo a inserta en la bd,
                if (!FieldsValidation()) //solo si valida los campos conecto a la BD, sino, salgo de la funcion. AUN ESTA INCOMPLETA
                {
                    return;
                }
                else
                {
                    BusinessCustomer customerBusiness = new BusinessCustomer();
                    BusinessVoucher voucherBusiness = new BusinessVoucher();

                    voucher.Code = ViewState["VoucherCode"] as string; //recupero el codigo de voucher

                    customer.Id = (int)ViewState["CustomerId"]; //recupero el id, si el usuario es nuevo, el id aca es -1 y debemos cambiarlo al nuevo id que se genere
                    if (customer.Id == -1) //caso de usuario nuevo
                    {
                        customer.Document = (int)ViewState["CustomerDocument"]; //recupero el dni del viewState ya que es nuevo y aun no esta en la BD
                        customer.Name = txtName.Text;
                        customer.LastName = txtLastName.Text;
                        customer.Email = txtEmail.Text;
                        customer.Address = txtAdress.Text;
                        customer.City = txtCity.Text;
                        customer.CP = int.Parse(txtCP.Text);
                        customer.Id = customerBusiness.AddCustomer(customer);
                    }
                    //si el usuario NO es nuevo debemos chequear si hubo cambios en la info y actualizar
                    SelectedArticle = (int)ViewState["SelectedArticle"]; //recupero el articulo

                        voucherBusiness.ModifyVoucher(voucher.Code, customer.Id, DateTime.Now.Date, SelectedArticle);

                        consola.Text += " Voucher canjeado exitosamente.";


                    Response.Redirect("Success.aspx");
                    //informar que se canjeo el premio...
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool FieldsValidation()
        {
            lblError2.Visible = false;
            switch (Model.Validation.onlyCP(txtCP.Text))  //valido el campo CP
            {
                case -1: //ingresaron caracter no numerico
                    lblError2.Visible = true;
                    lblError2.Text = "Only Numbers";
                    break;
                case -2: //el largo no es  el correcto
                    lblError2.Visible = true;
                    lblError2.Text = "CP must have between 4 and 8 digits long";
                    break;
                case -3: //inicia con 0
                    lblError2.Visible = true;
                    lblError2.Text = "CP cannot start with 0";
                    break;
            }

            //ACA FALTAN LAS OTRAS VALIDACIONES PARA CADA CAMPO..

            if (lblError2.Visible == true) //si hay un cartel de error visible entonces es porque no paso todas las validaciones, devuelvo false
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        protected void chkAgree_CheckedChanged(object sender, EventArgs e)
        {
            btnSubmit.Enabled = chkAgree.Checked;
        }
    }
}