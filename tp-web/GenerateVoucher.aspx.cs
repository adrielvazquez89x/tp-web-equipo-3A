using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_web
{
    public partial class GenerateVoucher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnGenerateVoucher.Text = "Generar Voucherrrrrrrrrrrrrrr";
        }

        protected void btnGenerateVoucher_Click(object sender, EventArgs e)
        {
            btnGenerateVoucher.Text = "Voucher Generado";
        }
    }
}