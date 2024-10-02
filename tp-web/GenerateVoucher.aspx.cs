using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;

namespace tp_web
{
    public partial class GenerateVoucher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnGenerateVoucher.Text = "Generar Voucher";
            BusinessVoucher business = new BusinessVoucher();

            string nuevo = business.GetLastCode();
        }

        protected void btnGenerateVoucher_Click(object sender, EventArgs e)
        {
            try
            {

                BusinessVoucher business = new BusinessVoucher();
                string codVoucher = business.AddVaucher();


                ltlVoucherCode.Text = codVoucher;

                // Mostrar la card
                voucherCard.Style["display"] = "block";

                btnGoToSwapping.Visible = true;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected void btnGoToSwapping_Click(object sender, EventArgs e)
        {
            Response.Redirect("VoucherSwapping.aspx"); 
        }


        //private void ShowToast(string message)
        //{
        //    ltlToastMessage.Text = message;

        //    ScriptManager.RegisterStartupScript(this, GetType(), "showToastie",
        //           "$(document).ready(function() { $('.toast').toast({ delay: 3000 }).toast('show'); });", true);
        //}
    }
}