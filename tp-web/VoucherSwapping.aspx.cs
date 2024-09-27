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
        protected void Page_Load(object sender, EventArgs e)
        {

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
    }
}