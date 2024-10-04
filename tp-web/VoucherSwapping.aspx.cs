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
        public List<Model.Image> ImageList { get; set; }

        public int SelectedArticle;

        public Customer customer = new Customer();

        public Voucher voucher = new Voucher();

        public bool IsUserExists;
        protected void Page_Load(object sender, EventArgs e)
        {
            BusinessArticle busines = new BusinessArticle();
            BusinessImage businessImage = new BusinessImage();
            ArtList = busines.list();
            if (!IsPostBack)
            {
                for (int i = 0; i < ArtList.Count; i++)
                {
                    Article aux = ArtList[i];
                    aux.UrlImages = businessImage.list(aux.Id);
                }
                rptListaDeCosas.DataSource = ArtList;
                rptListaDeCosas.DataBind();
            }

        }

        protected void rptListaDeCosas_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Article currentArticle = (Article)e.Item.DataItem;
                Repeater rptImagesList = (Repeater)e.Item.FindControl("rptImagesList"); // Toma el Repeater anidado
                rptImagesList.DataSource = currentArticle.UrlImages;
                rptImagesList.DataBind();
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
                            Session["VoucherCode"] = voucher.Code;
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


        protected void Wizard1_NextButtonClick(object sender, WizardNavigationEventArgs e)  //esto no es necesario... o para que?
        {

        }

        protected void btnPick_Click(object sender, EventArgs e)
        {
            SelectedArticle = int.Parse(((Button)sender).CommandArgument);
            Session["SelectedArticle"] = SelectedArticle;
            Wizard1.ActiveStepIndex = 2;
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                switch (Model.Validation.OnlyDNI(txtDni.Text))
                {
                    case 0: //caso exitoso
                        lblError.Visible = false;
                        customer.Document = int.Parse(txtDni.Text);
                        customer.Id = searchDNI(customer.Document);
                        Session["CustomerDocument"] = customer.Document;
                        Session["CustomerId"] = customer.Id;
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

                    voucher.Code = Session["VoucherCode"].ToString();

                    customer.Id = (int)Session["CustomerId"];
                    //si el usuario es nuevo, el id aca es -1 y debemos cambiarlo al nuevo id que se genere
                    //if (customer.Id == -1) //caso de usuario nuevo
                    //{
                    //    IsUserExists = false;
                    //}

                    IsUserExists = customer.Id == -1 ? false : true;

                    customer.Document = (int)Session["CustomerDocument"];
                    customer.Name = txtName.Text;
                    customer.LastName = txtLastName.Text;
                    customer.Email = txtEmail.Text;
                    customer.Address = txtAdress.Text;
                    customer.City = txtCity.Text;
                    customer.CP = int.Parse(txtCP.Text);

                    if (IsUserExists)
                    {
                        customerBusiness.modifyCustomer(customer);
                    }
                    else
                    {
                        customer.Id = customerBusiness.AddCustomer(customer);
                    }
                    
                    //si el usuario NO es nuevo debemos chequear si hubo cambios en la info y actualizar
                    SelectedArticle = (int)Session["SelectedArticle"]; //recupero el articulo

                    voucherBusiness.ModifyVoucher(voucher.Code, customer.Id, DateTime.Now.Date, SelectedArticle);

                    //si pongo un mail que ya existe me da error 

                    EmailService emailService = new EmailService();
                    string subject = "Confirmación de participación";
                    string body = $"¡Gracias por participar! Has elegido el premio: {SelectedArticle}.";
                    emailService.createMail(customer.Email, subject, body);
                    emailService.sendEmail();

                    Response.Redirect("Success.aspx");

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool FieldsValidation()
        {
            lblErrorName.Visible = lblErrorLastName.Visible = lblErrorCity.Visible = lblErrorAdress.Visible = lblErrorCP.Visible = false;
            switch (Model.Validation.OnlyCP(txtCP.Text))
            {
                case -1: //ingresaron caracter no numerico
                    lblErrorCP.Visible = true;
                    lblErrorCP.Text = "Only Numbers";
                    break;
                case -2: //el largo no es  el correcto
                    lblErrorCP.Visible = true;
                    lblErrorCP.Text = "CP must have between 4 and 8 digits long";
                    break;
                case -3: //inicia con 0
                    lblErrorCP.Visible = true;
                    lblErrorCP.Text = "CP cannot start with 0";
                    break;
            }
            switch (Model.Validation.OnlyLetters(txtName.Text, txtName.Text.Length))
            {
                case -1: //ingresaron caracter que no es letra
                    lblErrorName.Visible = true;
                    lblErrorName.Text = "Only Letters";
                    break;
                case -2: //el largo no es  el correcto
                    lblErrorName.Visible = true;
                    lblErrorName.Text = "Min Length 3, Max length 50";
                    break;
            }
            switch (Model.Validation.OnlyLetters(txtLastName.Text, txtLastName.Text.Length))
            {
                case -1: //ingresaron caracter que no es letra
                    lblErrorLastName.Visible = true;
                    lblErrorLastName.Text = "Only Letters";
                    break;
                case -2: //el largo no es  el correcto
                    lblErrorLastName.Visible = true;
                    lblErrorLastName.Text = "Min Length 3, Max length 50";
                    break;
            }
            switch (Model.Validation.NumbersAndLetters(txtCity.Text, txtCity.Text.Length))
            {
                case -1: //ingresaron caracter que no es letra
                    lblErrorCity.Visible = true;
                    lblErrorCity.Text = "No symbols or puntuaction";
                    break;

                ///validar que no sean solo nros
                ///
                case -2: //el largo no es  el correcto
                    lblErrorCity.Visible = true;
                    lblErrorCity.Text = "Min Length 3, Max length 50";
                    break;
                case -3: //no hay 3 letras
                    lblErrorCity.Visible = true;
                    lblErrorCity.Text = "At least 3 non-numeric characters";
                    break;
            }
            switch (Model.Validation.NumbersAndLetters(txtAdress.Text, txtAdress.Text.Length))
            {
                case -1: //ingresaron caracter que no es letra
                    lblErrorAdress.Visible = true;
                    lblErrorAdress.Text = "No symbols or puntuaction";
                    break;
                case -2: //el largo no es  el correcto
                    lblErrorAdress.Visible = true;
                    lblErrorAdress.Text = "Min Length 3, Max length 50";
                    break;
                case -3: //no hay 3 letras
                    lblErrorAdress.Visible = true;
                    lblErrorAdress.Text = "At least 3 non-numeric characters";
                    break;
            }
            //validacion para email necesitamos?..

            if (lblErrorName.Visible || lblErrorLastName.Visible || lblErrorCity.Visible || lblErrorAdress.Visible || lblErrorCP.Visible) //si hay un cartel de error visible entonces es porque no paso todas las validaciones, devuelvo false
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